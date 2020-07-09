using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex05.GameUI
{
     public class PlayerNameTextBox : TextBox
     {
          protected override void OnKeyPress(KeyPressEventArgs i_E)
          {
               base.OnKeyPress(i_E);

               // Preventing the user to enter other characters than letters
               // Also preventing using other controls except for the backspace key (with an ASCII code of 8)
               if (char.IsLetter(i_E.KeyChar) == false && i_E.KeyChar != (char)8 )
               {
                    i_E.Handled = true;
               }
          }

          protected override void OnKeyDown(KeyEventArgs i_E)
          {
               base.OnKeyDown(i_E);

               // Preventing the combination of Ctrl + V to avoid pasting illegal characters to the name text box
               if(i_E.KeyCode == Keys.ControlKey && i_E.KeyCode == Keys.V)
               {
                    i_E.Handled = true;
               }
          }
     }
}
