using MongoDB.Driver;
using MongoDB.Bson;
using IoTPlatform.Models.Database;
using IoTPlatform.Classes;
using IoTPlatform.Support;
using IoTPlatform.Models.DTO;
using IoTPlatform.Classes.Consts;

namespace IoTPlatform.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<FabricObject> _fabricObjectsCollection;
        private readonly IMongoCollection<TimeSeries> _timeSeriesCollection;

        public MongoDBService(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>(EnvironmentConsts.MONGODB_CONNECTION_STRING));
            var database = client.GetDatabase(configuration.GetValue<string>(EnvironmentConsts.MONGODB_IOT_DATABASE_NAME));

            _fabricObjectsCollection = database.GetCollection<FabricObject>(configuration.GetValue<string>(EnvironmentConsts.FABRIC_OBJECT_COLLECTION_NAME));

            if (!MongoDBSettings.CollectionExists(database, configuration.GetValue<string>(EnvironmentConsts.TIME_SERIES_COLLECTION_NAME))){
                database.CreateCollection(configuration.GetValue<string>(EnvironmentConsts.TIME_SERIES_COLLECTION_NAME),
                    new CreateCollectionOptions { TimeSeriesOptions = new TimeSeriesOptions(timeField: "timestamp", metaField: "metadata") });
            }

            _timeSeriesCollection = database.GetCollection<TimeSeries>(configuration.GetValue<string>(EnvironmentConsts.TIME_SERIES_COLLECTION_NAME));
        }

        #region FabricObjects
        /// <summary>
        /// Получить все объекты
        /// </summary>
        /// <returns></returns>
        public async Task<List<FabricObject>> GetAllFabricObjects()
        {
            return await _fabricObjectsCollection.Find(new BsonDocument()).ToListAsync();
        }
        
        /// <summary>
        /// Получить все объекты заданного типа
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<List<FabricObject>> GetFabricObjects(int type)
        {
            var filter = new BsonDocument { { "type", type } };
            return await _fabricObjectsCollection.Find(filter).ToListAsync();
        }

        /// <summary>
        /// Получить объекты с заданным именем
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<List<FabricObject>> GetFabricObjects(string name)
        {
            var filter = new BsonDocument { { "name", name } };
            return await _fabricObjectsCollection.Find(filter).ToListAsync();
        }

        /// <summary>
        /// Получить объекты по Id родитеского элемента
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public async Task<List<FabricObject>> GetFabricObjectsByParentId(string parentId)
        {
            var filter = new BsonDocument { { "parentId", parentId } };
            return await _fabricObjectsCollection.Find(filter).ToListAsync();
        }

        /// <summary>
        /// Получить объект по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<FabricObject>> GetFabricObjectById(string id)
        {
            var filter = new BsonDocument("_id", ObjectId.Parse(id));
            return await _fabricObjectsCollection.Find(filter).ToListAsync();
        }

        /// <summary>
        /// Добавить объекты
        /// </summary>
        /// <param name="fabricObjectsDto"></param>
        /// <returns></returns>
        public async Task<(int, string)> SetFabricObjects(IEnumerable<FabricObjectDTO> fabricObjectsDto)
        {
            try
            {
                await _fabricObjectsCollection.InsertManyAsync(fabricObjectsDto.Select(x => new FabricObject
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ParentId = ObjectId.Parse(x.ParentId).ToString(),
                    Name = x.Name,
                    Type = x.Type,
                }));
                return (StatusCodes.Status200OK, "Succesfully inserted");
            }
            catch (Exception ex)
            {
                return (StatusCodes.Status400BadRequest, ex.Message);
            }
            
        }

        #endregion

        #region TimeSeries
        /// <summary>
        /// Получить все записи TimeSeries в заданном временном промежутке
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public async Task<List<TimeSeries>> GetTimeSeries(
            DateTime from,
            DateTime to)
        {
            return _timeSeriesCollection.AsQueryable().Where(x => x.Date >= from && x.Date < to).ToList();
        }

        /// <summary>
        /// Получить все записи TimeSeries в заданном временном промежутке в виде массивов заданного размера
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<List<List<TimeSeries>>> GetTimeSeriesPaginated(
            DateTime from,
            DateTime to,
            int pageSize)
        {
            var data = _timeSeriesCollection.AsQueryable().Where(x => x.Date >= from && x.Date < to).ToList();
            var result = new PaginatedList<TimeSeries>(data, pageSize);
            return result.GetList();
        }

        /// <summary>
        /// Получить страницу записей TimeSeries в заданном временном промежутке и с заданной страницей
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public async Task<List<TimeSeries>> GetTimeSeriesPage(
            DateTime from,
            DateTime to,
            int pageSize,
            int pageNumber)
        {
            var data = _timeSeriesCollection.AsQueryable().Where(x => x.Date >= from && x.Date < to).ToList();
            return PaginatedList<TimeSeries>.GetListPage(data, pageSize, pageNumber);
        }
        #endregion
    }
}
