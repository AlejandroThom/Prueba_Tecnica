using CasosDeUso.CUPosts.Interfaces;
using DTOs.DTOsPosts;
using LogicaAccesoADatos.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUso.CUPosts.Implementacion
{
    public class CUObtenerPostPorId : ICUObtenerPostPorId
    {
        public IRepositorioPost Repo { get; set; }
        public CUObtenerPostPorId(IRepositorioPost repo)
        {
            Repo = repo;
        }
        public ListadoPostDTO ObtenerPostPorId(int idPost)
        {
           return PostMappers.FromPostToListadoDTO(Repo.ObtenerPostPorId(idPost));
        }
    }
}
