using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IndygoClient.Models
{
    internal class ResponseInfo
    {
        public WebHeaderCollection Headers { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public static readonly ResponseInfo Empty = new ResponseInfo();
    }
}
