using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALSupplierList
	{
		public int Add(SupplierListInfo model, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			if (model._Name != string.Empty)
			{
				text += "_Name,DeptID";
				object obj = text2;
				text2 = string.Concat(new object[]
				{
					obj,
					"'",
					model._Name,
					"',",
					model.DeptID
				});
			}
			if (model.SupNO != string.Empty)
			{
				text += ",SupNO";
				text2 = text2 + ",'" + model.SupNO + "'";
			}
			if (model.ClassID > 0)
			{
				text += ",ClassID";
				text2 = text2 + "," + model.ClassID;
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
			if (model.Tel2 != string.Empty)
			{
				text += ",Tel2";
				text2 = text2 + ",'" + model.Tel2 + "'";
			}
			if (model.Adr != string.Empty)
			{
				text += ",Adr";
				text2 = text2 + ",'" + model.Adr + "'";
			}
			if (model.Zip != string.Empty)
			{
				text += ",Zip";
				text2 = text2 + ",'" + model.Zip + "'";
			}
			if (model.Fax != string.Empty)
			{
				text += ",Fax";
				text2 = text2 + ",'" + model.Fax + "'";
			}
			if (model.Email != string.Empty)
			{
				text += ",Email";
				text2 = text2 + ",'" + model.Email + "'";
			}
			if (model.Account != string.Empty)
			{
				text += ",Account";
				text2 = text2 + ",'" + model.Account + "'";
			}
			if (model.bSupplier)
			{
				text += ",bSupplier";
				text2 += ",1";
			}
			if (model.bChargeCorp)
			{
				text += ",bChargeCorp";
				text2 += ",1";
			}
			if (model.bTransmitCorp)
			{
				text += ",bTransmitCorp";
				text2 += ",1";
			}
			if (model.pyCode != string.Empty)
			{
				text += ",pyCode";
				text2 = text2 + ",'" + model.pyCode + "'";
			}
			if (model.bStop)
			{
				text += ",bStop";
				text2 += ",1";
			}
			if (model.Remark != string.Empty)
			{
				text += ",Remark";
				text2 = text2 + ",'" + model.Remark + "'";
			}
			return DALCommon.InsertData("SupplierList", text, text2, " SupNO='" + model.SupNO + "'", "厂商编号", "ID", out strMsg, out iTbid);
		}

		public int Add_Sup(string strname, string strsupno, int strsupclass, string strlinkman, string strtel, string strtel2, string strfax, string strzip, string strEMail, string straccount, string stradr, string strremark, string strtransmitcorp, string strsuplier, string strchargecorp, int depetid, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@strname", SqlDbType.VarChar, 100),
				new SqlParameter("@strsupno", SqlDbType.VarChar, 50),
				new SqlParameter("@strsupclass", SqlDbType.Int),
				new SqlParameter("@strlinkman", SqlDbType.VarChar, 50),
				new SqlParameter("@strtel", SqlDbType.VarChar, 50),
				new SqlParameter("@strtel2", SqlDbType.VarChar, 50),
				new SqlParameter("@strfax", SqlDbType.VarChar, 50),
				new SqlParameter("@strzip", SqlDbType.VarChar, 50),
				new SqlParameter("@strEMail", SqlDbType.VarChar, 50),
				new SqlParameter("@straccount", SqlDbType.VarChar, 50),
				new SqlParameter("@stradr", SqlDbType.VarChar, 200),
				new SqlParameter("@strremark", SqlDbType.VarChar, 50),
				new SqlParameter("@strtransmitcorp", SqlDbType.VarChar, 50),
				new SqlParameter("@strsuplier", SqlDbType.VarChar, 50),
				new SqlParameter("@strchargecorp", SqlDbType.VarChar, 50),
				new SqlParameter("@depetid", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = strname;
			array[1].Value = strsupno;
			array[2].Value = strsupclass;
			array[3].Value = strlinkman;
			array[4].Value = strtel;
			array[5].Value = strtel2;
			array[6].Value = strfax;
			array[7].Value = strzip;
			array[8].Value = strEMail;
			array[9].Value = straccount;
			array[10].Value = stradr;
			array[11].Value = strremark;
			array[12].Value = strtransmitcorp;
			array[13].Value = strsuplier;
			array[14].Value = strchargecorp;
			array[15].Value = depetid;
			array[16].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("jc_inputsuplier", array);
			strMsg = Convert.ToString(array[16].Value);
			return result;
		}

		public int Update(SupplierListInfo model, string chkfld, out string strMsg)
		{
			string text = string.Empty;
			text = text + "_Name='" + model._Name + "'";
			text = text + ",SupNO='" + model.SupNO + "'";
			if (model.ClassID > 0)
			{
				text = text + ",ClassID=" + model.ClassID;
			}
			else
			{
				text += ",ClassID=null";
			}
			text = text + ",LinkMan='" + model.LinkMan + "'";
			text = text + ",Tel='" + model.Tel + "'";
			text = text + ",Tel2='" + model.Tel2 + "'";
			text = text + ",Adr='" + model.Adr + "'";
			text = text + ",Zip='" + model.Zip + "'";
			text = text + ",Fax='" + model.Fax + "'";
			text = text + ",Email='" + model.Email + "'";
			text = text + ",Account='" + model.Account + "'";
			if (model.bSupplier)
			{
				text += ",bSupplier=1";
			}
			else
			{
				text += ",bSupplier=0";
			}
			if (model.bChargeCorp)
			{
				text += ",bChargeCorp=1";
			}
			else
			{
				text += ",bChargeCorp=0";
			}
			if (model.bTransmitCorp)
			{
				text += ",bTransmitCorp=1";
			}
			else
			{
				text += ",bTransmitCorp=0";
			}
			text = text + ",pyCode='" + model.pyCode + "'";
			if (model.bStop)
			{
				text += ",bStop=1";
			}
			else
			{
				text += ",bStop=0";
			}
			text = text + ",Remark='" + model.Remark + "'";
			return DALCommon.UpdateData("SupplierList", text, " [ID]=" + model.ID.ToString(), " SupNO='" + chkfld + "'", " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public SupplierListInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select  top 1 a.[ID],a.SupNO,a._Name,a.DeptID,isnull(a.ClassID,0) as ClassID,b._Name as Class,a.LinkMan,a.Tel,a.Tel2,a.Adr,a.Zip,a.Fax,a.Email,a.Account,a.bSupplier,a.bChargeCorp,a.bTransmitCorp,a.pyCode,a.bStop,a.Remark from SupplierList a left join SupplierClass b on a.[ClassID]=b.[ID] ");
			stringBuilder.Append(" where a.ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			SupplierListInfo supplierListInfo = new SupplierListInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			SupplierListInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					supplierListInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				supplierListInfo.SupNO = dataSet.Tables[0].Rows[0]["SupNO"].ToString();
				supplierListInfo.DeptID = int.Parse(dataSet.Tables[0].Rows[0]["DeptID"].ToString());
				supplierListInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				if (dataSet.Tables[0].Rows[0]["ClassID"].ToString() != "")
				{
					supplierListInfo.ClassID = new int?(int.Parse(dataSet.Tables[0].Rows[0]["ClassID"].ToString()));
				}
				supplierListInfo.Class = dataSet.Tables[0].Rows[0]["Class"].ToString();
				supplierListInfo.LinkMan = dataSet.Tables[0].Rows[0]["LinkMan"].ToString();
				supplierListInfo.Tel = dataSet.Tables[0].Rows[0]["Tel"].ToString();
				supplierListInfo.Tel2 = dataSet.Tables[0].Rows[0]["Tel2"].ToString();
				supplierListInfo.Adr = dataSet.Tables[0].Rows[0]["Adr"].ToString();
				supplierListInfo.Zip = dataSet.Tables[0].Rows[0]["Zip"].ToString();
				supplierListInfo.Fax = dataSet.Tables[0].Rows[0]["Fax"].ToString();
				supplierListInfo.Email = dataSet.Tables[0].Rows[0]["Email"].ToString();
				supplierListInfo.Account = dataSet.Tables[0].Rows[0]["Account"].ToString();
				if (dataSet.Tables[0].Rows[0]["bSupplier"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bSupplier"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bSupplier"].ToString().ToLower() == "true")
					{
						supplierListInfo.bSupplier = true;
					}
					else
					{
						supplierListInfo.bSupplier = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bChargeCorp"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bChargeCorp"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bChargeCorp"].ToString().ToLower() == "true")
					{
						supplierListInfo.bChargeCorp = true;
					}
					else
					{
						supplierListInfo.bChargeCorp = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bTransmitCorp"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bTransmitCorp"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bTransmitCorp"].ToString().ToLower() == "true")
					{
						supplierListInfo.bTransmitCorp = true;
					}
					else
					{
						supplierListInfo.bTransmitCorp = false;
					}
				}
				supplierListInfo.pyCode = dataSet.Tables[0].Rows[0]["pyCode"].ToString();
				if (dataSet.Tables[0].Rows[0]["bStop"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bStop"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bStop"].ToString().ToLower() == "true")
					{
						supplierListInfo.bStop = true;
					}
					else
					{
						supplierListInfo.bStop = false;
					}
				}
				supplierListInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				result = supplierListInfo;
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
			case 0:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (SupNO like '%",
					strcon,
					"%' or _Name like '%",
					strcon,
					"%' or pyCode like '%",
					strcon,
					"%' or LinkMan like '%",
					strcon,
					"%' or Tel like '%",
					strcon,
					"%' or Adr like '%",
					strcon,
					"%' or Fax like '%",
					strcon,
					"%' or Zip like '%",
					strcon,
					"%' or Email like '%",
					strcon,
					"%' or Remark like '%",
					strcon,
					"%')"
				});
				break;
			}
			case 1:
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (_Name like '%",
					strcon,
					"%' or pyCode like '%",
					strcon,
					"%') "
				});
				break;
			}
			case 2:
				text = text + " and SupNO like '%" + strcon + "%' ";
				break;
			case 3:
				text = text + " and LinkMan like '%" + strcon + "%' ";
				break;
			case 4:
				text = text + " and Tel like '%" + strcon + "%' ";
				break;
			case 5:
				text = text + " and Adr like '%" + strcon + "%' ";
				break;
			case 6:
				text = text + " and Fax like '%" + strcon + "%' ";
				break;
			case 7:
				text = text + " and Zip like '%" + strcon + "%' ";
				break;
			case 8:
				text = text + " and Email like '%" + strcon + "%' ";
				break;
			case 9:
				text = text + " and Remark like '%" + strcon + "%' ";
				break;
			}
			return text;
		}

		public void UpdateClass(string strid, int int_a, int int_b, int int_c, int int_d, int int_1, int int_2, int int_3, int int_4)
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			stringBuilder.Append("update SupplierList set ");
			if (int_a == 1)
			{
				if (int_1 == 0)
				{
					stringBuilder2.Append("ClassID=null");
				}
				else
				{
					stringBuilder2.Append("ClassID=" + int_1);
				}
			}
			if (int_b == 1)
			{
				if (stringBuilder2.ToString() == "")
				{
					stringBuilder2.Append("bTransmitCorp=" + int_2);
				}
				else
				{
					stringBuilder2.Append(",bTransmitCorp=" + int_2);
				}
			}
			if (int_c == 1)
			{
				if (stringBuilder2.ToString() == "")
				{
					stringBuilder2.Append("bSupplier= " + int_3);
				}
				else
				{
					stringBuilder2.Append(",bSupplier= " + int_3);
				}
			}
			if (int_d == 1)
			{
				if (stringBuilder2.ToString() == "")
				{
					stringBuilder2.Append("bChargeCorp=" + int_4);
				}
				else
				{
					stringBuilder2.Append(",bChargeCorp=" + int_4);
				}
			}
			stringBuilder.Append(stringBuilder2.ToString());
			stringBuilder.Append(" where ID in(" + strid + ")");
			DbHelperSQL.ExecuteSql(stringBuilder.ToString());
		}

		public bool SupMerge(int id, string scus, string cusname, string linkman, string linktel, string adr, string remark)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@id", SqlDbType.Int, 4),
				new SqlParameter("@suppliers", SqlDbType.VarChar, 200),
				new SqlParameter("@sname", SqlDbType.VarChar, 100),
				new SqlParameter("@linkman", SqlDbType.VarChar, 50),
				new SqlParameter("@linktel", SqlDbType.VarChar, 50),
				new SqlParameter("@adr", SqlDbType.VarChar, 200),
				new SqlParameter("@remark", SqlDbType.VarChar, 2000)
			};
			array[0].Value = id;
			array[1].Value = scus;
			array[2].Value = cusname;
			array[3].Value = linkman;
			array[4].Value = linktel;
			array[5].Value = adr;
			array[6].Value = remark;
			int num = DbHelperSQL.RunProcedureTran("ks_suppliermerge", array);
			return num != 85;
		}

		public int UpdateLinkMan(SupplierListInfo model, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			List<string[]> strdellist = new List<string[]>();
			text = text + "ID=" + model.ID.ToString();
			string[] array = new string[7];
			array[0] = "SupplierList";
			array[1] = text;
			array[2] = " [ID]=" + model.ID.ToString();
			array[3] = "";
			array[4] = " [ID]=" + model.ID.ToString();
			list.Add(array);
			if (model.SupplierLinkManInfos != null)
			{
				foreach (SupplierLinkManInfo current in model.SupplierLinkManInfos)
				{
					string[] array2 = new string[9];
					if (current.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						if (current._Name != string.Empty)
						{
							text2 += "_Name";
							text = text + "'" + current._Name + "'";
						}
						if (current.LinkManDept != string.Empty)
						{
							text2 += ",LinkManDept";
							text = text + ",'" + current.LinkManDept + "'";
						}
						if (current.Sex != string.Empty)
						{
							text2 += ",Sex";
							text = text + ",'" + current.Sex + "'";
						}
						if (current.Posit != string.Empty)
						{
							text2 += ",Posit";
							text = text + ",'" + current.Posit + "'";
						}
						if (current.tel_Office != string.Empty)
						{
							text2 += ",tel_Office";
							text = text + ",'" + current.tel_Office + "'";
						}
						if (current.tel_Home != string.Empty)
						{
							text2 += ",tel_Home";
							text = text + ",'" + current.tel_Home + "'";
						}
						if (current.tel_Mobile != string.Empty)
						{
							text2 += ",tel_Mobile";
							text = text + ",'" + current.tel_Mobile + "'";
						}
						if (current.Fax != string.Empty)
						{
							text2 += ",Fax";
							text = text + ",'" + current.Fax + "'";
						}
						if (current.Birthday != string.Empty)
						{
							text2 += ",Birthday";
							text = text + ",'" + current.Birthday + "'";
						}
						if (current.Email != string.Empty)
						{
							text2 += ",Email";
							text = text + ",'" + current.Email + "'";
						}
						if (current.Remark != string.Empty)
						{
							text2 += ",Remark";
							text = text + ",'" + current.Remark + "'";
						}
						if (current.Adr != string.Empty)
						{
							text2 += ",Adr";
							text = text + ",'" + current.Adr + "'";
						}
						array2[0] = "SupplierLinkMan";
						array2[1] = text2;
						array2[2] = text;
						array2[3] = " _Name='" + current._Name + "' ";
						array2[4] = "厂商联系人";
						array2[5] = "ID";
						array2[6] = "SupplierID";
						array2[7] = current.ID.ToString();
						array2[8] = model.ID.ToString();
						list.Add(array2);
					}
					else
					{
						text = string.Empty;
						text = text + "_Name='" + current._Name + "'";
						text = text + ",LinkManDept='" + current.LinkManDept + "'";
						text = text + ",Sex='" + current.Sex + "'";
						text = text + ",Posit='" + current.Posit + "'";
						text = text + ",tel_Office='" + current.tel_Office + "'";
						text = text + ",tel_Home='" + current.tel_Home + "'";
						text = text + ",tel_Mobile='" + current.tel_Mobile + "'";
						text = text + ",Fax='" + current.Fax + "'";
						if (current.Birthday != string.Empty)
						{
							text = text + ",Birthday='" + current.Birthday + "'";
						}
						else
						{
							text += ",Birthday=null";
						}
						text = text + ",Email='" + current.Email + "'";
						text = text + ",Remark='" + current.Remark + "'";
						text = text + ",Adr='" + current.Adr + "'";
						array2[0] = "SupplierLinkMan";
						array2[1] = text;
						array2[2] = " [ID]=" + current.ID.ToString();
						array2[3] = "1=2";
						array2[4] = " [ID]=" + current.ID.ToString();
						array2[7] = current.ID.ToString();
						list.Add(array2);
					}
				}
			}
			return DbHelperSQL.UpdateManyProcedureTran(list, strdellist, false, out strMsg);
		}
	}
}
