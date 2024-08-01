using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUso.CUUsuarios.Interfaces
{
    public interface ICUVerificarSeguidorDeUsuario
    {
        /// <summary>
        /// Verifica si un usuario ya sigue al otro usuario
        /// </summary>
        /// <param name="nombreUsuario">usuario a quien se sigue</param>
        /// <param name="nombreUsuarioSeguidor">usuario seguidor</param>
        /// <returns>true si el usuario seguidor sigue realmente al otro usuario, false en caso contrario</returns>
        bool VerificarSeguidorDeUsuario(string nombreUsuario, string nombreUsuarioSeguidor);
    }
}
