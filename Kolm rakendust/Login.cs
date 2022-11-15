using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.IO;

namespace Kolm_rakendust
{

    public partial class Login : Form
    {
        string connect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\Maksim_Lagunovski_TARpv20\Kolm_rakendust-master\Kolm rakendust\appData\KasutajaDbnew.mdf;Integrated Security=True";
        
        Button loginbutton, registrbutton;
        TextBox login = new TextBox
        {
            Location = new System.Drawing.Point(200, 100),//Point(x,y)
            Height = 90,
            Width = 150,
            Font = new Font("Caladea", 12, FontStyle.Bold)
        };
        TextBox parool = new TextBox
        {
            Location = new System.Drawing.Point(200, 160),//Point(x,y)
            Height = 90,
            Width = 150,
            Font = new Font("Caladea", 12, FontStyle.Bold),
            UseSystemPasswordChar = true
        };

        public Login()
        {

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "Sisselogimine";
            this.Size = new Size(500, 400);
            this.BackColor = Color.LightSeaGreen;

            Label nimilabel = new Label
            {
                Location = new System.Drawing.Point(165, 30),//Point(x,y)
                Height = 50,
                Width = 300,
                Text = "Sisselogimine vorm",
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

            Label passwordnimi = new Label
            {
                Location = new System.Drawing.Point(50, 160),//Point(x,y)
                Height = 50,
                Width = 150,
                Text = "Parool:",
                Font = new Font("Caladea", 16, FontStyle.Bold)
            };

            loginbutton = new Button
            {
                Text = "Login",
                Location = new System.Drawing.Point(90, 275),//Point(x,y)
                Width = 150,
                Height = 35,
                BackColor = Color.LightCyan,//LightBlue
                Font = new Font("Caladea", 10, FontStyle.Bold)
            };
            loginbutton.Click += Loginbutton_Click;
            registrbutton = new Button
            {
                Text = "Registr",
                Location = new System.Drawing.Point(270, 275),//Point(x,y)
                Width = 150,
                Height = 35,
                BackColor = Color.LightCyan,
                Font = new Font("Caladea", 10, FontStyle.Bold)
            };
            registrbutton.Click += Registrbutton_Click;

            this.Controls.Add(nimilabel);
            this.Controls.Add(loginnimi);
            this.Controls.Add(passwordnimi);
            this.Controls.Add(login);
            this.Controls.Add(parool);
            this.Controls.Add(loginbutton);
            this.Controls.Add(registrbutton);
        }

        public async void Loginbutton_Click(object sender, EventArgs e)
        {
            if (login.Text !="" && parool.Text !="")
            {
                File.WriteAllText(@"../../Data/Data.txt", string.Empty);
                SqlConnection con = new SqlConnection(connect);
                con.Open();
                int convert = 0;
                SqlCommand command = con.CreateCommand();
                command.CommandText = "SELECT Count(*) FROM Login WHERE kasutajanimi='" + login.Text + "' and parool ='" + parool.Text + "'";
                DataTable datatable = new DataTable();
                SqlDataAdapter podkl = new SqlDataAdapter(command);
                podkl.Fill(datatable);
                convert = Convert.ToInt32(datatable.Rows.Count.ToString());
                if (convert == 0)
                {
                    MessageBox.Show("Vale parool või sisselogimine");
                }
                else
                {
                    StreamWriter sw = new StreamWriter(@"../../Data/Data.txt");
                    sw.Write(login.Text);
                    sw.Close();
                    Start start = new Start();
                    start.StartPosition = FormStartPosition.CenterScreen;
                    start.Show();
                    this.Hide();
                    

                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Te pole kõike täitnud palun kontrollige!");
            }
            


        }
        private void Registrbutton_Click(object sender, EventArgs e)
        {
            Registr registr = new Registr();
            registr.StartPosition = FormStartPosition.CenterScreen;
            registr.Show();
            this.Hide();
        }
    }
}
