using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLVatLieuXayDung.BLL;
using QLVatLieuXayDung.Common.Req;
using QLVatLieuXayDung.Common.Rsp;
using QLVatLieuXayDung.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLVatLieuXayDung22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductSvc productSvc;
        public ProductController()
        {
            productSvc = new ProductSvc();

        }
        [HttpGet("get-all")]
        public IActionResult getAllProduct()
        {
            var res = new SingleRsp();
            res.Data = productSvc.All;
            return Ok(res);
        }
        [HttpPost("search-by-id")]
        public IActionResult SearchProductById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = productSvc.Read(req.Id);
            return Ok(res);
        }

        [HttpPost("create-product")]
        public IActionResult CreateProduct([FromBody] ProductReq productReq)
        {
            var res = new SingleRsp();
            res = productSvc.CreateProduct(productReq);
            return Ok(res);
        }

        [HttpPost("search-product")]
        public IActionResult SearchProduct([FromBody] SearchProductReq searchProductReq)
        {
            var res = new SingleRsp();
            res = productSvc.SearchProduct(searchProductReq);
            return Ok(res);
        }


        [HttpPut("update-product")]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            var res = new SingleRsp();
            res = productSvc.UpdateProduct(product);
            return Ok(res);
        }
        [HttpDelete("delete-product")]
        public IActionResult DeleteProduct([FromBody] int id)
        {
            var res = new SingleRsp();
            res = productSvc.DeleteProduct(id);
            return Ok(res);
        }

        [HttpGet("GetProductsBySupplier")]
        public IActionResult GetProductsBySupplier([FromBody] int supplierId)
        {
            var res = productSvc.GetProductsBySupplier(supplierId);
            return Ok(res);
        }
        [HttpGet("GetProductsByCategory")]
        public IActionResult GetProductsByCategory([FromBody] int categoryID)
        {
            var res = productSvc.GetProductsByCategory(categoryID);
            return Ok(res);
        }

    }
}
