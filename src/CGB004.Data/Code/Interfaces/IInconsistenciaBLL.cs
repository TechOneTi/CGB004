using CGB004.Data.Model.Inconsistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGB004.Data.Code.Interfaces
{
    public interface IInconsistenciaBLL
    {
        Task<int> BuscarInconsistencial();
        Task<bool> InserirInconsistencia(InconsistenciaRequest request);
    }
}
