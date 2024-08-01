using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionConsolaPruebaTecnica.Models
{
    internal class PostResponseViewModel
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string HoraCreacion { get; set; }
        public string Mensaje { get; set; }
    }
}
