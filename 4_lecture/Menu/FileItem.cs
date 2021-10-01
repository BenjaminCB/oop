using System;
using System.IO;
using System.Text;

namespace Menu
{
    class FileItem : IMenuItem
    {
        public string Title { get => "File: " + _File.Name; }
        private FileInfo _File;

        public FileItem(FileInfo file)
        {
            _File = file;
        }

        public void Select() {}

        public void Draw()
        {
            FileStream fs = _File.OpenRead();
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);

            Console.Clear();

            while (fs.Read(b, 0, b.Length) > 0)
            {
                Console.WriteLine(temp.GetString(b));
            }
        }

        public void MoveUp() {}
        public void MoveDown() {}
    }
}
