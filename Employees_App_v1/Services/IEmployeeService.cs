using Employees_App_v1.Models;
using Employees_App_v1.Models.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_App_v1.Services
{
    public interface IEmployeeService
    {
        string AddEmployee(EmployeeModel model);
        string UpdateEmployee(EmployeeModel model);
        string DeleteEmployee(int id);
        string GetEmployeeStatus(int id);
        List<EmployeeModel> GetAllEmployees();
        List<EmployeeModel> GetAllEmployeesByFilter(FilterEmployeeModel model);
    }
}
