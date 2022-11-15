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
    public partial class Mathquiz : Form
    {
        //TableLayoutPanel table;
        TableLayoutPanel table2;
        string[] tehed = new string[4] {"+", "-", "*","/"};
        
        NumericUpDown numeric1, numeric2, numeric3, numeric4;
        Label time;
        Label timetext;
        Label plusLeftLabel, plusRightLabel;
        Label minusLeftLabel, minusRightLabel;
        Label timesLeftLabel, timesRightLabel;
        Label dividedLeftLabel, dividedRightLabel;
        Label vordub, margid;
        Button start;
        Button exit;
        Timer timer;
        Random rand = new Random();
        //Для появления рандомных чисел, вместо вопросительных знаков
        int addend1;
        int addend2;
        int minuend;
        int subtrahend;
        int multiplicand;
        int multiplier;
        int dividend;
        int divisor;

        int timeLeft;

        public Mathquiz()
        {
            this.Name = "Matemaatika viktoriin";
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Size = new Size(550, 450);
            this.BackColor = Color.LightSeaGreen;
            table2 = new TableLayoutPanel
            {
                BorderStyle = BorderStyle.FixedSingle,
                AutoSize = true,
                //BackColor = Color.CornflowerBlue,
                Location = new Point(0, 100),
            };
            table2.ColumnCount = 5;
            table2.RowCount = 4;

            for (int i = 0; i < 5; i++)
            {
                table2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            }
            for (int i = 0; i < 4; i++)
            {
                table2.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            }
            numeric1 = new NumericUpDown
            {
                Font = new Font("Cadalea", 18, FontStyle.Regular),
                Width = 100,
                Name = "sum"
            };
            numeric1.Enter += Numeric1_Enter;
            numeric2 = new NumericUpDown
            {
                Font = new Font("Cadalea", 18, FontStyle.Regular),
                Width = 100,
                Name = "min"
            };
            numeric2.Enter += Numeric2_Enter;
            numeric3 = new NumericUpDown
            {
                Font = new Font("Cadalea", 18, FontStyle.Regular),
                Width = 100,
                Name = "umn"
            };
            numeric3.Enter += Numeric3_Enter;
            numeric4 = new NumericUpDown
            {
                Font = new Font("Cadalea", 18, FontStyle.Regular),
                Width = 100,
                Name = "del"
            };
            numeric4.Enter += Numeric4_Enter;

            time = new Label
            {
                Name = "timeLabel",
                AutoSize = false,
                BorderStyle = BorderStyle.FixedSingle,
                Width = 200,
                Height = 30,
                Font = new Font("Cadalea", 16, FontStyle.Bold),
                Text = "",
            };
            timetext = new Label
            {
                Text = "Time left",
                Font = new Font("Cadalea", 16, FontStyle.Bold),
            };
            start = new Button
            {
                Text = "Alustage viktoriini",
                Name = "starButton",
                Font = new Font("Cadalea", 14, FontStyle.Bold),
                Width = 230,
                Height = 20,
                AutoSize = true,
                TabIndex = 0,
                Location = new Point(150, 290),
                BackColor = Color.White,
            };
            start.Click += Start_Click;
            exit = new Button
            {
                Text = "Tagasi",
                Name = "exitButton",
                Font = new Font("Cadalea", 14, FontStyle.Bold),
                Width = 230,
                Height = 20,
                AutoSize = true,
                TabIndex = 0,
                Location = new Point(150, 340),
                BackColor = Color.White,
            };
            exit.Click += Exit_Click;


            //-------------------------Label------------------
            //--------Plus------
            plusLeftLabel = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Cadalea", 20, FontStyle.Regular),
                Text = "?"
            };
            plusRightLabel = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Cadalea", 20, FontStyle.Regular),
                Text = "?"
            };
            //--------Minus--------
            minusLeftLabel = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Cadalea", 20, FontStyle.Regular),
                Text = "?"
            };
            minusRightLabel = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Cadalea", 20, FontStyle.Regular),
                Text = "?"
            };
            //--------Umno--------
            timesLeftLabel = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Cadalea", 20, FontStyle.Regular),
                Text = "?"
            };
            timesRightLabel = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Cadalea", 20, FontStyle.Regular),
                Text = "?"
            };
            //--------Delenie--------
            dividedLeftLabel = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Cadalea", 20, FontStyle.Regular),
                Text = "?"
            };

            dividedRightLabel = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Cadalea", 20, FontStyle.Regular),
                Text = "?"
            };
            //-----------------Timer--------------
            timer = new Timer
            {
                Interval = 1000
            };
            timer.Tick += Timer_Tick;
            //Loodud table
           
             FlowLayoutPanel flowe = new FlowLayoutPanel { FlowDirection = FlowDirection.RightToLeft, Dock = DockStyle.Top};
            flowe.Controls.Add(time);
            flowe.Controls.Add(timetext);
            table2.Controls.Add(numeric1);
            table2.SetCellPosition(numeric1, new TableLayoutPanelCellPosition(4, 0));
            table2.Controls.Add(numeric2);
            table2.SetCellPosition(numeric2, new TableLayoutPanelCellPosition(4, 1));
            table2.Controls.Add(numeric3);
            table2.SetCellPosition(numeric3, new TableLayoutPanelCellPosition(4, 2));
            table2.Controls.Add(numeric4);
            table2.SetCellPosition(numeric4, new TableLayoutPanelCellPosition(4, 3));

            //-----------Label-------------
            table2.Controls.Add(plusLeftLabel);
            table2.SetCellPosition(plusLeftLabel, new TableLayoutPanelCellPosition(0, 0));
            table2.Controls.Add(plusRightLabel);
            table2.SetCellPosition(plusRightLabel, new TableLayoutPanelCellPosition(2, 0));

            table2.Controls.Add(minusLeftLabel);
            table2.SetCellPosition(minusLeftLabel, new TableLayoutPanelCellPosition(0, 1));
            table2.Controls.Add(minusRightLabel);
            table2.SetCellPosition(minusRightLabel, new TableLayoutPanelCellPosition(2, 1));

            table2.Controls.Add(timesLeftLabel);
            table2.SetCellPosition(timesLeftLabel, new TableLayoutPanelCellPosition(0, 2));
            table2.Controls.Add(timesRightLabel);
            table2.SetCellPosition(timesRightLabel, new TableLayoutPanelCellPosition(2, 2));

            table2.Controls.Add(dividedLeftLabel);
            table2.SetCellPosition(dividedLeftLabel, new TableLayoutPanelCellPosition(0, 3));
            table2.Controls.Add(dividedRightLabel);
            table2.SetCellPosition(dividedRightLabel, new TableLayoutPanelCellPosition(2, 3));

            //Добавление "равно" в Label vordub и знаков при помощи цикла
            for (int i = 0; i < 4; i++)
            {
                margid = new Label
                {
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Calibri", 15, FontStyle.Regular),
                    Text = tehed[i]
                };
                table2.Controls.Add(margid);
                table2.SetCellPosition(margid, new TableLayoutPanelCellPosition(1, i));
                vordub = new Label
                {
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Calibri", 20, FontStyle.Regular),
                    Text = "="
                };
                table2.Controls.Add(vordub);
                table2.SetCellPosition(vordub, new TableLayoutPanelCellPosition(3, i));
            }
            this.Controls.Add(flowe);
            this.Controls.Add(table2);
            this.Controls.Add(start);
            this.Controls.Add(exit);
   
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Start start = new Start();
            start.StartPosition = FormStartPosition.CenterScreen;
            start.Show();
            this.Hide();
        }

        private void Numeric4_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
        private void Numeric3_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
        private void Numeric2_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
        private void Numeric1_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer.Stop();
                MessageBox.Show("Vastasite kõigile küsimustele õigesti!",
                                "Palju õnne! :)");
                start.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                time.Text = timeLeft + " seconds";
            }
            else
            {
                timer.Stop();
                time.Text = "Aeg on läbi!";
                MessageBox.Show("Sa ei jõudnud aegade lõpuni:(", "Vabandust!");
                numeric1.Value = addend1 + addend2;
                numeric2.Value = minuend - subtrahend;
                numeric3.Value = multiplicand * multiplier;
                numeric4.Value = dividend / divisor;
                start.Enabled = true;
            }
        }
        private void Start_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            start.Enabled = false;
        }
        public void StartTheQuiz()
        {
            addend1 = rand.Next(51);
            addend2 = rand.Next(51);

            //plus
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            numeric1.Value = 0;
            //minus
            minuend = rand.Next(1, 101);
            subtrahend = rand.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            numeric2.Value = 0;

            //umnozenie
            // Fill in the multiplication problem.
            multiplicand = rand.Next(2, 11);
            multiplier = rand.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            numeric3.Value = 0;

            //delenie
            divisor = rand.Next(2, 11);
            int temporaryQuotient = rand.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            numeric4.Value = 0;

            //Start the timer
            timeLeft = 30;
            time.Text = "30 seconds";
            timer.Start();
        }
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == numeric1.Value)
            && (minuend - subtrahend == numeric2.Value)
            && (multiplicand * multiplier == numeric3.Value)
            && (dividend / divisor == numeric4.Value))
            { return true; }
            else { return false; }           
        }
    }
}
