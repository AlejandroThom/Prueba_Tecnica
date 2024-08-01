using CasosDeUso.CUUsuarios.Interfaces;
using LogicaAccesoADatos.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUso.CUUsuarios.Implementacion
{
    public class CUSeguirUsuario : ICUSeguirUsuario
    {
        public IRepositorioUsuario Repo {  get; set; }

        public CUSeguirUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public void SeguirUsuario(string nombreUsuario, string nombreUsuarioSeguidor)
        {
            Repo.SeguirUsuario(nombreUsuario, nombreUsuarioSeguidor);
        }
    }
}
