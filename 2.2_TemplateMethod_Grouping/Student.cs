using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2._2_TemplateMethod_Grouping
{
    public class Student
    {
        public string Name { get; set; }
        public int Experience { get; set; }
        public string Language { get; set; }
        public string JobTitle { get; set; }
        public List<TimeSlot> AvailableTimeSlots { get; set; }
    }


}