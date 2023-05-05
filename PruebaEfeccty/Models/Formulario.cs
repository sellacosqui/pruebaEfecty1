using System.ComponentModel.DataAnnotations;

namespace PruebaEfeccty.Models
{
    public class Formulario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string Apellido { get; set; } = default!; 
        public int Tipo_Identificacion { get; set; }
        public int Sueldo { get; set; }
        public bool Estado_Civil { get; set; }
        public DateTime Fecha_Nacimiento { get; set; } 


        public virtual Tipo_Identificacion? Tipo_Identificacionmodel { get; set; }
    }
}
