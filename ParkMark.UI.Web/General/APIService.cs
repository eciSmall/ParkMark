using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace ParkMark.UI.Web.General
{
    public class APIService<TEnum> where TEnum : struct, IConvertible
    {
        private static string CurrentSessionId;
        private static string APIUsername = ConfigurationManager.AppSettings["APIUsername"];
        private static string APIPassword = ConfigurationManager.AppSettings["APIPassword"];
        public APIService()
        {

        }
        private string Url(TEnum controller, string action)
        {
            var slashAction = (string.IsNullOrWhiteSpace(action) ? "" : ("/" + action));
            return string.Format("{0}{1}{2}", ConfigValues.ApiUrl, controller, slashAction);
        }
        private string Url<T>(TEnum controller, T content, string action)
        {
            var param = "value=" + Newtonsoft.Json.JsonConvert.SerializeObject(content);
            return string.Format("{0}?{1}", Url(controller, action), param);
        }
        public TResult Call<TResult>(TEnum controller, string actionName)
        {
            try
            {
                string url;
                HttpResponseMessage task;
                url = Url(controller, actionName);
                var client = getClient(controller);
                task = client.GetAsync(url).Result;
                keepResultSessionId(task, controller);
                var result = task.Content.ReadAsStringAsync().Result;
                return Newtonsoft.Json.JsonConvert.DeserializeObject<TResult>(result);
            }
            catch (Exception ex)
            {
                return default(TResult);
            }
        }

        public TResult Call<T, TResult>(TEnum controller, HttpMethod method, T content)
        {
            return Call<T, TResult>(controller, null, method, content);
        }
        public TResult Call<T, TResult>(TEnum controller, string actionName, HttpMethod method, T content)
        {
            string url;
            HttpResponseMessage task;
            if (method == HttpMethod.Get && content != null)
            {
                url = Url<T>(controller, content, actionName);
            }
            else
            {
                url = Url(controller, actionName);
            }
            var client = getClient(controller);
            client.Timeout = new TimeSpan(0, 4, 0);
            if (method != HttpMethod.Get)
            {
                var reqTest = JsonConvert.SerializeObject(content);

                var requestMsg = new HttpRequestMessage
                {
                    Content = new StringContent(reqTest, Encoding.UTF8, "application/json"),
                    Method = method,
                    RequestUri = new Uri(url)
                };
                task = client.SendAsync(requestMsg).Result;
            }
            else
            {
                task = client.GetAsync(url).Result;
            }
            keepResultSessionId(task, controller);
            var result = task.Content.ReadAsStringAsync().Result;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TResult>(result);
        }
        private void keepResultSessionId(HttpResponseMessage task, TEnum controller)
        {
            var sessionId = task.Headers.Where(x => x.Key == "FSession").Select(x => x.Value.FirstOrDefault()).FirstOrDefault();
            {
                CurrentSessionId = sessionId;
            }
        }

        private HttpClient getClient(TEnum controller)
        {
            var client = new HttpClient();
            {
                client.DefaultRequestHeaders.Add("FSession", CurrentSessionId);
                client.DefaultRequestHeaders.Add("FUser", APIUsername);
                client.DefaultRequestHeaders.Add("FPass", APIPassword);
            }

            client.DefaultRequestHeaders.Add("FApiVersion", "1.1");
            return client;
        }
    }
}