using LibraryManagement.Models;
using System.Data.SqlClient;
using System.Data;
using LibraryManagement.IRepository;

namespace LibraryManagement.Repository
{
    public class StudentRepository: IStudentRepository
    {
        SqlConnection conn = new SqlConnection("Server=INDRANI; Database = LibraryManagement; Trusted_Connection = true");
        SqlCommand? sqlcommand;
        DataSet dataSet = new DataSet();
        DataTable dataTable = new DataTable();
        const string STUDENT = "Student";

        private ISqlRepository _sqlRepository;

        public StudentRepository(ISqlRepository sqlRepository)
        {
            _sqlRepository = sqlRepository;
        }

        
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            sqlcommand = new SqlCommand("SELECT * FROM STUDENT", conn);

            dataTable = _sqlRepository.Get(sqlcommand);

            foreach (DataRow row in dataTable.Rows)
            {
                Student student = new Student();
                student.Id = Convert.ToInt32(row["Id"]);
                student.StudentName = Convert.ToString(row["StudentName"]);
                student.DepartmentId = Convert.ToInt32(row["DepartmentId"]);

                students.Add(student);
            };

            return students;
        }

        public Student GetStudentById(int id)
        {

            sqlcommand = new SqlCommand("SELECT * FROM STUDENT WHERE Id = @Id", conn);
            sqlcommand.Parameters.AddWithValue("@Id", id);

            dataTable = _sqlRepository.Get(sqlcommand);

            DataRow row = dataTable.Rows[0];

            Student student = new Student();
            student.Id = Convert.ToInt32(row["Id"]);
            student.StudentName = Convert.ToString(row["StudentName"]);
            student.DepartmentId = Convert.ToInt32(row["DepartmentId"]);

            return student;
        }

        public string CreateStudent(Student student)
        {

            sqlcommand = new SqlCommand("INSERT INTO Student (Id, StudentName, DepartmentId) VALUES (@Id, @StudentName, @DepartmentId)", conn);
            sqlcommand.Parameters.AddWithValue("@Id", student.Id);
            sqlcommand.Parameters.AddWithValue("@StudentName", student.StudentName);
            sqlcommand.Parameters.AddWithValue("@DepartmentId", student.DepartmentId);

            return _sqlRepository.Create(sqlcommand, STUDENT);
        }

        public string UpdateStudentById(int id, Student student)
        {
            sqlcommand = new SqlCommand("UPDATE Student SET StudentName = @StudentName  WHERE Id = @Id", conn);
            sqlcommand.Parameters.AddWithValue("@Id", id);
            sqlcommand.Parameters.AddWithValue("@StudentName", student.StudentName);

            return _sqlRepository.UpdateById(id, STUDENT, sqlcommand);
        }

        public string DeleteStudentById(int id)
        {
            return _sqlRepository.DeleteById(id, STUDENT);
        }

    }
}
