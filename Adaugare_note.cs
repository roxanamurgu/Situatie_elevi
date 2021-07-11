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

namespace Proiect_situatie_elevi
{
    public partial class Adaugare_note : UserControl
    {
        public Adaugare_note()
        {
            InitializeComponent();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {

            refreshdata1();

        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            refreshdata2();
        }

        public void refreshdata1()
        {
            DataRow dr1;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CTB26SK;Initial Catalog=situatie_elevi;Integrated Security=True");
            con.Open();

            //incarcare date despre elevi in combobox1
            SqlCommand cmd1 = new SqlCommand("SELECT id_elev, concat(concat( nume_elev, ' '), prenume_elev) AS nume_complet FROM Elevi GROUP BY id_elev, nume_elev, prenume_elev  ORDER BY  nume_elev,prenume_elev ASC", con);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);

            dr1 = dt1.NewRow();
            dt1.Rows.InsertAt(dr1, 0);

            comboBox1.ValueMember = "id_elev";

            comboBox1.DisplayMember = "nume_complet";
            comboBox1.DataSource = dt1;
            con.Close();
        }

        public void refreshdata2()
        {
            DataRow dr2;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CTB26SK;Initial Catalog=situatie_elevi;Integrated Security=True");
            con.Open();


            //incarcare denumiri materii in combobox2
            SqlCommand cmd2 = new SqlCommand("SELECT id_materie, nume_materie FROM Materii GROUP BY id_materie, nume_materie ORDER BY  nume_materie ASC", con);
            //sqlDataAdapter asigura conexiunea dintre interfata si sursa de date si
            //trimite solicitari de gestionare a datelor catre baza de date
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            //creez un obiect de tip DataTable care este o reprezentare a tabelelor
            //bazei de date și oferă o colecție de coloane și rânduri pentru stocarea datelor
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);

            dr2 = dt2.NewRow();
            dt2.Rows.InsertAt(dr2, 0);

            comboBox2.ValueMember = "id_materie";

            comboBox2.DisplayMember = "nume_materie";
            comboBox2.DataSource = dt2;

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1)
            { MessageBox.Show("Trebuie alese valori pentru fiecare camp!"); }
            else
            {

                SqlConnection sc = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                sc.ConnectionString = ("Data Source=DESKTOP-CTB26SK;Initial Catalog=situatie_elevi;Integrated Security=True");
                sc.Open();


                cmd.Connection = sc;
                cmd.CommandText = @"INSERT INTO NOTE (id_elev, id_materie, valoare) VALUES (@id_elev, @id_materie, @valoare)";

                var dataRowValue1 = (DataRowView)comboBox1.SelectedItem;
                var dataRowValue2 = (DataRowView)comboBox2.SelectedItem;
                cmd.Parameters.AddWithValue("@id_elev", dataRowValue1["id_elev"].ToString());
                cmd.Parameters.AddWithValue("@id_materie", dataRowValue2["id_materie"].ToString());
                cmd.Parameters.AddWithValue("@valoare", this.comboBox3.SelectedItem);


                if (sc.State == System.Data.ConnectionState.Open)
                {


                    try
                    {
                        int n = cmd.ExecuteNonQuery();
                        if (n > 0)
                        {
                            MessageBox.Show("Operatie de adaugare efectuata cu succes!");
                        }
                        comboBox1.SelectedIndex = -1;
                        comboBox2.SelectedIndex = -1;
                        comboBox3.SelectedIndex = -1;
                        sc.Close();
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show("Operatia de adaugare a esuat! Verificati din nou datele introduse!" + excep);
                    }
                }

            }
        }

        private void Adaugare_note_Load(object sender, EventArgs e)
        {
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
