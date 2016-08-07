using System;

namespace wt.Model
{
	[Serializable]
	public class SerAttachInfo
	{
		private int _id;

		private int _billid;

		private int _itype;

		private string _filepath;

		private string _filename;

		private string _remark;

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

		public string FileName
		{
			get
			{
				return this._filename;
			}
			set
			{
				this._filename = value;
			}
		}

		public string FilePath
		{
			get
			{
				return this._filepath;
			}
			set
			{
				this._filepath = value;
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

		public int iType
		{
			get
			{
				return this._itype;
			}
			set
			{
				this._itype = value;
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

		public SerAttachInfo()
		{
		}
	}
}