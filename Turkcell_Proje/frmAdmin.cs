using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;//Kutuphanemıs
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turkcell_Proje
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        readonly SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-5AJ46VH\\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            baglan.Open();

            SqlCommand komut = new SqlCommand("select * from TblAdmin where KullaniciAd=@p1 and Sifre=@p2", baglan);
            komut.Parameters.AddWithValue("@p1", txtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader oku = komut.ExecuteReader();

            if (oku.Read())
            {
                frmYonlendir Yonlendirme = new frmYonlendir();
                Yonlendirme.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Yada Şifre Yanlış", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            baglan.Close();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
