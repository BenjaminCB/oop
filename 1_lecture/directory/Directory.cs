using System;
using System.IO;

namespace directory
{
    public static class MyDirectory
    {
        public static void FileSizes()
        {
            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
            foreach (FileInfo File in di.GetFiles())
            {
                Console.WriteLine(File.Name + ": " + File.Length + "bytes");
            }
        }

        public static void Tree(DirectoryInfo path)
        {
            foreach (FileInfo File in path.GetFiles())
            {
                Console.WriteLine(File.Name);
            }

            foreach (DirectoryInfo Dir in path.GetDirectories())
            {
                Console.WriteLine(Dir.Name);
                Tree(Dir);
            }
        }
    }
}
