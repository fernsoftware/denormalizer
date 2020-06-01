using Denormalizer.Database;
using Denormalizer.Logging;

namespace Denormalizer.Steps
{
    public abstract class BaseStep : IStep
    {
        protected ILogger Logger;

        public BaseStep(ILogger logger)
        {
            Logger = logger;
        }

        public abstract void Execute(int databaseId, AbacusContext source, AzureContext destination);
    }
}