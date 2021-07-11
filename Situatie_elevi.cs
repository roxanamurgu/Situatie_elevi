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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Proiect_situatie_elevi
{
    public partial class Situatie_elevi : Form
    {
        public Situatie_elevi()
        {
            InitializeComponent();
        }


        //Calculul si inserarea mediilor tuturor elevilor, la toate materiile in tabelul Medii
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = ("Data Source=DESKTOP-CTB26SK;Initial Catalog=situatie_elevi;Integrated Security=True");
            sc.Open();

            //sterge toate datele existente in tabel pentru a evita existenta duplicatelor
            string stergere_date = @"DELETE FROM Medii;";
            SqlCommand cmd = new SqlCommand(stergere_date, sc);
            cmd.ExecuteNonQuery();

           try
            {
                //interogarea care selecteaza id_elev, id_materie si calculeaza media necesare
                //pentru a fi inserate in tabelul Medii 
                string query = "SELECT e.id_elev, m.id_materie, AVG(n.valoare) AS Medie " +
                               "FROM Elevi e, Materii m, Note n " +
                               "WHERE e.id_elev = n.id_elev and m.id_materie = n.id_materie " +
                               "GROUP BY e.id_elev, m.id_materie " +
                               "ORDER BY e.id_elev, m.id_materie";
                SqlCommand cmd1 = new SqlCommand(query, sc);

                //conecteaza baza de date la un obiect de tip DataTable si incarca datele selectate in el
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);

                //insereaza fiecare rand cu datele salvate din DataTable in tabelul medii pana la numarul maxim de randuri din DataTable
                string tempSql = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tempSql = "INSERT INTO Medii (id_elev,id_materie,medie) VALUES ("
                             + dt.Rows[i]["id_elev"].ToString().Trim() + ",'"
                             + dt.Rows[i]["id_materie"].ToString().Trim() + "',"
                             + dt.Rows[i]["medie"].ToString().Trim() + ");";
                    SqlCommand tempCommand = new SqlCommand(tempSql, sc);

                    try
                    {
                        tempCommand.ExecuteNonQuery();                        
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show("Operatia de adaugare a esuat! Verificati din nou datele introduse!" + excep);
                    }
                    
                }
                MessageBox.Show("Operatie de adaugare efectuata cu succes!");
                this.updateDataGrid1();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            sc.Close();


        }


        //Creare si vizualizare raport si salvarea lui in format PDF si deschiderea documentului
        private void button2_Click(object sender, EventArgs e)
        {
            //creez un obiect de tip reportdocument
            ReportDocument cryRpt = new ReportDocument();
            //incarc datele din raport in document
            cryRpt.Load(@"D:\Proiect_situatie_elevi\Proiect_situatie_elevi\Raport_situatie_elevi.rpt");
            cryRpt.Refresh();
            //dau calea unde va fi exportat raportul in format pdf
            cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\Proiect_situatie_elevi\Rapoarte\Raport.pdf");
            MessageBox.Show("Raport salvat cu succes");


            //deschid documentul salvat
            string path = @"D:\Proiect_situatie_elevi\Rapoarte\Raport.pdf";
            System.Diagnostics.Process.Start(path);
        }


        //Actualizarea datelor de fiecare data cand datele din situatia elevilor se schimba
        public void updateDataGrid1()
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = ("Data Source=DESKTOP-CTB26SK;Initial Catalog=situatie_elevi;Integrated Security=True");
            sc.Open();

            SqlCommand cmd = new SqlCommand("SELECT e.id_elev, e.nume_elev AS Nume, e.prenume_elev AS Prenume, m.nume_materie AS Materie, n.id_nota, n. valoare AS Nota, me.medie AS Medie " +
                               "FROM Elevi e, Materii m, Note n, Medii me " +
                               "WHERE e.id_elev = n.id_elev and m.id_materie = n.id_materie and e.id_elev = me.id_elev and m.id_materie = me.id_materie " +
                               "GROUP BY e.id_elev, e.nume_elev, e.prenume_elev, m.nume_materie, n.id_nota, n.valoare, me.medie " +
                               "ORDER BY e.nume_elev, m.nume_materie", sc);

            cmd.Connection = sc;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt.DefaultView;
            sc.Close();
            this.dataGridView1.Columns["id_elev"].Visible = false;
            this.dataGridView1.Columns["id_nota"].Visible = false;
        }


        //la click-ul utilizatorului pe o celula din datagridview se selecteaza tot randul si se extrag date din selectie
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                comboBox1.SelectedItem = row.Cells[5].Value.ToString();
            }
        }

        private void Situatie_elevi_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            updateDataGrid1();
            this.label2.Visible = false;
            this.textBox1.Visible = false;
            this.label7.Visible = false;
            this.textBox5.Visible = false;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void modificareNumeSauPrenumeElevToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a;
            if (Int32.TryParse(textBox1.Text, out a) == false)
            { MessageBox.Show("Nu ati selectat elevul pentru care doriti sa modificati numele sau prenumele"); }
            else
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = ("Data Source=DESKTOP-CTB26SK;Initial Catalog=situatie_elevi;Integrated Security=True");
                sc.Open();
                string update_elev = "UPDATE   Elevi SET nume_elev=@nume_elev, prenume_elev=@prenume_elev WHERE id_elev=@id_elev ";
                SqlCommand cmd = new SqlCommand(update_elev, sc);

                if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^[a-z A-Z ]*$"))
                {
                    MessageBox.Show("Numele trebuie sa contina doar litere");
                    return;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@nume_elev", textBox2.Text);
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "^[a-z A-Z ]*$"))
                {
                    MessageBox.Show("Prenumele trebuie sa contina doar litere");
                    return;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@prenume_elev", textBox3.Text);
                }

                cmd.Parameters.AddWithValue("@id_elev", textBox1.Text);

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
                        textBox2.Text = "";
                        textBox3.Text = "";
                        comboBox1.SelectedIndex = -1;
                        textBox4.Text = "";
                        sc.Close();
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show("Operatia de update a esuat! Verificati din nou datele introduse!" + excep);
                    }
                }
            }
        }

        private void modificareNotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a;
            if (Int32.TryParse(textBox1.Text, out a) == false)
            { MessageBox.Show("Nu ati selectat elevul pentru care doriti sa modificati nota!"); }
            else
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = ("Data Source=DESKTOP-CTB26SK;Initial Catalog=situatie_elevi;Integrated Security=True");
                sc.Open();

                //select pentru preluarea id-ului materiei
                var sql_m = "SELECT id_materie FROM Materii WHERE nume_materie=@nume_materie";
                SqlCommand id_m = new SqlCommand(sql_m, sc);
                id_m.Parameters.AddWithValue("@nume_materie", textBox4.Text);
                int mat = (Int32)id_m.ExecuteScalar();


                string modificare_nota = @"UPDATE   Note SET valoare=@valoare WHERE id_elev=@id_elev and id_materie=@id_materie and id_nota=@id_nota";
                SqlCommand cmd = new SqlCommand(modificare_nota, sc);


                cmd.Parameters.AddWithValue("@id_nota", textBox5.Text);
                cmd.Parameters.AddWithValue("@id_elev", textBox1.Text);
                cmd.Parameters.AddWithValue("@id_materie", mat);
                cmd.Parameters.AddWithValue("@valoare", this.comboBox1.SelectedItem);

                try
                {
                    int n = cmd.ExecuteNonQuery();
                    if (n > 0)
                    {
                        MessageBox.Show("Operatie de update efectuata cu succes!");
                        this.updateDataGrid1();
                    }
                    textBox2.Text = "";
                    textBox3.Text = "";
                    comboBox1.SelectedIndex = -1;
                    textBox4.Text = "";
                }
                catch (Exception excep)
                {
                    MessageBox.Show("Operatia de update a esuat!Verificati din nou daca ati selectat campul pe care doriti sa il stergeti!" + excep);
                }
            }
        }

        private void stergereCompletaADatelorUnuiElevToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a;
            if (Int32.TryParse(textBox1.Text, out a) == false)
            { MessageBox.Show("Nu ati selectat elevul pe care doriti sa il stergeti!"); }
            else
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = ("Data Source=DESKTOP-CTB26SK;Initial Catalog=situatie_elevi;Integrated Security=True");
                sc.Open();

                string stergere_elev = @"DELETE FROM  Elevi  WHERE id_elev=@id_elev";
                SqlCommand cmd = new SqlCommand(stergere_elev, sc);

                cmd.Parameters.AddWithValue("@id_elev", textBox1.Text);

                try
                {
                    int n = cmd.ExecuteNonQuery();
                    if (n > 0)
                    {
                        MessageBox.Show("Operatie de stergere efectuata cu succes!");
                        this.updateDataGrid1();
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show("Operatia de stergere a esuat!Verificati din nou daca ati selectat campul pe care doriti sa il stergeti!" + excep);
                }
            }
        }

        private void stergereaTuturorNotelorUnuiElevToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a;
            if (Int32.TryParse(textBox1.Text, out a) == false)
            { MessageBox.Show("Nu ati selectat elevul pentru care doriti stergeti notele!"); }
            else
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = ("Data Source=DESKTOP-CTB26SK;Initial Catalog=situatie_elevi;Integrated Security=True");
                sc.Open();

                string stergere_note = @"DELETE FROM  Note  WHERE id_elev=@id_elev";
                SqlCommand cmd = new SqlCommand(stergere_note, sc);

                cmd.Parameters.AddWithValue("@id_elev", textBox1.Text);


                try
                {
                    int n = cmd.ExecuteNonQuery();
                    if (n > 0)
                    {
                        MessageBox.Show("Operatie de stergere efectuata cu succes!");
                        this.updateDataGrid1();
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show("Operatia de stergere a esuat!Verificati din nou daca ati selectat campul pe care doriti sa il stergeti!" + excep);
                }
            }
        }

        private void stergereaUneiNoteSelectateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a;
            if (Int32.TryParse(textBox1.Text, out a) == false)
            { MessageBox.Show("Nu ati selectat elevul pentru care doriti stergeti nota!"); }
            else
            {
                SqlConnection sc = new SqlConnection();
                sc.ConnectionString = ("Data Source=DESKTOP-CTB26SK;Initial Catalog=situatie_elevi;Integrated Security=True");
                sc.Open();

                //select pentru preluarea id-ului materiei
                var sql_m = "SELECT id_materie FROM Materii WHERE nume_materie=@nume_materie";
                SqlCommand id_m = new SqlCommand(sql_m, sc);
                id_m.Parameters.AddWithValue("@nume_materie", textBox4.Text);
                int mat = (Int32)id_m.ExecuteScalar();


                string stergere_nota = @"DELETE FROM  Note  WHERE id_elev=@id_elev and id_materie=@id_materie and id_nota=@id_nota";
                SqlCommand cmd = new SqlCommand(stergere_nota, sc);

                cmd.Parameters.AddWithValue("@id_elev", textBox1.Text);
                cmd.Parameters.AddWithValue("@id_materie", mat);
                cmd.Parameters.AddWithValue("@id_nota", textBox5.Text);


                try
                {
                    int n = cmd.ExecuteNonQuery();
                    if (n > 0)
                    {
                        MessageBox.Show("Operatie de stergere efectuata cu succes!");
                        this.updateDataGrid1();
                    }
                }
                catch (Exception excep)
                {
                    MessageBox.Show("Operatia de stergere a esuat!Verificati din nou daca ati selectat campul pe care doriti sa il stergeti!" + excep);
                }
            }
        }
    }
}   