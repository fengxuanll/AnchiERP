using Anchi.ERP.Domain.Users;
using Anchi.ERP.Domain.Users.Filter;
using Anchi.ERP.Service.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var userFilter = new FindUserFilter();
            userFilter.TrueName = "xx";
            userFilter.PageIndex = 0;
            userFilter.PageSize = 10;

            var userService = new UserService();
            var result = userService.FindPaged<User>(userFilter);
        }
    }
}
