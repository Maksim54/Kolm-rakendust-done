using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Kolm_rakendust
{
    public partial class Registr : Form
    {
        
        Button registrbutton, back;
        string[] sugupolo = { "Mees", "Naine" };
        TextBox kasutaja = new TextBox
        {
            Location = new System.Drawing.Point(200, 102),//Point(x,y)
            Height = 90,
            Width = 150,
            Font = new Font("Caladea", 12, FontStyle.Bold),
        };
        TextBox email = new TextBox
        {
            Location = new System.Drawing.Point(200, 162),//Point(x,y)
            Height = 90,
            Width = 150,
            Font = new Font("Caladea", 12, FontStyle.Bold),

        };
        ComboBox sugubox = new ComboBox
        {
            //DataSource = sugupolo.ToArray(),
            Location = new System.Drawing.Point(200, 222),//Point(x,y)
            Height = 50,
            Width = 150,
            Font = new Font("Caladea", 12, FontStyle.Bold),         
            DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList,
            BackColor = Color.White,
    };
       
        //sugubox.Items.Add("Mees");

        NumericUpDown vanus = new NumericUpDown
        {
            Location = new System.Drawing.Point(200, 282),//Point(x,y)
            Height = 90,
            Width = 150,
            Font = new Font("Caladea", 12, FontStyle.Bold),

        };
        TextBox password = new TextBox
        {
            Location = new System.Drawing.Point(200, 342),//Point(x,y)
            Height = 90,
            Width = 150,
            Font = new Font("Caladea", 12, FontStyle.Bold),
            UseSystemPasswordChar = true

        };

        public Registr()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "Registreerimine";
            this.Size = new Size(500, 600);
            this.BackColor = Color.LightSeaGreen;


            Label nimilabel = new Label
            {
                Location = new System.Drawing.Point(150, 30),//Point(x,y)
                Height = 50,
                Width = 300,
                Text = "Registreerimine vorm",
                Font = new Font("Caladea", 16, FontStyle.Bold)
            };

            Label loginnimi = new Label
            {
                Location = new System.Drawing.Point(50, 100),//Point(x,y)
                Height = 50,
                Width = 150,
                Text = "Login:",
                Font = new Font("Caladea", 16, FontStyle.Bold)
            };
            Label emaillabel = new Label
            {
                Location = new System.Drawing.Point(50, 160),//Point(x,y)
                Height = 50,
                Width = 150,
                Text = "Email:",
                Font = new Font("Caladea", 16, FontStyle.Bold)
            };
            
            Label sugulabel = new Label
            {
                Location = new System.Drawing.Point(50, 220),//Point(x,y)
                Height = 50,
                Width = 150,
                Text = "Sugu:",
                Font = new Font("Caladea", 16, FontStyle.Bold)
            };
            Label vanuslabel = new Label
            {
                Location = new System.Drawing.Point(50, 280),//Point(x,y)
                Height = 50,
                Width = 150,
                Text = "Vanus:",
                Font = new Font("Caladea", 16, FontStyle.Bold)
            };
            Label passwordnimi = new Label
            {
                Location = new System.Drawing.Point(50, 340),//Point(x,y)
                Height = 50,
                Width = 150,
                Text = "Parool:",
                Font = new Font("Caladea", 16, FontStyle.Bold)
            };
            /*loginbutton = new Button
            {
                Text = "Registr",
                Location = new System.Drawing.Point(200, 250),//Point(x,y)
                Width = 150,
                Height = 35,
                BackColor = Color.LightYellow
            };*/
            registrbutton = new Button
            {
                Text = "Registr",
                Location = new System.Drawing.Point(90, 450),//Point(x,y)
                Width = 150,
                Height = 35,
                BackColor = Color.LightCyan,
                Font = new Font("Caladea", 10, FontStyle.Bold)
            };
            registrbutton.Click += Registrbutton_Click;
            back = new Button
            {
                Text = "Tagasi",
                Location = new System.Drawing.Point(280, 450),//Point(x,y)
                Width = 150,
                Height = 35,
                BackColor = Color.LightCyan,
                Font = new Font("Caladea", 10, FontStyle.Bold)
            };
            back.Click += Back_Click;

            sugubox.Items.AddRange(new string[] { "Mees", "Naine" });//lisamine variantid "sugubox"
            //sugubox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            //sugubox.ReadOnly = true;
            this.Controls.Add(nimilabel);
            this.Controls.Add(loginnimi);
            this.Controls.Add(passwordnimi);
            this.Controls.Add(emaillabel);
            this.Controls.Add(sugulabel);
            this.Controls.Add(vanuslabel);
            this.Controls.Add(kasutaja);           
            this.Controls.Add(email);
            this.Controls.Add(sugubox);
            this.Controls.Add(vanus);
            this.Controls.Add(password);
            this.Controls.Add(registrbutton);
            this.Controls.Add(back);
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.StartPosition = FormStartPosition.CenterScreen;
            login.Show();
            this.Hide();
        }

        static string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\Maksim_Lagunovski_TARpv20\Kolm_rakendust-master\Kolm rakendust\appData\KasutajaDbnew.mdf;Integrated Security=True";
        /*Надо менять            ↑ ↑ ↑ ↑ ↑ ↑ ↑  вот это, если ты пересел за другой комп!!!!!!!!!*/
        SqlConnection connect_to_DB = new SqlConnection(conn);

        SqlCommand command;
        SqlDataAdapter adapter;

        private async void Registrbutton_Click(object sender, EventArgs e)
        {
            if (kasutaja.Text != "" && email.Text != "" && sugubox.Text != "" && vanus.Text != "" && password.Text != "")
            {
                try
                {
                    File.WriteAllText(@"../../Data/Data.txt", string.Empty);
                    command = new SqlCommand("INSERT INTO Login(kasutajanimi,email,sugu,vanus,parool) VALUES(@nimi,@email,@sugu,@vanus,@parool)", connect_to_DB);
                    connect_to_DB.Open();
                    command.Parameters.AddWithValue("@nimi", kasutaja.Text);
                    command.Parameters.AddWithValue("@email", email.Text);
                    command.Parameters.AddWithValue("@sugu", sugubox.Text);
                    command.Parameters.AddWithValue("@vanus", vanus.Text);
                    command.Parameters.AddWithValue("@parool", password.Text);

                    command.ExecuteNonQuery();
                    connect_to_DB.Close();

                    MessageBox.Show("Registreerimine oli edukas, hea puhkus!");
                    StreamWriter sw = new StreamWriter(@"../../Data/Data.txt");
                    sw.Write(kasutaja.Text);
                    sw.Close();
                    Start start = new Start();
                    start.StartPosition = FormStartPosition.CenterScreen;
                    start.Show();
                    this.Hide();
                }
                catch (Exception)
                {

                    MessageBox.Show("Ei saanud registreeruda!");
                }
            }
            else
            {
                MessageBox.Show("Te pole kõike täitnud palun kontrollige!");
            }
            
        }
    }
}
