using System;
using System.Collections.Generic;
using System.Web;
using callcenter.modal;
using callcenter.bll;

namespace callcenter.service
{
    /// <summary>
    /// GetAds 的摘要说明
    /// </summary>
    public class GetAds : baseHandler.WechatServiceHandler
    {
        public class AdsResponseInfo : ResponseInfo
        {
            public List<AdInfo> Ads
            {
                get;set;
            }
        }

        public override ResponseInfo OnLoad(HttpContext context)
        {
            AdsResponseInfo rep = new AdsResponseInfo();
            rep.Ads = Ads.GetAds();

            return rep;
        }
    }
}