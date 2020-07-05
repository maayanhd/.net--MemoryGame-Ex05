using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex05.GameUI
{
     public class FormSettings : Form
     {
          private Label m_LabelFirstPlayerName;
          private Label m_LabelBoardSize;
          private Button m_ButtonBoardSizeOptions;
          private Button m_ButtonStart;
          private TextBox m_TextBoxFirstPlayerName;
          private Button m_ButtonAgainstaFriend;
          private TextBox m_TextBoxSecondPlayerName;
          private Label m_LabelSecondPlayerName;

          public FormSettings(): base()
          {
               InitializeComponent();
          }

          private void InitializeComponent()
          {
               this.m_LabelFirstPlayerName = new System.Windows.Forms.Label();
               this.m_LabelSecondPlayerName = new System.Windows.Forms.Label();
               this.m_LabelBoardSize = new System.Windows.Forms.Label();
               this.m_ButtonBoardSizeOptions = new System.Windows.Forms.Button();
               this.m_ButtonStart = new System.Windows.Forms.Button();
               this.m_TextBoxFirstPlayerName = new System.Windows.Forms.TextBox();
               this.m_ButtonAgainstaFriend = new System.Windows.Forms.Button();
               this.m_TextBoxSecondPlayerName = new System.Windows.Forms.TextBox();
               this.SuspendLayout();
               // 
               // m_LabelFirstPlayerName
               // 
               this.m_LabelFirstPlayerName.AutoSize = true;
               this.m_LabelFirstPlayerName.Enabled = false;
               this.m_LabelFirstPlayerName.Location = new System.Drawing.Point(23, 17);
               this.m_LabelFirstPlayerName.Name = "m_LabelFirstPlayerName";
               this.m_LabelFirstPlayerName.Size = new System.Drawing.Size(124, 17);
               this.m_LabelFirstPlayerName.TabIndex = 0;
               this.m_LabelFirstPlayerName.Text = "First Player Name:";
               this.m_LabelFirstPlayerName.Click += new System.EventHandler(this.label1_Click);
               // 
               // m_LabelSecondPlayerName
               // 
               this.m_LabelSecondPlayerName.AutoSize = true;
               this.m_LabelSecondPlayerName.Enabled = false;
               this.m_LabelSecondPlayerName.Location = new System.Drawing.Point(23, 51);
               this.m_LabelSecondPlayerName.Name = "m_LabelSecondPlayerName";
               this.m_LabelSecondPlayerName.Size = new System.Drawing.Size(145, 17);
               this.m_LabelSecondPlayerName.TabIndex = 1;
               this.m_LabelSecondPlayerName.Text = "Second Player Name:";
               this.m_LabelSecondPlayerName.Click += new System.EventHandler(this.label2_Click);
               // 
               // m_LabelBoardSize
               // 
               this.m_LabelBoardSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
               this.m_LabelBoardSize.AutoSize = true;
               this.m_LabelBoardSize.Enabled = false;
               this.m_LabelBoardSize.Location = new System.Drawing.Point(23, 85);
               this.m_LabelBoardSize.Name = "m_LabelBoardSize";
               this.m_LabelBoardSize.Size = new System.Drawing.Size(81, 17);
               this.m_LabelBoardSize.TabIndex = 2;
               this.m_LabelBoardSize.Text = "Board Size:";
               // 
               // m_ButtonBoardSizeOptions
               // 
               this.m_ButtonBoardSizeOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
               this.m_ButtonBoardSizeOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
               this.m_ButtonBoardSizeOptions.FlatAppearance.BorderColor = System.Drawing.Color.Black;
               this.m_ButtonBoardSizeOptions.Location = new System.Drawing.Point(26, 105);
               this.m_ButtonBoardSizeOptions.Name = "m_ButtonBoardSizeOptions";
               this.m_ButtonBoardSizeOptions.Size = new System.Drawing.Size(131, 81);
               this.m_ButtonBoardSizeOptions.TabIndex = 3;
               this.m_ButtonBoardSizeOptions.Text = "4 X 4";
               this.m_ButtonBoardSizeOptions.UseVisualStyleBackColor = false;
               // 
               // m_ButtonStart
               // 
               this.m_ButtonStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.m_ButtonStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
               this.m_ButtonStart.Location = new System.Drawing.Point(378, 156);
               this.m_ButtonStart.Name = "m_ButtonStart";
               this.m_ButtonStart.Size = new System.Drawing.Size(100, 29);
               this.m_ButtonStart.TabIndex = 4;
               this.m_ButtonStart.Text = "Start!";
               this.m_ButtonStart.UseVisualStyleBackColor = false;
               // 
               // m_TextBoxFirstPlayerName
               // 
               this.m_TextBoxFirstPlayerName.Location = new System.Drawing.Point(209, 17);
               this.m_TextBoxFirstPlayerName.Name = "m_TextBoxFirstPlayerName";
               this.m_TextBoxFirstPlayerName.Size = new System.Drawing.Size(130, 22);
               this.m_TextBoxFirstPlayerName.TabIndex = 6;
               // 
               // m_ButtonAgainstaFriend
               // 
               this.m_ButtonAgainstaFriend.AutoSize = true;
               this.m_ButtonAgainstaFriend.Location = new System.Drawing.Point(345, 49);
               this.m_ButtonAgainstaFriend.Name = "m_ButtonAgainstaFriend";
               this.m_ButtonAgainstaFriend.Size = new System.Drawing.Size(133, 27);
               this.m_ButtonAgainstaFriend.TabIndex = 7;
               this.m_ButtonAgainstaFriend.Text = "Against a Friend";
               this.m_ButtonAgainstaFriend.UseVisualStyleBackColor = true;
               // 
               // m_TextBoxSecondPlayerName
               // 
               this.m_TextBoxSecondPlayerName.Enabled = false;
               this.m_TextBoxSecondPlayerName.Location = new System.Drawing.Point(209, 51);
               this.m_TextBoxSecondPlayerName.Name = "m_TextBoxSecondPlayerName";
               this.m_TextBoxSecondPlayerName.ReadOnly = true;
               this.m_TextBoxSecondPlayerName.Size = new System.Drawing.Size(130, 22);
               this.m_TextBoxSecondPlayerName.TabIndex = 8;
               this.m_TextBoxSecondPlayerName.Text = "- computer -";
               // 
               // FormSettings
               // 
               this.ClientSize = new System.Drawing.Size(490, 197);
               this.Controls.Add(this.m_TextBoxSecondPlayerName);
               this.Controls.Add(this.m_ButtonAgainstaFriend);
               this.Controls.Add(this.m_TextBoxFirstPlayerName);
               this.Controls.Add(this.m_ButtonStart);
               this.Controls.Add(this.m_ButtonBoardSizeOptions);
               this.Controls.Add(this.m_LabelBoardSize);
               this.Controls.Add(this.m_LabelSecondPlayerName);
               this.Controls.Add(this.m_LabelFirstPlayerName);
               this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
               this.MaximizeBox = false;
               this.MinimizeBox = false;
               this.Name = "FormSettings";
               this.Text = "Memory Game - Settings";
               this.Load += new System.EventHandler(this.FormSettings_Load);
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          private void FormSettings_Load(object sender, EventArgs e)
          {

          }

          private void label2_Click(object sender, EventArgs e)
          {

          }

          private void label1_Click(object sender, EventArgs e)
          {

          }
     }
}
