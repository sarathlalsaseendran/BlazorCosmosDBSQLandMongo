using BlazorCosmosDBSQLandMongo.Shared.Models;
using MongoDB.Driver;

namespace BlazorCosmosDBSQLandMongo.Server.DataAccess
{
    public class MongoApiContext
    {
        private readonly IMongoDatabase _mongoDb;

        public MongoApiContext()
        {
            var client = new MongoClient("mongodb://localhost:C2y6yDjf5%2FR%2Bob0N8A7Cgv30VRDJIWEHLM%2B4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw%2FJw%3D%3D@localhost:10255/admin?ssl=true");
            _mongoDb = client.GetDatabase("SarathCosmosDB");
        }

        public IMongoCollection<Employee> Employee
        {
            get
            {
                return _mongoDb.GetCollection<Employee>("EmployeeMongo");
            }
        }
    }
}
