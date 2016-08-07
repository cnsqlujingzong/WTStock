using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALNetServices
	{
		public int Add(NetServicesInfo model, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			text = "AssID";
			text2 += model.AssID;
			if (model.TypeID > 0)
			{
				text += ",TypeID";
				text2 = text2 + "," + model.TypeID.ToString();
			}
			if (model._Date != string.Empty)
			{
				text += ",_Date";
				text2 = text2 + ",'" + model._Date + "'";
			}
			if (model.CustomerID > 0)
			{
				text += ",CustomerID";
				text2 = text2 + "," + model.CustomerID.ToString();
			}
			if (model.CustomerName != string.Empty)
			{
				text += ",CustomerName";
				text2 = text2 + ",'" + model.CustomerName + "'";
			}
			if (model.LinkMan != string.Empty)
			{
				text += ",LinkMan";
				text2 = text2 + ",'" + model.LinkMan + "'";
			}
			if (model.Tel != string.Empty)
			{
				text += ",Tel";
				text2 = text2 + ",'" + model.Tel + "'";
			}
			if (model.UsePerson != string.Empty)
			{
				text += ",UsePerson";
				text2 = text2 + ",'" + model.UsePerson + "'";
			}
			if (model.UsePersonDept != string.Empty)
			{
				text += ",UsePersonDept";
				text2 = text2 + ",'" + model.UsePersonDept + "'";
			}
			if (model.UsePersonTel != string.Empty)
			{
				text += ",UsePersonTel";
				text2 = text2 + ",'" + model.UsePersonTel + "'";
			}
			if (model.Area != string.Empty)
			{
				text += ",Area";
				text2 = text2 + ",'" + model.Area + "'";
			}
			if (model.Adr != string.Empty)
			{
				text += ",Adr";
				text2 = text2 + ",'" + model.Adr + "'";
			}
			if (model.ProductBrandID > 0)
			{
				text += ",ProductBrandID";
				text2 = text2 + "," + model.ProductBrandID.ToString();
			}
			if (model.ProductClassID > 0)
			{
				text += ",ProductClassID";
				text2 = text2 + "," + model.ProductClassID.ToString();
			}
			if (model.ProductModelID > 0)
			{
				text += ",ProductModelID";
				text2 = text2 + "," + model.ProductModelID.ToString();
			}
			if (model.ProductSN1 != string.Empty)
			{
				text += ",ProductSN1";
				text2 = text2 + ",'" + model.ProductSN1 + "'";
			}
			if (model.ProductSN2 != string.Empty)
			{
				text += ",ProductSN2";
				text2 = text2 + ",'" + model.ProductSN2 + "'";
			}
			if (model.Aspect != string.Empty)
			{
				text += ",Aspect";
				text2 = text2 + ",'" + model.Aspect + "'";
			}
			if (model.Status != string.Empty)
			{
				text += ",Status";
				text2 = text2 + ",'" + model.Status + "'";
			}
			if (model.Accessory != string.Empty)
			{
				text += ",Accessory";
				text2 = text2 + ",'" + model.Accessory + "'";
			}
			if (model.Fault != string.Empty)
			{
				text += ",Fault";
				text2 = text2 + ",'" + model.Fault + "'";
			}
			if (model.WarrantyID > 0)
			{
				text += ",WarrantyID";
				text2 = text2 + "," + model.WarrantyID.ToString();
			}
			if (model.BuyDate != string.Empty)
			{
				text += ",BuyDate";
				text2 = text2 + ",'" + model.BuyDate + "'";
			}
			if (model.BuyFrom != string.Empty)
			{
				text += ",BuyFrom";
				text2 = text2 + ",'" + model.BuyFrom + "'";
			}
			if (model.BuyInvoice != string.Empty)
			{
				text += ",BuyInvoice";
				text2 = text2 + ",'" + model.BuyInvoice + "'";
			}
			if (model.SubscribeTime != string.Empty)
			{
				text += ",SubscribeTime";
				text2 = text2 + ",'" + model.SubscribeTime + "'";
			}
			if (model.PostNO != string.Empty)
			{
				text += ",PostNO";
				text2 = text2 + ",'" + model.PostNO + "'";
			}
			if (model.Postage > 0m)
			{
				text += ",Postage";
				text2 = text2 + "," + model.Postage.ToString();
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			if (model.ServiceLevelID > 0)
			{
				text += ",ServiceLevelID";
				text2 = text2 + "," + model.ServiceLevelID;
			}
			if (model.SndStyleID > 0)
			{
				text += ",SndStyleID";
				text2 = text2 + "," + model.SndStyleID;
			}
			if (model.DeviceNO != string.Empty && model.Remark != null)
			{
				text += ",DeviceNO";
				text2 = text2 + ",'" + model.DeviceNO + "'";
			}
			if (model.IBranch > 0)
			{
				text += ",iBranch";
				object obj = text2;
				text2 = string.Concat(new object[]
				{
					obj,
					",'",
					model.IBranch,
					"'"
				});
			}
			return DALCommon.InsertData("NetServices", text, text2, " 1=2 ", "网络报修", "ID", out strMsg, out iTbid);
		}

		public void Update(NetServicesInfo model)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("update NetServices set ");
			stringBuilder.Append("TypeID=@TypeID,");
			stringBuilder.Append("_Date=@_Date,");
			stringBuilder.Append("Status=@Status,");
			stringBuilder.Append("AssID=@AssID,");
			stringBuilder.Append("CustomerID=@CustomerID,");
			stringBuilder.Append("CustomerName=@CustomerName,");
			stringBuilder.Append("LinkMan=@LinkMan,");
			stringBuilder.Append("Tel=@Tel,");
			stringBuilder.Append("UsePerson=@UsePerson,");
			stringBuilder.Append("UsePersonDept=@UsePersonDept,");
			stringBuilder.Append("UsePersonTel=@UsePersonTel,");
			stringBuilder.Append("Area=@Area,");
			stringBuilder.Append("Adr=@Adr,");
			stringBuilder.Append("ProductClassID=@ProductClassID,");
			stringBuilder.Append("ProductBrandID=@ProductBrandID,");
			stringBuilder.Append("ProductModelID=@ProductModelID,");
			stringBuilder.Append("ProductSN1=@ProductSN1,");
			stringBuilder.Append("ProductSN2=@ProductSN2,");
			stringBuilder.Append("Aspect=@Aspect,");
			stringBuilder.Append("Accessory=@Accessory,");
			stringBuilder.Append("Fault=@Fault,");
			stringBuilder.Append("WarrantyID=@WarrantyID,");
			stringBuilder.Append("BuyDate=@BuyDate,");
			stringBuilder.Append("BuyFrom=@BuyFrom,");
			stringBuilder.Append("BuyInvoice=@BuyInvoice,");
			stringBuilder.Append("SubscribeTime=@SubscribeTime,");
			stringBuilder.Append("PostNO=@PostNO,");
			stringBuilder.Append("Postage=@Postage,");
			stringBuilder.Append("ServiceLevelID=@ServiceLevelID,");
			stringBuilder.Append("SndStyleID=@SndStyleID,");
			stringBuilder.Append("Remark=@Remark,");
			stringBuilder.Append("iBranch=@iBranch");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4),
				new SqlParameter("@TypeID", SqlDbType.Int, 4),
				new SqlParameter("@_Date", SqlDbType.DateTime),
				new SqlParameter("@Status", SqlDbType.VarChar, 50),
				new SqlParameter("@AssID", SqlDbType.Int, 4),
				new SqlParameter("@CustomerID", SqlDbType.Int, 4),
				new SqlParameter("@CustomerName", SqlDbType.VarChar, 100),
				new SqlParameter("@LinkMan", SqlDbType.VarChar, 50),
				new SqlParameter("@Tel", SqlDbType.VarChar, 50),
				new SqlParameter("@UsePerson", SqlDbType.VarChar, 50),
				new SqlParameter("@UsePersonDept", SqlDbType.VarChar, 50),
				new SqlParameter("@UsePersonTel", SqlDbType.VarChar, 50),
				new SqlParameter("@Area", SqlDbType.VarChar, 50),
				new SqlParameter("@Adr", SqlDbType.VarChar, 200),
				new SqlParameter("@ProductClassID", SqlDbType.Int, 4),
				new SqlParameter("@ProductBrandID", SqlDbType.Int, 4),
				new SqlParameter("@ProductModelID", SqlDbType.Int, 4),
				new SqlParameter("@ProductSN1", SqlDbType.VarChar, 50),
				new SqlParameter("@ProductSN2", SqlDbType.VarChar, 50),
				new SqlParameter("@Aspect", SqlDbType.VarChar, 100),
				new SqlParameter("@Accessory", SqlDbType.VarChar, 200),
				new SqlParameter("@Fault", SqlDbType.VarChar, 1000),
				new SqlParameter("@WarrantyID", SqlDbType.Int, 4),
				new SqlParameter("@BuyDate", SqlDbType.DateTime),
				new SqlParameter("@BuyFrom", SqlDbType.VarChar, 50),
				new SqlParameter("@BuyInvoice", SqlDbType.VarChar, 50),
				new SqlParameter("@SubscribeTime", SqlDbType.DateTime),
				new SqlParameter("@PostNO", SqlDbType.VarChar, 50),
				new SqlParameter("@Postage", SqlDbType.Decimal, 9),
				new SqlParameter("@ServiceLevelID", SqlDbType.Int, 4),
				new SqlParameter("@SndStyleID", SqlDbType.Int, 4),
				new SqlParameter("@Remark", SqlDbType.VarChar, 500),
				new SqlParameter("@iBranch", SqlDbType.Int, 4)
			};
			array[0].Value = model.ID;
			array[1].Value = model.TypeID;
			array[2].Value = model._Date;
			array[3].Value = model.Status;
			array[4].Value = model.AssID;
			array[5].Value = model.CustomerID;
			array[6].Value = model.CustomerName;
			array[7].Value = model.LinkMan;
			array[8].Value = model.Tel;
			array[9].Value = model.UsePerson;
			array[10].Value = model.UsePersonDept;
			array[11].Value = model.UsePersonTel;
			array[12].Value = model.Area;
			array[13].Value = model.Adr;
			array[14].Value = model.ProductClassID;
			array[15].Value = model.ProductBrandID;
			array[16].Value = model.ProductModelID;
			array[17].Value = model.ProductSN1;
			array[18].Value = model.ProductSN2;
			array[19].Value = model.Aspect;
			array[20].Value = model.Accessory;
			array[21].Value = model.Fault;
			array[22].Value = model.WarrantyID;
			array[23].Value = model.BuyDate;
			array[24].Value = model.BuyFrom;
			array[25].Value = model.BuyInvoice;
			array[26].Value = model.SubscribeTime;
			array[27].Value = model.PostNO;
			array[28].Value = model.Postage;
			array[29].Value = model.ServiceLevelID;
			array[30].Value = model.SndStyleID;
			array[31].Value = model.Remark;
			array[32].Value = model.IBranch;
			DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
		}

		public NetServicesInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select * from NetServices ");
			stringBuilder.Append(" where ID=@ID");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			NetServicesInfo netServicesInfo = new NetServicesInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			netServicesInfo.ID = ID;
			NetServicesInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["TypeID"].ToString() != "")
				{
					netServicesInfo.TypeID = int.Parse(dataSet.Tables[0].Rows[0]["TypeID"].ToString());
				}
				netServicesInfo._Date = dataSet.Tables[0].Rows[0]["_Date"].ToString();
				netServicesInfo.Status = dataSet.Tables[0].Rows[0]["Status"].ToString();
				if (dataSet.Tables[0].Rows[0]["AssID"].ToString() != "")
				{
					netServicesInfo.AssID = int.Parse(dataSet.Tables[0].Rows[0]["AssID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["CustomerID"].ToString() != "")
				{
					netServicesInfo.CustomerID = int.Parse(dataSet.Tables[0].Rows[0]["CustomerID"].ToString());
				}
				netServicesInfo.CustomerName = dataSet.Tables[0].Rows[0]["CustomerName"].ToString();
				netServicesInfo.DeviceNO = dataSet.Tables[0].Rows[0]["DeviceNO"].ToString();
				netServicesInfo.LinkMan = dataSet.Tables[0].Rows[0]["LinkMan"].ToString();
				netServicesInfo.Tel = dataSet.Tables[0].Rows[0]["Tel"].ToString();
				netServicesInfo.UsePerson = dataSet.Tables[0].Rows[0]["UsePerson"].ToString();
				netServicesInfo.UsePersonDept = dataSet.Tables[0].Rows[0]["UsePersonDept"].ToString();
				netServicesInfo.UsePersonTel = dataSet.Tables[0].Rows[0]["UsePersonTel"].ToString();
				netServicesInfo.Area = dataSet.Tables[0].Rows[0]["Area"].ToString();
				netServicesInfo.Adr = dataSet.Tables[0].Rows[0]["Adr"].ToString();
				if (dataSet.Tables[0].Rows[0]["ProductClassID"].ToString() != "")
				{
					netServicesInfo.ProductClassID = int.Parse(dataSet.Tables[0].Rows[0]["ProductClassID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["ProductBrandID"].ToString() != "")
				{
					netServicesInfo.ProductBrandID = int.Parse(dataSet.Tables[0].Rows[0]["ProductBrandID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["ProductModelID"].ToString() != "")
				{
					netServicesInfo.ProductModelID = int.Parse(dataSet.Tables[0].Rows[0]["ProductModelID"].ToString());
				}
				netServicesInfo.ProductSN1 = dataSet.Tables[0].Rows[0]["ProductSN1"].ToString();
				netServicesInfo.ProductSN2 = dataSet.Tables[0].Rows[0]["ProductSN2"].ToString();
				netServicesInfo.Aspect = dataSet.Tables[0].Rows[0]["Aspect"].ToString();
				netServicesInfo.Accessory = dataSet.Tables[0].Rows[0]["Accessory"].ToString();
				netServicesInfo.Fault = dataSet.Tables[0].Rows[0]["Fault"].ToString();
				if (dataSet.Tables[0].Rows[0]["WarrantyID"].ToString() != "")
				{
					netServicesInfo.WarrantyID = int.Parse(dataSet.Tables[0].Rows[0]["WarrantyID"].ToString());
				}
				netServicesInfo.BuyDate = dataSet.Tables[0].Rows[0]["BuyDate"].ToString();
				netServicesInfo.BuyFrom = dataSet.Tables[0].Rows[0]["BuyFrom"].ToString();
				netServicesInfo.BuyInvoice = dataSet.Tables[0].Rows[0]["BuyInvoice"].ToString();
				netServicesInfo.SubscribeTime = dataSet.Tables[0].Rows[0]["SubscribeTime"].ToString();
				netServicesInfo.PostNO = dataSet.Tables[0].Rows[0]["PostNO"].ToString();
				if (dataSet.Tables[0].Rows[0]["Postage"].ToString() != "")
				{
					netServicesInfo.Postage = decimal.Parse(dataSet.Tables[0].Rows[0]["Postage"].ToString());
				}
				netServicesInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				if (dataSet.Tables[0].Rows[0]["ServiceLevelID"].ToString() != "")
				{
					netServicesInfo.ServiceLevelID = int.Parse(dataSet.Tables[0].Rows[0]["ServiceLevelID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["SndStyleID"].ToString() != "")
				{
					netServicesInfo.SndStyleID = int.Parse(dataSet.Tables[0].Rows[0]["SndStyleID"].ToString());
				}
				if (dataSet.Tables[0].Rows[0]["iBranch"].ToString() != "")
				{
					netServicesInfo.IBranch = int.Parse(dataSet.Tables[0].Rows[0]["iBranch"].ToString());
				}
				result = netServicesInfo;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public string GetSchWhere(int schid, string strcon)
		{
			string text = string.Empty;
			switch (schid)
			{
			case 1:
				text = text + " and _Name like '%" + strcon + "%' ";
				break;
			case 2:
				text = text + " and ServicesType like '%" + strcon + "%' ";
				break;
			case 3:
				text = text + " and CustomerName like '%" + strcon + "%' ";
				break;
			case 4:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (LinkMan like '%",
					strcon,
					"%' or UsePerson like '%",
					strcon,
					"%')"
				});
				break;
			}
			case 5:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (Tel like '%",
					strcon,
					"%' or UsePersonTel like '%",
					strcon,
					"%')"
				});
				break;
			}
			case 6:
				text = text + " and Adr like '%" + strcon + "%' ";
				break;
			case 7:
				text = text + " and ProductModel like '%" + strcon + "%' ";
				break;
			case 8:
				text = text + " and ProductBrand like '%" + strcon + "%' ";
				break;
			case 9:
				text = text + " and ProductClass like '%" + strcon + "%' ";
				break;
			case 10:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (ProductSN1 like '%",
					strcon,
					"%' or ProductSN2 like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 11:
				text = text + " and Fault like '%" + strcon + "%' ";
				break;
			case 12:
				text = text + " and Warranty like '%" + strcon + "%' ";
				break;
			case 13:
				text = text + " and Remark like '%" + strcon + "%' ";
				break;
			}
			return text;
		}
	}
}
