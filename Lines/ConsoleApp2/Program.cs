using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Line> lines = new List<Line>();
            XmlSerializer xml = new XmlSerializer(typeof(List<Line>));
            Stream stream = null;
            try
            {
                 lines = (List<Line>)xml.Deserialize(stream = File.OpenRead("../../../abc.xml"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Что то пошло не так" + ex.Message);
            }

           // Console.WriteLine("lines.Capacity   " + lines.Capacity);
           // Console.WriteLine("lines.Count   " + lines.Count);


            for (int i = 0; i < lines.Count; i++)
            {
                Console.WriteLine(lines[i].ToString());
            }

            


            int X = 0;
            int Y = 0;
            Console.WriteLine("Введите значение X и Y");

            while (!int.TryParse(Console.ReadLine(), out X))
            {
                Console.WriteLine("неподходящее значение для X");
            }

            while (!int.TryParse(Console.ReadLine(), out Y))
            {
                Console.WriteLine("неподходящее значение для Y");
            }


            Point point = new Point(X, Y);

            var sorted_lines = lines.OrderBy(l => point%l);



            Console.WriteLine("-----------------");
            foreach (var ten in sorted_lines)
            {
                Console.WriteLine(ten.ToString() +"\t\t" + (point % ten));
            }
               

            Console.ReadLine();
        }
    }
}