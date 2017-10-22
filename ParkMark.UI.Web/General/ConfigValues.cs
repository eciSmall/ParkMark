using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ParkMark.UI.Web.General
{
    public class ConfigValues
    {
        internal static string ApiUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
    }
}