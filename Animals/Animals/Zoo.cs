using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Zoo
    {
        public List<Animal> animals { get; }

        public Zoo()
        {
            List<Animal> animals = new List<Animal>();
        }

        public Zoo(List<Animal> animals)
        {
            this.animals = animals;
        }


        public IEnumerable<Animal> GetEnumerator()
        {
            return animals.ToList().OrderBy(animal => animal.Name.Length);
        }
    }
}
