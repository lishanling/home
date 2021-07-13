using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_home.Models
{
    public class PageTableResult
    {
        public int PageTotal {set { PageTotal= (int) (Total/PageSize)+(Total%PageSize!=0 ? 1:0);}}
        public int PageSize{get;set;}
        public int PageNo{get;set;}
        public Int64 Total{get;set;}
        public Object Table{get;set;}
    }
    public class PageTableResult<T> : PageTableResult
    {
        [JsonIgnore]
        public IEnumerable<T> Data;
    }
}