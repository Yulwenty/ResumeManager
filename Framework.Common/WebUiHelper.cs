using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Framework.Common
{
    public class WebUiHelper
    {
        public static HttpContext CurrentContext
        {
            get{return HttpContext.Current; }
            set {HttpContext.Current = value;}
        }
    }
}
