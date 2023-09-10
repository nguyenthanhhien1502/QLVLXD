using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLVatLieuXayDung.BLL;
using QLVatLieuXayDung.Common.Req;
using QLVatLieuXayDung.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLVatLieuXayDung22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderSvc orderSvc;
        public OrderController()
        {
            orderSvc = new OrderSvc();
        }
        [HttpGet("get-all")]
        public IActionResult getAllOrder()
        {
            var res = new SingleRsp();
            res.Data = orderSvc.All;
            return Ok(res);
        }
        [HttpPost("search-by-id")]
        public IActionResult searchOrderById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = orderSvc.Read(req.Id);
            return Ok(res);
        }
        [HttpGet("search-order-by-year")]
        public IActionResult GetOrdersByYear(int year)
        {
            var res = orderSvc.SearchOrderByYear(year);
            return Ok(res);
        }

        [HttpGet("revenue-by-year")]
        public IActionResult GetRevenueByYear(int year)
        {
            //var orders = orderSvc.GetOrdersByYear(year);

            //decimal totalRevenue = orders
            //    .SelectMany(o => o.OrderDetails)
            //    .Sum(d => d.Quantity * d.UnitPrice);

            //return Ok(new { Year = year, TotalRevenue = totalRevenue });
            var res = new SingleRsp();
            res = orderSvc.GetOrdersByYear(year);
            return Ok(res);
        }
        [HttpGet("revenue-by-month")]
        public IActionResult GetRevenueByMonth(int month, int year)
        {
            var res = new SingleRsp();
            res = orderSvc.GetOrdersByMonth(month, year);
            return Ok(res);
        }
        [HttpGet("Search-Order-By-CusID")]
        public IActionResult SearchOrderByCusID(string cusID)
        {
            var res = orderSvc.SearchOrderByCusID(cusID);
            return Ok(res);
        }
        [HttpGet("Total-Order-By-CusID")]
        public IActionResult TotalOrderByCusID(string cusID)
        {
            var res = orderSvc.TotalOrderByCusID(cusID);
            return Ok(res);
        }
        [HttpGet("Search-Order-By-OrderID")]
        public IActionResult SearchOrderByOrderID(int orderID)
        {
            var res = orderSvc.SearchOrderByOrderID(orderID);
            return Ok(res);
        }
    }
}
