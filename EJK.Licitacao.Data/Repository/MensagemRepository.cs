using EJK.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJK.Licitacao.Data.Repository
{
    public interface IMensagemRepository : IBaseRepository<Mensagem>
    {
        bool ProcessMensagens(IList<Mensagem> mensagens);
    }

    internal class MensagemRepository : BaseRepository<Mensagem>, IMensagemRepository
    {
        public MensagemRepository(PregaoContext repository) : base(repository)
        {
        }


        public bool ProcessMensagens(IList<Mensagem> mensagens)
        {
            foreach (var mensagem in mensagens.OrderBy(x => x.Data))
            {

            }
            return true;
        }
    }
}
