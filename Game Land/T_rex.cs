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
    public partial class T_rex : Form
    {
        bool jumping = false;
        int jumpSpeed;
        int force = 12;
        int score = 0;
        int obstacleSpeed = 10;
        Random rand = new Random();
        int position;
        bool isGameOver = false;
        public T_rex()
        {
            InitializeComponent();
            GameReset();
        }

        private void gameTamer_Tick(object sender, EventArgs e)
        {
            trex.Top += jumpSpeed;
            txtScore.Text = "Score : " + score;

            if (jumping == true && force < 0)
            {
                jumping = false;
            }
            if (jumping == true)
            {
                jumpSpeed = -12;
                force -= 1;
            }
            else
            {
                jumpSpeed = 12;
            }

            if (trex.Top > 355 && jumping == false)
            {
                force = 12;
                trex.Top = 356;
                jumpSpeed = 0;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "obstacle")
                {
                    x.Left -= obstacleSpeed;

                    if (x.Left < -100)
                    {
                        x.Left = this.ClientSize.Width + rand.Next(200, 500) + (x.Width * 15);
                        score++;
                    }

                    if (trex.Bounds.IntersectsWith(x.Bounds))
                    {
                        gameTamer.Stop();
                        trex.Image = Properties.Resources.tdead;
                        txtScore.Text += " Press R to Start again  ";
                        isGameOver = true;
                    }

                }
            }

            if (score > 10)
            {
                obstacleSpeed = 15;
            }
            if (score > 20)
            {
                obstacleSpeed = 20;
            }
            if (score > 30)
            {
                obstacleSpeed = 25;
            }
            if (score > 40)
            {
                obstacleSpeed = 30;
            }

        }
        private void GameReset()
        {
            force = 12;
            jumpSpeed = 0;
            jumping = false;
            score = 0;
            obstacleSpeed = 10;
            txtScore.Text = "Score : " + score;
            trex.Image = Properties.Resources.running;
            isGameOver = false;

            trex.Top = 355;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "obstacle")
                {
                    position = this.ClientSize.Width + rand.Next(500, 800) + (x.Width * 10);

                    x.Left = position;
                }
            }

            gameTamer.Start();
        }

        private void T_rex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
            }
        }

        private void T_rex_KeyUp(object sender, KeyEventArgs e)
        {
            if (jumping == true)
            {
                jumping = false;
            }

            if (e.KeyCode == Keys.R && isGameOver == true)
            {
                GameReset();
            }
        }
    }
}
