using System;
using System.Collections.Generic;
using MAS.HandsOnTest.Core.Entities;
using MAS.HandsOnTest.Core.Factory;
using MAS.HandsOnTest.Core.Repositories;
using MAS.HandsOnTest.Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MAS.HandsOnTest.Core.UnitTests
{
    [TestClass]
    public class EmployeeServiceTests
    {
        private IEmployeeService _employeeServices;
        private Mock<IEmployeeRepository> _employeeRepository;
        private Mock<ISalaryFactory> _salaryFactory;
        private Mock<ISalaryContract> _salaryContract;

        public EmployeeServiceTests()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            _salaryFactory = new Mock<ISalaryFactory>();
            _salaryContract = new Mock<ISalaryContract>();
        }

        [TestMethod]
        public void AnnualSalaryCalculatedHourly()
        {
            //Arrange
            var employees = new List<Employee> { new Employee { Id = 1,
                Name = "Juan",
                ContractTypeName = "HourlySalaryEmployee",
                RoleId = 1,
                RoleName = "Administrator",
                RoleDescription = null,
                HourlySalary = 60000,
                MonthlySalary =  80000}
            };
            _employeeRepository.Setup(emp => emp.GetAll()).Returns(employees);
            _salaryFactory.Setup(f => f.CreateInstance(It.IsAny<Employee>())).Returns( new SalaryContractHourly(employees[0]));            
            _employeeServices = new EmployeeService(_employeeRepository.Object, _salaryFactory.Object);

            //Act
            var employeesCalculated = _employeeServices.GetEmployeeById(1);

            //Assert                
            Assert.AreEqual( 120 * employees[0].HourlySalary * 12, employeesCalculated.AnnualSalary);

        }

        [TestMethod]
        public void AnnualSalaryCalculatedMonthly()
        {
            //Arrange
            var employees = new List<Employee> { new Employee { Id = 2,
                Name = "Sebastian",
                ContractTypeName = "MonthlySalaryEmployee",
                RoleId = 2,
                RoleName = "Contractor",
                RoleDescription = null,
                HourlySalary = 60000,
                MonthlySalary =  80000}
            };
            _employeeRepository.Setup(emp => emp.GetAll()).Returns(employees);
            _salaryFactory.Setup(f => f.CreateInstance(It.IsAny<Employee>())).Returns(new SalaryContractMonthly(employees[0]));
            _employeeServices = new EmployeeService(_employeeRepository.Object, _salaryFactory.Object);

            //Act
            var employeesCalculated = _employeeServices.GetEmployeeById(2);

            //Assert                
            Assert.AreEqual(employees[0].MonthlySalary * 12, employeesCalculated.AnnualSalary);

        }

    }
}
