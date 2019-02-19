using BlazorCosmosDBSQLandMongo.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorCosmosDBSQLandMongo.Server.DataAccess
{
    public interface IDataAccessProvider
    {
        Task Add(Employee employee);
        Task Update(Employee employee);
        Task Delete(string id);
        Task<Employee> GetEmployee(string id);
        Task<IEnumerable<Employee>> GetEmployees();
    }
}
