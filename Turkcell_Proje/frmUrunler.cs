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

namespace Turkcell_Proje
{
    public partial class frmUrunler : Form
    {
        public frmUrunler()
        {
            InitializeComponent();
        }

        readonly SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-5AJ46VH\\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");

        void Listele()
        {
            baglan.Open();
            SqlCommand komutver1 = new SqlCommand("select UrunId,UrunAd,Stok,AlisFiyat,SatısFiyat,Ad,Kategori from TblUrunler inner join TblKategori on TblUrunler.Kategori=TblKategori.ID", baglan);
            SqlDataAdapter da = new SqlDataAdapter(komutver1);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            baglan.Close();
        }
        private void txtListele_Click(object sender, EventArgs e)
        {
            Listele();

        }

        private void frmUrunler_Load(object sender, EventArgs e)
        {
            Listele();


            SqlCommand komutver2 = new SqlCommand("select * from TblKategori", baglan);
            SqlDataAdapter da = new SqlDataAdapter(komutver2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "Ad";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = dt;

           //this.dataGridView1.Columns["ID"].Visible = false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komutver3 = new SqlCommand("insert into TblUrunler (UrunAd,Stok,AlisFiyat,SatısFiyat,Kategori) values(@p1,@p2,@p3,@p4,@p5)", baglan);
            komutver3.Parameters.AddWithValue("@p1", txtUrunAd.Text);
            komutver3.Parameters.AddWithValue("@p2", nudStok.Value);
            komutver3.Parameters.AddWithValue("@p3", txtAlisF.Text);
            komutver3.Parameters.AddWithValue("@p4", txtSatisF.Text);
            komutver3.Parameters.AddWithValue("@p5", comboBox1.SelectedValue);
            komutver3.ExecuteNonQuery();
            baglan.Close();
            Listele();

            MessageBox.Show("Ekleme işlemir Başarılı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komutver4 = new SqlCommand("delete from TblUrunler where UrunId=@p1", baglan);
            komutver4.Parameters.AddWithValue("@p1", txtSil.Text);
            komutver4.ExecuteNonQuery();
            baglan.Close();
            Listele();


            MessageBox.Show("Ürün Silinmiştir..", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komutver5 = new SqlCommand("update TblUrunler set UrunAd=@p1,Stok=@p2,AlisFiyat=@p3,SatısFiyat=@p4,Kategori=@p5 where UrunId=@p6", baglan);
            komutver5.Parameters.AddWithValue("@p1", txtUrunAd.Text);
            komutver5.Parameters.AddWithValue("@p2", nudStok.Value);
            komutver5.Parameters.AddWithValue("@p3", Convert.ToDecimal(txtAlisF.Text));
            komutver5.Parameters.AddWithValue("@p4", decimal.Parse(txtSatisF.Text));
            komutver5.Parameters.AddWithValue("@p5", comboBox1.SelectedValue);
            komutver5.Parameters.AddWithValue("@p6", lblId.Text);
            komutver5.ExecuteNonQuery();
            baglan.Close();
            Listele();

            MessageBox.Show("Güncelleme Başarı ile Yapıldı..", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtUrunAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            nudStok.Value = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            txtAlisF.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSatisF.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }
    }
}
