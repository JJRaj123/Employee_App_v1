using Employees_App_v1.Data;
using Employees_App_v1.Models;
using Employees_App_v1.Models.Custom;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Employees_App_v1.Services
{
    public class EmployeeService :IEmployeeService
    {
        private readonly ILogger _logger;
        private readonly EmployeeDbContext _context;
        public EmployeeService(EmployeeDbContext context,ILogger<EmployeeService> logger)
        {
            _context = context;
            _logger = logger;
        }
        /// <summary>
        /// Adding new employeee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string AddEmployee(EmployeeModel model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.First_Name) && !string.IsNullOrEmpty(model.Last_Name) && !string.IsNullOrEmpty(model.Email_Id) && IsValidMail(model.Email_Id)) {
                    var _model = _context.tbl_Employee.Where(w => w.Email_Id == model.Email_Id).ToList();
                    if (_model.Count == 0)
                    {
                        _context.Add(model);
                        _context.SaveChanges();
                        ///Send mail///
                        /////////////////
                        _logger.LogInformation("Added successfully {0}",model.Employee_Id);
                        return "Added Suceessfully";
                    }
                    else{
                        _logger.LogInformation("Already present {0}", model);
                        return "Already present";
                    }
                }
                else
                {
                    _logger.LogInformation("Invalid request {0}", model);
                    return "Invalid request";
                }
            }
            catch(Exception ex)
            {
                _logger.LogError("while adding employee error", ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// Edit and update the employee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string UpdateEmployee(EmployeeModel model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.First_Name) && !string.IsNullOrEmpty(model.Last_Name) && !string.IsNullOrEmpty(model.Email_Id) && IsValidMail(model.Email_Id))
                {
                    var _model = _context.tbl_Employee.Where(w => w.Email_Id == model.Email_Id).FirstOrDefault();
                    if (_model!= null)
                    {
                        _model.Email_Id = model.Email_Id;
                        _model.First_Name = model.First_Name;
                        _model.Last_Name = model.Last_Name;
                        _model.DepartmentId = model.DepartmentId;
                        _context.Attach(model);
                        _context.SaveChanges();
                        ///send mail///
                        /////////////////
                        _logger.LogInformation("Updated successfully {0}", model.Employee_Id);
                        return "Updated Suceessfully";
                    }
                    else
                    {
                        _logger.LogInformation("Model not present {0}", model);
                        return "Not present";
                    }
                }
                else
                {
                    _logger.LogInformation("Invalid request {0}", model);
                    return "Invalid request";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("while updating employee error", ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// Delete the employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteEmployee(int id)
        {
            try
            {
                var _model = _context.tbl_Employee.Where(w => w.Employee_Id == id).FirstOrDefault();
                if (_model != null)
                {
                    _context.Remove(_model);
                    ///send mail///
                    /////////////////
                    _logger.LogInformation("Deleted Successfully {0}", id);
                    return "Deleted Successfully";
                }
                else
                {
                    _logger.LogInformation("Invalid request {0}", id);
                    return "Invalid request";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("while deleting employee {0}", ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// Employee status for employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetEmployeeStatus(int id)
        {
            try
            {
                string Employeestatus = "";
                var model = _context.tbl_Employee.Where(w => w.Manager_Id == id).ToList();
                var chkManagerId = _context.tbl_Employee.Where(w => w.Employee_Id == id).Select(s => s.Manager_Id).FirstOrDefault();
                ///check if employee is 'Associate'
                if (model.Count == 0)
                {
                    Employeestatus = "Associate";
                }
                ///check if employee is 'Manager' or 'Head'
                else if (model.Count > 0 && !string.IsNullOrEmpty(chkManagerId.ToString()))
                {
                    Employeestatus = "Manager";
                }
                else if(model.Count > 0 && string.IsNullOrEmpty(chkManagerId.ToString()))
                {
                    Employeestatus = "Head";
                }
                _logger.LogInformation("Employee status fetched for {0} is {1}", id, Employeestatus);
                return Employeestatus;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Employee status fetched error for {0} is {1}", ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// List of All employees
        /// </summary>
        /// <returns></returns>
        public List<EmployeeModel> GetAllEmployees()
        {
            try
            {
                _logger.LogInformation("Fetched all employees");
                return _context.tbl_Employee.OrderBy(o=>o.First_Name).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Fetched all employees error {0}", ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// getting list of employeesby filter
        /// </summary>
        /// <returns></returns>
        public List<EmployeeModel> GetAllEmployeesByFilter(FilterEmployeeModel model)
        {
            List<EmployeeModel> _lst = new List<EmployeeModel>();
            try
            {
                if (!string.IsNullOrEmpty(model.Department) || !string.IsNullOrEmpty(model.FirstName) || !string.IsNullOrEmpty(model.Id) || !string.IsNullOrEmpty(model.LastName))
                {
                    _lst = _context.tbl_Employee.Include(i => i.DepartmentId).Where(w => model.Department != null ? w.DepartmentId.Department_Id == Convert.ToInt32(model.Department) : model.FirstName != null ? w.First_Name == model.FirstName : model.Id != null ? w.Employee_Id == Convert.ToInt32(model.Id) : model.LastName != null ? w.Last_Name == model.LastName : false).OrderBy(o => o.First_Name).ToList();
                    _logger.LogInformation("Fetched employees by filter {0}", _lst);
                   return _lst;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Fetched employees by filter error {0}", ex.Message);
                throw ex;
            }
        }
        //checking email is valid or not//
        public bool IsValidMail(string mail)
        {
            bool isEmail = Regex.IsMatch(mail, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            return isEmail;
        }
    }
}
