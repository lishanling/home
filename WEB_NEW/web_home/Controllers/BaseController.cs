using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_home.BLL;
using web_home.Models;
using web_home.Unitl;
using WebGrease;
using ServiceStack.Redis;

namespace web_home.Controllers
{
     [Obsolete]
    public partial class BaseController : Controller
    {
        public static IRedisClient Redis = RedisManager.GetClient();
        protected virtual CustomResult JRestlt(Object Data)
        {
            return new CustomResult { Data = Data };
        }
        [AllowAnonymous]
        public ActionResult ValidateCode()
        {
            var url = Url.Action("CreateValidataCode", "Base", new { t = DateTime.Now.ToString("yyyyMMddHHssmmff") });
            return JRestlt(new { ImgUrl = url });
        }
        public ActionResult CreateValidataCode()
        {
            var validatacode = new ValidateCodeUtils();
            var code=validatacode.CreateRandomCode(4).ToLower();
            Redis.Set(code, code, new TimeSpan(5));
            var img = validatacode.CreateImage(code);
            return File(img,"image/gif");
        }
    }
}