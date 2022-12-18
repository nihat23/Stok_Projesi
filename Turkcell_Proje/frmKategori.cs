using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;// kutuphanemizi eklıyoruz

namespace Turkcell_Proje
{
    public partial class frmKategori : Form
    {
        public frmKategori()
        {
            InitializeComponent();
        }

        readonly SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-5AJ46VH\\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");

        void Listele()
        {
            baglan.Open();
            SqlCommand komutver1 = new SqlCommand("select * from TblKategori", baglan);
            SqlDataAdapter da = new SqlDataAdapter(komutver1);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            baglan.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komutver2 = new SqlCommand("insert into TblKategori (Ad) values(@p1)", baglan);
            komutver2.Parameters.AddWithValue("@p1", txtKategoriAd.Text);
            komutver2.ExecuteNonQuery();
            baglan.Close();
            Listele();

            MessageBox.Show("Kategori Eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut3 = new SqlCommand("delete from TblKategori where ID=@p1", baglan);
            komut3.Parameters.AddWithValue("@p1", txtId.Text);
            komut3.ExecuteNonQuery();
            baglan.Close();
            Listele();

            MessageBox.Show("Kategori Silindi..", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komutver4 = new SqlCommand("update TblKategori set Ad=@p1 where Id=@p2", baglan);
            komutver4.Parameters.AddWithValue("@p1", txtKategoriAd.Text);
            komutver4.Parameters.AddWithValue("@p2", txtId.Text);
            komutver4.ExecuteNonQuery();
            baglan.Close();
            Listele();

            MessageBox.Show("Guncelleme işlemi basarılı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
          

            




        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komutver5 = new SqlCommand("select * from TblKategori where Ad=@p1", baglan);
            komutver5.Parameters.AddWithValue("@p1", txtKategoriAd.Text);
            SqlDataAdapter da = new SqlDataAdapter(komutver5);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            baglan.Close();
        }
    }
}
