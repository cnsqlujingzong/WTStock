using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussModule.Biz.Model
{
 public   class Cd_ImgStock
    {
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
