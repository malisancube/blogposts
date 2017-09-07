using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Dinosaur.Model;
using Dinosaur.Server.Data;

namespace Dinosaur.Server.api
{
    public class PersonController : ApiController
    {
        private readonly DinosaurContext dataContext = new DinosaurContext();

        // GET api/person    
        public IEnumerable<Person> Get()
        {
            return dataContext.People.Include("Country");
        }

        // GET api/person/5 
        public Country Get(int id)
        {
            return dataContext.Countries.Include("Country").SingleOrDefault(d => d.Id == id);
        }

        // POST api/person 
        public void Post([FromBody]Person value)
        {
            dataContext.People.Add(value);
            dataContext.SaveChanges();
        }

        // PUT api/person/5 
        public void Put(int id, [FromBody]Person value)
        {

        }

        // DELETE api/person/5 
        public void Delete(int id)
        {
            var value = dataContext.People.SingleOrDefault(d => d.Id == id);
            dataContext.People.Remove(value);
            dataContext.SaveChanges();
        }
    }
}
