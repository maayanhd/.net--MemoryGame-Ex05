using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Ex05.GameLogic;

namespace Ex05.GameUI
{
    class FormMemoryGame : Form
    {
        private Label m_LabelCurrentPlayerName;
        private Label m_LabelFirstPlayer;
        private CardButton[,] m_Board;
        private Label m_LabelSecondPlayerName;

        private Game m_CurrentGame;
        private Image [] m_CardImages;

        private readonly Color[] r_PlayerColors;
        private readonly int r_BorderMargin = 16;
        private readonly int r_MarginBetweenObjects = 8;
        private readonly Size r_ImageSize = new Size(80,80);

        private readonly Timer r_ExposureTimer;
        private Player m_CurrentPlayer;
        private CardButton[] m_ChosenPair;

        public FormMemoryGame(Game i_CurrentGame) : base()
        {

            this.StartPosition = FormStartPosition.CenterScreen;

            int height = i_CurrentGame.Board.GetLength(0);
            int width = i_CurrentGame.Board.GetLength(1);
            m_CurrentGame = i_CurrentGame;
            r_PlayerColors = new Color[2];

            m_CurrentGame.GameEnded += m_CurrentGame_GameEnded;
            r_ExposureTimer = new Timer();
            r_ExposureTimer.Interval = 750;
            r_ExposureTimer.Tick += exposureTimer_Tick;

            i_CurrentGame.Player1.ScoreChanged += Player_ScoreChanged;
            i_CurrentGame.Player2.ScoreChanged += Player_ScoreChanged;
            m_CurrentPlayer = i_CurrentGame.Player1;
            m_ChosenPair = new CardButton[2];

            r_PlayerColors[0] = System.Drawing.Color.FromArgb(
                ((int)(((byte)(192)))),
                ((int)(((byte)(255)))),
                ((int)(((byte)(192)))));

            r_PlayerColors[1] = System.Drawing.Color.FromArgb(
                ((int)(((byte)(192)))),
                ((int)(((byte)(192)))),
                ((int)(((byte)(255)))));

            m_Board = new CardButton[height, width];
            m_CardImages = new Image[(height*width)/2];
            GenerateImagesArray();
            InitializeComponent();
        }

        private void m_CurrentGame_GameEnded(PostGameInfo i_PostGameInfo)
        {
            string endOfTheGameAnnouncement = "The game ended in a draw!";

            if (i_PostGameInfo.IsDraw == false)
            {
                endOfTheGameAnnouncement = string.Format(
                    "{0} has won with a score of {1}",
                    i_PostGameInfo.Winner.Name,
                    i_PostGameInfo.Winner.Score);
            }

            MessageBox.Show(endOfTheGameAnnouncement, "Memory Game - Result", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Player_ScoreChanged(int i_ScoreToUpdate)
        {
            string labelString = string.Format(
                "{0}: {1} Pairs",
                m_CurrentPlayer.Name, i_ScoreToUpdate);

            Label currentLabel =
                m_CurrentPlayer == m_CurrentGame.Player1 ? m_LabelFirstPlayer : m_LabelSecondPlayerName;

            currentLabel.Text = labelString;

        }

        internal void GenerateImagesArray()
        {
            for(int i = 0; i < m_CardImages.Length; i++)
            {
                PictureBox img = new PictureBox();
                img.Load("https://picsum.photos/80");
                m_CardImages[i] = img.Image;
            }
        }

        internal void BuildBoard()
        {
            int height = m_Board.GetLength(0);
            int width = m_Board.GetLength(1);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int locationFromTop = i > 0 ? m_Board[i - 1, j].Bottom + r_MarginBetweenObjects : r_BorderMargin,
                        locationFromLeft = j > 0 ? m_Board[i, j - 1].Right + r_MarginBetweenObjects : r_BorderMargin;
                    
                    AddCardButtonToBoard(i,j, locationFromLeft,locationFromTop);
                }
            }
        }

        void AddCardButtonToBoard(int i_HeightIdx, int i_WidthIdx,params int [] i_CardButtonLocation)
        {
            m_Board[i_HeightIdx, i_WidthIdx] = new CardButton(new Location(i_HeightIdx, i_WidthIdx));
            CardButton currentCardButton = m_Board[i_HeightIdx, i_WidthIdx];
            currentCardButton.BackgroundImage = null;
            currentCardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top)
                                                                              | System.Windows.Forms.AnchorStyles.Left)
                                                                             | System.Windows.Forms.AnchorStyles.Right)));
            currentCardButton.FlatStyle = FlatStyle.Flat;
            currentCardButton.Location = new System.Drawing.Point(i_CardButtonLocation[0], i_CardButtonLocation[1]);
            currentCardButton.Name = string.Format("m_ButtonCard{0}{1}",i_HeightIdx,i_WidthIdx);
            currentCardButton.Size = r_ImageSize;
            currentCardButton.TabIndex = i_HeightIdx + i_WidthIdx;
            currentCardButton.UseVisualStyleBackColor = true;
            currentCardButton.Click += new System.EventHandler(this.cardButton_Click);
            this.Controls.Add(m_Board[i_HeightIdx, i_WidthIdx]);
        }

        private void InitializeComponent()
        {
            
            BuildBoard();
            this.SuspendLayout();

            this.m_LabelCurrentPlayerName = new System.Windows.Forms.Label();
            this.m_LabelFirstPlayer = new System.Windows.Forms.Label();
            this.m_LabelSecondPlayerName = new System.Windows.Forms.Label();
            // 
            // m_LabelCurrentPlayerName
            // 
            this.m_LabelCurrentPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Bottom)
         | System.Windows.Forms.AnchorStyles.Left)
         | System.Windows.Forms.AnchorStyles.Right)));
            this.m_LabelCurrentPlayerName.AutoSize = true;
            this.m_LabelCurrentPlayerName.BackColor = r_PlayerColors[0] ;
            this.m_LabelCurrentPlayerName.Location = new System.Drawing.Point(r_BorderMargin, m_Board[m_Board.GetLength(0)-1,0].Bottom + r_BorderMargin);
            this.m_LabelCurrentPlayerName.Name = "m_LabelCurrentPlayerName";
            this.m_LabelCurrentPlayerName.Size = new System.Drawing.Size(243, 17);
            this.m_LabelCurrentPlayerName.TabIndex = 0;
            this.m_LabelCurrentPlayerName.Text = string.Format("Current Player : {0}",m_CurrentPlayer.Name);
            // 
            // m_LabelFirstPlayer
            // 
            this.m_LabelFirstPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Bottom)
         | System.Windows.Forms.AnchorStyles.Left)
         | System.Windows.Forms.AnchorStyles.Right)));
            this.m_LabelFirstPlayer.AutoSize = true;
            this.m_LabelFirstPlayer.BackColor = r_PlayerColors[0];
            this.m_LabelFirstPlayer.Location = new System.Drawing.Point(
                r_BorderMargin,
                m_LabelCurrentPlayerName.Bottom + r_MarginBetweenObjects);
            this.m_LabelFirstPlayer.Name = "m_LabelFirstPlayerName";
            this.m_LabelFirstPlayer.Size = new System.Drawing.Size(188, 17);
            this.m_LabelFirstPlayer.TabIndex = 150;
            this.m_LabelFirstPlayer.Text = string.Format(
                "{0}: 0 Pairs",
                m_CurrentGame.Player1.Name);
            // 
            // m_LabelSecondPlayerName
            // 
            this.m_LabelSecondPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
         | System.Windows.Forms.AnchorStyles.Left)
         | System.Windows.Forms.AnchorStyles.Right)));
            this.m_LabelSecondPlayerName.AutoSize = true;
            this.m_LabelSecondPlayerName.BackColor = r_PlayerColors[1];
            this.m_LabelSecondPlayerName.Location = new System.Drawing.Point(r_BorderMargin, m_LabelFirstPlayer.Bottom + r_MarginBetweenObjects);
            this.m_LabelSecondPlayerName.Name = "m_LabelFirstPlayerName";
            this.m_LabelSecondPlayerName.Size = new System.Drawing.Size(135, 17);
            this.m_LabelSecondPlayerName.TabIndex = 200;
            this.m_LabelSecondPlayerName.Text = string.Format(
                "{0}: 0 Pairs",
                m_CurrentGame.Player2.Name);
            // 
            // FormMemoryGame
            this.ClientSize = calcClientSize();
            this.Controls.Add(this.m_LabelSecondPlayerName);
            this.Controls.Add(this.m_LabelFirstPlayer);
            this.Controls.Add(this.m_LabelCurrentPlayerName);
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormMemoryGame";
            this.Load += new System.EventHandler(this.formMemoryGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Size calcClientSize()
        {
            int pictureWidth = r_ImageSize.Width;
            int pictureHeight = r_ImageSize.Height;
            int formHeight = r_BorderMargin * 2 + pictureHeight * m_Board.GetLength(0);

            formHeight += (m_Board.GetLength(0) - 1) * r_MarginBetweenObjects;
            formHeight += m_LabelCurrentPlayerName.Height + r_BorderMargin;
            formHeight += m_LabelFirstPlayer.Height + r_MarginBetweenObjects;
            formHeight += m_LabelSecondPlayerName.Height + r_MarginBetweenObjects;

            int formWidth = r_BorderMargin * 2 + pictureWidth * m_Board.GetLength(1) + (m_Board.GetLength(1) - 1) * r_MarginBetweenObjects;

            return new Size(formWidth, formHeight);
        }
        private void cardButton_Click(object sender, EventArgs e)
        {
            CardButton buttonClicked = sender as CardButton;

            ExposeCard(buttonClicked);

            if(m_ChosenPair[0] == null)
            {
                m_ChosenPair[0] = buttonClicked;
            }
            else
            {
                m_ChosenPair[1] = buttonClicked;
                // disable the form in order to avoid unnecessary clicks //
                this.Enabled = false;
                r_ExposureTimer.Start();
            }


        }
        
        internal void ExposeCard(CardButton i_CardToExpose)
        {
            if(i_CardToExpose != null)
            {
                Location? cardLocation = i_CardToExpose.CardLocation;
                int cardContentId = m_CurrentGame.Board[cardLocation.Value.Row, cardLocation.Value.Col].CellContent;
                i_CardToExpose.BackgroundImage = m_CardImages[cardContentId];
                i_CardToExpose.FlatAppearance.BorderColor = getCurrentPlayerColor();
                i_CardToExpose.FlatAppearance.BorderSize = 5;
                i_CardToExpose.Enabled = false;
            }
        }

        internal void HideCard(CardButton i_CardToHide)
        {
            if (i_CardToHide != null)
            {
                i_CardToHide.BackgroundImage = null;
                i_CardToHide.FlatAppearance.BorderColor = Color.Black;
                i_CardToHide.FlatAppearance.BorderSize = 1;
                i_CardToHide.Enabled = true;
            }
        }

        private void exposureTimer_Tick(object sender, EventArgs e)
        {
            Location firstCardLocation = m_ChosenPair[0].CardLocation.Value;
            Location secondCardLocation = m_ChosenPair[1].CardLocation.Value;
            Cell firstCardCell = m_CurrentGame.GetCellByLocation(firstCardLocation);
            Cell secondCardCell = m_CurrentGame.GetCellByLocation(secondCardLocation);

            bool isAMatch = m_CurrentGame.IsThereAMatch(m_CurrentPlayer, firstCardCell, secondCardCell);
            r_ExposureTimer.Stop();
            if (isAMatch==false)
            {
                HideCard(m_ChosenPair[0]);
                HideCard(m_ChosenPair[1]);
                switchPlayer();
            }
            else
            {
                m_CurrentGame.FlipCard(firstCardCell);
                m_CurrentGame.FlipCard(secondCardCell);
            }

            m_CurrentGame.UpdateAvailableCards(isAMatch,firstCardCell,secondCardCell);
            m_CurrentGame.UpdateSeenCards(isAMatch,firstCardCell,secondCardCell);

            m_ChosenPair[0] = null;
            m_ChosenPair[1] = null;

            // turn back the form // 
            this.Enabled = true;

            if (m_CurrentPlayer.IsComputer() && m_CurrentGame.IsTheGameEnded()==false)
            {
                ComputerTurn();
            }
        }

        internal void ComputerTurn()
        {

            Cell[] computerMove = m_CurrentPlayer.ComputerMove(m_CurrentGame);
            Location firstCardLocation = computerMove[0].Location;
            Location secondCardLocation = computerMove[1].Location;

            m_Board[firstCardLocation.Row, firstCardLocation.Col].PerformClick();
            m_Board[secondCardLocation.Row, secondCardLocation.Col].PerformClick();
        }
        private void switchPlayer()
        {
            m_CurrentPlayer = m_CurrentPlayer == m_CurrentGame.Player1 ? m_CurrentGame.Player2 : m_CurrentGame.Player1;
            m_LabelCurrentPlayerName.Text = string.Format("Current Player : {0}", m_CurrentPlayer.Name);
            m_LabelCurrentPlayerName.BackColor = getCurrentPlayerColor();
        }

        private Color getCurrentPlayerColor()
        {
            Color currentPlayerColor;
            currentPlayerColor = m_CurrentPlayer == m_CurrentGame.Player1 ? r_PlayerColors[0] : r_PlayerColors[1];

            return currentPlayerColor;
        }
        private void formMemoryGame_Load(object sender, EventArgs e)
        {

        }
    }
}
