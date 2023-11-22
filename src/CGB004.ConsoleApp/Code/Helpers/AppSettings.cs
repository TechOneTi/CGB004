using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace TemplateApp.ConsoleApp
{
    /// <summary>
    /// AppSettings do sistema
    /// </summary>
    public class AppSettings
    {       

        #region ConnectionStrings

        private static string ConfigName { get; set; }

        public static string ConnectionStringMRT
        {
            get
            {
                try
                {
                    var jsonString = File.ReadAllText(ConfigName);
                    var jsonDocument = JsonDocument.Parse(jsonString);
                    var root = jsonDocument.RootElement;

                    // Acesse a string de conexão diretamente do JSON
                    string connectionString = root.GetProperty("connectionstrings").GetProperty("MRT001").GetString();
                    return connectionString;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Falha ao obter configuração do banco de dados. Erro: {0}", ex.Message));
                }
            }
        }

        #endregion

        /// <summary>
        /// Carregar as variáveis do appsettings para as constantes do sistema
        /// </summary>
        /// <param name="configuration">IConfiguration program</param>
        public static void LoadSettings(IConfiguration configuration)
        {
            // ConnectionStrings
            ConfigName = configuration.GetValue<string>("ConnectionStrings:ConfigName");
        }

    }
}
