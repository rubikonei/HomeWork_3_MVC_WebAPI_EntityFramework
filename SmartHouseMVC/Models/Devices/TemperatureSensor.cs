using SmartHouseMVC.Models.AbstractDevices;
using SmartHouseMVC.Models.Interfaces;
using System;
using System.Runtime.Serialization;

namespace SmartHouseMVC.Models.Devices
{
    [DataContract]
    public class TemperatureSensor : Device, ITemperatureSensor
    {
        public TemperatureSensor() { }
        public TemperatureSensor(string name, bool state)
        {
            Name = name;
            State = state;
            if (state == true)
            {
                On();
            }
        }

        [DataMember]
        public int TemperatureEnvironment { get; set; }

        public override void On()
        {
            State = true;
            Power = 0.05;
            GetTemperature();
        }

        public override void Off()
        {
            State = false;
            Power = 0;
            TemperatureEnvironment = 0;
        }

        private void GetTemperature()
        {
            Random r = new Random();
            TemperatureEnvironment = r.Next(-30, 41);
        }

        public override string ToString()
        {
            return base.ToString() + ", наружная температура: " + TemperatureEnvironment;
        }
    }
}