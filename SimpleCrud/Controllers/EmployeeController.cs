using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SimpleCrud.Database;
using SimpleCrud.Models;
using System.Linq;

namespace SimpleCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        EmployeeContext _employeeContext;

        public EmployeeController(EmployeeContext employeeContext, IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
            _employeeContext = employeeContext;
        }

       
        public IActionResult Get()
        {
            HttpContext.Response.Headers.Add("Region", _appSettings.AppRegion);

            var result =_employeeContext.Employee.ToList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeContext.Employee.Add(employee);
                _employeeContext.SaveChanges();
                return Ok(employee);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]Employee employee)
        {
            if (ModelState.IsValid)
            {
                var exsistingEmployee = _employeeContext.Employee.FirstOrDefault(t => t.EmployeeID == employee.EmployeeID);
                if (exsistingEmployee != null)
                {
                    exsistingEmployee.Address = employee.Address;
                    exsistingEmployee.DateOfBirth = employee.DateOfBirth;
                    exsistingEmployee.EmployeeNumber = employee.EmployeeNumber;
                    exsistingEmployee.FullName = employee.FullName;
                    exsistingEmployee.IDNumber = employee.IDNumber;
                    _employeeContext.Employee.Update(exsistingEmployee);
                    _employeeContext.SaveChanges();
                    return Ok(employee);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]Employee employee)
        {
            var exsistingEmployee = _employeeContext.Employee.FirstOrDefault(t => t.EmployeeID == employee.EmployeeID);
            if (exsistingEmployee != null)
            {
                   
                _employeeContext.Employee.Remove(exsistingEmployee);
                _employeeContext.SaveChanges();
                var employeeList = _employeeContext.Employee.ToList();
                return Ok(employeeList);
            }
            else
            {
                return NotFound();
            }
        }
    }
}