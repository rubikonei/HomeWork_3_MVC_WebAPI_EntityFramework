using SmartHouseMVC.Models.AbstractDevices;
using SmartHouseMVC.Models.Devices;
using System.Data.Entity;

namespace SmartHouseMVC.Models
{
    public class DevicesContext : DbContext
    {
        static DevicesContext()
        {
            Database.SetInitializer<DevicesContext>(new DevicesContextInitializer());
        }
        public DbSet<Device> Devices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conditioner>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Conditioners");
            });

            modelBuilder.Entity<Convector>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Convectors");
            });

            modelBuilder.Entity<EnergyMeter>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("EnergyMeters");
            });

            modelBuilder.Entity<TemperatureSensor>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("TemperatureSensors");
            });
        }
    }
}