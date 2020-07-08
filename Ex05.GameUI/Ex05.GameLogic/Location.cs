using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05.GameLogic
{
     public struct Location
     {
          public int m_Row;
          public int m_Col;

          public Location(int i_Row, int i_Col)
          {
               m_Row = i_Row;
               m_Col = i_Col;
          }

          public int Row
          {
               get
               {
                    return m_Row;
               }

               internal set
               {
                    m_Row = value;
               }
          }

          public int Col
          {
               get
               {
                    return m_Col;
               }

               internal set
               {
                    m_Col = value;
               }
          }
     }
}
