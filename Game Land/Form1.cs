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
    public partial class GameLand : Form
    {
        public GameLand()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Space_Shooter space = new Space_Shooter();
            space.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Zombie_Shooter zombie = new Zombie_Shooter();
            zombie.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Pacman pacman = new Pacman();
            pacman.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            T_rex t_Rex = new T_rex();
            t_Rex.Show();
        }
    }
}
