using LibraryManagement.IRepository;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        [HttpGet]
        public List<Student> Get()
        {
            return _studentRepository.GetAllStudents();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _studentRepository.GetStudentById(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public string Post([FromBody] Student student)
        {
            return _studentRepository.CreateStudent(student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Student student)
        {
            return _studentRepository.UpdateStudentById(id, student);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _studentRepository.DeleteStudentById(id);
        }
    }
}
