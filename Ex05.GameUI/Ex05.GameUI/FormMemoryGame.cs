using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ex05.GameLogic;

namespace Ex05.GameUI
{
    class FormMemoryGame : Form
    {
        private Label m_LabelCurrentPlayerName;
        private Label m_CurrentPlayerName;
        private CardButton[,] m_Board;
        private Label m_LabelRivalPlayerName;

        private Game m_CurrentGame;
        private Image [] m_CardImages;

        public FormMemoryGame(Game i_CurrentGame) : base()
        {
            int height = i_CurrentGame.Board.GetLength(0);
            int width = i_CurrentGame.Board.GetLength(1);
            m_CurrentGame = i_CurrentGame;
            m_Board = new CardButton[height, width];
            m_CardImages = new Image[(height*width)/2];
            GenerateImagesArray();
            InitializeComponent();
        }

        internal void GenerateImagesArray()
        {
            for(int i = 0; i < m_CardImages.Length; i++)
            {

                PictureBox img = new PictureBox();
                img.Load("https://i.stack.imgur.com/xGKVm.jpg");
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
                    int locationFromLeft = i > 0 ? m_Board[i - 1, j].Right + 8 : 12,
                        locationFromTop = j > 0 ? m_Board[i, j - 1].Bottom + 8 : 12;
                    
                    AddCardButtonToBoard(i,j, locationFromLeft,locationFromTop);
                }
            }



        }

        void AddCardButtonToBoard(int i_HeightIdx, int i_WidthIdx,params int [] i_CardButtonLocation)
        {
            m_Board[i_HeightIdx, i_WidthIdx] = new CardButton(new Location(i_HeightIdx, i_WidthIdx));
            m_Board[i_HeightIdx, i_WidthIdx].Image =
                m_CardImages[m_CurrentGame.Board[i_HeightIdx, i_WidthIdx].CellContent];
            m_Board[i_HeightIdx, i_WidthIdx].Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                                             | System.Windows.Forms.AnchorStyles.Left)
                                                                                            | System.Windows.Forms.AnchorStyles.Right)));
            m_Board[i_HeightIdx, i_WidthIdx].Location = new System.Drawing.Point(i_CardButtonLocation[0], i_CardButtonLocation[1]);
            m_Board[i_HeightIdx, i_WidthIdx].Name = "m_ButtonCard00";
            m_Board[i_HeightIdx, i_WidthIdx].Size = new System.Drawing.Size(54, 48);
            m_Board[i_HeightIdx, i_WidthIdx].TabIndex = 3;
            m_Board[i_HeightIdx, i_WidthIdx].UseVisualStyleBackColor = true;
            m_Board[i_HeightIdx, i_WidthIdx].Click += new System.EventHandler(this.button1_Click);
        }

        private void InitializeComponent()
        {
            this.m_LabelCurrentPlayerName = new System.Windows.Forms.Label();
            this.m_CurrentPlayerName = new System.Windows.Forms.Label();
            this.m_LabelRivalPlayerName = new System.Windows.Forms.Label();


            BuildBoard();

            //    this.m_ButtonCard00 = new System.Windows.Forms.Button();

            //    this.m_ButtonCard00.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //| System.Windows.Forms.AnchorStyles.Left)
            //| System.Windows.Forms.AnchorStyles.Right)));
            //    this.m_ButtonCard00.Location = new System.Drawing.Point(12, 12);
            //    this.m_ButtonCard00.Name = "m_ButtonCard00";
            //    this.m_ButtonCard00.Size = new System.Drawing.Size(54, 48);
            //    this.m_ButtonCard00.TabIndex = 3;
            //    this.m_ButtonCard00.UseVisualStyleBackColor = true;
            //    this.m_ButtonCard00.Click += new System.EventHandler(this.button1_Click);



            //    this.m_ButtonCard10 = new System.Windows.Forms.Button();
            //    this.m_ButtonCard20 = new System.Windows.Forms.Button();
            //    this.m_ButtonCard30 = new System.Windows.Forms.Button();
            //    this.m_ButtonCard01 = new System.Windows.Forms.Button();
            //    this.m_ButtonCard11 = new System.Windows.Forms.Button();
            //    this.m_ButtonCard21 = new System.Windows.Forms.Button();
            //    this.m_ButtonCard31 = new System.Windows.Forms.Button();
            //    this.m_ButtonCard02 = new System.Windows.Forms.Button();
            //    this.m_ButtonCard12 = new System.Windows.Forms.Button();
            //    this.m_ButtonCard22 = new System.Windows.Forms.Button();
            //    this.m_ButtonCard32 = new System.Windows.Forms.Button();
            //    this.m_ButtonCard03 = new System.Windows.Forms.Button();
            //    this.m_ButtonCard13 = new System.Windows.Forms.Button();
            //    this.m_ButtonCard23 = new System.Windows.Forms.Button();
            //    this.m_ButtonCard33 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_LabelCurrentPlayerName
            // 
            this.m_LabelCurrentPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
         | System.Windows.Forms.AnchorStyles.Left)
         | System.Windows.Forms.AnchorStyles.Right)));
            this.m_LabelCurrentPlayerName.AutoSize = true;
            this.m_LabelCurrentPlayerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_LabelCurrentPlayerName.Location = new System.Drawing.Point(12, 237);
            this.m_LabelCurrentPlayerName.Name = "m_LabelCurrentPlayerName";
            this.m_LabelCurrentPlayerName.Size = new System.Drawing.Size(243, 17);
            this.m_LabelCurrentPlayerName.TabIndex = 0;
            this.m_LabelCurrentPlayerName.Text = "Current Player : Current Player Name";
            // 
            // m_CurrentPlayerName
            // 
            this.m_CurrentPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
         | System.Windows.Forms.AnchorStyles.Left)
         | System.Windows.Forms.AnchorStyles.Right)));
            this.m_CurrentPlayerName.AutoSize = true;
            this.m_CurrentPlayerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_CurrentPlayerName.Location = new System.Drawing.Point(12, 271);
            this.m_CurrentPlayerName.Name = "m_CurrentPlayerName";
            this.m_CurrentPlayerName.Size = new System.Drawing.Size(188, 17);
            this.m_CurrentPlayerName.TabIndex = 1;
            this.m_CurrentPlayerName.Text = "Current PlayerName: 0 Pairs";
            // 
            // m_LabelRivalPlayerName
            // 
            this.m_LabelRivalPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
         | System.Windows.Forms.AnchorStyles.Left)
         | System.Windows.Forms.AnchorStyles.Right)));
            this.m_LabelRivalPlayerName.AutoSize = true;
            this.m_LabelRivalPlayerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.m_LabelRivalPlayerName.Location = new System.Drawing.Point(12, 307);
            this.m_LabelRivalPlayerName.Name = "m_LabelRivalPlayerName";
            this.m_LabelRivalPlayerName.Size = new System.Drawing.Size(135, 17);
            this.m_LabelRivalPlayerName.TabIndex = 2;
            this.m_LabelRivalPlayerName.Text = "Rival Player: 0 Pairs";
            // 
            // FormMemoryGame
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.m_LabelRivalPlayerName);
            this.Controls.Add(this.m_CurrentPlayerName);
            this.Controls.Add(this.m_LabelCurrentPlayerName);
            this.MaximizeBox = false;
            this.Name = "FormMemoryGame";
            this.Load += new System.EventHandler(this.FormMemoryGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void FormMemoryGame_Load(object sender, EventArgs e)
        {

        }
    }
}
