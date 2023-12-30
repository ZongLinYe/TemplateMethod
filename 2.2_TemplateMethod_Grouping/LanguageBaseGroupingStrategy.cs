using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2._2_TemplateMethod_Grouping
{
    public class LanguageBaseGroupingStrategy
    {
        public List<Grouping> Group(List<Student> students)
        {
            var groups = new List<Grouping>();
            var languageGroups = students.GroupBy(s => s.Language);
            var groupNumber = 1;

            foreach (var languageGroup in languageGroups)
            {
                var studentList = languageGroup.ToList();
                for (int i = 0; i < studentList.Count; i += 6)
                {
                    var group = new Grouping(studentList.Skip(i).Take(6).ToList());
                    if (group.Students.Count < 6 && groups.Any())
                    {
                        // 將不足6人的組分到其他組
                        groups.Last().Merge(group);
                    }
                    else
                    {
                        group.Number = groupNumber++;
                        groups.Add(group);
                    }
                }
            }

            return groups;


        }

    }
}