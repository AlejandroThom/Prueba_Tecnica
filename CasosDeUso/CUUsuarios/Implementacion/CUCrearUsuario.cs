using CasosDeUso.CUUsuarios.Interfaces;
using LogicaAccesoADatos.IRepositorio;
using LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUso.CUUsuarios.Implementacion
{
    public class CUCrearUsuario : ICUCrearUsuario
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUCrearUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public void CrearUsuario(string nombreUsuario)
        {
            Repo.CrearUsuario(new Usuario(nombreUsuario));
        }
    }
}
