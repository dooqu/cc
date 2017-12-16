using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace admin.HttpWebRequest
{
    public class HttpWebRequestHelp
    {
        public static string HttpWebRequestByPost(string strURL,string strPost)
        {
            System.Net.HttpWebRequest request;
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            //Post请求方式  
            request.Method = "POST";
            // 内容类型  
            request.ContentType = "application/x-www-form-urlencoded";
            // 参数经过URL编码  
            string paraUrlCoded = System.Web.HttpUtility.UrlEncode(strPost);
            byte[] payload;
            //将URL编码后的字符串转化为字节  
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            //设置请求的 ContentLength   
            request.ContentLength = payload.Length;
            //获得请 求流  
            System.IO.Stream writer = request.GetRequestStream();
            //将请求参数写入流  
            writer.Write(payload, 0, payload.Length);
            // 关闭请求流  
            writer.Close();
            System.Net.HttpWebResponse response;
            // 获得响应流  
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string responseText = myreader.ReadToEnd();
            myreader.Close();
            return(responseText);
        }
    }
}
