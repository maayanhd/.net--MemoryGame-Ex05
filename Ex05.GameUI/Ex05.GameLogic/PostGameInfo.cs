using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05.GameLogic
{
    public class PostGameInfo
    {
        private readonly Player r_Winner;
        private bool m_IsaDraw;

        public PostGameInfo(Player i_GameWinner, bool i_IsaDraw)
        {
            if(i_IsaDraw == false)
            {
                r_Winner = i_GameWinner;
            }

            m_IsaDraw = i_IsaDraw;
        }

        public bool IsaDraw
        {
            get
            {
                return m_IsaDraw;
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
