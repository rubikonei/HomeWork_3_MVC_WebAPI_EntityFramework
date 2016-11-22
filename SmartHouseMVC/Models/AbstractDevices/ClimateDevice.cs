using SmartHouseMVC.Models.Interfaces;
using System.Runtime.Serialization;

namespace SmartHouseMVC.Models.AbstractDevices
{
    [DataContract]
    public abstract class ClimateDevice : Device, ITemperature
    {
        [DataMember]
        public int TemperatureEnvironment { get; set; }

        [DataMember]
        public virtual int Temperature { get; set; }

        public abstract void Increase();
        public abstract void Decrease();
        public abstract void SetAutoTemperature();
        public override string ToString()
        {
            return base.ToString();
        }
    }
}