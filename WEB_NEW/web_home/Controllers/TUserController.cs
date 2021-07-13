using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_home.BLL;

namespace web_home.Controllers
{
    public class TUserController : BaseController
    {
         [HttpPost]
        public ActionResult login(string uaccount,string password)
        {
            T_UserBLL s = new T_UserBLL();
            var result=s.login(uaccount, password);
            if (result == "成功")
            {
                return JRestlt(result);
            }
            else
            {
              //  return Fai
            }
             
        }
    }
}