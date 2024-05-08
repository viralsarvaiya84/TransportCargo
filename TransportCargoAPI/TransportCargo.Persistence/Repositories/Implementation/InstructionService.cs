using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCargo.Application.Interface.Contract;
using TransportCargo.Domain.Entities;
using TransportCargo.Persistence.Contexts;
using TransportCargo.Persistence.Repositories.GenericRepository;

namespace TransportCargo.Persistence.Repositories.Implementation
{
    public class InstructionService:GenericRepositoryAsync<Instruction>, IInstruction
    {
        public InstructionService(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { } 
    }
}
