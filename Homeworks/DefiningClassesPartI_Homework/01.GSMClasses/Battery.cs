using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsmInfo
{
    public enum BatteryType
    {
        LiIon,
        NiMH,
        NiCD
    }

    class Battery
    {
        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private decimal? hoursIdle;

        public decimal? HoursIdle
        {
            get { return hoursIdle; }
            set { hoursIdle = value; }
        }

        private decimal? hoursTalk;

        public decimal? HoursTalk
        {
            get { return hoursTalk; }
            set { hoursTalk = value; }
        }

        private BatteryType type;

        public BatteryType Type
        {
            get { return type; }
            set { type = value; }
        }
        
        public Battery(string model, decimal? hoursIdle, decimal? hoursTalk, BatteryType type=BatteryType.LiIon)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.Type = type;
        }

        public Battery(decimal? hoursIdle, decimal? hoursTalk)
            : this(null, hoursIdle, hoursTalk)
        { 
        }

        public Battery()
            
        { 
        }
    }
}
