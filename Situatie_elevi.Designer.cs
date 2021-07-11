
namespace Proiect_situatie_elevi
{
    partial class Situatie_elevi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificareDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificareNumeSauPrenumeElevToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificareNotaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stergereDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stergereCompletaADatelorUnuiElevToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stergereaTuturorNotelorUnuiElevToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stergereaUneiNoteSelectateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.adaugare_materie1 = new Proiect_situatie_elevi.Adaugare_materie();
            this.adaugare_elevi1 = new Proiect_situatie_elevi.Adaugare_elevi();
            this.adaugare_note1 = new Proiect_situatie_elevi.Adaugare_note();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(797, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(270, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "Calculeaza mediile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(797, 263);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(270, 31);
            this.button2.TabIndex = 4;
            this.button2.Text = "Creare raport";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1455, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Situatie elevi";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(1146, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(766, 318);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificareDateToolStripMenuItem,
            this.stergereDateToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(202, 60);
            // 
            // modificareDateToolStripMenuItem
            // 
            this.modificareDateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificareNumeSauPrenumeElevToolStripMenuItem,
            this.modificareNotaToolStripMenuItem});
            this.modificareDateToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificareDateToolStripMenuItem.Name = "modificareDateToolStripMenuItem";
            this.modificareDateToolStripMenuItem.Size = new System.Drawing.Size(201, 28);
            this.modificareDateToolStripMenuItem.Text = "Modificare date";
            // 
            // modificareNumeSauPrenumeElevToolStripMenuItem
            // 
            this.modificareNumeSauPrenumeElevToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificareNumeSauPrenumeElevToolStripMenuItem.Name = "modificareNumeSauPrenumeElevToolStripMenuItem";
            this.modificareNumeSauPrenumeElevToolStripMenuItem.Size = new System.Drawing.Size(368, 28);
            this.modificareNumeSauPrenumeElevToolStripMenuItem.Text = "Modificare nume sau prenume elev";
            this.modificareNumeSauPrenumeElevToolStripMenuItem.Click += new System.EventHandler(this.modificareNumeSauPrenumeElevToolStripMenuItem_Click);
            // 
            // modificareNotaToolStripMenuItem
            // 
            this.modificareNotaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modificareNotaToolStripMenuItem.Name = "modificareNotaToolStripMenuItem";
            this.modificareNotaToolStripMenuItem.Size = new System.Drawing.Size(368, 28);
            this.modificareNotaToolStripMenuItem.Text = "Modificare nota";
            this.modificareNotaToolStripMenuItem.Click += new System.EventHandler(this.modificareNotaToolStripMenuItem_Click);
            // 
            // stergereDateToolStripMenuItem
            // 
            this.stergereDateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stergereCompletaADatelorUnuiElevToolStripMenuItem,
            this.stergereaTuturorNotelorUnuiElevToolStripMenuItem,
            this.stergereaUneiNoteSelectateToolStripMenuItem});
            this.stergereDateToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stergereDateToolStripMenuItem.Name = "stergereDateToolStripMenuItem";
            this.stergereDateToolStripMenuItem.Size = new System.Drawing.Size(201, 28);
            this.stergereDateToolStripMenuItem.Text = "Stergere date";
            // 
            // stergereCompletaADatelorUnuiElevToolStripMenuItem
            // 
            this.stergereCompletaADatelorUnuiElevToolStripMenuItem.Name = "stergereCompletaADatelorUnuiElevToolStripMenuItem";
            this.stergereCompletaADatelorUnuiElevToolStripMenuItem.Size = new System.Drawing.Size(387, 28);
            this.stergereCompletaADatelorUnuiElevToolStripMenuItem.Text = "Stergere completa a datelor unui elev";
            this.stergereCompletaADatelorUnuiElevToolStripMenuItem.Click += new System.EventHandler(this.stergereCompletaADatelorUnuiElevToolStripMenuItem_Click);
            // 
            // stergereaTuturorNotelorUnuiElevToolStripMenuItem
            // 
            this.stergereaTuturorNotelorUnuiElevToolStripMenuItem.Name = "stergereaTuturorNotelorUnuiElevToolStripMenuItem";
            this.stergereaTuturorNotelorUnuiElevToolStripMenuItem.Size = new System.Drawing.Size(387, 28);
            this.stergereaTuturorNotelorUnuiElevToolStripMenuItem.Text = "Stergerea tuturor notelor unui elev";
            this.stergereaTuturorNotelorUnuiElevToolStripMenuItem.Click += new System.EventHandler(this.stergereaTuturorNotelorUnuiElevToolStripMenuItem_Click);
            // 
            // stergereaUneiNoteSelectateToolStripMenuItem
            // 
            this.stergereaUneiNoteSelectateToolStripMenuItem.Name = "stergereaUneiNoteSelectateToolStripMenuItem";
            this.stergereaUneiNoteSelectateToolStripMenuItem.Size = new System.Drawing.Size(387, 28);
            this.stergereaUneiNoteSelectateToolStripMenuItem.Text = "Stergerea unei note selectate";
            this.stergereaUneiNoteSelectateToolStripMenuItem.Click += new System.EventHandler(this.stergereaUneiNoteSelectateToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(823, 445);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "ID_elev";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(823, 473);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nume elev";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(980, 445);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 10;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(980, 473);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 11;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(980, 501);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 14;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(980, 529);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(823, 501);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Prenume elev";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(823, 529);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Materie";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(823, 557);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Nota";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBox1.Location = new System.Drawing.Point(980, 557);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(823, 587);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 26;
            this.label7.Text = "ID_nota";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(980, 587);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(731, 420);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(460, 20);
            this.label8.TabIndex = 28;
            this.label8.Text = "Modificati datele dorite utilizand campurile de mai jos";
            // 
            // adaugare_materie1
            // 
            this.adaugare_materie1.Location = new System.Drawing.Point(422, 12);
            this.adaugare_materie1.Name = "adaugare_materie1";
            this.adaugare_materie1.Size = new System.Drawing.Size(294, 455);
            this.adaugare_materie1.TabIndex = 25;
            // 
            // adaugare_elevi1
            // 
            this.adaugare_elevi1.HeaderCell = null;
            this.adaugare_elevi1.Location = new System.Drawing.Point(12, 12);
            this.adaugare_elevi1.Name = "adaugare_elevi1";
            this.adaugare_elevi1.Size = new System.Drawing.Size(404, 617);
            this.adaugare_elevi1.TabIndex = 23;
            // 
            // adaugare_note1
            // 
            this.adaugare_note1.Location = new System.Drawing.Point(713, 12);
            this.adaugare_note1.Name = "adaugare_note1";
            this.adaugare_note1.Size = new System.Drawing.Size(419, 234);
            this.adaugare_note1.TabIndex = 2;
            // 
            // Situatie_elevi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 662);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.adaugare_materie1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.adaugare_elevi1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.adaugare_note1);
            this.Name = "Situatie_elevi";
            this.Text = "Situatie_elevi";
            this.Load += new System.EventHandler(this.Situatie_elevi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Adaugare_note adaugare_note1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Adaugare_elevi adaugare_elevi1;
        private System.Windows.Forms.ComboBox comboBox1;
        private Adaugare_materie adaugare_materie1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modificareDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificareNumeSauPrenumeElevToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificareNotaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stergereDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stergereCompletaADatelorUnuiElevToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stergereaTuturorNotelorUnuiElevToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stergereaUneiNoteSelectateToolStripMenuItem;
        private System.Windows.Forms.Label label8;
    }
}

