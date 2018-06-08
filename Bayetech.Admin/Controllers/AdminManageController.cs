﻿using Bayetech.Service;
using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;

namespace Bayetech.Admin.Controllers
{
    public class AdminManageController : BaseController
    {
        IAdminManageService adminManageService = ctx.GetObject("AdminManageService") as IAdminManageService;
        /// <summary>
        /// 获取管理员员工列表与角色列表
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpPost]
        public JObject GetList(JObject json)
        {
            try
            {
                return adminManageService.GetUserList(json,null,null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 添加与修改员工
        /// </summary>
        /// <param name="json">员工信息</param>
        /// <returns></returns>
        [HttpPost]
       public JObject UserAdd(JObject json)
       {
            try
            {
                return adminManageService.AddUser(json, 0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
