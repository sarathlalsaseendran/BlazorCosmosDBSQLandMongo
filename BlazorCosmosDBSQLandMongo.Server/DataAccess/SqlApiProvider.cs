using BlazorCosmosDBSQLandMongo.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorCosmosDBSQLandMongo.Server.DataAccess
{
    public class SqlApiProvider : IDataAccessProvider
    {
        private static readonly string CollectionId = "EmployeeSQL";

        public async Task Add(Employee employee)
        {
            try
            {
                await SqlApiRepository<Employee>.CreateItemAsync(employee, CollectionId);
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
                return await SqlApiRepository<Employee>.GetSingleItemAsync(id, CollectionId);
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
                return await SqlApiRepository<Employee>.GetItemsAsync(CollectionId);
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
                await SqlApiRepository<Employee>.UpdateItemAsync(employee.Id, employee, CollectionId);
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
                await SqlApiRepository<Employee>.DeleteItemAsync(id, CollectionId);
            }
            catch
            {
                throw;
            }
        }
    }
}
