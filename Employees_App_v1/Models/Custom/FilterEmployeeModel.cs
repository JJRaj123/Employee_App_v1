using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_App_v1.Models.Custom
{
    public class FilterEmployeeModel
    {
        public string Id { get; set; }
        public string Department { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
