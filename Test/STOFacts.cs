using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xunit;

namespace Test
{
    public class STOFacts
    {
        [Fact]
        public void GetSto()
        {
            using (var client = new HttpClient())
            {
                string url = "http://localhost:57907/STO/Index/43f905dbb760490495578669e32e88a8";
                var task = client.GetAsync(url);
                var responce = task.Result;
                if (responce.StatusCode == HttpStatusCode.OK)
                {
                    url = "OK";
                }
                Assert.Equal(url,"OK");
            }
        }

        [Fact]
        public void GetNoValidSto()
        {
            using (var client = new HttpClient())
            {
                string url = "http://localhost:57907/STO/Index/43f905dbb32e88a8";
                var task = client.GetAsync(url);
                var responce = task.Result;
                if (responce.StatusCode == HttpStatusCode.OK)
                {
                    url = "OK";
                }
                Assert.NotEqual(url, "OK");
            }
        }
    }
}
