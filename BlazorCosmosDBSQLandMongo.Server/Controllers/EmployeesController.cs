using BlazorCosmosDBSQLandMongo.Server.DataAccess;
using BlazorCosmosDBSQLandMongo.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorCosmosDBSQLandMongo.Server.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IDataAccessProvider _dataAccessProvider;
        public EmployeesController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }
        [HttpGet]
        [Route("api/Employees/Get")]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await _dataAccessProvider.GetEmployees();
        }

        [HttpPost]
        [Route("api/Employees/Create")]
        public async Task CreateAsync([FromBody]Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _dataAccessProvider.Add(employee);
            }
        }

        [HttpGet]
        [Route("api/Employees/Details/{id}")]
        public async Task<Employee> Details(string id)
        {
            var result = await _dataAccessProvider.GetEmployee(id);
            return result;
        }

        [HttpPut]
        [Route("api/Employees/Edit")]
        public async Task EditAsync([FromBody]Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _dataAccessProvider.Update(employee);
            }
        }

        [HttpDelete]
        [Route("api/Employees/Delete/{id}")]
        public async Task DeleteConfirmedAsync(string id)
        {
            await _dataAccessProvider.Delete(id);
        }
    }
}
