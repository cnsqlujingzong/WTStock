using System;
using System.Collections.Generic;

namespace wt.Model
{
	public class TroubleListInfo
	{
		private int _id;

		private int? _productclassid;

		private int? _repairclassid;

		private int? _troubleclassid;

		private string _troubleclass;

		private string _troubleno;

		private string _summary;

		private decimal _score;

		private List<TakeStepsInfo> _takestepsinfos;

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

		public int? ProductClassID
		{
			get
			{
				return this._productclassid;
			}
			set
			{
				this._productclassid = value;
			}
		}

		public int? RepairClassID
		{
			get
			{
				return this._repairclassid;
			}
			set
			{
				this._repairclassid = value;
			}
		}

		public decimal Score
		{
			get
			{
				return this._score;
			}
			set
			{
				this._score = value;
			}
		}

		public string Summary
		{
			get
			{
				return this._summary;
			}
			set
			{
				this._summary = value;
			}
		}

		public List<TakeStepsInfo> TakeStepsInfos
		{
			get
			{
				return this._takestepsinfos;
			}
			set
			{
				this._takestepsinfos = value;
			}
		}

		public string TroubleClass
		{
			get
			{
				return this._troubleclass;
			}
			set
			{
				this._troubleclass = value;
			}
		}

		public int? TroubleClassID
		{
			get
			{
				return this._troubleclassid;
			}
			set
			{
				this._troubleclassid = value;
			}
		}

		public string TroubleNO
		{
			get
			{
				return this._troubleno;
			}
			set
			{
				this._troubleno = value;
			}
		}

		public TroubleListInfo()
		{
		}
	}
}