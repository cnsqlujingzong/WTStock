using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace wt.Library
{
	public sealed class DataToExcel
	{
		public DataToExcel()
		{
		}

		public static void CreateExcel(DataSet ds)
		{
			char[] chrArray;
			HttpContext.Current.Response.Charset = "GB2312";
			HttpContext.Current.Response.ContentEncoding = Encoding.GetEncoding("GB2312");
			HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=expensede.xls");
			HttpContext.Current.Response.ContentType = "application/ms-excel";
			string str = "";
			string str1 = "";
			int i = 0;
			DataTable item = ds.Tables[0];
			DataRow[] dataRowArray = item.Select("");
			for (i = 0; i < item.Columns.Count; i++)
			{
				if (!(item.Columns[i].Caption.ToString() == "ID"))
				{
					if (i != item.Columns.Count - 1)
					{
						string str2 = item.Columns[i].Caption.ToString();
						chrArray = new char[] { 'c' };
						str = string.Concat(str, str2.TrimStart(chrArray), "\t");
					}
					else
					{
						string str3 = item.Columns[i].Caption.ToString();
						chrArray = new char[] { 'c' };
						str = string.Concat(str, str3.TrimStart(chrArray), "\n");
					}
				}
			}
			HttpContext.Current.Response.Write(str);
			DataRow[] dataRowArray1 = dataRowArray;
			for (int j = 0; j < (int)dataRowArray1.Length; j++)
			{
				DataRow dataRow = dataRowArray1[j];
				for (i = 0; i < item.Columns.Count; i++)
				{
					if (i != 4)
					{
						str1 = (i != item.Columns.Count - 1 ? string.Concat(str1, dataRow[i].ToString(), "\t") : string.Concat(str1, dataRow[i].ToString(), "\n"));
					}
				}
				HttpContext.Current.Response.Write(str1);
				str1 = "";
			}
			HttpContext.Current.Response.End();
		}

		public static void DataSetToExcel(DataSet ds, string[] Titles, string excelPath, string filename, string[] sheetNames, out bool iFlag, out string result)
		{
			int i;
			if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Excel/")))
			{
				Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Excel/"));
			}
			excelPath = HttpContext.Current.Server.MapPath(string.Concat("~/Excel/", excelPath));
			string str = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES;IMEX=2;'";
			int num = 0;
			while (true)
			{
				if (num < (int)sheetNames.Length)
				{
					string str1 = sheetNames[num];
					char[] chrArray = new char[] { '|' };
					string[] strArrays = str1.Split(chrArray);
					string str2 = strArrays[0];
					int num1 = int.Parse(strArrays[1]);
					DataTable item = ds.Tables[num1];
					string titles = Titles[num];
					string str3 = ".*?<(.*?)>|";
					string str4 = "<.*?>";
					Regex.Replace(Titles[num], str3, "$1|");
					Regex.Replace(Titles[num], str4, "");
					string str5 = Regex.Replace(Titles[num], str3, "$1|");
					chrArray = new char[] { '|' };
					string[] strArrays1 = str5.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
					string str6 = Regex.Replace(Titles[num], str4, "");
					chrArray = new char[] { '|' };
					string[] strArrays2 = str6.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
					for (i = 0; i < (int)strArrays1.Length; i++)
					{
						item.Columns[strArrays1[i]].SetOrdinal(i);
					}
					while (item.Columns.Count != (int)strArrays1.Length)
					{
						item.Columns.Remove(item.Columns[(int)strArrays1.Length].Caption);
					}
					if (item == null)
					{
						result = "操作失败！没有要导出的数据";
						iFlag = false;
						break;
					}
					else if (item.Rows.Count <= 60000)
					{
						int count = item.Rows.Count;
						int count1 = item.Columns.Count;
						if (count != 0)
						{
							StringBuilder stringBuilder = new StringBuilder();
							string str7 = string.Format(str, excelPath);
							stringBuilder.Append(string.Concat("CREATE TABLE ", str2, " ( "));
							for (i = 0; i < (int)strArrays2.Length; i++)
							{
								stringBuilder.Append(string.Format(string.Concat("[{0}] ", DataToExcel.GetDataType(item.Columns[i].DataType), ","), strArrays2[i].ToString()));
							}
							stringBuilder.Remove(stringBuilder.Length - 1, 1);
							stringBuilder.Append(")");
							OleDbConnection oleDbConnection = new OleDbConnection(str7);
							try
							{
								OleDbCommand oleDbCommand = new OleDbCommand(stringBuilder.ToString(), oleDbConnection);
								try
								{
									oleDbConnection.Open();
									oleDbCommand.ExecuteNonQuery();
								}
								catch (Exception exception)
								{
									result = string.Concat("在Excel中创建表失败，错误信息：", exception.Message);
									result = result.Replace("'", "\"");
									iFlag = false;
									break;
								}
								stringBuilder.Remove(0, stringBuilder.Length);
								stringBuilder.Append(string.Concat("INSERT INTO ", str2, " ( "));
								for (i = 0; i < (int)strArrays2.Length; i++)
								{
									stringBuilder.Append(string.Concat("[", strArrays2[i].ToString(), "],"));
								}
								stringBuilder.Remove(stringBuilder.Length - 1, 1);
								stringBuilder.Append(") values (");
								for (i = 0; i < count1; i++)
								{
									stringBuilder.Append(string.Concat("@", item.Columns[i].ColumnName, ","));
								}
								stringBuilder.Remove(stringBuilder.Length - 1, 1);
								stringBuilder.Append(")");
								oleDbCommand.CommandText = stringBuilder.ToString();
								OleDbParameterCollection parameters = oleDbCommand.Parameters;
								for (i = 0; i < count1; i++)
								{
									parameters.Add(new OleDbParameter(string.Concat("@", item.Columns[i].ColumnName), item.Columns[i].DataType));
								}
								foreach (DataRow row in item.Rows)
								{
									for (i = 0; i < parameters.Count; i++)
									{
										parameters[i].Value = row[i];
									}
									oleDbCommand.ExecuteNonQuery();
								}
							}
							finally
							{
								if (oleDbConnection != null)
								{
									((IDisposable)oleDbConnection).Dispose();
								}
							}
						}
						else
						{
							result = "操作失败！没有要导出的数据";
						}
						num++;
					}
					else
					{
						result = string.Concat("操作失败！", str2, "中的数据超过60000条。请分类查询后导出");
						iFlag = false;
						break;
					}
				}
				else
				{
					result = "数据导出成功!";
					iFlag = true;
					HttpContext.Current.Response.ContentType = "application/ms-excel";
					HttpContext.Current.Response.AppendHeader("Content-Disposition", string.Concat("attachment;filename=", HttpContext.Current.Server.UrlEncode(filename), ".xls"));
					HttpContext.Current.Response.BinaryWrite(File.ReadAllBytes(excelPath));
					File.Delete(excelPath);
					break;
				}
			}
		}

		public static void DataTableToExcel(DataTable dt, string[] TbTitle, string excelPath, string sheetName, out bool iFlag, out string result)
		{
			int i;
			if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Excel/")))
			{
				Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Excel/"));
			}
			excelPath = HttpContext.Current.Server.MapPath(string.Concat("~/Excel/", excelPath));
			string str = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES;IMEX=2;'";
			if (dt == null)
			{
				result = "操作失败！没有要导出的数据";
				iFlag = false;
			}
			else if (dt.Rows.Count <= 60000)
			{
				int count = dt.Rows.Count;
				int num = dt.Columns.Count;
				if (count != 0)
				{
					StringBuilder stringBuilder = new StringBuilder();
					string str1 = string.Format(str, excelPath);
					stringBuilder.Append(string.Concat("CREATE TABLE ", sheetName, " ( "));
					for (i = 0; i < (int)TbTitle.Length; i++)
					{
						stringBuilder.Append(string.Format(string.Concat("[{0}] ", DataToExcel.GetDataType(dt.Columns[i].DataType), ","), TbTitle[i].ToString()));
					}
					stringBuilder.Remove(stringBuilder.Length - 1, 1);
					stringBuilder.Append(")");
					OleDbConnection oleDbConnection = new OleDbConnection(str1);
					try
					{
						OleDbCommand oleDbCommand = new OleDbCommand(stringBuilder.ToString(), oleDbConnection);
						try
						{
							oleDbConnection.Open();
							oleDbCommand.ExecuteNonQuery();
						}
						catch (Exception exception)
						{
							result = string.Concat("在Excel中创建表失败，错误信息：", exception.Message);
							result = result.Replace("'", "\"");
							iFlag = false;
							return;
						}
						stringBuilder.Remove(0, stringBuilder.Length);
						stringBuilder.Append(string.Concat("INSERT INTO ", sheetName, " ( "));
						for (i = 0; i < (int)TbTitle.Length; i++)
						{
							stringBuilder.Append(string.Concat("[", TbTitle[i].ToString(), "],"));
						}
						stringBuilder.Remove(stringBuilder.Length - 1, 1);
						stringBuilder.Append(") values (");
						for (i = 0; i < num; i++)
						{
							stringBuilder.Append(string.Concat("@", dt.Columns[i].ColumnName, ","));
						}
						stringBuilder.Remove(stringBuilder.Length - 1, 1);
						stringBuilder.Append(")");
						oleDbCommand.CommandText = stringBuilder.ToString();
						OleDbParameterCollection parameters = oleDbCommand.Parameters;
						for (i = 0; i < num; i++)
						{
							parameters.Add(new OleDbParameter(string.Concat("@", dt.Columns[i].ColumnName), dt.Columns[i].DataType));
						}
						foreach (DataRow row in dt.Rows)
						{
							for (i = 0; i < parameters.Count; i++)
							{
								parameters[i].Value = row[i];
							}
							oleDbCommand.ExecuteNonQuery();
						}
						result = "数据导出成功!";
						iFlag = true;
					}
					finally
					{
						if (oleDbConnection != null)
						{
							((IDisposable)oleDbConnection).Dispose();
						}
					}
					HttpContext.Current.Response.ContentType = "application/ms-excel";
					HttpContext.Current.Response.AppendHeader("Content-Disposition", string.Concat("attachment;filename=", HttpContext.Current.Server.UrlEncode(sheetName), ".xls"));
					HttpContext.Current.Response.BinaryWrite(File.ReadAllBytes(excelPath));
					if (dt.Rows.Count > 10000)
					{
						HttpContext.Current.Response.Write("<script language=\"javascript\" type=\"text/javascript\">EndRequest2();</script>");
					}
					File.Delete(excelPath);
				}
				else
				{
					result = "操作失败！没有要导出的数据";
					iFlag = false;
				}
			}
			else
			{
				result = "操作失败！最多只能导出60000条数据。请分类查询后导出";
				iFlag = false;
			}
		}

		private static string GetDataType(Type type)
		{
			string str = "Text";
			if (type.ToString() == "System.Decimal")
			{
				str = "Decimal";
			}
			return str;
		}
	}
}