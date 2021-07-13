using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Configuration;

namespace web_home.Unitl
{

    public class AppSettingUtils
    {
        /// <summary>
        /// 读取配置文件键值对
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string GetString(string key, string defaultValue = "")
        {
            //ConfigurationManager.AppSettings.AllKeys.
            var obj = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrWhiteSpace(obj))
            {
                return defaultValue;
            }
            return obj;
        }

        public static bool GetBoolean(string key, bool value = false)
        {
            var obj = GetString(key, value.ToString());
            bool boolean = false;
            if (bool.TryParse(obj, out  boolean))
            {
                return boolean;
            }
            return value;
        }


        public static Int32 GetInt(string key, int value = 0)
        {
            var obj = GetString(key, value.ToString());
            int r = 0;
            if (Int32.TryParse(obj, out r))
            {
                return r;
            }
            return value;
        }

        /// <summary>
        /// 读取Web.Config 中自定义配置节点信息
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static NameValueCollection GetSection(string sectionName)
        {
            var logConfig = (NameValueCollection)ConfigurationManager.GetSection(sectionName);
            if (null == logConfig)
            {
              //  Logger.Warn("读取自定义配置失败：web.config 中未找到 " + sectionName + " 配置节点");
                return null;
            }
            return logConfig;
        }
    }

    /// <summary>
    /// 读取配置项方法扩展类
    /// </summary>
    public static class AppSettingUtilsExtension
    {
        /// <summary>
        /// 读取自定义配置节点下的配置项名称
        /// </summary>
        /// <param name="section">配置节点</param>
        /// <param name="key">配置项名称</param>
        /// <param name="defaultValue">默认值，默认为空字符串</param>
        /// <returns></returns>
        public static string GetString(this NameValueCollection section, string key, string defaultValue = "")
        {
            //ConfigurationManager.AppSettings.AllKeys.
            var obj = section[key];
            if (string.IsNullOrWhiteSpace(obj))
            {
                return defaultValue;
            }
            return obj;
        }
        /// <summary>
        /// 读取自定义配置节点下的配置项名称
        /// </summary>
        /// <param name="section">配置节点</param>
        /// <param name="key">配置项名称</param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool GetBoolean(this NameValueCollection section, string key, bool value = false)
        {
            var obj = section[key];
            bool boolean=false;
            if (bool.TryParse(obj, out boolean))
            {
                return boolean;
            }
            return value;
        }

        /// <summary>
        /// 读取自定义配置节点下的配置项名称
        /// </summary>
        /// <param name="section">配置节点</param>
        /// <param name="key">配置项名称</param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Int32 GetInt(this NameValueCollection section, string key, int value = 0)
        {
            var obj = section[key];
            int r=0;
            if (Int32.TryParse(obj, out r))
            {
                return r;
            }
            return value;
        }
    }
}