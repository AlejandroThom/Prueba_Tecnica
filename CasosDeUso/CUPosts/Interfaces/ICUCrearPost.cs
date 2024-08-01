using DTOs.DTOsPosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUso.CUPosts.Interfaces
{
    public interface ICUCrearPost
    {
        ListadoPostDTO CrearPost(string mensaje,string nombreUsuario);
    }
}
