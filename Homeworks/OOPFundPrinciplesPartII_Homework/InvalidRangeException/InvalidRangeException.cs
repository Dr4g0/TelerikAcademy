using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvalidRangeException
{
    class InvalidRangeException<T>
        : ApplicationException
    {
        private readonly T startValue;
        private readonly T endValue;

        public T EndValue
        {
            get { return endValue; }
        }

        public T StartValue
        {
            get { return startValue; }
        }

        public InvalidRangeException(string msg, T start, T end)
            : this(msg, null, start, end)
        { }

        public InvalidRangeException(T start, T end)
            : this(null, start, end)
        { }

        public InvalidRangeException(string msg, Exception innerEx, T start, T end)
            : base(msg, innerEx)
        {
            this.startValue = start;
            this.endValue = end;
        }
    }
}
