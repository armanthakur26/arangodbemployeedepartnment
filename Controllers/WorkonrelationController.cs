using Arangodbcompany.Model;
using Arangodbcompany.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arangodbcompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkonrelationController : ControllerBase
    {
        private readonly IWorkonrepository _workonrepository;
        public WorkonrelationController(IWorkonrepository workonrepository)
        {
            _workonrepository = workonrepository;
        }
        [HttpGet]
        public IActionResult GetworkRelation()
        {
            var work = _workonrepository.GetWorkRelation();
            return Ok(work);
        }
        [HttpPost]
        public IActionResult addworkRelation(Workon workon)
        {
            _workonrepository.addWorkRelation(workon);
            return Ok(workon);
        }
        [HttpDelete]
        public IActionResult deleterelation(string _key)
        {
            _workonrepository.deleteRelation(_key);
            return Ok("relation delete successfully");
        }

    }
}
