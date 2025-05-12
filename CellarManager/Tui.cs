using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellarManager
{
    internal class Tui
    {
        private ILogic _logic;

        public Tui(ILogic logic) 
        {
            _logic = logic;
        }

        
    }
}
