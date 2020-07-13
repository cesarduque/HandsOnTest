using MAS.HandsOnTest.Core.Entities;

namespace MAS.HandsOnTest.Core.Factory
{
    public interface ISalaryFactory
    {
        ISalaryContract CreateInstance(Employee empleyee);
    }
}
