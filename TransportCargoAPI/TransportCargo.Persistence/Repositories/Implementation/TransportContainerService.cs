using TransportCargo.Application.Interface.Contract;
using TransportCargo.Domain.Entities;
using TransportCargo.Persistence.Contexts;
using TransportCargo.Persistence.Repositories.GenericRepository;

namespace TransportCargo.Persistence.Repositories.Implementation
{
    public class TransportContainerService:GenericRepositoryAsync<TransportContainer>, ITransportContainer
    {
        public TransportContainerService(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
    }
}
