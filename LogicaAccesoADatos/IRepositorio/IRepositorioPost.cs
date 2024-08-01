using LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoADatos.IRepositorio
{
    public interface IRepositorioPost : IRepositorio
    {

        /// <summary>
        /// Dado un post se valida y se almacena el nuevo post
        /// </summary>
        /// <param name="post">un nuevo post a ser agregado</param>
        void CrearNuevoPost(Post post);
        /// <summary>
        /// Dado el id de un usuario se obtiene todo los post de un usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        List<Post> ObtenerPostsDeUsuario(string nombreUsuario);
        /// <summary>
        /// Dada una lista con los nombre de usuario que un usuario sigue se obtiene los posts de dichos usuarios
        /// </summary>
        /// <param name="idsUsuarios">Una lista con los nombre de usuario a los que sigue un usuario</param>
        /// <returns>Retorna una lista con los posts con los 10 posts más recientes, de mas antiguo a más reciente</returns>
        List<Post> ObtenerPostsDeSeguidos(List<string> nombresDeUsuarios);

        /// <summary>
        /// Dado una frase, se busca todos los posts que contengan dicha frase
        /// </summary>
        /// <param name="frase">la frase a buscar en los posts</param>
        /// <returns>Una lista de posts que contengan dicha frase</returns>
        List<Post> ObtenerPostsQueContenganFrase(string frase);

        /// <summary>
        /// Dado un id de un post se busca el post con dicho id
        /// </summary>
        /// <param name="idPost">El id de un post</param>
        /// <returns>Retorna un post con todos sus datos</returns>
        Post ObtenerPostPorId(int idPost);

    }
}
