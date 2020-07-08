using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05.GameLogic
{
    public class PostGameInfo
    {
        private readonly Player r_Winner;
        private bool m_IsADraw;
          
        public PostGameInfo(Player i_GameWinner, bool i_IsADraw)
        {
            if(i_IsADraw == false)
            {
                r_Winner = i_GameWinner;
            }

            m_IsADraw = i_IsADraw;
        }

        public bool IsaDraw
        {
            get
            {
                return m_IsADraw;
            }
        }

        public Player Winner
        {
            get
            {
                return r_Winner;
            }
        }
    }
}
