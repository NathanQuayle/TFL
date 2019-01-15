using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TFL.ConsoleUI
{
    public interface IHttpResponseManager
    {
        Task<string> ConvertToString(HttpResponseMessage httpResponseMessage);
    }
}
