using LogicaAccesoADatos.IRepositorio;
using LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoADatos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private static readonly List<Usuario> s_usuarios = new List<Usuario>() { new Usuario("@Alfonso"), new Usuario("@Ivan"), new Usuario("@Alicia") };

        public void LimpiarRegistros()
        {
            s_usuarios.Clear();
            s_usuarios.Add(new Usuario("@Alfonso"));
            s_usuarios.Add(new Usuario("@Ivan"));
            s_usuarios.Add(new Usuario("@Alicia"));
        }
        public void CrearUsuario(Usuario usuario)
        {
            if (s_usuarios.Find(u => u.NombreUsuario.Nombre.ToLower() == usuario.NombreUsuario.Nombre.ToLower()) != null)
                throw new Exception("Intente otro nombre de usuario");
            s_usuarios.Add(usuario);
        }

        public Usuario ObtenerUsuario(string nombreUsuario)
        {
            return s_usuarios.Find(u => u.NombreUsuario.Nombre.Equals(nombreUsuario)) ?? throw new Exception($"No se encontró ningún usuario {nombreUsuario}");
        }

        public bool UsuarioContieneSeguidor(string nombreUsuario, string nombreUsuarioSeguidor)
        {
            Usuario user = ObtenerUsuario(nombreUsuario);
            Usuario nuevoSeguidor = ObtenerUsuario(nombreUsuarioSeguidor);
            return user.Seguidores.Contains(nuevoSeguidor);
        }

        public void SeguirUsuario(string nombreUsuario, string nombreUsuarioSeguidor)
        {
            Usuario aSeguir = ObtenerUsuario(nombreUsuario);
            Usuario nuevoSeguidor = ObtenerUsuario(nombreUsuarioSeguidor);
            aSeguir.Seguidores.Add(nuevoSeguidor);
            nuevoSeguidor.Seguidos.Add(aSeguir);
        }

        public IEnumerable<Usuario> ObtenerSeguidosDeUsuario(string nombreUsuario)
        {
            return ObtenerUsuario(nombreUsuario).Seguidos;
        } 
    }
}
