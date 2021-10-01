using System.IO;

namespace Menu
{
    class DirectoryMenu : Menu
    {
        private DirectoryInfo _Dir;

        public DirectoryMenu(DirectoryInfo dir) : base("Directory: " + dir.Name)
        {
            _Dir = dir;
        }

        public override void Select()
        {
            foreach (DirectoryInfo dir in _Dir.EnumerateDirectories())
            {
                Items.Add(new DirectoryMenu(dir));
            }

            foreach (FileInfo file in _Dir.EnumerateFiles())
            {
                Items.Add(new FileItem(file));
            }

            base.Select();
        }
    }
}
