using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGB004.Data.Model.SAFX
{
    public  class SAFX80
    {
        public string COD_EMPRESA { get; set; }
        public string COD_ESTAB { get; set; }
        public string COD_CONTA { get; set; }
        public string DATA_SALDO { get; set; }
        public string COD_CUSTO { get; set; }
        public string VLR_SALDO_CONT_ANT { get; set; }
        public string IND_DEB_CRED_ANT { get; set; }
        public string VLR_TOT_DEB { get; set; }
        public string VLR_TOT_CRED { get; set; }
        public string VLR_SALDO_CONT_ATU { get; set; }
        public string IND_DEB_CRED_ATU { get; set; }
        public DateTime? DAT_GRAVACAO { get; set; }
        public string IDENTIF_SALDO { get; set; }        
        public string COD_SISTEMA_ORIG { get; set; }
        public Decimal? PST_ID { get; set; }
        public string NUM_LOTE { get; set; }

    }
}
