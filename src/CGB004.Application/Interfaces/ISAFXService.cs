using CGB004.Data.Model.SAFX;

namespace CGB004.Application.Interfaces
{
    public interface ISAFXService
    {
        Task<bool> InserirSAFX01(SAFX01 objRow);
        Task<bool> InserirSAFX02(SAFX02 objRow);
        Task<bool> InserirSAFX80(SAFX80 objRow);
        Task<bool> InserirSAFX2001(SAFX2001 objRow);
        Task<bool> InserirSAFX2002(SAFX2002 objRow);
        Task<bool> InserirSAFX2003(SAFX2003 objRow);
    }
}
