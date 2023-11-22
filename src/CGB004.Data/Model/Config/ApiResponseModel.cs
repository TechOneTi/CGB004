namespace CGB004.Data.Model.Config
{
    public class ApiResponseModel
    {
        public int StatusCode { get; set; }
        public string DataInical { get; set; }
        public string DataFinal { get; set; }
        public List<ResultadoModel> Resultado { get; set; }
        public int Pagina { get; set; }
        public int TotalPaginas { get; set; }
    }

    public class ResultadoModel
    {
        public string Empresa { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public List<DiasModel> Dias { get; set; }
    }
    public class DiasModel
    {
        public string Data { get; set; }
        public string Entrada { get; set; }
        public string Saida { get; set; }
        public string InicioIntervalo { get; set; }
        public string FimIntervalo { get; set; }
        public string Jornada { get; set; }
        public string Situacao { get; set; }
        public string TipoDia { get; set; }
        public string CodigoEscala { get; set; }
        public string DescricaoEscala { get; set; }
    }

}
