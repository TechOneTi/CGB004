using CGB004.Data.Code.Api;
using CGB004.Data.Code.Helpers;
using CGB004.Data.Code.Infra;
using CGB004.Data.Code.Interfaces;
using CGB004.Data.Configuration;
using CGB004.Data.Model.SAFX;
using Oracle.ManagedDataAccess.Client;
using System.Data;


namespace CGB004.Data.Code.Business.SAFX
{
    public class SAFXDAL : OraAccess, ISAFXDAL
    {
        private readonly AppSettings _appSettings;
        private readonly IApi _api;
        public SAFXDAL(AppSettings appSettings, IApi api) : base(appSettings)
        {
            _appSettings = appSettings;
            _api = api;
        }

        public Task<bool> InserirSAFX01(SAFX01 objRow)
        {
            int retorno = 0;
            try
            {
                //Definição indice da conexão
                ConnectionIdx = EnumConexoes.MRT001;

                Command.CommandText = SAFXDALSQL.InserirSAFX01();
                Command.CommandType = CommandType.Text;
                Command.CommandTimeout = 0;
                Command.Parameters.Clear();

                Command.Parameters.Add("COD_EMPRESA", OracleDbType.Varchar2).Value = objRow.COD_EMPRESA;
                Command.Parameters.Add("COD_ESTAB", OracleDbType.Varchar2).Value = objRow.COD_ESTAB;
                Command.Parameters.Add("DATA_OPERACAO", OracleDbType.Varchar2).Value = objRow.DATA_OPERACAO;
                Command.Parameters.Add("CONTA_DEB_CRED", OracleDbType.Varchar2).Value = objRow.CONTA_DEB_CRED;
                Command.Parameters.Add("IND_DEB_CRE", OracleDbType.Varchar2).Value = objRow.IND_DEB_CRE;
                Command.Parameters.Add("ARQUIVAMENTO", OracleDbType.Varchar2).Value = objRow.ARQUIVAMENTO;
                Command.Parameters.Add("VLR_LANCTO", OracleDbType.Varchar2).Value = objRow.VLR_LANCTO;
                Command.Parameters.Add("CONTRA_PART", OracleDbType.Varchar2).Value = objRow.CONTRA_PART;
                Command.Parameters.Add("CENTRO_CUSTO", OracleDbType.Varchar2).Value = objRow.CENTRO_CUSTO;
                Command.Parameters.Add("CENTRO_DESPESA", OracleDbType.Varchar2).Value = objRow.CENTRO_DESPESA;
                Command.Parameters.Add("HISTPADRAO", OracleDbType.Varchar2).Value = objRow.HISTPADRAO;
                Command.Parameters.Add("COD_OPERACAO", OracleDbType.Varchar2).Value = objRow.COD_OPERACAO;
                Command.Parameters.Add("HISTCOMPL", OracleDbType.Varchar2).Value = objRow.HISTCOMPL;
                Command.Parameters.Add("COD_INDICE_CONV", OracleDbType.Varchar2).Value = objRow.COD_INDICE_CONV;
                Command.Parameters.Add("VLR_OPER_IND", OracleDbType.Varchar2).Value = objRow.VLR_OPER_IND;
                Command.Parameters.Add("DAT_GRAVACAO", OracleDbType.Date).Value = objRow.DAT_GRAVACAO;
                Command.Parameters.Add("NUM_LANCAMENTO", OracleDbType.Varchar2).Value = objRow.NUM_LANCAMENTO;
                Command.Parameters.Add("TIPO_LANCTO", OracleDbType.Varchar2).Value = objRow.TIPO_LANCTO;
                Command.Parameters.Add("IND_PFJ_EMPRESA", OracleDbType.Varchar2).Value = objRow.IND_PFJ_EMPRESA;
                Command.Parameters.Add("COD_PFJ_EMPRESA", OracleDbType.Varchar2).Value = objRow.COD_PFJ_EMPRESA;
                Command.Parameters.Add("COD_SERVICO", OracleDbType.Varchar2).Value = objRow.COD_SERVICO;
                Command.Parameters.Add("IDENTIF_LANC_RES", OracleDbType.Varchar2).Value = objRow.IDENTIF_LANC_RES;
                Command.Parameters.Add("COD_SISTEMA_ORIG", OracleDbType.Varchar2).Value = objRow.COD_SISTEMA_ORIG;
                Command.Parameters.Add("IDENTIF_SALDO", OracleDbType.Varchar2).Value = objRow.IDENTIF_SALDO;
                Command.Parameters.Add("DSC_RESERVADO1", OracleDbType.Varchar2).Value = objRow.DSC_RESERVADO1;
                Command.Parameters.Add("DSC_RESERVADO2", OracleDbType.Varchar2).Value = objRow.DSC_RESERVADO2;
                Command.Parameters.Add("DSC_RESERVADO3", OracleDbType.Varchar2).Value = objRow.DSC_RESERVADO3;
                Command.Parameters.Add("DSC_RESERVADO4", OracleDbType.Varchar2).Value = objRow.DSC_RESERVADO4;
                Command.Parameters.Add("DSC_RESERVADO5", OracleDbType.Varchar2).Value = objRow.DSC_RESERVADO5;
                Command.Parameters.Add("DSC_RESERVADO6", OracleDbType.Varchar2).Value = objRow.DSC_RESERVADO6;
                Command.Parameters.Add("DSC_RESERVADO7", OracleDbType.Varchar2).Value = objRow.DSC_RESERVADO7;
                Command.Parameters.Add("DSC_RESERVADO8", OracleDbType.Varchar2).Value = objRow.DSC_RESERVADO8;
                Command.Parameters.Add("NUM_PROCESSO", OracleDbType.Decimal).Value = objRow.NUM_PROCESSO;
                Command.Parameters.Add("DAT_LANCTO_EXTEMP", OracleDbType.Varchar2).Value = objRow.DAT_LANCTO_EXTEMP;
                Command.Parameters.Add("PST_ID", OracleDbType.Decimal).Value = objRow.PST_ID;
                Command.Parameters.Add("COD_EVENTO_DESIF", OracleDbType.Varchar2).Value = objRow.COD_EVENTO_DESIF;
                Command.Parameters.Add("COD_ESTADO_ORIG", OracleDbType.Varchar2).Value = objRow.COD_ESTADO_ORIG;
                Command.Parameters.Add("COD_MUNIC_ORIG", OracleDbType.Varchar2).Value = objRow.COD_MUNIC_ORIG;
                Command.Parameters.Add("NUM_LOTE", OracleDbType.Varchar2).Value = objRow.NUM_LOTE;

                retorno = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult(retorno > 0);
        }



        public Task<bool> InserirSAFX02(SAFX02 objRow)
        {
            int retorno = 0;
            try
            {
                //Definição indice da conexão
                ConnectionIdx = EnumConexoes.MRT001;

                Command.CommandText = SAFXDALSQL.InserirSAFX02();
                Command.CommandType = CommandType.Text;
                Command.CommandTimeout = 0;
                Command.Parameters.Clear();

                Command.Parameters.Add("COD_EMPRESA", OracleDbType.Varchar2).Value = objRow.COD_EMPRESA;
                Command.Parameters.Add("COD_ESTAB", OracleDbType.Varchar2).Value = objRow.COD_ESTAB;
                Command.Parameters.Add("COD_CONTA", OracleDbType.Varchar2).Value = objRow.COD_CONTA;
                Command.Parameters.Add("DATA_SALDO", OracleDbType.Varchar2).Value = objRow.DATA_SALDO;
                Command.Parameters.Add("VLR_SALDO_INI", OracleDbType.Varchar2).Value = objRow.VLR_SALDO_INI;
                Command.Parameters.Add("IND_SALDO_INI", OracleDbType.Varchar2).Value = objRow.IND_SALDO_INI;
                Command.Parameters.Add("VLR_SALDO_FIM", OracleDbType.Varchar2).Value = objRow.VLR_SALDO_FIM;
                Command.Parameters.Add("IND_SALDO_FIM", OracleDbType.Varchar2).Value = objRow.IND_SALDO_FIM;
                Command.Parameters.Add("VLR_TOT_CRE", OracleDbType.Varchar2).Value = objRow.VLR_TOT_CRE;
                Command.Parameters.Add("VLR_TOT_DEB", OracleDbType.Varchar2).Value = objRow.VLR_TOT_DEB;
                Command.Parameters.Add("VLR_SALDO_FIM", OracleDbType.Varchar2).Value = objRow.VLR_SALDO_FIM;
                Command.Parameters.Add("VLR_SALDO_FIM", OracleDbType.Varchar2).Value = objRow.VLR_SALDO_FIM;
                Command.Parameters.Add("DAT_GRAVACAO", OracleDbType.Date).Value = objRow.DAT_GRAVACAO;
                Command.Parameters.Add("IDENTIF_SALDO", OracleDbType.Varchar2).Value = objRow.IDENTIF_SALDO;
                Command.Parameters.Add("COD_SISTEMA_ORIG", OracleDbType.Varchar2).Value = objRow.COD_SISTEMA_ORIG;
                Command.Parameters.Add("PST_ID", OracleDbType.Decimal).Value = objRow.PST_ID;
                Command.Parameters.Add("NUM_LOTE", OracleDbType.Varchar2).Value = objRow.NUM_LOTE;

                retorno = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult(retorno > 0);
        }

        public Task<bool> InserirSAFX80(SAFX80 objRow)
        {
            int retorno = 0;
            try
            {
                //Definição indice da conexão
                ConnectionIdx = EnumConexoes.MRT001;

                Command.CommandText = SAFXDALSQL.InserirSAFX80();
                Command.CommandType = CommandType.Text;
                Command.CommandTimeout = 0;
                Command.Parameters.Clear();

                Command.Parameters.Add("COD_EMPRESA", OracleDbType.Varchar2).Value = objRow.COD_EMPRESA;
                Command.Parameters.Add("COD_ESTAB", OracleDbType.Varchar2).Value = objRow.COD_ESTAB;
                Command.Parameters.Add("COD_CONTA", OracleDbType.Varchar2).Value = objRow.COD_CONTA;
                Command.Parameters.Add("DATA_SALDO", OracleDbType.Varchar2).Value = objRow.DATA_SALDO;
                Command.Parameters.Add("COD_CUSTO", OracleDbType.Varchar2).Value = objRow.COD_CUSTO;
                Command.Parameters.Add("VLR_SALDO_CONT_ANT", OracleDbType.Varchar2).Value = objRow.VLR_SALDO_CONT_ANT;
                Command.Parameters.Add("IND_DEB_CRED_ANT", OracleDbType.Varchar2).Value = objRow.IND_DEB_CRED_ANT;
                Command.Parameters.Add("VLR_TOT_DEB", OracleDbType.Varchar2).Value = objRow.VLR_TOT_DEB;
                Command.Parameters.Add("VLR_TOT_CRED", OracleDbType.Varchar2).Value = objRow.VLR_TOT_CRED;
                Command.Parameters.Add("VLR_TOT_DEB", OracleDbType.Varchar2).Value = objRow.VLR_TOT_DEB;
                Command.Parameters.Add("VLR_SALDO_CONT_ATU", OracleDbType.Varchar2).Value = objRow.VLR_SALDO_CONT_ATU;
                Command.Parameters.Add("IND_DEB_CRED_ATU", OracleDbType.Varchar2).Value = objRow.IND_DEB_CRED_ATU;
                Command.Parameters.Add("DAT_GRAVACAO", OracleDbType.Date).Value = objRow.DAT_GRAVACAO;
                Command.Parameters.Add("IDENTIF_SALDO", OracleDbType.Varchar2).Value = objRow.IDENTIF_SALDO;
                Command.Parameters.Add("COD_SISTEMA_ORIG", OracleDbType.Varchar2).Value = objRow.COD_SISTEMA_ORIG;
                Command.Parameters.Add("PST_ID", OracleDbType.Decimal).Value = objRow.PST_ID;
                Command.Parameters.Add("NUM_LOTE", OracleDbType.Varchar2).Value = objRow.NUM_LOTE;

                retorno = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult(retorno > 0);
        }

        public Task<bool> InserirSAFX2001(SAFX2001 objRow)
        {
            int retorno = 0;
            try
            {
                //Definição indice da conexão
                ConnectionIdx = EnumConexoes.MRT001;

                Command.CommandText = SAFXDALSQL.InserirSAFX2001();
                Command.CommandType = CommandType.Text;
                Command.CommandTimeout = 0;
                Command.Parameters.Clear();

                Command.Parameters.Add("COD_OPERACAO", OracleDbType.Varchar2).Value = objRow.COD_OPERACAO;
                Command.Parameters.Add("DATA_X2001", OracleDbType.Varchar2).Value = objRow.DATA_X2001;
                Command.Parameters.Add("DESCRICAO", OracleDbType.Varchar2).Value = objRow.DESCRICAO;
                Command.Parameters.Add("DAT_GRAVACAO", OracleDbType.Date).Value = objRow.DAT_GRAVACAO;
                Command.Parameters.Add("IND_TP_OP", OracleDbType.Varchar2).Value = objRow.IND_TP_OP;
                Command.Parameters.Add("PST_ID", OracleDbType.Decimal).Value = objRow.PST_ID;
                Command.Parameters.Add("MASC_ARQUIVO", OracleDbType.Varchar2).Value = objRow.MASC_ARQUIVO;
                Command.Parameters.Add("NUM_LOTE", OracleDbType.Varchar2).Value = objRow.NUM_LOTE;

                retorno = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult(retorno > 0);
        }

        public Task<bool> InserirSAFX2002(SAFX2002 objRow)
        {
            int retorno = 0;
            try
            {
                //Definição indice da conexão
                ConnectionIdx = EnumConexoes.MRT001;

                Command.CommandText = SAFXDALSQL.InserirSAFX2002();
                Command.CommandType = CommandType.Text;
                Command.CommandTimeout = 0;
                Command.Parameters.Clear();

                Command.Parameters.Add("COD_OPERACAO", OracleDbType.Varchar2).Value = objRow.COD_OPERACAO;
                Command.Parameters.Add("DATA_X2002", OracleDbType.Varchar2).Value = objRow.DATA_X2002;
                Command.Parameters.Add("DESCRICAO", OracleDbType.Varchar2).Value = objRow.DESCRICAO;
                Command.Parameters.Add("IND_CONTA", OracleDbType.Varchar2).Value = objRow.IND_CONTA;
                Command.Parameters.Add("COD_CONTA_REDUZ", OracleDbType.Varchar2).Value = objRow.COD_CONTA_REDUZ;
                Command.Parameters.Add("DAT_GRAVACAO", OracleDbType.Date).Value = objRow.DAT_GRAVACAO;
                Command.Parameters.Add("COD_CONTA_SINT", OracleDbType.Varchar2).Value = objRow.COD_CONTA_SINT;
                Command.Parameters.Add("IND_NATUREZA", OracleDbType.Varchar2).Value = objRow.IND_NATUREZA;
                Command.Parameters.Add("NIVEL", OracleDbType.Varchar2).Value = objRow.NIVEL;
                Command.Parameters.Add("IND_LANCTO_GLOBAL", OracleDbType.Varchar2).Value = objRow.IND_LANCTO_GLOBAL;
                Command.Parameters.Add("SEQ_ARQ", OracleDbType.Decimal).Value = objRow.SEQ_ARQ;
                Command.Parameters.Add("COD_CONTA_ANL_TOT", OracleDbType.Varchar2).Value = objRow.COD_CONTA_ANL_TOT;
                Command.Parameters.Add("COD_CONTA_PADRAO", OracleDbType.Varchar2).Value = objRow.COD_CONTA_PADRAO;
                Command.Parameters.Add("IND_ATO_COTEPE", OracleDbType.Varchar2).Value = objRow.IND_ATO_COTEPE;
                Command.Parameters.Add("COD_CUSTO", OracleDbType.Varchar2).Value = objRow.COD_CUSTO;
                Command.Parameters.Add("IND_SITUACAO", OracleDbType.Varchar2).Value = objRow.IND_SITUACAO;
                Command.Parameters.Add("IND_CONTA_CONSOLID", OracleDbType.Varchar2).Value = objRow.IND_CONTA_CONSOLID;
                Command.Parameters.Add("PST_ID", OracleDbType.Decimal).Value = objRow.PST_ID;
                Command.Parameters.Add("MASC_ARQUIVO", OracleDbType.Varchar2).Value = objRow.MASC_ARQUIVO;
                Command.Parameters.Add("DESC_DETALHADA", OracleDbType.Varchar2).Value = objRow.DESC_DETALHADA;
                Command.Parameters.Add("NUM_LOTE", OracleDbType.Varchar2).Value = objRow.NUM_LOTE;

                retorno = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult(retorno > 0);
        }

        public Task<bool> InserirSAFX2003(SAFX2003 objRow)
        {
            int retorno = 0;
            try
            {
                //Definição indice da conexão
                ConnectionIdx = EnumConexoes.MRT001;

                Command.CommandText = SAFXDALSQL.InserirSAFX2003();
                Command.CommandType = CommandType.Text;
                Command.CommandTimeout = 0;
                Command.Parameters.Clear();

                Command.Parameters.Add("COD_CUSTO", OracleDbType.Varchar2).Value = objRow.COD_CUSTO;
                Command.Parameters.Add("DATA_X2003", OracleDbType.Varchar2).Value = objRow.DATA_X2003;
                Command.Parameters.Add("DESCRICAO", OracleDbType.Varchar2).Value = objRow.DESCRICAO;
                Command.Parameters.Add("IND_CTRL_INVEST", OracleDbType.Varchar2).Value = objRow.IND_CTRL_INVEST;
                Command.Parameters.Add("DAT_GRAVACAO", OracleDbType.Date).Value = objRow.DAT_GRAVACAO;
                Command.Parameters.Add("COD_CUSTO_SPED", OracleDbType.Varchar2).Value = objRow.COD_CUSTO_SPED;
                Command.Parameters.Add("PST_ID", OracleDbType.Decimal).Value = objRow.PST_ID;
                Command.Parameters.Add("MASC_ARQUIVO", OracleDbType.Varchar2).Value = objRow.MASC_ARQUIVO;
                Command.Parameters.Add("NUM_LOTE", OracleDbType.Varchar2).Value = objRow.NUM_LOTE;                  


                retorno = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult(retorno > 0);
        }
    }
}
