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
    public class SupplierController : ControllerBase
    {
        private SupplierSvc supplierSvc;
        public SupplierController()
        {
            supplierSvc = new SupplierSvc();
        }
        [HttpGet("get-all")]
        public IActionResult getAllSupplier()
        {
            var res = new SingleRsp();
            res.Data = supplierSvc.All;
            return Ok(res);
        }

        [HttpPost("search-by-id")]
        public IActionResult searchSupplierById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = supplierSvc.Read(req.Id);
            return Ok(res);
        }
        [HttpPost("create-supplier")]
        public IActionResult CreateSupplier([FromBody] SupplierReq supplierReq)
        {
            var res = new SingleRsp();
            res = supplierSvc.CreateSupplier(supplierReq);
            return Ok(res);
        }


        [HttpPut("update-Supplier")]
        public IActionResult UpdateSupplier([FromBody] SupplierReq supplierReq)
        {
            var res = new SingleRsp();
            res = supplierSvc.UpdateSupplier(supplierReq);
            return Ok(res);
        }


    }
}
