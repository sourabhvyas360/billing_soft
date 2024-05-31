using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Billing_Software
{
    /// <summary>
    /// Summary description for pdfdocashx
    /// </summary>
    public class pdfdocashx : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}