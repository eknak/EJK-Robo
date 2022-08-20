using System.ComponentModel.DataAnnotations;

namespace EJK.Shared.Models.Entities
{
    public class Cliente : IEntity
    {
        public Cliente()
        {
            this.Nome = String.Empty;
        }
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        
        public IList<Plataforma> Plataformas { get; set; }
    }


}
