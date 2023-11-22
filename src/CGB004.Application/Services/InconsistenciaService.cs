using CGB004.Application.Interfaces;
using CGB004.Data.Code.Interfaces;
using CGB004.Data.Model.Inconsistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGB004.Application.Services
{
    public class InconsistenciaService : IInconsistenciaService
    {
        private readonly IInconsistenciaBLL _inconsistenciaBLL;
        public InconsistenciaService(IInconsistenciaBLL inconsistenciaBLL)
        {
            _inconsistenciaBLL = inconsistenciaBLL;
        }
        public async Task<int> BuscarInconsistencia()
        {
            return await _inconsistenciaBLL.BuscarInconsistencial();
        }

        public async Task<bool> InserirInconsistencia(InconsistenciaRequest request)
        {
            return await _inconsistenciaBLL.InserirInconsistencia(request);
        }
    }
}
