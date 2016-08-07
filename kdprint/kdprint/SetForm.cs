using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace kdprint
{
    class SetForm
    {
        //快递单界面变量
        static string Kdpach = Application.StartupPath + @"\data\";
        public SetForm(string kdpach)
        {
            Kdpach = kdpach;
        }
        //public SetForm()
        //{ }
        //初始化xml文档操作类
        XmlWork xw = new XmlWork(Kdpach);
        DressOut dro = new DressOut();

        //加载文本框位置
        public List<string[]> KDDinit(string KuidiName)
        {
            List<string[]> lst = new List<string[]>();
            if (KuidiName != "")
            {
                try
                {
                    //加载图片
                    xw.KuiDiPicLode(KuidiName);

                   // string lname, lpointx, lpointy;
                    //使用XML中数据加载控件坐标
                    XmlDocument xd = new XmlDocument();
                    xd.Load(Kdpach + KuidiName + ".dat");
                    XmlNode xn = xd.SelectSingleNode("Kset");
                    XmlNodeList xnl = xn.ChildNodes;
                    foreach (XmlNode LableNode in xn)
                    {
                        string[] st = new string[4];
                        st[0] = LableNode.Attributes["Name"].InnerText;
                        st[1] = LableNode.ChildNodes[0].InnerText;
                        st[2] = LableNode.ChildNodes[1].InnerText;
                        try
                        {
                            st[3] = LableNode.ChildNodes[2].InnerText;
                        }
                        catch { }
                        lst.Add(st);
                    }
                }
                catch
                {
                    //TextBoxDress(KuidiName);
                    //MessageBox.Show("图片加载错误");
                }
                finally
                {
                    //				MessageBox.Show("OK");
                }
            }
            return lst;
        }
    }
}
