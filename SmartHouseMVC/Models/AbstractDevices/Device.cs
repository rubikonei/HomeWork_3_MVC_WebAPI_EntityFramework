using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SmartHouseMVC.Models.AbstractDevices
{
    [DataContract]
    public abstract class Device
    {
        private double power;

        public abstract void On();
        public abstract void Off();

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; protected set; }

        [DataMember]
        public bool State { get; protected set; }

        [DataMember]
        public double Power
        {
            get
            {
                return power;
            }
            set
            {
                if (value >= 0)
                {
                    power = value;
                }
            }
        }

        public override string ToString()
        {
            string state;
            if (State == true)
            {
                state = "включен";
            }
            else
            {
                state = "выключен";
            }
            return Name + ": " + state + ", мощность: " + Power;
        }
    }
}