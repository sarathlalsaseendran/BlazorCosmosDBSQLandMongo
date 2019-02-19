using BlazorCosmosDBSQLandMongo.Shared.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorCosmosDBSQLandMongo.Server.DataAccess
{
    public class MongoApiProvider : IDataAccessProvider
    {
        MongoApiContext db = new MongoApiContext();

        public async Task Add(Employee employee)
        {
            try
            {
                await db.Employee.InsertOneAsync(employee);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Employee> GetEmployee(string id)
        {
            try
            {
                FilterDefinition<Employee> filter = Builders<Employee>.Filter.Eq("Id", id);

                return await db.Employee.Find(filter).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            try
            {
                return await db.Employee.Find(_ => true).ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task Update(Employee employee)
        {
            try
            {
                await db.Employee.ReplaceOneAsync(filter: g => g.Id == employee.Id, replacement: employee);
            }
            catch
            {
                throw;
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                FilterDefinition<Employee> data = Builders<Employee>.Filter.Eq("Id", id);
                await db.Employee.DeleteOneAsync(data);
            }
            catch
            {
                throw;
            }
        }
    }
}
