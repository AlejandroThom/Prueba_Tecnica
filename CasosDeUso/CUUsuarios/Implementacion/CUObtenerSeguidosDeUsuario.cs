using CasosDeUso.CUUsuarios.Interfaces;
using LogicaAccesoADatos.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUso.CUUsuarios.Implementacion
{
    public class CUObtenerSeguidosDeUsuario : ICUObtenerSeguidosDeUsuario
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUObtenerSeguidosDeUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }
        public IEnumerable<string> ObtenerNombreDeUsuarioSeguidosDeUsuario(string nombreUsuario)
        {
            return Repo.ObtenerSeguidosDeUsuario(nombreUsuario).Select(u => u.NombreUsuario.Nombre);
        }
    }
}
