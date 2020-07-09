using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Ex05.GameLogic;

namespace Ex05.GameUI
{
    internal class FormMemoryGame : Form
    {
        private const int k_BorderMargin = 16;
        private const int k_MarginBetweenObjects = 8;

        private readonly Color[] r_PlayerColors;
        private readonly Size r_ImageSize = new Size(80, 80);
        private readonly Timer r_ExposureTimer;
        private readonly CardButton[,] r_Board;
        private readonly Image[] r_CardImages;
        private readonly CardButton[] r_ChosenPair;
        private readonly Game r_CurrentGame;

        private Label m_LabelCurrentPlayer;
        private Label m_LabelFirstPlayer;
        private Label m_LabelSecondPlayer;
        private Player m_CurrentPlayer;
        
        public FormMemoryGame(Game i_CurrentGame) : base()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            int height = i_CurrentGame.Board.GetLength(0);
            int width = i_CurrentGame.Board.GetLength(1);

            r_CurrentGame = i_CurrentGame;
            r_PlayerColors = new Color[2];

            // For delay after exposing the second card if needed 
            r_ExposureTimer = new Timer();
            r_ExposureTimer.Interval = 750;

            m_CurrentPlayer = i_CurrentGame.Player1;
            r_ChosenPair = new CardButton[2];

            r_PlayerColors[0] = getLightGreenFromRgb();
            r_PlayerColors[1] = getLightPurpleFromRgb();

            r_Board = new CardButton[height, width];
            r_CardImages = new Image[(height * width) / 2];

            generateImagesArray();
            manageEventsJoining();
            initializeComponent();
        }

        private static System.Drawing.Color getLightGreenFromRgb()
        {
            return System.Drawing.Color.FromArgb(
                (int)((byte)192),
                (int)((byte)255),
                (int)((byte)192));
        }

        private static System.Drawing.Color getLightPurpleFromRgb()
        {
            return System.Drawing.Color.FromArgb(
                (int)((byte)192),
                (int)((byte)192),
                (int)((byte)255));
        }

        private static void hideCard(CardButton i_CardToHide)
        {
            if (i_CardToHide != null)
            {
                i_CardToHide.BackgroundImage = null;
                i_CardToHide.FlatAppearance.BorderColor = Color.Black;
                i_CardToHide.FlatAppearance.BorderSize = 1;
                i_CardToHide.Enabled = true;
            }
        }

        private static int getVisualLabelHeight(Label i_LabelToEstimate)
        {
            return i_LabelToEstimate.Height + k_MarginBetweenObjects;
        }

        private void manageEventsJoining()
        {
            r_CurrentGame.GameEnded += r_CurrentGame_GameEnded;
            r_CurrentGame.CardFlipped += r_CurrentGame_CardFlipped;
            r_CurrentGame.Player1.ScoreChanged += player_ScoreChanged;
            r_CurrentGame.Player2.ScoreChanged += player_ScoreChanged;
            r_ExposureTimer.Tick += exposureTimer_Tick;
        }

        private void r_CurrentGame_GameEnded(PostGameInfo i_PostGameInfo)
        {
            string endOfTheGameAnnouncement = "The game ended in a draw!";

            if (i_PostGameInfo.IsADraw == false)
            {
                string winnerName = i_PostGameInfo.Winner.IsComputer() == true ? "Computer" : i_PostGameInfo.Winner.Name;
                endOfTheGameAnnouncement = string.Format(
                    "{0} has won with a score of {1}",
                    winnerName,
                    i_PostGameInfo.Winner.Score);
            }

            MessageBox.Show(endOfTheGameAnnouncement, "Memory Game - Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        
        private void r_CurrentGame_CardFlipped(Cell i_CardFlipped)
        {
            int i = i_CardFlipped.Location.Row,
                j = i_CardFlipped.Location.Col;
            CardButton cardToFlip = r_Board[i, j];
            bool isCardFacingUpAfterFlipped = i_CardFlipped.IsFlipped;

            if (isCardFacingUpAfterFlipped)
            {
                exposeCard(cardToFlip);
            }
            else
            {
                hideCard(cardToFlip);
            }
        }

        private void player_ScoreChanged(int i_ScoreToUpdate)
        {
            string labelString = string.Format(
                "{0}: {1} Pairs",
                m_CurrentPlayer.Name,
                i_ScoreToUpdate);

            Label currentLabel =
                m_CurrentPlayer == r_CurrentGame.Player1 ? m_LabelFirstPlayer : m_LabelSecondPlayer;

            currentLabel.Text = labelString;
        }

        private void generateImagesArray()
        {
            for (int i = 0; i < r_CardImages.Length; i++)
            {
                PictureBox img = new PictureBox();
                img.Load("https://picsum.photos/80");
                r_CardImages[i] = img.Image;
            }
        }

        private void initializeComponent()
        {
            buildBoard();
            this.SuspendLayout();

            allocateControls();

            // m_LabelCurrentPlayer
            designLabelCurrentPlayer();

            // m_LabelFirstPlayer
            designLabelFirstPlayer();

            // m_LabelSecondPlayer
            designLabelSecondPlayer();

            // FormMemoryGame
            this.ClientSize = calcClientSize();
            addControlsToThisForm();

            designMemoryGameForm();
        }

        private void buildBoard()
        {
            int height = r_Board.GetLength(0);
            int width = r_Board.GetLength(1);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int locationFromTop = i > 0 ? r_Board[i - 1, j].Bottom + k_MarginBetweenObjects : k_BorderMargin,
                        locationFromLeft = j > 0 ? r_Board[i, j - 1].Right + k_MarginBetweenObjects : k_BorderMargin;

                    addCardButtonToBoard(i, j, locationFromLeft, locationFromTop);
                }
            }
        }

        private void addCardButtonToBoard(int i_HeightIdx, int i_WidthIdx, params int[] i_CardButtonLocation)
        {
            r_Board[i_HeightIdx, i_WidthIdx] = new CardButton(new Location(i_HeightIdx, i_WidthIdx));

            CardButton currentCardButton = r_Board[i_HeightIdx, i_WidthIdx];
            currentCardButton.BackgroundImage = null;
            currentCardButton.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top
                                                                              | System.Windows.Forms.AnchorStyles.Left
                                                                             | System.Windows.Forms.AnchorStyles.Right);
            currentCardButton.FlatStyle = FlatStyle.Flat;
            currentCardButton.Location = new System.Drawing.Point(i_CardButtonLocation[0], i_CardButtonLocation[1]);
            currentCardButton.Name = string.Format(
                "m_ButtonCard{0}{1}",
                i_HeightIdx,
                i_WidthIdx);
            currentCardButton.Size = r_ImageSize;
            currentCardButton.TabIndex = (i_HeightIdx * r_Board.GetLength(0)) + i_WidthIdx;
            currentCardButton.UseVisualStyleBackColor = true;
            currentCardButton.Click += new System.EventHandler(this.cardButton_Click);
            this.Controls.Add(r_Board[i_HeightIdx, i_WidthIdx]);
        }

        private void allocateControls()
        {
            this.m_LabelCurrentPlayer = new System.Windows.Forms.Label();
            this.m_LabelFirstPlayer = new System.Windows.Forms.Label();
            this.m_LabelSecondPlayer = new System.Windows.Forms.Label();
        }

        private void designLabelCurrentPlayer()
        {
            this.m_LabelCurrentPlayer.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom
                       | System.Windows.Forms.AnchorStyles.Left
                       | System.Windows.Forms.AnchorStyles.Right);
            this.m_LabelCurrentPlayer.AutoSize = true;
            this.m_LabelCurrentPlayer.BackColor = r_PlayerColors[0];
            this.m_LabelCurrentPlayer.Location = new System.Drawing.Point(k_BorderMargin, r_Board[r_Board.GetLength(0) - 1, 0].Bottom + k_BorderMargin);
            this.m_LabelCurrentPlayer.Name = "m_LabelCurrentPlayerName";
            this.m_LabelCurrentPlayer.Size = new System.Drawing.Size(243, 17);

            // Assuming the board size is under 100  - meaning less than 100 memory cards involved in the game
            this.m_LabelCurrentPlayer.Text = string.Format(
                "Current Player : {0}",
                m_CurrentPlayer.Name);
        }

        private void designLabelFirstPlayer()
        {
            this.m_LabelFirstPlayer.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom
           | System.Windows.Forms.AnchorStyles.Left
           | System.Windows.Forms.AnchorStyles.Right);
            this.m_LabelFirstPlayer.AutoSize = true;
            this.m_LabelFirstPlayer.BackColor = r_PlayerColors[0];
            this.m_LabelFirstPlayer.Location = new System.Drawing.Point(
                k_BorderMargin,
                m_LabelCurrentPlayer.Bottom + k_MarginBetweenObjects);
            this.m_LabelFirstPlayer.Name = "m_LabelFirstPlayerName";
            this.m_LabelFirstPlayer.Size = new System.Drawing.Size(188, 17);
            this.m_LabelFirstPlayer.Text = string.Format(
                "{0}: 0 Pairs",
                r_CurrentGame.Player1.Name);
        }

        private void designLabelSecondPlayer()
        {
            this.m_LabelSecondPlayer.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                                               | System.Windows.Forms.AnchorStyles.Left
                                               | System.Windows.Forms.AnchorStyles.Right);
            this.m_LabelSecondPlayer.AutoSize = true;
            this.m_LabelSecondPlayer.BackColor = r_PlayerColors[1];
            this.m_LabelSecondPlayer.Location = new System.Drawing.Point(k_BorderMargin, m_LabelFirstPlayer.Bottom + k_MarginBetweenObjects);
            this.m_LabelSecondPlayer.Name = "m_LabelFirstPlayerName";
            this.m_LabelSecondPlayer.Size = new System.Drawing.Size(135, 17);
            this.m_LabelSecondPlayer.Text = string.Format(
                "{0}: 0 Pairs",
                r_CurrentGame.Player2.Name);
        }

        private void addControlsToThisForm()
        {
            this.Controls.Add(this.m_LabelSecondPlayer);
            this.Controls.Add(this.m_LabelFirstPlayer);
            this.Controls.Add(this.m_LabelCurrentPlayer);
        }

        private void designMemoryGameForm()
        {
            this.Text = "Memory Game";
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormMemoryGame";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Size calcClientSize()
        {
            int formHeight = getVisualBoardHeight();

            formHeight += getVisualLabelHeight(m_LabelCurrentPlayer) + k_MarginBetweenObjects;
            formHeight += getVisualLabelHeight(m_LabelFirstPlayer);
            formHeight += getVisualLabelHeight(m_LabelSecondPlayer);

            return new Size(getVisualBoardWidth(), formHeight);
        }

        private int getVisualBoardHeight()
        {
            int pictureHeight = r_ImageSize.Height;

            return ((r_Board.GetLength(0) - 1) * k_MarginBetweenObjects) + (k_BorderMargin * 2) + (pictureHeight * r_Board.GetLength(0));
        }

        private int getVisualBoardWidth()
        {
            int pictureWidth = r_ImageSize.Width;

            return (k_BorderMargin * 2) + (pictureWidth * r_Board.GetLength(1)) + ((r_Board.GetLength(1) - 1) * k_MarginBetweenObjects);
        }

        private void cardButton_Click(object i_Sender, EventArgs i_E)
        {
            CardButton buttonClicked = i_Sender as CardButton;

            Location cardLocation = buttonClicked.CardLocation.Value;
            Cell cardCell = r_CurrentGame.GetCellByLocation(cardLocation);

            r_CurrentGame.FlipCard(cardCell);

            if (r_ChosenPair[0] == null)
            {
                // First card of the pair to be exposed
                r_ChosenPair[0] = buttonClicked;
            }
            else
            {
                r_ChosenPair[1] = buttonClicked;

                // disable the form in order to avoid unnecessary clicks //
                this.Enabled = false;
                r_ExposureTimer.Start();
            }
        }

        private void exposeCard(CardButton i_CardToExpose)
        {
            if (i_CardToExpose != null)
            {
                Location? cardLocation = i_CardToExpose.CardLocation;
                int cardContentId = r_CurrentGame.Board[cardLocation.Value.Row, cardLocation.Value.Col].CellContent;
                i_CardToExpose.BackgroundImage = r_CardImages[cardContentId];
                i_CardToExpose.FlatAppearance.BorderColor = getCurrentPlayerColor();
                i_CardToExpose.FlatAppearance.BorderSize = 5;
                i_CardToExpose.Enabled = false;
            }
        }

        private void exposureTimer_Tick(object i_Sender, EventArgs i_E)
        {
            Location firstCardLocation = r_ChosenPair[0].CardLocation.Value;
            Location secondCardLocation = r_ChosenPair[1].CardLocation.Value;
            Cell firstCardCell = r_CurrentGame.GetCellByLocation(firstCardLocation);
            Cell secondCardCell = r_CurrentGame.GetCellByLocation(secondCardLocation);

            bool isAMatch = r_CurrentGame.IsThereAMatch(m_CurrentPlayer, firstCardCell, secondCardCell);
            r_ExposureTimer.Stop();
            if (isAMatch == false)
            {
                r_CurrentGame.FlipCard(firstCardCell);
                r_CurrentGame.FlipCard(secondCardCell);

                switchPlayer();
            }

            r_CurrentGame.UpdateAvailableCards(isAMatch, firstCardCell, secondCardCell);
            r_CurrentGame.UpdateSeenCards(isAMatch, firstCardCell, secondCardCell);

            r_ChosenPair[0] = null;
            r_ChosenPair[1] = null;

            // turn back the form 
            this.Enabled = true;

            if (m_CurrentPlayer.IsComputer() && r_CurrentGame.IsTheGameEnded() == false)
            {
                computerTurn();
            }
        }

        private void computerTurn()
        {
            Cell[] computerMove = m_CurrentPlayer.ComputerMove(r_CurrentGame);
            Location firstCardLocation = computerMove[0].Location;
            Location secondCardLocation = computerMove[1].Location;

            r_Board[firstCardLocation.Row, firstCardLocation.Col].PerformClick();
            r_Board[secondCardLocation.Row, secondCardLocation.Col].PerformClick();
        }

        private void switchPlayer()
        {
            m_CurrentPlayer = m_CurrentPlayer == r_CurrentGame.Player1 ? r_CurrentGame.Player2 : r_CurrentGame.Player1;
            m_LabelCurrentPlayer.Text = string.Format("Current Player : {0}", m_CurrentPlayer.Name);
            m_LabelCurrentPlayer.BackColor = getCurrentPlayerColor();
        }

        private Color getCurrentPlayerColor()
        {
            Color currentPlayerColor = m_CurrentPlayer == r_CurrentGame.Player1 ? r_PlayerColors[0] : r_PlayerColors[1];

            return currentPlayerColor;
        }
    }
}
