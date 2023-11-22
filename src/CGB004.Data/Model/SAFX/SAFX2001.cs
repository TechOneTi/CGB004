using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGB004.Data.Model.SAFX
{
    public  class SAFX2001
    {
        public string COD_OPERACAO { get; set; }
        public string DATA_X2001 { get; set; }
        public string DESCRICAO { get; set; }
        public DateTime? DAT_GRAVACAO { get; set; }
        public string IND_TP_OP { get; set; }
        public Decimal? PST_ID { get; set; }
        public string MASC_ARQUIVO { get; set; }
        public string NUM_LOTE { get; set; }

    }
}
