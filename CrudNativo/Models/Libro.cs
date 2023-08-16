using System.ComponentModel.DataAnnotations;

namespace CrudNativo.Models
{
    public class Libro
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo es Obligatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El campo es Obligatorio")]

        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo es Obligatorio")]

        public string Autor { get; set;}
        [Required(ErrorMessage = "El campo es Obligatorio")]


        public DateTime FechaPublicacion { get; set; }
        [Required(ErrorMessage = "El campo es Obligatorio")]

        public string Precio { get; set; }
    }
}
