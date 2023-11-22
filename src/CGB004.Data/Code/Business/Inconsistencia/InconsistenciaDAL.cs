using CGB004.Data.Code.Infra;
using CGB004.Data.Code.Interfaces;
using CGB004.Data.Configuration;
using CGB004.Data.Model.Inconsistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGB004.Data.Code.Business.Inconsistencia
{
    public class InconsistenciaDAL : OraAccess, IInconsistenciaDAL
    {
        public InconsistenciaDAL(AppSettings appSettings) : base(appSettings)
        {
        }

        public Task<int> BuscarInconsistencial()
        {
            try
            {
                this.ConnectionIdx = (Helpers.EnumConexoes)2;

                var retorno = Convert.ToInt32(Command.UseQuery(InconsistenciaDALSQL.BuscarInconsistencia())
                    .ExecuteScalar());

                return Task.FromResult(retorno);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> InserirInconsistencia(InconsistenciaRequest request)
        {
            this.ConnectionIdx = (Helpers.EnumConexoes)2;
            try
            {
                var retorno = Command.UseQuery(InconsistenciaDALSQL.InserirInconsistencia())
                     .AddParameter("numseq", request.NUMSEQ)
                     .AddParameter("codemp", request.CODEMP)
                     .AddParameter("codfilemp", request.CODFILEMP)
                     .AddParameter("datref", request.DATLMT.ToString("yyyy-MM-dd"))
                    .AddParameter("desobs", request.NUMCGCFRN)
                    .AddParameter("qdelitabs", request.NUMNOTFSC)
                    .AddParameter("datref", request.DATEMS.ToString("yyyy-MM-dd"))
                    .AddParameter("descdoitejsn", request.VLRPGT)
                    .AddParameter("descdoitejsn", request.DESORISLC)
                    .AddParameter("descdoitejsn", request.DESOBS)
                    .AddParameter("descdoitejsn", request.DESCDOITEJSN)
                    .ExecuteNonQuery();

                return Task.FromResult(retorno > 0);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
