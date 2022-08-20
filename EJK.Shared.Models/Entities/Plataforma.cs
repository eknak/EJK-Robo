using System.ComponentModel.DataAnnotations;

namespace EJK.Shared.Models.Entities
{
    public class Plataforma : IEntity
    {
        public Plataforma()
        {
            this.Nome = String.Empty;
        }
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public IList<Cliente> Clientes { get; set; }
    }


}
