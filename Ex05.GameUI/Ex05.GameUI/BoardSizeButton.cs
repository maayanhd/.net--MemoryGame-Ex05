using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex05.GameUI
{
     public class BoardSizeButton: Button
     {
          private List<string> m_BoardSizeOptionsStrings = new List<string>();
          private int m_SizeBoardOptionCounter = 0;

          public BoardSizeButton(): base()
          {
               FillSizesOfBoardsStrings();
          }

          public void FillSizesOfBoardsStrings()
          {
               string rows = string.Empty, cols = string.Empty;
               string sizeOfBoardString = string.Format("{0}X{1}", rows, cols);

               //rows and cols number varies between 4 to 6
               //an odd number of cells is not possible (since a total number made out of pairs is even)

               for (int i = 4; i <= 6; i++)
               {
                    for (int j = 4; j <= 6; j++)
                    {
                         if (i * j % 2 == 0)
                         {
                              m_BoardSizeOptionsStrings.Add(string.Format("{0} X {1}", i, j));
                         }
                    }
               }
          }

          protected override void OnClick(EventArgs e)
          {
               base.OnClick(e);

               base.Text = m_BoardSizeOptionsStrings[indexOfNextBoardSizeString()];
          }
                   
          internal int indexOfNextBoardSizeString()
          {
               // Number of different sequences of 2 digits made out of 4, 5 or 6
               // The multiplication result of the 2 digit must be even (sum of pairs is even)
               // Decreasing the only odd option - 2 odd numbers 
               m_SizeBoardOptionCounter++;
               return m_SizeBoardOptionCounter % ((3 * 3) - 1);
          }
     }
}
