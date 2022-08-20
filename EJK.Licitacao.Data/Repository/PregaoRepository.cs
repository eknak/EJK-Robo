using EJK.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJK.Licitacao.Data.Repository
{
    public interface IPregaoRepository : IBaseRepository<Pregao>
    {

    }
    internal class PregaoRepository : BaseRepository<Pregao>, IPregaoRepository
    {
        public PregaoRepository(PregaoContext repository) : base(repository)
        {
        }
    }
}
