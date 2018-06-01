using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{

    [Serializable]
    public class PagingDataSet<T> : ReadOnlyCollection<T>, IPagingDataSet
    {
        // Fields
        private int _pageIndex;
        private int _pageSize;
        private long _totalRecords;
        //private double queryDuration;

        // Methods
        public PagingDataSet(IEnumerable<T> entities) : base(entities.ToList<T>())
        {
            this._pageSize = 20;
            this._pageIndex = 1;
            this._totalRecords = 0L;
            //this.queryDuration = 0.0;
        }

        public PagingDataSet(IList<T> entities) : base(entities)
        {
            this._pageSize = 20;
            this._pageIndex = 1;
            this._totalRecords = 0L;
            //this.queryDuration = 0.0;
        }

        // Properties
        public int PageCount
        {
            get
            {
                long num = this.TotalRecords / ((long)this.PageSize);
                if ((this.TotalRecords % ((long)this.PageSize)) > 0L)
                {
                    long num2 = num;
                    num = num2 + 1L;
                }
                return Convert.ToInt32(num);
            }
        }

        public int PageIndex
        {
            get
            {
                return this._pageIndex;
            }
            set
            {
                this._pageIndex = value;
            }
        }

        public int PageSize
        {
            get
            {
                return this._pageSize;
            }
            set
            {
                this._pageSize = value;
            }
        }

        //public double QueryDuration
        //{
        //    get
        //    {
        //        return this.queryDuration;
        //    }
        //    set
        //    {
        //        this.queryDuration = value;
        //    }
        //}

        public long TotalRecords
        {
            get
            {
                return this._totalRecords;
            }
            set
            {
                this._totalRecords = value;
            }
        }

    }
}
