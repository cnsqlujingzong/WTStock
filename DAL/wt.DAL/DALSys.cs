using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using wt.DB;
using wt.Model;

namespace wt.DAL
{
	public class DALSys
	{
		public int AddLayoutUser(int DeptID, int ClassID, int UserID, out string strMsg)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@DeptID", SqlDbType.Int),
				new SqlParameter("@ClassID", SqlDbType.Int),
				new SqlParameter("@UserID", SqlDbType.Int),
				new SqlParameter("@strMsg", SqlDbType.NVarChar, 200)
			};
			array[0].Value = DeptID;
			array[1].Value = ClassID;
			array[2].Value = UserID;
			array[3].Direction = ParameterDirection.Output;
			int result = DbHelperSQL.RunProcedureTran("xt_layoutuseradd", array);
			strMsg = Convert.ToString(array[3].Value);
			return result;
		}

		public DataSet GetLayoutDetail(int iFlag, int DeptID, int WinName, int ClassID, int UserID)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iFlag", SqlDbType.Int),
				new SqlParameter("@DeptID", SqlDbType.Int),
				new SqlParameter("@WinName", SqlDbType.Int),
				new SqlParameter("@ClassID", SqlDbType.Int),
				new SqlParameter("@UserID", SqlDbType.Int)
			};
			array[0].Value = iFlag;
			array[1].Value = DeptID;
			array[2].Value = WinName;
			array[3].Value = ClassID;
			array[4].Value = UserID;
			return DbHelperSQL.RunProcedureDs("aa_getlayoutdetail", array);
		}

		public int AddLayout(LayoutDetailInfo model, out string strMsg)
		{
			List<string[]> list = new List<string[]>();
			string text = string.Empty;
			string text2 = string.Empty;
			if (model.LayoutDetailInfoss != null)
			{
				foreach (LayoutDetailInfos current in model.LayoutDetailInfoss)
				{
					string[] array = new string[4];
					if (current.ID == 0)
					{
						text2 = string.Empty;
						text = string.Empty;
						text2 += "ClassID";
						text += current.ClassID.ToString();
						if (current.DeptID > 0)
						{
							text2 += ",DeptID";
							text = text + "," + current.DeptID.ToString();
						}
						if (current.WinName > 0)
						{
							text2 += ",WinName";
							text = text + "," + current.WinName.ToString();
						}
						text2 += ",_Order";
						text = text + "," + current._Order.ToString();
						if (current.bShow)
						{
							text2 += ",bShow";
							text += ",1";
						}
						else
						{
							text2 += ",bShow";
							text += ",0";
						}
						if (current.FieldName != string.Empty)
						{
							text2 += ",FieldName";
							text = text + ",'" + current.FieldName + "'";
						}
						if (current.TitleName != string.Empty)
						{
							text2 += ",TitleName";
							text = text + ",'" + current.TitleName + "'";
						}
						array[0] = text2;
						array[1] = text;
						array[2] = "xt_bj_add";
						array[3] = current.ID.ToString();
						list.Add(array);
					}
					else
					{
						text = string.Empty;
						text = text + "_Order=" + current._Order.ToString();
						if (current.bShow)
						{
							text += ",bShow=1";
						}
						else
						{
							text += ",bShow=0";
						}
						text = text + ",TitleName='" + current.TitleName + "'";
						array[0] = "LayoutDetail";
						array[1] = text;
						array[2] = " [ID]=" + current.ID.ToString();
						array[3] = current.ID.ToString();
						list.Add(array);
					}
				}
			}
			return DbHelperSQL.AddLayout(list, out strMsg);
		}

		public int BackJob(string BackUpAdr)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@GoBak", SqlDbType.Int),
				new SqlParameter("@BackUpAdr", SqlDbType.NVarChar, 100)
			};
			array[0].Value = 1;
			array[1].Value = BackUpAdr;
			return DbHelperSQL.RunProcedureTran("xt_bakjob", array);
		}

		public int SysInit(int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12, string Operator)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@Init_CKGL", SqlDbType.Int, 4),
				new SqlParameter("@Init_CGGL", SqlDbType.Int, 4),
				new SqlParameter("@Init_XSGL", SqlDbType.Int, 4),
				new SqlParameter("@Init_FWGL", SqlDbType.Int, 4),
				new SqlParameter("@Init_KHGX", SqlDbType.Int, 4),
				new SqlParameter("@Init_ZKGL", SqlDbType.Int, 4),
				new SqlParameter("@Init_SFGL", SqlDbType.Int, 4),
				new SqlParameter("@Init_BGGL", SqlDbType.Int, 4),
				new SqlParameter("@Init_XTRZ", SqlDbType.Int, 4),
				new SqlParameter("@Init_JCSJ", SqlDbType.Int, 4),
				new SqlParameter("@Init_HPML", SqlDbType.Int, 4),
				new SqlParameter("@Init_ZLQB", SqlDbType.Int, 4),
				new SqlParameter("@Operator", SqlDbType.VarChar, 50)
			};
			array[0].Value = i1;
			array[1].Value = i2;
			array[2].Value = i3;
			array[3].Value = i4;
			array[4].Value = i5;
			array[5].Value = i6;
			array[6].Value = i7;
			array[7].Value = i8;
			array[8].Value = i9;
			array[9].Value = i10;
			array[10].Value = i11;
			array[11].Value = i12;
			array[12].Value = Operator;
			return DbHelperSQL.RunProcedureTran("xt_sysinit", array);
		}

		public DataSet GetXTTX(int iDept, int iStaff)
		{
			SqlParameter[] array = new SqlParameter[]
			{
				new SqlParameter("@iDept", SqlDbType.Int),
				new SqlParameter("@iStaff", SqlDbType.Int)
			};
			array[0].Value = iDept;
			array[1].Value = iStaff;
			return DbHelperSQL.RunProcedureDs("aa_dh_xt", array);
		}
	}
}
