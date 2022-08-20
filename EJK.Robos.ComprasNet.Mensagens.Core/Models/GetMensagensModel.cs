using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJK.Robos.ComprasNet.Mensagens.Core.Models
{
    public class GetMensagensModel
    {
        public string PrgCod { get; set; }
        public DateTime DataUltimMensagem { get; set; } = DateTime.MinValue;
    }
}
