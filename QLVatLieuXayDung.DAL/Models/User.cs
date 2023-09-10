using System;
using System.Collections.Generic;

#nullable disable

namespace QLVatLieuXayDung.DAL.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public int? ProductId { get; set; }
        public string UserName { get; set; }
        public string Dob { get; set; }

        public virtual Product Product { get; set; }
    }
}
