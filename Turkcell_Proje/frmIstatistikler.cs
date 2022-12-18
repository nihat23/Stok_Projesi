using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;//Kutuphanemiz
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Turkcell_Proje
{
    public partial class frmIstatistikler : Form
    {
        public frmIstatistikler()
        {
            InitializeComponent();
        }


        readonly SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-5AJ46VH\\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");

        private void frmIstatistikler_Load(object sender, EventArgs e)
        {
            //Kategori Sayısı
            baglan.Open();
            SqlCommand komut1 = new SqlCommand("select count(*) from TblKategori", baglan);
            SqlDataReader oku = komut1.ExecuteReader();

            if (oku.Read())
            {
                lblToplamKategori.Text = oku[0].ToString();
            }
            baglan.Close();

            //Uruler Sayısı

            baglan.Open();
            SqlCommand komut2 = new SqlCommand("select count(*) from TblUrunler", baglan);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                lblToplamUrun.Text = oku2[0].ToString();

            }
            baglan.Close();
            //En Yuksek
            baglan.Open();
            SqlCommand komut3 = new SqlCommand("select * from TblUrunler where Stok=(select max(Stok) from TblUrunler)", baglan);
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                lblEnYuksekStok.Text = oku3["UrunAd"].ToString();
            }
            baglan.Close();
            //En Düşük
            baglan.Open();
            SqlCommand komut4 = new SqlCommand("select * from TblUrunler where Stok=(Select min(Stok) from TblUrunler)", baglan);
            SqlDataReader oku4 = komut4.ExecuteReader();
            while (oku4.Read())
            {
                lblEnDusukStok.Text = oku4["UrunAd"].ToString();

            }
            baglan.Close();
            //küçük ev aletlerı
            baglan.Open();
            SqlCommand komut5 = new SqlCommand("select count(*) from TblUrunler where Kategori=(select Id from TblKategori where Id='3')", baglan);
            SqlDataReader oku5 = komut5.ExecuteReader();
            while (oku5.Read())
            {
                lblKucukEv.Text = oku5[0].ToString();
            }
            baglan.Close();
            //Beyaz Eşya
            baglan.Open();
            SqlCommand komut6 = new SqlCommand("select count(*) from TblUrunler where Kategori=(select Id from TblKategori where Id='1')", baglan);
            SqlDataReader oku6 = komut6.ExecuteReader();

            while (oku6.Read())
            {
                lblBeyazEsya.Text = oku6[0].ToString();

            }
            baglan.Close();

            //Beyaz Esya Toplam Kar
            baglan.Open();
            SqlCommand komut7 = new SqlCommand("select sum( Stok*(SatısFiyat-AlisFiyat)) as 'Toplam Stokla Kar' from TblUrunler where Kategori=(select Id from TblKategori where ID=1 )", baglan);
            SqlDataReader oku7 = komut7.ExecuteReader();
            while (oku7.Read())
            {
                lblBeyazToplamKAr.Text = oku7[0].ToString() + " ₺";
            }
            baglan.Close();

            //Küçük Ev Toplam kar
            baglan.Open();
            SqlCommand komut8 = new SqlCommand("select sum(Stok*(SatısFiyat-AlisFiyat)) as  'Toplam Stokla Kar' from TblUrunler where Kategori=(select Id from TblKategori where ID=3)",baglan);
            SqlDataReader oku8 = komut8.ExecuteReader();

            while (oku8.Read())
            {
                lblKucukEvKar.Text = oku8[0].ToString() + " ₺";
            }
            baglan.Close();

            //Bilgisayar Toplam kar
            baglan.Open();
            SqlCommand komut9 = new SqlCommand("select sum(Stok*(SatısFiyat-AlisFiyat)) as  'Toplam Stokla Kar' from TblUrunler where Kategori=(select Id from TblKategori where ID=2)", baglan);
            SqlDataReader oku9 = komut9.ExecuteReader();

            while (oku9.Read())
            {
                lblBilGisayarKar.Text = oku9[0].ToString() + " ₺";
            }
            baglan.Close();

            //Telefon Toplam kar
            baglan.Open();
            SqlCommand komut10 = new SqlCommand("select sum(Stok*(SatısFiyat-AlisFiyat)) as  'Toplam Stokla Kar' from TblUrunler where Kategori=(select Id from TblKategori where ID=5)", baglan);
            SqlDataReader oku10 = komut10.ExecuteReader();

            while (oku10.Read())
            {
                lblTelefonKar.Text = oku10[0].ToString() + " ₺";
            }
            baglan.Close();

            /*
             select Stok*(SatısFiyat - AlisFiyat) as ' Kar' from TblUrunler where UrunAd='Ütü'
            
             */



        }
    }
}
