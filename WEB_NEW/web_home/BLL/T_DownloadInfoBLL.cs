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
        /// <param name="type2">类型 （1. APP  2 PC）</param>
        /// <param name="platform">平台编号</param>
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