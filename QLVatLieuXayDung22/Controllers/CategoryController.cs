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
    public class CategoryController : ControllerBase
    {
        private CategorySvc categorySvc;
        public CategoryController()
        {
            categorySvc = new CategorySvc();
        }
        [HttpGet("get-all")]
        public IActionResult getAllCategories()
        {
            var res = new SingleRsp();
            res.Data = categorySvc.All;
            return Ok(res);
        }
        [HttpPost("search-by-id")]
        public IActionResult searchCategoryById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = categorySvc.Read(req.Id);
            return Ok(res);
        }
        [HttpPost("create-category")]
        public IActionResult CreateCategory([FromBody] CategoryReq categoryReq)
        {
            var res = new SingleRsp();
            res = categorySvc.CreateCategory(categoryReq);
            return Ok(res);
        }
        // search category bằng CateName có phân trang
        [HttpPost("search-category")]
        public IActionResult SearchCategory([FromBody] SearchCategoryReq searchCategoryReq)
        {
            var res = new SingleRsp();
            res = categorySvc.SearchCategory(searchCategoryReq);
            return Ok(res);
        }
        [HttpPut("update-category")]
        public IActionResult UpdateCategory([FromBody] CategoryReq categoryReq)
        {
            var res = new SingleRsp();
            res = categorySvc.UpdateCategory(categoryReq);
            return Ok(res);
        }
        //[HttpPost("delete-category")]
        //public IActionResult DeleteCategory([FromBody] int id)
        //{
        //    var res = new SingleRsp();
        //    res = categorySvc.DeleteCategory(id);
        //    return Ok(res);
        //}
    }
}

