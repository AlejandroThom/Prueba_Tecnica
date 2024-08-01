using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoADatos.IRepositorio
{
    public interface IRepositorio
    {
        /// <summary>
        /// Limpia los registros actuales o los reestablece
        /// </summary>
        void LimpiarRegistros();
    }
}
