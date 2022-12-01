using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IGRSCourtAPI.Database.DB_Entity;

namespace IGRSCourtAPI.Database
{
    public class EF_IGRSCC_DataContext : DbContext
    {
        public EF_IGRSCC_DataContext(DbContextOptions<EF_IGRSCC_DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public DbSet<Courtcase> Courtcases { get; set; }
        public DbSet<Zone_master> Zone_Masters { get; set; }
        public DbSet<District_master> District_Masters { get; set; }
        public DbSet<Sro_master> Sro_Masters { get; set; }
        public DbSet<Court_master> Court_Masters { get; set; }
        public DbSet<Casetype_master> Casetype_Masters { get; set; }
        public DbSet<Responsetype_master> Responsetype_Masters { get; set; }
        public DbSet<Casestatus_master> Casestatus_Masters { get; set; }

    }
}
