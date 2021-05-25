﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore;
using Sales.Common.Dtos.Sales;
using Sales.Data.Contracts;


namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesRepository _salesRepository;
        public SalesController(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }

        [HttpPost]
        public void Add(SalesDto salesDto)
        {
            _salesRepository.Add(new Entities.Sales.Sales()
            {
                PersonnelId = salesDto.PersonnelId,
                ReportDate =new DateTime(salesDto.Year,salesDto.Month,salesDto.Day),
                SalesAmount = salesDto.SalesAmount
            });
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id,int month,int year)
        {
            List<string> labels=new List<string>();
            List<decimal> datas = new List<decimal>();
            var monthName = "";

            var allData = _salesRepository.Table.Where(p => p.PersonnelId == id && p.ReportDate.Value.Month==month && p.ReportDate.Value.Year==year).OrderBy(s => s.ReportDate).ToList();
            if (allData.Any())
            {
                monthName = allData[0].ReportDate.Value.ToMonthName();

                int days = DateTime.DaysInMonth(2020, month);
                for (int day = 1; day <= days; day++)
                {
                    if (allData.Any(d => d.ReportDate.Value.Day == day))
                    {
                        var item = allData.FirstOrDefault(d => d.ReportDate.Value.Day == day);
                        var label = day.ToString();
                        labels.Add(day.ToString());
                        datas.Add(item.SalesAmount.Value);
                    }

                    else
                    {
                        labels.Add(day.ToString());
                        datas.Add(0);
                    }
                }
            }

            var res = new
            {
                Labelset = labels,
                dataset = datas,
                monthName= monthName
                };
            return Ok(res);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var itemToDelete = _salesRepository.Table.FirstOrDefault(p => p.Id == id); ;
            if (itemToDelete != null)
            {
                _salesRepository.Delete(itemToDelete);
            }
        }
    }
}
static class DateTimeExtensions
{
    public static string ToMonthName(this DateTime dateTime)
    {
        return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month);
    }
}