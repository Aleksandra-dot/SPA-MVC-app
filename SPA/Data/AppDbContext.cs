using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SPA.Models;

namespace SPA.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service_Appointment>().HasKey(sa => new
            {
                sa.ServiceId,
                sa.AppointmentId,
            });
            modelBuilder.Entity<Service_Appointment>()
                .HasOne(a => a.Appointment)
                .WithMany(am => am.Service_Appointments)
                .HasForeignKey(a => a.AppointmentId);

            modelBuilder.Entity<Service_Appointment>()
                .HasOne(a => a.Service)
                .WithMany(am => am.Service_Appointments)
                .HasForeignKey(a => a.ServiceId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Service> Services { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Service_Appointment> Service_Appointments { get; set; }
        public DbSet<Client> Clients { get; set; }


    }
}
