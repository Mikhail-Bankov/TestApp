using Microsoft.AspNetCore.Mvc;

namespace TestApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestAppController : ControllerBase
    {
        // GET: api/<TestAppController>
        [HttpGet]
        public string Get()
        {
            // Вызываем метод ReturnAllVersions, возвращающий список всех версий
            return SQLMethods.ReturnAllVersions();
        }

        // GET api/<TestAppController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            // Передаем методу ReturnCustomVersion запрашиваемый номер версии
            return SQLMethods.ReturnCustomVersion(id);
        }

        // POST api/<TestAppController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestAppController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestAppController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
