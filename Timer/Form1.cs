using System.Collections.Generic;
using System;
using System.Media;
using System.Timers;

namespace Timer
{
    public partial class Form1 : Form
    {
        readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\timer.txt";
        private int czas;
        Time timeform = new Time();
        Alarm alarmform = new Alarm();
        public Form1()
        {
            InitializeComponent();
            if (!File.Exists(path))
            {
                File.Create(path);
                
            }

            labelshowtimes.Text = File.ReadAllText(path);

            

        }


        private void buttonstart_Click(object sender, EventArgs e)
        {
            timer1.Start();
            czas++;
            labeltime.Text = czas.ToString();
        }

        private void stopbutton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            DialogResult dialog =
                MessageBox.Show("Do you want to save your time?", "Question", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                labelshowtimes.Text += labeltime.Text + " " + "Seconds" + "\n";   
                using StreamWriter sw = new StreamWriter(path, append: true);
                sw.Write(labeltime.Text + " " + "Seconds" + "\n");
                sw.Close();
                czas = 0;
                labeltime.Text = czas.ToString();
            }
        }

        private void timeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            timeform.Show();
            
        }

        private void alarmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alarmform.Show();
        }
    }
}
    
