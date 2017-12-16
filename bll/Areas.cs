using System;
using System.Collections.Generic;
using System.Text;

namespace callcenter.bll
{
    public class AreaInfo
    {
        public string AreaId
        {
            get;set;
        }

        public string AreaName
        {
            get;set;
        }
    }

    
    public class Areas
    {
        public static List<AreaInfo> AREAS;
        static Areas()
        {
            AREAS = new List<AreaInfo>();
        }

        public static void Init()
        {

        }
    }
}
