using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _05_LinqWithXML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string studentsXML =
                @"<Students>
                    <Student>
                        <Id>0</Id>
                        <Name>Tara</Name>
                        <Age>20</Age>
                        <University>Harvard</University>
                    </Student>
                    <Student>
                        <Id>1</Id>
                        <Name>Carla</Name>
                        <Age>18</Age>
                        <University>Yalo</University>
                    </Student>
                    <Student>
                        <Id>2</Id>
                        <Name>Ming</Name>
                        <Age>44</Age>
                        <University>Peking</University>
                    </Student>
                </Students>";

            XDocument stdXDocument = new XDocument();
            stdXDocument = XDocument.Parse(studentsXML);

            var students = from student in stdXDocument.Descendants("Student")
                           select new
                           {
                               Id = student.Element("Id").Value,
                               Name = student.Element("Name").Value,
                               Age = student.Element("Age").Value,
                               University = student.Element("University").Value
                           };

            foreach (var student in students)
            {
                Console.WriteLine("Student {0} with id {1}, age {2} from university {3}", student.Name, student.Id, student.Age, student.University);
            }


            var studentsSortedByAge = from student in students orderby student.Age select student;

            foreach (var student in studentsSortedByAge)
            {
                Console.WriteLine("Student {0} with id {1}, age {2} from university {3}", student.Name, student.Id, student.Age, student.University);
            }

            Console.ReadKey();
        }
    }
}
