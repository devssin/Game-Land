namespace Game_Land
{
    partial class Zombie_Shooter
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
            this.HelthBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.Label();
            this.txtAmmo = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.player = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // HelthBar
            // 
            this.HelthBar.Location = new System.Drawing.Point(709, 10);
            this.HelthBar.Name = "HelthBar";
            this.HelthBar.Size = new System.Drawing.Size(190, 23);
            this.HelthBar.TabIndex = 6;
            this.HelthBar.Value = 100;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(615, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Health : ";
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.ForeColor = System.Drawing.Color.White;
            this.txtScore.Location = new System.Drawing.Point(362, 7);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(77, 24);
            this.txtScore.TabIndex = 4;
            this.txtScore.Text = "Kills : 0";
            // 
            // txtAmmo
            // 
            this.txtAmmo.AutoSize = true;
            this.txtAmmo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmmo.ForeColor = System.Drawing.Color.White;
            this.txtAmmo.Location = new System.Drawing.Point(25, 7);
            this.txtAmmo.Name = "txtAmmo";
            this.txtAmmo.Size = new System.Drawing.Size(105, 24);
            this.txtAmmo.TabIndex = 5;
            this.txtAmmo.Text = "Ammo : 0 ";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // player
            // 
            this.player.Image = global::Game_Land.Properties.Resources.up;
            this.player.Location = new System.Drawing.Point(427, 532);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(71, 100);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 7;
            this.player.TabStop = false;
            // 
            // Zombie_Shooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(924, 661);
            this.Controls.Add(this.player);
            this.Controls.Add(this.HelthBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.txtAmmo);
            this.Name = "Zombie_Shooter";
            this.Text = "Zombie_Shooter";
            this.Load += new System.EventHandler(this.Zombie_Shooter_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Zombie_Shooter_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Zombie_Shooter_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.ProgressBar HelthBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Label txtAmmo;
        private System.Windows.Forms.Timer timer1;
    }
}