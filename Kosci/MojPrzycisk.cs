using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kosci
{
    class MojPrzycisk : Button
    {
        public MojPrzycisk()
        {
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
