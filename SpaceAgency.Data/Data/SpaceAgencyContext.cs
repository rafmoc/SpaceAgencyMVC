using Microsoft.EntityFrameworkCore;
using SpaceAgency.Data.Data.CMS;
using SpaceAgency.Data.Data.Travels;
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

        public DbSet<Page> Page { get; set; }

        public DbSet<Pioneer> Pioneer { get; set; }

        public DbSet<MainContent> MainContent { get; set; }

        public DbSet<Travel> Travel { get; set; }

        public DbSet<Planet> Planet { get; set; }
    }
}
