using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lym.Model.ApiResult
{
    [Serializable]
    public class DTReturnData
    {
        public int code { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
        public int count { get; set; }
    }
}
