using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ex05.GameLogic;

namespace Ex05.GameUI
{


     internal static class UI
     {
          public static void StartGame()
          {
               FormSettings settingsForm = new FormSettings();
               ShowFormSetting(settingsForm);

               settingsForm.GetBoardMeasurements(out int height, out int width);
               FormMemoryGame formMemoryGame = new FormMemoryGame(height, width);
               ShowGameForm(formMemoryGame);
          }
                    
          public static void ShowGameForm(FormMemoryGame io_FormMemoryGame)
          {
               io_FormMemoryGame.ShowDialog();
          }

          public static void ShowFormSetting(FormSettings io_SettingsForm)
          {
               io_SettingsForm.ShowDialog();
          }

     }
}

