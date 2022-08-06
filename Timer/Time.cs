using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer
{
    public partial class Time : Form
    {
        Alarm alarmform = new Alarm();

        public Time()
        {
            InitializeComponent();
        }

        private void Time_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void alarmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alarmform.Show();
        }

        private void timerToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
