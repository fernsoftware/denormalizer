using Denormalizer.Database;

namespace Denormalizer.Steps
{
    public interface IStep
    {
        void Execute(int databaseId, AbacusContext source, AzureContext destination);
    }
}