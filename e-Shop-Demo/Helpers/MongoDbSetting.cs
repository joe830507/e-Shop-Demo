namespace e_Shop_Demo.Helpers
{
    public class MongoDbSetting : IMongoDbSetting
    {
        public string Uri { get; set; }
        public string DatabaseName { get; set; }
    }
}
