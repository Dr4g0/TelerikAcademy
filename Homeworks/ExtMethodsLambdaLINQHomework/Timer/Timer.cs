//Using delegates write a class Timer that has can execute certain method at each t seconds.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timer
{
    public delegate void TimerDelegate(int number);

    class Timer
    {

        private readonly TimerDelegate execMethod;
        private readonly int delayInSeconds;
        private int reps;

        public int Reps
        {
            get { return reps; }
        }
        

        public int DelayInSeconds
        {
            get { return delayInSeconds; }
        }
        

        public TimerDelegate ExecMethod
        {
            get { return execMethod; }
        }

        public Timer(TimerDelegate execMethod,int delay,int reps)
        {
            this.execMethod = execMethod;
            this.delayInSeconds = delay;
            this.reps = reps;
        }

        public void Run()
        {
            while (this.reps>0)
            {
                this.execMethod(reps);
                Thread.Sleep(delayInSeconds * 1000);
                this.reps--;
            }
        }
    }
}
