using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specafications
{
    public class ProductParams
    {
        private const int maxPageSize = 50;
        public int PageIndex { get; set; } = 1;
        private int pageSize = 6;
        private string search;

        public int PageSize
        {
            get => pageSize;
            set => pageSize = (value > maxPageSize) ? maxPageSize : value;
        }

        public string Sort { get; set; }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }

        public string Search { get => search; set => search = value.ToLower(); }

    }
}
