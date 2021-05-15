using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sezar_VigenereSifreleme
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            SezarSifreleme.lw_cozumler = SZR_lw_cozumler;
            SezarSifreleme.rchTxt_sifreliMetin = SZR_rchTxt_sifreliMetin;
        }

        private void SZR_btn_Sifrele_Click(object sender, EventArgs e)
        {
            try
            {
                SZR_rchTxt_sifrelenmis.Text = SezarSifreleme.Encoding(SZR_rchTxt_Sifrelenecek.Text, Convert.ToInt32(SZR_txt_anahtarDeger.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SZR_btn_temizle_Click(object sender, EventArgs e)
        {
            SZR_rchTxt_Sifrelenecek.Text = null;
            SZR_rchTxt_sifrelenmis.Text = null;
            SZR_txt_anahtarDeger.Text = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SZR_lw_cozumler.View = View.Details;
            SZR_lw_cozumler.FullRowSelect = true;
            SZR_lw_cozumler.Columns.Add("Sıra", 75);
            SZR_lw_cozumler.Columns.Add("Çözüm", 500);

        }

        private void SZR_btn_coz_Click(object sender, EventArgs e)
        {
            SZR_lw_cozumler.Items.Clear();
            SezarSifreleme.Decoding();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SZR_lw_cozumler.Items.Clear();
            SZR_rchTxt_sifreliMetin.Text = null;
        }

        private void VNG_btnSifrele_Click(object sender, EventArgs e)
        {
            try
            {
                VNG_rchTxt_sifrelenmis.Text = VigenereSifreleme.Encoding(VNG_rchTxt_sifrelenecek.Text, VNG_txt_anahtarKelime.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void VNG_btn_temizle_Click(object sender, EventArgs e)
        {
            VNG_rchTxt_sifrelenecek.Text = null;
            VNG_rchTxt_sifrelenmis.Text = null;
            VNG_txt_anahtarKelime.Text = null;
        }
    }
}
