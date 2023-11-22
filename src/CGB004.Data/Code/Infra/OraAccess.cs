using Oracle.ManagedDataAccess.Client;
using System.Data;
using CGB004.Data.Code.Helpers;
using CGB004.Data.Configuration;

namespace CGB004.Data.Code.Infra
{
    /// <summary>
    /// Contexto de Conexão com o banco de dados padrão.
    /// </summary>
    public class OraAccess : IDisposable, IOraAccess
    {
        private readonly AppSettings _appSettings;
        public OraAccess(AppSettings appSettings)
        {
            _appSettings = appSettings;
            ConnectionIdx = EnumConexoes.MRT001;
        }
        /// <summary>
        /// Auxiliar de Conexão.
        /// </summary>
        private OracleConnection ConnectionAux { get; set; }

        /// <summary>
        /// Auxiliar comando padrão Oracle.
        /// </summary>
        private OracleCommand CommandAux { get; set; }

        /// <summary>
        /// Indice das string de conexoes de banco
        /// </summary>
        public EnumConexoes ConnectionIdx { get; set; }

        private OracleTransaction TransactionAux { get; set; }       

        /// <summary>
        /// Conexão padrão Oracle.
        /// </summary>
        protected OracleConnection Connection
        {
            get
            {
                if (ConnectionAux == null || ConnectionAux.State == ConnectionState.Closed || ConnectionAux.State == ConnectionState.Broken)
                {
                    if (ConnectionAux != null)
                    {
                        ConnectionAux.Close();
                        ConnectionAux.Dispose();
                    }
                    ConnectionAux = new OracleConnection(ConnectionIdx == 0 ? _appSettings.ConfigMartins : _appSettings.ConfigMRTDSV01);
                    ConnectionAux.Open();
                }
                return ConnectionAux;
            }
        }



        /// <summary>
        /// Criar transação
        /// </summary>
        public void BeginTransaction()
        {
            TransactionAux = Connection.BeginTransaction();
        }

        /// <summary>
        /// Executar commit da transação
        /// </summary>
        public void Commit()
        {
            if (TransactionAux != null)
                TransactionAux.Commit();
            TransactionAux = null;
            Connection.Close();
        }

        /// <summary>
        /// Executar rollback da transação
        /// </summary>
        public void Rollback()
        {
            if (TransactionAux != null)
                TransactionAux.Rollback();
            TransactionAux = null;
            Connection.Close();
        }

        /// <summary>
        /// Comando padrão Oracle.
        /// </summary>
        protected OracleCommand Command
        {
            get
            {
                if (this.CommandAux == null)
                    this.CommandAux = new OracleCommand() { Connection = this.Connection };
                else
                    this.CommandAux.Connection = this.Connection;
                return this.CommandAux;
            }
        }

        /// <summary>
        /// Finaliza todos os recursos utilizados.
        /// </summary>
        private void EndMe()
        {
            try
            {
                if (this.CommandAux != null)
                {
                    this.CommandAux.Dispose();
                    this.CommandAux = null;
                }
                if (this.ConnectionAux != null)
                {
                    this.ConnectionAux.Close();
                    this.ConnectionAux.Dispose();
                    this.ConnectionAux = null;
                }
            }
            catch
            {
                // TODO: Nothing.
            }
        }

        /// <summary>
        /// Finaliza todos os recursos utilizados.
        /// </summary>
        public void Dispose()
        {
            EndMe();
        }

        /// <summary>
        /// Finaliza todos os recursos utilizados pelo Garbage Collector.
        /// </summary>
        ~OraAccess()
        {
            if (TransactionAux == null)
                EndMe();
        }
    }
}
