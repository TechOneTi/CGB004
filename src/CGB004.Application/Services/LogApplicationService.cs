using System.Text;
using CGB004.Application.Interfaces;
using CGB004.Data.Configuration;

namespace CGB004.Application.Services
{
    public class LogApplicationService : ILogApplicationService
    {
        private readonly AppSettings _appSettings;
        private readonly string _pathLog = string.Empty;        
        private readonly string _nomePrograma = string.Empty;
        private readonly string _descricaoPrograma = string.Empty;
        private readonly string _logFile = string.Empty;
        public LogApplicationService(AppSettings appSettings)
        {
            _appSettings = appSettings;
            _pathLog = _appSettings.PathLog;
            _nomePrograma = _appSettings.NomePrograma;
            _logFile = $"{_pathLog}{_nomePrograma}_{DateTime.Now:yyyyMMdd}.txt";
        }

        public void AdicionarLinha(string message="")
        {
            Console.WriteLine(" ");
            using (StreamWriter writer = new StreamWriter(_logFile, true))
            {
                writer.WriteLine(!String.IsNullOrWhiteSpace(message) ? message :  " ");
                writer.Close();
            }
        }       

        public void InicioProcesso()
        {
            
            if (!System.IO.Directory.Exists(_pathLog))
                System.IO.Directory.CreateDirectory(_pathLog);
            var header = new StringBuilder()
                .AppendLine("================================================================================================")
                .AppendLine($"INICIO DO PROGRAMA {_nomePrograma}: {DateTime.Now}")
                .AppendLine($"{_descricaoPrograma}")
                .ToString();
            Console.WriteLine(header);
            using (StreamWriter writer = new StreamWriter(_logFile, true))
            {
                writer.WriteLine(header);
                writer.Close();
            }
        }

        public void FimProcesso(bool erro = false)
        {
            var footer = $"Fim do Processo [{(erro ? "FALHA" : "SUCESSO")}]";
            AdicionarLinha("");
            Console.WriteLine(footer);
            using (StreamWriter writer = new StreamWriter(_logFile, true))
            {
                writer.WriteLine(footer);
                writer.Close();
            }
        }

        public void Salvar(string msg, bool erro = false)
        {
            var logMsg = $"{DateTime.Now} [{(erro ? "E" : "P")}] :: {msg}";
            Console.WriteLine(logMsg);
            using (StreamWriter writer = new StreamWriter(_logFile, true))
            {
                writer.WriteLine(logMsg);
                writer.Close();
            }
        }
    }
}
