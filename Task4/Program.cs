using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Task4
{
    namespace ReadMyFile
    {
        class Program
        {

            public static void Main()
            {
                string filePath = "C:\\Users\\JzK\\Desktop\\BinaryReadWrite-master\\BinaryReadWrite\\SampleDataFile\\students.dat";

                if (File.Exists(filePath))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo("C:\\Users\\JzK\\Desktop\\Students");
                    Directory.CreateDirectory(directoryInfo.FullName);
                    using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                    {
                        
                        while (reader.PeekChar() > -1)
                        {
                            string Name = reader.ReadString();
                            string Group1 = reader.ReadString();
                            long DateOfBirth = reader.ReadInt64();
                            var ddbirth = DateTime.FromBinary(DateOfBirth);
                            decimal SrBall = reader.ReadDecimal();
                            Console.WriteLine($"Name: {Name}  Group: {Group1}  DateofBirth: {ddbirth}  SrBall: {SrBall}");
                            string stringValue = $"{Name} {ddbirth} {SrBall}";
                            using (StreamWriter sw = File.CreateText($"C:\\Users\\JzK\\Desktop\\Students\\{Group1}.txt"))
                            {
                                sw.WriteLine(stringValue);
                            }
                        }
                    }
                }
            }
        }

    }
}