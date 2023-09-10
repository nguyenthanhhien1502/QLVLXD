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
    public class SupplierRep : GenericRep<QLVLXDContext, Supplier>
    {
        #region -- Overrides --
        //Lấy tất cả loại sp
        public override Supplier Read(int id)
        {
            var res = All.FirstOrDefault(p => p.SupplierId == id);
            return res;
        }
        //public override Category Read(int id)
        //{
        //    return base.Read(id);
        //}
        public int Remove(int id)
        {
            var m = base.All.First(i => i.SupplierId == id);
            m = base.Delete(m);
            return m.SupplierId;
        }

        #endregion
        #region -- Methods --
        public SingleRsp CreateSupplier(Supplier supplier)
        {
            var res = new SingleRsp();
            using (var context = new QLVLXDContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Suppliers.Add(supplier);
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
        //public List<Category> SearchSupplier(string KeyWord)
        //{
        //    return All.Where(k => k.CompanyName.Contains(KeyWord)).ToList();

        //}

        public SingleRsp UpdateSupplier(Supplier supplier)
        {
            var res = new SingleRsp();
            using (var context = new QLVLXDContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Suppliers.Update(supplier);
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
        #endregion
    }
}
