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
        private Location? m_CardLocation;

        public CardButton(Location? i_CardLocation)
            : base()
        {
            m_CardLocation = i_CardLocation;
        }

        public Location? CardLocation
        {
            get
            {
                return m_CardLocation;
            }
        }
    }
}
