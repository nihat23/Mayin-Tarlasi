using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mayın_Tarlası
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1Renk_Click(object sender, EventArgs e)
        {
            DialogResult arkarenk = colorDialog1.ShowDialog();
            if(arkarenk== DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
            }
        }



        private void button2YenidenOyna_Click(object sender, EventArgs e)
        {
            secilen = 0;
            bulunan = 0;
            butonuret();

        }
        private void butonuret()
        {
            flowLayoutPanel1.Controls.Clear();

            Random rnd = new Random();
            
            List<int> mayinlar = new List<int>();
            
            for(int i=1; mayinlar.Count<40; i++)
            {
                int sayi = rnd.Next(1, 114);
                if (!mayinlar.Contains(sayi))
                {
                    mayinlar.Add(sayi);
                }
            }

            for(int bos_hucre=1; bos_hucre < 113; bos_hucre++)
            {
                Button btn = new Button();
                btn.Size = new System.Drawing.Size(35, 35);
                btn.Text = bos_hucre.ToString();

                if (mayinlar.Contains(bos_hucre))
                {
                    btn.Tag = true;

                }
                else
                {
                    btn.Tag = false;
                }
                btn.Click += Btn_Click;

                flowLayoutPanel1.Controls.Add(btn);
            }
        }


        int secilen = 0;
        int bulunan = 0;
        private void Btn_Click(object sender, EventArgs e)
        {
            Button basilanButon =(Button) sender;
            bool mayin = (bool)basilanButon.Tag;

            if (mayin)
            {
                basilanButon.BackColor = Color.Red;
                basilanButon.Enabled = false;
                MessageBox.Show("Mayına Bastınız", "TEHLİKE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bulunan++;
                
            }
            else
            {
                basilanButon.BackColor = Color.Green;
                basilanButon.Enabled = false;
                secilen++;
            }
            label4bulunan.Text = bulunan.ToString();
            label2secilen.Text = secilen.ToString();

            if (bulunan >=30)
            {
                DialogResult soruvecevap = MessageBox.Show("Bütün Mayınlar Patladı..!", "Yeniden Başlatmak istermisin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (soruvecevap == DialogResult.OK)
                {
                    secilen = 0;
                    bulunan = 0;
                    butonuret();

                }
                else
                {
                    secilen = 0;
                    bulunan = 0;
                    butonuret();
                    
                }


            }


        }


        

        private void Form1_Load(object sender, EventArgs e)
        {
            butonuret();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/n.beyi");
        }
    }
}
