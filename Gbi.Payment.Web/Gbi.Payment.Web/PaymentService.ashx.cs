﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gbi.Payment.Web
{
    /// <summary>
    /// Class PaymentService.
    /// </summary>
    public class PaymentService : IHttpHandler
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