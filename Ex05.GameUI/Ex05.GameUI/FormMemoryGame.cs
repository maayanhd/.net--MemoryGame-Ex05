using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex05.GameUI
{
     class FormMemoryGame: Form
     {
          private Label m_LabelCurrentPlayerName;
          private Label m_CurrentPlayerName;
          private int m_BoardHeight;
          private int m_BoardWidth;

          private Button m_ButtonCard00;
          private Button m_ButtonCard01;
          private Button m_ButtonCard02;
          private Button m_ButtonCard03;

          private Button m_ButtonCard10;
          private Button m_ButtonCard11;
          private Button m_ButtonCard12;
          private Button m_ButtonCard13;

          private Button m_ButtonCard20;
          private Button m_ButtonCard21;
          private Button m_ButtonCard22;
          private Button m_ButtonCard23;
          
          private Button m_ButtonCard30;
          private Button m_ButtonCard31;
          private Button m_ButtonCard32;
          private Button m_ButtonCard33;

          private Label m_LabelRivalPlayerName;


          public void GetBoardMeasurements(ref int m_Rows,ref int m_Cols)
          {
               
          }
                           
          public FormMemoryGame(int i_Height, int i_Width) : base()
          {
               m_BoardHeight = i_Height;
               m_BoardWidth  = i_Width;

               InitializeComponent();
          }

          internal void BuildBoard()
          {
               
               for (int i = 0; i < m_BoardHeight; i++) 
               {
                    for (int j = 0; j < m_BoardWidth; j++) 
                    {
                         int leftMargin = i > 0 ? 8 : 12,
                              topMargin = j > 0 ? 8 : 12;


                        
                    }
               }



          }

          private void InitializeComponent()
          {
               this.m_LabelCurrentPlayerName = new System.Windows.Forms.Label();
               this.m_CurrentPlayerName = new System.Windows.Forms.Label();
               this.m_LabelRivalPlayerName = new System.Windows.Forms.Label();


               BuildBoard()

               this.m_ButtonCard00 = new System.Windows.Forms.Button();

               this.m_ButtonCard00.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
           | System.Windows.Forms.AnchorStyles.Left)
           | System.Windows.Forms.AnchorStyles.Right)));
               this.m_ButtonCard00.Location = new System.Drawing.Point(12, 12);
               this.m_ButtonCard00.Name = "m_ButtonCard00";
               this.m_ButtonCard00.Size = new System.Drawing.Size(54, 48);
               this.m_ButtonCard00.TabIndex = 3;
               this.m_ButtonCard00.UseVisualStyleBackColor = true;
               this.m_ButtonCard00.Click += new System.EventHandler(this.button1_Click);



               this.m_ButtonCard10 = new System.Windows.Forms.Button();
               this.m_ButtonCard20 = new System.Windows.Forms.Button();
               this.m_ButtonCard30 = new System.Windows.Forms.Button();
               this.m_ButtonCard01 = new System.Windows.Forms.Button();
               this.m_ButtonCard11 = new System.Windows.Forms.Button();
               this.m_ButtonCard21 = new System.Windows.Forms.Button();
               this.m_ButtonCard31 = new System.Windows.Forms.Button();
               this.m_ButtonCard02 = new System.Windows.Forms.Button();
               this.m_ButtonCard12 = new System.Windows.Forms.Button();
               this.m_ButtonCard22 = new System.Windows.Forms.Button();
               this.m_ButtonCard32 = new System.Windows.Forms.Button();
               this.m_ButtonCard03 = new System.Windows.Forms.Button();
               this.m_ButtonCard13 = new System.Windows.Forms.Button();
               this.m_ButtonCard23 = new System.Windows.Forms.Button();
               this.m_ButtonCard33 = new System.Windows.Forms.Button();
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
               // m_ButtonCard00
               // 
               this.m_ButtonCard00.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.m_ButtonCard00.Location = new System.Drawing.Point(12, 12);
               this.m_ButtonCard00.Name = "m_ButtonCard00";
               this.m_ButtonCard00.Size = new System.Drawing.Size(54, 48);
               this.m_ButtonCard00.TabIndex = 3;
               this.m_ButtonCard00.UseVisualStyleBackColor = true;
               this.m_ButtonCard00.Click += new System.EventHandler(this.button1_Click);
               // 
               // m_ButtonCard10
               // 
               this.m_ButtonCard10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.m_ButtonCard10.Location = new System.Drawing.Point(12, 66);
               this.m_ButtonCard10.Name = "m_ButtonCard10";
               this.m_ButtonCard10.Size = new System.Drawing.Size(54, 48);
               this.m_ButtonCard10.TabIndex = 5;
               this.m_ButtonCard10.UseVisualStyleBackColor = true;
               this.m_ButtonCard10.Click += new System.EventHandler(this.button2_Click);
               // 
               // m_ButtonCard20
               // 
               this.m_ButtonCard20.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.m_ButtonCard20.Location = new System.Drawing.Point(12, 120);
               this.m_ButtonCard20.Name = "m_ButtonCard20";
               this.m_ButtonCard20.Size = new System.Drawing.Size(54, 48);
               this.m_ButtonCard20.TabIndex = 6;
               this.m_ButtonCard20.UseVisualStyleBackColor = true;
               // 
               // m_ButtonCard30
               // 
               this.m_ButtonCard30.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.m_ButtonCard30.Location = new System.Drawing.Point(12, 174);
               this.m_ButtonCard30.Name = "m_ButtonCard30";
               this.m_ButtonCard30.Size = new System.Drawing.Size(54, 48);
               this.m_ButtonCard30.TabIndex = 7;
               this.m_ButtonCard30.UseVisualStyleBackColor = true;
               this.m_ButtonCard30.Click += new System.EventHandler(this.button4_Click);
               // 
               // m_ButtonCard01
               // 
               this.m_ButtonCard01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.m_ButtonCard01.Location = new System.Drawing.Point(72, 12);
               this.m_ButtonCard01.Name = "m_ButtonCard01";
               this.m_ButtonCard01.Size = new System.Drawing.Size(54, 48);
               this.m_ButtonCard01.TabIndex = 3;
               this.m_ButtonCard01.UseVisualStyleBackColor = true;
               this.m_ButtonCard01.Click += new System.EventHandler(this.button1_Click);
               // 
               // m_ButtonCard11
               // 
               this.m_ButtonCard11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.m_ButtonCard11.Location = new System.Drawing.Point(72, 66);
               this.m_ButtonCard11.Name = "m_ButtonCard11";
               this.m_ButtonCard11.Size = new System.Drawing.Size(54, 48);
               this.m_ButtonCard11.TabIndex = 5;
               this.m_ButtonCard11.UseVisualStyleBackColor = true;
               // 
               // m_ButtonCard21
               // 
               this.m_ButtonCard21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.m_ButtonCard21.Location = new System.Drawing.Point(72, 120);
               this.m_ButtonCard21.Name = "m_ButtonCard21";
               this.m_ButtonCard21.Size = new System.Drawing.Size(54, 48);
               this.m_ButtonCard21.TabIndex = 6;
               this.m_ButtonCard21.UseVisualStyleBackColor = true;
               // 
               // m_ButtonCard31
               // 
               this.m_ButtonCard31.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.m_ButtonCard31.Location = new System.Drawing.Point(72, 174);
               this.m_ButtonCard31.Name = "m_ButtonCard31";
               this.m_ButtonCard31.Size = new System.Drawing.Size(54, 48);
               this.m_ButtonCard31.TabIndex = 7;
               this.m_ButtonCard31.UseVisualStyleBackColor = true;
               // 
               // m_ButtonCard02
               // 
               this.m_ButtonCard02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.m_ButtonCard02.Location = new System.Drawing.Point(132, 12);
               this.m_ButtonCard02.Name = "m_ButtonCard02";
               this.m_ButtonCard02.Size = new System.Drawing.Size(54, 48);
               this.m_ButtonCard02.TabIndex = 3;
               this.m_ButtonCard02.UseVisualStyleBackColor = true;
               this.m_ButtonCard02.Click += new System.EventHandler(this.button1_Click);
               // 
               // m_ButtonCard12
               // 
               this.m_ButtonCard12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.m_ButtonCard12.Location = new System.Drawing.Point(132, 66);
               this.m_ButtonCard12.Name = "m_ButtonCard12";
               this.m_ButtonCard12.Size = new System.Drawing.Size(54, 48);
               this.m_ButtonCard12.TabIndex = 5;
               this.m_ButtonCard12.UseVisualStyleBackColor = true;
               // 
               // m_ButtonCard22
               // 
               this.m_ButtonCard22.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.m_ButtonCard22.Location = new System.Drawing.Point(132, 120);
               this.m_ButtonCard22.Name = "m_ButtonCard22";
               this.m_ButtonCard22.Size = new System.Drawing.Size(54, 48);
               this.m_ButtonCard22.TabIndex = 6;
               this.m_ButtonCard22.UseVisualStyleBackColor = true;
               this.m_ButtonCard22.Click += new System.EventHandler(this.button10_Click);
               // 
               // m_ButtonCard32
               // 
               this.m_ButtonCard32.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.m_ButtonCard32.Location = new System.Drawing.Point(132, 174);
               this.m_ButtonCard32.Name = "m_ButtonCard32";
               this.m_ButtonCard32.Size = new System.Drawing.Size(54, 48);
               this.m_ButtonCard32.TabIndex = 7;
               this.m_ButtonCard32.UseVisualStyleBackColor = true;
               // 
               // m_ButtonCard03
               // 
               this.m_ButtonCard03.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.m_ButtonCard03.Location = new System.Drawing.Point(192, 12);
               this.m_ButtonCard03.Name = "m_ButtonCard03";
               this.m_ButtonCard03.Size = new System.Drawing.Size(54, 48);
               this.m_ButtonCard03.TabIndex = 3;
               this.m_ButtonCard03.UseVisualStyleBackColor = true;
               this.m_ButtonCard03.Click += new System.EventHandler(this.button1_Click);
               // 
               // m_ButtonCard13
               // 
               this.m_ButtonCard13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.m_ButtonCard13.Location = new System.Drawing.Point(192, 66);
               this.m_ButtonCard13.Name = "m_ButtonCard13";
               this.m_ButtonCard13.Size = new System.Drawing.Size(54, 48);
               this.m_ButtonCard13.TabIndex = 5;
               this.m_ButtonCard13.UseVisualStyleBackColor = true;
               // 
               // m_ButtonCard23
               // 
               this.m_ButtonCard23.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.m_ButtonCard23.Location = new System.Drawing.Point(192, 120);
               this.m_ButtonCard23.Name = "m_ButtonCard23";
               this.m_ButtonCard23.Size = new System.Drawing.Size(54, 48);
               this.m_ButtonCard23.TabIndex = 6;
               this.m_ButtonCard23.UseVisualStyleBackColor = true;
               // 
               // m_ButtonCard33
               // 
               this.m_ButtonCard33.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.m_ButtonCard33.Location = new System.Drawing.Point(192, 174);
               this.m_ButtonCard33.Name = "m_ButtonCard33";
               this.m_ButtonCard33.Size = new System.Drawing.Size(54, 48);
               this.m_ButtonCard33.TabIndex = 7;
               this.m_ButtonCard33.UseVisualStyleBackColor = true;
               // 
               // FormMemoryGame
               // 
               this.AutoSize = true;
               this.ClientSize = new System.Drawing.Size(282, 253);
               this.Controls.Add(this.m_ButtonCard33);
               this.Controls.Add(this.m_ButtonCard32);
               this.Controls.Add(this.m_ButtonCard31);
               this.Controls.Add(this.m_ButtonCard30);
               this.Controls.Add(this.m_ButtonCard23);
               this.Controls.Add(this.m_ButtonCard22);
               this.Controls.Add(this.m_ButtonCard21);
               this.Controls.Add(this.m_ButtonCard20);
               this.Controls.Add(this.m_ButtonCard13);
               this.Controls.Add(this.m_ButtonCard03);
               this.Controls.Add(this.m_ButtonCard12);
               this.Controls.Add(this.m_ButtonCard02);
               this.Controls.Add(this.m_ButtonCard11);
               this.Controls.Add(this.m_ButtonCard01);
               this.Controls.Add(this.m_ButtonCard10);
               this.Controls.Add(this.m_ButtonCard00);
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
