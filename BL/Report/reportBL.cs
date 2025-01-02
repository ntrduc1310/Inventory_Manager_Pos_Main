using DTO.Sale;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DL.Report;

namespace BL.Report
{
    public class reportBL
    {
        private readonly reportDL _reportDL;

        public reportBL()
        {
            _reportDL = new reportDL();
        }

        public async Task<List<SaleClass>> SaleTodayBL()
        {
            try
            {
                return await _reportDL.SaleTodayDL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SaleClass>> Sale7DayBL()
        {
            try
            {
                return await _reportDL.Sale7DayDL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SaleClass>> Sale30DayBL()
        {
            try
            {
                return await _reportDL.Sale30DayDL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<(int OrderCount, decimal TotalSale, decimal TotalCostPrice)> GetSalesSummaryTodayBL()
        {
            try
            {
                return await _reportDL.GetSalesSummaryTodayDL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<(int OrderCount, decimal TotalSale, decimal TotalCostPrice)> GetSalesSummaryLast7DaysBL()
        {
            try
            {
                return await _reportDL.GetSalesSummaryLast7DaysDL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<(int OrderCount, decimal TotalSale, decimal TotalCostPrice)> GetSalesSummaryLast30DaysBL()
        {
            try
            {
                return await _reportDL.GetSalesSummaryLast30DaysDL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SaleClass>> SaleByDateBL(DateTime fromDate, DateTime toDate)
        {
            try
            {
                return await _reportDL.SaleByDateDL(fromDate, toDate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<(int OrderCount, decimal TotalSale, decimal TotalCostPrice)> GetSalesSummaryByDateRangeBL(DateTime fromDate, DateTime toDate)
        {
            return await _reportDL.GetSalesSummaryByDateRangeDL(fromDate, toDate);
        }
    }
}