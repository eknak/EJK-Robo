using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJK.Shared.Models.Entities
{
    public class Pregao : IEntity
    {
        public Pregao()
        {
            this.Plataforma = new Plataforma();
        }
        [Key]
        public int Id { get; set; }

        public int PlataformaId { get; set; }
        public Plataforma Plataforma { get; set; }
        public Cliente Cliente { get; set; }
        public string Identificador { get; set; }
    }
}
