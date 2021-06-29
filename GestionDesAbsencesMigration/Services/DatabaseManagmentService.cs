using GestionDesAbsencesMigration.Models.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesAbsencesMigration.Services
{
    public static class DatabaseManagmentService
    {
        public static void MigrationInitialLisation(IApplicationBuilder app)
        {
            using (var serviceScpoe = app.ApplicationServices.CreateScope())
            {
                serviceScpoe.ServiceProvider.GetService<ApplicationContext>().Database.Migrate();
            }
        }
    }
}
