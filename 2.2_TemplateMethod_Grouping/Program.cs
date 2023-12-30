using System.Text.RegularExpressions;

namespace _2._2_TemplateMethod_Grouping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var languageBaseGroupingStrategy = new LanguageBaseGroupingStrategy();
            // 讀取學生資料 from student.data
            var students = ReadStudents.GetStudents();
            var groupList = languageBaseGroupingStrategy.Group(students);

        }

    }
}
