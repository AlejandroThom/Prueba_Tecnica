using CasosDeUso.CUUsuarios.Interfaces;
using DTOs.DTOsUsuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Prueba_Tecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //Inyeccion de dependencias
        public ICUSeguirUsuario CUSeguirUsuario { get; set; }
        public ICUVerificarSeguidorDeUsuario CUVerificarSeguidorDeUsuario { get; set; }

        public UsuarioController(ICUSeguirUsuario cUSeguirUsuario,ICUVerificarSeguidorDeUsuario cUVerificarSeguidorDeUsuario)
        {
            CUSeguirUsuario = cUSeguirUsuario;
            CUVerificarSeguidorDeUsuario=cUVerificarSeguidorDeUsuario;
        }

        /// <summary>
        /// Dado dos nombres de usuario, un usuario empieza a seguir al otro.
        /// </summary>
        /// <param name="dto">Los dos nombres de usuario(seguidor y a seguir)</param>
        /// <returns>Un mensaje de exito si se sigue exitosamente a otro usuario, uno de error en caso contrario</returns>
        [HttpPost("SeguirUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult SeguirAUsuario([FromBody] SeguimientoUsuarioDTO dto)
        {
            try
            {
                if (CUVerificarSeguidorDeUsuario.VerificarSeguidorDeUsuario(dto.NombreUsuarioASeguir, dto.NombreUsuarioSeguidor))
                    return BadRequest($"{dto.NombreUsuarioSeguidor.Substring(1)} ya esta siguiendo a {dto.NombreUsuarioASeguir}");
                CUSeguirUsuario.SeguirUsuario(dto.NombreUsuarioASeguir,dto.NombreUsuarioSeguidor);
                return Ok($"{dto.NombreUsuarioSeguidor.Substring(1)} empezó a seguir a {dto.NombreUsuarioASeguir.Substring(1)}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
