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
            _repoUsuario.LimpiarRegistros();
        }

        [Fact]
        public void UsuarioControllerTest_SeguirAUsuarioCorrectamente()
        {
            //arrange
            var controller = new UsuarioController(CUSeguirUsuario,CUVerificarSeguidorDeUsuario);

            //Action
            var result = controller.SeguirAUsuario(new SeguimientoUsuarioDTO {NombreUsuarioASeguir="@Ivan",NombreUsuarioSeguidor= "@Alicia" });
            
            //Assert
            Assert.IsType(typeof(OkObjectResult), result);
            var okResult = result as OkObjectResult;
            Assert.Equal("Alicia empezó a seguir a Ivan", okResult.Value);
            
        }

        [Fact]
        public void UsuarioControllerTest_YaSigueAUsuarioCorrectamente()
        {
            //arrange
            var controller = new UsuarioController(CUSeguirUsuario, CUVerificarSeguidorDeUsuario);
            controller.SeguirAUsuario(new SeguimientoUsuarioDTO { NombreUsuarioASeguir = "@Alfonso", NombreUsuarioSeguidor = "@Alicia" });
            //Action
            var result = controller.SeguirAUsuario(new SeguimientoUsuarioDTO { NombreUsuarioASeguir = "@Alfonso", NombreUsuarioSeguidor = "@Alicia" });
           
            var okResult = result as BadRequestObjectResult;

            var result2 = controller.SeguirAUsuario(new SeguimientoUsuarioDTO { NombreUsuarioASeguir = "@res", NombreUsuarioSeguidor = "@Alicia" });

            var okResult2 = result2 as BadRequestObjectResult;
            //Assert
            Assert.Equal("Alicia ya esta siguiendo a @Alfonso", okResult.Value);
            Assert.Equal("No se encontró ningún usuario @res", okResult2.Value);
        }

        [Fact]
        public void UsuarioControllerTest_UsuarioASeguirNoExiste()
        {
            //arrange
            var controller = new UsuarioController(CUSeguirUsuario, CUVerificarSeguidorDeUsuario);
            //Action
            var result = controller.SeguirAUsuario(new SeguimientoUsuarioDTO { NombreUsuarioASeguir = "@res", NombreUsuarioSeguidor = "@Alicia" });
            var result2 = controller.SeguirAUsuario(new SeguimientoUsuarioDTO { NombreUsuarioASeguir = "@Andres", NombreUsuarioSeguidor = "@ndrea" });
            
            var badResult = result as BadRequestObjectResult;
            var badResult2 = result2 as BadRequestObjectResult;
            //Assert
            Assert.Equal("No se encontró ningún usuario @res", badResult.Value);
            Assert.Equal("No se encontró ningún usuario @Andres", badResult2.Value);

        }
    }
}
