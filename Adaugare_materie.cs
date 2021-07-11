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
    public partial class Adaugare_materie : UserControl
    {
        public Adaugare_materie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { MessageBox.Show("Campul cu numele materiei trebuie completat!"); }
            else
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = ("Data Source=DESKTOP-CTB26SK;Initial Catalog=situatie_elevi;Integrated Security=True");
                sc.Open();

                
                if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[a-z A-Z ]*$"))
                {
                    MessageBox.Show("Numele materiei trebuie sa contina doar litere");
                    textBox1.Text = "";
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
                    //verifica daca materia exista deja in baza de date
                    SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Materii WHERE nume_materie=@nume_materie", sc);
                    command.Parameters.AddWithValue("@nume_materie", textBox1.Text);
                    var res = (int)command.ExecuteScalar();
                    if (res > 0)
                        MessageBox.Show("Aceasta materie exista deja in baza de date. Incercati sa adaugati o alta materie");
                    else
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = sc;
                        cmd.CommandText = @"INSERT INTO MATERII (NUME_MATERIE) VALUES (@nume_materie)";
                        cmd.Parameters.AddWithValue("@nume_materie", textBox1.Text);
                        if (sc.State == System.Data.ConnectionState.Open)
                        {


                            try
                            {
                                int n = cmd.ExecuteNonQuery();
                                if (n > 0)
                                {
                                    MessageBox.Show("Operatie de adaugare efectuata cu succes!");
                                }
                                textBox1.Text = "";
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
            }
        }

        public void updateDataGrid1()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = ("Data Source=DESKTOP-CTB26SK;Initial Catalog=situatie_elevi;Integrated Security=True");
            sc.Open();

            SqlCommand cmd = new SqlCommand("SELECT id_materie,nume_materie AS Materie  " +
                               "FROM Materii "+
                               "ORDER BY nume_materie", sc);

            cmd.Connection = sc;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt.DefaultView;
            sc.Close();
            this.dataGridView1.Columns["id_materie"].Visible = false;
        }

        private void Adaugare_materie_Load(object sender, EventArgs e)
        {
            label4.Visible = false;
            textBox2.Visible = false;
            updateDataGrid1();
        }

        private void stergereMaterieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "")
            { MessageBox.Show("Nu ati selectat inregistrarea ce contine materia pe care doriti sa o stergeti!"); }
            else
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = ("Data Source=DESKTOP-CTB26SK;Initial Catalog=situatie_elevi;Integrated Security=True");
                sc.Open();

                string stergere_materie = @"DELETE FROM  Materii  WHERE nume_materie=@nume_materie";
                SqlCommand cmd = new SqlCommand(stergere_materie, sc);

                cmd.Parameters.AddWithValue("@nume_materie", textBox1.Text);


                try
                {
                    int n = cmd.ExecuteNonQuery();
                    if (n > 0)
                    {
                        MessageBox.Show("Materie stearsa cu succes!");
                        this.updateDataGrid1();
                    }
                    textBox1.Text = "";
                    sc.Close();
                }
                catch (Exception excep)
                {
                    MessageBox.Show("Operatia de stergere a esuat!Verificati din nou daca ati selectat campul pe care doriti sa il stergeti!" + excep);
                }
            }
        }

        private void modificareDenumireMaterieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { MessageBox.Show("Nu ati selectat inregistrarea ce contine materia pe care doriti sa o stergeti!"); }
            else
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = ("Data Source=DESKTOP-CTB26SK;Initial Catalog=situatie_elevi;Integrated Security=True");
                sc.Open();

                string update_materie = @"UPDATE Materii SET nume_materie=@nume_materie WHERE id_materie=@id_materie";
                SqlCommand cmd = new SqlCommand(update_materie, sc);

                cmd.Parameters.AddWithValue("@nume_materie", textBox1.Text);
                cmd.Parameters.AddWithValue("@id_materie", textBox2.Text);
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
                        sc.Close();
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show("Operatia de update a esuat! Verificati din nou datele introduse!" + excep);
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[0].Value.ToString();
            }
        }
    }
}
