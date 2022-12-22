using System.ComponentModel.DataAnnotations;

namespace Crud_Asp.Net.Models
{
    public class Contacto
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage ="El campo Nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Direccion es obligatorio")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo Email es obligatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Fecha es obligatorio")]
        public DateTime FechaRegistro { get; set; }
    }
}
