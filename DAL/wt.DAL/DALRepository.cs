using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALRepository
	{
		public int Add(RepositoryInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("insert into Repository(");
			stringBuilder.Append("DeptID,ClassID,AuthorID,Title,_Date,Content,AccessLevel,bTechnician,bSeller,bStockMan,bDestClerk,bAccountant)");
			stringBuilder.Append(" values (");
			stringBuilder.Append("@DeptID,@ClassID,@AuthorID,@Title,@_Date,@Content,@AccessLevel,@bTechnician,@bSeller,@bStockMan,@bDestClerk,@bAccountant)");
			stringBuilder.Append(";select @@IDENTITY");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@DeptID", SqlDbType.Int, 4),
				new SqlParameter("@ClassID", SqlDbType.Int, 4),
				new SqlParameter("@AuthorID", SqlDbType.Int, 4),
				new SqlParameter("@Title", SqlDbType.VarChar, 200),
				new SqlParameter("@_Date", SqlDbType.DateTime),
				new SqlParameter("@Content", SqlDbType.Text),
				new SqlParameter("@AccessLevel", SqlDbType.Int, 4),
				new SqlParameter("@bTechnician", SqlDbType.Bit, 1),
				new SqlParameter("@bSeller", SqlDbType.Bit, 1),
				new SqlParameter("@bStockMan", SqlDbType.Bit, 1),
				new SqlParameter("@bDestClerk", SqlDbType.Bit, 1),
				new SqlParameter("@bAccountant", SqlDbType.Bit, 1)
			};
			array[0].Value = model.DeptID;
			if (model.ClassID > 0)
			{
				array[1].Value = model.ClassID;
			}
			else
			{
				array[1].Value = null;
			}
			if (model.AuthorID > 0)
			{
				array[2].Value = model.AuthorID;
			}
			else
			{
				array[2].Value = null;
			}
			array[3].Value = model.Title;
			array[4].Value = model._Date;
			array[5].Value = model.Content;
			array[6].Value = model.AccessLevel;
			array[7].Value = model.bTechnician;
			array[8].Value = model.bSeller;
			array[9].Value = model.bStockMan;
			array[10].Value = model.bDestClerk;
			array[11].Value = model.bAccountant;
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

		public void Update(RepositoryInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update Repository set ");
			stringBuilder.Append("ClassID=@ClassID,");
			stringBuilder.Append("Title=@Title,");
			stringBuilder.Append("Content=@Content,");
			stringBuilder.Append("AccessLevel=@AccessLevel,");
			stringBuilder.Append("bTechnician=@bTechnician,");
			stringBuilder.Append("bSeller=@bSeller,");
			stringBuilder.Append("bStockMan=@bStockMan,");
			stringBuilder.Append("bDestClerk=@bDestClerk,");
			stringBuilder.Append("bAccountant=@bAccountant");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@ClassID", SqlDbType.Int, 4),
				new SqlParameter("@Title", SqlDbType.VarChar, 200),
				new SqlParameter("@Content", SqlDbType.Text),
				new SqlParameter("@AccessLevel", SqlDbType.Int, 4),
				new SqlParameter("@bTechnician", SqlDbType.Bit, 1),
				new SqlParameter("@bSeller", SqlDbType.Bit, 1),
				new SqlParameter("@bStockMan", SqlDbType.Bit, 1),
				new SqlParameter("@bDestClerk", SqlDbType.Bit, 1),
				new SqlParameter("@bAccountant", SqlDbType.Bit, 1)
			};
			array[0].Value = model.ID;
			if (model.ClassID > 0)
			{
				array[1].Value = model.ClassID;
			}
			else
			{
				array[1].Value = null;
			}
			array[2].Value = model.Title;
			array[3].Value = model.Content;
			array[4].Value = model.AccessLevel;
			array[5].Value = model.bTechnician;
			array[6].Value = model.bSeller;
			array[7].Value = model.bStockMan;
			array[8].Value = model.bDestClerk;
			array[9].Value = model.bAccountant;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public RepositoryInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 ID,DeptID,ClassID,AuthorID,Title,_Date,Content,Hit,AccessLevel,bTechnician,bSeller,bStockMan,bDestClerk,bAccountant from Repository ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			RepositoryInfo repositoryInfo = new RepositoryInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			RepositoryInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					repositoryInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["DeptID"].ToString() != "")
				{
					repositoryInfo.DeptID = int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["ClassID"].ToString() != "")
				{
					repositoryInfo.ClassID = int.Parse(dataSet.Tables[0].Rows[0]["ClassID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["AuthorID"].ToString() != "")
				{
					repositoryInfo.AuthorID = int.Parse(dataSet.Tables[0].Rows[0]["AuthorID"].ToString());
				}
				repositoryInfo.Title = dataSet.Tables[0].Rows[0]["Title"].ToString();
				if (dataSet.Tables[0].Rows[0]["_Date"].ToString() != "")
				{
					repositoryInfo._Date = DateTime.Parse(dataSet.Tables[0].Rows[0]["_Date"].ToString());
				}
				repositoryInfo.Content = dataSet.Tables[0].Rows[0]["Content"].ToString();
				if (dataSet.Tables[0].Rows[0]["Hit"].ToString() != "")
				{
					repositoryInfo.Hit = int.Parse(dataSet.Tables[0].Rows[0]["Hit"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["AccessLevel"].ToString() != "")
				{
					repositoryInfo.AccessLevel = int.Parse(dataSet.Tables[0].Rows[0]["AccessLevel"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["bTechnician"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bTechnician"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bTechnician"].ToString().ToLower() == "true")
					{
						repositoryInfo.bTechnician = true;
					}
					else
					{
						repositoryInfo.bTechnician = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bSeller"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bSeller"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bSeller"].ToString().ToLower() == "true")
					{
						repositoryInfo.bSeller = true;
					}
					else
					{
						repositoryInfo.bSeller = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bStockMan"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bStockMan"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bStockMan"].ToString().ToLower() == "true")
					{
						repositoryInfo.bStockMan = true;
					}
					else
					{
						repositoryInfo.bStockMan = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bDestClerk"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bDestClerk"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bDestClerk"].ToString().ToLower() == "true")
					{
						repositoryInfo.bDestClerk = true;
					}
					else
					{
						repositoryInfo.bDestClerk = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bAccountant"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bAccountant"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bAccountant"].ToString().ToLower() == "true")
					{
						repositoryInfo.bAccountant = true;
					}
					else
					{
						repositoryInfo.bAccountant = false;
					}
				}
				result = repositoryInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public void UpdateHit(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update Repository set ");
			stringBuilder.Append("Hit=Hit+1 ");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}
	}
}
