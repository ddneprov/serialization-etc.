using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Animals;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {

        private static string generateName(Random random)
        {
            string name = "";
            int l = 4 + random.Next(7);
            for (int i = 0; i < l; i++)
            {
                name += (char)('a' + random.Next(26));
            }
            return name;
        }

        static void Main(string[] args)
        {
            int N = 0;
            do
            {
                Console.WriteLine("Введите число животных");

                try
                {
                    N = Convert.ToInt32(Console.ReadLine());
                    if (N == 0)
                        throw new ArgumentException();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Введите корректные данные" + e.Message);                  
                }
            } while (N == 0);

            Zoo zoo = new Zoo();
            Random rnd = new Random();

            for (int i = 0; i < N; i++)
            {
                bool generated = false;
                while (!generated)
                {

                    try
                    {
                        string name = generateName(rnd);
                        bool IsTakenCare = rnd.Next(10) < 4; // 40%
                        int otherParam = rnd.Next(-10, 120);


                        if (rnd.Next(0, 2) == 0)
                        {
                            /// генерируем млекопитоющее
                            Mammal mammal = new Mammal(otherParam, name, IsTakenCare);
                            mammal.OnSound += (sender, eventArgs) => Console.WriteLine("Я млекопитающее, би-би-би");
                            zoo.animals.Add(mammal);
                        }
                        else
                        {
                            /// генерируем птичку
                            Bird bird = new Bird(otherParam, name, IsTakenCare);
                            bird.OnSound += (sender, eventArgs) => Console.WriteLine("Я птичка, пи-пи-пи");
                            zoo.animals.Add(bird);
                        }
                        generated = true;
                    }
                    catch (Exception)
                    {
                        // ignore 
                    }
                   
                }

                foreach (var animal in zoo.GetEnumerator())             
                    animal.DoSound();
                
                try
                {
                    using (var fs = new FileStream("../../../zooAnimal.ser", FileMode.Create))
                        new XmlSerializer(typeof(Animal[])).Serialize(fs, zoo.GetEnumerator().ToArray());
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
