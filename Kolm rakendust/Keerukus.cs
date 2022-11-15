using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kolm_rakendust
{
    public partial class Keerukus : Form
    {
        Button lihtne, keeruline, tagasi;

        public Keerukus()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "Keerukus";
            this.Size = new Size(500, 280);
            this.BackColor = Color.LightSeaGreen;

            lihtne = new Button
            {
                Text = "Lihtne",
                Width = 180,
                Height = 70,
                Location = new System.Drawing.Point(10, 60),
                BackColor = Color.White,
            };
            lihtne.Click += Lihtne_Click;
            keeruline = new Button
            {
                Text = "Raske",
                Width = 180,
                Height = 70,
                Location = new System.Drawing.Point(290, 60),
                BackColor = Color.White,
            };
            keeruline.Click += Keeruline_Click;
            tagasi = new Button
            {
                Text = "Tagasi",
                Width = 380,
                Height = 30,
                Location = new System.Drawing.Point(50, 190),
                BackColor = Color.White,
            };
            tagasi.Click += Tagasi_Click;

            this.Controls.Add(lihtne);
            this.Controls.Add(keeruline);
            this.Controls.Add(tagasi);
        }

        private void Lihtne_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            game.StartPosition = FormStartPosition.CenterScreen;
            game.Show();
            this.Hide();
        }

        private void Keeruline_Click(object sender, EventArgs e)
        {
            Gamehard gamehard = new Gamehard();
            gamehard.StartPosition = FormStartPosition.CenterScreen;
            gamehard.Show();
            this.Hide();
        }

        private void Tagasi_Click(object sender, EventArgs e)
        {
            Start start = new Start();
            start.StartPosition = FormStartPosition.CenterScreen;
            start.Show();
            this.Hide();
        }
    }
}
