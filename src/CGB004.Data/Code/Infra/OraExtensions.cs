using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CGB004.Data.Code.Infra
{
    /// <summary>
    /// Classe padrão de extensões.
    /// </summary>
    public static class Extensions
    {

        /// <summary>
        /// Cria uma lista do tipo informado.
        /// </summary>
        /// <typeparam name="T">Tipo da lista.</typeparam>
        /// <param name="oraCommand">Comando de execução SQL oracle.</param>
        /// <param name="closeConnection">Fecha a conexão após o uso.</param>
        /// <returns>Lista do Tipo informado.</returns>
        public static List<T> ExecuteList<T>(this OracleCommand oraCommand, bool closeConnection = true)
        {
            using IDataReader reader = oraCommand.ExecuteReader();
            List<T> items = new(); List<string> cols = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();
            PropertyInfo[] props = typeof(T).GetProperties();
            while (reader.Read())
            {
                T item = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in props)
                    if (cols.Contains(prop.Name) && prop.CanWrite)
                        if (reader[prop.Name] is object value && value != null && value != DBNull.Value)
                        {
                            if (prop.PropertyType != value.GetType())
                            {
                                if (Nullable.GetUnderlyingType(prop.PropertyType) is Type underType && underType != null)
                                    prop.SetValue(item, Convert.ChangeType(value, underType));
                                else
                                    prop.SetValue(item, Convert.ChangeType(value, prop.PropertyType));
                            }
                            else
                                prop.SetValue(item, value);
                        }
                items.Add(item);
            }
            if (closeConnection) oraCommand.Connection.Close();
            return items;
        }

        /// <summary>
        /// Cria uma lista do tipo informado.
        /// </summary>
        /// <typeparam name="T">Tipo da lista.</typeparam>
        /// <param name="oraCommand">Comando de execução SQL oracle.</param>
        /// <param name="closeConnection">Fecha a conexão após o uso.</param>
        /// <returns>Lista do Tipo informado.</returns>
        public static async Task<List<T>> ExecuteListAsync<T>(this OracleCommand oraCommand, bool closeConnection = true)
        {
            using IDataReader reader = await oraCommand.ExecuteReaderAsync();
            List<T> items = new(); List<string> cols = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();
            PropertyInfo[] props = typeof(T).GetProperties();
            while (reader.Read())
            {
                T item = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in props)
                    if (cols.Contains(prop.Name) && prop.CanWrite)
                        if (reader[prop.Name] is object value && value != null && value != DBNull.Value)
                        {
                            if (prop.PropertyType != value.GetType())
                            {
                                if (Nullable.GetUnderlyingType(prop.PropertyType) is Type underType && underType != null)
                                    prop.SetValue(item, Convert.ChangeType(value, underType));
                                else
                                    prop.SetValue(item, Convert.ChangeType(value, prop.PropertyType));
                            }
                            else
                                prop.SetValue(item, value);
                        }
                items.Add(item);
            }
            if (closeConnection) oraCommand.Connection.Close();
            return items;
        }

        /// <summary>
        /// Define a query ao comando Oracle.
        /// (Limpa o conteúdo antigo do comando)
        /// </summary>
        /// <param name="oraCommand">Comando de execução SQL oracle.</param>
        /// <param name="cmdText">Instrução SQL.</param>
        /// <param name="arrayBindCount">Quantidade de itens no array de parâmentros.</param>
        /// <param name="bindByName">Adicionar parâmetro por nome ou posição.</param>
        /// <param name="cmdType">Tipo da Instrução SQL.</param>
        /// <returns>Commando Oracle.</returns>
        public static OracleCommand UseQuery(this OracleCommand oraCommand, string cmdText, int? arrayBindCount = null, bool bindByName = true, CommandType cmdType = CommandType.Text)
        {
            if (oraCommand.Parameters.Count > 0)
                oraCommand.Parameters.Clear();
            oraCommand.CommandText = cmdText;
            oraCommand.CommandType = cmdType;
            oraCommand.ArrayBindCount = arrayBindCount ?? default;
            oraCommand.BindByName = bindByName;
            return oraCommand;
        }

        /// <summary>
        /// Adiciona um parâmetro no comando Oracle.
        /// </summary>
        /// <param name="oraCommand">Comando de execução SQL oracle.</param>
        /// <param name="paramName">Nome do parâmetro.</param>
        /// <param name="paramValue">Valor do parâmetro.</param>
        /// <returns>Commando Oracle.</returns>
        public static OracleCommand AddParameter(this OracleCommand oraCommand, string paramName, object paramValue)
        {
            OracleParameter param = oraCommand.CreateParameter();
            param.ParameterName = paramName;
            param.Value = paramValue ?? DBNull.Value;
            oraCommand.Parameters.Add(param);
            return oraCommand;
        }

        /// <summary>
        /// Adiciona uma sequêcia de parâmetros no comando Oracle.
        /// </summary>
        /// <param name="oraCommand">Comando de execução SQL oracle.</param>
        /// <param name="paramName">Nome do parâmetro.</param>
        /// <param name="paramValues">Valores do parâmetro.</param>
        /// <returns>Commando Oracle.</returns>
        public static OracleCommand AddParameters<T>(this OracleCommand oraCommand, string paramName, IEnumerable<T> paramValues)
        {
            foreach (T paramValue in paramValues)
                oraCommand.AddParameter(paramName, paramValue);
            return oraCommand;
        }

        /// <summary>
        /// Adiciona um parâmetro no comando Oracle com uma condição.
        /// </summary>
        /// <param name="oraCommand">Comando de execução SQL oracle.</param>
        /// <param name="paramName">Nome do parâmetro.</param>
        /// <param name="paramValue">Valor do parâmetro.</param>
        /// <param name="coditionToAdd">Condição para adicionar.</param>
        /// <returns>Commando Oracle.</returns>
        public static OracleCommand AddParameter(this OracleCommand oraCommand, string paramName, object paramValue, bool coditionToAdd)
        {
            if (coditionToAdd) oraCommand.AddParameter(paramName, paramValue);
            return oraCommand;
        }

        /// <summary>
        /// Adiciona um parâmetro no comando Oracle repedido.
        /// </summary>
        /// <param name="oraCommand">Comando de execução SQL oracle.</param>
        /// <param name="paramName">Nome do parâmetro.</param>
        /// <param name="paramValue">Valor do parâmetro.</param>
        /// <param name="bindCount">Quantidade de vezes.</param>
        /// <returns>Commando Oracle.</returns>
        public static OracleCommand AddParameter(this OracleCommand oraCommand, string paramName, object paramValue, int bindCount)
        {
            for (int i = 0; i < bindCount; i++)
                oraCommand.AddParameter(paramName, paramValue);
            return oraCommand;
        }

        /// <summary>
        /// Adiciona um array de parâmetros no comando Oracle.
        /// </summary>
        /// <param name="oraCommand">Comando de execução SQL oracle.</param>
        /// <param name="paramName">Nome do parâmetro.</param>
        /// <param name="paramValue">Valor do parâmetro.</param>
        /// <param name="statusValue">Status do parâmetro.</param>
        /// <returns>Commando Oracle.</returns>
        public static OracleCommand AddParameterArray(this OracleCommand oraCommand, string paramName, object paramValue, OracleParameterStatus[] statusValue = null)
        {
            OracleParameter param = oraCommand.CreateParameter();
            if (paramValue == null)
                param.Value = DBNull.Value;
            else
            {
                if (statusValue != null)
                    param.ArrayBindStatus = statusValue;
                param.Value = paramValue;
            }
            oraCommand.Parameters.Add(param);
            return oraCommand;
        }

        /// <summary>
        /// Adiciona um modelo no comando Oracle.
        /// </summary>
        /// <param name="oraCommand">Comando de execução SQL oracle.</param>
        /// <param name="model">Modelo.</param>
        /// <returns>Commando Oracle.</returns>
        public static OracleCommand AddModel<T>(this OracleCommand oraCommand, T model)
        {
            Regex regex = new(@"(?<param>:\w*)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(oraCommand.CommandText);
            Type type = model.GetType();
            foreach (Match match in matches)
            {
                PropertyInfo prop = type.GetProperty(match.Value.Remove(0, 1));
                if (prop != null)
                    oraCommand.AddParameter(prop.Name, prop.GetValue(model));
            }
            return oraCommand;
        }

        /// <summary>
        /// Executa uma declaração SQL em um objeto de conexão e fecha a conexão.
        /// </summary>
        /// <param name="oraCommand">Comando de execução SQL oracle.</param>
        /// <returns>Numero de linhas afetadas.</returns>
        public static int ExecuteNonQueryEnd(this OracleCommand oraCommand)
        {
            int result = oraCommand.ExecuteNonQuery();
            oraCommand.Connection.Close();
            return result;
        }

        /// <summary>
        /// Obtem a primeira coluna da primeira linha do resultado select e fecha a conexão.
        /// </summary>
        /// <param name="oraCommand">Comando de execução SQL oracle.</param>
        /// <returns>Primeira linha da primeira coluna.</returns>
        public static object ExecuteScalarEnd(this OracleCommand oraCommand)
        {
            object result = oraCommand.ExecuteScalar();
            oraCommand.Connection.Close();
            return result;
        }

        /// <summary>
        /// Retornar um enumerable convertido para array primitivo
        /// </summary>
        /// <typeparam name="TSource">TSource</typeparam>
        /// <typeparam name="TResult">TResult</typeparam>
        /// <param name="source">source</param>
        /// <param name="selector">selector</param>
        /// <returns>Array</returns>
        public static TResult[] SelectArray<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return source.Select(selector).ToArray();
        }

        /// <summary>
        /// Retornar um enumerable convertido em OracleParameterStatus
        /// </summary>
        /// <typeparam name="TSource">TSource</typeparam>
        /// <typeparam name="TResult">TResult</typeparam>
        /// <param name="source">source</param>
        /// <param name="selector">selector</param>
        /// <returns>OracleParameterStatus Array</returns>
        public static OracleParameterStatus[] SelectOracleStatus<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            List<OracleParameterStatus> oracleParameters = new();
            foreach (TSource item in source)
            {
                oracleParameters.Add(
                    selector(item) == null
                    ? OracleParameterStatus.NullInsert
                    : OracleParameterStatus.Success
                );
            }
            return oracleParameters.ToArray();
        }
    }
}
