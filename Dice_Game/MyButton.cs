using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice_Game
{
    public partial class MyButton : Button
    {
        public MyButton()
        {
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
