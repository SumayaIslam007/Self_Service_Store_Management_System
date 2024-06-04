using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation_Layer
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            timer1.Start();
        }

        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            progressBar.Value = startpoint;
            if(progressBar.Value == 10000)
            {
                progressBar.Value = 0;
                timer1.Stop();
                LoginPage log = new LoginPage();
                this.Hide();
                log.Show();

            }
        }

        private void progressBar_Click(object sender, EventArgs e)
        {
            timer1.Start(); 
        }

        private void Splash_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }
    }
}
