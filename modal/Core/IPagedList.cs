using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace callcenter.modal.Core
{/// <summary>
    /// 分页数据接口
    /// </summary>
    public interface IPagedList
    {
        /// <summary>
        /// 当前页
        /// </summary>
        int CurrentPageIndex { get; set; }

        /// <summary>
        /// 每页包含的记录数
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        long TotalItemCount { get; set; }
    }
}
