using CGB004.Application.Interfaces;
using CGB004.Data.Code.Interfaces;
using CGB004.Data.Configuration;
using CGB004.Data.Model.SAFX;

namespace CGB004.Application.Services
{
    public class SAFXService : ISAFXService
    {
        private readonly AppSettings _appSettings;
        private readonly ISAFXBLL _safxBLL;
        

        public SAFXService(AppSettings appSettings, ISAFXBLL safxBLL)
        {
            _appSettings = appSettings;
            _safxBLL = safxBLL;            
        }

        public Task<bool> InserirSAFX01(SAFX01 objRow)
        {
            return _safxBLL.InserirSAFX01(objRow);
        }

        public Task<bool> InserirSAFX02(SAFX02 objRow)
        {
            return _safxBLL.InserirSAFX02(objRow);
        }

        public Task<bool> InserirSAFX2001(SAFX2001 objRow)
        {
            return _safxBLL.InserirSAFX2001(objRow);
        }

        public Task<bool> InserirSAFX2002(SAFX2002 objRow)
        {
            return _safxBLL.InserirSAFX2002(objRow);
        }

        public Task<bool> InserirSAFX2003(SAFX2003 objRow)
        {
            return _safxBLL.InserirSAFX2003(objRow);
        }

        public Task<bool> InserirSAFX80(SAFX80 objRow)
        {
            return _safxBLL.InserirSAFX80(objRow);
        }
    }
}
