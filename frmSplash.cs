using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Viagens
{
    public partial class frmSplash : Form
    {
        bool increase = true;

        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            timer1.Interval = 190;
            timer1.Enabled = true;
            this.Opacity = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (increase)
                this.Opacity += 0.02D;
            if (this.Opacity == 1)
            {
                increase = false;
                this.Close();
            }
        }
    }
}
