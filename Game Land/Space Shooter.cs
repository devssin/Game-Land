using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Game_Land
{
    public partial class Space_Shooter : Form
    {
        WindowsMediaPlayer backSound;   //Son de jeu
        WindowsMediaPlayer shotSound;   //Son de tire
        WindowsMediaPlayer explosion;
        PictureBox[] stars; // stars
        int backgroundSpeed;    // vitess de jeu
        int playerSpeed;    // vitess de joueur 
        Random rnd;
        PictureBox[] bullets; //balles
        int bulletSpeed;    //vitess de balls 
        PictureBox[] enemies; // enemies
        int enemySpeed;  //vitess d'enemie
        PictureBox[] enemiesBullets;
        int enemiesBulletSpeed;
        //=======================
        int level, score, difficulty;
        bool pause, gameOver;
        //=======================
        private void startTimer()
        {
            timer1.Start();
            moveEnemiesTimer.Start();
            moveBullets.Start();
            bulletEnemies.Start();
        }

        private void moveEnemies(PictureBox[] array, int speed)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Visible = true;
                array[i].Top += speed;
                if (array[i].Top > this.Height)
                {
                    array[i].Location = new Point((i + 1) * 50, -200);
                }
            }
        }

        private void collusion()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].Bounds.IntersectsWith(bullets[0].Bounds) || enemies[i].Bounds.IntersectsWith(bullets[1].Bounds)
                    || enemies[i].Bounds.IntersectsWith(bullets[2].Bounds))
                {
                    explosion.controls.play();
                    score += 1;
                    lblScore.Text = (score < 10) ? "0" + score.ToString() : score.ToString();
                    if (score % 30 == 0)
                    {
                        level += 1;
                        lblLevel.Text = (level < 10) ? "0" + level.ToString() : level.ToString();
                        if (enemySpeed <= 10 && enemiesBulletSpeed <= 10 && difficulty >= 0)
                        {
                            difficulty--;
                            enemySpeed++;
                            enemiesBulletSpeed++;
                        }
                        if (level == 10)
                        {
                            GameOver("You win");
                        }
                    }

                    enemies[i].Location = new Point((i + 1) * 50, -100);
                }
                if (player.Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    explosion.settings.volume = 30;
                    explosion.controls.play();
                    player.Visible = false;
                    GameOver("Game Over");
                }
            }
        }

        private void GameOver(String str)
        {
            label1.Text = str;
            label1.Location = new Point(this.Width / 2 - 240, 120);
            label1.Visible = true;
            label1.ForeColor = Color.Red;
            btnReplay.Visible = true;
            btnExit.Visible = true;
            backSound.controls.stop();
            stopTimer();

        }

   
        private void stopTimer()
        {
            timer1.Stop();
            moveBullets.Stop();
            moveEnemiesTimer.Stop();
            bulletEnemies.Stop();
        }

        

        public Space_Shooter()
        {
            InitializeComponent();
        }

        private void rightMoveTimer_Tick(object sender, EventArgs e)
        {
            if (player.Right < 500)
            {
                player.Left += playerSpeed;
            }
        }

        private void topMoveTimer_Tick(object sender, EventArgs e)
        {

            if (player.Top > 10)
            {
                player.Top -= playerSpeed;
            }
        }

        private void downMoveTmer_Tick(object sender, EventArgs e)
        {
            if (player.Top < 400)
            {
                player.Top += playerSpeed;
            }
        }

        private void moveBullets_Tick(object sender, EventArgs e)
        {
            shotSound.controls.play();
            for (int i = 0; i < bullets.Length; i++)
            {
                if (bullets[i].Top > 0)
                {
                    bullets[i].Visible = true;
                    bullets[i].Top -= bulletSpeed;
                    collusion();
                }
                else
                {
                    bullets[i].Visible = false;
                    bullets[i].Location = new Point(player.Location.X + 20, player.Location.Y - 1 * 30);
                }
            }
        }

        private void moveEnemiesTimer_Tick(object sender, EventArgs e)
        {
            moveEnemies(enemies, enemySpeed);
        }

        private void bulletEnemies_Tick(object sender, EventArgs e)
        {

            for (int i = 0; i < enemiesBullets.Length - difficulty; i++)
            {
                if (enemiesBullets[i].Top < this.Height)
                {
                    enemiesBullets[i].Visible = true;
                    enemiesBullets[i].Top += enemiesBulletSpeed;
                    CollusionWitheEnemiesBullets();
                }
                else
                {
                    enemiesBullets[i].Visible = false;
                    int x = rnd.Next(0, 10);
                    enemiesBullets[i].Location = new Point(enemies[x].Location.X + 20, enemies[x].Location.Y + 30);
                }
            }
        }
        private void CollusionWitheEnemiesBullets()
        {
            for (int i = 0; i < enemiesBullets.Length; i++)
            {
                if (enemiesBullets[i].Bounds.IntersectsWith(player.Bounds))
                {
                    enemiesBullets[i].Visible = false;
                    explosion.settings.volume = 30;
                    explosion.controls.play();
                    player.Visible = false;
                    GameOver("Game Over");
                }
            }
        }

        private void btnReplay_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            Space_Shooter_Load(e, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void Space_Shooter_KeyDown(object sender, KeyEventArgs e)
        {
            if (!pause)
            {
                if (e.KeyCode == Keys.Up)
                {
                    topMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Down)
                {
                    downMoveTmer.Start();
                }
                if (e.KeyCode == Keys.Left)
                {
                    leftMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Right)
                {
                    rightMoveTimer.Start();
                }
            }
        }

        private void Space_Shooter_KeyUp(object sender, KeyEventArgs e)
        {
            rightMoveTimer.Stop();
            leftMoveTimer.Stop();
            downMoveTmer.Stop();
            topMoveTimer.Stop();
            if (e.KeyCode == Keys.Space)
            {
                if (!gameOver)
                {
                    if (pause)
                    {
                        startTimer();
                        backSound.controls.play();
                        label1.Visible = false;
                        pause = false;
                    }
                    else
                    {
                        label1.Location = new Point(this.Width / 2 - 220, 150);
                        label1.Text = "PAUSED";
                        label1.Visible = true;
                        pause = true;
                        backSound.controls.pause();
                        stopTimer();
                    }
                }
            }
        }

        private void Space_Shooter_Load(object sender, EventArgs e)
        {
            //Initialisation des stars
            stars = new PictureBox[10];
            backgroundSpeed = 4;
            enemySpeed = 5;
            playerSpeed = 4;
            enemiesBulletSpeed = 4;
            rnd = new Random();
            //=================
            pause = false;
            score = 0;
            difficulty = 9;
            level = 0;
            //=================
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new PictureBox();
                stars[i].BorderStyle = BorderStyle.None;
                stars[i].Location = new Point(rnd.Next(20, 500), rnd.Next(-10, 400));
                if (i % 2 == 1)
                {
                    stars[i].Size = new Size(2, 2);
                    stars[i].BackColor = Color.Wheat;
                }
                else
                {
                    stars[i].Size = new Size(3, 3);
                    stars[i].BackColor = Color.DimGray;
                }
                this.Controls.Add(stars[i]);
            }

            //importer l'image de balle
            Image bullet = Image.FromFile(@"Images\Space_Shooter\munition.png");

            //initialisation des balles
            bullets = new PictureBox[3];
            bulletSpeed = 30;

            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i] = new PictureBox();
                bullets[i].Image = bullet;
                bullets[i].Size = new Size(8, 8);
                bullets[i].SizeMode = PictureBoxSizeMode.Zoom;
                bullets[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(bullets[i]);
            }

            //Initialisation de Sons
            backSound = new WindowsMediaPlayer();
            shotSound = new WindowsMediaPlayer();
            explosion = new WindowsMediaPlayer();

            //Importation des fichiers de sons
            backSound.URL = @"songs\GameSong.mp3";
            shotSound.URL = @"songs\shoot.mp3";
            explosion.URL = @"songs\boom.mp3";

            backSound.settings.setMode("loop", true);
            backSound.settings.volume = 5;
            shotSound.settings.volume = 1;
            explosion.settings.volume = 6;
            backSound.controls.play();

            //Chargement des enemies
            Image enemy1 = Image.FromFile(@"Images\Space_Shooter\E1.png");
            Image enemy2 = Image.FromFile(@"Images\Space_Shooter\E2.png");
            Image enemy3 = Image.FromFile(@"Images\Space_Shooter\E3.png");
            Image boss1 = Image.FromFile(@"Images\Space_Shooter\Boss1.png");
            Image boss2 = Image.FromFile(@"Images\Space_Shooter\Boss2.png");
            enemies = new PictureBox[10];

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new PictureBox();
                enemies[i].Visible = false;
                enemies[i].Size = new Size(40, 40);
                enemies[i].BorderStyle = BorderStyle.None;
                enemies[i].SizeMode = PictureBoxSizeMode.Zoom;
                this.Controls.Add(enemies[i]);
                enemies[i].Location = new Point((i + 1) * 50, -50);
            }
            enemies[0].Image = boss1;
            enemies[1].Image = enemy1;
            enemies[2].Image = enemy3;
            enemies[3].Image = enemy2;
            enemies[4].Image = enemy3;
            enemies[5].Image = enemy1;
            enemies[6].Image = enemy2;
            enemies[7].Image = enemy2;
            enemies[8].Image = enemy3;
            enemies[9].Image = boss2;


            enemiesBullets = new PictureBox[10];
            for (int i = 0; i < enemiesBullets.Length; i++)
            {
                enemiesBullets[i] = new PictureBox();
                enemiesBullets[i].Visible = false;
                enemiesBullets[i].Size = new Size(2, 25);
                enemiesBullets[i].BackColor = Color.Yellow;
                int x = rnd.Next(0, 10);
                enemiesBullets[i].Location = new Point(enemies[x].Location.X, enemies[x].Location.Y - 20);
                this.Controls.Add(enemiesBullets[i]);
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < stars.Length / 2; i++)
            {
                stars[i].Top += backgroundSpeed;
                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }
            for (int i = stars.Length / 2; i < stars.Length; i++)
            {
                stars[i].Top -= backgroundSpeed;
                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }
        }
        private void leftMoveTimer_Tick(object sender, EventArgs e)
        {
            if (player.Left > 10)
            {
                player.Left -= playerSpeed;
            }
        }
    }
}
