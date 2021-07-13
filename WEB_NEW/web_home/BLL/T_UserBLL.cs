using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web_home.Unitl;

namespace web_home.BLL
{
    public class T_UserBLL
    {
        public static DContext context = new DContext();
        public static IRedisClient Redis = RedisManager.GetClient();
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="uaccount"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string login(string uaccount, string password)
        {
            password = Tool.MD5Encrypt16(password);
            var model=context.t_user.Where(p => p.uaccount == uaccount && p.password == password).FirstOrDefault();
            if (model == null)
            {
                return "账户或密码错误";
            }
            else
            {
               //判断密码是否正确 ，将密码重新加密一次，与之前进行比对
               model.token= Guid.NewGuid().ToString();
               TimeSpan ts = new TimeSpan(0, 5, 0);//设置过期时间为五分钟
               Redis.Set("UserInfo:" + model.uid, model.token,ts);
               context.SaveChanges();
               return "成功";
            }
        }
    }
}