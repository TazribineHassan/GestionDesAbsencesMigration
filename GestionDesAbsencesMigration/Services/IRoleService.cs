using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesAbsencesMigration.Services
{
    public interface IRoleService
    {
        int getRoleId(string roleName);
    }
}
