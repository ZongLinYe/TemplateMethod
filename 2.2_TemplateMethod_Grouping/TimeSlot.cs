using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2._2_TemplateMethod_Grouping
{
    public class TimeSlot
    {
        public TimeSlot(TimeSpan start, TimeSpan end)
        {
            Start = start;
            End = end;
        }

        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }


    }
}