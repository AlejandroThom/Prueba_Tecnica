using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionConsolaPruebaTecnica.Models
{
    internal class FollowModel
    {
        public string NombreUsuarioSeguidor { get; set; }
        public string NombreUsuarioASeguir { get; set; }

        public override string ToString()
        {
            return $"{{'NombreUsuarioSeguidor': {NombreUsuarioSeguidor}, 'NombreUsuarioASeguir': {NombreUsuarioASeguir}}}";
        }
    }
}
