using System;

namespace wt.Model
{
	[Serializable]
	public class NOPlanInfo
	{
		private int _id;

		private string _type;

		private string _code;

		private string _style;

		private string _tally;

		private string _beginno;

		private string _model;

		public string BeginNO
		{
			get
			{
				return this._beginno;
			}
			set
			{
				this._beginno = value;
			}
		}

		public string Code
		{
			get
			{
				return this._code;
			}
			set
			{
				this._code = value;
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

		public string Model
		{
			get
			{
				return this._model;
			}
			set
			{
				this._model = value;
			}
		}

		public string Style
		{
			get
			{
				return this._style;
			}
			set
			{
				this._style = value;
			}
		}

		public string Tally
		{
			get
			{
				return this._tally;
			}
			set
			{
				this._tally = value;
			}
		}

		public string Type
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

		public NOPlanInfo()
		{
		}
	}
}