using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsmInfo
{
    class GSM
    {
        private string model;

        public string Model
        {
            get { return model; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The model is incorrect");
                } 
                model = value;
            }
        }

        private string manufacturer;

        public string Manufacturer
        {
            get { return manufacturer; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The manufacturer is incorrect.");
                } 
                manufacturer = value;
            }
        }

        private decimal? price;

        public decimal? Price
        {
            get { return price; }
            set {
                if (value<0)
                {
                    throw new ArgumentException("Invalid price.");
                } 
                price = value;
            }
        }

        private string owner;

        public string Owner
        {
            get { return owner; }
            set {
                if (!String.IsNullOrEmpty(value))
                {
                    foreach (char symbol in value)
                    {
                        if (!(Char.IsLetter(symbol) || symbol == ' '|| symbol=='-')) //assume the owner is a person
                        {
                            throw new ArgumentException("The name of the owner is incorrect.");
                        }
                    } 
                }
                owner = value;
            }
        }
        
        public Battery Battery = new Battery();
        public Display Display = new Display();

        private static readonly GSM iPhone4S = new GSM("IPhone4S","Apple",700);

        public static GSM IPhone4S
        { 
            get { return iPhone4S; } 
        }

        private List<Call> callHistory = new List<Call>();

        public List<Call> CallHistory
        {
            get { return callHistory ; }
            set { callHistory = value; }
        }

        public GSM(string model, string manufacturer, decimal? price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }

        public GSM(string model, string manufacturer)
            : this(model, manufacturer,null,null,null,null)
        { 
        }

        public GSM(string model, string manufacturer, decimal? price)
            : this(model, manufacturer, price, null, null, null)
        { 
        }

        public GSM(string model, string manufacturer, string owner)
            : this(model, manufacturer, null, owner, null, null)
        { 
        }

        public GSM(string model, string manufacterer, decimal? price, string owner)
            :this(model,manufacterer,price,owner,null,null)
        { 
        }

        public GSM(string model, string manufacturer, Battery battery, Display display)
            : this(model, manufacturer, null, null, battery, display)
        { 
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine("INFO:");
            info.AppendLine(new string('=',20));
            info.AppendLine("Model:"+Model);
            info.AppendLine("Manufacterer:" + Manufacturer);
            info.Append("Price:");
            if (Price==null)
            {
                info.AppendLine("Unknown");
            }
            else
            {
                info.AppendLine(Price.ToString());
            }
            info.Append("Owner:");
            if (Owner==null)
            {
                info.AppendLine("Unknown");
            }
            else
            {
                info.AppendLine(Owner.ToString());
            }
            info.Append("Battery Model:");
            if (Battery==null)
            {
                info.AppendLine("Uknown");
            }
            else
            {
                info.AppendLine(Battery.Model.ToString());
                info.Append("Battery Hours Idle:");
                info.AppendLine(Battery.HoursIdle.ToString());
                info.Append("Battery Hours Talk:");
                info.AppendLine(Battery.HoursTalk.ToString());
                info.Append("Battery Type:");
                info.AppendLine(Battery.Type.ToString());
            }
            if (Display!=null)
            {
                info.Append("Display Size:");
                info.AppendLine(Display.Size.ToString());
                info.Append("Display Number of Colors:");
                info.AppendLine(Display.Colors.ToString());
            }
            return info.ToString();
        }

        public void AddCall(Call call)
        {
            CallHistory.Add(call);
        }

        public void RemoveCall(Call call)
        {
            if (!CallHistory.Contains(call))
            {
                throw new IndexOutOfRangeException("Nonexistent call");
            }
            CallHistory.Remove(call);
        }

        public void ClearCallHistory()
        {
            CallHistory.Clear();
        }

        public decimal CalculateTotalPrice(decimal fixedPrice)
        {
            decimal totalPrice = 0;
            foreach (Call call in CallHistory)
            {
                //the mobile phone companies usually calculate the calls for every started minute
                totalPrice += (Math.Ceiling((decimal)call.Duration / 60)) * fixedPrice;
            }
            return Math.Round(totalPrice,2);
        }
    }
}
