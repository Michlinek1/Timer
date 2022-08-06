using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer
{
    public partial class Alarm : Form
    {
        private int czas;
        public Alarm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonstart_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox1 == null)
            {
                MessageBox.Show("Textbox cannot be empty!", "Error");
            }

            try
            {
                timer1.Start();
                textBox1.Enabled = false;
                czas = int.Parse(textBox1.Text);
                czas--;
                textBox1.Text = czas.ToString();


                if (czas == 0)
                {
                    try
                    {
                        timer1.Stop();
                        SoundPlayer sound = new SoundPlayer(
                            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\alarm.wav");
                        sound.PlayLooping();
                        DialogResult dialog = MessageBox.Show("Time has ended!", "Alert", MessageBoxButtons.YesNo);
                        if (dialog == DialogResult.Yes)
                        {
                            Application.Exit();
                        }
                        else
                        {
                            sound.Stop();
                            textBox1.Text = "";
                            textBox1.Enabled = true;
                        }
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        timer1.Stop();
                        DialogResult dialog = MessageBox.Show("Time has ended!", "Alert", MessageBoxButtons.YesNo);
                        if (dialog == DialogResult.Yes)
                        {
                            Application.Exit();
                        }
                        else
                        {
                            textBox1.Text = "";
                            textBox1.Enabled = true;

                        }
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured!", "Error");
                textBox1.Text = "0";
                textBox1.Enabled = true;
                timer1.Stop();
            }
        }

        private void stopbutton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
