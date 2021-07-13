using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web_home.Models;
using web_home.Unitl;

namespace web_home.BLL
{
    public class T_DownloadInfoBLL
    {
        public static DContext context = new DContext();
        /// <summary>
        /// 下载地址获取
        /// </summary>
        /// <param name="type"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        public GeneralResult<t_download_info> download(int type2, int platform)
        {
            var result = new GeneralResult<t_download_info>();
            var model = context.download_info.Where(p => p.platform == platform && p.type2 == type2 && p.status==1).ToList();
            result.SetSuccess(model, "成功");
            return result;
        }
    }
}