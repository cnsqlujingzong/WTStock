using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALBranchList
	{
		public int Add(BranchListInfo model, out string strMsg, out int iTbid)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			if (model.BranchNO != string.Empty)
			{
				text += "BranchNO";
				text2 = text2 + "'" + model.BranchNO + "'";
			}
			if (model._Name != string.Empty)
			{
				text += ",_Name";
				text2 = text2 + ",'" + model._Name + "'";
				text += ",pyCode";
				text2 = text2 + ",'" + model.pyCode + "'";
			}
			if (model.CorpName != string.Empty)
			{
				text += ",CorpName";
				text2 = text2 + ",'" + model.CorpName + "'";
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
			if (model.Area != string.Empty)
			{
				text += ",Area";
				text2 = text2 + ",'" + model.Area + "'";
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
			text += ",bBranchPurchase";
			if (model.bBranchPurchase)
			{
				text2 += ",1";
			}
			else
			{
				text2 += ",0";
			}
			text += ",bGoodsAdd";
			if (model.bGoodsAdd)
			{
				text2 += ",1";
			}
			else
			{
				text2 += ",0";
			}
            text += ",Array";
			text2 = text2 + "," + model.ArrayID;
            text += ",TR_jsfw";
            text2 = text2 + "," + model.TR_jsfw;
              text += ",TR_zzsxx";
            text2 = text2 + "," + model.TR_zzsxx;
              text += ",TR_zzsjx";
            text2 = text2 + "," + model.TR_zzsjx;
              text += ",TR_ptfp";
            text2 = text2 + "," + model.TR_ptfp;
			return DALCommon.InsertData("BranchList", text, text2, " BranchNO='" + model.BranchNO + "'", "网点名称", "ID", out strMsg, out iTbid);
		}

		public int Add_Branch(string strname, string strno, string strcomname, string strlinkman, string strtel, string strzip, string strfax, string stremail, string strfrom, string straccount, string stradr, string strremark, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@strName", SqlDbType.VarChar, 50),
				new SqlParameter("@strNo", SqlDbType.VarChar, 50),
				new SqlParameter("@strComName", SqlDbType.VarChar, 100),
				new SqlParameter("@strLinkman", SqlDbType.VarChar, 50),
				new SqlParameter("@strTel", SqlDbType.VarChar, 50),
				new SqlParameter("@strZip", SqlDbType.VarChar, 50),
				new SqlParameter("@strFax", SqlDbType.VarChar, 50),
				new SqlParameter("@strEmail", SqlDbType.VarChar, 50),
				new SqlParameter("@strFrom", SqlDbType.VarChar, 50),
				new SqlParameter("@strAccount", SqlDbType.VarChar, 50),
				new SqlParameter("@strAdr", SqlDbType.VarChar, 100),
				new SqlParameter("@strRemark", SqlDbType.VarChar, 200),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = strname;
			array[1].Value = strno;
			array[2].Value = strcomname;
			array[3].Value = strlinkman;
			array[4].Value = strtel;
			array[5].Value = strzip;
			array[6].Value = strfax;
			array[7].Value = stremail;
			array[8].Value = strfrom;
			array[9].Value = straccount;
			array[10].Value = stradr;
			array[11].Value = strremark;
			array[12].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("jc_inputbranch", array);
			strMsg = Convert.ToString(array[12].Value);
			return result;
		}

		public int Update(BranchListInfo model, string chkfld, out string strMsg)
		{
			string text = string.Empty;
			text = text + "BranchNO='" + model.BranchNO + "'";
			text = text + ",_Name='" + model._Name + "'";
			text = text + ",pyCode='" + model.pyCode + "'";
			text = text + ",CorpName='" + model.CorpName + "'";
			text = text + ",LinkMan='" + model.LinkMan + "'";
			text = text + ",Tel='" + model.Tel + "'";
			text = text + ",Adr='" + model.Adr + "'";
			text = text + ",Zip='" + model.Zip + "'";
			text = text + ",Fax='" + model.Fax + "'";
			text = text + ",Email='" + model.Email + "'";
			text = text + ",Account='" + model.Account + "'";
			text = text + ",Area='" + model.Area + "'";
			text = text + ",Array=" + model.ArrayID;
            text = text + ",TR_jsfw=" + model.TR_jsfw;//TaxRate
            text = text + ",TR_zzsxx=" + model.TR_zzsxx;//TaxRate
            text = text + ",TR_zzsjx=" + model.TR_zzsjx;//TaxRate
            text = text + ",TR_ptfp=" + model.TR_ptfp;//TaxRate
			if (model.bStop)
			{
				text += ",bStop=1";
			}
			else
			{
				text += ",bStop=0";
			}
			text = text + ",Remark='" + model.Remark + "'";
			if (model.bBranchPurchase)
			{
				text += ",bBranchPurchase=1";
			}
			else
			{
				text += ",bBranchPurchase=0";
			}
			if (model.bGoodsAdd)
			{
				text += ",bGoodsAdd=1";
			}
			else
			{
				text += ",bGoodsAdd=0";
			}
			return DALCommon.UpdateData("BranchList", text, " [ID]=" + model.ID.ToString(), chkfld, " [ID]=" + model.ID.ToString(), out strMsg);
		}

		public BranchListInfo GetModel(int ID)
		{
			StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select  top 1 ID,BranchNO,_Name,CorpName,LinkMan,Tel,Adr,Zip,Fax,Email,Account,Area,bStop,Remark,bBranchPurchase,bGoodsAdd,Array,TR_jsfw,TR_zzsxx,TR_zzsjx,TR_ptfp from BranchList ");
			stringBuilder.Append(" where ID=@ID ");
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4)
			};
			array[0].Value = ID;
			BranchListInfo branchListInfo = new BranchListInfo();
			DataSet dataSet = DbHelperSQL.Query(stringBuilder.ToString(), array);
			BranchListInfo result;
			if (dataSet.Tables[0].Rows.Count > 0)
			{
				if (dataSet.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					branchListInfo.ID = int.Parse(dataSet.Tables[0].Rows[0]["ID"].ToString());
				}
				branchListInfo.BranchNO = dataSet.Tables[0].Rows[0]["BranchNO"].ToString();
				branchListInfo._Name = dataSet.Tables[0].Rows[0]["_Name"].ToString();
				branchListInfo.CorpName = dataSet.Tables[0].Rows[0]["CorpName"].ToString();
				branchListInfo.LinkMan = dataSet.Tables[0].Rows[0]["LinkMan"].ToString();
				branchListInfo.Tel = dataSet.Tables[0].Rows[0]["Tel"].ToString();
				branchListInfo.Adr = dataSet.Tables[0].Rows[0]["Adr"].ToString();
				branchListInfo.Zip = dataSet.Tables[0].Rows[0]["Zip"].ToString();
				branchListInfo.Fax = dataSet.Tables[0].Rows[0]["Fax"].ToString();
				branchListInfo.Email = dataSet.Tables[0].Rows[0]["Email"].ToString();
				branchListInfo.Account = dataSet.Tables[0].Rows[0]["Account"].ToString();
				branchListInfo.Area = dataSet.Tables[0].Rows[0]["Area"].ToString();
                branchListInfo.TR_jsfw = Convert.ToDecimal(dataSet.Tables[0].Rows[0]["TR_jsfw"]);
                branchListInfo.TR_ptfp = Convert.ToDecimal(dataSet.Tables[0].Rows[0]["TR_ptfp"]);
                branchListInfo.TR_zzsjx = Convert.ToDecimal(dataSet.Tables[0].Rows[0]["TR_zzsjx"]);
                branchListInfo.TR_zzsxx = Convert.ToDecimal(dataSet.Tables[0].Rows[0]["TR_zzsxx"]);
				if (dataSet.Tables[0].Rows[0]["bStop"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bStop"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bStop"].ToString().ToLower() == "true")
					{
						branchListInfo.bStop = true;
					}
					else
					{
						branchListInfo.bStop = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bBranchPurchase"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bBranchPurchase"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bBranchPurchase"].ToString().ToLower() == "true")
					{
						branchListInfo.bBranchPurchase = true;
					}
					else
					{
						branchListInfo.bBranchPurchase = false;
					}
				}
				if (dataSet.Tables[0].Rows[0]["bGoodsAdd"].ToString() != "")
				{
					if (dataSet.Tables[0].Rows[0]["bGoodsAdd"].ToString() == "1" || dataSet.Tables[0].Rows[0]["bGoodsAdd"].ToString().ToLower() == "true")
					{
						branchListInfo.bGoodsAdd = true;
					}
					else
					{
						branchListInfo.bGoodsAdd = false;
					}
				}
				branchListInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				if (!string.IsNullOrEmpty(dataSet.Tables[0].Rows[0]["Array"].ToString()))
				{
					branchListInfo.ArrayID = int.Parse(dataSet.Tables[0].Rows[0]["Array"].ToString());
				}
				branchListInfo.Remark = dataSet.Tables[0].Rows[0]["Remark"].ToString();
				result = branchListInfo;
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
				text = text + " and BranchNO like '%" + strcon + "%' ";
				break;
			case 3:
				text = text + " and CorpName like '%" + strcon + "%' ";
				break;
			case 4:
				text = text + " and Tel like '%" + strcon + "%' ";
				break;
			case 5:
				text = text + " and LinkMan like '%" + strcon + "%' ";
				break;
			case 6:
				text = text + " and Fax like '%" + strcon + "%' ";
				break;
			case 7:
				text = text + " and Account like '%" + strcon + "%' ";
				break;
			case 8:
				text = text + " and Remark like '%" + strcon + "%' ";
				break;
			}
			return text;
		}
	}
}
