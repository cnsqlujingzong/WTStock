using System;
namespace Coding.Stock.Model
{
    /// <summary>
    /// Cd_ImgStock:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class WTLog
    {
        public WTLog()
        { }
        #region Model
        public int ID { get; set; }
        public string source{get;set;}
          public string person{get;set;}
          public string personID{get;set;}
          public string BillID{get;set;}
          public string decribe{get;set;}
          public string common{get;set;}
          public DateTime logtime { get; set; }
          public string Att1{get;set;}
          public string Att2{get;set;}
          public DateTime Dtime{get;set;}
          public DateTime Dtime2 { get; set; }
          public string opt { get; set; }




        #endregion Model

    }
}

