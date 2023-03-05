using System.ComponentModel.DataAnnotations;
namespace L01_2020QQ650.Models
{
    public class usuarios
    {
        [Key] 
        
        public int usuarioId { get; set; }
        public int rolId { get; set; }

        public string nombreUsuario { get; set; }

        public string clave { get; set; }

        public  string nombres { get; set; }

        public string apellido { get; set; }
    }
}
