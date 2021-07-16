using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web_home.Models;
using web_home.Unitl;

namespace web_home.BLL
{
    public class T_UserBLL
    {
        public static DContext context = new DContext();
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="type"> 注册方式(1:手机号注册  2 邮箱注册)</param>
        /// <param name="platform"></param>
        /// <param name="phone"></param>
        /// <param name="code">推荐码</param>
        /// <returns></returns>
        public GeneralResult<t_user> Register(string email, string password, int type, int platform, string phone, string code)
        {
            
            password = Tool.MD5Encrypt16(password);//将密码加密 MD5算法
            var result = new GeneralResult<t_user>();
            var model = context.t_user.Where(p => p.email == (email == null ? null : email.ToString()) && p.password == password && p.type == type && p.phone == (phone == null ? null : phone.ToString()) && p.platform == platform).FirstOrDefault();
            if (model != null)
            {
                result.SetFail("注册失败，该账户已经注册过了!");
            }
            else
            {
                var user = new t_user { platform = platform, phone = (phone == null ? null : phone.ToString()), type = type, password = password, email = (email == null ? null : email.ToString()), updateTime=DateTime.Now, code = (code==null ? null :code.ToString()) };
                context.t_user.Add(user);
                context.SaveChanges();
                result.SetSuccess(user, "成功");
            }
            return result;
        }
    }
}