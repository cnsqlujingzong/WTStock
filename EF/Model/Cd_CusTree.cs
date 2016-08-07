using System;
namespace Coding.Stock.Model
{
    /// <summary>
    /// Cd_ImgStock:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Cd_CusTree
    {
        public Cd_CusTree()
        { }
        #region Model
        private int _id;
        private int _cusid;
        private int _pid;
        private string _pjob;
        private string _pname;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CusID
        {
            set { _cusid = value; }
            get { return _cusid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Pid
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PJob
        {
            set { _pjob = value; }
            get { return _pjob; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PName
        {
            set { _pname = value; }
            get { return _pname; }
        }
        #endregion Model

    }
}

