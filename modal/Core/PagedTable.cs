using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace callcenter.modal.Core
{/// <summary>
    /// 分页的DataTable
    /// </summary>
    [Serializable]
    [DataContract]
    public class PagedTable : IPagedList
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PagedTable() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">分页后的DataTable</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示记录数</param>
        public PagedTable(DataTable dataTable, int pageIndex, int pageSize)//:this(dataTable,pageIndex,pageSize,dataTable.Rows.Count)
        {
            if (dataTable != null)
            {
                Table = dataTable;
                TotalItemCount = dataTable.Rows.Count;
                CurrentPageIndex = pageIndex;
                PageSize = pageSize;
            }
            else
            {
                Table = new DataTable();
                TotalItemCount = 0;
                CurrentPageIndex = pageIndex;
                PageSize = pageSize;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">分页后的DataTable</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="totalItemCount">总记录数</param>
        public PagedTable(DataTable dataTable, int pageIndex, int pageSize, long totalItemCount)
        {
            Table = dataTable;
            TotalItemCount = totalItemCount;
            CurrentPageIndex = pageIndex;
            PageSize = pageSize;
        }

        /// <summary>
        /// 分页后的数据表
        /// </summary>
        [DataMember]
        public DataTable Table { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        [DataMember]
        public int CurrentPageIndex { get; set; }

        /// <summary>
        /// 每页记录数
        /// </summary>
        [DataMember]
        public int PageSize { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        [DataMember]
        public long TotalItemCount { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPageCount { get { return (int)Math.Ceiling(TotalItemCount / (double)PageSize); } }

        /// <summary>
        /// 起始行
        /// </summary>
        public int StartRecordIndex { get { return (CurrentPageIndex - 1) * PageSize + 1; } }

        /// <summary>
        /// 结束行
        /// </summary>
        public int EndRecordIndex { get { return (int)(TotalItemCount > CurrentPageIndex * PageSize ? CurrentPageIndex * PageSize : TotalItemCount); } }
    }
}
