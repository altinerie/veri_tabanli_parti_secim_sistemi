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
namespace veri_tabanli
{
    public partial class FrmOyGiris : Form
    {
        public FrmOyGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-2CVA09C;Initial Catalog=DB_SECIMPROJE; Integrated Security = True");
        private void BtnOyGirisi_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLILCE (ILCE,AKP,CHP,MHP,IYIP,MEMLEKET,DEVA) values (@P1,@P2,@P3,@P4,@P5,@P6,@P7)", baglanti);
            komut.Parameters.AddWithValue("@P1", txtilcead.Text);
            komut.Parameters.AddWithValue("@P2", txtAKP.Text);
            komut.Parameters.AddWithValue("@P3", txtCHP.Text);
            komut.Parameters.AddWithValue("@P4", txtMHP.Text);
            komut.Parameters.AddWithValue("@P5", txtIYIP.Text);
            komut.Parameters.AddWithValue("@P6", txtMEMLEKET.Text);
            komut.Parameters.AddWithValue("@P7", txtDEVA.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Oy Girişi Gerçekleştirildi.");

        }

        private void BtnGrafikler_Click(object sender, EventArgs e)
        {
            frmGrafikler fr = new frmGrafikler();
            fr.Show();
        }
    }
}
