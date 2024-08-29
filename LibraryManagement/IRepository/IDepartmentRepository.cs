using LibraryManagement.Models;

namespace LibraryManagement.IRepository
{
    public interface IDepartmentRepository
    {
        public List<Department> GetAllDepartments();

        public Department GetDepartmentById(int id);

        public string CreateDepartment(Department department);

        public string UpdateDepartmentById(int id, Department department);

        public string DeleteDepartmentById(int id);
    }
}
