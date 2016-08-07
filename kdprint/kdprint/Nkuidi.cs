using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace kdprint
{
    public partial class Nkuidi : Form
    {
        //快递单界面变量
        static string Kdpach = Application.StartupPath + @"\data\";
        string Kname="";
        //图片名
        private string PicName="",PicPach="";
        XmlWork xw = new XmlWork(Kdpach);
        public Nkuidi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Image ig=Image.FromFile(this.openFileDialog1.FileName);
            if (ig.Width > 1000 || ig.Height > 650)
            {
                MessageBox.Show("图像太大,请缩放至实际大小,限制宽900,高550");
                PicName = "";
            }
            else if (ig.Width < 400 || ig.Height < 250)
            {
                MessageBox.Show("图像过小,请缩放至实际大小");
                PicName = "";
            }
            else
            {
                PicPach = this.openFileDialog1.FileName;
                //攻取文件名
                int i = PicPach.LastIndexOf("\\");
                PicName = PicPach.Substring(i + 1);
                this.pictureBox1.Image = Image.FromFile(PicPach);
                //MessageBox.Show(PicName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Regex re = new Regex(@"\d+");
            Match ma;
            //Match ma = re.Match(textBox2.Text);
            string gao, kuang;
            kuang = textBox2.Text.Replace(" ","");
            ma = re.Match(kuang);
            if (ma.Success == false)
            {
                
                MessageBox.Show("宽应该为数字");
                textBox2.Focus();
                return;
            }
            kuang = ((int.Parse(kuang))).ToString();
            gao = textBox3.Text.Replace(" ", "");
            ma = re.Match(gao);
            if (ma.Success == false)
            {
                MessageBox.Show("高应该为数字");
                textBox3.Focus();
                return;
            }
            try
            {
                kuang = ((int.Parse(kuang))).ToString();
                gao = ((int.Parse(gao))).ToString();
            }
            catch
            {
                MessageBox.Show("数字请用半角输入，或英文输入法下输入数字");
                return;
            }

            Kname = this.textBox1.Text.ToString().Trim();
            if (Kname == "" || this.textBox1.Text == "请输入快递名称")
            {
                this.textBox1.Focus();
                this.textBox1.Text = "请输入快递名称";
                return;
            }
            else if(PicName=="")
            {
                MessageBox.Show("请选择图片");
                button1_Click(sender, e);

            }
            else if (File.Exists(Kdpach+@"pic\" + PicName) == true)
            {
                if (MessageBox.Show("确认将原图覆盖,点取消重选图片或者更改图片名称后再试", PicName + "图片已存在", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(PicPach,Kdpach+ @"pic\" + PicName, true);
                        this.Close();
                    }
                    catch { }
                    finally
                    {
                        xw.KuiDiNew(Kname, PicName, kuang, gao, "", "", "", "");

                        //Form1.f1.Listbox2Init(Kname);
                    }
                }
            }

            else
            {
                File.Copy(PicPach, Kdpach+@"pic\" + PicName);
                xw.KuiDiNew(Kname, PicName,kuang,gao,"","","","");
                //Form1.f1.Listbox2Init("");
                this.Close();
            }
        
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            Kname = this.textBox1.Text.ToString().Trim();
            if (xw.ReCombox(Kname) == true)
            {
                MessageBox.Show(Kname+"已存在,请重新输入快递名称");
                this.textBox1.Focus();
            }
        }

    }
}
