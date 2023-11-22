using System.ComponentModel;

namespace CGB004.Data.Code.Helpers
{
    public enum EnumConexoes
    {
        [Description("MRT001")]
        MRT001 = 0,
        [Description("APP01A")]
        APP01A = 1,
        [Description("MRTDSV01")]
        MRTDSV = 2
    }

    public enum EnumEtapas
    {
        [Description("Validação Tipo Nota")]
        TIPNOT = 1,
        [Description("Validando Unidade de Negocio")]
        UNDNEG = 2,
        [Description("Validando Fornecedor")]
        FRN = 3,
        [Description("Validando Parâmetro de Contabilização")]
        PRMCTB = 4,
        [Description("Validando Parâmetro Integração Contábil")]
        PRMITGCTB = 5
    }
}
