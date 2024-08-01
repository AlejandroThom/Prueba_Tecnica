using CasosDeUso.CUPosts.Interfaces;
using DTOs.DTOsPosts;
using LogicaAccesoADatos.IRepositorio;
using LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUso.CUPosts.Implementacion
{
    public class CUCrearPost : ICUCrearPost
    {
        public IRepositorioPost Repo { get; set; }
        public CUCrearPost(IRepositorioPost repo)
        {
            Repo = repo;
        }

        public ListadoPostDTO CrearPost(string mensaje, string nombreUsuario)
        {
            Post nuevoPost = new Post(mensaje, nombreUsuario);
            Repo.CrearNuevoPost(nuevoPost);
            return new ListadoPostDTO { Id =nuevoPost.Id , HoraCreacion = nuevoPost.HoraCreacion,Mensaje=mensaje,NombreUsuario=nombreUsuario };
        }
    }
}
