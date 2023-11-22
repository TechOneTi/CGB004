namespace CGB004.Data.Model.Config
{
    public class APIDataResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int ResultCount { get; set; }
    }
    public class APIDataResponse<T> : APIDataResponse
    {
        public T Data { get; set; }
    }
}
