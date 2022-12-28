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

            // Configure StudentId as FK for StudentAddress
   
            //  modelBuilder.Entity<District_master>()
            // .HasOne(p => p.Zone_Masters)
            //.WithMany(b => b.District_masters)
            // .HasForeignKey(p => p.zoneid);
        }

        public DbSet<Courtcase> Courtcases { get; set; }
        public DbSet<Zone_master> Zone_Masters { get; set; }
        public DbSet<District_master> District_Masters { get; set; }
        public DbSet<Sro_master> Sro_Masters { get; set; }
        public DbSet<Court_master> Court_Masters { get; set; }
        public DbSet<Casetype_master> Casetype_Masters { get; set; }
        public DbSet<Responsetype_master> Responsetype_Masters { get; set; }
        public DbSet<Casestatus_master> Casestatus_Masters { get; set; }

        public DbSet<Menumaster> Menumasters { get; set; }
        public DbSet<Usermaster> usermaster { get; set; }
        public DbSet<Role_master> rolemaster { get; set; }
        public DbSet<Respondant_Master> respondentsmaster { get; set; }
        public DbSet<Slp_Master> slpmaster { get; set; }
        public DbSet<Judgement_master> judgementmaster { get; set; }
        public DbSet<Writappeals_master> Writappeals_Masters { get; set; }
        public DbSet<ChangePassword> changepassword { get; set; }
        public DbSet<Writappealstatus_master> Writappealstatus_Masters { get; set; }
        public DbSet<SupremeCourtCase> SupremeCourtCase { get; set; }
        public DbSet<Casehearing> casehearing { get; set; }


    }
}
