namespace Game_Land
{
    partial class Space_Shooter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Space_Shooter));
            this.lblLevel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReplay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.player = new System.Windows.Forms.PictureBox();
            this.bulletEnemies = new System.Windows.Forms.Timer(this.components);
            this.moveBullets = new System.Windows.Forms.Timer(this.components);
            this.rightMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.leftMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.topMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.downMoveTmer = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.moveEnemiesTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.ForeColor = System.Drawing.Color.Gold;
            this.lblLevel.Location = new System.Drawing.Point(533, 10);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(27, 19);
            this.lblLevel.TabIndex = 8;
            this.lblLevel.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(454, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Level: ";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.Gold;
            this.lblScore.Location = new System.Drawing.Point(100, 10);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(0, 19);
            this.lblScore.TabIndex = 10;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.Gold;
            this.lbl.Location = new System.Drawing.Point(24, 10);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(57, 19);
            this.lbl.TabIndex = 11;
            this.lbl.Text = "Score: ";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(172, 279);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(256, 39);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Visible = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnReplay
            // 
            this.btnReplay.BackColor = System.Drawing.Color.White;
            this.btnReplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplay.ForeColor = System.Drawing.Color.Black;
            this.btnReplay.Location = new System.Drawing.Point(172, 215);
            this.btnReplay.Name = "btnReplay";
            this.btnReplay.Size = new System.Drawing.Size(256, 39);
            this.btnReplay.TabIndex = 7;
            this.btnReplay.Text = "Replay";
            this.btnReplay.UseVisualStyleBackColor = false;
            this.btnReplay.Visible = false;
            this.btnReplay.Click += new System.EventHandler(this.btnReplay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Wide Latin", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(162, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 59);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = ((System.Drawing.Image)(resources.GetObject("player.Image")));
            this.player.Location = new System.Drawing.Point(272, 401);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(50, 50);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 4;
            this.player.TabStop = false;
            // 
            // bulletEnemies
            // 
            this.bulletEnemies.Enabled = true;
            this.bulletEnemies.Interval = 20;
            this.bulletEnemies.Tick += new System.EventHandler(this.bulletEnemies_Tick);
            // 
            // moveBullets
            // 
            this.moveBullets.Enabled = true;
            this.moveBullets.Interval = 20;
            this.moveBullets.Tick += new System.EventHandler(this.moveBullets_Tick);
            // 
            // rightMoveTimer
            // 
            this.rightMoveTimer.Interval = 5;
            this.rightMoveTimer.Tick += new System.EventHandler(this.rightMoveTimer_Tick);
            // 
            // leftMoveTimer
            // 
            this.leftMoveTimer.Interval = 5;
            this.leftMoveTimer.Tick += new System.EventHandler(this.leftMoveTimer_Tick);
            // 
            // topMoveTimer
            // 
            this.topMoveTimer.Interval = 5;
            this.topMoveTimer.Tick += new System.EventHandler(this.topMoveTimer_Tick);
            // 
            // downMoveTmer
            // 
            this.downMoveTmer.Interval = 5;
            this.downMoveTmer.Tick += new System.EventHandler(this.downMoveTmer_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // moveEnemiesTimer
            // 
            this.moveEnemiesTimer.Enabled = true;
            this.moveEnemiesTimer.Tick += new System.EventHandler(this.moveEnemiesTimer_Tick);
            // 
            // Space_Shooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReplay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.player);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "Space_Shooter";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Space_Shooter";
            this.Load += new System.EventHandler(this.Space_Shooter_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Space_Shooter_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Space_Shooter_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer bulletEnemies;
        private System.Windows.Forms.Timer moveBullets;
        private System.Windows.Forms.Timer rightMoveTimer;
        private System.Windows.Forms.Timer leftMoveTimer;
        private System.Windows.Forms.Timer topMoveTimer;
        private System.Windows.Forms.Timer downMoveTmer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer moveEnemiesTimer;
    }
}