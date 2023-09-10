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
    public class ProductRep : GenericRep<QLVLXDContext, Product>
    {
        #region -- Overrides --

        public override Product Read(int id)
        {
            var res = All.FirstOrDefault(p => p.ProductId == id);
            return res;
        }

        public int Remove(int id)
        {
            var m = base.All.First(i => i.ProductId == id);
            m = base.Delete(m);
            return m.ProductId;
        }
        #endregion

        #region -- Method --
        public SingleRsp CreateProduct(Product product)
        {
            var res = new SingleRsp();
            using (var context = new QLVLXDContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Products.Add(product);
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

        public List<Product> SearchProduct(string keyWord)
        {

            return All.Where(a => a.ProductName.Contains(keyWord)).ToList();
        }

        public SingleRsp UpdateProduct(Product product)
        {
            var res = new SingleRsp();
            using (var context = new QLVLXDContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Products.Update(product);
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
        public SingleRsp DeleteProduct(int id)
        {
            var res = new SingleRsp();
            //res.Data = All.FirstOrDefault(s => s.CategoryId == category.CategoryId);
            using (var context = new QLVLXDContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Products.Remove(All.FirstOrDefault(s => s.ProductId == id));
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
        public List<Product> GetProductsBySupplier(int supplierId)
        {
            var context = new QLVLXDContext();
            return context.Products.Where(p => p.SupplierId == supplierId).ToList();

        }
        public List<Product> GetProductsByCategory(int categoryID)
        {
            var context = new QLVLXDContext();
            return context.Products.Where(p => p.CategoryId == categoryID).ToList();

        }
        #endregion
    }
}
