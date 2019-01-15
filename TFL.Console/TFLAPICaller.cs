using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TFL.ConsoleUI
{
    public class TFLAPICaller
    {
        private readonly IHttpClientHandler _httpClientHandler;
        private readonly IHttpResponseManager _httpResponseManager;
        public TFLAPICaller(IHttpClientHandler httpClientHandler, IHttpResponseManager httpResponseManager)
        {
            _httpClientHandler = httpClientHandler;
            _httpResponseManager = httpResponseManager;
        }

        public string GetDataAsString()
        {
            var dataAsTask = GetData();
            return dataAsTask.Result;
        }

        public async Task<string> GetData()
        {
            var response = await _httpClientHandler.GetAsync("https://api.tfl.gov.uk/Line/victoria/Status");
            var result = await _httpResponseManager.ConvertToString(response);
            return result;
        }
    }
}
