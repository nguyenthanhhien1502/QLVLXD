using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLVatLieuXayDung22.IService
{
    public interface IUserSvc
    {
        bool checkUser(string username, string password);
    }
}
