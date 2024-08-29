using LibraryManagement.IRepository;
using LibraryManagement.Models;
using LibraryManagement.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        // GET: api/<DepartmentController>
        [HttpGet]
        public List<Department> Get()
        {
            return _departmentRepository.GetAllDepartments();
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public Department Get(int id)
        {
            return _departmentRepository.GetDepartmentById(id);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public string Post([FromBody] Department department)
        {
            return _departmentRepository.CreateDepartment(department);
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Department department)
        {
            return _departmentRepository.UpdateDepartmentById(id, department);
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _departmentRepository.DeleteDepartmentById(id);
        }
    }
}


