using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiSimpCRUD.Models;

namespace WebApiSimpCRUD.Controllers
{

    // EmployeesController handles CRUD operations for Employee data
    public class EmployeesController : ApiController
    {
        // Static list of employees to serve as in-memory data storage
        public static List<Employee> employeeslist = new List<Employee>()
        { 
            // Initializing the list with some sample employees
            new Employee {Id=1001, Name="Arati", city="solapur", Isactive = true},
            new Employee {Id=1002, Name="prathamesh", city="mumbai", Isactive = true},
            new Employee {Id=1003, Name="varad", city="latur", Isactive = true},
            new Employee {Id=1004, Name="prajkta", city="solapur", Isactive = true}
        };

        // GET api/employees
        // Retrieves the entire list of employees
        public List<Employee> get()
        {
            // Returning the list of employees
            return employeeslist;
        }

        // GET api/employees/{id}
        // Retrieves a specific employee by their id
        public Employee get(int id)
        {
            // Searching for the employee with the given id
            return employeeslist.FirstOrDefault(employee => employee.Id == id);
        }

        // POST api/employees
        // Adds a new employee to the list
        public void post(Employee employee)
        {
            // Adding the new employee to the static list
            employeeslist.Add(employee);
        }

        // PUT api/employees/{id}
        // Updates an existing employee's details by their id
        public void put(int id, Employee employee)
        {
            // Finding the employee to update by id
            var emp = employeeslist.FirstOrDefault(e => e.Id == id);

            // If the employee exists, update their details
            if (emp != null)
            {
                emp.Name = employee.Name;   // Updating the employee's name
                emp.city = employee.city;   // Updating the employee's city
                emp.Isactive = employee.Isactive; // Updating the employee's active status
            }
        }

        // DELETE api/employees/{id}
        // Removes an employee from the list by their id
        public void delete(int id)
        {
            // Searching for the employee to delete by id
            var emp = employeeslist.FirstOrDefault(e => e.Id == id);

            // If the employee exists, remove them from the list
            if (emp != null)
            {
                employeeslist.Remove(emp);
            }
        }
    }
}
