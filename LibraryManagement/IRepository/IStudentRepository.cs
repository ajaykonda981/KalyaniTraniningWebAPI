using LibraryManagement.Models;

namespace LibraryManagement.IRepository
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();

        public Student GetStudentById(int id);

        public string CreateStudent(Student student);

        public string UpdateStudentById(int id, Student student);

        public string DeleteStudentById(int id);
    }
}
