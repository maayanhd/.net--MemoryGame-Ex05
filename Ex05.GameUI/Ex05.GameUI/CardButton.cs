using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Ex05.GameLogic;

namespace Ex05.GameUI
{
    public class CardButton : Button
    {
        private readonly Location? r_CardLocation;

        public CardButton(Location? i_CardLocation)
            : base()
        {
            r_CardLocation = i_CardLocation;
        }

        public Location? CardLocation
        {
            get
            {
                return r_CardLocation;
            }
        }
    }
}
