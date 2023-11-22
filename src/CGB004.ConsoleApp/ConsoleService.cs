using CGB004.Application.Interfaces;
using CGB004.ConsoleApp.Extensions;
using CGB004.Data.Code.Helpers;
using CGB004.Data.Model.Config;
using CGB004.Data.Model.Inconsistencia;
using CGB004.Data.Model.SAFX;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace CGB004.ConsoleApp
{
    public class ConsoleService : IHostedService
    {
        private readonly IHostApplicationLifetime _appLifeTime;
        private readonly ISAFXService _safxService;
        private readonly ILogApplicationService _logService;
        private readonly RequestInfo _requestInfo;
        private readonly IInconsistenciaService _inconsistenciaService;
        private EnumEtapas _enumEtapas;
        private string TipoExec = String.Empty;
        public ConsoleService(IHostApplicationLifetime appLifeTime, ISAFXService safxService, ILogApplicationService logService, RequestInfo requestInfo, IInconsistenciaService inconsistenciaService, IConfiguration configuration)
        {
            _appLifeTime = appLifeTime;
            _safxService = safxService;
            _logService = logService;
            _requestInfo = requestInfo;
            _inconsistenciaService = inconsistenciaService;
            // Pegando o valor do parametro de execução setado fixo no debug como 1
            TipoExec = configuration["TipoExec"];

        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifeTime.ApplicationStarted.Register(() =>
            {
                Int32 contador = 0;
                bool inseriuSAFX01 = false;
                bool inseriuSAFX02 = false;
                bool inseriuSAFX80 = false;
                bool inseriuSAFX2001 = false;
                bool inseriuSAFX2002 = false;
                bool inseriuSAFX2003 = false;
                _enumEtapas = EnumEtapas.TIPNOT;

                _logService.InicioProcesso();
                Task.Run(async () =>
                {
                    try
                    {
                        switch (TipoExec)
                        {
                            case "1":
                                //Setar o mock de dados para inserir na tabela SAFX01
                                SAFX01 objSAFX01 = new SAFX01();
                                inseriuSAFX01 = await _safxService.InserirSAFX01(objSAFX01);
                                if (inseriuSAFX01)
                                {
                                    _logService.AdicionarLinha("Inserido na tabela SAFX01");
                                }
                                break;                            
                            case "2":
                                //Setar aqui o mock de dados para inserir na tabela SAFX02
                                SAFX02 objSAFX02 = new SAFX02();
                                inseriuSAFX02 = await _safxService.InserirSAFX02(objSAFX02);
                                if (inseriuSAFX02)
                                {
                                    _logService.AdicionarLinha("Inserido an tabela SAFX02");
                                }
                                break;
                            case "80":
                                //Setar aqui o mock de dados para inserir na tabela SAFX80
                                SAFX80 objSAFX80 = new SAFX80();
                                inseriuSAFX80 = await _safxService.InserirSAFX80(objSAFX80);
                                if (inseriuSAFX80)
                                {
                                    _logService.AdicionarLinha("Inserido na tabela SAFX80");
                                }
                                break;
                            case "2001":
                                //Setar o mock de dados para inserir na tabela SAFX2001
                                SAFX2001 objSAFX2001 = new SAFX2001();
                                inseriuSAFX2001 = await _safxService.InserirSAFX2001(objSAFX2001);
                                if (inseriuSAFX2001)
                                {
                                    _logService.AdicionarLinha("Inserido na tabela SAFX2001");
                                }
                                break;
                            case "2002":
                                //Setar o mock de dados para inserir na tabela SAFX2002
                                SAFX2002 objSAFX2002 = new SAFX2002();
                                inseriuSAFX2002 = await _safxService.InserirSAFX2002(objSAFX2002);
                                if (inseriuSAFX2002)
                                {
                                    _logService.AdicionarLinha("Inserido na tabela SAFX2002");
                                }
                                break;
                            case "2003":
                                //Setar o mock de dados para inserir na tabela SAFX2003
                                SAFX2003 objSAFX2003 = new SAFX2003();
                                inseriuSAFX2003 = await _safxService.InserirSAFX2003(objSAFX2003);
                                if (inseriuSAFX2003)
                                {
                                    _logService.AdicionarLinha("Inserido na tabela SAFX2003");
                                }
                                break;                            
                        }

                        _logService.AdicionarLinha("------------------------------------------");
                        _logService.FimProcesso(); 
                    }
                    catch (Exception ex)
                    {
                        var requestJson = _requestInfo.JsonRequest;
                        _logService.AdicionarLinha($"ERRO:: Registro: {contador}  - ETAPA {EnumExtensions.GetDescriptionOrName(_enumEtapas) ?? string.Empty} ");
                        _logService.Salvar("Gravando a inconsistência na tabela MRT.MOVINTBXACMB");
                        var numseq = await _inconsistenciaService.BuscarInconsistencia();
                        InconsistenciaRequest request = new()
                        {
                            NUMSEQ = numseq,
                            CODEMP = 1,
                            CODFILEMP = 1,
                            DATLMT = DateTime.Now,
                            NUMCGCFRN = "96.560.256/0001-22",
                            NUMNOTFSC = 6000,
                            DATEMS = DateTime.Now,
                            DESORISLC = "MASTERSAF",
                            VLRPGT = 5000,
                            DESOBS = "Erro na etapa: " + EnumExtensions.GetDescriptionOrName(_enumEtapas) + ex.Message,
                            DESCDOITEJSN = requestJson
                        };
                        _=_inconsistenciaService.InserirInconsistencia(request);
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        _logService.Salvar("Fim");
                        _appLifeTime.StopApplication();
                    }
                });
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
