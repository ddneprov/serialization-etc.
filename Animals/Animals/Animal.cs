using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{

    [Serializable]
    public abstract class Animal
    {
        private static int _id = 1;
        public int ID { get; set; }
        public string Name { get; set; }
        public  bool IsTakenCare { get; set; }
        public event EventHandler OnSound;

        public Animal()
        {

        }

        public Animal(string Name, bool IsTakenCare)
        {
            ID = ++_id;
            this.Name = Name;
            this.IsTakenCare = IsTakenCare;
        }

        public override string ToString()
        {
            return $"\t Name = {Name},\t  ID = {ID},\t  IsTakenCare = {(IsTakenCare ? "YES" : "NO")}";
        }

        public virtual void DoSound()
        {
            OnSound?.Invoke(this, EventArgs.Empty);
        }

    }
}
