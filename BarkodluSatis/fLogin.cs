﻿using Lisans;
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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void bGiris_Click(object sender, EventArgs e)
        {
            GirisYap();
        }

        void GirisYap()
        {
            if (tKullaniciAdi.Text != "" && tSifre.Text != "")
            {
                try
                {
                    using (var db = new BarkodDBEntities())
                    {
                        if (db.Kullanici.Any())
                        {
                            var bak = db.Kullanici.Where(x => x.KullaniciAd == tKullaniciAdi.Text && x.Sifre == tSifre.Text).FirstOrDefault();
                            if (bak != null)
                            {
                                Cursor.Current = Cursors.WaitCursor;
                                /*  Kontrol kontrol = new Kontrol(); // Burası
                                  if (kontrol.KontrolYap()) // Burası
                                  {*/
                                bool durum = false;
                                if (db.Guvenlik.Count() == 0)
                                {
                                    Lic lic = new Lic();
                                    fLisans f = new fLisans();
                                    f.lKontrolNo.Text = lic.EkrandaGoster().ToString();
                                    f.Show();
                                }
                                else
                                {
                                    fBaslangic f = new fBaslangic();
                                    f.bSatisIslemi.Enabled = (bool)bak.Satis;
                                    f.bGenelRapor.Enabled = (bool)bak.Rapor;
                                    f.bStok.Enabled = (bool)bak.Stok;
                                    f.bUrunGiris.Enabled = (bool)bak.UrunGiris;
                                    f.bAyarlar.Enabled = (bool)bak.Ayarlar;
                                    f.bFiyatGuncelle.Enabled = (bool)bak.FiyatGuncelle;
                                    f.bYedekleme.Enabled = (bool)bak.Yedekleme;
                                    f.lKullanici.Text = bak.AdSoyad;
                                    var isyeri = db.Sabit.FirstOrDefault();
                                    f.lIsyeri.Text = isyeri.Unvan;
                                    f.Show();
                                    this.Hide();
                                }
                                
                                //  } // Burası
                                Cursor.Current = Cursors.Default;
                            }
                            else
                            {
                                MessageBox.Show("Hatalı giriş");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void fLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GirisYap();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lic lic = new Lic();
            label1.Text = lic.CpuNo() + "\n" + lic.CpuKarakterToplam().ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GirisYap();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
