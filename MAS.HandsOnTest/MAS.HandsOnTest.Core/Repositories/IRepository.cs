using System.Collections.Generic;

namespace MAS.HandsOnTest.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
    }
}
