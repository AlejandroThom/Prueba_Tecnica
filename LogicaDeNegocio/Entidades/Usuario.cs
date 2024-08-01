using LogicaDeNegocio.ValueObjects.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class Usuario :IEquatable<Usuario>
    {
        private static int s_id = 0;
        public int Id { get; set; }
        public NombreUsuarioVO NombreUsuario { get; set; }
        public List<Usuario> Seguidos { get; set; }
        public List<Usuario> Seguidores { get; set; }

        public Usuario(string nombreUsuario) 
        {
            NombreUsuario = new NombreUsuarioVO(nombreUsuario);
            s_id++;
            Id = s_id;
            Seguidores = new List<Usuario>();
            Seguidos = new List<Usuario>();
        }


        public bool Equals(Usuario? other)
        {
            if(other == null) return false;
            return NombreUsuario.Nombre.Equals(other.NombreUsuario.Nombre);
        }
    }
}
