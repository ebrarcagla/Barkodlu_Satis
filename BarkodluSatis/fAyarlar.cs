﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarkodluSatis
{
    public partial class fAyarlar : Form
    {
        public fAyarlar()
        {
            InitializeComponent();
        }
        private void Temizle()
        {
            tAdSoyad.Clear();
            tTelefon.Clear();
            tEposta.Clear();
            tKullanici.Clear();
            tSifre.Clear();
            chSatisEkrani.Checked = false;
            chRapor.Checked = false;
            chStok.Checked = false;
            chUrunGiris.Checked = false;
            chAyarlar.Checked = false;
            chFiyatGuncelle.Checked = false;
            chYedekleme.Checked = false;
            tSifreTekrar.Clear();
        }
        private void bKaydet_Click(object sender, EventArgs e)
        {
            if (bKaydet.Text == "Kaydet")
            {
                if (tAdSoyad.Text != "" && tTelefon.Text != "" && tKullanici.Text != "" && tSifre.Text != "" && tSifreTekrar.Text != "")
                {
                    if (tSifre.Text == tSifreTekrar.Text)
                    {
                        try
                        {
                            using (var db = new BarkodDBEntities())
                            {
                                if (!db.Kullanici.Any(x => x.KullaniciAd == tKullanici.Text))
                                {
                                    Kullanici k = new Kullanici();
                                    k.AdSoyad = tAdSoyad.Text;
                                    k.Telefon = tTelefon.Text;
                                    k.EPosta = tEposta.Text;
                                    k.KullaniciAd = tKullanici.Text.Trim();
                                    k.Sifre = tSifre.Text;
                                    k.Satis = chSatisEkrani.Checked;
                                    k.Rapor = chRapor.Checked;
                                    k.Stok = chStok.Checked;
                                    k.UrunGiris = chUrunGiris.Checked;
                                    k.Ayarlar = chAyarlar.Checked;
                                    k.FiyatGuncelle = chFiyatGuncelle.Checked;
                                    k.Yedekleme = chYedekleme.Checked;
                                    db.Kullanici.Add(k);
                                    db.SaveChanges();
                                    Doldur();
                                    Temizle();
                                }
                                else
                                {
                                    MessageBox.Show("Bu kullanıcı zaten kayıtlı");
                                }
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Hata oluştu");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler uyuşmuyor");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen zorunlu girişleri yazınız" + "\nAd Soyad \nTelefon \nKullanıcı Adı \nŞifre \nŞifre Tekrar");
                }
            }
            else if (bKaydet.Text == "Düzenle/Kaydet")
            {
                if (tAdSoyad.Text != "" && tTelefon.Text != "" && tKullanici.Text != "" && tSifre.Text != "" && tSifreTekrar.Text != "")
                {
                    if (tSifre.Text == tSifreTekrar.Text)
                    {
                        int id = Convert.ToInt32(lKullaniciId.Text);
                        using (var db = new BarkodDBEntities())
                        {
                            var guncelle = db.Kullanici.Where(x => x.Id == id).FirstOrDefault();
                            guncelle.AdSoyad = tAdSoyad.Text;
                            guncelle.Telefon = tTelefon.Text;
                            guncelle.EPosta = tEposta.Text;
                            guncelle.KullaniciAd = tKullanici.Text.Trim();
                            guncelle.Sifre = tSifre.Text;
                            guncelle.Satis = chSatisEkrani.Checked;
                            guncelle.Rapor = chRapor.Checked;
                            guncelle.Stok = chStok.Checked;
                            guncelle.UrunGiris = chUrunGiris.Checked;
                            guncelle.Ayarlar = chAyarlar.Checked;
                            guncelle.FiyatGuncelle = chFiyatGuncelle.Checked;
                            guncelle.Yedekleme = chYedekleme.Checked;
                            db.SaveChanges();
                            MessageBox.Show("Güncelleme yapılmıştır");
                            bKaydet.Text = "Kaydet";
                            Temizle();
                            Doldur();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler uyuşmuyor");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen zorunlu girişleri yazınız" + "\nAd Soyad \nTelefon \nKullanıcı Adı \nŞifre \nŞifre Tekrar");

                }
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridListeKullanici.Rows.Count > 0)
            {
                int id = Convert.ToInt32(gridListeKullanici.CurrentRow.Cells["Id"].Value.ToString());
                lKullaniciId.Text = id.ToString();
                using (var db = new BarkodDBEntities())
                {
                    var getir = db.Kullanici.Where(x => x.Id == id).FirstOrDefault();
                    tAdSoyad.Text = getir.AdSoyad;
                    tTelefon.Text = getir.Telefon;
                    tEposta.Text = getir.EPosta;
                    tKullanici.Text = getir.KullaniciAd;
                    tSifre.Text = getir.Sifre;
                    tSifreTekrar.Text = getir.Sifre;
                    chSatisEkrani.Checked = (bool)getir.Satis;
                    chRapor.Checked = (bool)getir.Rapor;
                    chStok.Checked = (bool)getir.Stok;
                    chUrunGiris.Checked = (bool)getir.UrunGiris;
                    chAyarlar.Checked = (bool)getir.Ayarlar;
                    chFiyatGuncelle.Checked = (bool)getir.FiyatGuncelle;
                    chYedekleme.Checked = (bool)getir.Yedekleme;
                    bKaydet.Text = "Düzenle/Kaydet";
                    Doldur();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı seçiniz");
            }
        }

        private void fAyarlar_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Doldur();
            Cursor.Current = Cursors.Default;
        }

        private void Doldur()
        {
            using (var db = new BarkodDBEntities())
            {
                if (db.Kullanici.Any())
                {
                    gridListeKullanici.DataSource = db.Kullanici.Select(x => new { x.Id, x.AdSoyad, x.KullaniciAd, x.Telefon }).ToList();

                }
                Islemler.SabitVarsayilan();
                var yazici = db.Sabit.FirstOrDefault();
                chYazmaDurumu.Checked = (bool)yazici.Yazici;

                var sabitler = db.Sabit.FirstOrDefault();
                tKartKomisyon.Text = sabitler.KarKomisyon.ToString();

                var terazionek = db.Terazi.ToList();
                cmbTeraziOnEk.DisplayMember = "TeraziOnEk";
                cmbTeraziOnEk.ValueMember = "Id";
                cmbTeraziOnEk.DataSource = terazionek;

                tIsyeriAdSoyad.Text = sabitler.AdSoyad;
                tIsyeriUnvan.Text = sabitler.Unvan;
                tIsyeriAdres.Text = sabitler.Adres;
                tIsyeriTelefon.Text = sabitler.Telefon;
                tIsyeriEposta.Text = sabitler.Eposta;
               
            }
        }

        private void chYazmaDurumu_CheckedChanged(object sender, EventArgs e)
        {
            using (var db = new BarkodDBEntities())
            {
                if (chYazmaDurumu.Checked)
                {

                    Islemler.SabitVarsayilan();
                    var ayarla = db.Sabit.FirstOrDefault();
                    ayarla.Yazici = true;
                    db.SaveChanges();
                    chYazmaDurumu.Text = "Yazma Durumu AKTİF";

                }
                else
                {
                    Islemler.SabitVarsayilan();
                    var ayarla = db.Sabit.FirstOrDefault();
                    ayarla.Yazici = false;
                    db.SaveChanges();
                    chYazmaDurumu.Text = "Yazma Durumu PASİF";
                }
            }
        }

        private void bKartKomisyonAyarla_Click(object sender, EventArgs e)
        {
            if (tKartKomisyon.Text != "")
            {
                using (var db = new BarkodDBEntities())
                {
                    var sabit = db.Sabit.FirstOrDefault();
                    sabit.KarKomisyon = Convert.ToInt16(tKartKomisyon.Text);
                    db.SaveChanges();
                    MessageBox.Show("Kart komisyon ayarlandı");                   
                }
            }
            else
            {
                MessageBox.Show("Kart komisyon bilgisini giriniz");
            }

        }

        private void bTeraziOnEkKaydet_Click(object sender, EventArgs e)
        {
            if (tTeraziOnEk.Text!="")
            {
                int onek = Convert.ToInt16(tTeraziOnEk.Text);
                using (var db=new BarkodDBEntities())
                {
                    if (db.Terazi.Any(x=> x.TeraziOnEk==onek))
                    {
                        MessageBox.Show(onek.ToString() + " önek zaten kayıtlı");
                    }
                    else
                    {
                        Terazi t = new Terazi();
                        t.TeraziOnEk = onek;
                        db.Terazi.Add(t);
                        db.SaveChanges();
                        MessageBox.Show("Bilgiler kaydedilmiştir");
                        cmbTeraziOnEk.DisplayMember = "TeraziOnEk";
                        cmbTeraziOnEk.ValueMember = "Id";
                        cmbTeraziOnEk.DataSource = db.Terazi.ToList();
                        tTeraziOnEk.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Terazi önek bilgisini giriniz");
            }
        }

        private void bTeraziOnEkSil_Click(object sender, EventArgs e)
        {
            if (cmbTeraziOnEk.Text!="")
            {
                int onekid = Convert.ToInt16(cmbTeraziOnEk.SelectedValue);
                DialogResult onay = MessageBox.Show(cmbTeraziOnEk.Text + " öneki silmek istiyor musunuz?","Terazi Önek Silme İşlemi",MessageBoxButtons.YesNo);
                if (onay==DialogResult.Yes)
                {
                    using (var db=new BarkodDBEntities())
                    {
                        var onek = db.Terazi.Find(onekid);
                        db.Terazi.Remove(onek);
                        db.SaveChanges();
                        cmbTeraziOnEk.DisplayMember = "TeraziOnEk";
                        cmbTeraziOnEk.ValueMember = "Id";
                        cmbTeraziOnEk.DataSource = db.Terazi.ToList();
                        MessageBox.Show("Önek silinmiştir");
                    }
                }
            }
            else
            {
                MessageBox.Show("Önek seçiniz");
            }
        }

        private void bIsyeriKaydet_Click(object sender, EventArgs e)
        {
            if (tIsyeriAdSoyad.Text!="" && tIsyeriUnvan.Text!="" && tIsyeriAdres.Text!="" && tIsyeriTelefon.Text!="")
            {
                using (var db=new BarkodDBEntities())
                {
                    var isyeri = db.Sabit.FirstOrDefault();
                    isyeri.AdSoyad = tIsyeriAdSoyad.Text;
                    isyeri.Unvan = tIsyeriUnvan.Text;
                    isyeri.Adres = tIsyeriAdres.Text;
                    isyeri.Telefon = tIsyeriTelefon.Text;
                    isyeri.Eposta = tIsyeriEposta.Text;
                    db.SaveChanges();
                    MessageBox.Show("İşyeri bilgileri kaydedilmiştir");
                    var yeni = db.Sabit.FirstOrDefault();
                    tIsyeriAdSoyad.Text = yeni.AdSoyad;
                    tIsyeriUnvan.Text = yeni.Unvan;
                    tIsyeriAdres.Text = yeni.Adres;
                    tIsyeriTelefon.Text = yeni.Telefon;
                    tIsyeriEposta.Text = yeni.Eposta;
                }
            }
        }

        private void bYedektenYukle_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + @"\ProgramRestore.exe");
            Application.Exit();
        }
    }
}
