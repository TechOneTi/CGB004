using CGB004.Data.Model.Inconsistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGB004.Application.Interfaces
{
    public interface IInconsistenciaService
    {
        Task<int> BuscarInconsistencia();
        Task<bool> InserirInconsistencia(InconsistenciaRequest request);
    }
}
