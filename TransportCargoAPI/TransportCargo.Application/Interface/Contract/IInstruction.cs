using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCargo.Application.Interface.IGenericRepository;
using TransportCargo.Domain.Entities;

namespace TransportCargo.Application.Interface.Contract
{
    public interface IInstruction:IGenericRepositoryAsync<Instruction>
    {
    }
}
