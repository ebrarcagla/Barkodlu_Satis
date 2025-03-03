﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodluSatis
{
    static class Islemler
    {
        public static double DoubleYap(string deger)
        {
            double sonuc;
            double.TryParse(deger, NumberStyles.Currency, CultureInfo.CurrentUICulture.NumberFormat, out sonuc);
            return Math.Round(sonuc, 2);
        }

        public static void StokAzalt(string barkod, double miktar)
        {
            if (barkod != "1111111111116")
            {
                using (var db = new BarkodDBEntities())
                {
                    var urunbilgi = db.Urun.SingleOrDefault(x => x.Barkod == barkod);
                    urunbilgi.Miktar -= miktar;
                    db.SaveChanges();
                }
            }

        }

        public static void StokArtir(string barkod, double miktar)
        {
            if (barkod != "1111111111116")
            {
                using (var db = new BarkodDBEntities())
                {
                    var urunbilgi = db.Urun.SingleOrDefault(x => x.Barkod == barkod);
                    urunbilgi.Miktar += miktar;
                    db.SaveChanges();
                }
            }

        }

        public static void GridDuzenle(DataGridView dgv)
        {
            if (dgv.Columns.Count > 0)
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    switch (dgv.Columns[i].HeaderText)
                    {
                        case "Id":
                            dgv.Columns[i].HeaderText = "Numara"; break;
                        case "IslemNo":
                            dgv.Columns[i].HeaderText = "İşlem No"; break;
                        case "UrunId":
                            dgv.Columns[i].HeaderText = "Urun Numarası"; break;
                        case "UrunAd":
                            dgv.Columns[i].HeaderText = "Ürün Adı"; break;
                        case "Aciklama":
                            dgv.Columns[i].HeaderText = "Açıklama"; break;
                        case "UrunGrup":
                            dgv.Columns[i].HeaderText = "Ürün Grubu"; break;
                        case "AlisFiyat":
                            dgv.Columns[i].HeaderText = "Alış Fiyatı";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2";
                            break;
                        case "AlisFiyatToplam":
                            dgv.Columns[i].HeaderText = "Alış Fiyat Toplam";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2";
                            break;
                        case "SatisFiyat":
                            dgv.Columns[i].HeaderText = "Satış Fiyatı";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "KdvOrani":
                            dgv.Columns[i].HeaderText = "Kdv Oranı";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;
                        case "Birim":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;
                        case "Miktar":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;
                        case "OdemeSekli":
                            dgv.Columns[i].HeaderText = "Ödeme Şekli";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;
                        case "Kart":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "Nakit":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "Gelir":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "Gider":
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "Kullanici":
                            dgv.Columns[i].HeaderText = "Kullanıcı";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; break;
                        case "KdvTutari":
                            dgv.Columns[i].HeaderText = "Kdv Tutarı";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                        case "Toplam":
                            dgv.Columns[i].HeaderText = "Toplam";
                            dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv.Columns[i].DefaultCellStyle.Format = "C2"; break;
                    }
                }
            }
        }

        public static void StokHareket(string barkod, string urunad, string birim, double miktar, string urungrup, string kullanici)
        {
            using (var db = new BarkodDBEntities())
            {
                StokHareket sh = new StokHareket();
                sh.Barkod = barkod;
                sh.UrunAd = urunad;
                sh.Birim = birim;
                sh.Miktar = miktar;
                sh.UrunGrup = urungrup;
                sh.Kullanici = kullanici;
                sh.Tarih = DateTime.Now;
                db.StokHareket.Add(sh);
                db.SaveChanges();
            }
        }

        public static int KartKomisyon()
        {
            int sonuc = 0;
            using (var db = new BarkodDBEntities())
            {
                if (db.Sabit.Any())
                {
                    sonuc = Convert.ToInt16(db.Sabit.First().KarKomisyon);
                }
                else
                {
                    sonuc = 0;
                }
            }
            return sonuc;
        }

        public static void SabitVarsayilan()
        {
            using (var db = new BarkodDBEntities())
            {
                if (!db.Sabit.Any())
                {
                    Sabit s = new Sabit();
                    s.KarKomisyon = 0;
                    s.Yazici = false;
                    s.AdSoyad = "admin";
                    s.Adres = "admin";
                    s.Unvan = "admin";
                    s.Adres = "admin";
                    s.Telefon = "admin";
                    s.Eposta = "admin";
                    db.Sabit.Add(s);
                    db.SaveChanges();
                }
            }
        }

        public static void Backup()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Veri yedek dosyası|0.bak";
            save.FileName = "Barkodlu_Satis_Programi_" + DateTime.Now.ToShortDateString();
            if (save.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (File.Exists(save.FileName))
                    {
                        File.Delete(save.FileName);
                    }
                    var dbHedef = save.FileName;
                    //string dbKaynak = Application.StartupPath + @"\BarkodDb.mdf";
                    using (var db=new BarkodDBEntities())
                    {
                        string dbKaynak = db.Database.Connection.Database;
                        var cmd = @"BACKUP DATABASE[" + dbKaynak + "] TO DISK='" + dbHedef + "'";
                        db.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, cmd);
                    }
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Yedekleme tamamlanmıştır");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
