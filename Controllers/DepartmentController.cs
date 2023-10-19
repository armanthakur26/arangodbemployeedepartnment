using Arangodbcompany.Model;
using Arangodbcompany.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arangodbcompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentrepository _departmentrepository;
        public DepartmentController(IDepartmentrepository departmentrepository)
        {
            _departmentrepository = departmentrepository; 
        }
        [HttpGet]
        public IActionResult Getdepartment()
        {
            var dep = _departmentrepository.GetDepartments();
            return Ok(dep);
        }

        [HttpPost]
        public IActionResult addDepartment(Department department)
        {
            _departmentrepository.AddDepartment(department);
            return Ok(department);
        }
        [HttpPut]
        public IActionResult editdepartment([FromBody] Department department)
        {
            _departmentrepository.UpdateDepartment(department);
            return Ok(department);
        }

        [HttpDelete]
        public IActionResult deletedepartment(string _key)
        {
            _departmentrepository.DeleteDepartment(_key);
            return Ok("data delete successfully");
        }
        [HttpGet("_key")]
        public IActionResult getdepartment(string _key)
        {
            var dep = _departmentrepository.GetDepartment(_key);
            return Ok(dep);
        }
    }
}