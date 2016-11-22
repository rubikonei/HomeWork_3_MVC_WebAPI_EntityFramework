using SmartHouseMVC.Models.AbstractDevices;
using SmartHouseMVC.Models.Interfaces;
using System.Runtime.Serialization;

namespace SmartHouseMVC.Models.Devices
{
    [DataContract]
    public class Conditioner : ClimateDevice, IFan
    {
        private int temperature;
        private bool fan;

        public Conditioner() { }
        public Conditioner(string name, bool state, bool fan)
        {
            Name = name;
            State = state;
            Fan = fan;
            if (state == true)
            {
                On();
            }
        }

        public override int Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                if (value >= 15 && value <= 25 && State == true)
                {
                    temperature = value;
                }
                if (State == false)
                {
                    temperature = 0;
                }
            }
        }

        [DataMember]
        public bool Fan
        {
            get
            {
                return fan;
            }
            set
            {
                if (value == true && Fan == false && State == true)
                {
                    fan = value;
                }
                if (value == false && Fan == true && State == true)
                {
                    fan = value;
                }
                if (value == false && State == false)
                {
                    fan = value;
                }
            }
        }

        public override void On()
        {
            State = true;
            Power = 4;
            Temperature = 22;
        }

        public override void Off()
        {
            State = false;
            Power = 0;
            Temperature = 0;
            Fan = false;
        }

        public override void Increase()
        {
            Temperature++;
        }

        public override void Decrease()
        {
            Temperature--;
        }

        public void FanOn()
        {
            Fan = true;
            if (Fan == true)
            {
                Power += 0.2;
            }
        }

        public void FanOff()
        {
            Fan = false;
            if (Fan == false)
            {
                Power -= 0.2;
            }
        }

        public override void SetAutoTemperature()
        {
            if (TemperatureEnvironment >= 25 && TemperatureEnvironment <= 40)
            {
                On();
                Temperature = 22;
                Power += (TemperatureEnvironment - Temperature) * 0.05;
            }
            else
            {
                Off();
            }
        }

        public override string ToString()
        {
            string fanState;
            if (fan)
            {
                fanState = "включен";
            }
            else
            {
                fanState = "выключен";
            }
            return base.ToString() + ", температура: " + temperature + ", венитялтор: " + fanState;
        }
    }
}