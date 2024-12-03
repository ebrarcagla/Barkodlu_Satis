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
    public partial class FBarkod : Form
    {
        public FBarkod()
        {
            InitializeComponent();
        }
        BarkodDBEntities db = new BarkodDBEntities();
        Yazdir2 yazdir = new Yazdir2();
        void Kaydet()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Resim Dosyaları";
            saveFile.Filter = "PNG Dosyası|*.png";
            if (saveFile.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFile.FileName);
                yazdir.yol_al = saveFile.FileName.ToString();
                yazdir.YazdirmayaBasla();
            }
            
        }
        private void BBarkod_Click(object sender, EventArgs e)
        {
            
            if (TCode.Text!="")
            {
                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                pictureBox1.Image = barcode.Draw(TCode.Text, 60);
                Kaydet();
            }

        }

        private void BQr_Click(object sender, EventArgs e)
        {
            var barkodno = db.Barkod.First();
            int karakter = barkodno.BarkodNo.ToString().Length;
            string sifirlar = string.Empty;
            for (int i = 0; i < 8 - karakter; i++)
            {
                sifirlar = sifirlar + "0";
            }
            string olusanbarkod = sifirlar + barkodno.BarkodNo.ToString();
            TCode.Text = olusanbarkod;
            if (TCode.Text != "")
            {
                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                pictureBox1.Image = barcode.Draw(TCode.Text, 60);
                Kaydet();
            }
        }

        private void FBarkod_Load(object sender, EventArgs e)
        {

        }
    }
}
