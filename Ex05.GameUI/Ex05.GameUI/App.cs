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
          internal static void Run()
          {
               bool IsGameStillOn = true;

               // For more up to date visual effects
               Application.EnableVisualStyles();

               FormSettings formMemoryGameSettings = showAndGenerateFormSetting();
               
               do
               {
                    startNewGame(out IsGameStillOn, formMemoryGameSettings);
               }
               while (IsGameStillOn == true);
          }

          private static Game generateMemoryGameFromSettings(FormSettings i_FormMemoryGameSettings)
          {
               i_FormMemoryGameSettings.GetBoardMeasurements(out int[] boardMeasurements);
               List<int> memoryCards = GenerateMemoryCards(boardMeasurements[0] * boardMeasurements[1]);

               Game currentGame = new Game(
                   boardMeasurements,
                   memoryCards,
                   getPlayerNamesFromSettingsForm(i_FormMemoryGameSettings),
                   getPlayerTypesFromSettingsForm(i_FormMemoryGameSettings));

               return currentGame;
          }

          private static void startNewGame(out bool o_IsTheGameStillOn, FormSettings i_FormMemoryGameSettings)
          {
               o_IsTheGameStillOn = false;
             
               Game currentGame = generateMemoryGameFromSettings(i_FormMemoryGameSettings);
                    
               FormMemoryGame formMemoryGame = new FormMemoryGame(currentGame);
               showGameForm(formMemoryGame);

               if (formMemoryGame.DialogResult != DialogResult.Cancel)
               {
                    o_IsTheGameStillOn = askIfKeepPlaying();
               }
          }

          private static bool askIfKeepPlaying()
          {
               bool isKeepPlaying = false;

               DialogResult dialogRes = MessageBox.Show("Do you wish to play again?", "Memory Game - Rematch", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               isKeepPlaying = dialogRes == DialogResult.Yes;

               return isKeepPlaying;
          }

          private static GameLogic.Player.ePlayerType[] getPlayerTypesFromSettingsForm(FormSettings io_FormSettings)
          {
               GameLogic.Player.ePlayerType[] playerTypes = new Player.ePlayerType[2];

               // Working under the assumption that the first player stored in the array is a human player -  due to design
               playerTypes[0] = GameLogic.Player.ePlayerType.Human;
               playerTypes[1] = io_FormSettings.IsSecondPlayerComputer() ? GameLogic.Player.ePlayerType.Computer : GameLogic.Player.ePlayerType.Human;

               return playerTypes;
          }

          private static string[] getPlayerNamesFromSettingsForm(FormSettings io_FormSettings)
          {
               string[] playerNames = new string[2];

               playerNames[0] = io_FormSettings.Player1Name;
               playerNames[1] = io_FormSettings.Player2Name;

               return playerNames;
          }

          private static List<int> GenerateMemoryCards(int i_NumOfCards)
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

          private static void showGameForm(FormMemoryGame i_FormMemoryGame)
          {
               i_FormMemoryGame.ShowDialog();
          }

          private static FormSettings showAndGenerateFormSetting()
          {
               FormSettings settingsForm = new FormSettings();
               settingsForm.ShowDialog();

               return settingsForm;
          }
     }
}