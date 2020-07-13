using MAS.HandsOnTest.Core.Entities;
using System.Collections.Generic;

namespace MAS.HandsOnTest.Core.Service
{
    public interface IEmployeeService
    {
        Employee GetEmployeeById(int id);

        IEnumerable<Employee> GetEmployees();
    }
}
