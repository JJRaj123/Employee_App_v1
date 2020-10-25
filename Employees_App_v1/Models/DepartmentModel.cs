using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_App_v1.Models
{
    public class DepartmentModel
    {
        [Key]
        public int Department_Id { get; set; }
        public string Department_Name { get; set; }
        public List<EmployeeModel> Employees { get; set; }
    }
}
