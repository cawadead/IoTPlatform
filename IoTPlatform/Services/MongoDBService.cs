﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using IoTPlatform.Models.Database;
using IoTPlatform.Classes;
using IoTPlatform.Support;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using IoTPlatform.Models.DTO;
using MongoDB.Driver.Core.Operations;

namespace IoTPlatform.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<FabricObject> _fabricObjectsCollection;
        private readonly IMongoCollection<TimeSeries> _timeSeriesCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            var client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            var database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);

            _fabricObjectsCollection = database.GetCollection<FabricObject>(mongoDBSettings.Value.FabricObjectsCollectionName);

            if (!MongoDBSettings.CollectionExists(database, mongoDBSettings.Value.TimeSeriesCollectionName)){
                database.CreateCollection(mongoDBSettings.Value.TimeSeriesCollectionName,
                    new CreateCollectionOptions { TimeSeriesOptions = new TimeSeriesOptions("timestamp") });
            }
            _timeSeriesCollection = database.GetCollection<TimeSeries>(mongoDBSettings.Value.TimeSeriesCollectionName);
        }
        #region FabricObjects
        public async Task<List<FabricObject>> GetAllFabricObjects()
        {
            return await _fabricObjectsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<List<FabricObject>> GetFabricObjects(int type)
        {
            var filter = new BsonDocument { { "type", type } };
            return await _fabricObjectsCollection.Find(filter).ToListAsync();
        }

        public async Task<List<FabricObject>> GetFabricObjects(string name)
        {
            var filter = new BsonDocument { { "name", name } };
            return await _fabricObjectsCollection.Find(filter).ToListAsync();
        }

        public async Task<List<FabricObject>> GetFabricObjectsByParentId(string parentId)
        {
            var filter = new BsonDocument { { "parentId", parentId } };
            return await _fabricObjectsCollection.Find(filter).ToListAsync();
        }

        public async Task<List<FabricObject>> GetFabricObjectById(string id)
        {
            var filter = new BsonDocument("_id", ObjectId.Parse(id));
            return await _fabricObjectsCollection.Find(filter).ToListAsync();
        }

        public async void SetFabricObjects(IEnumerable<FabricObjectDTO> fabricObjectsDto)
        {
            foreach (var fabricObjectDto in fabricObjectsDto)
            {
                if (!fabricObjectDto.ParentId.Equals("")) { }
                FabricObject fabricObject = new FabricObject()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    ParentId = ObjectId.Parse(fabricObjectDto.ParentId).ToString(),
                    Name = fabricObjectDto.Name,
                    Type = fabricObjectDto.Type,
                };
                await _fabricObjectsCollection.InsertOneAsync(fabricObject);
            }
            
        }

        #endregion

        #region TimeSeries
        public async Task<List<TimeSeries>> GetTimeSeries(
            DateTime from,
            DateTime to)
        {
            return _timeSeriesCollection.AsQueryable().Where(x => x.Date >= from && x.Date < to).ToList();
        }
        public async Task<List<List<TimeSeries>>> GetTimeSeriesPaginated(
            DateTime from,
            DateTime to,
            int pageSize)
        {
            var data = _timeSeriesCollection.AsQueryable().Where(x => x.Date >= from && x.Date < to).ToList();
            var result = new PaginatedList<TimeSeries>(data, pageSize);
            return result.GetList();
        }

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
