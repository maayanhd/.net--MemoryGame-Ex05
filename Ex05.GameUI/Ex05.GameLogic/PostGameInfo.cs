using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05.GameLogic
{
    public class PostGameInfo
    {
        private readonly Player r_Winner;
        private bool m_IsDraw;

        public PostGameInfo(Player i_GameWinner, bool i_IsDraw)
        {
            if(i_IsDraw == false)
            {
                r_Winner = i_GameWinner;
            }

            m_IsDraw = i_IsDraw;
        }

        public bool IsDraw
        {
            get
            {
                return m_IsDraw;
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
