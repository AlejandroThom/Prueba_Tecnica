using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class Post
    {
        private static int s_id = 0;
        public int Id { get; set; }

        public string Mensaje { get; set; }
        public string NombreUsuarioCreador { get; set; }
        public DateOnly FechaCreacion { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public TimeOnly HoraCreacion { get; set; } = TimeOnly.FromDateTime(DateTime.Now);

        public Post(string mensaje,string nombreUsuario)
        {
            s_id++;
            Id= s_id;
            Mensaje= mensaje;
            NombreUsuarioCreador = nombreUsuario;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Mensaje))
                throw new Exception("El mensaje del post no puede estar vacía");
            if (string.IsNullOrEmpty(NombreUsuarioCreador))
                throw new Exception("El nombre de usuario no puede estar vacio");
        }

    }
}
