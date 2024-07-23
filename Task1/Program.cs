using static System.Net.Mime.MediaTypeNames;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var timeSpan = DateTime.Now - TimeSpan.FromMinutes(1);
                var di = new DirectoryInfo($"C:\\Users\\JzK\\Desktop\\Test");
                if (di.Exists)
                {
                    Console.WriteLine("File Exists");
                    foreach (DirectoryInfo directory in di.GetDirectories())
                    {
                        if (directory.LastAccessTime < timeSpan) {directory.Delete();}
                    }
                    foreach (FileInfo file in di.GetFiles())
                    {
                        if (file.LastAccessTime < timeSpan) { file.Delete(); }
                    }
                }
                else
                {
                    Console.WriteLine("File not found");
                }
            }
            catch (Exception ex) { Console.WriteLine("You haven't permission to change files"); }
        }
    }
}
