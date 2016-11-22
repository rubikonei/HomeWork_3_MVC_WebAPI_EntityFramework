using System.Data.Entity;
using SmartHouseMVC.Models.Factories;
using SmartHouseMVC.Models.AbstractDevices;

namespace SmartHouseMVC.Models
{
    public class DevicesContextInitializer : DropCreateDatabaseAlways<DevicesContext>
    {
        Factory factory = new Factory();

        protected override void Seed(DevicesContext context)
        {
            Device conditioner = factory.GetConditioner();
            Device convector = factory.GetConvector();
            Device energyMeter = factory.GetEnergyMeter();
            Device temperatureSensor = factory.GetTemperatureSensor();

            context.Devices.Add(conditioner);
            context.Devices.Add(convector);
            context.Devices.Add(energyMeter);
            context.Devices.Add(temperatureSensor);

            context.SaveChanges();
        }
    }
}