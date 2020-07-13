using MAS.HandsOnTest.Core.Service;
using System;
using System.Web.Http;

namespace MAS.HandsOnTest.WebApi.Controllers
{
    /// <summary>
    /// Employee controler
    /// </summary>
    public class EmployeesController : ApiController
    {
        readonly IEmployeeService _employeeService;

        /// <summary>
        /// Controler constructor
        /// </summary>
        /// <param name="employeeService"></param>
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        /// <summary>
        /// Get employees
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {            
            return Ok(_employeeService.GetEmployees());
        }
        
        /// <summary>
        /// Get employee by id
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            return Ok(_employeeService.GetEmployeeById(id));
        }        
    }
}
