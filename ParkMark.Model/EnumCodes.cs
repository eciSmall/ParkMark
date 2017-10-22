using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Model
{
    public enum ResponseStatus
    {
        Unknown = 0,
        Success = 1,
        InternalError = 2,
        DuplicateObject = 3,
        NotExist = 4,
        AccessDenied = 5,
    }
}
