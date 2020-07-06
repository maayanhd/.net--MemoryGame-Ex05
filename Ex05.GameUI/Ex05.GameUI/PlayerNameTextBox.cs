using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex05.GameUI
{
     public class PlayerNameTextBox: TextBox
     {
          protected override void OnKeyPress(KeyPressEventArgs e)
          {
               base.OnKeyPress(e);

               if (char.IsLetter(e.KeyChar) == false && e.KeyChar != (char)8 )
               {
                    e.Handled = true;
               }
          }

          protected override void OnKeyDown(KeyEventArgs e)
          {
               base.OnKeyDown(e);

               if(e.KeyCode == Keys.ControlKey && e.KeyCode == Keys.V)
               {
                    e.Handled = true;
               }
          }
     }
}
