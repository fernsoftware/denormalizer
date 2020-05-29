using System.Collections.Generic;
using System.Data.Common;

namespace Denormalizer.Factories
{
    public interface IFactory<T> where T : class, new()
    {
        T Create(DbDataReader reader);

        IEnumerable<T> CreateMany(DbDataReader reader);
    }
}