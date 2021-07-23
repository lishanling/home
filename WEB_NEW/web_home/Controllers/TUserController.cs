﻿using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_home.BLL;
using web_home.Models;
using web_home.Unitl;

namespace web_home.Controllers
{
    public class TUserController : BaseController
    {
        public static ILog logger = LogManager.GetLogger(typeof(T_UserBLL));
        [HttpPost]
        public ActionResult Register(string email, string password, int type, int platform, string phone, string code)
        {
            T_UserBLL s = new T_UserBLL();
            var t = new GeneralResult<t_user>();
            GeneralResult<t_user> result=new GeneralResult<t_user>();
            result = s.Register(email, password, type, platform, phone, code);
           
            return JRestlt(result);
        }
        /// <summary>
        /// 图形验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SecurityCode()
        {
            //string oldcode = TempData["SecurityCode"] as string;
            //string code = ValidataCode.CreateRandomCode(4); //验证码的字符为4个
            //TempData["SecurityCode"] = code; //验证码存放在TempData中
            Response.Cache.SetNoStore();//禁用缓存
            string code = ValidataCode.CreateRandomCode(4); //验证码的字符为4个
            Session["CheckCode"] = code;
            Response.Cookies.Add(new HttpCookie("CheckCode", code));
            return File(ValidataCode.CreateValidateGraphic(code), "image/Jpeg");
        }
    }
}