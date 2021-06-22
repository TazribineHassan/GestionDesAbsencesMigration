
using GestionDesAbsencesMigration.Models.Context;
using GestionDesAbsencesMigration.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesAbsencesMigration.ServicesImpl
{
    public class RoleService : IRoleService
    {
        private ApplicationContext context;

        public RoleService(ApplicationContext context)
        {
            this.context = context;
        }

        public int getRoleId(string roleName)
        {
            return context.Roles.Where(r => r.Nom.Equals(roleName)).FirstOrDefault().Id;
        }
    }
}
