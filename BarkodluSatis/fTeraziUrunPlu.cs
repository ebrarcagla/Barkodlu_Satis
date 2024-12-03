using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodluSatis
{
    public partial class fTeraziUrunPlu : Form
    {
        public fTeraziUrunPlu()
        {
            InitializeComponent();
        }

        private void fTeraziUrunPlu_Load(object sender, EventArgs e)
        {
            UrunDoldur();
        }

        private void UrunDoldur()
        {
            using (var db = new BarkodDBEntities())
            {
                gridListe.DataSource = db.Urun.Where(x => x.Birim == "Kg").ToList();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gridListe.Rows.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "txt dosyası|0.txt";
                sf.FileName = "Plu Dosyası_" + DateTime.Now.ToShortDateString();
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sf.FileName))
                    {
                        File.Delete(sf.FileName);
                    }
                    FileStream fs = new FileStream(sf.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    fs.Close();
                    for (int i = 0; i < gridListe.Rows.Count; i++)
                    {
                        string urunadi = gridListe.Rows[i].Cells["UrunAd"].Value.ToString();
                        string urunkodu = gridListe.Rows[i].Cells["Barkod"].Value.ToString();
                        double urunfiyat =double.Parse(gridListe.Rows[i].Cells["SatisFiyat"].Value.ToString());
                        string terazionek = "27";
                        string icerik = urunkodu + ";" + terazionek + urunkodu + ";" + urunadi + "\t\t" + ";0;" +urunfiyat.ToString("N2");
                        File.AppendAllText(sf.FileName,  icerik + Environment.NewLine ); 
                    }
                    
                }
                Cursor.Current = Cursors.Default;
            }

        }
    }
}
