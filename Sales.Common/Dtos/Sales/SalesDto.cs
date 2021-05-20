using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Common.Dtos.Sales
{
    public class SalesDto
    {
        public int Id { get; set; }
        public int PersonnelId { get; set; }
        public DateTime? ReportDate { get; set; }
        public decimal? SalesAmount { get; set; }
    }
}
