using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace admin.Core
{
    public static class StringHelper
    {
        /// <summary>
        /// 移除尾部不需要的字符
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="trimChars"></param>
        /// <returns></returns>
        public static StringBuilder TrimEnd(this StringBuilder builder, params char[] trimChars)
        {
            if (trimChars == null)
            {
                trimChars = new char[] { ',' };
            }
            while (builder.Length > 0 && trimChars.Contains(builder[builder.Length - 1]))
            {
                builder.Remove(builder.Length - 1, 1);
            }
            return builder;
        }

        /// <summary>
        /// 判定字符串IsNullOrEmpty
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string source)
        {
            return String.IsNullOrEmpty(source);
        }
    }
}