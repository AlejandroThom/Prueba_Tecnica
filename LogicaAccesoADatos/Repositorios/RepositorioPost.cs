using LogicaAccesoADatos.IRepositorio;
using LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoADatos.Repositorios
{
    public class RepositorioPost : IRepositorioPost
    {
        private static readonly List<Post> s_posts = new List<Post>();
        public void CrearNuevoPost(Post post)
        {
            post.Validar();
            s_posts.Add(post);
        }

        public Post ObtenerPostPorId(int idPost)
        {
            return s_posts.Find(p=>p.Id==idPost) ?? throw new Exception("El post no existe");
        }

        public List<Post> ObtenerPostsDeSeguidos(List<string> nombresDeUsuarios)
        {
            return s_posts
                .Where(p=> nombresDeUsuarios.Contains(p.NombreUsuarioCreador))
                .OrderBy(p=>p.FechaCreacion)
                .OrderBy(p=>p.HoraCreacion)
                .ToList();
        }

        public List<Post> ObtenerPostsDeUsuario(string nombreUsuario)
        {
            return s_posts.FindAll(p => p.NombreUsuarioCreador==nombreUsuario);
        }

        public List<Post> ObtenerPostsQueContenganFrase(string frase)
        {
            return s_posts.Where(p => p.Mensaje.Contains(frase)).ToList();
        }
    }
}
