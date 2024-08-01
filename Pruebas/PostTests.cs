using CasosDeUso.CUPosts.Implementacion;
using CasosDeUso.CUPosts.Interfaces;
using CasosDeUso.CUUsuarios.Implementacion;
using CasosDeUso.CUUsuarios.Interfaces;
using DTOs.DTOsPosts;
using LogicaAccesoADatos.IRepositorio;
using LogicaAccesoADatos.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas
{
    public class PostTests
    {
        private readonly IRepositorioUsuario _repoUsuario;
        private readonly IRepositorioPost _repoPosts;
        public ICUCrearPost CUCrearPost { get; set; }
        public ICUObtenerSeguidosDeUsuario CUObtenerSeguidosDeUsuario { get; set; }
        public ICUObtenerPostsDeUsuarios CUObtenerPostsDeUsuarios { get; set; }
        public ICUObtenerPostPorId CUObtenerPostPorId { get; set; }
        public ICUSeguirUsuario CUSeguirUsuario { get; set; }
        public ICUVerificarSeguidorDeUsuario CUVerificarSeguidorDeUsuario { get; set; }
        public ICUObtenerUsuario CUObtenerUsuario { get; set; }
        public PostTests()
        {
            _repoUsuario = new RepositorioUsuario();
            _repoPosts = new RepositorioPost();
            CUCrearPost = new CUCrearPost(_repoPosts);
            CUObtenerSeguidosDeUsuario = new CUObtenerSeguidosDeUsuario(_repoUsuario);
            CUObtenerPostsDeUsuarios = new CUObtenerPostsDeUsuarios(_repoPosts);
            CUObtenerPostPorId = new CUObtenerPostPorId(_repoPosts);
            CUObtenerUsuario = new CUObtenerUsuario(_repoUsuario);
            CUSeguirUsuario = new CUSeguirUsuario(_repoUsuario);
            CUVerificarSeguidorDeUsuario = new CUVerificarSeguidorDeUsuario(_repoUsuario);
        }

        [Fact]
        public void PostController_PublicacionDePostCorrectamente()
        {
            //arrange
            var controller = new PostController(CUCrearPost,
                CUObtenerSeguidosDeUsuario,
                CUObtenerPostsDeUsuarios,
                CUObtenerPostPorId,
                CUObtenerUsuario);
            //act
            var result = controller.PublicarUnPost(new DTOs.DTOsPosts.CrearPostDTO {Mensaje="Buenas como estan gente?",NombreUsuario="@Alicia"}) as CreatedAtActionResult;
            
            var result2 = controller.PublicarUnPost(new DTOs.DTOsPosts.CrearPostDTO { Mensaje = "Buenos dias!!!! todo bien?", NombreUsuario = "@Alfonso" }) as CreatedAtActionResult;

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result2);

            var postResult1 = result?.Value as ListadoPostDTO;
            var postResult2 = result2?.Value as ListadoPostDTO;

            Assert.NotNull(postResult1); 
            Assert.NotNull(postResult2); 

            Assert.IsType<ListadoPostDTO>(postResult1);
            Assert.IsType<ListadoPostDTO>(postResult2);
        }

        [Fact]
        public void PostController_ObtenerPostDeMisSeguidos()
        {
            //arrange
            var controller = new PostController(CUCrearPost,
                CUObtenerSeguidosDeUsuario,
                CUObtenerPostsDeUsuarios,
                CUObtenerPostPorId,
                CUObtenerUsuario);
            var usuarioController = new UsuarioController(CUSeguirUsuario,CUVerificarSeguidorDeUsuario);
            usuarioController.SeguirAUsuario(new DTOs.DTOsUsuarios.SeguimientoUsuarioDTO {NombreUsuarioASeguir= "@Alfonso", NombreUsuarioSeguidor= "@Alicia" });
            controller.PublicarUnPost(new DTOs.DTOsPosts.CrearPostDTO { NombreUsuario= "@Alfonso", Mensaje="Python es el mejor lenguaje"});
            controller.PublicarUnPost(new DTOs.DTOsPosts.CrearPostDTO { NombreUsuario = "@Alfonso", Mensaje = "php esta en el olvido" });

            //act
            var result = controller.ObtenerPostDeLosSeguidosDeUnUsuario("@Alicia");
            var okObject = result as ObjectResult;
            //assert
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
            Assert.IsType<List<ListadoPostDTO>>(okObject.Value as List<ListadoPostDTO>);
            Assert.True((okObject.Value as List<ListadoPostDTO>).Count == 2);

        }

    }
}
