using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodluSatis
{
    public partial class fLisans : Form
    {
        public fLisans()
        {
            InitializeComponent();
        }
        BarkodDBEntities db = new BarkodDBEntities();
        private void bTamam_Click(object sender, EventArgs e)
        {
            int sayi = int.Parse(lKontrolNo.Text);
            sayi = sayi * 23;
            if (tLisansNo.Text!="" & tLisansNo.Text==sayi.ToString())
            {
                /* Kontrol k = new Kontrol();
                 k.Lisansla(tLisansNo.Text);*/
                Guvenlik guvenlik = new Guvenlik();
                guvenlik.baslangic = tLisansNo.Text;
                guvenlik.bitis = tLisansNo.Text;
                db.Guvenlik.Add(guvenlik);
                db.SaveChanges();
                MessageBox.Show("Program Kullanıma Açılmıştır","BAŞARILI");
            }
            else
            {
                MessageBox.Show("Geçersiz");
            }
        }
    }
}
