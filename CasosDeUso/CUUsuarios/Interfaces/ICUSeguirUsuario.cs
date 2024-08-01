using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUso.CUUsuarios.Interfaces
{
    public interface ICUSeguirUsuario
    {
        void SeguirUsuario(string nombreUsuario, string nombreUsuarioSeguidor);
    }
}
