using LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOsPosts
{
    public class PostMappers
    {
        public static ListadoPostDTO FromPostToListadoDTO(Post post)
        {
            if (post == null) throw new Exception("El post no puede ser nulo");
            return new ListadoPostDTO {Id=post.Id,HoraCreacion=post.HoraCreacion,Mensaje=post.Mensaje,NombreUsuario=post.NombreUsuarioCreador };
        }
    }
}
