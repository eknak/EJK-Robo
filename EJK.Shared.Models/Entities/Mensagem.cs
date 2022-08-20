using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJK.Shared.Models.Entities
{
    public class Mensagem : IEntity
    {
        public Mensagem()
        {
            Tipo = string.Empty;
            Texto = string.Empty;
        }
        [Key]
        public int Id { get; set; }
        public string Tipo { get; set; }
        public DateTime Data { get; set; }
        public string Texto { get; set; }
    }
}
