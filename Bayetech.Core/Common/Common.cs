﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Text;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Bayetech.Core
{
    public class Common
    {
        /// <summary>
        /// 获取客户端IP地址（无视代理）
        /// </summary>
        /// <returns>若失败则返回回送地址</returns>
        public static string GetHostAddress()
        {
            string userHostAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (string.IsNullOrEmpty(userHostAddress))
            {
                if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
                    userHostAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString().Split(',')[0].Trim();
            }
            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = HttpContext.Current.Request.UserHostAddress;
            }

            //最后判断获取是否成功， （检查其格式非常重要）
            if (!string.IsNullOrEmpty(userHostAddress) && IsIP(userHostAddress))
            {
                return userHostAddress;
            }
            return "127.0.0.1";
        }

        /// <summary>
        /// 检查IP地址格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        /// <summary>
        /// 带返回值异常处理的方法执行
        /// </summary>
        /// <param name="action">方法</param>
        /// <param name="ExceptionFunc">异常方法</param>
        /// <returns></returns>
        public static T AddTryCatch<T>(Func<T> func, Func<T> ExceptionFunc)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                //写日志
                //抛出
                if (ExceptionFunc != null)
                    return ExceptionFunc.Invoke();
                else
                    throw ex;
            }
            finally
            {

            }
        }

        /// <summary>
        /// 带返回值异常处理的方法执行
        /// </summary>
        /// <param name="action">方法</param>
        /// <param name="ExceptionFunc">异常方法</param>
        /// <returns></returns>
        public static T AddTryCatch<T>(Func<T> func, Action ExceptionFunc)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                //写日志
                //抛出
                ExceptionFunc?.BeginInvoke(null, null);
                throw ex;
            }
            finally
            {

            }
        }

        /// <summary>
        /// 带返回值异常处理的方法执行
        /// </summary>
        /// <param name="action">方法</param>
        /// <returns></returns>
        public static T AddTryCatch<T>(Func<T> func)
        {
            return AddTryCatch(func, null);
        }

        //写入操作的entity异常处理
        public static string ExceptionForWriteEntity(DbEntityValidationException ex)
        {
            StringBuilder errors = new StringBuilder();
            IEnumerable<DbEntityValidationResult> validationResult = ex.EntityValidationErrors;
            foreach (DbEntityValidationResult result in validationResult)
            {
                ICollection<DbValidationError> validationError = result.ValidationErrors;
                foreach (DbValidationError err in validationError)
                {
                    errors.Append(err.PropertyName + ":" + err.ErrorMessage + "\r\n");
                }
            }
            return errors.ToString();
        }


        /// <summary>
        /// 商品编号机制（18位）
        /// </summary>
        /// <returns></returns>
        public static string CreatGoodNo(string head)
        {
            try
            {
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString().PadLeft(2,'0');
                string day = DateTime.Now.Day.ToString().PadLeft(2, '0');
                string hour = DateTime.Now.Hour.ToString().PadLeft(2, '0');
                string min = DateTime.Now.Minute.ToString().PadLeft(2, '0');
                string second = DateTime.Now.Second.ToString().PadLeft(2, '0');
                Random ran = new Random();
                string wan = ran.Next(1, 9999).ToString().PadLeft(4, '0');
                string result = head + year + month + day + hour + min + second + wan;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "发生错误!");
            }   
        }



        /// <summary>
        /// 生成user（10位）
        /// </summary>
        /// <returns></returns>
        public static string CreatUser(string head)
        {
            try
            {
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString().PadLeft(2, '0');
                string second = DateTime.Now.Second.ToString().PadLeft(2, '0');
                Random ran = new Random();
                string wan = ran.Next(1, 9999).ToString().PadLeft(4, '0');
                string result = head + year + month + second + wan;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "发生错误!");
            }
        }

        /// <summary>
        /// 根据商品编号生成订单编号（22位）
        /// </summary>
        /// <param name="goodNo"></param>
        /// <returns></returns>
        public static string CreatOrderNo(string goodNo)
        {
            try
            {
                Random ran = new Random();
                string wan = ran.Next(1, 9999).ToString().PadLeft(4, '0');
                string result = goodNo + wan;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "发生错误!");
            }
        }

        /// <summary>
        /// trim方法增加null判断
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Trim(string str) => str == null ? "" : str.Trim();


        /// <summary>
        /// 打包返回的结果集
        /// </summary>
        /// <param name="bol"></param>
        /// <param name="result"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static JObject PackageJObect(bool bol,object result= null,Pagination page=null)
        {
            var jObect = new JObject();
            jObect.Add("result", bol);
            jObect.Add("content", JToken.FromObject(result));
            if (page != null)
            {
                jObect.Add("outpage", JToken.FromObject(page));//分页
            }
            return jObect;
        }

        /// <summary>
        /// IP地址转数字
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static long IpToInt(string ip)
        {
            char[] separator = new char[] { '.' };
            string[] items = ip.Split(separator);
            return long.Parse(items[0]) << 24
                    | long.Parse(items[1]) << 16
                    | long.Parse(items[2]) << 8
                    | long.Parse(items[3]);
        }


        /// <summary>
        /// 整数转换成IP地址
        /// </summary>
        /// <param name="ipInt"></param>
        /// <returns></returns>
        public static string IntToIp(long ipInt)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append((ipInt >> 24) & 0xFF).Append(".");
            sb.Append((ipInt >> 16) & 0xFF).Append(".");
            sb.Append((ipInt >> 8) & 0xFF).Append(".");
            sb.Append(ipInt & 0xFF);
            return sb.ToString();
        }

        /// <summary>
        /// 得到当前完整主机头
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentFullHost()
        {
            HttpRequest request = System.Web.HttpContext.Current.Request;
            if (!request.Url.IsDefaultPort)
                return string.Format("{0}:{1}", request.Url.Host, request.Url.Port.ToString());

            return request.Url.Host;
        }

       
    }
}
