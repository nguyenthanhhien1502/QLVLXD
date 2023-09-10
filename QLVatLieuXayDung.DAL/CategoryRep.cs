using QLVatLieuXayDung.Common.DAL;
using QLVatLieuXayDung.Common.Rsp;
using QLVatLieuXayDung.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVatLieuXayDung.DAL
{
    public class CategoryRep : GenericRep<QLVLXDContext, Category>
    {
        #region -- Overrides --
        //Lấy tất cả loại sp
        public override Category Read(int id)
        {
            var res = All.FirstOrDefault(p => p.CategoryId == id);
            return res;
        }
        //public override Category Read(int id)
        //{
        //    return base.Read(id);
        //}
        public int Remove(int id)
        {
            var m = base.All.First(i => i.CategoryId == id);
            m = base.Delete(m);
            return m.CategoryId;
        }

        #endregion
        #region -- Methods --
        public SingleRsp CreateCategory(Category category)
        {
            var res = new SingleRsp();
            using (var context = new QLVLXDContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Categories.Add(category);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        public List<Category> SearchCategory(string KeyWord)
        {
            return All.Where(k => k.CategoryName.Contains(KeyWord)).ToList();

        }
        public SingleRsp UpdateCategory(Category category)
        {
            var res = new SingleRsp();
            //res.Data = All.FirstOrDefault(s => s.CategoryId == category.CategoryId);
            using (var context = new QLVLXDContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Categories.Update(category);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        //public SingleRsp DeleteCategory(int id)
        //{
        //    var res = new SingleRsp();
        //    //res.Data = All.FirstOrDefault(s => s.CategoryId == category.CategoryId);
        //    using (var context = new QLVLXDContext())
        //    {
        //        using (var tran = context.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                var p = context.Categories.Remove(All.FirstOrDefault(s => s.CategoryId == id));
        //                context.SaveChanges();
        //                tran.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                tran.Rollback();
        //                res.SetError(ex.StackTrace);
        //            }
        //        }
        //    }
        //    return res;
        //}
        #endregion
    }
}
