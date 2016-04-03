using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CIandTAPI.Utils
{
    public class RestFullAcess<T> where T : class
    {

        public async Task<T> Get(string URL, string Metodo, string HttpVerb)
        {

            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync(URL + Metodo);

            var JsonResult = response.Content.ReadAsStringAsync().Result;

            var rootobject = JsonConvert.DeserializeObject<T>(JsonResult);

            return rootobject;
        }

        public async Task<bool> Post(T objeto, string URL, string Metodo)
        {
            try
            {

                var client = new System.Net.Http.HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(JsonConvert.SerializeObject(objeto));

                var response = await client.PostAsync(URL + Metodo, content);
                
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
