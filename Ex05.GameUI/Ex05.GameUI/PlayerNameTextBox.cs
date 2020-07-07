using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex05.GameUI
{
     public class PlayerNameTextBox : TextBox
     {
          protected override void OnKeyPress(KeyPressEventArgs e)
          {
               base.OnKeyPress(e);

               ////Preventing the user to enter other characters than letters
               ////also preventing using other controls except for the backspace key (with an ASCII code of 8)
               if (char.IsLetter(e.KeyChar) == false && e.KeyChar != (char)8 )
               {
                    e.Handled = true;
               }
          }

          protected override void OnKeyDown(KeyEventArgs e)
          {
               base.OnKeyDown(e);

               // Preventing the combination of Ctrl + V to avoid pasting illegal characters to the name text box
               if(e.KeyCode == Keys.ControlKey && e.KeyCode == Keys.V)
               {
                    e.Handled = true;
               }
          }
     }
}
