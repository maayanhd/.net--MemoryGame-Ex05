using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ex05.GameLogic
{
     public class Cell
     {
          private int m_CellContent;
          private bool m_IsFlipped = false;
          private Location m_Location;

          public Cell(int i_CellContent, Location i_Location)
          {
              m_Location = i_Location;
              m_CellContent = i_CellContent;
          }

          public int CellContent
          {
               get
               {
                    return m_CellContent;
               }

               internal set
               {
                    m_CellContent = value;
               }
          }

          public bool IsFlipped
          {
               get
               {
                    return m_IsFlipped;
               }

               internal set
               {
                    m_IsFlipped = value;
               }
          }

          public Location Location
          {
               get
               {
                    return m_Location;
               }

               internal set
               {
                    m_Location = value;
               }
          }
     }
}
