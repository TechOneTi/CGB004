namespace CGB004.Data.Model.Config
{
    public class ApiParameter
    {
        public ApiParameter() { }

        public ApiParameter(string key, object value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public object Value { get; set; }
    }
}
