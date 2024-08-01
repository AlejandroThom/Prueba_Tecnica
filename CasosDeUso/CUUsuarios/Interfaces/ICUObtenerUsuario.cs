using DTOs.DTOsUsuarios;
using LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUso.CUUsuarios.Interfaces
{
    public interface ICUObtenerUsuario
    {
        UsuarioDTO ObtenerUsuario(string nombreUsuario);
    }
}
