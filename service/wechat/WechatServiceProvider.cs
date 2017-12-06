using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using callcenter.modal;

namespace callcenter.service.wechat
{
    public class WechatServiceProvider
    {
        protected string appid;
        protected string secret;
        protected string access_token;

        public WechatServiceProvider(string appid, string secret)
        {
            this.appid = appid;
            this.secret = secret;
        }

        public WechatServiceProvider() : 
            this(System.Configuration.ConfigurationManager.AppSettings["wechat_appid"], 
                System.Configuration.ConfigurationManager.AppSettings["wechat_secret"])
        {
        }


        protected static Stream GetResponseStream(string url)
        {
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            WebResponse response = null;
            response = request.GetResponse();
            return response.GetResponseStream();
        }

        protected static Stream PostResponseStream(string url, string post_data)
        {
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            WebResponse response = null;
            request.Timeout = 8000;
            request.Method = "POST";

            byte[] post_bytes = System.Text.Encoding.UTF8.GetBytes(post_data);

            using (Stream post_stream = request.GetRequestStream())
            {
                post_stream.Write(post_bytes, 0, post_bytes.Length);
            }
            response = request.GetResponse();
            return response.GetResponseStream();
        }


        protected static Stream PostResponseStream(string url, Stream user_stream)
        {
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            WebResponse response = null;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            byte[] buffer = new byte[1024];

            int read_size;
            using (Stream post_stream = request.GetRequestStream())
            {
                while ((read_size = user_stream.Read(buffer, 0, buffer.Length)) > 0)
                    post_stream.Write(buffer, 0, read_size);
            }


            response = request.GetResponse();
            return response.GetResponseStream();
        }

        protected static string GetResponseStringByPost(string url, string post_data)
        {
            using (Stream stream = PostResponseStream(url, post_data))
            {
                using (StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8))
                {
                    return sr.ReadToEnd();
                }
            }
        }


        protected static string GetResponseString(string url)
        {
            using (Stream responseStream = GetResponseStream(url))
            {
                using (StreamReader sr = new StreamReader(responseStream, System.Text.Encoding.UTF8))
                {
                    return sr.ReadToEnd();
                }
            }
        }


        /// <summary>
        /// 获取网页的user_info_base,主要是获取openid和access_token两个参数
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public WechatSessionInfo GetSessionInfoByJscode(string code)
        {
            string service_url = string.Format("https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type=authorization_code",
                this.appid, this.secret, code);

            string response_content = GetResponseString(service_url);
            WechatSessionInfo session_info = Newtonsoft.Json.JsonConvert.DeserializeObject<WechatSessionInfo>(response_content);
            return session_info;
        }
    }
}

