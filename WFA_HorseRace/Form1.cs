using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_HorseRace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rnd = new Random();

        decimal bet1;
        decimal bet2;
        decimal bet3;

        decimal pot;

        decimal multi1 = 1.30m;
        decimal multi2 = 1.50m;
        decimal multi3 = 1.80m;

        

        private void btnBaslat_Click(object sender, EventArgs e)
        {

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //Movement section
            pbAt1.Left += rnd.Next(1, 30);
            pbAt2.Left += rnd.Next(1, 30);
            pbAt3.Left += rnd.Next(1, 30);
            //this is for manipulating the location. keep in mind .Right is a read-only value, we have to use "-". For now we'll send the random number

            //Victory message
            if (pbAt1.Right >= lblFinish.Left)
            {
                timer1.Stop();
                MessageBox.Show("1 wins");
                pot = bet1 * multi1;
                lblVictory.Text = pot.ToString() + " kazanıldı!";
            }
            else if (pbAt2.Right >= lblFinish.Left)
            {
                timer1.Stop();
                MessageBox.Show("2 wins");
                pot = bet2 * multi2;
                lblVictory.Text = pot.ToString() + " kazanıldı!";
            }
            else if (pbAt3.Right >= lblFinish.Left)
            {
                timer1.Stop();
                MessageBox.Show("3 wins");
                pot = bet3 * multi3;
                lblVictory.Text = pot.ToString() + " kazanıldı!";
            }
            
            //Announcer section

            //1 ahead
            else if (pbAt1.Right > pbAt2.Right)
            {
                if (pbAt1.Right > pbAt3.Right)
                {
                    lblSpiker.Text = "1 önde!";
                }
            }

            //2 ahead
            else if (pbAt2.Right > pbAt1.Right)
            {
                if (pbAt2.Right > pbAt3.Right)
                {
                    lblSpiker.Text = "2 önde!";
                }
            }

            //3 ahead
            else if (pbAt3.Right > pbAt1.Right)
            {
                if (pbAt3.Right > pbAt2.Right)
                {
                    lblSpiker.Text = "3 önde!";
                }
            }

        }

         //Beting part
        
        private void button1_Click(object sender, EventArgs e)
        {
            bet1 = nud1.Value;
            listBox1.Items.Add(bet1.ToString() + " puan 1'e yatırıldı!");
            btnBaslat.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bet2 = nud2.Value;
            listBox1.Items.Add(bet2.ToString() + " puan 2'e yatırıldı!");
            btnBaslat.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bet3 = nud3.Value;
            listBox1.Items.Add(bet3.ToString() + " puan 3'e yatırıldı!");
            btnBaslat.Enabled = true;
        }
    }
}
