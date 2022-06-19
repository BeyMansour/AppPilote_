using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppPilote.Models;

namespace AppPilote.Data
{
    public class AppPiloteContext : DbContext
    {
        public AppPiloteContext (DbContextOptions<AppPiloteContext> options)
            : base(options)
        {
        }
        public DbSet<AppPilote.Models.Employe> Employe { get; set; }

    }
}
