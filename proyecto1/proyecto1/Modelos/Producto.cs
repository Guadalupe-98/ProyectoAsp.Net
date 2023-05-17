using System.ComponentModel.DataAnnotations;


namespace WebApi.Modelos
{
    public class Producto
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public bool diponibilidad { get; set; }
        public string detalles { get; set;}

        [Required]
        public int cantidad { get; set;}
    }
}
