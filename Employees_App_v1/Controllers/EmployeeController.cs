using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employees_App_v1.Models;
using Employees_App_v1.Models.Custom;
using Employees_App_v1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employees_App_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        [Route("allemployees")]
        public IActionResult GetAllEmployees()
        {
            return Ok(_employeeService.GetAllEmployees());
        }
        [HttpPost]
        [Route("allemployeesfilter")]
        public IActionResult GetFilterAllEmployees([FromBody] FilterEmployeeModel model)
        {
            var response = _employeeService.GetAllEmployeesByFilter(model);
            return Ok(response);
        }
        [HttpGet]
        [Route("getemployeestatus/{id}")]
        public IActionResult GetEmployeeStatus(int id)
        {
            var response = _employeeService.GetEmployeeStatus(id);
            return Ok(response);
        }
        [HttpPost]
        [Route("addemployee")]
        public IActionResult AddEmployee(EmployeeModel model)
        {
            var response = _employeeService.AddEmployee(model);
            return Ok(response);
        }
        [HttpPost]
        [Route("updateemployee")]
        public IActionResult UpdateEmployee(EmployeeModel model)
        {
            var response = _employeeService.UpdateEmployee(model);
            return Ok(response);
        }
        [HttpPost]
        [Route("deleteemployee")]
        public IActionResult DeleteEmployee(int id)
        {
            var response = _employeeService.DeleteEmployee(id);
            return Ok(response);
        }
    }
}
