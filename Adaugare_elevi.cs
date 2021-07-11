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
    public partial class Adaugare_elevi : UserControl
    {
        public System.Windows.Forms.DataGridViewRowHeaderCell HeaderCell { get; set; }
        public Adaugare_elevi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            { MessageBox.Show("Atat campul pentru nume cat si cel pentru prenume trebuie completate!"); }
            else
            {
                SqlConnection sc = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                sc.ConnectionString = ("Data Source=DESKTOP-CTB26SK;Initial Catalog=situatie_elevi;Integrated Security=True");
                sc.Open();

                cmd.Connection = sc;
                cmd.CommandText = @"INSERT INTO ELEVI (NUME_ELEV,PRENUME_ELEV) VALUES (@nume_elev, @prenume_elev)";
                if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[a-z A-Z ]*$"))
                {
                    MessageBox.Show("Numele trebuie sa contina doar litere");
                    return;
                }
                else
                {
                    //transforma prima litera din stringul introdus in litera mare 
                    string s = textBox1.Text.Substring(0, 1);
                    if (s != s.ToUpper())
                    {
                        int numeStart = textBox1.SelectionStart;
                        int numeLength = textBox1.SelectionLength;
                        textBox1.SelectionStart = 0;
                        textBox1.SelectionLength = 1;
                        textBox1.SelectedText = s.ToUpper();
                        textBox1.SelectionStart = numeStart;
                        textBox1.SelectionLength = numeLength;
                    }
                    
                    cmd.Parameters.AddWithValue("@nume_elev", textBox1.Text);
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^[a-z A-Z-]*$"))
                {
                    MessageBox.Show("Penumele trebuie sa contina doar litere");
                    return;
                }
                else
                {
                    //transforma prima litera din stringul introdus in litera mare si litera de dupa semnul minus "-" sau de dupa spatiu
                    string sp = textBox2.Text.Substring(0, 1);
                    if (sp != sp.ToUpper())
                    {
                        int prenumeStart = textBox2.SelectionStart;
                        int prenumeLength = textBox2.SelectionLength;
                        textBox2.SelectionStart = 0;
                        textBox2.SelectionLength = 1;
                        textBox2.SelectedText = sp.ToUpper();
                        textBox2.SelectionStart = prenumeStart;
                        textBox2.SelectionLength = prenumeLength;
                    }
                    if (textBox2.Text.Contains("-"))
                        {
                        int poz = textBox2.Text.IndexOf("-");
                        string s1 = textBox2.Text.Substring(poz + 1, 1);
                        if (s1 != s1.ToUpper())
                        {
                            int prenume2Start = textBox2.SelectionStart;
                            int prenume2Length = textBox2.SelectionLength;
                            textBox2.SelectionStart = poz + 1;
                            textBox2.SelectionLength = 1;
                            textBox2.SelectedText = s1.ToUpper();
                            textBox2.SelectionStart = prenume2Start;
                            textBox2.SelectionLength = prenume2Length;
                        }
                    }
                    if (textBox2.Text.Contains(" "))
                    {
                        int poz = textBox2.Text.IndexOf(" ");
                        string s1 = textBox2.Text.Substring(poz + 1, 1);
                        if (s1 != s1.ToUpper())
                        {
                            int prenume2Start = textBox2.SelectionStart;
                            int prenume2Length = textBox2.SelectionLength;
                            textBox2.SelectionStart = poz + 1;
                            textBox2.SelectionLength = 1;
                            textBox2.SelectedText = s1.ToUpper();
                            textBox2.SelectionStart = prenume2Start;
                            textBox2.SelectionLength = prenume2Length;
                        }
                    }
                    cmd.Parameters.AddWithValue("@prenume_elev", textBox2.Text);
                }
                if (sc.State == System.Data.ConnectionState.Open)
                {


                    try
                    {
                        int n = cmd.ExecuteNonQuery();
                        if (n > 0)
                        {
                            MessageBox.Show("Elev adaugat cu succes!");
                        }
                        textBox1.Text = "";
                        textBox2.Text = "";
                        updateDataGrid1();
                        sc.Close();
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show("Operatia de adaugare a esuat! Verificati din nou datele introduse!" + excep);
                    }
                }

            }
        }


        //Actualizarea listei cu elevi din baza de date dupa fiecare adaugare
        public void updateDataGrid1()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = ("Data Source=DESKTOP-CTB26SK;Initial Catalog=situatie_elevi;Integrated Security=True");
            sc.Open();
            SqlCommand cmd = new SqlCommand("SELECT id_elev, nume_elev AS Nume, prenume_elev AS Prenume " +
                               "FROM Elevi " +
                               "ORDER BY nume_elev, prenume_elev", sc);

            cmd.Connection = sc;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt.DefaultView;
            sc.Close();
            this.dataGridView1.Columns["id_elev"].Visible = false;
        }

        private void Adaugare_elevi_Load(object sender, EventArgs e)
        {
            label5.Visible = false;
            textBox3.Visible = false;
            updateDataGrid1();
        }

        private void modificareDateElevToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a;
            if (Int32.TryParse(textBox3.Text, out a) == false)
            { MessageBox.Show("Valorile introduse sunt incorecte!Va rugam sa verificati fiecare camp si datele introduse!"); }
            else
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = ("Data Source=DESKTOP-CTB26SK;Initial Catalog=situatie_elevi;Integrated Security=True");
                sc.Open();
                string update_elev = "UPDATE   Elevi SET nume_elev=@nume_elev, prenume_elev=@prenume_elev WHERE id_elev=@id_elev ";
                SqlCommand cmd = new SqlCommand(update_elev, sc);

                if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[a-z A-Z ]*$"))
                {
                    MessageBox.Show("Numele trebuie sa contina doar litere");
                    return;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@nume_elev", textBox1.Text);
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^[a-z A-Z ]*$"))
                {
                    MessageBox.Show("Prenumele trebuie sa contina doar litere");
                    return;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@prenume_elev", textBox2.Text);
                }

                cmd.Parameters.AddWithValue("@id_elev", textBox3.Text);

                if (sc.State == System.Data.ConnectionState.Open)
                {


                    try
                    {
                        int n = cmd.ExecuteNonQuery();
                        if (n > 0)
                        {
                            MessageBox.Show("Operatie de update efectuata cu succes!");
                            this.updateDataGrid1();
                        }
                        textBox1.Text = "";
                        textBox2.Text = "";
                        sc.Close();
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show("Operatia de update a esuat! Verificati din nou datele introduse!" + excep);
                    }
                }
            }
        }

        private void stergereDateElevToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a;
            if (Int32.TryParse(textBox3.Text, out a) == false)
            { MessageBox.Show("Nu ati selectat elevul pe care doriti sa il stergeti!"); }
            else
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = ("Data Source=DESKTOP-CTB26SK;Initial Catalog=situatie_elevi;Integrated Security=True");
                sc.Open();

                string stergere_elev = @"DELETE FROM  Elevi  WHERE id_elev=@id_elev";
                SqlCommand cmd = new SqlCommand(stergere_elev, sc);

                cmd.Parameters.AddWithValue("@id_elev", textBox3.Text);

                try
                {
                    int n = cmd.ExecuteNonQuery();
                    if (n > 0)
                    {
                        MessageBox.Show("Elev sters cu succes din lista!");
                        this.updateDataGrid1();
                    }
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                catch (Exception excep)
                {
                    MessageBox.Show("Operatia de stergere a esuat!Verificati din nou daca ati selectat campul pe care doriti sa il stergeti!" + excep);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                textBox3.Text = row.Cells[0].Value.ToString();
                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
            }
        }

        private void modificareDateElevToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            MessageBox.Show("Pentru a putea modifica datele unui elev din lista, selectati elevul, modificati numele sau prenumele si apoi dati click pe butonul din meniul aparut la click dreapta");
        }

        private void stergereDateElevToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            MessageBox.Show("Pentru a putea sterge un elev din lista, selectati elevul si apoi dati click pe butonul din meniul aparut la click dreapta");
        }
    }
}
