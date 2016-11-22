using SmartHouseMVC.Models;
using SmartHouseMVC.Models.AbstractDevices;
using SmartHouseMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;

namespace SmartHouseMVC.Controllers
{
    public class ValuesController : ApiController
    {
        private DevicesContext db = new DevicesContext();

        [HttpPut]
        [Route("api/values/off/{id}")]
        public Device Off(Guid id)
        {
            Device device = db.Devices.Find(id);
            if (device.State == true)
            {
                device.Off();
            }
            else
            {
                device.On();
            }
            db.Entry(device).State = EntityState.Modified;
            db.SaveChanges();
            return device;
        }

        [HttpPut]
        [Route("api/values/decreaseTemperature/{id}")]
        public Device DecreaseTemperature(Guid id)
        {
            Device device = db.Devices.Find(id);
            ((ClimateDevice)device).Decrease();
            db.Entry(device).State = EntityState.Modified;
            db.SaveChanges();
            return device;
        }

        [HttpPut]
        [Route("api/values/increaseTemperature/{id}")]
        public Device IncreaseTemperature(Guid id)
        {
            Device device = db.Devices.Find(id);
            ((ClimateDevice)device).Increase();
            db.Entry(device).State = EntityState.Modified;
            db.SaveChanges();
            return device;
        }

        [HttpPut]
        [Route("api/values/setAutoTemperature/{id}")]
        public Device SetAutoTemperature(Guid id)
        {
            Device climateDevice = db.Devices.Find(id);
            foreach (Device deviceSensor in db.Devices)
            {
                if (deviceSensor is ITemperatureSensor)
                {
                    ((ClimateDevice)climateDevice).TemperatureEnvironment = ((ITemperatureSensor)deviceSensor).TemperatureEnvironment;
                }
            }
            ((ClimateDevice)climateDevice).SetAutoTemperature();
            db.Entry(climateDevice).State = EntityState.Modified;
            db.SaveChanges();
            return climateDevice;
        }

        [HttpPut]
        [Route("api/values/countEnergy/{id}")]
        public Device CountEnergy(Guid id)
        {
            int key = 1;
            Device device = db.Devices.Find(id);
            Dictionary<int, Device> allDevices = new Dictionary<int, Device>();
            foreach (Device d in db.Devices)
            {
                allDevices.Add(key++, d);
            }
            ((ICountEnergy)device).CountEnergy(allDevices);
            db.Entry(device).State = EntityState.Modified;
            db.SaveChanges();
            return device;
        }

        [HttpPut]
        [Route("api/values/offFan/{id}")]
        public Device OffFan(Guid id)
        {
            Device device = db.Devices.Find(id);
            if (((IFan)device).Fan == true)
            {
                ((IFan)device).FanOff();
            }
            else
            {
                ((IFan)device).FanOn();
            }
            db.Entry(device).State = EntityState.Modified;
            db.SaveChanges();
            return device;
        }

        [HttpDelete]
        [Route("api/values/delete/{id}")]
        public void Delete(Guid id)
        {
            Device device = db.Devices.Find(id);
            db.Devices.Remove(device);
            db.SaveChanges();
        }
    }
}
