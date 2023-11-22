using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGB004.Data.Model.SAFX
{
    public  class SAFX2003
    {
        public string COD_CUSTO { get; set; }
        public string DATA_X2003 { get; set; }
        public string DESCRICAO { get; set; }
        public string IND_CTRL_INVEST { get; set; }
        public DateTime? DAT_GRAVACAO { get; set; }
        public string COD_CUSTO_SPED { get; set; }        
        public Decimal? PST_ID { get; set; }
        public string MASC_ARQUIVO { get; set; }
        public string NUM_LOTE { get; set; }

    }
}
