using CasosDeUso.CUUsuarios.Interfaces;
using LogicaAccesoADatos.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUso.CUUsuarios.Implementacion
{
    public class CUVerificarSeguidorDeUsuario : ICUVerificarSeguidorDeUsuario
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUVerificarSeguidorDeUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }
        public bool VerificarSeguidorDeUsuario(string nombreUsuario, string nombreUsuarioSeguidor)
        {
            return Repo.UsuarioContieneSeguidor(nombreUsuario, nombreUsuarioSeguidor);
        }
    }
}
