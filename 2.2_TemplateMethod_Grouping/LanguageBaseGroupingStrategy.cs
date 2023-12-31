using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2._2_TemplateMethod_Grouping
{
    public class LanguageBaseGroupingStrategy
    {
        public static readonly int _groupMinSize = 6;
        public List<Grouping> Group(List<Student> students)
        {
            var groups = new List<Grouping>();
            // 第一刀，以語言分組
            var languageGroups = students.GroupBy(student => student.Language);
            var groupNumber = 1;

            foreach (var languageGroup in languageGroups)
            {
                var studentList = languageGroup.ToList();
                for (int studentIndex = 0; studentIndex < studentList.Count; studentIndex += _groupMinSize)
                {
                    CreateOrMergeGroup(studentList, studentIndex, ref groupNumber, groups);
                }
            }

            return groups;
        }

        private void CreateOrMergeGroup(List<Student> studentList, int studentIndex, ref int groupNumber, List<Grouping> groups)
        {
            var group = new Grouping(studentList.Skip(studentIndex).Take(_groupMinSize).ToList());
            if (group.Students.Count < _groupMinSize && groups.Any())
            {
                // if last group language is same, merge
                if (groups.Last().Students.First().Language == group.Students.First().Language)
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
            else
            {
                group.Number = groupNumber++;
                groups.Add(group);
            }
        }
    }


}