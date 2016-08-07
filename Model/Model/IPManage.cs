using System;

namespace Model
{
	internal class IPManage
	{
		private string iPStart;

		private string iPEnd;

		private string staffName;

		private int staffID;

		public string IPEnd
		{
			get
			{
				return this.iPEnd;
			}
			set
			{
				this.iPEnd = value;
			}
		}

		public string IPStart
		{
			get
			{
				return this.iPStart;
			}
			set
			{
				this.iPStart = value;
			}
		}

		public int StaffID
		{
			get
			{
				return this.staffID;
			}
			set
			{
				this.staffID = value;
			}
		}

		public string StaffName
		{
			get
			{
				return this.staffName;
			}
			set
			{
				this.staffName = value;
			}
		}

		public IPManage()
		{
		}
	}
}