using CGB004.Data.Model.Config;
using RestSharp;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace CGB004.Data.Code.Helpers
{
    public static class Util
    {
        /// <summary>
        /// Converte um objeto em um dicionário de dados
        /// </summary>
        public static List<ApiParameter> GetApiParameters<T>(T objeto)
        {
            return objeto.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .SelectMany(prop =>
                {
                    List<ApiParameter> parameters;
                    if (prop.PropertyType.IsArray)
                    {
                        parameters = new();
                        Array values = (Array)prop.GetValue(objeto, null);
                        for (int i = 0; i < values.Length; i++)
                            parameters.Add(new ApiParameter(prop.Name, values.GetValue(i)));
                    }
                    else
                        parameters = new List<ApiParameter> { new ApiParameter(prop.Name, prop.GetValue(objeto, null)) };

                    return parameters;
                })
                .ToList();
        }

        /// <summary>
        /// Recupera erro completo de uma exceção
        /// </summary>
        /// Rogério Siqueira
        public static string GetError(Exception ex)
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("Mensagem: {0}", ex.Message);
            if (ex.InnerException != null)
            {
                str.AppendLine("\nDetalhe Erro:");
                Exception subEx = ex.InnerException;
                while (subEx != null)
                {
                    str.AppendLine(subEx.Message);
                    subEx = subEx.InnerException;
                }
            }
            return str.ToString();
        }

        /// <summary>
        /// Recupera erro completo de uma api
        /// </summary>
        /// Rogério Siqueira
        public static string GetRestError(RestResponse response)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("Erro na comunicação com API");
            if (!string.IsNullOrWhiteSpace(response.Content))
                str.AppendLine("Content:").AppendLine(response.Content);
            if (!string.IsNullOrWhiteSpace(response.ErrorMessage))
                str.AppendLine("ErrorMessage:").AppendLine(response.ErrorMessage);
            return str.ToString();
        }

        /// <summary>
        /// Criar exceção para acesso expirado
        /// </summary>
        /// Rogério Siqueira
        public static Exception GetExpiredException()
        {
            Exception ex = new Exception();
            ex.Data.Add(HttpStatusCode.Unauthorized, "Acesso Expirado");
            return ex;
        }

        /// <summary>
        /// Criar exceção para acesso expirado
        /// </summary>
        /// Rogério Siqueira
        public static Exception GetNotFoundException()
        {
            Exception ex = new Exception("NOT FOUND - método REST não encontrado");
            ex.Data.Add(HttpStatusCode.NotFound, "Dados não Encontrados");
            return ex;
        }        
    }
}
