using System.IO;

namespace Menu
{
    class DirectoryItem : Menu, IMenuItem
    {
        private DirectoryInfo _Dir;

        public DirectoryItem(DirectoryInfo dir) : base("Directory: " + dir.Name)
        {
            _Dir = dir;
        }

        public override void Select()
        {
            foreach (DirectoryInfo dir in _Dir.EnumerateDirectories())
            {
                Items.Add(new DirectoryItem(dir));
            }

            foreach (FileInfo file in _Dir.EnumerateFiles())
            {
                Items.Add(new FileItem(file));
            }

            base.Select();
        }
    }
}
