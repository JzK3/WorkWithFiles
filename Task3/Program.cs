namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var timeSpan = DateTime.Now - TimeSpan.FromMinutes(30);
                var di = new DirectoryInfo($"C:\\Users\\JzK\\Desktop\\Test3");
                Console.WriteLine("Size before delete - "+DirSize(di));
                Console.WriteLine("Deleted "+DirSize(di));
                if (di.Exists)
                {
                    foreach (DirectoryInfo directory in di.GetDirectories())
                    //удаление папок
                    {
                        if (directory.LastAccessTime < timeSpan) { directory.Delete(true); }
                    }
                    //удаление файлов
                    foreach (FileInfo file in di.GetFiles())
                    {
                        if (file.LastAccessTime < timeSpan) { file.Delete(); }
                    }
                    
                }
                else
                {
                    Console.WriteLine("File not found");
                }
                Console.WriteLine("Size after delete - " + DirSize(di));
            }
            catch (Exception) { Console.WriteLine("You haven't permission to change files"); }
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
            return Size;
        }
    }
}
