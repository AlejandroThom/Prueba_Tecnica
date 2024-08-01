using CasosDeUso.CUUsuarios.Implementacion;
using CasosDeUso.CUUsuarios.Interfaces;
using DTOs.DTOsUsuarios;
using LogicaAccesoADatos.IRepositorio;
using LogicaAccesoADatos.Repositorios;
using LogicaDeNegocio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Prueba_Tecnica.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebas
{
    public class UsuariosTests
    {
        private readonly IRepositorioUsuario _repoUsuario;
        public ICUSeguirUsuario CUSeguirUsuario { get; set; }
        public ICUVerificarSeguidorDeUsuario CUVerificarSeguidorDeUsuario { get; set; }

        
        public UsuariosTests()
        { 
            _repoUsuario = new RepositorioUsuario();
            CUSeguirUsuario = new CUSeguirUsuario(_repoUsuario);
            CUVerificarSeguidorDeUsuario = new CUVerificarSeguidorDeUsuario(_repoUsuario);
        }

        [Fact]
        public void UsuarioControllerTest_SeguirAUsuarioCorrectamente()
        {
            //arrange
            _repoUsuario.CrearUsuario(new Usuario("@Andres"));
            _repoUsuario.CrearUsuario(new Usuario("@Andrea"));
            var controller = new UsuarioController(CUSeguirUsuario,CUVerificarSeguidorDeUsuario);

            //Action
            var result = controller.SeguirAUsuario(new SeguimientoUsuarioDTO {NombreUsuarioASeguir="@Andres",NombreUsuarioSeguidor="@Andrea" });
            
            //Assert
            Assert.IsType(typeof(OkObjectResult), result);
            var okResult = result as OkObjectResult;
            Assert.Equal("Andrea empezó a seguir a Andres", okResult.Value);
            
        }

        [Fact]
        public void UsuarioControllerTest_YaSigueAUsuarioCorrectamente()
        {
            //arrange
            var controller = new UsuarioController(CUSeguirUsuario, CUVerificarSeguidorDeUsuario);
            //Action
            var result = controller.SeguirAUsuario(new SeguimientoUsuarioDTO { NombreUsuarioASeguir = "@Andres", NombreUsuarioSeguidor = "@Andrea" });
           
            var okResult = result as BadRequestObjectResult;

            var result2 = controller.SeguirAUsuario(new SeguimientoUsuarioDTO { NombreUsuarioASeguir = "@res", NombreUsuarioSeguidor = "@Andrea" });

            var okResult2 = result2 as BadRequestObjectResult;
            //Assert
            Assert.Equal("Andrea ya esta siguiendo a @Andres", okResult.Value);
            Assert.Equal("No se encontró ningún usuario @res", okResult2.Value);
        }

        [Fact]
        public void UsuarioControllerTest_UsuarioASeguirNoExiste()
        {
            //arrange
            var controller = new UsuarioController(CUSeguirUsuario, CUVerificarSeguidorDeUsuario);
            //Action
            var result = controller.SeguirAUsuario(new SeguimientoUsuarioDTO { NombreUsuarioASeguir = "@res", NombreUsuarioSeguidor = "@Andrea" });

            var okResult = result as BadRequestObjectResult;
            //Assert
            Assert.Equal("No se encontró ningún usuario @res", okResult.Value);
        }
    }
}
