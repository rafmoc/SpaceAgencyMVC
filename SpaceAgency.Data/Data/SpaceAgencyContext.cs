using Microsoft.EntityFrameworkCore;
using SpaceAgency.Data.Data.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAgency.Data.Data
{
    public class SpaceAgencyContext : DbContext
    {
        public SpaceAgencyContext(DbContextOptions<SpaceAgencyContext> options)
            : base(options)
        {
        }

        public DbSet<Pioneer> Pioneer { get; set; }

        public DbSet<Mission> Mission { get; set; }

        public DbSet<Structure> Structure { get; set; }
    }
}
