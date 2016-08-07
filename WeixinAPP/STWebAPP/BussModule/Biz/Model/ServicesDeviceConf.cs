using System;
namespace BussModule.Biz.Model
{
	/// <summary>
	/// ServicesDeviceConf:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ServicesDeviceConf
	{
		public ServicesDeviceConf()
		{}
		#region Model
		private int _id;
		private int _billid;
		private string __name="";
		private string _parameter="";
		private string _sn="";
		private string _maintenanceperiod="";
		private string _buydate="";
		private string _maintenanceend="";
		private string _remark="";
		private int? _devconfid;
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
		public int BillID
		{
			set{ _billid=value;}
			get{return _billid;}
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
		public string Parameter
		{
			set{ _parameter=value;}
			get{return _parameter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SN
		{
			set{ _sn=value;}
			get{return _sn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MaintenancePeriod
		{
			set{ _maintenanceperiod=value;}
			get{return _maintenanceperiod;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BuyDate
		{
			set{ _buydate=value;}
			get{return _buydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MaintenanceEnd
		{
			set{ _maintenanceend=value;}
			get{return _maintenanceend;}
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
		public int? DevConfID
		{
			set{ _devconfid=value;}
			get{return _devconfid;}
		}
		#endregion Model

	}
}

