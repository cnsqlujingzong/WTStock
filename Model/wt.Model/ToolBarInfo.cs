using System;

namespace wt.Model
{
	public class ToolBarInfo
	{
		private int _id;

		private int _deptid;

		private int _ioperator;

		private string _fieldvalue;

		private string _fieldtext;

		private string _command;

		private int _array;

		public int Array
		{
			get
			{
				return this._array;
			}
			set
			{
				this._array = value;
			}
		}

		public string Command
		{
			get
			{
				return this._command;
			}
			set
			{
				this._command = value;
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

		public string FieldText
		{
			get
			{
				return this._fieldtext;
			}
			set
			{
				this._fieldtext = value;
			}
		}

		public string FieldValue
		{
			get
			{
				return this._fieldvalue;
			}
			set
			{
				this._fieldvalue = value;
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

		public int iOperator
		{
			get
			{
				return this._ioperator;
			}
			set
			{
				this._ioperator = value;
			}
		}

		public ToolBarInfo()
		{
		}
	}
}