using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Mammal : Animal
    {
        int Paws { get; set; }

        public Mammal(int Paws, string Name, bool IsTakenCare) : base(Name, IsTakenCare)
        {
            if (Paws < 1 || Paws > 20)
                throw new ArgumentOutOfRangeException();
            this.Paws = Paws;
        }

        public override string ToString()
        {
            return $"got {Paws} Paws";
        }
    }
}
