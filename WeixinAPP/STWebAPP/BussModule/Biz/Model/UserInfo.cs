using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussModule.Biz.Model
{
    public class UserInfo
    {
        public int ID { get; set; }
        public int DeptID { get; set; }
        public string _Name { get; set; }
        public string Specialty { get; set; }
        public string School { get; set; }//代用经理
    }
}
