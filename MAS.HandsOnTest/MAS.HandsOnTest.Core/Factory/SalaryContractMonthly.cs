using MAS.HandsOnTest.Core.Entities;

namespace MAS.HandsOnTest.Core.Factory
{
    /// <summary>
    /// Implement calculation to get the annual salary by Monthly Contract
    /// </summary>
    public class SalaryContractMonthly : ISalaryContract
    {
        public readonly Employee _employee;

        /// <summary>
        /// Class Constructor
        /// </summary>
        /// <param name="employee"></param>
        public SalaryContractMonthly(Employee employee)
        {
            _employee = employee;
        }

        /// <summary>
        /// Calculate the annual salary
        /// </summary>
        /// <returns></returns>
        public decimal CalculateAnnualSalary()
        {
            return _employee.MonthlySalary * 12;
        }
    }
}
