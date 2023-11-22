using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGB004.Data.Code.Business.Inconsistencia
{
    public class InconsistenciaDALSQL
    {
        public static string BuscarInconsistencia()
        {
            StringBuilder sql = new();

            sql.AppendLine(@"SELECT NVL(MAX(NUMSEQ), 0) + 1 AS NUMSEQ FROM MRT.MOVITFFSC");

            return sql.ToString();
        }
        public static string InserirInconsistencia()
        {
            StringBuilder sql = new();

            sql.AppendLine(@"
                INSERT INTO mrt.MOVITFFSC (
                    numseq,
                    codemp,
                    codfilemp,
                    datlmt,
                    numcgcfrn,
                    numnotfsc,
                    datems,
                    vlrpgt,
                    desorislc,
                    desobs,
                    descdoitejsn
                ) VALUES (
                    :numseq,
                    :codemp,
                    :codfilemp,
                    TO_DATE(:datlmt, 'YYYY-MM-DD'),
                    :numcgcfrn,
                    :numnotfsc,
                    TO_DATE(:datems, 'YYYY-MM-DD'),
                    :vlrpgt,
                    :desorislc,
                    :desobs,
                    :descdoitejsn
            )");

            return sql.ToString();
        }
    }
}
