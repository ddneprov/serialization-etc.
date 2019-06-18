using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 0;
            Console.WriteLine("Введите значение N");

            while (!int.TryParse(Console.ReadLine(), out N) || N < 0)
            {
                Console.WriteLine("неподходящее значение");
            }


            List<Line> lines = new List<Line>(N);
            Random rnd = new Random();

            Console.WriteLine("lines.Count" + lines.Count); 
            for (int i = 0; i < lines.Capacity; i++)
            {
                double A, B, C;
                A = rnd.NextDouble() * rnd.Next(-10, 10);
                B = rnd.NextDouble() * rnd.Next(-10, 10);
                C = rnd.NextDouble() * rnd.Next(-10, 10);

                Line line = new Line(A, B, C);
                lines.Add(line);
            }

            for (int i = 0; i < lines.Capacity; i++)
            {
                Console.WriteLine(lines[i].ToString());
            }

            
            XmlSerializer xml = new XmlSerializer(typeof(List<Line>));
            Stream stream = null;
            try
            {
                xml.Serialize(stream = File.Create("../../../abc.xml"), lines);
            }
            catch ( IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                stream?.Close();
            }

            Console.ReadLine();
        }
    }
}
