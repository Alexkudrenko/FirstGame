namespace TheGame
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.MainPBox = new System.Windows.Forms.PictureBox();
            this.LevelEnd = new System.Windows.Forms.PictureBox();
            this.CharacterImg = new System.Windows.Forms.PictureBox();
            this.MoveTimer = new System.Windows.Forms.Timer(this.components);
            this.RenderTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ClearGrButton = new TheGame.SuperButton();
            this.CloseButton = new TheGame.SuperButton();
            this.GameButton = new TheGame.SuperButton();
            ((System.ComponentModel.ISupportInitialize)(this.MainPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LevelEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterImg)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPBox
            // 
            this.MainPBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.MainPBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPBox.Location = new System.Drawing.Point(0, 0);
            this.MainPBox.Name = "MainPBox";
            this.MainPBox.Size = new System.Drawing.Size(973, 488);
            this.MainPBox.TabIndex = 0;
            this.MainPBox.TabStop = false;
            this.MainPBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseDown);
            this.MainPBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseMove);
            this.MainPBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseUp);
            // 
            // LevelEnd
            // 
            this.LevelEnd.BackColor = System.Drawing.Color.CornflowerBlue;
            this.LevelEnd.Image = ((System.Drawing.Image)(resources.GetObject("LevelEnd.Image")));
            this.LevelEnd.Location = new System.Drawing.Point(793, 192);
            this.LevelEnd.Name = "LevelEnd";
            this.LevelEnd.Size = new System.Drawing.Size(34, 50);
            this.LevelEnd.TabIndex = 3;
            this.LevelEnd.TabStop = false;
            // 
            // CharacterImg
            // 
            this.CharacterImg.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CharacterImg.Image = ((System.Drawing.Image)(resources.GetObject("CharacterImg.Image")));
            this.CharacterImg.Location = new System.Drawing.Point(33, 62);
            this.CharacterImg.Name = "CharacterImg";
            this.CharacterImg.Size = new System.Drawing.Size(40, 38);
            this.CharacterImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CharacterImg.TabIndex = 4;
            this.CharacterImg.TabStop = false;
            // 
            // MoveTimer
            // 
            this.MoveTimer.Interval = 40;
            this.MoveTimer.Tick += new System.EventHandler(this.MoveTimer_Tick);
            // 
            // RenderTimer
            // 
            this.RenderTimer.Enabled = true;
            this.RenderTimer.Interval = 50;
            this.RenderTimer.Tick += new System.EventHandler(this.RenderTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(742, 448);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 488);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSalmon;
            this.panel2.Location = new System.Drawing.Point(963, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 488);
            this.panel2.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Turquoise;
            this.panel3.Location = new System.Drawing.Point(0, 480);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(967, 10);
            this.panel3.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Maroon;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(967, 12);
            this.panel4.TabIndex = 12;
            // 
            // ClearGrButton
            // 
            this.ClearGrButton.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearGrButton.Location = new System.Drawing.Point(874, 378);
            this.ClearGrButton.Name = "ClearGrButton";
            this.ClearGrButton.Size = new System.Drawing.Size(75, 46);
            this.ClearGrButton.TabIndex = 7;
            this.ClearGrButton.Text = "Clear";
            this.ClearGrButton.UseVisualStyleBackColor = true;
            this.ClearGrButton.Click += new System.EventHandler(this.ClearGrButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseButton.Location = new System.Drawing.Point(837, 430);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 46);
            this.CloseButton.TabIndex = 6;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // GameButton
            // 
            this.GameButton.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GameButton.Location = new System.Drawing.Point(793, 378);
            this.GameButton.Name = "GameButton";
            this.GameButton.Size = new System.Drawing.Size(75, 46);
            this.GameButton.TabIndex = 5;
            this.GameButton.Text = "Start!";
            this.GameButton.UseVisualStyleBackColor = true;
            this.GameButton.Click += new System.EventHandler(this.GameButton_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(973, 488);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClearGrButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.GameButton);
            this.Controls.Add(this.CharacterImg);
            this.Controls.Add(this.LevelEnd);
            this.Controls.Add(this.MainPBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TheGame";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.MainPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LevelEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MainPBox;
        private System.Windows.Forms.PictureBox LevelEnd;
        private System.Windows.Forms.PictureBox CharacterImg;
        private SuperButton GameButton;
        private SuperButton CloseButton;
        private SuperButton ClearGrButton;
        private System.Windows.Forms.Timer MoveTimer;
        private System.Windows.Forms.Timer RenderTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;

    }
}

