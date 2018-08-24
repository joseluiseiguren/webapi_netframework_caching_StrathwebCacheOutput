using System.Linq;
using System.Web.Http;
using WebApi.OutputCache.V2;
using webapiexample.Models;
using webapiexample.Repository;

namespace webapiexample.Controllers
{
    //invalida el cache si se hace cualquier operacion de modifcacion de datos
    [AutoInvalidateCacheOutput] 
    public class PersonsController : ApiController
    {
        [HttpGet]
        [CacheOutput(ServerTimeSpan = 30)]
        public IHttpActionResult Get()
        {
            var personRepository = new PersonRepository();

            var persons = personRepository.GetByFilter();

            return this.Ok(persons);
        }

        [HttpGet]
        [CacheOutput(ServerTimeSpan = 30)]
        public IHttpActionResult Get(int id)
        {
           var personRepository = new PersonRepository();

            var persons = personRepository.GetByFilter().ToList();

            return this.Ok(persons[0]);
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody] string personname)
        {
            var personRepository = new PersonRepository();

            var person = new Person();
            person.Name = personname;
            personRepository.Update(person);

            return this.Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var personRepository = new PersonRepository();

            var person = new Person();
            person.Name = "";
            personRepository.Update(person);

            return this.Ok();
        }
    }
}
