using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2._2_TemplateMethod_Grouping
{
    public class Grouping
    {
        public Grouping(List<Student> students)
        {
            Students = students;
        }

        public List<Student> Students { get; set; }
        public int Number { get; set; }

        public void Merge(Grouping grouping)
        {
            Students.AddRange(grouping.Students);
        }
        public int Size()
        {
            return Students.Count;
        }
    }
}
