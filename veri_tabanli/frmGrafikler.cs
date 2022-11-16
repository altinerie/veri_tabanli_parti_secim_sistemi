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

namespace veri_tabanli
{
    public partial class frmGrafikler : Form
    {
        public frmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-2CVA09C;Initial Catalog=DB_SECIMPROJE; Integrated Security = True");
        private void frmGrafikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select ILCE from TBLILCE", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            baglanti.Close();

            //Grafiğe Toplam Sonuçları Getirme
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select SUM(AKP),SUM(CHP),SUM(MHP),SUM(IYIP),SUM(MEMLEKET),SUM(DEVA) FROM TBLILCE", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("AKP", dr2[0]);
                chart1.Series["Partiler"].Points.AddXY("CHP", dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("MHP", dr2[2]);
                chart1.Series["Partiler"].Points.AddXY("IYI PARTI", dr2[3]);
                chart1.Series["Partiler"].Points.AddXY("MEMLEKET", dr2[4]);
                chart1.Series["Partiler"].Points.AddXY("DEVA", dr2[5]);
            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLILCE where ILCE=@P1", baglanti);
            komut.Parameters.AddWithValue("@P1", comboBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LBLAKP.Value = int.Parse(dr[2].ToString());
                LBLCHP.Value = int.Parse(dr[3].ToString());
                LBLMHP.Value = int.Parse(dr[4].ToString());
                LBLIYI.Value = int.Parse(dr[5].ToString());
                LBLMEP.Value = int.Parse(dr[6].ToString());
                LBLDEVA.Value = int.Parse(dr[7].ToString());

                label8.Text = dr[2].ToString();
                label9.Text = dr[3].ToString();
                label10.Text = dr[4].ToString();
                label11.Text = dr[5].ToString();
                label12.Text = dr[6].ToString();
                label13.Text = dr[7].ToString();
            }
            baglanti.Close();
        }
    }
}
