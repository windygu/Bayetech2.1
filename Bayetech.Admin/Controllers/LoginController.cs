﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bayetech.Admin.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public string Login(JObject json) {
            return string.Empty;
        }
    }
}
