using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace callcenter.service
{
    public class Global : System.Web.HttpApplication
    {

        public static JObject AreaMap;
        protected void Application_Start(object sender, EventArgs e)
        {
            string content = null;
            
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("AreaMap.txt"), System.Text.Encoding.UTF8))
            {
                content = reader.ReadToEnd();
            }

            AreaMap = (JObject)JsonConvert.DeserializeObject(content);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
           
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}