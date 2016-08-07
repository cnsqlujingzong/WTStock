using BussModule.Biz.DAL;
using BussModule.Biz.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodingFormat
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GoodsDAL gooddal = new GoodsDAL();
            StockDeptDAL dal = new StockDeptDAL();
            DataTable gdt=gooddal.GetList("").Tables[0];
            foreach (DataRow item in gdt.Rows)
            {
               bool r= dal.Exists(int.Parse(item["ID"].ToString()));
               if (r)
               {
                   continue;
               }
               else 
               {
                   StockDept m = new StockDept();
                   m.ID = dal.GetMaxId()+1;
                   m.DeptID = 1;
                   m.StockID =Convert.ToInt32(item["StockID"]);
                   m.GoodsID=int.Parse(item["ID"].ToString());
                   dal.Add(m);
               }
            }

            MessageBox.Show("OK");
           
        }
    }
}
