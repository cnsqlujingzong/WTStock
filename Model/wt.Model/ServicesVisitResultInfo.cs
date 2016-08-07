using System;

namespace wt.Model
{
	public class ServicesVisitResultInfo
	{
		private int _id;

		private int _visitresultid;

		private int _visitid;

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

		public int VisitID
		{
			get
			{
				return this._visitid;
			}
			set
			{
				this._visitid = value;
			}
		}

		public int VisitResultID
		{
			get
			{
				return this._visitresultid;
			}
			set
			{
				this._visitresultid = value;
			}
		}

		public ServicesVisitResultInfo()
		{
		}
	}
}