using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesAbsencesMigration.Services
{
    public interface ILoginService
    {
        object Login(string email, string password, string userType = null);
        object getUser(string email);
    }
}
