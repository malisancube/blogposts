using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Dinosaur.Model;
using Dinosaur.Server.Data;

namespace Dinosaur.Server
{
    public class CountryController : ApiController
    {
        private readonly DinosaurContext dataContext = new DinosaurContext();

        // GET api/country 
        public IEnumerable<Country> Get()
        {
            return dataContext.Countries;
        }

        // GET api/country/5 
        public Country Get(int id)
        {
            return dataContext.Countries.SingleOrDefault(d => d.Id == id);
        }

        // POST api/country 
        public void Post([FromBody]Country value)
        {
        }

        // PUT api/country/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/country/5 
        public void Delete(int id)
        {
            var value = dataContext.Countries.SingleOrDefault(d => d.Id == id);
            dataContext.Countries.Remove(value);
        }
    }
}
