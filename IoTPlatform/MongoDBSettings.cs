namespace IoTPlatform
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string FabricObjectsCollectionName { get; set; } = null!;
        public string TimeSeriesCollectionName { get; set; } = null!;
    }
}
