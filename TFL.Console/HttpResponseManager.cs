using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TFL.ConsoleUI
{
    public class HttpResponseManager : IHttpResponseManager
    {
        public async Task<string> ConvertToString(HttpResponseMessage httpResponseMessage)
        {
            var result = await httpResponseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(result);
            return result;
        }
    }
}
