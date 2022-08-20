using EJK.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJK.Licitacao.Data.Repository
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {

    }
    internal class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(PregaoContext repository) : base(repository)
        {
        }
    }
}
