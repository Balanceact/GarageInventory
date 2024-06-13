using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageInventory
{
    internal class Manager
    {
        private IUI _ui;

        public IUI UI { get { return _ui; } }

        public Manager(IUI ui)
        {
            _ui = ui;
        }
        public void Run()
        {
            Initialize();
            Menu();

        }

        private void Initialize()
        {
            
        }

        public void Menu()
        {
            PrintMenu();
        }

        public void PrintMenu()
        {
            UI.Write("");
        }
    }
}
