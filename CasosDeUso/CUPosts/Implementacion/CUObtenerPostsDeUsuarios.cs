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
    public class CUObtenerPostsDeUsuarios : ICUObtenerPostsDeUsuarios
    {
        public IRepositorioPost Repo { get; set; }
        public CUObtenerPostsDeUsuarios(IRepositorioPost repo)
        {
            Repo = repo;
        }
        public List<ListadoPostDTO> ObtenerPostsDeUsuarios(List<string> nombresDeUsuario)
        {
            return Repo.ObtenerPostsDeSeguidos(nombresDeUsuario)
                .Select(p=>new ListadoPostDTO() 
                {
                    Id = p.Id,
                    HoraCreacion=p.HoraCreacion,
                    Mensaje=p.Mensaje,
                    NombreUsuario=p.NombreUsuarioCreador
                })
                .ToList();
        }
    }
}
