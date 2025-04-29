
using Microsoft.EntityFrameworkCore;

namespace CallLogsAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<LocationDetail> LocationDetail { get; set; }
        
        public DbSet<CallLogDetail> CallLogDetail { get; set; }

         public DbSet<CallBoundDetail> CallBoundDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LocationDetail>(entity =>
            {
                entity.ToTable("locationdetails");  // Match the exact case of your PostgreSQL table
                entity.HasKey(e => e.UserId);
                
                // Make sure string properties have proper column names that match your DB
                entity.Property(e => e.UserId).HasColumnName("userid");
                entity.Property(e => e.Address).HasColumnName("address");
                entity.Property(e => e.Pincode).HasColumnName("pincode");
                entity.Property(e => e.Country).HasColumnName("country");
            });


            modelBuilder.Entity<CallLogDetail>(entity =>
            {
                entity.ToTable("calllogdetails");
                entity.HasKey(e => e.SessionId);

                entity.Property(e => e.SessionId).HasColumnName("sessionid");
                entity.Property(e => e.UserId).HasColumnName("userid");
                entity.Property(e => e.FromName).HasColumnName("fromname");
                entity.Property(e => e.FromNumber).HasColumnName("fromnumber");
                entity.Property(e => e.ToName).HasColumnName("toname");
                entity.Property(e => e.ToNumber).HasColumnName("tonumber");
            });

            modelBuilder.Entity<CallBoundDetail>(entity =>
            {
                entity.ToTable("callbounddetails"); 
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("userid");
                entity.Property(e => e.InboundCallsCount).HasColumnName("inboundcallscount");
                entity.Property(e => e.OutboundCallsCount).HasColumnName("outboundcallscount");
                
            });
        }
    }
}