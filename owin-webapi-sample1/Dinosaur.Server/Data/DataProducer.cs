using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dinosaur.Model;

namespace Dinosaur.Server.Data
{
    public class DataProducer
    {
        private static DinosaurContext context = new DinosaurContext();

        public static void TryFill()
        {
            context.Database.CreateIfNotExists();
            if(!context.Countries.Any() && !context.People.Any())
                Fill();
        }

        private static void Fill()
        {
            var uganda = new Country {Id = 1, Name = "Uganda"};
            var kenya = new Country {Id = 2, Name = "Kenya"};
            var rwanda = new Country {Id = 3, Name = "Rwanda"};

            context.Countries.Add(uganda);
            context.Countries.Add(kenya);
            context.Countries.Add(rwanda);

            context.People.Add(new Person { FirstName = "John", LastName = "Doe", Country = uganda});
            context.People.Add(new Person{FirstName = "Jane", LastName = "Doe", Country = kenya});
            context.People.Add(new Person{FirstName = "Pete", LastName = "Lee", Country = uganda});
            context.People.Add(new Person { FirstName = "Anne", LastName = "Kim", Country = rwanda });

            context.SaveChanges();
        }
    }
}
