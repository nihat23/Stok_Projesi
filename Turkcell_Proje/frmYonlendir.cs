using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turkcell_Proje
{
    public partial class frmYonlendir : Form
    {
        public frmYonlendir()
        {
            InitializeComponent();
        }
        private void panel1_Click(object sender, EventArgs e)
        {
            frmUrunler Urunler = new frmUrunler();
            Urunler.Show();

        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void pnlGrafikler_Click(object sender, EventArgs e)
        {
            frmGrafikler grafikler = new frmGrafikler();
            grafikler.Show();
        }

        private void pnlIstatistikler_Click(object sender, EventArgs e)
        {
            frmIstatistikler Istatistikler = new frmIstatistikler();
            Istatistikler.Show();

        }

        private void frmYonlendir_Load(object sender, EventArgs e)
        {

        }

        private void pnlKategoriIslemleri_Click(object sender, EventArgs e)
        {
            frmKategori kategori = new frmKategori();
            kategori.Show();
        }
    }
}
