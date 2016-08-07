//Form1默认大小(1100, 654)图片框默认大小(870, 465) 限定大小(900, 550)
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;
using System.Drawing.Printing;
using DBUtility;

namespace kdprint
{
    public partial class Form1 : Form
    {
        Bitmap bp=new Bitmap(1,1);
        //左右偏移量
        float lp = 0, rp = 0;
        //大字字号 字宽
        int bFont = 35;
        float wFont = 320;
        PaperSize ps;
        string Kdname="";
        //快递宽高
        //int kKuang, kGao;
        char[] zcm = new char[] { };
        ArrayList ar = new ArrayList();
        //listbox2功能false为修改快递名模式,true为正常可用
        public static Form1 f1;
        //收件人变量
        string Sname = "", Sdress = "", Stel = "", Sphone = "", Spost = "", Stxt = "", Sxin = "", Squ = "";
        string tx2; //临时保存单号

        //快递单界面变量
        static string Kdpach =Application.StartupPath+ @"\data\";


        //初始化xml文档操作类
        XmlWork xw = new XmlWork(Kdpach);
        DressOut dro = new DressOut();

        //初始化SetForm类
        SetForm sform = new SetForm(Kdpach);
        List<string[]> lst = new List<string[]>();
        public string Kname
        {
            set
            { Kdname = value; }
        }
        public Form1()
        {
            InitializeComponent();
            f1 = this;

            //设置默认快递，需要完成自动打开最后打印过的快递单
            //this.pictureBox2.Image = Image.FromFile(@"C:\\Users\feisa\Desktop\快递单图片\顺风.bmp");

            //初始设置打印边距为0
            //Margins margins = new Margins(0, 0, 0, 0);
            //printDocument1.DefaultPageSettings.Margins = margins;

            //初始化Combox1
            ComboxInit();
            //初始化快递单            
            Kdname = this.comboBox1.Text;
            textInit();
        }
        //初始化combox
        public void ComboxInit()
        {
            string Kname="";
            string k = Kdname;
            try
            {
                this.comboBox1.Items.Clear();
                XmlWork xd = new XmlWork(Kdpach);
                XmlDocument xdc = new XmlDocument();
                xdc.Load(Kdpach + "combox.dat");
                XmlNode xn = xdc.SelectSingleNode("combox");
                XmlNodeList xnl = xn.ChildNodes;
                foreach (XmlNode LableNode in xn)
                {
                    Kname = LableNode.Attributes["Name"].InnerText;
                    if (LableNode.ChildNodes[0].InnerText == "0"&&k=="")
                    {
                        k=Kname;
                    }




                }
                foreach (XmlNode LableNode in xn)
                {
                    Kname = LableNode.Attributes["Name"].InnerText;
                    this.comboBox1.Items.Add(Kname);
                }
                if (k == "")
                {
                    this.comboBox1.Text = Kname;
                }
                else
                {
                    this.comboBox1.Text = k;
                }
                //this.comboBox1.DropDownStyle = ComboBoxStyle.DropDown;
                //this.comboBox1.Refresh();
            }
            catch
            {
                //xw.GreatXmlDoc("combox");
                MessageBox.Show("combox.dat丢失，请联系软件作者");
            }
            finally 
            {
                Kdname = this.comboBox1.Text;
                //this.comboBox1.SelectedIndex = 0;
                //textBox1.Text = this.comboBox1.SelectedText;
                LbInit(Kdname);
            }

        }


        //初始化listbox2
        //public void Listbox2Init(string KuiDiName)
        //{
        //    try
        //    {
        //        string Kname = "";
        //        this.listBox2.Items.Clear();
        //        XmlWork xd = new XmlWork();
        //        XmlDocument xdc = new XmlDocument();
        //        xdc.Load(Kdpach + "combox.dat");
        //        XmlNode xn = xdc.SelectSingleNode("combox");
        //        XmlNodeList xnl = xn.ChildNodes;
        //        foreach (XmlNode LableNode in xn)
        //        {
        //            Kname = LableNode.Attributes["Name"].InnerText;
        //            this.listBox2.Items.Add(Kname);
        //            if (Kname == KuiDiName)
        //            {
        //                this.listBox2.SelectedItem = KuiDiName;
        //                LbInit(Kname);
        //            }
        //        }
        //        if (KuiDiName == "")
        //        {
        //            this.listBox2.SelectedItem = Kname;
        //            LbInit(Kname);
        //        }
        //    }
        //    catch
        //    {
        //        //xw.GreatXmlDoc("combox");

        //        MessageBox.Show("combox.dat丢失，请联系软件作者");
        //    }
        //    finally
        //    {
        //        this.listBox2.Refresh();
        //    }
        //}

        //设计模板
        private void button4_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(this.button4, 5, 16);
            //Design ds = new Design(false,Kdname);
            //ds.ShowDialog();
        }

        //生成快递单
        private void button1_Click(object sender, EventArgs e)
        {
            Stxt = Convert.ToString(xmlTxt.Text).Trim();
            GetString(Stxt);
        }

        //分解收货地址
        public void GetString(string Stxt1)
        {
            //Stxt="彭丽霞 ，13736571800 ， ，浙江省 台州市, 玉环县, 楚门镇 大莆田 会员超市 前50米 ，317605 ";
            if (Stxt1 != "")
            {

                string[] st;
                st = dro.GetString(Stxt);
                Sname = st[0];
                Stel = st[1];
                Sphone = st[2];
                Sdress = st[3];
                Spost = st[4];
                Sxin = st[5];
                Squ = st[6];

                if (Sname == "" || Sdress == "")
                {
                    MessageBox.Show("收货信息不完整！");
                    return;
                }
                sjName.Text = "";
                sjPhone.Text = "";
                sjTel.Text = "";
                sjDress.Text = "";
                sCity.Text = "";
                SPosttxt.Text = "";
                sjName.Text = Sname;
                sjPhone.Text = Sphone;
                sjTel.Text = Stel;
                sjDress.Text = Sdress;
                sCity.Text = (Sxin+Squ).Replace(" ","");
                SPosttxt.Text = Spost;
                mudd.Text = Sxin;

                // 为大字设置图片框大小
                Font ft = new Font("宋体", bFont);
                bp = xw.TextBitmap(sCity.Text,bFont,(int)wFont);
                if (bp.Width < wFont)
                    bigbox.Width = bp.Width*3/5;
                else
                    bigbox.Width = (int)wFont;
                bigbox.Height = (int)ft.Height;
                bigbox.Image = bp;

            }
            else
            {
                MessageBox.Show("请粘入淘宝收货地址地址格式！");
            }
            Sname = "";
            Sphone = "";
            Sdress = "";
            Stel = "";
            Sxin = "";
            Squ = "";
            Spost = "";
        }

        //打印
        private void button2_Click(object sender, EventArgs e)
        {
            //显示打印对话框
            if (sjName.Text == ""||sjDress.Text=="")
            {
                if (MessageBox.Show("还未生成快递单，需要生成数据吗？") == DialogResult.OK)
                {
                    button1_Click(sender, e);
                }
            }
            else
            {
                string DhString,st;
                PrintDialog pr = new PrintDialog();
                pr.Document = this.printDocument1;
                this.printDocument1.Print();
                //xmlTxt.Text = sjName.Text + "已发送打印,如未能正常打印请查看打印机是否连接正确！";
                if(Stxt!="")
                    this.listBox1.Items.Add(Stxt);
                ar.Add(textBox1.Text);

                //打印后设置快递单号
                DhString=textBox1.Text;
                textBox2.Text = DhString;
                textBox3.Text = sjName.Text;
                for (int x =DhString.Length-1; x >= 0; x--)
                {
                    int y;
                    st = DhString.Substring(x, 1);
                    if (Regex.IsMatch(st, @"\d") == true)
                    {
                        y = int.Parse(st) + 1;
                        if (y < 10)
                        {
                            string nt;
                            nt = DhString.Remove(x, 1);
                            DhString = nt.Insert(x, y.ToString());
                            break;
                        }
                        else
                        {
                            string nt;
                            nt = DhString.Remove(x, 1);
                            DhString = nt.Insert(x, "0");
                        }
                    }
                }
                this.textBox1.Text = DhString.ToString();
                xw.KuiDiDefault(Kdname, 44, DhString.ToString());
                sjName.Text = "";
                sjDress.Text = "";
                sjPhone.Text = "";
                sjTel.Text = "";
                sCity.Text = "";
                sOther1.Text = "";
                xmlTxt.Text = "";
            }
        }

        //combox默认值设定
        private void button5_Click(object sender, EventArgs e)
        {
            Kdname = this.comboBox1.Text;
            xw.KuiDiDefault(Kdname, 0,"1");
        }

        //combox选择加载快递单
        private void comboBox1_Change(object sender, EventArgs e)
        {
            Kdname = this.comboBox1.Text;
            LbInit(Kdname);
            xw.KuiDiDefault(Kdname, 33,"1");
            this.textBox2.Text = "";
        }

        //关闭
        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       //列表框1双击加载收货信息
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Stxt = this.listBox1.SelectedItem.ToString();
                GetString(Stxt);
                this.textBox2.Text = ar[this.listBox1.SelectedIndex].ToString();
            }
            catch { }
            finally { }
        }

        //private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    //lb = true;
        //    string kdname = "";
        //    try
        //    {
        //        kdname = this.listBox2.SelectedItem.ToString().Trim();
        //    }
        //    catch
        //    {
        //        kdname = "请输入快递名称";
        //    }
        //    this.contextMenuStrip1.Show(this.listBox2, 5, e.Y - 16);
        //    this.DelKuidi.Visible = false;
        //    this.AddKuidi.Visible = false;
        //}

        //初始化txt发件人文本框内容
        public void TextLode(string lname, string txt)
        {
            foreach (Control cr in this.groupBox1.Controls)
            {
                if (cr.Name == lname)
                {
                    cr.Text = txt;
                }
            }
        }
        //初始化发件人
        public void textInit()
        {

            try
            {

                string lname, ltxt;
                XmlDocument xd = new XmlDocument();
                xd.Load(Kdpach + @"XMLtxt.dat");

                XmlNode xn = xd.SelectSingleNode("Kset");
                XmlNodeList xnl = xn.ChildNodes;
                foreach (XmlNode txtnode in xn)
                {
                    lname = txtnode.Attributes["Name"].InnerText;
                    ltxt = txtnode.InnerText;
                    TextLode(lname, ltxt);
                }
            }
            catch
            {
                MessageBox.Show("发件人信息读取错误");
            }
            finally
            {
                System.DateTime dt = new DateTime();
                dt = System.DateTime.Now;
                lyear.Text = dt.Year.ToString();
                lmouth.Text = dt.Month.ToString();
                lday.Text = dt.Day.ToString();
                this.Refresh();

            }
        }

        //初始化文本框位置
        public void LbInit(string KuidiName)
        {
            lst = sform.KDDinit(KuidiName);
            for (int i = 0; i < lst.Count; i++)
            {
                foreach (Control cr in this.groupBox1.Controls)
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
        }

        //保存发件人信息
        private void button3_Click(object sender, EventArgs e)
        {
            xw.FjSave(fjName.Text, fjCity.Text, fjDress.Text, fjTel.Text, fjPhone.Text, Other1.Text, Other2.Text, Other3.Text, Other4.Text, Other5.Text, SPosttxt.Text);
        }
        
        //private void listBox2_MouseClick(object sender, MouseEventArgs e)
        //{
        //    string kdname = "";
        //    try
        //    {
        //        kdname = this.listBox2.SelectedItem.ToString().Trim();
        //    }
        //    catch
        //    {
        //    }
        //    finally
        //    {
        //        LbInit(kdname);
        //    }
        //    //MessageBox.Show(this.listBox2.SelectedItem.ToString());
        //}
        

        //收货地址文本框中双击全选
        private void ClickTxt(object sender, MouseEventArgs e)
        {
            this.xmlTxt.SelectAll();
        }

        //删除快递
        //private void DelKuidi_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string kname = this.listBox2.SelectedItem.ToString().Trim();
        //        if (MessageBox.Show("确认将" + this.listBox2.SelectedItem + "删除吗?", "删除" + this.listBox2.SelectedItem, MessageBoxButtons.OKCancel) == DialogResult.OK)
        //        {
        //            File.Delete(Kdpach + kname + @".dat");
        //            xw.KuiDiDel(kname);
        //            Listbox2Init("");
        //        }
        //    }
        //    catch { }
        //    finally { }
        //}

        //新增快递

        //页面设置
        private void button6_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.Document = this.printDocument1;
            pageSetupDialog1.ShowDialog();
        }

        //加载快递单图片
        public void PicLoad(string pc, int w, int g,float flp,float frp,int bf,float wf)
        {
            lp = flp; rp = frp; bFont = bf; wFont = wf;
            Image ig = Image.FromFile(Kdpach+@"pic\" + pc);
            this.Width = w + 230;
            this.pictureBox2.Width = w;
            this.Height = g + 198;

            this.pictureBox2.Height = g;
            this.pictureBox2.Image = ig;

            //设定打印纸
            ps = new PaperSize(this.comboBox1.Text, w, g);
            this.printDocument1.DefaultPageSettings.PaperSize = ps;
            this.printDocument1.DocumentName = this.comboBox1.Text;

        }

        //打印预览
        private void button7_Click(object sender, EventArgs e)
        {
            //设定打印纸
            this.printDocument2.DefaultPageSettings.PaperSize = ps;
            try
            {
                ToolStrip tool = printPreviewDialog1.Controls[1] as ToolStrip;
                if (tool != null)
                {
                    tool.Items["printToolStripButton"].Visible = false;
                }
                printPreviewDialog1.Document = this.printDocument2;
                printPreviewDialog1.Show();
            }
            catch
            {
                PrintPreviewDialog pt = new PrintPreviewDialog();
                pt.Document = this.printDocument2;
                pt.Show();
            }
        }

        //输入打印内容
        void PrintDocument1PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Point pt = new Point();
            if (sCity.Visible)
            {
                pt = sCity.Location;
                Rectangle rect = new Rectangle(pt.X, pt.Y, bigbox.Width, bigbox.Height);
                e.Graphics.DrawImage(this.bp, rect);
            }

            foreach (Control ct in this.groupBox1.Controls)
            {
                if (ct.Text != ""&&ct.Visible)
                {
                    pt = ct.Location;
                    if (ct == sCity)
                    { continue; }
                    //e.Graphics.DrawString(ct.Text, new Font("宋体", bFont,FontStyle.Bold), Brushes.Black, new RectangleF(pt.X + (int)lp, pt.Y + (int)rp, wFont, 120),new StringFormat(StringFormatFlags.NoWrap));
                    else
                        e.Graphics.DrawString(ct.Text, new Font("宋体", 11), Brushes.Black, new RectangleF(pt.X + (int)lp, pt.Y + (int)rp, 290, 120));
                }
            }
        }

        //设定初始单号
        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox2.ReadOnly == true)
            {
                textBox2.ReadOnly = false;
                tx2 = textBox2.Text;
                textBox2.Focus();
            }
        }

        //快递单号读取
        public void KuiDiDanghaoRead(string danghao)
        {
            this.textBox1.Text = danghao;
        }

        //将单号复制到剪贴板
        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox2.ReadOnly == true)
            {
                Clipboard.SetDataObject(textBox2.Text);
                label1.Text = "单号已复制";
            }
        }
        //快递单号设置
        private void textBox2_Leave(object sender, EventArgs e)
        {
            label1.Text = "";
            string txt=this.textBox2.Text.Replace(" ","");
            try
            {
                if (this.textBox2.Text.Trim() != ""  && this.textBox2.ReadOnly == false)
                {
                    Regex reg = new Regex(@"\W*\d+\W*");
                    Match ma = reg.Match(txt);
                    if (ma.Success == true)
                    {
                        if (MessageBox.Show("确定将" + txt + "\n设定为初始单号吗?", this.comboBox1.Text, MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            xw.KuiDiDefault(this.comboBox1.Text, 44, txt);
                            this.textBox1.Text = txt;
                        }
                        else
                        {
                            textBox2.Text = txt;
                        }
                    }
                }
                else
                {
                    textBox2.Text = txt;
                }
            }
            catch
            {
                textBox2.Text = txt;
            }
            finally 
            {
                textBox2.ReadOnly = true;
            }
        }

     //注册按键 改为关于2013.1.12改为免费版
        private void button8_Click(object sender, EventArgs e)
        {
            //ZhuCeLode();
            //Form st = new Start();
            //Form st = new Start(zhucema, yonhu);
            //st.ShowDialog();
        }

        //读取用户名注册码
        //public void ZhuCeLode()
        //{
        //    string s = xw.LoadReg();
        //    if (s.Length >= 17)
        //    {
        //        yonhu = s.Substring(16);
        //        zhucema = s.Substring(0,16);
        //    }
        //    else
        //    {
        //        yonhu = "";
        //        zhucema = "";
        //    }
        //}

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (this.pictureBox2.Image != null)
            {
                e.Graphics.DrawImage(this.pictureBox2.Image, 0, 0, this.pictureBox2.Width, this.pictureBox2.Height);
            }

            Point pt = new Point();
            if (sCity.Visible)
            {
                pt = sCity.Location;
                Rectangle rect = new Rectangle(pt.X, pt.Y, bigbox.Width, bigbox.Height);
                e.Graphics.DrawImage(this.bp, rect);
            }

            foreach (Control ct in this.groupBox1.Controls)
            {
                if (ct.Text != "" && ct.Visible)
                {
                    pt = ct.Location;
                    if (ct == sCity)
                    {
                        continue;
                    }

                //e.Graphics.DrawString(ct.Text, new Font("宋体", bFont, FontStyle.Bold), Brushes.Black, new RectangleF(pt.X + (int)lp, pt.Y + (int)rp, wFont, 120), new StringFormat(StringFormatFlags.LineLimit));
                    else
                        e.Graphics.DrawString(ct.Text, new Font("宋体", 11), Brushes.Black, new RectangleF(pt.X + (int)lp, pt.Y + (int)rp, 290, 120));
                }
            }
        }

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            //string url = ((WebBrowser)sender).Document.ActiveElement.GetAttribute("href");
            //System.Diagnostics.Process.Start(url);
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(@"##");
        }

        private void ReKuidiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Design ds = new Design(false, Kdname);
            ds.ShowDialog();
        }

        private void AddKuidi_Click(object sender, EventArgs e)
        {
            Design ds = new Design(true, "");
            ds.ShowDialog();
        }
        private void DelKuidi_Click(object sender, EventArgs e)
        {
            xw.KuiDiDel(Kdname);
            Kdname = "";
            ComboxInit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.xmlTxt.Focus();
            this.xmlTxt.SelectedText = "请粘贴收货人信息";
            this.xmlTxt.Select();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string fh = txt_fhnum.Text.Trim();
            if (!string.IsNullOrEmpty(fh))
            {
                //Stxt="彭丽霞 ，13736571800 ， ，浙江省 台州市, 玉环县, 楚门镇 大莆田 会员超市 前50米 ，317605 ";
              DataTable dt=  DbHelperSQL.Query(" select top 1 * from sf_rcvsnd where billid='"+fh+"'").Tables[0];
              if (dt.Rows.Count > 0)
              {
                  string str = dt.Rows[0]["LinkMan"].ToString() + "  ," + dt.Rows[0]["Tel"].ToString() + ",," + dt.Rows[0]["adr"].ToString() + "," + dt.Rows[0]["zip"].ToString();
                  xmlTxt.Text = str;
                  Stxt = Convert.ToString(str).Trim();
                  GetString(Stxt);

                  fjName.Text = dt.Rows[0]["operator"].ToString();
                  Other1.Text = "测试公司名称";
                  fjDress.Text = "测试地址";
                  Other2.Text = "Other2";
                  Other3.Text = dt.Rows[0]["operator"].ToString(); ;//寄件人签名
                  Other4.Text = "";//客户签名
                  Other5.Text = "100000";//邮编
                  fjCity.Text = "";//发件城市
                  
                  DataTable sellinfo = DbHelperSQL.Query(" select top 1 * from jc_staff where [_Name]='" + fjName.Text + "'").Tables[0];
                  if (sellinfo.Rows.Count > 0)
                  {
                    fjPhone.Text= sellinfo.Rows[0]["Tel"].ToString();
                  }



                  string snd = dt.Rows[0]["sndStyle"].ToString();
                     comboBox1.SelectedText = snd;
                     this.comboBox1.Text = snd;

                  Kdname = snd;
                  LbInit(Kdname);
                  xw.KuiDiDefault(Kdname, 33, "1");
                  this.textBox2.Text = "";
                 // MessageBox.Show(this.comboBox1.Text,"提示",MessageBoxButtons.OK);
              }
            }
        }

    }
}
