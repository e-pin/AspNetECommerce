using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        private readonly IConfiguration _configuration;
        private MongoClient _client;
        private IMongoDatabase _database;

        public CatalogContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new MongoClient(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            _database = _client.GetDatabase(_configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            var collectionName = _configuration.GetValue<string>("DatabaseSettings:CollectionName");
            Products = _database.GetCollection<Product>(collectionName);
            CatalogContectSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
