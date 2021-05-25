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
        public int SalesAmount { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }


    }

    public class SalesSearchModel
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
