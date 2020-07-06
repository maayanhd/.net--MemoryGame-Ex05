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
        public static void Run()
        {
            bool IsGameStillOn = true;
            while(IsGameStillOn == true)
            {
                StartNewGame(out IsGameStillOn);

            }

        }
        public static void StartNewGame(out bool o_IsTheGameStillOn)
        {

            DialogResult dialogRes;
            o_IsTheGameStillOn = false;
            FormSettings settingsForm = new FormSettings();
            ShowFormSetting(settingsForm);
            dialogRes = settingsForm.DialogResult;
            if(dialogRes != DialogResult.Cancel)
            {
                settingsForm.GetBoardMeasurements(out int[] boardMeasurements);
                List<int> memoryCards = GenerateMemoryCards(boardMeasurements[0] * boardMeasurements[1]);
                Game currentGame = new Game(
                    boardMeasurements,
                    memoryCards,
                    GetPlayerNamesFromForm(settingsForm),
                    GetPlayerTypesFromForm(settingsForm));

                FormMemoryGame formMemoryGame = new FormMemoryGame(currentGame);
                ShowGameForm(formMemoryGame);
                dialogRes = formMemoryGame.DialogResult;
                if(dialogRes != DialogResult.Cancel)
                {
                    o_IsTheGameStillOn = AskIfKeepPlaying();
                }
            }

        }

        public static bool AskIfKeepPlaying()
        {
            bool keepPlaying = false;

            DialogResult dialogRes = MessageBox.Show("Do you wish to play again?", "Memory Game - Rematch", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            keepPlaying = dialogRes == DialogResult.Yes;

            return keepPlaying;
        }
        public static GameLogic.Player.ePlayerType[] GetPlayerTypesFromForm(FormSettings i_FormSettings)
        {
            GameLogic.Player.ePlayerType[] playerTypes = new Player.ePlayerType[2];

            playerTypes[0] = GameLogic.Player.ePlayerType.Human;
            playerTypes[1] = i_FormSettings.IsSecondPlayerComputer() ? GameLogic.Player.ePlayerType.Computer : GameLogic.Player.ePlayerType.Human;

            return playerTypes;
        }

        public static string[] GetPlayerNamesFromForm(FormSettings i_FormSettings)
        {
            string [] playerNames = new string[2];

            playerNames[0] = i_FormSettings.Player1Name;
            playerNames[1] = i_FormSettings.Player2Name;

            return playerNames;
        }

        public static void ShowGameForm(FormMemoryGame io_FormMemoryGame)
        {
            io_FormMemoryGame.ShowDialog();
        }

        internal static List<int> GenerateMemoryCards(int i_NumOfCards)
        {
            List<int> memoryCards = new List<int>();

            for (int i = 0; i < i_NumOfCards / 2; i++)
            {
                memoryCards.Add(i);
                memoryCards.Add(i);
            }

            return memoryCards;
        }

        public static void ShowFormSetting(FormSettings io_SettingsForm)
        {
            io_SettingsForm.ShowDialog();
        }



    }
}

