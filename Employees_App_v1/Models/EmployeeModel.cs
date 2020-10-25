using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_App_v1.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Employee_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email_Id { get; set; }
        public int Manager_Id { get; set; }
        public DepartmentModel DepartmentId { get; set; }
    }
}
