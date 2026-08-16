namespace LinqSample020
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var teachers = CreateTeachers();
            var students = CreateStudents();
            var result =
                from t in teachers
                join s in students
                on t.ClassName equals s.ClassName
                select
                new ResultInfo { ClassName = t.ClassName, Teacher = t.Teacher, Student = s.Student };
            foreach(var item in result)
            {
                Console.WriteLine($"{item.ClassName}：{item.Teacher}：{item.Student}");
            }
        }
        static List<TeacherInfo> CreateTeachers()//集合初始化
        {
            return new List<TeacherInfo>()
            {
               new TeacherInfo { ClassName ="1A" , Teacher ="Bill" },
               new TeacherInfo { ClassName ="1B" , Teacher ="David"}
            };
        }
        static List<StudentInfo> CreateStudents()//集合運算式
        {
            return
            [
                new () { ClassName ="1A" , Student ="魯夫" },
                new () { ClassName ="1A" , Student ="索隆" },
                new () { ClassName ="1B" , Student ="櫻木" },
                new () { ClassName ="1A" , Student ="香吉士"},
                new () { ClassName ="1B" , Student ="流川楓"}
            ];
        }
    }

    internal class TeacherInfo
    {
        public string ClassName { get; set; }
        public string Teacher { get; set; }
    }
    internal class StudentInfo
    {
        public string ClassName { get; set; }
        public string Student { get; set; }
    }
    internal class ResultInfo
    {
        public string ClassName { get; set; }
        public string Teacher { get; set; }
        public string Student { get; set; }
    }
}
