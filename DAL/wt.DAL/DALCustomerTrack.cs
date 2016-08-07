using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALCustomerTrack
	{
		public int Add(CustomerTrackInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into CustomerTrack(");
			stringBuilder.Append("_Date,OperatorID,CustomerID,LinkMan,Tel,TrackStyleID,TrackTypeID,Content,Result,NextTrack,bTrack)");
			stringBuilder.Append(" values (");
			stringBuilder.Append("@_Date,@OperatorID,@CustomerID,@LinkMan,@Tel,@TrackStyleID,@TrackTypeID,@Content,@Result,@NextTrack,@bTrack)");
			stringBuilder.Append(";select @@IDENTITY");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@_Date", SqlDbType.DateTime),
				new SqlParameter("@OperatorID", SqlDbType.Int, 4),
				new SqlParameter("@CustomerID", SqlDbType.Int, 4),
				new SqlParameter("@LinkMan", SqlDbType.VarChar, 50),
				new SqlParameter("@Tel", SqlDbType.VarChar, 50),
				new SqlParameter("@TrackStyleID", SqlDbType.Int, 4),
				new SqlParameter("@TrackTypeID", SqlDbType.Int, 4),
				new SqlParameter("@Content", SqlDbType.VarChar, 500),
				new SqlParameter("@Result", SqlDbType.VarChar, 500),
				new SqlParameter("@NextTrack", SqlDbType.DateTime),
				new SqlParameter("@bTrack", SqlDbType.Bit, 1)
			};
			array[0].Value = model._Date;
			array[1].Value = model.OperatorID;
			array[2].Value = model.CustomerID;
			array[3].Value = model.LinkMan;
			array[4].Value = model.Tel;
			array[5].Value = model.TrackStyleID;
			array[6].Value = model.TrackTypeID;
			array[7].Value = model.Content;
			array[8].Value = model.Result;
			array[9].Value = ((model.NextTrack == "") ? "" : model.NextTrack);
			array[10].Value = model.bTrack;
			object single = DbHelperSQL.GetSingle(stringBuilder.ToString(), array);
			int result;
			if (single == null)
			{
				result = 1;
			}
			else
			{
				result = Convert.ToInt32(single);
			}
			return result;
		}

		public void Update(CustomerTrackInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update CustomerTrack set ");
			stringBuilder.Append("_Date=@_Date,");
			stringBuilder.Append("OperatorID=@OperatorID,");
			stringBuilder.Append("LinkMan=@LinkMan,");
			stringBuilder.Append("Tel=@Tel,");
			stringBuilder.Append("TrackStyleID=@TrackStyleID,");
			stringBuilder.Append("TrackTypeID=@TrackTypeID,");
			stringBuilder.Append("Content=@Content,");
			stringBuilder.Append("Result=@Result,");
			stringBuilder.Append("NextTrack=@NextTrack,");
			stringBuilder.Append("bTrack=@bTrack");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@_Date", SqlDbType.DateTime),
				new SqlParameter("@OperatorID", SqlDbType.Int, 4),
				new SqlParameter("@LinkMan", SqlDbType.VarChar, 50),
				new SqlParameter("@Tel", SqlDbType.VarChar, 50),
				new SqlParameter("@TrackStyleID", SqlDbType.Int, 4),
				new SqlParameter("@TrackTypeID", SqlDbType.Int, 4),
				new SqlParameter("@Content", SqlDbType.VarChar, 500),
				new SqlParameter("@Result", SqlDbType.VarChar, 500),
				new SqlParameter("@NextTrack", SqlDbType.DateTime),
				new SqlParameter("@bTrack", SqlDbType.Bit)
			};
			array[0].Value = model.ID;
			array[1].Value = model._Date;
			array[2].Value = model.OperatorID;
			array[3].Value = model.LinkMan;
			array[4].Value = model.Tel;
			array[5].Value = model.TrackStyleID;
			array[6].Value = model.TrackTypeID;
			array[7].Value = model.Content;
			array[8].Value = model.Result;
			array[9].Value = ((model.NextTrack == "") ? "" : model.NextTrack);
			array[10].Value = model.bTrack;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}
	}
}
