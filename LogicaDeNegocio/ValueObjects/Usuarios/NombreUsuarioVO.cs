using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.ValueObjects.Usuarios
{
    public class NombreUsuarioVO
    {
        public string Nombre;

        public NombreUsuarioVO(string nombreUsuario)
        {
            Nombre = nombreUsuario;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
                throw new Exception("El nombre de usuario es obligatorio");
        }
    }
}
