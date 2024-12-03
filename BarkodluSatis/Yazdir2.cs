using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodluSatis
{
    class Yazdir2
    {
        PrintDocument doc = new PrintDocument();
        public string yol_al { get; set; }
        public void YazdirmayaBasla()
        {
            try
            {
                doc.PrintPage += Doc_PrintPage;
                doc.Print();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }
        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Image img = Image.FromFile(@yol_al);
            Point loc = new Point(1, 1);
            e.Graphics.DrawImage(img, loc);
        }
    }

}
