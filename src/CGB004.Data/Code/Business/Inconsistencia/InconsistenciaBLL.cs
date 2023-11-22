using CGB004.Data.Code.Interfaces;
using CGB004.Data.Model.Inconsistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGB004.Data.Code.Business.Inconsistencia
{
    public class InconsistenciaBLL : IInconsistenciaBLL
    {
        private readonly IInconsistenciaDAL _inconsistenciaDAL;
        public InconsistenciaBLL(IInconsistenciaDAL inconsistenciaDAL)
        {
            _inconsistenciaDAL = inconsistenciaDAL;
        }

        public async Task<int> BuscarInconsistencial()
        {
            try
            {
                return await _inconsistenciaDAL.BuscarInconsistencial();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> InserirInconsistencia(InconsistenciaRequest request)
        {
            try
            {
                //request.DATREF.ToString("yyyy/MM/dd");
                return await _inconsistenciaDAL.InserirInconsistencia(request);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
