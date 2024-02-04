using System.Net.Http.Headers;

namespace YUJCSR.Web.CSO.Helper
{
    public static class CommonAPIHelper
    {
        public static string GetApiData(string _baseurl, string methodName)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(_baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var getData = client.GetAsync(methodName);
                getData.Wait();
                var Res = getData.Result;
                if (Res.IsSuccessStatusCode)
                {
                    return Res.Content.ReadAsStringAsync().Result;
                }
            }

            return null;
        }
    }
}
