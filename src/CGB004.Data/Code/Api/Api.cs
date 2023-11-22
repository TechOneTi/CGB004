using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using CGB004.Data.Code.Helpers;
using CGB004.Data.Model.Config;


namespace CGB004.Data.Code.Api
{
    public class Api: IApi
    {
        private readonly HttpClient _client;
        private readonly RequestInfo _requestInfo;

        public Api(RequestInfo requestInfo)
        {
            _client = new HttpClient();
            _requestInfo=requestInfo;
        }


        /// <summary>
        /// Rest GET Method
        /// </summary>
        /// <typeparam name="Resp">Generics</typeparam>
        /// <param name="api">Api route</param>
        /// <param name="routeMethod">Method route</param>
        /// <param name="param">Dictionary paramêters</param>
        /// <param name="oauth">Auth</param>
        /// <param name="timeout">Timeout</param>
        /// <returns>Generics result</returns>
        public Resp Get<Resp>(string api, string routeMethod, List<ApiParameter> param = null, int timeout = 0)
        {
            try
            {
                RestRequest request = new RestRequest($"{api}", Method.Get)                    
                    .AddHeader("cache-control", "no-cache")
                    .AddHeader("Content-Type", "application/json");

                if (timeout > 0)
                    request.Timeout = timeout;
                if (param != null)
                    foreach (var item in param)
                        request.AddParameter(item.Key, item.Value, ParameterType.QueryString);

                // Criar um objeto anônimo que representa os parâmetros da URL
                var queryParams = request.Parameters
                    .Where(p => p.Type == ParameterType.QueryString)
                    .ToDictionary(p => p.Name, p => p.Value);

                // Serializar o objeto de parâmetros da URL em JSON
                string jsonRequest = JsonConvert.SerializeObject(queryParams);
                _requestInfo.JsonRequest = jsonRequest;

                RestResponse response = new RestClient(new RestClientOptions { ThrowOnAnyError = false }).ExecuteAsync(request).GetAwaiter().GetResult();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    try
                    {
                        APIDataResponse<Resp> dataResponse = JsonConvert.DeserializeObject<APIDataResponse<Resp>>(response.Content);
                        return dataResponse.Data;
                    }
                    catch (Exception ex)
                    {
                        return JsonConvert.DeserializeObject<Resp>(response.Content);
                    }
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                    throw Util.GetExpiredException();
                else if (response.StatusCode == HttpStatusCode.NotFound)
                    throw Util.GetNotFoundException();
                else
                    throw new Exception(Util.GetRestError(response));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO NA COMUNICAÇÃO COM API - {ex.Message}");
                throw;
            }
        }
    }
}
