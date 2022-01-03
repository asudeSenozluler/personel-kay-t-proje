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

namespace personel_kayıt_proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-RE91BPD\\SQLEXPRESS;Initial Catalog=personel.veri.tabanı;Integrated Security=True");
        void temizle()
        {
            perid.Text = "";
            perad.Text = "";
            persoyad.Text = "";
            comboBox1.Text = "";
            maskedTextBox1.Text = "";
            permeslek.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            perad.Focus();


        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnlist_Click(object sender, EventArgs e)
        {

            this.personel_tablosuTableAdapter.Fill(this._personel_veri_tabanıDataSet._personel_tablosu);
        }

        private void btnkyt_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into personel_tablosu (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1",perad.Text);
            komut.Parameters.AddWithValue("@p2",persoyad.Text);
            komut.Parameters.AddWithValue("@p3",comboBox1.Text);
            komut.Parameters.AddWithValue("@p4",maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p5",permeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel eklendi...");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "true";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "false";
        }

        private void btntem_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilen = dataGridView1.SelectedCells[0].RowIndex;


            perid.Text = dataGridView1.Rows[seçilen].Cells[0].Value.ToString();
            perad.Text = dataGridView1.Rows[seçilen].Cells[1].Value.ToString();
            persoyad.Text = dataGridView1.Rows[seçilen].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[seçilen].Cells[3].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[seçilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[seçilen].Cells[5].Value.ToString();
            permeslek.Text = dataGridView1.Rows[seçilen].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if(label8.Text=="True")
            {
                radioButton1.Checked = true;
            }
            if(label8.Text=="False")
            {
                radioButton2.Checked = true;
            }
        }
    }
}
