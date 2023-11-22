using CGB004.Data.Model.Config;

namespace CGB004.Data.Code.Api
{
    public interface IApi
    {
        Resp Get<Resp>(string api, string routeMethod, List<ApiParameter> param = null, int timeout = 0);
    }
}
