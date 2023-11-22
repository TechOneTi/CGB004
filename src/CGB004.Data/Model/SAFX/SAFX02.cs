using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGB004.Data.Model.SAFX
{
    public  class SAFX02
    {
        public string COD_EMPRESA { get; set; }
        public string COD_ESTAB { get; set; }
        public string COD_CONTA { get; set; }
        public string DATA_SALDO { get; set; }        
        public string VLR_SALDO_INI { get; set; }
        public string IND_SALDO_INI { get; set; }
        public string VLR_SALDO_FIM { get; set; }
        public string IND_SALDO_FIM { get; set; }
        public string VLR_TOT_CRE { get; set; }
        public string VLR_TOT_DEB { get; set; }
        public DateTime? DAT_GRAVACAO { get; set; }
        public string IDENTIF_SALDO { get; set; }
        public string COD_SISTEMA_ORIG { get; set; }
        public Decimal? PST_ID { get; set; }        
        public string NUM_LOTE { get; set; }

    }
}
