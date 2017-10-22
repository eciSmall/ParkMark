using ParkMark.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkMark.UI.Web.General
{
    public class WebUILogRequestContext : ILogRequestContext
    {
        public WebUILogRequestContext(HttpContextBase httpContext)
        {
            ApiAccount = null;
            //URL = httpContext?.Request?.Url?.ToString();
            //UserAgent = httpContext?.Request?.UserAgent;
            URL = "";
            UserAgent = "";
            Version = "1.1";
            //UserId = (SessionContext.GetCurrentUser()?.Id)?.ToString();
        }
        public byte? ApiAccount { get; set; }
        public string URL { get; set; }
        public string UserId { get; set; }
        public string UserAgent { get; set; }
        public string Version
        {
            get; set;
        }
        public byte? Site { get; } = 2;
    }
}