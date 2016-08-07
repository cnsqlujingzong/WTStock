using System;
namespace Coding.Stock.Model
{
    /// <summary>
    /// Cd_ImgStock:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Cd_ImgStock
    {
        public Cd_ImgStock()
        { }
        #region Model
        private int _id;
        private string _flagname;
        private string _imgtype;
        private string _imgname;
        private string _imgsrc;
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
        public string FlagName
        {
            set { _flagname = value; }
            get { return _flagname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImgType
        {
            set { _imgtype = value; }
            get { return _imgtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImgName
        {
            set { _imgname = value; }
            get { return _imgname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImgSrc
        {
            set { _imgsrc = value; }
            get { return _imgsrc; }
        }
        #endregion Model

    }
}

