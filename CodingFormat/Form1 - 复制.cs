using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace CodingFormat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      
/// <summary>
      /// 移动文件
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(@"F:\WTStock\wt-web\CodeSource");
            string basepath = @"F:\WTStock\wt-web";//basepath
           // string[] delfile = Directory.GetFiles(@"F:\WTStock\wt-web","*.cs", SearchOption.AllDirectories);
            //foreach (var item in delfile)
            //{
            //    File.Delete(item);
            //}
            foreach (string item in files)
            {
                string name = item.Substring(item.LastIndexOf("\\") + 1);//old name
                string extname = item.Substring(item.LastIndexOf("."));   //old ext
                if (extname == ".cs" && name.LastIndexOf("_") >= 0)
                {
                    string[] names = name.Split('_');
                    string realpath="";
                    string newpath = "";
                    foreach (string s in names)
                    {
                        newpath += "\\"+ s ;
                    }
                  //  realpath = realpath.Substring(0,realpath.LastIndexOf("\\"));
                    realpath = basepath + newpath.Replace(".cs",".aspx.cs");
                    if (string.IsNullOrEmpty(realpath))
                    {
                        continue;
                    }
                    else
                    {
                        if (File.Exists(realpath))
                        {
                            continue;
                        }
                        else
                        {
                            try
                            {
                               // File.Move(item, realpath);
                                File.Copy(item, realpath,true);
                            }
                            catch {
                                continue;
                            }
                        }
                    }
                }
                
            }
            MessageBox.Show("完成！");
        }
        /// <summary>
        /// 改写codingfile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click_1(object sender, EventArgs e)
        {

           // string[] files = Directory.GetFiles(@"E:\workspace\st\WTStock\wt-web\Branch\Basic2");
            string[] files = Directory.GetFiles(@"E:\workspace\st\WTStock\wt-web","*.aspx",SearchOption.AllDirectories);
         
            foreach (string item in files)
            {
                string extname = item.Substring(item.LastIndexOf("."));   //old ext         
                string allname = item.Substring(item.LastIndexOf("\\") + 1);//old name
                string name = allname.Substring(0,allname.LastIndexOf("."));
                if (extname.ToLower() == ".aspx")
                {
                    FileStream fs = File.Open(item,FileMode.Open,FileAccess.ReadWrite);
                    StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("utf-8"));
                    string line = sr.ReadLine();
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; line != null; i++)
                    {
                        if (i == 0)
                        {
                            sb.Append(line.Replace("language=\"C#\"", "language=\"C#\"  CodeBehind=\"" + name + ".aspx.cs\"    ") + "\r\n");
                        }
                        else {
                            sb.Append(line + "\r\n");
                        }
                        line = sr.ReadLine();
                    }
                    sr.Close();
                    fs.Close();
                    FileStream fs1 = new FileStream(item, FileMode.Open, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs1);
                    sw.Write(sb.ToString());
                    sw.Close();
                    fs.Close();
                }
            }

            MessageBox.Show("完成");
        }

      
    }
}
