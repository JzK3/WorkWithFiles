using System.Text.Encodings.Web;
using static System.Net.Mime.MediaTypeNames;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string path = @"C:\\Users\\JzK\\Desktop\\Test";
                if (Directory.Exists(path))
                {
                    var size = new DirectoryInfo(path);
                    DirSize(size);
                }
                else
                {
                    Console.WriteLine("File not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("You haven't permission to change files");
            }
            }
            static long DirSize(DirectoryInfo dir)
        {
            long Size = 0;
            FileInfo[] fis = dir.GetFiles();
            foreach (FileInfo fi in fis)
            {
                Size += fi.Length;
            }

            DirectoryInfo[] dis = dir.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                Size += DirSize(di);
            }
            if (Size > 0) { Console.WriteLine($"Total size of files and directories {Size} bytes"); }
            return Size;
        }
    }
}
