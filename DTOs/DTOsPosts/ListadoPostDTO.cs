using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOsPosts
{
    public class ListadoPostDTO
    {
        public int Id {  get; set; }
        public string NombreUsuario {  get; set; }
        public TimeOnly HoraCreacion { get; set; }
        public string Mensaje {  get; set; }
    }
}
