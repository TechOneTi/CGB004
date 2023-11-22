using CGB004.Data.Code.Api;
using CGB004.Data.Code.Helpers;
using CGB004.Data.Code.Infra;
using CGB004.Data.Code.Interfaces;
using CGB004.Data.Configuration;
using CGB004.Data.Model.SAFX;
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

                //Entrada
                //Command.Parameters.Add("CODEMP", OracleDbType.Int32).Value = codEmp;
                //Command.Parameters.Add("CODFILEMP", OracleDbType.Int32).Value = codFilEmp;
                //Command.Parameters.Add("CODUNDNGC", OracleDbType.Int32).Value = codUndNeg;

                var obj = Command.ExecuteScalar();


                retorno = ((int)(obj ?? 0));

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult(retorno > 0 ? true : false);
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

                //Entrada
                //Command.Parameters.Add("CODEMP", OracleDbType.Int32).Value = codEmp;
                //Command.Parameters.Add("CODFILEMP", OracleDbType.Int32).Value = codFilEmp;
                //Command.Parameters.Add("CODUNDNGC", OracleDbType.Int32).Value = codUndNeg;

                var obj = Command.ExecuteScalar();


                retorno = ((int)(obj ?? 0));

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult(retorno > 0 ? true : false);
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

                //Entrada
                //Command.Parameters.Add("CODEMP", OracleDbType.Int32).Value = codEmp;
                //Command.Parameters.Add("CODFILEMP", OracleDbType.Int32).Value = codFilEmp;
                //Command.Parameters.Add("CODUNDNGC", OracleDbType.Int32).Value = codUndNeg;

                var obj = Command.ExecuteScalar();


                retorno = ((int)(obj ?? 0));

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult(retorno > 0 ? true : false);
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

                //Entrada
                //Command.Parameters.Add("CODEMP", OracleDbType.Int32).Value = codEmp;
                //Command.Parameters.Add("CODFILEMP", OracleDbType.Int32).Value = codFilEmp;
                //Command.Parameters.Add("CODUNDNGC", OracleDbType.Int32).Value = codUndNeg;

                var obj = Command.ExecuteScalar();


                retorno = ((int)(obj ?? 0));

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult(retorno > 0 ? true : false);
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

                //Entrada
                //Command.Parameters.Add("CODEMP", OracleDbType.Int32).Value = codEmp;
                //Command.Parameters.Add("CODFILEMP", OracleDbType.Int32).Value = codFilEmp;
                //Command.Parameters.Add("CODUNDNGC", OracleDbType.Int32).Value = codUndNeg;

                var obj = Command.ExecuteScalar();


                retorno = ((int)(obj ?? 0));

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult(retorno > 0 ? true : false);
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

                //Entrada
                //Command.Parameters.Add("CODEMP", OracleDbType.Int32).Value = codEmp;
                //Command.Parameters.Add("CODFILEMP", OracleDbType.Int32).Value = codFilEmp;
                //Command.Parameters.Add("CODUNDNGC", OracleDbType.Int32).Value = codUndNeg;

                var obj = Command.ExecuteScalar();


                retorno = ((int)(obj ?? 0));

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Task.FromResult(retorno > 0 ? true : false);
        }
    }
}
