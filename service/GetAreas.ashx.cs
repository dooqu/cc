using System;
using System.Collections.Generic;
using System.Web;
using callcenter.modal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace callcenter.service
{
    /// <summary>
    /// GetAreas 的摘要说明
    /// </summary>
    public class GetAreas : baseHandler.WechatServiceHandler
    {
        public class AreasResponseInfo : ResponseInfo
        {
            public List<AreaInfo> Areas
            {
                get;set;
            }
        }

        public override ResponseInfo OnLoad(HttpContext context)
        {
            List<AreaInfo> areas = null;

            string method = string.IsNullOrEmpty(GetParam("method")) ? "getProvinces" : GetParam("method");
            string parentId = null;

            if (method == "getProvinces")
            {
                areas = GetProvinces();
            }
            else if (method == "getCities" && string.IsNullOrEmpty(GetParam("parentid")) == false)
            {
                areas = GetCities(GetParam("parentid"));
            }
            else if (method == "getZones" && string.IsNullOrEmpty(GetParam("parentid")) == false)
            {
                areas = GetZones(GetParam("parentid"));
            }
            else
            {
                return new ResponseInfo(true, "参数错误");
            }

            AreasResponseInfo ri = new AreasResponseInfo();
            ri.Areas = areas;

            return ri;
        }

        public List<AreaInfo> GetProvinces()
        {
            List<AreaInfo> provinces = new List<AreaInfo>();
            
            foreach(var area in Global.AreaMap)
            {
                if(area.Key.EndsWith("0000"))
                {
                    AreaInfo ai = new AreaInfo();
                    ai.AreaId = area.Key;
                    ai.AreaName = area.Value.Value<string>();
                    provinces.Add(ai);
                }
            }

            return provinces;
        }

        public List<AreaInfo> GetCities(string provinceId)
        {
            string pid = provinceId.Substring(0, 2);
            List<AreaInfo> cities = new List<AreaInfo>();

            foreach(var area in Global.AreaMap)
            {
                if(area.Key.StartsWith(pid) && area.Key.EndsWith("00") && area.Key != provinceId)
                {
                    AreaInfo ai = new AreaInfo();
                    ai.AreaId = area.Key;
                    ai.AreaName = area.Value.Value<string>();
                    cities.Add(ai);
                }
            }

            if(cities.Count == 0)
            {
                AreaInfo ai = new AreaInfo();
                ai.AreaId = provinceId;
                ai.AreaName = Global.AreaMap[provinceId].Value<string>();
                cities.Add(ai);
            }

            return cities;
        }

        public List<AreaInfo> GetZones(string cityId)
        {
            string cid = cityId.Substring(0, 4);
            List<AreaInfo> zones = new List<AreaInfo>();

            foreach (var area in Global.AreaMap)
            {
                if (area.Key.StartsWith(cid) &&  area.Key != cityId)
                {
                    AreaInfo ai = new AreaInfo();
                    ai.AreaId = area.Key;
                    ai.AreaName = area.Value.Value<string>();
                    zones.Add(ai);
                }
            }
            return zones;
        }
    }
}