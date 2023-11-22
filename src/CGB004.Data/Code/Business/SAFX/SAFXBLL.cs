using CGB004.Data.Code.Interfaces;
using CGB004.Data.Model.SAFX;

namespace CGB004.Data.Code.Business.SAFX
{
    public class SAFXBLL : ISAFXBLL
    {
        private readonly ISAFXDAL _safxDAL;
        public SAFXBLL(ISAFXDAL safxDAL)
        {
            _safxDAL = safxDAL;
        }       

        public Task<bool> InserirSAFX01(SAFX01 objRow)
        {
            return _safxDAL.InserirSAFX01(objRow);
        }

        public Task<bool> InserirSAFX02(SAFX02 objRow)
        {
            return _safxDAL.InserirSAFX02(objRow);
        }

        public Task<bool> InserirSAFX80(SAFX80 objRow)
        {
            return _safxDAL.InserirSAFX80(objRow);
        }

        public Task<bool> InserirSAFX2001(SAFX2001 objRow)
        {
            return _safxDAL.InserirSAFX2001(objRow);
        }

        public Task<bool> InserirSAFX2002(SAFX2002 objRow)
        {
            return _safxDAL.InserirSAFX2002(objRow);
        }

        public Task<bool> InserirSAFX2003(SAFX2003 objRow)
        {
            return _safxDAL.InserirSAFX2003(objRow);
        }
    }
}
