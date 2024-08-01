using AplicacionConsolaPruebaTecnica.Models;
using System.Text;
using System.Text.Json;

namespace AplicacionConsolaPruebaTecnica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("Ingrese 0 para terminar el programa");
                Console.WriteLine("Ingresé un comando");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    Console.WriteLine("Ingrese un comando valido");
                else if(input == "0") continuar = false;
                else if (input.Contains("post"))
                {
                    RealizarUnPost(input);
                }
                else if (input.Contains("follow"))
                {
                    SeguirAOtroUsuario(input);
                }
                else
                {
                    MostrarDashboard(input);
                }
            }
            Console.WriteLine("Saliendo...");
        }

        /// <summary>
        /// Dado un string que es el comando post donde tiene el nombre del usuario y el mensaje a publicar
        /// Se realiza una peticion a una web API para realizar un post para dicho usuario
        /// </summary>
        /// <param name="comando">string que contiene el comando, el usuario y el mensaje</param>
        public static void RealizarUnPost(string comando)
        {
            string[] parts = comando.Split(' ');
            string usuario = parts[1];
            StringBuilder sb = new StringBuilder();
            for (int i = 2; i < parts.Length; i++)
            {
                sb.Append(parts[i]).Append(" ");
            }
            var result = Utilities.Utils.RealizarPeticionPost("https://localhost:7121/api/Post", new PostModel
            {
                NombreUsuario = usuario,
                Mensaje = sb.ToString().Trim()
            });
            result.Wait();
            var res = result.Result.Content.ReadAsStringAsync();
            res.Wait();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            PostResponseViewModel response = JsonSerializer.Deserialize<PostResponseViewModel>(res.Result,options);
            Console.WriteLine($"{usuario.Substring(1)} posted -> '{response.Mensaje}'@{response.HoraCreacion.Split('.')[0]}");
        }

        /// <summary>
        /// Dado un string que es el comando follow donde tiene dos nombres de usuario
        /// Se realiza una peticion a una web API para realizar un seguimiento de un usuario a otro
        /// </summary>
        /// <param name="comando">Comando donde se tiene los dos nombres de usuario</param>
        public static void SeguirAOtroUsuario(string comando)
        {
            string[] parts = comando.Split(' ');
            string usuarioSeguidor = parts[1];
            string usuarioASeguir = parts[2];
            var result = Utilities.Utils.RealizarPeticionPost("https://localhost:7121/api/Usuario/SeguirUsuario",
                new FollowModel
                {
                    NombreUsuarioSeguidor = usuarioSeguidor,
                    NombreUsuarioASeguir = usuarioASeguir
                });
            result.Wait();
            var res = result.Result.Content.ReadAsStringAsync();
            res.Wait();
            Console.WriteLine(res.Result);
        }

        /// <summary>
        /// Dado un string que es el comando dashboard o wall donde tiene el nombre del usuario
        /// Se realiza una peticion a una web API para obtener 10 los post más recientes hechos por 
        /// los usuarios que sigue el usuario
        /// </summary>
        /// <param name="comando">Comando wall/dashboard que contiene el nombre del usuario</param>
        public static void MostrarDashboard(string comando)
        {
            string[] parts = comando.Split(' ');
            string usuario = parts[1];
            var result = Utilities.Utils.RealizarPeticion($"https://localhost:7121/api/Post/{usuario}");
            result.Wait();
            var response = result.Result.Content.ReadAsStringAsync();
            response.Wait();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<PostResponseViewModel> responseFinal = JsonSerializer.Deserialize<List<PostResponseViewModel>>(response.Result, options);
            foreach (PostResponseViewModel p in responseFinal)
            {
                Console.WriteLine($"'{p.Mensaje}' {p.NombreUsuario} @{p.HoraCreacion.Split('.')[0]}");
            }
        }
    }
}
