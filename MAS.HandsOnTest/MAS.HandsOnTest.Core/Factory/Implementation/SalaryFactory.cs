using MAS.HandsOnTest.Core.Entities;

namespace MAS.HandsOnTest.Core.Factory
{
    /// <summary>
    /// Implement factory method to calculate the salary
    /// </summary>
    public class SalaryFactory : ISalaryFactory
    {
        /// <summary>
        /// Retrieve the Salary Implementation by Contract Type
        /// </summary>
        /// <param name="empleyee"></param>
        /// <returns></returns>
        public ISalaryContract CreateInstance(Employee empleyee)
        {
            ISalaryContract result;

            switch (empleyee.ContractTypeName)
            {
                case "HourlySalaryEmployee":
                    result = new SalaryContractHourly(empleyee);
                    break;
                case "MonthlySalaryEmployee":
                    result = new SalaryContractMonthly(empleyee);
                    break;
                default:
                    result = null;
                    break;
            }

            return result;
        }
    }
}
