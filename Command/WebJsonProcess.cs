using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Edit_Info.Command
{
    public class WebJsonProcess
    {
        public T tryParseJson<T>(string json) where T : class, new()
        {
            T value = new T();
            try
            {
                value = JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex) { }

            return value;
        }

        public string tryToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public HttpResponseMessage sendRequest(string method, object obj, string url, out string json)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = new HttpResponseMessage();
                json = null;
                try
                {
                    var _method = new HttpMethod(method);
                    HttpRequestMessage rq = new HttpRequestMessage(_method, url);
                    rq.Content = obj != null ? new StringContent(obj.ToString(), Encoding.UTF8, "application/json") : null;
                    response = client.SendAsync(rq).Result;
                    json = response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception) { }
                return response;
            }
        }

        public async Task<HttpResponseMessage> sendRequestAsync(string method, object obj, string url)
        {
            using (HttpClient client = new HttpClient())
            {
                //HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    var _method = new HttpMethod(method);
                    HttpRequestMessage rq = new HttpRequestMessage(_method, url);
                    rq.Content = obj != null ? new StringContent(obj.ToString(), Encoding.UTF8, "application/json") : null;
                    return await client.SendAsync(rq);
                }
                catch (Exception) { return new HttpResponseMessage(); }
            }
        }

        public JObject ConvertToJObject(object obj)
        {
            return JObject.FromObject(obj);
        }

        public JArray ConvertToJArrayNoTitle(List<object> objs)
        {
            var listJArray = new JArray();
            foreach (var obj in objs)
            {
                listJArray.Add(ConvertToJObject(obj));
            }
            return listJArray;
        }

        public JArray ConvertToJArrayNoTitle(ObservableCollection<object> objs)
        {
            var listJArray = new JArray();
            foreach (var obj in objs)
            {
                listJArray.Add(ConvertToJObject(obj));
            }
            return listJArray;
        }
    }
}
