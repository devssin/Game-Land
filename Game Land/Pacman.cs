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
    public partial class Pacman : Form
    {
        bool goup, godown, goleft, goright, isGameOver;



        int score, playerSpeed, redGhostSpeed, yellowGhostSpeed, pinkGhostX, pinkGhostY;

        private void Pacman_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                resetGame();
            }
        }

        public Pacman()
        {
            InitializeComponent();
            resetGame();
        }
        private void Pacman_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up)
            {
                goup = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }

        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;

            if (goleft == true)
            {
                pic_pacman.Left -= playerSpeed;
                pic_pacman.Image = Properties.Resources.pacleft;
            }
            if (goright == true)
            {
                pic_pacman.Left += playerSpeed;
                pic_pacman.Image = Properties.Resources.pacright;
            }
            if (godown == true)
            {
                pic_pacman.Top += playerSpeed;
                pic_pacman.Image = Properties.Resources.pacdown;
            }
            if (goup == true)
            {
                pic_pacman.Top -= playerSpeed;
                pic_pacman.Image = Properties.Resources.pacup;
            }

            if (pic_pacman.Left < -10)
            {
                pic_pacman.Left = 680;
            }
            if (pic_pacman.Left > 680)
            {
                pic_pacman.Left = -10;
            }

            if (pic_pacman.Top < -10)
            {
                pic_pacman.Top = 550;
            }
            if (pic_pacman.Top > 550)
            {
                pic_pacman.Top = 0;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "coin" && x.Visible == true)
                    {
                        if (pic_pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            score += 1;
                            x.Visible = false;
                        }
                    }
                    if ((string)x.Tag == "wall")
                    {
                        if (pic_pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameOver("You lose!");
                        }

                        if (pinkGhost.Bounds.IntersectsWith(x.Bounds))
                        {
                            pinkGhostX = -pinkGhostX;
                        }
                    }

                    if ((string)x.Tag == "ghost")
                    {
                        if (pic_pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameOver("You lose!");
                        }
                    }
                }
            }

            redGhost.Left += redGhostSpeed;
            if (redGhost.Bounds.IntersectsWith(wall1.Bounds) || redGhost.Bounds.IntersectsWith(wall2.Bounds))
            {
                redGhostSpeed = -redGhostSpeed;
            }


            yellowGhost.Left -= yellowGhostSpeed;
            if (yellowGhost.Bounds.IntersectsWith(wall3.Bounds) || yellowGhost.Bounds.IntersectsWith(wall4.Bounds))
            {
                yellowGhostSpeed = -yellowGhostSpeed;
            }

            pinkGhost.Left -= pinkGhostX;
            pinkGhost.Top -= pinkGhostY;

            if (pinkGhost.Top < 0 || pinkGhost.Top > 520)
            {
                pinkGhostY = -pinkGhostY;
            }
            if (pinkGhost.Left < 0 || pinkGhost.Left > 620)
            {
                pinkGhostX = -pinkGhostX;
            }

            if (score == 46)
            {
                gameOver("YOU WIN ");
            }
        }
        private void resetGame()
        {
            txtScore.Text = "Score: 0";
            score = 0;

            redGhostSpeed = 5;
            yellowGhostSpeed = 5;
            pinkGhostX = 5;
            pinkGhostY = 5;
            playerSpeed = 8;

            isGameOver = false;

            pic_pacman.Left = 39;
            pic_pacman.Top = 57;

            redGhost.Left = 236;
            redGhost.Top = 57;

            yellowGhost.Left = 463;
            yellowGhost.Top = 441;

            pinkGhost.Left = 546;
            pinkGhost.Top = 233;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    x.Visible = true;
                }
            }


            gameTimer.Start();
        }

        private void gameOver(string message)
        {
            isGameOver = true;
            gameTimer.Stop();

            txtScore.Text = "Score: " + score + Environment.NewLine + message;
        }

    }
}
