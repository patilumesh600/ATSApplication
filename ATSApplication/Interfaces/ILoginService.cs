using ATSApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSApplication.Interfaces
{
    public interface ILoginService
    {
        ApplicationUser ValidateUser(string username, string password);
    }
}
