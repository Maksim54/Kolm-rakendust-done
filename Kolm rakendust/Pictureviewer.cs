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
    public partial class Pictureviewer : Form
    {
        TableLayoutPanel tableLayotPanel;
        PictureBox image;
        CheckBox checkbox;
        OpenFileDialog openfiledialog = new OpenFileDialog
        {
            Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All files (*.*)|*.*",
            Title = "Select a Picture"
        };
        ColorDialog colordialog = new ColorDialog{ };
        public Pictureviewer()
        {
            this.Name = "Piltide vaatamise tööriist";
            this.Size = new Size(850, 700);
            
            tableLayotPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnStyles =
                {new ColumnStyle(SizeType.Percent, 15), new ColumnStyle(SizeType.Percent, 85)},
                RowStyles = {new RowStyle(SizeType.Percent, 90), new RowStyle(SizeType.Percent, 10)}
            };
            image = new PictureBox
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.Fixed3D,
            };
            checkbox = new CheckBox
            {
                Text = "Venitama"
            };
            FlowLayoutPanel flowe = new FlowLayoutPanel { FlowDirection = FlowDirection.RightToLeft, Dock = DockStyle.Fill};
            Button showimg = new Button { Text= "Näita pilti", AutoSize = true, Name = "nupp1" };
            Button clearimg = new Button { Text = "Selge pilt", AutoSize = true, Name = "nupp2" };
            Button background = new Button { Text = "Määrake tausta värv", AutoSize = true, Name = "knopka3" };
            Button close = new Button { Text = "Tagasi", AutoSize = true, Name = "knopka4" };
            checkbox.CheckedChanged += Checkbox_CheckedChanged;
            showimg.Click += Showimg_Click;
            clearimg.Click += Clearimg_Click;
            background.Click += Background_Click;
            close.Click += Close_Click;

            flowe.Controls.Add(showimg);
            flowe.Controls.Add(clearimg);
            flowe.Controls.Add(background);
            flowe.Controls.Add(close);

            tableLayotPanel.Controls.Add(image);
            tableLayotPanel.SetColumnSpan(image, 2);
            tableLayotPanel.Controls.Add(checkbox);
            tableLayotPanel.Controls.Add(flowe);
            tableLayotPanel.SetCellPosition(flowe, new TableLayoutPanelCellPosition(1, 1));
            this.Controls.Add(tableLayotPanel);
        }

        private void Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox.Checked)
            {
                image.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                image.SizeMode = PictureBoxSizeMode.Normal;
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Start start = new Start();
            start.StartPosition = FormStartPosition.CenterScreen;
            start.Show();
            this.Hide();
        }

        private void Background_Click(object sender, EventArgs e)
        {
            if(colordialog.ShowDialog()== DialogResult.OK)
            {
                image.BackColor = colordialog.Color;
            }
        }

        private void Clearimg_Click(object sender, EventArgs e)
        {
            image.Image = null;
        }

        private void Showimg_Click(object sender, EventArgs e)
        {
            if(openfiledialog.ShowDialog() == DialogResult.OK)
            {
                image.Load(openfiledialog.FileName);
            }
        }
    }
}
