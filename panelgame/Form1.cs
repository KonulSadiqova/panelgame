using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace panelgame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        Random r = new Random();
        Random g = new Random();
        Random b = new Random();

        Random xL = new Random();
        Random yL = new Random();
        int count = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            Panel p = new Panel();
            p.Size = new Size(60, 60);
            p.BackColor = Color.FromArgb(r.Next(0, 256), g.Next(0, 256), b.Next(0, 256));
            p.Location = new Point(xL.Next(0, 636), yL.Next(0, 300));

            if (p.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                PlayBombSound();

                DialogResult result = MessageBox.Show("Bomba partladı! Oyun bitdi.\nYenidən başlamaq üçün OK düyməsinə basın.", "Oyun Bitdi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    ResetGame();
                    return;
                }
            }

            this.Controls.Add(p);
            label2.Text = count.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(xL.Next(0, 636), yL.Next(0, 300));
        }

        private void PlayBombSound()
        {
            try
            {
                SoundPlayer player = new SoundPlayer(Properties.Resources.explosion);
                player.Play();
            }
            catch (Exception)
            {
            }
        }

        private void ResetGame()
        {
            count = 0;
            label2.Text = count.ToString();

            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                if (this.Controls[i] is Panel && this.Controls[i] != panel1)
                {
                    this.Controls.RemoveAt(i);
                }
            }

            pictureBox1.Location = new Point(xL.Next(0, 636), yL.Next(0, 300));
        }
    }
}