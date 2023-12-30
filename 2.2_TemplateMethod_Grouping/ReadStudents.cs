using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2._2_TemplateMethod_Grouping
{
    public class ReadStudents
    {
        public static List<Student> GetStudents()
        {
            // 讀取學生資料 from student.data
            var students = new List<Student>();
            using (var reader = new StreamReader("student.data"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(' ');
                    string pattern = @"\[(.*?)\]";
                    Match match = Regex.Match(line, pattern);
                    var student = new Student()
                    {
                        Name = values[0],
                        Experience = int.Parse(Regex.Match(values[1], @"\d+").Value),
                        Language = values[2],
                        JobTitle = values[3],
                        AvailableTimeSlots = ParseTimeSlots(match.Success ? match.Groups[1].Value : string.Empty)
                    };
                    students.Add(student);
                }
            }
            return students;
        }

        // [10 14 15 17 18 20 21] is timeSlots:string
        private static List<TimeSlot> ParseTimeSlots(string timeSlots)
        {
            // timeSlots = timeSlots.Trim('[', ']');
            var parts = timeSlots.Split(' ');
            var result = new List<TimeSlot>();
            foreach (var part in parts)
            {
                if (int.TryParse(part, out int timeSlot))
                {
                    // result.Add(timeSlot);
                    // Convert to TimeSlot is DateTime startTime And DateTime EndTime
                    result.Add(new TimeSlot(new TimeSpan(timeSlot, 0, 0), new TimeSpan(timeSlot + 1, 0, 0)));
                }
            }
            return result;
        }

    }
}