using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Bird : Animal
    {
        int Speed { get; set; }
        public Bird(int Speed, string Name, bool IsTakenCare):base( Name,  IsTakenCare)
        {
            if (Speed > 100 || Speed < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.Speed = Speed;
        }

        public override string ToString()
        {
            return $"Bird Speed = {Speed}";
        }
    }
}
