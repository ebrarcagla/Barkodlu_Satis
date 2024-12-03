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
    public partial class Youtube : Form
    {
        public Youtube()
        {
            InitializeComponent();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void Youtube_Load(object sender, EventArgs e)
        {
            using (var db = new BarkodDBEntities())
            {
                dataGridView1.DataSource = db.Urun.Where(x => x.Birim == "Kg").ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "txt dosyası|0.txt";
            sf.FileName = "Text Dosyası";
            if (sf.ShowDialog()==DialogResult.OK)
            {
                FileStream fs = new FileStream(sf.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                fs.Close();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string urunadi = dataGridView1.Rows[i].Cells["UrunAd"].Value.ToString();
                    string urunkodu = dataGridView1.Rows[i].Cells["Barkod"].Value.ToString();
                    double urunfiyat = double.Parse(dataGridView1.Rows[i].Cells["SatisFiyat"].Value.ToString());
                    string onek = "27";
                    string icerik = urunkodu + ";" + onek + urunkodu + ";" + urunadi + "\t\t" + ";0;" + urunfiyat.ToString("N2");
                    File.AppendAllText(sf.FileName, icerik + Environment.NewLine);
                }
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
