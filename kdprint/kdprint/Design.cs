using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Printing;

//Other1 发件单位 SOther1 收件单位 Other2 证件号 Other3 发件人签名 Other4 快递签名 Other5 发件人邮编
namespace kdprint
{
    public partial class Design : Form
    {
        //左右偏移量
        float lp = 0, rp = 0;
        //大字字号 字宽
        int bFont=35;
        float wFont=320;
        string picPath = "";
        bool Mode;
        PaperSize ps;
        //快递单界面变量
        static string Kdpach = Application.StartupPath + @"\data\";
        //初始化xml文档操作类
        XmlWork xw = new XmlWork(Kdpach);
        DressOut dro = new DressOut();
        private Point mouse_offset; 
        //初始化SetForm类
        SetForm sform = new SetForm(Kdpach);
        List<string[]> lst = new List<string[]>();
        private string PicName = "", PicPach = "";
        public string Kname="";
        public Design(bool mode,string kname)
        {
            Mode = mode;
            Form1.f1.Visible = false;
            Kname = kname;
            InitializeComponent();
            textBox2.Text = kname;
            ComboxInit();
            if (!mode)
            {
                comboBox1.Text = kname;
            }
            else
            {
                button1.Enabled = true;
                comboBox1.Enabled = false;
            }
        }

        //初始化combox
        public void ComboxInit()
        {
            string k = "";
            //if (Kname != "")
            //    k = Kname;
            try
            {
                comboBox1.Items.Clear();
                XmlWork xd = new XmlWork(Kdpach);
                XmlDocument xdc = new XmlDocument();
                xdc.Load(Kdpach + "combox.dat");
                XmlNode xn = xdc.SelectSingleNode("combox");
                XmlNodeList xnl = xn.ChildNodes;
                foreach (XmlNode LableNode in xn)
                {
                    k = LableNode.Attributes["Name"].InnerText;
                    comboBox1.Items.Add(k);
                }                
            }
            catch
            {
                //xw.GreatXmlDoc("combox");
                MessageBox.Show("combox.dat丢失，请联系软件作者");
            }
            finally
            {
                comboBox1.Text = Kname;
                //this.comboBox1.SelectedIndex = 0;
                //textBox1.Text = this.comboBox1.SelectedText;
                //KDDinit(this.comboBox1.Text);
            }

        }
        #region 选择是否显示文本框
        public void DisTrun(Control sender, Control cor)
        {
            if (cor.Visible == true)
            {
                sender.ForeColor = System.Drawing.Color.Black;
                cor.Visible = false;
            }
            else
            {
                sender.ForeColor = System.Drawing.Color.Brown;
                cor.Visible = true;
            }
        }
        public void ButtomTextInit(Control sender,Control cor)
        {
            if (sender.Visible==true)
                cor.ForeColor = System.Drawing.Color.Brown;
            else
                cor.ForeColor = System.Drawing.Color.Black;
        }
        public void BTinit()
        {
            ButtomTextInit(lmouth, button3);
            ButtomTextInit(lyear, button2);
            ButtomTextInit(lday, button4);
            ButtomTextInit(Other5, button5);
            ButtomTextInit(fjCity, button7);
            ButtomTextInit(Other1, button8);
            ButtomTextInit(Other2, button9);
            ButtomTextInit(Other3, button11);
            ButtomTextInit(Other4, button10);
            ButtomTextInit(SPosttxt, button6);
            ButtomTextInit(sCity, button12);
            ButtomTextInit(sOther1, button13);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DisTrun(button3, lmouth);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DisTrun(button2, lyear);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DisTrun(button4, lday);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DisTrun(button5, Other5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DisTrun(button7, fjCity);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DisTrun(button8, Other1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DisTrun(button9, Other2);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DisTrun(button11, Other3);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DisTrun(button10, Other4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DisTrun(button6, SPosttxt);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DisTrun(button12, sCity);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DisTrun(button13, sOther1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            DisTrun(button17, mudd);
        }
        #endregion

        //选择图片
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            Image ig = Image.FromFile(openFileDialog1.FileName);
            if (ig.Width >= 1000 || ig.Height > 650)
                MessageBox.Show("图像太大,限制宽小于1000像素,高小于650像素","简单快递打印");
            else if (ig.Width < 400 || ig.Height < 250)
                MessageBox.Show("图像过小,影响清晰度，请使用\n宽大于400高大于250像素的图片","简单快递打印");
            else
            {
                textBox1.Text = openFileDialog1.FileName;
                PicPach = openFileDialog1.FileName;
                //攻取文件名
                int i = PicPach.LastIndexOf("\\");
                PicName = PicPach.Substring(i + 1);
                pictureBox2.Image = Image.FromFile(PicPach);
                //MessageBox.Show(PicName);
            }
        }

        //选择框动作
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Kdname = comboBox1.Text;
            textBox2.Text = Kdname;
            //KDDinit(Kdname);
            //xw.KuiDiDefault(Kdname, 33, "1");
            lst = sform.KDDinit(Kdname);
            for (int i = 0; i < lst.Count; i++)
            {
                foreach (Control cr in groupBox1.Controls)
                {
                    if (cr.Name == lst[i][0])
                    {
                        Point pt = new Point(int.Parse(lst[i][1]), int.Parse(lst[i][2]));
                        cr.Location = pt;
                        try
                        {
                            cr.Visible = bool.Parse(lst[i][3]);
                        }
                        catch { }
                    }
                }
            }
            PicLoad(Kdname);
            //xw.KuiDiPicLode(Kname);
            Kname = Kdname;
            BTinit();
        }

        //图片动态缩放 w或h为0时使用文本框中的值
        public void PicZoom(int w, int h)
        {
            if (w == 0)
            {
                w = (int)float.Parse(textBox3.Text) * 1000 / 254;
                h = (int)float.Parse(textBox4.Text) * 1000 / 254;
            }
            if (w + 12 > 880)
                this.Width = w + 12;
            else
                this.Width = 880;
            pictureBox2.Width = w;
            if (h + 200 > 700)
                this.Height = h + 200;
            else
                this.Height = 700;
            pictureBox2.Height = h;
        }

        //加载快递单图片框大小 读取快递单属性
        public void PicLoad(string Kname)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(Kdpach+"combox.dat");
            XmlNode xn = xd.SelectSingleNode("combox");
            XmlNodeList xnl = xn.ChildNodes;
            foreach (XmlNode LableNode in xn)
            {
                if (LableNode.Attributes["Name"].InnerXml == Kname)
                {
                    string kname1 = LableNode.ChildNodes[1].InnerText;
                    picPath = kname1;
                    Image ig = Image.FromFile(Kdpach+@"pic\" + kname1);
                    int kuan1 = (int)float.Parse(LableNode.ChildNodes[3].InnerText) * 1000 / 254;
                    textBox3.Text = LableNode.ChildNodes[3].InnerText;
                    int gao1 = (int)float.Parse(LableNode.ChildNodes[4].InnerText) * 1000 / 254;
                    textBox4.Text = LableNode.ChildNodes[4].InnerText;
                    try
                    {
                        textBox5.Text = LableNode.ChildNodes[5].InnerText;
                        lp = float.Parse(LableNode.ChildNodes[5].InnerText) * 1000 / 254;
                        textBox6.Text = LableNode.ChildNodes[6].InnerText;
                        rp = float.Parse(LableNode.ChildNodes[6].InnerText) * 1000 / 254;
                        textBox7.Text = LableNode.ChildNodes[7].InnerText;
                        bFont = int.Parse(LableNode.ChildNodes[7].InnerText);
                        textBox8.Text = LableNode.ChildNodes[8].InnerText;
                        wFont = float.Parse(LableNode.ChildNodes[8].InnerText) * 1000 / 254;
                    }
                    catch
                    {
                        textBox5.Text = "0";
                        textBox6.Text = "0";
                        textBox7.Text = "35";
                        textBox8.Text = "100";
                    }
                    PicZoom(kuan1, gao1);
                    pictureBox2.Image = ig;
                    CenterToScreen();
                    //设定打印纸
                    ps = new PaperSize(this.comboBox1.Text, kuan1, gao1);
                    this.printDocument1.DefaultPageSettings.PaperSize = ps;
                    this.printDocument1.DocumentName = this.comboBox1.Text;
                }
            }
        }

        #region//更改文本框位置 鼠标动作
        void MouseD(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
        }
        void MouseM(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouse_offset.X, mouse_offset.Y);
                ((Control)sender).Location = ((Control)sender).Parent.PointToClient(mousePos);
            }
        }
        #endregion

        #region //快递单宽高约束
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (Int32.Parse(textBox3.Text.Trim()) < 100 || Int32.Parse(textBox3.Text.Trim()) >= 250)
                textBox3.Text = "230";
            PicZoom(0, 0);
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (Int32.Parse(textBox4.Text.Trim()) < 50 || Int32.Parse(textBox4.Text.Trim()) >= 145)
                textBox3.Text = "127";
            PicZoom(0, 0);
        }
        #endregion

        //help
        private void button15_Click(object sender, EventArgs e)
        {
           
        }

        //保存模板
        public void TextBoxDress(string Kname)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(Kdpach+"xmldoc.dat");
            }
            catch
            {
                xw.GreatXmlDoc(Kname);
                doc.Load(Kdpach + "xmldoc.dat");
            }
            //			Point lab=fName.Location;获取控件坐标
            //			MessageBox.Show(lab.ToString());
            foreach (Control cr in groupBox1.Controls)
            {
                if (cr is TextBox)
                {
                    xw.ModeSave(doc, cr.Name,cr.Visible.ToString(), cr.Location.X.ToString(), cr.Location.Y.ToString(), Kname);
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (Mode)
            {
                if (textBox1.Text.Replace(" ", "") == "")
                {
                    MessageBox.Show("请选择快递单图片");
                    return;
                }
                if (textBox2.Text.Replace(" ", "") == "")
                {
                    textBox2.Focus();
                    MessageBox.Show("请输入名字");
                    return;
                }
                try
                {
                    File.Copy(PicPach, Kdpach+@"pic\" + Kname + ".jpg", true);
                }
                catch
                {
                    MessageBox.Show("图片已在目录中，并且正在使用不能替换");
                    return;
                }
                picPath = Kname + ".jpg";
            }
            TextBoxDress(comboBox1.Text);
            xw.KuiDiNew(Kname, picPath, textBox3.Text.Replace(" ", ""), textBox4.Text.Replace(" ", ""), textBox5.Text.Replace(" ", ""), textBox6.Text.Replace(" ", ""), textBox7.Text.Replace(" ", ""), textBox8.Text.Replace(" ", ""));
        }
        private void Design_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.f1.Kname = Kname;
            Form1.f1.ComboxInit();
            Form1.f1.Visible = true;
        }

        #region//打印预览
        private void button14_Click(object sender, EventArgs e)
        {
            //设定打印纸
            this.printDocument1.DefaultPageSettings.PaperSize = ps;
            try
            {
                ToolStrip tool = printPreviewDialog1.Controls[1] as ToolStrip;
                if (tool != null)
                {
                    tool.Items["printToolStripButton"].Visible = false;
                }
                printPreviewDialog1.Document = this.printDocument1;
                printPreviewDialog1.Show();
            }
            catch
            {
                PrintPreviewDialog pt = new PrintPreviewDialog();
                pt.Document = this.printDocument1;
                pt.Show();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (this.pictureBox2.Image != null)
            {
                e.Graphics.DrawImage(this.pictureBox2.Image, 0, 0, this.pictureBox2.Width, this.pictureBox2.Height);
            }

            // 为大字设置图片框大小
            Bitmap bp;
            Font ft = new Font("宋体", bFont);
            bp = xw.TextBitmap(sCity.Text, bFont, (int)wFont);
            if (bp.Width < wFont)
                bigbox.Width = bp.Width;
            else
                bigbox.Width = (int)wFont;
            bigbox.Height = (int)ft.Height;
            bigbox.Image = bp;

            Point pt = new Point();
            if (sCity.Visible)
            {
                pt = sCity.Location;
                Rectangle rect = new Rectangle(pt.X, pt.Y, bigbox.Width, bigbox.Height);
                e.Graphics.DrawImage(bp, rect);
            }

            foreach (Control ct in this.groupBox1.Controls)
            {
                if (ct.Text != "" && ct.Visible)
                {
                    pt = ct.Location;
                    if (ct == sCity)
                    { continue; }
                    //e.Graphics.DrawString(ct.Text, new Font("宋体", bFont, FontStyle.Bold), Brushes.Black, new RectangleF(pt.X + (int)lp, pt.Y + (int)rp, wFont, 120), new StringFormat(StringFormatFlags.LineLimit));
                    else
                        e.Graphics.DrawString(ct.Text, new Font("宋体", 11), Brushes.Black, new RectangleF(pt.X + (int)lp, pt.Y + (int)rp, 290, 120));
                }
            }
        }
        #endregion

        #region//文本输入约束
        private void textBox5_Leave(object sender, EventArgs e)
        {
            try
            {
                lp = float.Parse(textBox5.Text) * 1000 / 254;
            }
            catch
            {
                textBox5.Text = "0";
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            try
            {
                rp = float.Parse(textBox6.Text) * 1000 / 254;
            }
            catch
            {
                textBox6.Text = "0";
            }
        }
        //文件名输入限制
        private void textBox2_Leave(object sender, EventArgs e)
        {
            char[] cr = textBox2.Text.Replace(" ", "").ToCharArray();
            for (int i = 0; i < cr.Length; i++)
            {
                if (cr[i] == '/' || cr[i] == '\\' || cr[i] == '<' || cr[i] == '>' || cr[i] == '?' || cr[i] == '*')
                {
                    textBox2.Text = Kname;
                    if (Kname == "")
                        MessageBox.Show("请输入名字");
                    return;
                }
            }
            xw.ReKuiDi(textBox2.Text.Replace(" ", ""), Kname);
            Kname = textBox2.Text.Replace(" ", "");
            ComboxInit();
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            try
            {
                bFont = int.Parse(textBox7.Text);
            }
            catch
            {
                textBox7.Text = "35";
            }

        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            try
            {
                wFont = float.Parse(textBox8.Text) * 1000 / 254;
            }
            catch
            {
                textBox8.Text = "100";
            }
        }
        #endregion

        private void Design_Shown(object sender, EventArgs e)
        {
            BTinit();
        }

    }
}
