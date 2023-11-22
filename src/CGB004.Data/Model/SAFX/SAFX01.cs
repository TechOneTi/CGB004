using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGB004.Data.Model.SAFX
{
    public  class SAFX01
    {
        public string COD_EMPRESA { get; set; }
        public string COD_ESTAB { get; set; }
        public string DATA_OPERACAO { get; set; }
        public string CONTA_DEB_CRED { get; set; }
        public string IND_DEB_CRE { get; set; }
        public string ARQUIVAMENTO { get; set; }
        public string VLR_LANCTO { get; set; }
        public string CONTRA_PART { get; set; }
        public string CENTRO_CUSTO { get; set; }
        public string CENTRO_DESPESA { get; set; }
        public string HISTPADRAO { get; set; }
        public string COD_OPERACAO { get; set; }
        public string HISTCOMPL { get; set; }
        public string COD_INDICE_CONV { get; set; }
        public string VLR_OPER_IND { get; set; }
        public DateTime? DAT_GRAVACAO { get; set; }
        public string NUM_LANCAMENTO { get; set; }
        public string TIPO_LANCTO { get; set; }
        public string IND_PFJ_EMPRESA { get; set; }
        public string COD_PFJ_EMPRESA { get; set; }
        public string COD_SERVICO { get; set; }
        public string IDENTIF_LANC_RES { get; set; }
        public string COD_SISTEMA_ORIG { get; set; }
        public string IDENTIF_SALDO { get; set; }
        public string DSC_RESERVADO1 { get; set; }
        public string DSC_RESERVADO2 { get; set; }
        public string DSC_RESERVADO3 { get; set; }
        public string DSC_RESERVADO4 { get; set; }
        public string DSC_RESERVADO5 { get; set; }
        public string DSC_RESERVADO6 { get; set; }
        public string DSC_RESERVADO7 { get; set; }
        public string DSC_RESERVADO8 { get; set; }
        public Decimal? NUM_PROCESSO { get; set; }
        public string DAT_LANCTO_EXTEMP { get; set; }
        public Decimal? PST_ID { get; set; }
        public string COD_EVENTO_DESIF { get; set; }
        public string COD_ESTADO_ORIG { get; set; }
        public string COD_MUNIC_ORIG { get; set; }
        public string NUM_LOTE { get; set; }

    }
}
