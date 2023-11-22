using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace CGB004.Data.Configuration
{
    public class EndPoint
    {
        public string URLMockNF { get; set; }
    }

    public class AppSettings
    {
        public EndPoint EndPoints { get; set; }

        public string Application { get; set; }

        public string ConfigMartins { get; set; }
        public string ConfigP01A { get; set; }
        public string ConfigMRTDSV01 { get; set; }

        public string PathLog { get; set; }
        public string NomePrograma { get; set; }
        public string URLMockNF { get; set; }

        public AppSettings(IConfiguration config)
        {
            ConfigMartins = config.GetValue<string>("ConnectionStrings:ConfigName");
            var jsonString = File.ReadAllText(ConfigMartins);
            var jsonDocument = JsonDocument.Parse(jsonString);
            var root = jsonDocument.RootElement;
            // Acesse as strings de conexões diretamente do JSON
            string connectionString = root.GetProperty("connectionstrings").GetProperty("MRTDSV").GetString();            
            ConfigMartins = connectionString;
            
            //connectionString = root.GetProperty("connectionstrings").GetProperty("P01A").GetString();            
            //ConfigP01A = connectionString;

            //connectionString = root.GetProperty("connectionstrings").GetProperty("MRTDSV").GetString();
            //ConfigMRTDSV01 = connectionString;

            NomePrograma = config.GetValue<string>("Application");
            PathLog = config.GetValue<string>("Logging:PathLog");

            URLMockNF = config.GetValue<string>("EndPoints:UrlMockNF");            
        }
    }
}
