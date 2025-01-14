using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Contracts.Utils
{
    public class PaginationParameters
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaximumPageSize ? MaximumPageSize : value;
        }

        private int _pageSize = 5;
        private const int MaximumPageSize = 50;
    }
}
