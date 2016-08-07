using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;
using System.Drawing;
using System.Security.Cryptography;

namespace kdprint
{
    class XmlWork
    {
        string Kdpach = Application.StartupPath + @"\data\";
        public XmlWork(string kpach1)
        {
            Kdpach = kpach1;
        }
        //string pathuser = @".\data\user.dat";
        //当数据文件没有时创建一个Xml文档 @".\data\"
        public void GreatXmlDoc(string FileName)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration newDec = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(newDec);

            //create the new root element
            XmlElement newRoot = doc.CreateElement(FileName);
            doc.AppendChild(newRoot);
            XmlTextWriter tr = new XmlTextWriter(Kdpach + FileName + ".dat", null);
            tr.Formatting = Formatting.Indented;
            doc.WriteContentTo(tr);
            tr.Close();
        }
        //保存发件人信息
        public void FjSave(string Fname, string Fcity, string Fdress, string Ftel, string Fphone, string other1, string other2, string other3, string other4, string other5, string other6)
        {
            XmlDocument xdc = new XmlDocument();
            try
            {
                xdc.Load(Kdpach + @"xmldoc.dat");
            }
            catch
            {
                XmlDocument doc = new XmlDocument();
                XmlDeclaration newDec = doc.CreateXmlDeclaration("1.0", null, null);
                doc.AppendChild(newDec);

                //create the new root element
                XmlElement newRoot = doc.CreateElement("Kset");
                doc.AppendChild(newRoot);
                XmlTextWriter tr = new XmlTextWriter(Kdpach + @"xmldoc.dat", null);
                tr.Formatting = Formatting.Indented;
                doc.WriteContentTo(tr);
                tr.Close();
                xdc.Load(Kdpach+@"xmldoc.dat");
            }
            finally
            {
                MTextSave(xdc, "fjName", Fname);
                MTextSave(xdc, "fjCity", Fcity);
                MTextSave(xdc, "fjDress", Fdress);
                MTextSave(xdc, "fjTel", Ftel);
                MTextSave(xdc, "fjPhone", Fphone);
                MTextSave(xdc, "Other1", other1);
                MTextSave(xdc, "Other2", other2);
                MTextSave(xdc, "Other3", other3);
                MTextSave(xdc, "Other4", other4);
                MTextSave(xdc, "Other5", other5);
                MTextSave(xdc, "Other6", other6);
            }
        }
 
        //保存模板--保存
        public void ModeSave(XmlDocument doc, string name, string attrib, string pointx, string pointy,string Kname)
        {
            XmlNode sroot = doc.SelectSingleNode("Kset");
            //Lable节点
            XmlElement nlable = doc.CreateElement("Lable");
            nlable.SetAttribute("Name", name);
            sroot.AppendChild(nlable);


            //Lable描述
            XmlElement px = doc.CreateElement("pointx");
            px.InnerText = pointx;
            nlable.AppendChild(px);

            XmlElement py = doc.CreateElement("pointy");
            py.InnerText = pointy;
            nlable.AppendChild(py);

            XmlElement att = doc.CreateElement("attrib");
            att.InnerText = attrib;
            nlable.AppendChild(att);
            doc.Save(Kdpach + Kname + ".dat");
        }

        //保存用户注册信息
        public void NameSave()
        {}
        //快递单删除combox内容删除
        public void KuiDiDel(string Kname)
        {
            string Aname;
            XmlDocument xd = new XmlDocument();
            xd.Load(Kdpach + @"combox.dat");
            XmlNode xn = xd.SelectSingleNode("combox");
            foreach (XmlNode LableNode in xn)
            {
                Aname=LableNode.Attributes["Name"].InnerXml.Trim();
                //MessageBox.Show(Aname);
                if (Aname == Kname)
                {
                    LableNode.ParentNode.RemoveChild(LableNode);
                    xd.Save(Kdpach + @"combox.dat");
                }
            }
        }
        //快递单新增combox新增 存在则修改
        public void KuiDiNew(string Kname,string picName,string kuang,string gao,string Pleft,string Pright,string BigFont,string Bigwidth)
        {
            try
            {
                //查找是否存在 存在则删除
                try
                {
                    KuiDiDel(Kname);
                }
                catch { }
                XmlDocument xd = new XmlDocument();
                xd.Load(Kdpach + @"combox.dat");
                XmlNode xn = xd.SelectSingleNode("combox");

                XmlElement nName = xd.CreateElement("Lable");
                nName.SetAttribute("Name", Kname);
                xn.AppendChild(nName);

                //Lable描述
                XmlElement px = xd.CreateElement("pointx");
                px.InnerText = "1";
                nName.AppendChild(px);

                XmlElement py = xd.CreateElement("pointy");
                py.InnerText = picName;
                nName.AppendChild(py);

                XmlElement pz = xd.CreateElement("danhao");
                pz.InnerText = "8888888";
                nName.AppendChild(pz);

                XmlElement pku = xd.CreateElement("Kuang");
                pku.InnerText = kuang;
                nName.AppendChild(pku);

                XmlElement pgao = xd.CreateElement("Gao");
                pgao.InnerText = gao;
                nName.AppendChild(pgao);

                XmlElement pl = xd.CreateElement("Pleft");
                pl.InnerText = Pleft;
                nName.AppendChild(pl);

                XmlElement pr = xd.CreateElement("Pright");
                pr.InnerText = Pright;
                nName.AppendChild(pr);

                XmlElement bf = xd.CreateElement("BigFont");
                bf.InnerText = BigFont;
                nName.AppendChild(bf);

                XmlElement bw = xd.CreateElement("Bigwidth");
                bw.InnerText = Bigwidth;
                nName.AppendChild(bw);

                xd.Save(Kdpach + @"combox.dat");
            }
            catch { }
            finally{}
        }

        //快递单节点修改combox节点,默认快递单,当前单号,修改单号
        public void KuiDiDefault(string Kname, int jiedian,string danhao)
        {
            XmlDocument xdc = new XmlDocument();
            xdc.Load(Kdpach + @"combox.dat");
            XmlNode xn = xdc.SelectSingleNode("combox");
            XmlNodeList xnl = xn.ChildNodes;
            foreach (XmlNode LableNode in xn)
            {
                switch (jiedian)
                {
                    case 0:
                        {
                            if (LableNode.ChildNodes[jiedian].InnerText == "0")
                            {
                                LableNode.ChildNodes[jiedian].InnerText = "1";
                            }

                            if (LableNode.Attributes["Name"].InnerText == Kname)
                            {
                                LableNode.ChildNodes[jiedian].InnerText = "0";
                            }
                            //LableNode.Attributes["Name"].InnerXml = "申通";
                            xdc.Save(Kdpach + "combox.dat");
                            break;
                        }
                    case 2:
                        {
                            if (int.Parse( LableNode.ChildNodes[jiedian].InnerText)>0)
                            {
                                int x = int.Parse(LableNode.ChildNodes[jiedian].InnerText) + 1;
                                LableNode.ChildNodes[jiedian].InnerText = x.ToString() ;
                            }
                            xdc.Save(Kdpach + "combox.dat");
                            break;
                        }
                        //快递单号读取
                    case 33:
                        {
                            if (Kname == LableNode.Attributes["Name"].InnerText)
                            {
                                Form1.f1.KuiDiDanghaoRead(LableNode.ChildNodes[2].InnerText);
                            }
                            break;
                        }
                    //快递单号修改
                    case 44:
                        {
                            if (Kname == LableNode.Attributes["Name"].InnerText)
                            {
                                LableNode.ChildNodes[2].InnerText = danhao;
                                xdc.Save(Kdpach + "combox.dat");
                            }
                            break;
                        }
                       
                }
            }
        }
        //快递单重命名combox修改
        public void ReKuiDi(string Nname,string Oname)
        {
            if (Oname == "" || Nname == Oname)
                return;
            try 
            {
                try
                {
                    //文件重命名
                    File.Move(Kdpach + Oname + ".dat", Kdpach + Nname + ".dat");
                }
                catch { }
                finally { }
                //combox内容更新
                XmlDocument xd = new XmlDocument();
                xd.Load(Kdpach + @"combox.dat");
                XmlNode xn = xd.SelectSingleNode("combox");
                XmlNodeList xnl = xn.ChildNodes;
                foreach (XmlNode LableNode in xn)
                {
                    if (LableNode.Attributes["Name"].InnerXml == Oname)
                    {
                        LableNode.Attributes["Name"].InnerXml = Nname;
                        xd.Save(Kdpach + @"combox.dat");
                        //快递单图片重命名 
                        //File.Move(@".\data\pic\"+Oname+LableNode.ChildNodes[1].InnerText,@".\data\pic\"+Nname+LableNode.ChildNodes[1].InnerText);
                    }
                }
                //MessageBox.Show("OK");
            }
            catch 
            {
                MessageBox.Show("更改失败,请输入正确的文件名");
            }
            finally { }
        }
        //发件人信息的存取 创建xmltxt.dat
        public void MTextSave(XmlDocument xd, string name, string txt)
        {
                XmlNode sroot = xd.SelectSingleNode("Kset");
                //Textbox节点
                XmlElement nName = xd.CreateElement("txetbox");
                nName.SetAttribute("Name", name);
                nName.InnerText = txt;
                sroot.AppendChild(nName);
                xd.Save(Kdpach + @"XMLtxt.dat");
        }

        //查找快递单名字是否已经存在combox.dat
        public bool ReCombox(string Kname)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(Kdpach + @"combox.dat");
            XmlNode xn = xd.SelectSingleNode("combox");
            XmlNodeList xnl = xn.ChildNodes;
            foreach (XmlNode LableNode in xn)
            {
                if (LableNode.Attributes["Name"].InnerXml == Kname)
                {
                    return true;
                }
            }
            return false;
        }

        //加载快递单图片
        public void KuiDiPicLode(string Kname)
        {
            //左右偏移量
            float lp = 0, rp = 0;
            //大字字号 字宽
            int bFont = 35;
            float wFont = 320;
            XmlDocument xd = new XmlDocument();
            xd.Load(Kdpach + @"combox.dat");
            XmlNode xn = xd.SelectSingleNode("combox");
            XmlNodeList xnl = xn.ChildNodes;
            foreach (XmlNode LableNode in xn)
            {
                if (LableNode.Attributes["Name"].InnerXml == Kname)
                {
                    string kname1 = LableNode.ChildNodes[1].InnerText;
                    int kuan1 =(int)float.Parse(LableNode.ChildNodes[3].InnerText) * 1000 / 254;
                    int gao1 = (int)float.Parse(LableNode.ChildNodes[4].InnerText) * 1000 / 254; 
                    try
                    {
                        lp = float.Parse(LableNode.ChildNodes[5].InnerText) * 1000 / 254;
                        rp = float.Parse(LableNode.ChildNodes[6].InnerText) * 1000 / 254;
                        bFont = int.Parse(LableNode.ChildNodes[7].InnerText);
                        wFont = float.Parse(LableNode.ChildNodes[8].InnerText) * 1000 / 254;
                    }
                    catch { }
                    Form1.f1.PicLoad(kname1,kuan1,gao1,lp,rp,bFont,wFont);
                }
            }
        }

        //大字转图片
        public Bitmap TextBitmap(string text,int bFont,int wFont)
        {
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            Font font = new System.Drawing.Font("宋体", bFont, FontStyle.Bold);
            Bitmap bmp = new Bitmap(wFont, font.Height);
            Graphics g = Graphics.FromImage(bmp);
            SizeF sizef = g.MeasureString(text, font);
            int width = (int)(sizef.Width + 1);
            int height = (int)(sizef.Height + 1);
            Rectangle rect = new Rectangle(0, 0, width, height);
            bmp.Dispose();
            bmp = new Bitmap(width, height); g = Graphics.FromImage(bmp);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 0, 0)), rect);
            g.DrawString(text, font, Brushes.Black, rect, format);
            bmp.SetResolution(1200, 1200);
            return bmp;
        }
    }
}
