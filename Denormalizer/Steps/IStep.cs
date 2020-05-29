using System.Threading.Tasks;

using Denormalizer.Database;

namespace Denormalizer.Steps
{
    public interface IStep
    {
        Task Execute(AbacusContext source, AzureContext destination);
    }
}