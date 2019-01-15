using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TFL.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Result of API call:");
            var httpClientHandler = new HttpClientHandler();
            var httpResponseManager = new HttpResponseManager();
            TFLAPICaller tflAPICaller = new TFLAPICaller(httpClientHandler, httpResponseManager);
            var data = tflAPICaller.GetDataAsString();
            Console.WriteLine(data);
            Console.ReadLine();
        }

    }
}
