using System;
using System.Collections.Generic;

#nullable disable

namespace QLVatLieuXayDung.DAL.Models
{
    public partial class CustomerAndSuppliersByCity
    {
        public string City { get; set; }
        public string CompanyName { get; set; }
        public string Relationship { get; set; }
    }
}
