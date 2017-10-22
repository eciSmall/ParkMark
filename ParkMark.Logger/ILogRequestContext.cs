using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Logger
{
    public interface ILogRequestContext
    {
        byte? ApiAccount { get; }
        string URL { get; }
        string UserId { get; }
        string UserAgent { get; }
        string Version { get; }
        byte? Site { get; }
    }
}
