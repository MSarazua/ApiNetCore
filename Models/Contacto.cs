using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudWebApi.Models
{
    public class Contacto
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public bool Verificado { get; set; }
    }
}
