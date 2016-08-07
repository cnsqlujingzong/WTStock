using System;
namespace BussModule.Biz.Model
{
	/// <summary>
	/// Goods:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Goods
	{
		public Goods()
		{}
		#region Model
		private int _id=0;
		private string _goodsno="";
		private string __name="";
		private int? _classid;
		private string _spec="";
		private int? _brandid;
		private string _picpath="";
		private string _forproducts="";
		private string _attr="";
		private string _maintenanceperiod="";
		private int? _stockid;
		private int? _provid;
		private bool _bstock= false;
		private int _costmode=1;
		private int? _valid=0;
		private bool _bincrement= false;
		private bool _bsntrack= false;
		private bool _bstop= false;
		private string _pycode="";
		private string _remark="";
		private string _userdef1="";
		private string _userdef2="";
		private string _userdef3="";
		private string _userdef4="";
		private string _userdef5="";
		private string _userdef6="";
		private string _pcb;
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
		public string GoodsNO
		{
			set{ _goodsno=value;}
			get{return _goodsno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string _Name
		{
			set{ __name=value;}
			get{return __name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ClassID
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Spec
		{
			set{ _spec=value;}
			get{return _spec;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BrandID
		{
			set{ _brandid=value;}
			get{return _brandid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PicPath
		{
			set{ _picpath=value;}
			get{return _picpath;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ForProducts
		{
			set{ _forproducts=value;}
			get{return _forproducts;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Attr
		{
			set{ _attr=value;}
			get{return _attr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MainTenancePeriod
		{
			set{ _maintenanceperiod=value;}
			get{return _maintenanceperiod;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? StockID
		{
			set{ _stockid=value;}
			get{return _stockid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProvID
		{
			set{ _provid=value;}
			get{return _provid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bStock
		{
			set{ _bstock=value;}
			get{return _bstock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CostMode
		{
			set{ _costmode=value;}
			get{return _costmode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Valid
		{
			set{ _valid=value;}
			get{return _valid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bIncrement
		{
			set{ _bincrement=value;}
			get{return _bincrement;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bSNTrack
		{
			set{ _bsntrack=value;}
			get{return _bsntrack;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool bStop
		{
			set{ _bstop=value;}
			get{return _bstop;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pyCode
		{
			set{ _pycode=value;}
			get{return _pycode;}
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
		public string userdef1
		{
			set{ _userdef1=value;}
			get{return _userdef1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userdef2
		{
			set{ _userdef2=value;}
			get{return _userdef2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userdef3
		{
			set{ _userdef3=value;}
			get{return _userdef3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userdef4
		{
			set{ _userdef4=value;}
			get{return _userdef4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userdef5
		{
			set{ _userdef5=value;}
			get{return _userdef5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userdef6
		{
			set{ _userdef6=value;}
			get{return _userdef6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PCB
		{
			set{ _pcb=value;}
			get{return _pcb;}
		}
		#endregion Model

	}
}

