using System;
using System.Collections.Generic;

#nullable disable

namespace QLVatLieuXayDung.DAL.Models
{
    public partial class XuatKho
    {
        public int ProductId { get; set; }
        public string Quantity { get; set; }

        public virtual Product Product { get; set; }
    }
}
