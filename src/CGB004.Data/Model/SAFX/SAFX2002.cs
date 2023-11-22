using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGB004.Data.Model.SAFX
{
    public  class SAFX2002
    {
        public string COD_OPERACAO { get; set; }
        public string DATA_X2002 { get; set; }
        public string DESCRICAO { get; set; }        
        public string IND_CONTA { get; set; }
        public string COD_CONTA_REDUZ { get; set; }
        public DateTime? DAT_GRAVACAO { get; set; }
        public string COD_CONTA_SINT { get; set; }
        public string IND_NATUREZA { get; set; }
        public string NIVEL { get; set; }
        public string IND_LANCTO_GLOBAL { get; set; }
        public Decimal? SEQ_ARQ { get; set; }
        public string COD_CONTA_ANL_TOT { get; set; }
        public string COD_CONTA_PADRAO { get; set; }
        public string IND_ATO_COTEPE { get; set; }
        public string COD_CUSTO { get; set; }
        public string IND_SITUACAO { get; set; }
        public string IND_CONTA_CONSOLID { get; set; }
        public Decimal? PST_ID { get; set; }
        public string MASC_ARQUIVO { get; set; }
        public string DESC_DETALHADA { get; set; }
        public string NUM_LOTE { get; set; }

    }
}
