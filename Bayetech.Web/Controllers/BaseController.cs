﻿using Bayetech.Service;
using Newtonsoft.Json.Linq;
using Spring.Context;
using Spring.Context.Support;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;

namespace Bayetech.Web
{
    public class BaseController : ApiController
    {
        /// <summary>
        /// 创建spring容器上下文公共容器
        /// </summary>
        public static IApplicationContext ctx = ContextRegistry.GetContext();


        /// <summary>
        /// JObject
        /// </summary>
        /// <returns></returns>
        public static JObject CreatJObject(object content = null) {
            if (content == null)
            {
                return new JObject();
            }
            else
            {
                return new JObject(content);
            }
        }
    }
}
