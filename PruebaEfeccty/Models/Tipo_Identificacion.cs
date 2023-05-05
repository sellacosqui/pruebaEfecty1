using System.ComponentModel.DataAnnotations;

namespace PruebaEfeccty.Models
{
    public class Tipo_Identificacion
    {
        [Key]
        public int Id { get; set; }
        public string Descripcion { get; set; } = default!; 

    }
}
