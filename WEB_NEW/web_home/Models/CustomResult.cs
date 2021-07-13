using System;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using web_home.Unitl;

namespace web_home.Models
{

    /// <summary>

    /// 自定义返回结果

    /// </summary>

    public class CustomResult : ActionResult
    {

        /// <summary>

        /// 当前响应HTTP MIME类型

        /// </summary>

        public string ContentType = "application/json";

        /// <summary>

        /// 当前响应的内容编码

        /// </summary>

        public Encoding ContentEncoding = Encoding.UTF8;

        /// <summary>

        /// 数据对象实体

        /// </summary>

        public object Data { get; set; }

        /// <summary>

        /// 使用通用结构返回结果对象

        /// </summary>

        public bool UseGeneralResult = true;

        /// <summary>

        /// 默认返回值 成功

        /// </summary>

        public bool Success = true;
        private string SKey { get; set; }
        private string Iv { get; set; }

        /// <summary>

        /// 执行返回结果

        /// </summary>

        /// <param name="context"></param>

        public override void ExecuteResult(ControllerContext context)

        {

            HttpResponseBase response = context.HttpContext.Response;

            response.ContentType = ContentType;

            response.ContentEncoding = ContentEncoding;

            response.Headers.Remove("Server");

            response.Headers.Remove("X-AspNet-Version");

            response.Headers.Remove("X-AspNetMvc-Version");

            response.Headers.Remove("X-Powered-By");

            var temp=context.Controller.TempData["SKey"];
            var temp2=context.Controller.TempData["Iv"];

            SKey = temp==null ? "" :temp.ToString();

            Iv = temp2 == null ? "" : temp2.ToString();

            string jsonStr = string.Empty;

            if (UseGeneralResult)

            {
                var result = new GeneralResult();

                if (Data is Exception){
                    result.SetException(((Exception)Data).Message, (Exception)Data);
                }else if (Data is GeneralResult)

                {
                    result = (GeneralResult)Data;
                }

                else if (!Success && Data is string)
                {
                    result.SetFail(Data.ToString());
                }

                else

                {
                    result.SetSuccess(Data);

                }
                if (result.Success && !string.IsNullOrWhiteSpace(SKey) && !string.IsNullOrWhiteSpace(Iv))
                {

                    var source = result.Data.Serializer();

                    var encode = AESEncryptUtils.AESEncrypt(source, SKey, Iv);

                    result.SetSuccess(encode);

                }
                jsonStr = result.Serializer();


            }

            else

            {

                jsonStr = Data.Serializer();

#if !DEBUG

                if (!string.IsNullOrWhiteSpace(SKey) && !string.IsNullOrWhiteSpace(Iv))

                {

                    jsonStr = AESEncryptUtils.EncryptByAES(jsonStr, SKey, Iv);

                }
#endif
            }

            response.Headers.Add("content-encoding", "gzip");

            using (var stream = new GZipStream(response.OutputStream, CompressionMode.Compress))

            {

                byte[] jsonBuffer = Encoding.UTF8.GetBytes(jsonStr);

                stream.Write(jsonBuffer, 0, jsonBuffer.Length);


  }
        }
    }

}