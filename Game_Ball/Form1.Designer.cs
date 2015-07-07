namespace Game_Ball
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timerBall = new System.Windows.Forms.Timer(this.components);
            this.labelScore = new System.Windows.Forms.Label();
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Options = new System.Windows.Forms.Button();
            this.button_NewGame = new System.Windows.Forms.Button();
            this.pictureBox_Game = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Game)).BeginInit();
            this.SuspendLayout();
            // 
            // timerBall
            // 
            this.timerBall.Interval = 10;
            this.timerBall.Tick += new System.EventHandler(this.timerBall_Tick);
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.BackColor = System.Drawing.Color.Transparent;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelScore.Location = new System.Drawing.Point(-2, 9);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(146, 37);
            this.labelScore.TabIndex = 0;
            this.labelScore.Text = "Score - 0";
            this.labelScore.Visible = false;
            // 
            // button_Exit
            // 
            this.button_Exit.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_Exit.BackgroundImage = global::Game_Ball.Properties.Resources.Button_Exit;
            this.button_Exit.FlatAppearance.BorderSize = 0;
            this.button_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Exit.Font = new System.Drawing.Font("Arial", 60F);
            this.button_Exit.ForeColor = System.Drawing.Color.Gold;
            this.button_Exit.Image = global::Game_Ball.Properties.Resources.Button_Exit;
            this.button_Exit.Location = new System.Drawing.Point(271, 450);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(445, 114);
            this.button_Exit.TabIndex = 6;
            this.button_Exit.Text = "Exit";
            this.button_Exit.UseVisualStyleBackColor = false;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // button_Options
            // 
            this.button_Options.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_Options.BackgroundImage = global::Game_Ball.Properties.Resources.Button_Options;
            this.button_Options.FlatAppearance.BorderSize = 0;
            this.button_Options.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Options.Font = new System.Drawing.Font("Arial", 60F);
            this.button_Options.ForeColor = System.Drawing.Color.Gold;
            this.button_Options.Image = global::Game_Ball.Properties.Resources.Button_Options;
            this.button_Options.Location = new System.Drawing.Point(271, 336);
            this.button_Options.Name = "button_Options";
            this.button_Options.Size = new System.Drawing.Size(445, 114);
            this.button_Options.TabIndex = 5;
            this.button_Options.Text = "Options";
            this.button_Options.UseVisualStyleBackColor = false;
            this.button_Options.Click += new System.EventHandler(this.button_Options_Click);
            // 
            // button_NewGame
            // 
            this.button_NewGame.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_NewGame.BackgroundImage = global::Game_Ball.Properties.Resources.Button_NewGame;
            this.button_NewGame.FlatAppearance.BorderSize = 0;
            this.button_NewGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_NewGame.Font = new System.Drawing.Font("Arial", 60F);
            this.button_NewGame.ForeColor = System.Drawing.Color.Gold;
            this.button_NewGame.Image = global::Game_Ball.Properties.Resources.Button_NewGame;
            this.button_NewGame.Location = new System.Drawing.Point(271, 222);
            this.button_NewGame.Name = "button_NewGame";
            this.button_NewGame.Size = new System.Drawing.Size(445, 114);
            this.button_NewGame.TabIndex = 2;
            this.button_NewGame.Text = "New game";
            this.button_NewGame.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_NewGame.UseVisualStyleBackColor = false;
            this.button_NewGame.Click += new System.EventHandler(this.button_NewGame_Click);
            // 
            // pictureBox_Game
            // 
            this.pictureBox_Game.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Game.Image")));
            this.pictureBox_Game.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Game.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_Game.Name = "pictureBox_Game";
            this.pictureBox_Game.Size = new System.Drawing.Size(944, 761);
            this.pictureBox_Game.TabIndex = 1;
            this.pictureBox_Game.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(944, 761);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.button_Options);
            this.Controls.Add(this.button_NewGame);
            this.Controls.Add(this.pictureBox_Game);
            this.Controls.Add(this.labelScore);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(960, 800);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(960, 800);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Moon arcanoid";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Game)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerBall;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.PictureBox pictureBox_Game;
        private System.Windows.Forms.Button button_NewGame;
        private System.Windows.Forms.Button button_Options;
        private System.Windows.Forms.Button button_Exit;
    }
}

