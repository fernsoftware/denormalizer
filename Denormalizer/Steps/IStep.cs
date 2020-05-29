using System.Threading.Tasks;
using AutoMapper;

using Denormalizer.Database;

namespace Denormalizer.Steps
{
    public interface IStep
    {
        Task Execute(AbacusContext source, AzureContext destination, IMapper mapper);
    }
}