using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex05.GameUI
{
     internal static class UI
     {
          public static void StartGame()
          {
               ShowFormSetting();
          }
          public static void ShowFormSetting()
          {
               Application.EnableVisualStyles();
               new FormSettings().ShowDialog();
          }         
     }
}
