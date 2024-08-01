using CasosDeUso.CUPosts.Interfaces;
using CasosDeUso.CUUsuarios.Interfaces;
using DTOs.DTOsPosts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Prueba_Tecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        public ICUCrearPost CUCrearPost { get; set; }
        public ICUObtenerSeguidosDeUsuario CUObtenerSeguidosDeUsuario { get; set; }
        public ICUObtenerPostsDeUsuarios CUObtenerPostsDeUsuarios { get; set; }
        public ICUObtenerPostPorId CUObtenerPostPorId { get; set; }
        public ICUObtenerUsuario CUObtenerUsuario { get; set; }

        public PostController(ICUCrearPost cUCrearPost,
            ICUObtenerSeguidosDeUsuario cUObtenerSeguidosDeUsuario,
            ICUObtenerPostsDeUsuarios cUObtenerPostsDeUsuarios,
            ICUObtenerPostPorId cUObtenerPostPorId,
            ICUObtenerUsuario cUObtenerUsuario)
        {
            CUCrearPost = cUCrearPost;
            CUObtenerSeguidosDeUsuario = cUObtenerSeguidosDeUsuario;
            CUObtenerPostsDeUsuarios = cUObtenerPostsDeUsuarios;
            CUObtenerPostPorId = cUObtenerPostPorId;
            CUObtenerUsuario = cUObtenerUsuario;
        }

        /// <summary>
        /// Dado un id devuelve el post que tenga ese id
        /// </summary>
        /// <param name="idPost">El id de un post</param>
        /// <returns>Los datos de un post</returns>
        [HttpGet("{idPost:int}", Name ="BuscarPost")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ObtenerPostPorId(int idPost)
        {
            return Ok(CUObtenerPostPorId.ObtenerPostPorId(idPost));
        }

        /// <summary>
        /// Dado un mensaje y un nombre de usuario se crea un post
        /// </summary>
        /// <param name="datos">El mensaje y el nombre de usuario</param>
        /// <returns>Retorna un mensaje que contiene el mensaje, la hora de la creación y el nombre del usuario</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PublicarUnPost([FromBody] CrearPostDTO datos)
        {
            try
            {
                CUObtenerUsuario.ObtenerUsuario(datos.NombreUsuario);
                ListadoPostDTO nuevoPost = CUCrearPost.CrearPost(datos.Mensaje, datos.NombreUsuario);
                return CreatedAtAction(nameof(ObtenerPostPorId),new {idPost=nuevoPost.Id }, nuevoPost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Dado un nombre de usuario se busca los post más recientes hechos por sus seguidos
        /// </summary>
        /// <param name="nombreUsuario">El nombre de usuario a ver a quienes sigue</param>
        /// <returns>Retorna una lista con los post hechos por los seguidos del usuario</returns>
        [HttpGet("{nombreUsuario}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ObtenerPostDeLosSeguidosDeUnUsuario(string nombreUsuario)
        {
            //Lista de seguidos de este usuario
            IEnumerable<string> seguidos = CUObtenerSeguidosDeUsuario.ObtenerNombreDeUsuarioSeguidosDeUsuario(nombreUsuario);
            //Lista de post de dichos seguidos del usuario
            //retornar los posts
            return Ok(CUObtenerPostsDeUsuarios.ObtenerPostsDeUsuarios(seguidos.ToList()));
        }

    }
}
