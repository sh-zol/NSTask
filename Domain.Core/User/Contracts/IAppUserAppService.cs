using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.User.Contracts
{
    public interface IAppUserAppService
    {
        Task<int>? GetUserId();
        Task<List<IdentityError>> Register(string email, string password,string name, string phonenumber,bool isAdmin,bool isManufacturer);
        Task<bool> Login(string email,string password);
        Task SignOut();
    }
}
