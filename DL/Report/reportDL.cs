using DTO.Sale;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DL.Report
{
    public class reportDL: DataProviderEntity
    {
        public async Task<List<SaleClass>> SaleTodayDL()
        {
            try
            {
                using (var context = new DataProviderEntity())
                {
                    // Lấy ngày hôm nay
                    DateTime today = DateTime.Today;

                    // Truy vấn các đơn bán hàng của ngày hôm nay
                    return await context.Sale
                                             .Where(order => order.SaleDate.Date == today && order.Status == "Hoàn thành")
                                             .ToListAsync();
                }
            } catch {
                throw;
            }
        }
        public async Task<List<SaleClass>> Sale7DayDL()
        {
            using (var context = new DataProviderEntity())
            {
                // Lấy ngày hôm nay
                DateTime today = DateTime.Today;

                // Lấy ngày 7 ngày trước
                DateTime sevenDaysAgo = today.AddDays(-7);

                // Truy vấn các đơn bán hàng trong 7 ngày qua và có trạng thái "Hoàn thành"
                return await context.Sale
                                    .Where(order => order.SaleDate.Date >= sevenDaysAgo && order.SaleDate.Date <= today && order.Status == "Hoàn thành")
                                    .ToListAsync();
            }
        }

        public async Task<List<SaleClass>> Sale30DayDL()
        {
            using (var context = new DataProviderEntity())
            {
                // Lấy ngày hôm nay
                DateTime today = DateTime.Today;
                // Lấy ngày 30 ngày trước
                DateTime thirtyDaysAgo = today.AddDays(-30);
                // Truy vấn các đơn bán hàng trong 30 ngày qua và có trạng thái "Hoàn thành"
                return await context.Sale
                                    .Where(order => order.SaleDate.Date >= thirtyDaysAgo && order.SaleDate.Date <= today && order.Status == "Hoàn thành")
                                    .ToListAsync();
            }
        }
        
        public async Task<(int OrderCount, decimal TotalSale, decimal TotalCostPrice)> GetSalesSummaryTodayDL()
        {
            using (var context = new DataProviderEntity())
            {
                // Lấy ngày hôm nay
                DateTime today = DateTime.Today;

                // Truy vấn các đơn hàng thỏa mãn điều kiện
                var ordersToday = await context.Sale
                                                .Where(order => order.SaleDate.Date == today && order.Status == "Hoàn thành")
                                                .ToListAsync();

                // Tính số lượng đơn hàng
                int orderCount = ordersToday.Count;

                // Tính tổng doanh thu
                decimal totalSale = ordersToday.Sum(order => order.TotalAmount);

                // Tính tổng giá vốn
                decimal totalCostPrice = ordersToday.Sum(order => order.totalCostPrice);

                return (orderCount, totalSale, totalCostPrice);
            }
        }

        public async Task<(int OrderCount, decimal TotalSale, decimal TotalCostPrice)> GetSalesSummaryLast7DaysDL()
        {
            using (var context = new DataProviderEntity())
            {
                // Lấy ngày hôm nay
                DateTime today = DateTime.Today;

                // Lấy ngày cách đây 7 ngày
                DateTime sevenDaysAgo = today.AddDays(-6); // Bao gồm cả ngày hôm nay, tính từ 7 ngày trước

                // Truy vấn các đơn hàng trong 7 ngày gần đây
                var ordersLast7Days = await context.Sale
                                                   .Where(order => order.SaleDate.Date >= sevenDaysAgo &&
                                                                   order.SaleDate.Date <= today &&
                                                                   order.Status == "Hoàn thành")
                                                   .ToListAsync();

                // Tính số lượng đơn hàng
                int orderCount = ordersLast7Days.Count;

                // Tính tổng doanh thu
                decimal totalSale = ordersLast7Days.Sum(order => order.TotalAmount);

                // Tính tổng giá vốn
                decimal totalCostPrice = ordersLast7Days.Sum(order => order.totalCostPrice);

                return (orderCount, totalSale, totalCostPrice);
            }
        }

        public async Task<(int OrderCount, decimal TotalSale, decimal TotalCostPrice)> GetSalesSummaryLast30DaysDL()
        {
            using (var context = new DataProviderEntity())
            {
                // Lấy ngày hôm nay
                DateTime today = DateTime.Today;

                // Lấy ngày cách đây 30 ngày
                DateTime thirtyDaysAgo = today.AddDays(-29); // Bao gồm cả ngày hôm nay, tính từ 30 ngày trước

                // Truy vấn các đơn hàng trong 30 ngày gần đây
                var ordersLast30Days = await context.Sale
                                                    .Where(order => order.SaleDate.Date >= thirtyDaysAgo &&
                                                                    order.SaleDate.Date <= today &&
                                                                    order.Status == "Hoàn thành")
                                                    .ToListAsync();

                // Tính số lượng đơn hàng
                int orderCount = ordersLast30Days.Count;

                // Tính tổng doanh thu
                decimal totalSale = ordersLast30Days.Sum(order => order.TotalAmount);

                // Tính tổng giá vốn
                decimal totalCostPrice = ordersLast30Days.Sum(order => order.totalCostPrice);

                return (orderCount, totalSale, totalCostPrice);
            }
        }

    }
}
