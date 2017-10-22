using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Logger
{
    public class LogRequestContext : ILogRequestContext
    {
        public LogRequestContext(HttpRequestMessage request)
        {
            if (request != null)
            {
                UserId = GetUserIdStr(request);
                Version = GetHeader(request, "FApiVersion");
                UserAgent = GetHeader(request, "user-agent");
                byte apiAccId;
                if (byte.TryParse(GetHeader(request, "ApiAccount"), out apiAccId))
                {
                    ApiAccount = apiAccId;
                }
                URL = request.RequestUri.ToString();
            }
        }

        public byte? ApiAccount { get; set; }
        public string URL { get; set; }
        public string UserId { get; set; }
        public string UserAgent { get; set; }
        public string Version
        {
            get; set;
        }
        public byte? Site { get; } = 1;

        private static string GetUserIdStr(System.Net.Http.HttpRequestMessage request)
        {
            return GetHeader(request, "FUserId");
        }
        private static string GetHeader(System.Net.Http.HttpRequestMessage request, string headerName)
        {
            return request.Headers.Where(x => x.Key.ToUpper() == headerName.ToUpper()).Select(x => x.Value.FirstOrDefault()).FirstOrDefault();
        }
    }
}
