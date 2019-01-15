using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace TFL.ConsoleUI.Tests
{
    [TestFixture()]
    class TFLAPICallerTest
    {
        [Test()]
        public void GetDataGetsData()
        {

            var mockHttpClientHandler = new Mock<IHttpClientHandler>();
            var mockHttpResponseManager = new Mock<IHttpResponseManager>();

            var mockHttpResponseMessage = new HttpResponseMessage();
         
            var mockHttpResponseMessageTask = Task.FromResult(mockHttpResponseMessage);
            var expected = Task.FromResult("test content");
            mockHttpResponseManager.Setup(x => x.ConvertToString(mockHttpResponseMessage)).Returns(expected);

            mockHttpClientHandler.Setup(x => x.GetAsync("https://api.tfl.gov.uk/Line/victoria/Status")).Returns(mockHttpResponseMessageTask);
            var tflAPICaller = new TFLAPICaller(mockHttpClientHandler.Object, mockHttpResponseManager.Object);

            // Act
            var actual = tflAPICaller.GetData();

            // Assert
            Assert.AreEqual(expected.Result, actual.Result);
        }




    }
}
