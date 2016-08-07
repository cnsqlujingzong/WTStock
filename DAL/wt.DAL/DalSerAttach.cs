using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DalSerAttach
	{
		public int GetMaxId()
		{
			return DbHelperSQL.GetMaxID("ID", "SerAttach");
		}

		public bool Exists(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select count(1) from SerAttach");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			return DbHelperSQL.Exists(stringBuilder.ToString(), array);
		}

		public int Add(SerAttachInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into SerAttach(");
			stringBuilder.Append("BillID,iType,FilePath,FileName,Remark)");
			stringBuilder.Append(" values (");
			stringBuilder.Append("@BillID,@iType,@FilePath,@FileName,@Remark)");
			stringBuilder.Append(";select @@IDENTITY");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@BillID", SqlDbType.Int, 4),
				new SqlParameter("@iType", SqlDbType.Int, 4),
				new SqlParameter("@FilePath", SqlDbType.VarChar, 500),
				new SqlParameter("@FileName", SqlDbType.VarChar, 200),
				new SqlParameter("@Remark", SqlDbType.VarChar, 500)
			};
			array[0].Value = model.BillID;
			array[1].Value = model.iType;
			array[2].Value = model.FilePath;
			array[3].Value = model.FileName;
			array[4].Value = model.Remark;
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

		public bool Update(SerAttachInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update SerAttach set ");
			stringBuilder.Append("BillID=@BillID,");
			stringBuilder.Append("iType=@iType,");
			stringBuilder.Append("FilePath=@FilePath,");
			stringBuilder.Append("FileName=@FileName,");
			stringBuilder.Append("Remark=@Remark");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@BillID", SqlDbType.Int, 4),
				new SqlParameter("@iType", SqlDbType.Int, 4),
				new SqlParameter("@FilePath", SqlDbType.VarChar, 500),
				new SqlParameter("@FileName", SqlDbType.VarChar, 200),
				new SqlParameter("@Remark", SqlDbType.VarChar, 500)
			};
			array[0].Value = model.ID;
			array[1].Value = model.BillID;
			array[2].Value = model.iType;
			array[3].Value = model.FilePath;
			array[4].Value = model.FileName;
			array[5].Value = model.Remark;
			int num = DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
			return num > 0;
		}

		public bool Delete(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("delete from SerAttach ");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			int num = DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
			return num > 0;
		}

		public bool DeleteList(string IDlist)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("delete from SerAttach ");
			stringBuilder.Append(" where ID in (" + IDlist + ")  ");
			int num = DbHelperSQL.ExecuteSql(stringBuilder.ToString());
			return num > 0;
		}

		public SerAttachInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,BillID,iType,FilePath,FileName,Remark from SerAttach ");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			SerAttachInfo serAttachInfo = new SerAttachInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			SerAttachInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					serAttachInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["BillID"].ToString() != "")
				{
					serAttachInfo.BillID = int.Parse(dataSet.Tables[0].Rows[0]["BillID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["iType"].ToString() != "")
				{
					serAttachInfo.iType = int.Parse(dataSet.Tables[0].Rows[0]["iType"].ToString());
				}
				serAttachInfo.FilePath = dataSet.Tables[0].Rows[0]["FilePath"].ToString();
				serAttachInfo.FileName = dataSet.Tables[0].Rows[0]["FileName"].ToString();
				serAttachInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				result = serAttachInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public DataSet GetList(string strWhere)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select ID,BillID,iType,FilePath,FileName,Remark ");
			stringBuilder.Append(" FROM SerAttach ");
			if (strWhere.Trim() != "")
			{
				stringBuilder.Append(" where " + strWhere);
			}
			return DbHelperSQL.Query(stringBuilder.ToString());
		}

		public DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select ");
			if (Top > 0)
			{
				stringBuilder.Append(" top " + Top.ToString());
			}
			stringBuilder.Append(" ID,BillID,iType,FilePath,FileName,Remark ");
			stringBuilder.Append(" FROM SerAttach ");
			if (strWhere.Trim() != "")
			{
				stringBuilder.Append(" where " + strWhere);
			}
			stringBuilder.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(stringBuilder.ToString());
		}

		public void DelAttach(int billid, string types)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(string.Format("delete from serattach where billid=@billid and itype in({0})", types));
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@billid", SqlDbType.Int, 4)
			};
			array[0].Value = billid;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public int GetIDbyBillid(int bid)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select top 1 ID from ServicesProcess where BillID=@BillID order by ID desc");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@BillID", SqlDbType.Int, 4)
			};
			array[0].Value = bid;
			object single = DbHelperSQL.GetSingle(stringBuilder.ToString(), array);
			int result;
			if (single == null)
			{
				result = 0;
			}
			else
			{
				result = Convert.ToInt32(single);
			}
			return result;
		}
	}
}
