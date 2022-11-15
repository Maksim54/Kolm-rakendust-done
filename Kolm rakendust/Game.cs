using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using Label = System.Windows.Forms.Label;

namespace Kolm_rakendust
{
    public partial class Game : Form
    {
        TableLayoutPanel tableLayotPanel;
        TableLayoutPanel table;
        TableLayoutPanel tablemeduim;
        Random random = new Random();
        Label[] labelsmail= new Label[16];
        List<string> icons = new List<string>()
        {
        "!", "!", "b", "b", "[", "[", "J", "J",
        "8", "8", ":", ":", "=", "=", "(", "("
        };
        Label firstClicked = null;
        Label secondClicked = null;
        Timer timer;
        Timer gametimer;

        int timeLeft;
        string time;
        Button tagasi;
        public Game()
        {
            this.Name = " Matching game";
            this.Size = new Size(550, 550);
            this.BackColor = Color.LightSeaGreen;
            tagasi = new Button
            {
                Text = "Tagasi",
                Location = new System.Drawing.Point(300, 480),//Point(x,y)
                Width = 200,
                Height = 37,
                BackColor = Color.White,//LightBlue
                Font = new Font("Cadalea", 10, FontStyle.Bold)
            };
            tagasi.Click += Tagasi_Click;
            tableLayotPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowStyles = { new RowStyle(SizeType.Percent, 90), new RowStyle(SizeType.Percent, 10) }
            };
            table = new TableLayoutPanel
            {
                BackColor = Color.LightSeaGreen,
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,

            };
            table.ColumnCount = 4;
            table.RowCount = 4;
            for (int i = 0; i < 4; i++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
                for (int j = 0; j < 4; j++)
                {
                    table.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
                    labelsmail[i] = new Label
                    {
                        BackColor = Color.CornflowerBlue,
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Cadalea", 48, FontStyle.Bold),
                        Text = "c"
                    };
                    table.Controls.Add(labelsmail[i], j, i);
                    labelsmail[i].Click += Game_Click1;

                }
            }
            timer = new Timer
            {
                Interval = 750
            };
            timer.Tick += Timer_Tick;
            gametimer = new Timer
            {
                Interval = 1000
            };
            gametimer.Tick += Gametimer_Tick;
            tableLayotPanel.Controls.Add(table);
            tableLayotPanel.SetCellPosition(table, new TableLayoutPanelCellPosition(0, 0));
            tableLayotPanel.Controls.Add(tagasi);
            tableLayotPanel.SetCellPosition(table, new TableLayoutPanelCellPosition(0, 0));
            this.Controls.Add(tableLayotPanel);
            AssignIconsToSquares();

        }

        private void Tagasi_Click(object sender, EventArgs e)
        {
            Keerukus keerukus = new Keerukus();
            keerukus.StartPosition = FormStartPosition.CenterScreen;
            keerukus.Show();
            this.Hide();
        }

        private void Gametimer_Tick(object sender, EventArgs e)
        {
            /*if (CheckForWinnertimer())
            {
                gametimer.Stop();
            }*/
        }
        private void CheckForWinner()
        {
            foreach (Control control in table.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }
            
            string a = gametimer.ToString();
            MessageBox.Show($"Sa sobisid kõik ikoonid!", "Õnnitlus");
            var answer = MessageBox.Show("Mängida uuesti?", "Mäng", MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                Game game = new Game();
                game.StartPosition = FormStartPosition.CenterScreen;
                game.Show();
                this.Hide();
            }
            else
            {
                Keerukus keerukus = new Keerukus();
                keerukus.StartPosition = FormStartPosition.CenterScreen;
                keerukus.Show();
                this.Hide();
            }
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;


            firstClicked = null;
            secondClicked = null;
        }

        private void Game_Click1(object sender, EventArgs e)
        {
            if (timer.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {

                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                CheckForWinner();

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                timer.Start();
                gametimer.Start();
            }
        }

        private void AssignIconsToSquares()
        {
            foreach (Control control in table.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }
    }
}
