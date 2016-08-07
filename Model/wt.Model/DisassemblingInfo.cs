using System;
using System.Collections.Generic;

namespace wt.Model
{
	public class DisassemblingInfo
	{
		private int _id;

		private int _chkoperatorid;

		private int _stockid;

		private int _goodsid;

		private int _unitid;

		private decimal _qty;

		private decimal _price;

		private string _remark;

		private string _billid;

		private int _deptid;

		private string __date;

		private int _operatorid;

		private int _personid;

		private int _type;

		private int _status;

		private DateTime _chkdate;

		private string _sstatus;

		private string _btype;

		private string _goodsno;

		private string __name;

		private string _spec;

		private string _brand;

		private string _sn;

		private bool _bstockout;

		private List<DisassemblingDetailInfo> _disassemblingdetailinfos;

		public string _Date
		{
			get
			{
				return this.__date;
			}
			set
			{
				this.__date = value;
			}
		}

		public string _Name
		{
			get
			{
				return this.__name;
			}
			set
			{
				this.__name = value;
			}
		}

		public string BillID
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

		public string Brand
		{
			get
			{
				return this._brand;
			}
			set
			{
				this._brand = value;
			}
		}

		public bool bStockOut
		{
			get
			{
				return this._bstockout;
			}
			set
			{
				this._bstockout = value;
			}
		}

		public string bType
		{
			get
			{
				return this._btype;
			}
			set
			{
				this._btype = value;
			}
		}

		public DateTime ChkDate
		{
			get
			{
				return this._chkdate;
			}
			set
			{
				this._chkdate = value;
			}
		}

		public int ChkOperatorID
		{
			get
			{
				return this._chkoperatorid;
			}
			set
			{
				this._chkoperatorid = value;
			}
		}

		public int DeptID
		{
			get
			{
				return this._deptid;
			}
			set
			{
				this._deptid = value;
			}
		}

		public List<DisassemblingDetailInfo> DisassemblingDetailInfos
		{
			get
			{
				return this._disassemblingdetailinfos;
			}
			set
			{
				this._disassemblingdetailinfos = value;
			}
		}

		public int GoodsID
		{
			get
			{
				return this._goodsid;
			}
			set
			{
				this._goodsid = value;
			}
		}

		public string GoodsNO
		{
			get
			{
				return this._goodsno;
			}
			set
			{
				this._goodsno = value;
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

		public int OperatorID
		{
			get
			{
				return this._operatorid;
			}
			set
			{
				this._operatorid = value;
			}
		}

		public int PersonID
		{
			get
			{
				return this._personid;
			}
			set
			{
				this._personid = value;
			}
		}

		public decimal Price
		{
			get
			{
				return this._price;
			}
			set
			{
				this._price = value;
			}
		}

		public decimal Qty
		{
			get
			{
				return this._qty;
			}
			set
			{
				this._qty = value;
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

		public string SN
		{
			get
			{
				return this._sn;
			}
			set
			{
				this._sn = value;
			}
		}

		public string Spec
		{
			get
			{
				return this._spec;
			}
			set
			{
				this._spec = value;
			}
		}

		public string sStatus
		{
			get
			{
				return this._sstatus;
			}
			set
			{
				this._sstatus = value;
			}
		}

		public int Status
		{
			get
			{
				return this._status;
			}
			set
			{
				this._status = value;
			}
		}

		public int StockID
		{
			get
			{
				return this._stockid;
			}
			set
			{
				this._stockid = value;
			}
		}

		public int Type
		{
			get
			{
				return this._type;
			}
			set
			{
				this._type = value;
			}
		}

		public int UnitID
		{
			get
			{
				return this._unitid;
			}
			set
			{
				this._unitid = value;
			}
		}

		public DisassemblingInfo()
		{
		}
	}
}