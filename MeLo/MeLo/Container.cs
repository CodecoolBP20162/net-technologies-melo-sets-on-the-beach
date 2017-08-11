using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeLo
{
    class Container
    {
        private static Container instance;
        private List<Folder> folders = new List<Folder>();

        private Container(){}

        public static Container Setup()
        {
            if (instance == null)
            {
                instance = new Container();
            }
            return instance;
        }

        public void Add(Folder folder)
        {
            folders.Add(folder);
        }
    }
}
