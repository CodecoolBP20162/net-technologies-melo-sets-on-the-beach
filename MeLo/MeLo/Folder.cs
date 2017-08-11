using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeLo
{
    public class Folder
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public Folder(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
}
