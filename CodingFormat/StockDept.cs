using System;
namespace BussModule.Biz.Model
{
	/// <summary>
	/// StockDept:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class StockDept
	{
		public StockDept()
		{}
		#region Model
		private int _id;
		private int _deptid;
		private int _stockid;
		private int _goodsid;
		private int? _stocklocid;
		private decimal _stock=0M;
		private decimal _costprice=0M;
		private decimal _upwarning=0M;
		private decimal _downwarning=0M;
		private string _checkcount="";
		private string _remark="";
		private decimal _beginstock=0M;
		private decimal _begincost=0M;
		private int _beginstatus=0;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DeptID
		{
			set{ _deptid=value;}
			get{return _deptid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int StockID
		{
			set{ _stockid=value;}
			get{return _stockid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int GoodsID
		{
			set{ _goodsid=value;}
			get{return _goodsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? StockLocID
		{
			set{ _stocklocid=value;}
			get{return _stocklocid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Stock
		{
			set{ _stock=value;}
			get{return _stock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal CostPrice
		{
			set{ _costprice=value;}
			get{return _costprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal upWarning
		{
			set{ _upwarning=value;}
			get{return _upwarning;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal downWarning
		{
			set{ _downwarning=value;}
			get{return _downwarning;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CheckCount
		{
			set{ _checkcount=value;}
			get{return _checkcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal BeginStock
		{
			set{ _beginstock=value;}
			get{return _beginstock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal BeginCost
		{
			set{ _begincost=value;}
			get{return _begincost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int BeginStatus
		{
			set{ _beginstatus=value;}
			get{return _beginstatus;}
		}
		#endregion Model

	}
}

