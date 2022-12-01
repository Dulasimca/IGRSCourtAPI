using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGRSCourtAPI.Common
{
    public class ApiResponse
    {
        public string Code
        {
            get;
            set;
        }
        public string Message
        {
            get;
            set;
        }
        public object? ResponseData
        {
            get;
            set;
        }
    }
    public enum ResponseType
    {
        Success = 1,
        Failure = 2,
        NotFound = 3

    }
 
}
