using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Common.Dtos.Sales
{
    public class SalesListInChartDto
    {
        public List<string> Labelset {get; set;}
        public List<decimal> dataset { get; set; }
        public string monthName { get; set; }
    }
}
