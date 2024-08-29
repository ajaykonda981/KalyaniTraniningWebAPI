using LibraryManagement.Models;
using System.Data.SqlClient;
using System.Data;
using LibraryManagement.IRepository;

namespace LibraryManagement.Repository
{
    public class DepartmentRepository: IDepartmentRepository
    {
        SqlConnection conn = new SqlConnection("Server=INDRANI; Database = LibraryManagement; Trusted_Connection = true");
        SqlCommand? sqlcommand;
        DataSet dataSet = new DataSet();
        DataTable dataTable = new DataTable();
        const string DEPARTMENT = "DEPARTMENT";
        private SqlRepository _sqlRepository = new SqlRepository();
        public DepartmentRepository()
        {
        } 

        public List<Department> GetAllDepartments()
        {

            List<Department> departments = new List<Department>();

            conn.Open();

            sqlcommand = new SqlCommand("SELECT * FROM DEPARTMENT", conn);

            dataTable = _sqlRepository.Get(sqlcommand);

            foreach (DataRow row in dataTable.Rows)
            {
                Department department = new Department();
                department.Id = Convert.ToInt32(row["Id"]);
                department.DepartmentName = Convert.ToString(row["DepartmentName"]);
                
                departments.Add(department);
            };

            return departments;
        }

        public Department GetDepartmentById(int id)
        {
            conn.Open();

            sqlcommand = new SqlCommand("SELECT * FROM DEPARTMENT WHERE Id = @Id", conn);
            sqlcommand.Parameters.AddWithValue("@Id", id);

            dataTable = _sqlRepository.Get(sqlcommand);

            DataRow row = dataTable.Rows[0];

            Department department = new Department
            {
                Id = Convert.ToInt32(row["Id"]),
                DepartmentName = Convert.ToString(row["DepartmentName"])
            };

            return department;
        }

        public string CreateDepartment(Department department)
        {
            sqlcommand = new SqlCommand("INSERT INTO DEPARTMENT (Id, DepartmentName) VALUES (@Id, @DepartmentName)", conn);
            sqlcommand.Parameters.AddWithValue("@Id", department.Id);
            sqlcommand.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);

            return _sqlRepository.Create(sqlcommand, DEPARTMENT);
        }

        public string UpdateDepartmentById(int id, Department department)
        {
            sqlcommand = new SqlCommand("UPDATE DEPARTMENT SET DepartmentName = @DepartmentName  WHERE Id = @Id", conn);
            sqlcommand.Parameters.AddWithValue("@Id", id);
            sqlcommand.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);

            return _sqlRepository.UpdateById(id, DEPARTMENT, sqlcommand);
        }

        public string DeleteDepartmentById(int id)
        {
            return _sqlRepository.DeleteById(id, DEPARTMENT);
        }
    }
}
