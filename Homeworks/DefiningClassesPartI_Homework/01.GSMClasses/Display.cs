using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsmInfo
{
    class Display
    {
        private decimal? size;

        public decimal? Size
        {
            get { return size; }
            set { size = value; }
        }

        private int? colors;

        public int? Colors
        {
            get { return colors; }
            set { colors = value; }
        }
        
        public Display(decimal? size, int? colors)
        {
            this.Size = size;
            this.Colors = colors;
        }

        public Display()
            : this(null, null)
        { 
        }
    }

}
