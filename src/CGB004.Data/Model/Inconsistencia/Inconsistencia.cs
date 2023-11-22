using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGB004.Data.Model.Inconsistencia
{
    public class InconsistenciaRequest
    {
        /// <summary>
        /// NUMERO DE SEQUENCIA                                                   
        /// </summary>
        public int NUMSEQ { get; set; }
        /// <summary>
        /// CODIGO EMPRESA                                                        
        /// </summary>
        public int CODEMP { get; set; }
        /// <summary>
        /// CODIGO DA FILIAL DA EMPRESA                                           
        /// </summary>
        public int CODFILEMP { get; set; }
        /// <summary>
        /// DATA LANCAMENTO                                                       
        /// </summary>
        public DateTime DATLMT { get; set; }
        /// <summary>
        /// CNPJ
        /// </summary>
        public string NUMCGCFRN { get; set; }
        /// <summary>
        /// NUMERO NOTA FISCAL                                                    
        /// </summary>
        public int NUMNOTFSC { get; set; }
        /// <summary>
        /// DATA DA EMISSAO                                                       
        /// </summary>
        public DateTime DATEMS { get; set; }
        /// <summary>
        /// VALOR DE PAGAMENTO                                                    
        /// </summary>
        public int VLRPGT { get; set; }
        /// <summary>
        /// DESCRICAO ORIGEM DA SOLICITACAO                                       
        /// </summary>
        public string DESORISLC { get; set; }
        /// <summary>
        /// DESCRICAO OBSERVACAO DO CLIENTE                                       
        /// </summary>
        public string DESOBS { get; set; }
        /// <summary>
        /// DESCRICAO CONTEUDO ITEM JSON                                          
        /// </summary>
        public string DESCDOITEJSN { get; set; }
    }
}
