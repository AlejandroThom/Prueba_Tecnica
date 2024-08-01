using DTOs.DTOsPosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUso.CUPosts.Interfaces
{
    public interface ICUObtenerPostPorId
    {
        /// <summary>
        /// Dado un id de un post se obtiene dicho post
        /// </summary>
        /// <param name="idPost">El id de un post</param>
        /// <returns>Retorna el post con dicho id</returns>
        ListadoPostDTO ObtenerPostPorId(int idPost);
    }
}
