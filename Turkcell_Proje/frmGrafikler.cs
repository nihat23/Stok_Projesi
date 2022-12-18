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
    public partial class frmGrafikler : Form
    {
        public frmGrafikler()
        {
            InitializeComponent();
        }


        readonly SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-5AJ46VH\\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");


        private void frmGrafikler_Load(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("select Ad,count(*) from TblUrunler inner join TblKategori on TblUrunler.Kategori=TblKategori.ID group by ad", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                chart2.Series["Kategori"].Points.AddXY(oku[0], oku[1]);
            }
            baglan.Close();

        }
    }
}
