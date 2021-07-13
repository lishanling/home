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
    public class TDownloadInfoController : BaseController
    {
        [HttpPost]
        public ActionResult download(int type2,int platform)
        {
            T_DownloadInfoBLL s = new T_DownloadInfoBLL();
            var result = s.download(type2, platform);
            return JRestlt(result);
        }
    }
}