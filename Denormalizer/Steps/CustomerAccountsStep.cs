using System;
using System.Threading.Tasks;

using AutoMapper;

using Denormalizer.Database;

namespace Denormalizer.Steps
{
    public sealed class CustomerAccountsStep : IStep
    {
        public Task Execute(AbacusContext source, AzureContext destination, IMapper mapper)
        {
            throw new NotImplementedException();
        }
    }
}