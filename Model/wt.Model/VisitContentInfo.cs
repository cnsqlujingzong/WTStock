using System;
using System.Collections.Generic;

namespace wt.Model
{
	public class VisitContentInfo
	{
		private int _id;

		private string _content;

		private string _remark;

		private bool _bstop;

		private List<VisitResultInfo> _visitresultinfos;

		public bool bStop
		{
			get
			{
				return this._bstop;
			}
			set
			{
				this._bstop = value;
			}
		}

		public string Content
		{
			get
			{
				return this._content;
			}
			set
			{
				this._content = value;
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

		public List<VisitResultInfo> VisitResultInfos
		{
			get
			{
				return this._visitresultinfos;
			}
			set
			{
				this._visitresultinfos = value;
			}
		}

		public VisitContentInfo()
		{
		}
	}
}