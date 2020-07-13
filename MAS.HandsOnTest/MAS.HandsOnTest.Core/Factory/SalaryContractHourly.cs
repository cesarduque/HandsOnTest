using MAS.HandsOnTest.Core.Entities;

namespace MAS.HandsOnTest.Core.Factory
{
    /// <summary>
    /// Implement calculation to get the annual salary by Hourly Contract
    /// </summary>
    public class SalaryContractHourly : ISalaryContract
    {
        public readonly Employee _employee;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="employee"></param>
        public SalaryContractHourly(Employee employee)
        {
            _employee = employee;
        }

        /// <summary>
        /// Calculate the annual salary
        /// </summary>
        /// <returns></returns>
        public decimal CalculateAnnualSalary()
        {
            return 120 * _employee.HourlySalary * 12;
        }
    }
}
