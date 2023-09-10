using QLVatLieuXayDung22.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLVatLieuXayDung22.Service
{
    public class Svc : IUserSvc
    {
        public bool checkUser(string username, string password)
        {
            return username.Equals("admin") && password.Equals("123123");
        }
    }
}