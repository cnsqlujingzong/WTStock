using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BussModule.Biz.Model
{
    public class Task
    {
        public int ID { get; set; }
        public int DeptID { get; set; }
        public DateTime _Date { get; set; }
        public int OperatorID { get; set; }
        public DateTime ExeDate { get; set; }
        public int ExerID { get; set; }
        public string Status { get; set; }
        public string Summary { get; set; }
        public string CompleteRate { get; set; }
        public string TaskRemark { get; set; }
        public string executeRemark { get; set; }
        public int Score { get; set; }
        public string Remark { get; set; }
    }
}