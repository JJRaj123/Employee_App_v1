using Employees_App_v1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_App_v1.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<DepartmentModel> tbl_Department { get; set; }
        public DbSet<EmployeeModel> tbl_Employee { get; set; }
    }
}
