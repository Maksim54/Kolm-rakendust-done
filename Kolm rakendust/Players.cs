using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kolm_rakendust
{
    public partial class Players : Form
    {
        DataGridView dataGridView;
        static string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\Maksim_Lagunovski_TARpv20\Kolm_rakendust-master\Kolm rakendust\appData\KasutajaDbnew.mdf;Integrated Security=True";
        /*Надо менять            ↑ ↑ ↑ ↑ ↑ ↑ ↑  вот это, если ты пересел за другой комп!!!!!!!!!*/
        SqlConnection connect_to_DB = new SqlConnection(conn);
        SqlCommand command;
        SqlDataAdapter adapter;

        Button tagasi;
        public Players()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "Mängijad";
            this.Size = new Size(800, 500);
            this.BackColor = Color.LightSeaGreen;

            connect_to_DB.Open();
            DataTable tabel = new DataTable();
            dataGridView = new DataGridView();
            //dataGridView.RowHeaderMouseClick += DataGridView_RowHeaderMouseClick;
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT kasutajanimi, email, sugu, vanus FROM [dbo].[Login]", connect_to_DB);
            adapter.Fill(tabel);
            dataGridView.DataSource = tabel;
            dataGridView.Location = new System.Drawing.Point(10, 10);
            dataGridView.Size = new System.Drawing.Size(770, 300);

            connect_to_DB.Close();
            tagasi = new Button
            {
                Text = "Tagasi",
                Location = new System.Drawing.Point(580, 380),//Point(x,y)
                Width = 200,
                Height = 37,
                BackColor = Color.White,//LightBlue
                Font = new Font("Cadalea", 10, FontStyle.Regular)
            };
            tagasi.Click += Tagasi_Click;

            this.Controls.Add(dataGridView);
            this.Controls.Add(tagasi);
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
