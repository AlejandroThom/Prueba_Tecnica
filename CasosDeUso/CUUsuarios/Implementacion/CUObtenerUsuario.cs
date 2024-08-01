using CasosDeUso.CUUsuarios.Interfaces;
using DTOs.DTOsUsuarios;
using LogicaAccesoADatos.IRepositorio;
using LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUso.CUUsuarios.Implementacion
{
    public class CUObtenerUsuario : ICUObtenerUsuario
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUObtenerUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public UsuarioDTO ObtenerUsuario(string nombreUsuario)
        {
            Usuario user = Repo.ObtenerUsuario(nombreUsuario);
            return new UsuarioDTO {Id=user.Id,NombreUsuario=nombreUsuario};
        }
    }
}
