using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace RestApiAdMixer.ApiTool
{
    public class FetchTool
    {
        HttpClient client = new HttpClient();

        public T Fetch<T>(string url)
        {
            HttpResponseMessage responseMessage = client.GetAsync(url).GetAwaiter().GetResult();
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                var result = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return JsonConvert.DeserializeObject<T>(result);
            }
            else
            {
                throw new Exception("Couldn't get info");
            }


        }
    }
}
