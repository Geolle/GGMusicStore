using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{
    public interface IPagingDataSet
    {
        int PageIndex { get; set; }
        int PageSize { get; set; }
        long TotalRecords { get; set; }
    }
}
