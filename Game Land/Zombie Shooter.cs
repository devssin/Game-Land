using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Land
{

    public partial class Zombie_Shooter : Form
    {
        bool GoLeft, GoRight, GoUp, GoDown, GameOver;
        string facing = "up";
        int PlayHelth = 100;
        int speed = 10;
        int ammo = 10;
        int Zombiespeeding = 3;
        int score = 0;
        Random rnd = new Random();

        private void Zombie_Shooter_KeyDown(object sender, KeyEventArgs e)
        {
            if (GameOver == true)
            {
                return;
            }
            if (e.KeyCode == Keys.Left)
            {
                GoLeft = true;
                facing = "left";
                player.Image = Properties.Resources.left;
            }
            if (e.KeyCode == Keys.Right)
            {
                GoRight = true;
                facing = "right";
                player.Image = Properties.Resources.right;
            }
            if (e.KeyCode == Keys.Up)
            {
                GoUp = true;
                facing = "up";
                player.Image = Properties.Resources.up;
            }
            if (e.KeyCode == Keys.Down)
            {
                GoDown = true;
                facing = "down";
                player.Image = Properties.Resources.down;
            }
        }

        private void Zombie_Shooter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                GoLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                GoRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                GoUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                GoDown = false;
            }
            if (e.KeyCode == Keys.Space && ammo > 0 && GameOver == false)
            {
                ammo--;
                ShootBullet(facing);
                if (ammo < 1)
                {
                    DropAmmo();
                }
            }
            if (e.KeyCode == Keys.Enter && GameOver == true)
            {
                RestartGame();
            }
        }

        List<PictureBox> ZombieList = new List<PictureBox>();

        public Zombie_Shooter()
        {
            InitializeComponent();
            RestartGame();

        }


        private void Zombie_Shooter_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (PlayHelth > 1)
            {
                HelthBar.Value = PlayHelth;
            }
            else
            {
                GameOver = true;
                player.Image = Properties.Resources.dead;
                timer1.Stop();
            }
            txtAmmo.Text = "Ammo: " + ammo.ToString();
            txtScore.Text = "Kills: " + score.ToString();
            if (GoLeft == true && player.Left > 0)
            {
                player.Left -= speed;
            }
            if (GoRight == true && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += speed;
            }
            if (GoUp == true && player.Top > 45)
            {
                player.Top -= speed;
            }
            if (GoDown == true && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += speed;
            }
            foreach (Control x in Controls)
            {
                if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        ammo += 5;
                    }
                }
                if (x is PictureBox && (string)x.Tag == "zombie")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        PlayHelth--;
                    }
                    if (x.Left > player.Left)
                    {
                        x.Left -= Zombiespeeding;
                        ((PictureBox)x).Image = Properties.Resources.zleft;
                    }
                    if (x.Left < player.Left)
                    {
                        x.Left += Zombiespeeding;
                        ((PictureBox)x).Image = Properties.Resources.zright;
                    }
                    if (x.Top > player.Top)
                    {
                        x.Top -= Zombiespeeding;
                        ((PictureBox)x).Image = Properties.Resources.zup;
                    }
                    if (x.Top < player.Top)
                    {
                        x.Top += Zombiespeeding;
                        ((PictureBox)x).Image = Properties.Resources.zdown;
                    }
                }
                foreach (Control j in this.Controls)
                {
                    if (j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "zombie")
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            score++;
                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                            ZombieList.Remove((PictureBox)x);
                            MakingZombies();
                        }
                    }
                }
            }
        }
        private void ShootBullet(string direction)
        {
            Bullet shootBullet = new Bullet();
            shootBullet.direction = direction;
            shootBullet.bulletLeft = player.Left + (player.Width / 2);
            shootBullet.bulletTop = player.Top + (player.Height / 2);
            shootBullet.MakeBullet(this);
        }
        private void MakingZombies()
        {
            PictureBox zombie = new PictureBox();
            zombie.Tag = "zombie";
            zombie.Image = Image.FromFile(@"Images\Zombie_Shooter\down.png");
            zombie.Left = rnd.Next(0, 900);
            zombie.Top = rnd.Next(0, 800);
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;
            ZombieList.Add(zombie);
            this.Controls.Add(zombie);
        }
        private void DropAmmo()
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo_Image;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Tag = "ammo";
            ammo.Left = rnd.Next(10, this.ClientSize.Width - ammo.Width);
            ammo.Top = rnd.Next(60, this.ClientSize.Height - ammo.Height);
            this.Controls.Add(ammo);
            ammo.BringToFront();
            player.BringToFront();
        }
        private void RestartGame()
        {
            foreach (PictureBox i in ZombieList)
            {
                this.Controls.Remove(i);
            }
            ZombieList.Clear();
            for (int i = 0; i < 3; i++)
            {
                MakingZombies();
            }
            GoUp = false;
            GoDown = false;
            GoLeft = false;
            GoRight = false;
            GameOver = false;
            player.Image = Properties.Resources.up;
            PlayHelth = 100;
            score = 0;
            ammo = 10;
            timer1.Start();
        }
    }
}
    class Bullet
    {
        public string direction;
        public int bulletTop;
        public int bulletLeft;
        private int speed = 20;
        private PictureBox bullet = new PictureBox();
        private Timer bulletTimer = new Timer();

        public void MakeBullet(Form form)
        {
            bullet.BackColor = Color.White;
            bullet.Size = new Size(5, 5);
            bullet.Tag = "bullet";
            bullet.Left = bulletLeft;
            bullet.Top = bulletTop;
            bullet.BringToFront();

            form.Controls.Add(bullet);

            bulletTimer.Interval = speed;
            bulletTimer.Tick += new EventHandler(BulletTimerEvent);
            bulletTimer.Start();

        }
        private void BulletTimerEvent(object sender, EventArgs e)
        {
            if (direction == "left")
            {
                bullet.Left -= speed;
            }
            if (direction == "right")
            {
                bullet.Left += speed;
            }
            if (direction == "up")
            {
                bullet.Top -= speed;
            }
            if (direction == "down")
            {
                bullet.Top += speed;
            }

            if (bullet.Left < 40 || bullet.Left > 860 || bullet.Top < 10 || bullet.Top > 600)
            {
                bulletTimer.Stop();
                bulletTimer.Dispose();
                bulletTimer = null;
                bullet.Dispose();
                bullet = null;
            }
        }
    }

