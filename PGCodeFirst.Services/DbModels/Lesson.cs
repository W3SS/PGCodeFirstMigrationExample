using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGCodeFirst.Services.Db
{

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<ExamResult> ExamResults { get; set; }
    }

    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }

    public class Exam
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        public virtual ICollection<ExamResult> Results { get; set; }
    }

    public class ExamResult
    {
        public int Id { get; set; }
        public short Grade { get; set; }

        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }


}
