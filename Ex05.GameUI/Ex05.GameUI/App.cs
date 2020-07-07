using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ex05.GameLogic;

namespace Ex05.GameUI
{
     public static class App
     {
          public static void Run()
          {
               bool IsGameStillOn = true;

               // For more up to date visual effects
               Application.EnableVisualStyles();

               do
               {
                    StartNewGame(out IsGameStillOn);
               }
               while (IsGameStillOn == true);
          }

          public static void StartNewGame(out bool o_IsTheGameStillOn)
          {
               DialogResult dialogRes;
               o_IsTheGameStillOn = false;
               FormSettings settingsForm = new FormSettings();

               ShowFormSetting(settingsForm);
               dialogRes = settingsForm.DialogResult;

               if (dialogRes != DialogResult.Cancel)
               {
                    settingsForm.GetBoardMeasurements(out int[] boardMeasurements);
                    List<int> memoryCards = GenerateMemoryCards(boardMeasurements[0] * boardMeasurements[1]);
                    Game currentGame = new Game(
                        boardMeasurements,
                        memoryCards,
                        GetPlayerNamesFromSettingsForm(settingsForm),
                        GetPlayerTypesFromSettingsForm(settingsForm));

                    FormMemoryGame formMemoryGame = new FormMemoryGame(currentGame);
                    ShowGameForm(formMemoryGame);
                    dialogRes = formMemoryGame.DialogResult;
                    if (dialogRes != DialogResult.Cancel)
                    {
                         o_IsTheGameStillOn = AskIfKeepPlaying();
                    }
               }
          }

          internal static bool AskIfKeepPlaying()
          {
               bool isKeepPlaying = false;

               DialogResult dialogRes = MessageBox.Show("Do you wish to play again?", "Memory Game - Rematch", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               isKeepPlaying = dialogRes == DialogResult.Yes;

               return isKeepPlaying;
          }

          public static GameLogic.Player.ePlayerType[] GetPlayerTypesFromSettingsForm(FormSettings io_FormSettings)
          {
               GameLogic.Player.ePlayerType[] playerTypes = new Player.ePlayerType[2];

               // Working under the assumption that the first player stored in the array is a human player -  due to design
               playerTypes[0] = GameLogic.Player.ePlayerType.Human;
               playerTypes[1] = io_FormSettings.IsSecondPlayerComputer() ? GameLogic.Player.ePlayerType.Computer : GameLogic.Player.ePlayerType.Human;

               return playerTypes;
          }

          public static string[] GetPlayerNamesFromSettingsForm(FormSettings io_FormSettings)
          {
               string[] playerNames = new string[2];

               playerNames[0] = io_FormSettings.Player1Name;
               playerNames[1] = io_FormSettings.Player2Name;

               return playerNames;
          }

          internal static List<int> GenerateMemoryCards(int i_NumOfCards)
          {
               List<int> memoryCards = new List<int>();

               for (int i = 0; i < i_NumOfCards / 2; i++) 
               {
                    // Adding a couple of integers representing a matching memory cards pair id number
                    memoryCards.Add(i);
                    memoryCards.Add(i);
               }

               return memoryCards;
          }

          internal static void ShowGameForm(FormMemoryGame i_FormMemoryGame)
          {
               i_FormMemoryGame.ShowDialog();
          }

          internal static void ShowFormSetting(FormSettings io_SettingsForm)
          {
               io_SettingsForm.ShowDialog();
          }
     }
}