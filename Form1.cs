using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_game
{
    public partial class lab : Form
    {
        int pipeSpeed = 8;
        int gravity = 4;
        int score = 0;
    
        public lab()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeButtom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            label1.Text= score.ToString();
            if(pipeButtom.Left<-50)
            {
                pipeButtom.Left = 800;
                score++;
            }
            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 550;
                score++;
            }
            if (flappyBird.Bounds.IntersectsWith(pipeButtom.Bounds)||flappyBird.Bounds.IntersectsWith(pipeTop.Bounds)||
                flappyBird.Bounds.IntersectsWith(ground.Bounds)||flappyBird.Bounds.IntersectsWith(sky.Bounds))
            {
                endGame();
            }

        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Space)
            {
                gravity= -4;
            }
        }

        private void gamekeyisup(object sender, KeyPressEventArgs e)
        {

        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 4;
            }
        }
        private void endGame()
        {
            gameTimer.Stop();
            label1.Text += "  Game over";

        }
    }
}
