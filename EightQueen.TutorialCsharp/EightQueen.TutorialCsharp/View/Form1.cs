using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EightQueen.TutorialCsharp.View
{
    public partial class UI : Form
    {
        public UI()
        {
            InitializeComponent();
        }
       
        private void lbComputer_Click(object sender, EventArgs e)
        {
            Computer computer = new Computer();
            computer.Show();
        }

        private void lbPlayer_Click(object sender, EventArgs e)
        {
            Player player = new Player();
            player.Show();
        }
        int x = 12, y = 660, a = 1;

        Random random = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                x += a;
                label3.Location = new Point(x, y);
                if(x >= 679)
                {
                    a = -1;
                    label3.ForeColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                }
                if(x <= 12)
                {
                    a = 1;
                    label3.ForeColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
