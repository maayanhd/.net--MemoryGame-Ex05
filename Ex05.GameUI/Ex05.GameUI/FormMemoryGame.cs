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
          private readonly Color[] r_PlayerColors;
          private readonly int r_BorderMargin = 16;
          private readonly int r_MarginBetweenObjects = 8;
          private readonly Size r_ImageSize = new Size(80, 80);
          private readonly Timer r_ExposureTimer;

          private CardButton[,] m_Board;
          private Label m_LabelCurrentPlayer;
          private Label m_LabelFirstPlayer;
          private Label m_LabelSecondPlayer;

          private Game m_CurrentGame;
          private Image[] m_CardImages;
                  
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
               m_CurrentGame.CardFlipped += m_CurrentGame_CardFlipped;

               // For delay after exposing the second card if needed 
               r_ExposureTimer = new Timer();
               r_ExposureTimer.Interval = 750;
               r_ExposureTimer.Tick += exposureTimer_Tick;

               i_CurrentGame.Player1.ScoreChanged += Player_ScoreChanged;
               i_CurrentGame.Player2.ScoreChanged += Player_ScoreChanged;
               m_CurrentPlayer = i_CurrentGame.Player1;
               m_ChosenPair = new CardButton[2];

               r_PlayerColors[0] = getLightGreenFromRgb();
               r_PlayerColors[1] = getLightPurpleFromRgb();

               m_Board = new CardButton[height, width];
               m_CardImages = new Image[(height * width) / 2];

               GenerateImagesArray();
               InitializeComponent();
          }

          private System.Drawing.Color getLightGreenFromRgb()
          {
               return System.Drawing.Color.FromArgb(
              (int)((byte)192),
              (int)((byte)255),
              (int)((byte)192));
          }

          private System.Drawing.Color getLightPurpleFromRgb()
          {
               return System.Drawing.Color.FromArgb(
              (int)((byte)192),
              (int)((byte)192),
              (int)((byte)255));
          }

          private void m_CurrentGame_GameEnded(PostGameInfo i_PostGameInfo)
          {
               string endOfTheGameAnnouncement = "The game ended in a draw!";

               if (i_PostGameInfo.IsaDraw == false)
               {
                    endOfTheGameAnnouncement = string.Format(
                        "{0} has won with a score of {1}",
                        i_PostGameInfo.Winner.Name,
                        i_PostGameInfo.Winner.Score);
               }

               MessageBox.Show(endOfTheGameAnnouncement, "Memory Game - Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

               this.DialogResult = DialogResult.OK;
               this.Close();
          }

          private void m_CurrentGame_CardFlipped(Cell i_CardFlipped)
          {
               int i = i_CardFlipped.Location.Row,
                   j = i_CardFlipped.Location.Col;
               CardButton cardToFlip = m_Board[i, j];
               bool isCardFacingUpAfterFlipped = i_CardFlipped.IsFlipped; 

               if(isCardFacingUpAfterFlipped)
               {
                    ExposeCard(cardToFlip);
               }
               else
               {
                    HideCard(cardToFlip);
               }
          }

          private void Player_ScoreChanged(int i_ScoreToUpdate)
          {
               string labelString = string.Format(
                   "{0}: {1} Pairs",
                   m_CurrentPlayer.Name,
                   i_ScoreToUpdate);

               Label currentLabel =
                   m_CurrentPlayer == m_CurrentGame.Player1 ? m_LabelFirstPlayer : m_LabelSecondPlayer;

               currentLabel.Text = labelString;
          }

          internal void GenerateImagesArray()
          {
               for (int i = 0; i < m_CardImages.Length; i++)
               {
                    PictureBox img = new PictureBox();
                    img.Load("https://picsum.photos/80");
                    m_CardImages[i] = img.Image;
               }
          }

          private void InitializeComponent()
          {
               BuildBoard();
               this.SuspendLayout();

               allocateControls();

               // m_LabelCurrentPlayer
               designLabelCurrentPlayer();

               // m_LabelFirstPlayer
               design_LabelFirstPlayer();

               // m_LabelSecondPlayer
               design_LabelSecondPlayer();

               // FormMemoryGame
               this.ClientSize = calcClientSize();
               addControlsToThisForm();

               designMemoryGameForm();
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

                         AddCardButtonToBoard(i, j, locationFromLeft, locationFromTop);
                    }
               }
          }

          private void AddCardButtonToBoard(int i_HeightIdx, int i_WidthIdx, params int[] i_CardButtonLocation)
          {
               m_Board[i_HeightIdx, i_WidthIdx] = new CardButton(new Location(i_HeightIdx, i_WidthIdx));

               CardButton currentCardButton = m_Board[i_HeightIdx, i_WidthIdx];
               currentCardButton.BackgroundImage = null;
               currentCardButton.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top
                                                                                 | System.Windows.Forms.AnchorStyles.Left
                                                                                | System.Windows.Forms.AnchorStyles.Right);
               currentCardButton.FlatStyle = FlatStyle.Flat;
               currentCardButton.Location = new System.Drawing.Point(i_CardButtonLocation[0], i_CardButtonLocation[1]);
               currentCardButton.Name = string.Format("m_ButtonCard{0}{1}", i_HeightIdx, i_WidthIdx);
               currentCardButton.Size = r_ImageSize;
               currentCardButton.TabIndex = i_HeightIdx + i_WidthIdx;
               currentCardButton.UseVisualStyleBackColor = true;
               currentCardButton.Click += new System.EventHandler(this.cardButton_Click);
               this.Controls.Add(m_Board[i_HeightIdx, i_WidthIdx]);
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
               this.m_LabelCurrentPlayer.Location = new System.Drawing.Point(r_BorderMargin, m_Board[m_Board.GetLength(0) - 1, 0].Bottom + r_BorderMargin);
               this.m_LabelCurrentPlayer.Name = "m_LabelCurrentPlayerName";
               this.m_LabelCurrentPlayer.Size = new System.Drawing.Size(243, 17);

               // Assuming the board size is under 100  - meaning less than 100 memory cards involved in the game
               this.m_LabelCurrentPlayer.TabIndex = 100;
               this.m_LabelCurrentPlayer.Text = string.Format("Current Player : {0}", m_CurrentPlayer.Name);
          }

          private void design_LabelFirstPlayer()
          {
               this.m_LabelFirstPlayer.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom
              | System.Windows.Forms.AnchorStyles.Left
              | System.Windows.Forms.AnchorStyles.Right);
               this.m_LabelFirstPlayer.AutoSize = true;
               this.m_LabelFirstPlayer.BackColor = r_PlayerColors[0];
               this.m_LabelFirstPlayer.Location = new System.Drawing.Point(
                   r_BorderMargin,
                   m_LabelCurrentPlayer.Bottom + r_MarginBetweenObjects);
               this.m_LabelFirstPlayer.Name = "m_LabelFirstPlayerName";
               this.m_LabelFirstPlayer.Size = new System.Drawing.Size(188, 17);
               this.m_LabelFirstPlayer.TabIndex = 150;
               this.m_LabelFirstPlayer.Text = string.Format(
                   "{0}: 0 Pairs",
                   m_CurrentGame.Player1.Name);
          }

          private void design_LabelSecondPlayer()
          {
               this.m_LabelSecondPlayer.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                                                  | System.Windows.Forms.AnchorStyles.Left
                                                  | System.Windows.Forms.AnchorStyles.Right);
               this.m_LabelSecondPlayer.AutoSize = true;
               this.m_LabelSecondPlayer.BackColor = r_PlayerColors[1];
               this.m_LabelSecondPlayer.Location = new System.Drawing.Point(r_BorderMargin, m_LabelFirstPlayer.Bottom + r_MarginBetweenObjects);
               this.m_LabelSecondPlayer.Name = "m_LabelFirstPlayerName";
               this.m_LabelSecondPlayer.Size = new System.Drawing.Size(135, 17);
               this.m_LabelSecondPlayer.TabIndex = 200;
               this.m_LabelSecondPlayer.Text = string.Format(
                   "{0}: 0 Pairs",
                   m_CurrentGame.Player2.Name);
          }

          private void addControlsToThisForm()
          {
               this.Controls.Add(this.m_LabelSecondPlayer);
               this.Controls.Add(this.m_LabelFirstPlayer);
               this.Controls.Add(this.m_LabelCurrentPlayer);
          }

          private void designMemoryGameForm()
          {
               this.MaximizeBox = false;
               this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
               this.Name = "FormMemoryGame";
               this.ResumeLayout(false);
               this.PerformLayout();
          }

          private Size calcClientSize()
          {
               int pictureWidth = r_ImageSize.Width;
               int pictureHeight = r_ImageSize.Height;
               int formHeight = (r_BorderMargin * 2) + (pictureHeight * m_Board.GetLength(0));

               formHeight += (m_Board.GetLength(0) - 1) * r_MarginBetweenObjects;
               formHeight += m_LabelCurrentPlayer.Height + r_BorderMargin;
               formHeight += m_LabelFirstPlayer.Height + r_MarginBetweenObjects;
               formHeight += m_LabelSecondPlayer.Height + r_MarginBetweenObjects;

               int formWidth = (r_BorderMargin * 2) + (pictureWidth * m_Board.GetLength(1)) + ((m_Board.GetLength(1) - 1) * r_MarginBetweenObjects);

               return new Size(formWidth, formHeight);
          }

          private void cardButton_Click(object sender, EventArgs e)
          {
               CardButton buttonClicked = sender as CardButton;

               Location cardLocation = buttonClicked.CardLocation.Value;
               Cell cardCell = m_CurrentGame.GetCellByLocation(cardLocation);

               m_CurrentGame.FlipCard(cardCell); 
               
               //ExposeCard(buttonClicked);
               if (m_ChosenPair[0] == null)
               {
                    // First card of the pair to be exposed
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

          private void ExposeCard(CardButton i_CardToExpose)
          {
               if (i_CardToExpose != null)
               {
                    Location? cardLocation = i_CardToExpose.CardLocation;
                    int cardContentId = m_CurrentGame.Board[cardLocation.Value.Row, cardLocation.Value.Col].CellContent;
                    i_CardToExpose.BackgroundImage = m_CardImages[cardContentId];
                    i_CardToExpose.FlatAppearance.BorderColor = getCurrentPlayerColor();
                    i_CardToExpose.FlatAppearance.BorderSize = 5;
                    i_CardToExpose.Enabled = false;
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
               if (isAMatch == false)
               {
                    m_CurrentGame.FlipCard(firstCardCell);
                    m_CurrentGame.FlipCard(secondCardCell);

                    //HideCard(m_ChosenPair[0]);
                    //HideCard(m_ChosenPair[1]);
                    switchPlayer();
               }
            
               m_CurrentGame.UpdateAvailableCards(isAMatch, firstCardCell, secondCardCell);
               m_CurrentGame.UpdateSeenCards(isAMatch, firstCardCell, secondCardCell);

               m_ChosenPair[0] = null;
               m_ChosenPair[1] = null;

               // turn back the form // 
               this.Enabled = true;

               if (m_CurrentPlayer.IsComputer() && m_CurrentGame.IsTheGameEnded() == false)
               {
                    ComputerTurn();
               }
          }

          private void HideCard(CardButton i_CardToHide)
          {
               if (i_CardToHide != null)
               {
                    i_CardToHide.BackgroundImage = null;
                    i_CardToHide.FlatAppearance.BorderColor = Color.Black;
                    i_CardToHide.FlatAppearance.BorderSize = 1;
                    i_CardToHide.Enabled = true;
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
               m_LabelCurrentPlayer.Text = string.Format("Current Player : {0}", m_CurrentPlayer.Name);
               m_LabelCurrentPlayer.BackColor = getCurrentPlayerColor();
          }

          private Color getCurrentPlayerColor()
          {
               Color currentPlayerColor;
               currentPlayerColor = m_CurrentPlayer == m_CurrentGame.Player1 ? r_PlayerColors[0] : r_PlayerColors[1];

               return currentPlayerColor;
          }
     }
}
