using MAS.HandsOnTest.Core.Entities;
using MAS.HandsOnTest.Core.Factory;
using MAS.HandsOnTest.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MAS.HandsOnTest.Core.Service
{
    /// <summary>
    /// Implement operations realated to employee
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ISalaryFactory _salaryFactory;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="employeeRepository"></param>
        /// <param name="salaryFactory"></param>
        public EmployeeService(IEmployeeRepository employeeRepository, ISalaryFactory salaryFactory)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _salaryFactory = salaryFactory ?? throw new ArgumentNullException(nameof(salaryFactory));
        }

        /// <summary>
        /// Get employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetEmployeeById(int id)
        {           
            var employee = _employeeRepository.GetAll().FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employee.AnnualSalary = _salaryFactory.CreateInstance(employee).CalculateAnnualSalary();
            }
            return employee;
        }

        /// <summary>
        /// Get employees
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetEmployees()
        {
            var employees = _employeeRepository.GetAll();
            employees = employees.Select(emp =>
            {
                emp.AnnualSalary = _salaryFactory.CreateInstance(emp).CalculateAnnualSalary(); 
                return emp;
            });
            return employees;
        }
    }
}
