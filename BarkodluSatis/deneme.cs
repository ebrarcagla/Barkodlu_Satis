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
    public partial class deneme : Form
    {
        public deneme()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BarkodDBEntities db = new
                BarkodDBEntities();
            listBox1.DisplayMember = "UrunAd";listBox1.ValueMember = "UrunId";
            listBox1.DataSource = db.Urun.Select(a => new { a.UrunId, a.UrunAd }).ToList();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(listBox1.SelectedValue.ToString() + Environment.NewLine + listBox1.Text.ToString());
        }
    }
}
