using DTO.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Report
{
    public class reportBL
    {
        public async Task<List<SaleClass>> SaleTodayBL()
        {
            return await new DL.Report.reportDL().SaleTodayDL();
        }

        public async Task<List<SaleClass>> Sale7DayBL()
        {
            return await new DL.Report.reportDL().Sale7DayDL();
        }

        public async Task<List<SaleClass>> Sale30DayBL()
        {
            return await new DL.Report.reportDL().Sale30DayDL();
        }

        public async Task<(int OrderCount, decimal TotalSale, decimal TotalCostPrice)> GetSalesSummaryTodayDL()
        {
            return await new DL.Report.reportDL().GetSalesSummaryTodayDL();
        }

        public async Task<(int OrderCount, decimal TotalSale, decimal TotalCostPrice)> GetSalesSummaryLast7DaysDL()
        {
            return await new DL.Report.reportDL().GetSalesSummaryLast7DaysDL();
        }

        public async Task<(int OrderCount, decimal TotalSale, decimal TotalCostPrice)> GetSalesSummaryLast30DaysDL()
        {
            return await new DL.Report.reportDL().GetSalesSummaryLast30DaysDL();
        }
    }
}
