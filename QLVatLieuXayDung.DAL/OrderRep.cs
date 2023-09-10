using Microsoft.EntityFrameworkCore;
using QLVatLieuXayDung.Common.DAL;
using QLVatLieuXayDung.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVatLieuXayDung.DAL
{
    public class OrderRep : GenericRep<QLVLXDContext, Order>
    {
        #region -- Overrides --
        //Lấy tất cả loại sp
        public override Order Read(int id)
        {
            var res = All.FirstOrDefault(p => p.OrderId == id);
            return res;
        }

        #endregion

        #region --Methods--

        public List<Order> SearchOrderByYear(int year)
        {
            return All.Where(order => order.OrderDate.Value.Year == year).ToList();

        }


        public List<Order> GetOrdersByYear(int year)
        {
            var context = new QLVLXDContext();
            return context.Orders
                .Where(order => order.OrderDate.Value.Year == year)
                .Include(order => order.OrderDetails)
                .ToList();
        }
        public List<Order> GetOrdersByMonth(int month, int year)
        {
            var context = new QLVLXDContext();
            return context.Orders
                .Where(order => order.OrderDate.Value.Month == month && order.OrderDate.Value.Year == year)
                .Include(order => order.OrderDetails)
                .ToList();
        }

        public List<OrderDetail> SearchOrderByOrderID(int orderID)
        {
            var context = new QLVLXDContext();
            return context.OrderDetails.Where(p => p.OrderId == orderID).ToList();
        }


        public List<Order> SearchOrderByCusID(string cusID)
        {
            return All.Where(order => order.CustomerId == cusID).ToList();

        }

        public List<Order> GetOrdersByCusID(string cusID)
        {
            var context = new QLVLXDContext();
            return context.Orders
                .Where(order => order.CustomerId == cusID)
                .Include(order => order.OrderDetails)
                .ToList();
        }
        public int TotalOrderByCusID(string cusID)
        {
            var context = new QLVLXDContext();
            return context.Orders.Count(o => o.CustomerId == cusID);
        }
        #endregion
    }
}
