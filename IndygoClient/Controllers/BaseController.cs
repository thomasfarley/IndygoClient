using IndygoClient.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndygoClient.Controllers
{
    internal abstract class BaseController
    {
        protected string apiUrl = "http://localhost:59641/api/";
        protected NetworkHandler networkHandler;

        internal BaseController()
        {
            networkHandler = new NetworkHandler();
        }
    }
}
