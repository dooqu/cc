using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using callcenter.dal;
using callcenter.modal;
using callcenter.modal.Core;

namespace callcenter.bll
{
    public class Ads
    {
        public static ReturnMessage NewAd(string imagePath)
        {
            int result = DataProvider.NewAd(imagePath);

            if (result > 0)
            {
                return new ReturnMessage(EnumResultState.Success.ToString(), "处理成功");
            }
            else
            {
                return new ReturnMessage(EnumResultState.Failing.ToString(), "处理失败");
            }
        }

        public static ReturnMessage DeleteAd(int adid)
        {
            int result = 0;
            AdInfo ai = GetAdInfoById(adid);

            if (ai != null)
            {
                try
                {
                    System.IO.File.Delete(HttpContext.Current.Server.MapPath("/") + "/ads/" + ai.ImagePath);
                }
                finally
                {
                    result = DataProvider.DeleteAd(adid);
                }
            }

            if (result > 0)
            {
                return new ReturnMessage(EnumResultState.Success.ToString(), "处理成功");
            }
            else
            {
                return new ReturnMessage(EnumResultState.Failing.ToString(), "处理失败");
            }

        }

        public static List<AdInfo> GetAds()
        {
            return DataProvider.GetAds();
        }

        public static AdInfo GetAdInfoById(int adid)
        {
            return DataProvider.GetAdInfoById(adid);
        }
    }
}
