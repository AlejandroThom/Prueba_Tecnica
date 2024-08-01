using LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoADatos.IRepositorio
{
    public interface IRepositorioUsuario
    {
        /// <summary>
        /// Dado el id de un usuario (A seguir) y el id de otro usuario(Futuro Seguidor)
        /// se realiza el seguimiento de un usuario a otro.
        /// </summary>
        /// <param name="idUsuario">Usuario a seguir</param>
        /// <param name="idUsuarioSeguidor">usuario futuro seguidor</param>
        void SeguirUsuario(string nombreUsuario, string nombreUsuarioSeguidor);

        /// <summary>
        /// Dado un nombre de usuario se obtiene los datos de dicho usuario.
        /// </summary>
        /// <param name="idUsuario">nombre de usuario</param>
        /// <returns>Un objeto de tipo usuario</returns>
        Usuario ObtenerUsuario(string nombreUsuario);

        /// <summary>
        /// Dado dos nombres de usuario verifica que un usuario este siguiendo al otro, no en viceversa.
        /// </summary>
        /// <param name="nombreUsuario">Usuario a verificar si tiene al seguidor</param>
        /// <param name="nombreUsuarioSeguidor">usuario a verificar si es seguidor</param>
        /// <returns>true si sigue al usuario, false en caso contrario</returns>
        public bool UsuarioContieneSeguidor(string nombreUsuario, string nombreUsuarioSeguidor);

        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        /// <param name="usuario">un usuario validado</param>
        void CrearUsuario(Usuario usuario);

        /// <summary>
        /// Dado un nombre de usuario, retorna todos los seguidos que sigue el usuario
        /// </summary>
        /// <param name="nombreUsuario">nombre de usuario a encontrar a quien sigue</param>
        /// <returns>Una lista de usuarios que son los seguidos por el usuario</returns>
        IEnumerable<Usuario> ObtenerSeguidosDeUsuario(string nombreUsuario);
    }
}
