using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Model.API
{
    public class ConfigValues
    {
        public static string DBConntectionString = ConfigurationManager.AppSettings["DBConntectionString"];

        private const string entityStringThemplate = "metadata=res://*/Context.csdl|res://*/Context.ssdl|res://*/Context.msl;provider=System.Data.SqlClient;provider connection string=\"{0}\"";

        
        public static string EntityFrameworkConntectionString
        {
            get
            {
                return string.Format(entityStringThemplate, DBConntectionString);
            }
        }
    }
}
