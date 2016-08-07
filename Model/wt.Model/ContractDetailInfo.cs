using System;

namespace wt.Model
{
	public class ContractDetailInfo
	{
		private int _id;

		private int _billid;

		private string _productsn;

		private int _deviceid;

		private bool _brepair;

		private bool _bconsumables;

		private bool _bmaterial;

		private int _servicelevelid;

		private string _remark;

		private string _deviceno;

		public bool bConsumables
		{
			get
			{
				return this._bconsumables;
			}
			set
			{
				this._bconsumables = value;
			}
		}

		public int BillID
		{
			get
			{
				return this._billid;
			}
			set
			{
				this._billid = value;
			}
		}

		public bool bMaterial
		{
			get
			{
				return this._bmaterial;
			}
			set
			{
				this._bmaterial = value;
			}
		}

		public bool bRepair
		{
			get
			{
				return this._brepair;
			}
			set
			{
				this._brepair = value;
			}
		}

		public int DeviceID
		{
			get
			{
				return this._deviceid;
			}
			set
			{
				this._deviceid = value;
			}
		}

		public string DeviceNO
		{
			get
			{
				return this._deviceno;
			}
			set
			{
				this._deviceno = value;
			}
		}

		public int ID
		{
			get
			{
				return this._id;
			}
			set
			{
				this._id = value;
			}
		}

		public string ProductSN
		{
			get
			{
				return this._productsn;
			}
			set
			{
				this._productsn = value;
			}
		}

		public string Remark
		{
			get
			{
				return this._remark;
			}
			set
			{
				this._remark = value;
			}
		}

		public int ServiceLevelID
		{
			get
			{
				return this._servicelevelid;
			}
			set
			{
				this._servicelevelid = value;
			}
		}

		public ContractDetailInfo()
		{
		}
	}
}