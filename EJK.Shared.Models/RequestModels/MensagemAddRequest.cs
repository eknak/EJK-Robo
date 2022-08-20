using EJK.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJK.Shared.Models.RequestModels
{
    public class MensagemAddRequest
    {
        public string Identificador { get; set; }
        public List<Mensagem> Mensagens { get; set; } = new List<Mensagem>();
    }
}
