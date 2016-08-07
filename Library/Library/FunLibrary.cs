using System;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Xml;

namespace wt.Library
{
	public sealed class FunLibrary
	{
		public static string connectionString;

		static FunLibrary()
		{
			FunLibrary.connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
		}

		public FunLibrary()
		{
		}

		private static bool CheckLogin(int iUser)
		{
			bool flag;
			string empty = string.Empty;
			if (HttpContext.Current.Session["OperCode"] != null)
			{
				empty = HttpContext.Current.Session["OperCode"].ToString();
			}
			if (empty != null)
			{
				object obj = null;
				object[] objArray = new object[] { "if not exists (select bSim from SysParm where ID=1 and bSim=1) select 1;if exists(select ID from UserManage where StaffID=", iUser, " and OperCode='", empty, "' and LastOper>dateadd(minute,-1,getdate())) select 1 else select 0" };
				string str = string.Concat(objArray);
				SqlConnection sqlConnection = new SqlConnection(FunLibrary.connectionString);
				try
				{
					SqlCommand sqlCommand = new SqlCommand(str, sqlConnection);
					try
					{
						try
						{
							sqlConnection.Open();
							obj = sqlCommand.ExecuteScalar();
						}
						catch (SqlException sqlException1)
						{
							SqlException sqlException = sqlException1;
							sqlConnection.Close();
							throw new Exception(sqlException.Message);
						}
					}
					finally
					{
						if (sqlCommand != null)
						{
							((IDisposable)sqlCommand).Dispose();
						}
					}
				}
				finally
				{
					if (sqlConnection != null)
					{
						((IDisposable)sqlConnection).Dispose();
					}
				}
				if (obj != null)
				{
					flag = (int.Parse(obj.ToString()) == 1 ? true : false);
				}
				else
				{
					flag = false;
				}
			}
			else
			{
				flag = true;
			}
			return flag;
		}

		private static bool CheckTime()
		{
			HttpCookie httpCookie;
			bool flag;
			DateTime now;
			int num = 0;
			if ((HttpContext.Current.Request.Cookies["locktime"] == null ? false : HttpContext.Current.Request.Cookies["lastoper"] != null))
			{
				int.TryParse(HttpContext.Current.Request.Cookies["locktime"].Value, out num);
				if (num > 0)
				{
					DateTime dateTime = DateTime.Now;
					DateTime.TryParse(HttpContext.Current.Request.Cookies["lastoper"].Value, out dateTime);
					if ((DateTime.Now - dateTime).Minutes > num)
					{
						HttpCookie item = HttpContext.Current.Response.Cookies["locktime"];
						now = DateTime.Now;
						item.Expires = now.AddDays(-1);
						HttpCookie item1 = HttpContext.Current.Response.Cookies["lastoper"];
						now = DateTime.Now;
						item1.Expires = now.AddDays(-1);
						flag = false;
					}
					else
					{
						httpCookie = new HttpCookie("lastoper");
						now = DateTime.Now;
						httpCookie.Value = now.ToString("yyyy-MM-dd HH:mm:ss");
						HttpContext.Current.Response.Cookies.Set(httpCookie);
						flag = true;
					}
				}
				else
				{
					flag = true;
				}
			}
			else
			{
				HttpCookie str = new HttpCookie("locktime");
				httpCookie = new HttpCookie("lastoper");
				object obj = null;
				string str1 = "select isnull(LockMinutes,0) from SysParm where ID=1";
				SqlConnection sqlConnection = new SqlConnection(FunLibrary.connectionString);
				try
				{
					SqlCommand sqlCommand = new SqlCommand(str1, sqlConnection);
					try
					{
						try
						{
							sqlConnection.Open();
							obj = sqlCommand.ExecuteScalar();
						}
						catch (SqlException sqlException1)
						{
							SqlException sqlException = sqlException1;
							sqlConnection.Close();
							throw new Exception(sqlException.Message);
						}
					}
					finally
					{
						if (sqlCommand != null)
						{
							((IDisposable)sqlCommand).Dispose();
						}
					}
				}
				finally
				{
					if (sqlConnection != null)
					{
						((IDisposable)sqlConnection).Dispose();
					}
				}
				if (obj == null)
				{
					num = 0;
				}
				num = int.Parse(obj.ToString());
				str.Value = num.ToString();
				now = DateTime.Now;
				httpCookie.Value = now.ToString("yyyy-MM-dd HH:mm:ss");
				HttpContext.Current.Response.Cookies.Set(str);
				HttpContext.Current.Response.Cookies.Set(httpCookie);
				flag = true;
			}
			return flag;
		}

		public static void ChkBran()
		{
			if ((HttpContext.Current.Session["Session_wtBranch"] == null || HttpContext.Current.Session["Session_wtUserB"] == null || HttpContext.Current.Session["Session_wtUserBID"] == null || HttpContext.Current.Session["Session_wtPurB"] == null ? true : HttpContext.Current.Session["Session_wtBranchID"] == null))
			{
				HttpContext.Current.Response.Write("<Script>top.location.href = '../../Headquarters/Tip.html';</Script>");
				HttpContext.Current.Response.End();
			}
			if (!FunLibrary.CheckLogin(int.Parse(HttpContext.Current.Session["Session_wtUserBID"].ToString())))
			{
				HttpContext.Current.Response.Write("<Script>top.location.href = '../../Headquarters/Tip.html';</Script>");
				HttpContext.Current.Response.End();
			}
			if (!FunLibrary.CheckTime())
			{
				HttpContext.Current.Response.Write("<Script>top.location.href = '../../Headquarters/Tip.html';</Script>");
				HttpContext.Current.Response.End();
			}
		}

		public static void ChkBran(bool btel)
		{
			if ((HttpContext.Current.Session["Session_wtBranch"] == null || HttpContext.Current.Session["Session_wtUserB"] == null || HttpContext.Current.Session["Session_wtUserBID"] == null || HttpContext.Current.Session["Session_wtPurB"] == null ? true : HttpContext.Current.Session["Session_wtBranchID"] == null))
			{
				HttpContext.Current.Response.Write("<Script>top.location.href = '../../Headquarters/Tip.html';</Script>");
				HttpContext.Current.Response.End();
			}
			if (!btel)
			{
				if (!FunLibrary.CheckLogin(int.Parse(HttpContext.Current.Session["Session_wtUserBID"].ToString())))
				{
					HttpContext.Current.Response.Write("<Script>top.location.href = '../../Headquarters/Tip.html';</Script>");
					HttpContext.Current.Response.End();
				}
				if (!FunLibrary.CheckTime())
				{
					HttpContext.Current.Response.Write("<Script>top.location.href = '../../Headquarters/Tip.html';</Script>");
					HttpContext.Current.Response.End();
				}
			}
		}

		public static void ChkHead()
		{
			if ((HttpContext.Current.Session["Session_wtPur"] == null || HttpContext.Current.Session["Session_wtUser"] == null ? true : HttpContext.Current.Session["Session_wtUserID"] == null))
			{
				HttpContext.Current.Response.Write("<Script>top.location.href = '../../Headquarters/Tip.html';</Script>");
				HttpContext.Current.Response.End();
			}
			if (!FunLibrary.CheckLogin(int.Parse(HttpContext.Current.Session["Session_wtUserID"].ToString())))
			{
				HttpContext.Current.Response.Write("<Script>top.location.href = '../../Headquarters/Tip.html';</Script>");
				HttpContext.Current.Response.End();
			}
			if (!FunLibrary.CheckTime())
			{
				HttpContext.Current.Response.Write("<Script>top.location.href = '../../Headquarters/Tip.html';</Script>");
				HttpContext.Current.Response.End();
			}
		}

		public static void ChkHead(bool btel)
		{
			if ((HttpContext.Current.Session["Session_wtPur"] == null || HttpContext.Current.Session["Session_wtUser"] == null ? true : HttpContext.Current.Session["Session_wtUserID"] == null))
			{
				HttpContext.Current.Response.Write("<Script>top.location.href = '../../Headquarters/Tip.html';</Script>");
				HttpContext.Current.Response.End();
			}
			if (!btel)
			{
				if (!FunLibrary.CheckLogin(int.Parse(HttpContext.Current.Session["Session_wtUserID"].ToString())))
				{
					HttpContext.Current.Response.Write("<Script>top.location.href = '../../Headquarters/Tip.html';</Script>");
					HttpContext.Current.Response.End();
				}
				if (!FunLibrary.CheckTime())
				{
					HttpContext.Current.Response.Write("<Script>top.location.href = '../../Headquarters/Tip.html';</Script>");
					HttpContext.Current.Response.End();
				}
			}
		}

		public static string ChkInput(string str)
		{
			string str1;
			str1 = (str == null ? "" : str.Trim().Replace("'", "''").Replace("%", "％"));
			return str1;
		}

		public static string CVT(string strIn)
		{
			string empty = string.Empty;
			string str = string.Empty;
			for (int i = 0; i < strIn.Length; i++)
			{
				str = strIn.Substring(i, 1);
				if (str.CompareTo("吖") < 0)
				{
					string upper = str.Substring(0, 1).ToUpper();
					empty = (!char.IsNumber(upper, 0) ? string.Concat(empty, upper) : string.Concat(empty, "0"));
				}
				else if (str.CompareTo("八") < 0)
				{
					empty = string.Concat(empty, "A");
				}
				else if (str.CompareTo("嚓") < 0)
				{
					empty = string.Concat(empty, "B");
				}
				else if (str.CompareTo("咑") < 0)
				{
					empty = string.Concat(empty, "C");
				}
				else if (str.CompareTo("妸") < 0)
				{
					empty = string.Concat(empty, "D");
				}
				else if (str.CompareTo("发") < 0)
				{
					empty = string.Concat(empty, "E");
				}
				else if (str.CompareTo("旮") < 0)
				{
					empty = string.Concat(empty, "F");
				}
				else if (str.CompareTo("铪") < 0)
				{
					empty = string.Concat(empty, "G");
				}
				else if (str.CompareTo("讥") < 0)
				{
					empty = string.Concat(empty, "H");
				}
				else if (str.CompareTo("咔") < 0)
				{
					empty = string.Concat(empty, "J");
				}
				else if (str.CompareTo("垃") < 0)
				{
					empty = string.Concat(empty, "K");
				}
				else if (str.CompareTo("嘸") < 0)
				{
					empty = string.Concat(empty, "L");
				}
				else if (str.CompareTo("拏") < 0)
				{
					empty = string.Concat(empty, "M");
				}
				else if (str.CompareTo("噢") < 0)
				{
					empty = string.Concat(empty, "N");
				}
				else if (str.CompareTo("妑") < 0)
				{
					empty = string.Concat(empty, "O");
				}
				else if (str.CompareTo("七") < 0)
				{
					empty = string.Concat(empty, "P");
				}
				else if (str.CompareTo("亽") < 0)
				{
					empty = string.Concat(empty, "Q");
				}
				else if (str.CompareTo("仨") < 0)
				{
					empty = string.Concat(empty, "R");
				}
				else if (str.CompareTo("他") < 0)
				{
					empty = string.Concat(empty, "S");
				}
				else if (str.CompareTo("哇") < 0)
				{
					empty = string.Concat(empty, "T");
				}
				else if (str.CompareTo("夕") < 0)
				{
					empty = string.Concat(empty, "W");
				}
				else if (str.CompareTo("丫") < 0)
				{
					empty = string.Concat(empty, "X");
				}
				else if (str.CompareTo("帀") >= 0)
				{
					empty = (str.CompareTo("咗") >= 0 ? string.Concat(empty, "0") : string.Concat(empty, "Z"));
				}
				else
				{
					empty = string.Concat(empty, "Y");
				}
			}
			return empty;
		}

		public static string DESDecrypt(string encryptedValue, string key, string IV)
		{
			string str;
			string str1 = encryptedValue;
			if (str1.Length >= 16)
			{
				for (int i = 0; i < 8; i++)
				{
					str1 = string.Concat(str1.Substring(0, i + 1), str1.Substring(i + 2));
				}
				encryptedValue = str1;
				key = string.Concat(key, "12345678");
				IV = string.Concat(IV, "12345678");
				key = key.Substring(0, 8);
				IV = IV.Substring(0, 8);
				try
				{
					SymmetricAlgorithm dESCryptoServiceProvider = new DESCryptoServiceProvider()
					{
						Key = Encoding.UTF8.GetBytes(key),
						IV = Encoding.UTF8.GetBytes(IV)
					};
					ICryptoTransform cryptoTransform = dESCryptoServiceProvider.CreateDecryptor();
					byte[] numArray = Convert.FromBase64String(encryptedValue);
					MemoryStream memoryStream = new MemoryStream();
					CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);
					cryptoStream.Write(numArray, 0, (int)numArray.Length);
					cryptoStream.FlushFinalBlock();
					cryptoStream.Close();
					str = Encoding.UTF8.GetString(memoryStream.ToArray());
				}
				catch (Exception exception)
				{
					str = "";
				}
			}
			else
			{
				str = "";
			}
			return str;
		}

		public static string DESEncrypt(string encryptStr, string key, string IV)
		{
			key = string.Concat(key, "12345678");
			IV = string.Concat(IV, "12345678");
			key = key.Substring(0, 8);
			IV = IV.Substring(0, 8);
			SymmetricAlgorithm dESCryptoServiceProvider = new DESCryptoServiceProvider()
			{
				Key = Encoding.UTF8.GetBytes(key),
				IV = Encoding.UTF8.GetBytes(IV)
			};
			ICryptoTransform cryptoTransform = dESCryptoServiceProvider.CreateEncryptor();
			byte[] bytes = Encoding.UTF8.GetBytes(encryptStr);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, (int)bytes.Length);
			cryptoStream.FlushFinalBlock();
			cryptoStream.Close();
			string base64String = Convert.ToBase64String(memoryStream.ToArray());
			Random random = new Random();
			for (int i = 0; i < 8; i++)
			{
				int num = random.Next(36);
				char chr = Convert.ToChar(num + 65);
				base64String = string.Concat(base64String.Substring(0, 2 * i + 1), chr.ToString(), base64String.Substring(2 * i + 1));
			}
			return base64String;
		}

		public static string EncodeReg(string str)
		{
			int i;
			string[] strArrays = new string[] { "S", "B", "T", "R", "X", "A", "F", "H", "J", "I" };
			string[] strArrays1 = strArrays;
			string str1 = FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower().Substring(10, 8);
			string empty = string.Empty;
			for (i = 0; i < str1.Length; i++)
			{
				empty = string.Concat(empty, (char)(str1[i] + (char)(2 * i - 6)));
			}
			string empty1 = string.Empty;
			string empty2 = string.Empty;
			for (i = 0; i < empty.Length; i++)
			{
				empty2 = Convert.ToString((int)empty[i]);
				while (empty2.Length < 3)
				{
					empty2 = string.Concat("0", empty2);
				}
				empty1 = string.Concat(empty1, strArrays1[int.Parse(empty2.Substring(0, 1))], strArrays1[int.Parse(empty2.Substring(1, 1))], strArrays1[int.Parse(empty2.Substring(2, 1))]);
			}
			empty1 = empty1.Insert(6, "-");
			empty1 = empty1.Insert(13, "-");
			empty1 = empty1.Insert(20, "-");
			return empty1;
		}

		public static int GetTimeSpanByDay(string strDate1, string strDate2)
		{
			int days = 0;
			if ((strDate1 != "" ? true : strDate2 != ""))
			{
				DateTime dateTime = DateTime.Parse(strDate1);
				days = (DateTime.Parse(strDate2) - dateTime).Days;
			}
			return days;
		}

		public static string GetTimeSpanStr(string str)
		{
			DateTime dateTime = DateTime.Parse(str);
			TimeSpan now = DateTime.Now - dateTime;
			int days = now.Days;
			int hours = now.Hours;
			if (hours < 0)
			{
				days--;
				hours = hours + 24;
			}
			string str1 = string.Concat(days.ToString(), "天", hours.ToString(), "小时");
			return str1;
		}

		public static string GetXmlNodeText(string path, string str)
		{
			string empty = string.Empty;
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(path);
			foreach (XmlNode childNode in xmlDocument.SelectSingleNode("config").ChildNodes)
			{
				if (childNode.Name == str)
				{
					empty = childNode.InnerText;
					break;
				}
			}
			return empty;
		}

		public static string HtmlEncode(string encodeString)
		{
			encodeString = encodeString.Replace("<", "&lt;");
			encodeString = encodeString.Replace(">", "&gt;");
			encodeString = encodeString.Replace("   ", "&nbsp;");
			encodeString = encodeString.Replace("’", "'");
			encodeString = encodeString.Replace('\r'.ToString(), "<br/>");
			return encodeString;
		}

		public static bool IsAllowedExtension(string filepath)
		{
			FileStream fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
			BinaryReader binaryReader = new BinaryReader(fileStream);
			string str = "";
			try
			{
				str = binaryReader.ReadByte().ToString();
				byte num = binaryReader.ReadByte();
				str = string.Concat(str, num.ToString());
			}
			catch
			{
			}
			binaryReader.Close();
			fileStream.Close();
			return ((str == "6037" || str == "103105" ? false : !(str == "4747")) ? true : false);
		}

		public static string NumChs(string input, int dec)
		{
			int i;
			string str;
			char[] chrArray;
			char chr;
			string[] strArrays;
			bool flag;
			bool flag1;
			string[] str1 = new string[] { "角", "分", "厘" };
			string[] strArrays1 = str1;
			str1 = new string[] { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
			string[] strArrays2 = str1;
			if (input.Contains("."))
			{
				string str2 = input.ToString();
				chrArray = new char[] { '0' };
				string str3 = str2.Trim(chrArray);
				chrArray = new char[] { '.' };
				strArrays = str3.Split(chrArray);
			}
			else
			{
				str1 = new string[] { input.ToString() };
				strArrays = str1;
			}
			string[] strArrays3 = strArrays;
			string empty = string.Empty;
			for (i = strArrays3[0].Length - 1; i > -1; i--)
			{
				chr = strArrays3[0][i];
				int num = int.Parse(chr.ToString());
				if (!(strArrays3[0].Length - i - 1 == 0 ? true : (strArrays3[0].Length - i - 1) % 8 != 0))
				{
					empty = string.Concat("亿", empty);
				}
				else if (((strArrays3[0].Length - i - 1) % 4 != 0 ? false : i != strArrays3[0].Length - 1))
				{
					empty = string.Concat("萬", empty);
				}
				if (((strArrays3[0].Length - i - 1) % 4 != 3 ? false : num != 0))
				{
					empty = string.Concat("仟", empty);
				}
				if (((strArrays3[0].Length - i - 1) % 4 != 2 ? false : num != 0))
				{
					empty = string.Concat("佰", empty);
				}
				if (((strArrays3[0].Length - i - 1) % 4 != 1 ? false : num != 0))
				{
					empty = string.Concat("拾", empty);
				}
				if (num != 0)
				{
					flag = false;
				}
				else
				{
					flag = (num != 0 || empty.Length <= 0 || empty[0] == '\u96F6' || empty[0] == '\u842C' ? true : empty[0] == '\u4EBF');
				}
				if (!flag)
				{
					empty = string.Concat(strArrays2[num], empty);
				}
				if (((strArrays3[0].Length - i) % 8 != 0 ? false : num == 0))
				{
					chrArray = new char[] { '\u842C' };
					empty = empty.TrimStart(chrArray);
				}
			}
			empty = string.Concat(empty, "圆");
			if ((int)strArrays3.Length == 1)
			{
				flag1 = false;
			}
			else
			{
				string str4 = strArrays3[1];
				chrArray = new char[] { '0' };
				flag1 = !str4.Trim(chrArray).Equals("");
			}
			if (flag1)
			{
				i = 0;
				while (i < strArrays3[1].Length)
				{
					if ((i == dec ? false : i != 3))
					{
						chr = strArrays3[1][i];
						int num1 = int.Parse(chr.ToString());
						if (num1 != 0)
						{
							empty = string.Concat(empty, strArrays2[num1], strArrays1[i]);
						}
						else if (empty[empty.Length - 1] != '\u96F6')
						{
							empty = string.Concat(empty, strArrays2[num1]);
						}
						i++;
					}
					else
					{
						break;
					}
				}
			}
			else
			{
				empty = string.Concat(empty, "整");
			}
			if (empty == "圆整")
			{
				str = "";
			}
			else if (!empty.StartsWith("圆"))
			{
				chrArray = new char[] { '\u96F6' };
				str = empty.Trim(chrArray);
			}
			else
			{
				string str5 = empty.Substring(1);
				chrArray = new char[] { '\u96F6' };
				str = str5.Trim(chrArray);
			}
			return str;
		}

		public static string RndStr(int n)
		{
			string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string str1 = "";
			Random random = new Random();
			for (int i = 0; i < n; i++)
			{
				int num = random.Next(26);
				str1 = string.Concat(str1, str.Substring(num, 1));
			}
			return str1;
		}

		public static void SetCacheXml(string path, int index, string sid, string sname)
		{
			XmlElement xmlElement;
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(path);
			XmlNode itemOf = xmlDocument.SelectSingleNode("cache").ChildNodes[index];
			XmlNodeList childNodes = itemOf.ChildNodes;
			if (childNodes.Count != 0)
			{
				foreach (XmlNode childNode in childNodes)
				{
					XmlElement xmlElement1 = (XmlElement)childNode;
					if (xmlElement1.GetAttribute("id") == sid)
					{
						xmlElement1.ParentNode.RemoveChild(xmlElement1);
					}
				}
				xmlElement = xmlDocument.CreateElement("temp");
				xmlElement.SetAttribute("id", sid);
				xmlElement.SetAttribute("name", sname);
				itemOf.AppendChild(xmlElement);
			}
			else
			{
				xmlElement = xmlDocument.CreateElement("temp");
				xmlElement.SetAttribute("id", sid);
				xmlElement.SetAttribute("name", sname);
				itemOf.AppendChild(xmlElement);
			}
			xmlDocument.Save(path);
		}

		public static void SltDrop(DropDownList ddlName, string ddl_value)
		{
			ddlName.ClearSelection();
			if (!(ddl_value != string.Empty))
			{
				ddlName.Items[0].Selected = true;
			}
			else
			{
				bool flag = false;
				int num = 0;
				while (num < ddlName.Items.Count)
				{
					if (!(ddlName.Items[num].Text == ddl_value))
					{
						num++;
					}
					else
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					ddlName.Items.Add(new ListItem(ddl_value, ddl_value));
				}
				num = 0;
				while (num < ddlName.Items.Count)
				{
					if (!(ddlName.Items[num].Text == ddl_value))
					{
						num++;
					}
					else
					{
						ddlName.Items[num].Selected = true;
						break;
					}
				}
			}
		}

		public static string SqlSeltC(string input)
		{
			string str = "";
			char[] charArray = input.ToLower().ToCharArray();
			for (int i = 0; i < (int)charArray.Length; i++)
			{
				char chr = charArray[i];
				if ((chr < 'a' ? false : chr <= 'z'))
				{
					switch (chr)
					{
						case 'a':
						{
							str = string.Concat(str, "[a吖-鏊]");
							break;
						}
						case 'b':
						{
							str = string.Concat(str, "[b八-簿]");
							break;
						}
						case 'c':
						{
							str = string.Concat(str, "[c嚓-错]");
							break;
						}
						case 'd':
						{
							str = string.Concat(str, "[d哒-跺]");
							break;
						}
						case 'e':
						{
							str = string.Concat(str, "[e屙-贰]");
							break;
						}
						case 'f':
						{
							str = string.Concat(str, "[f发-馥]");
							break;
						}
						case 'g':
						{
							str = string.Concat(str, "[g旮-过]");
							break;
						}
						case 'h':
						{
							str = string.Concat(str, "[h铪-蠖]");
							break;
						}
						case 'i':
						{
							str = string.Concat(str, chr);
							break;
						}
						case 'j':
						{
							str = string.Concat(str, "[j丌-竣]");
							break;
						}
						case 'k':
						{
							str = string.Concat(str, "[k咔-廓]");
							break;
						}
						case 'l':
						{
							str = string.Concat(str, "[l垃-雒]");
							break;
						}
						case 'm':
						{
							str = string.Concat(str, "[m妈-穆]");
							break;
						}
						case 'n':
						{
							str = string.Concat(str, "[n拿-糯]");
							break;
						}
						case 'o':
						{
							str = string.Concat(str, "[o噢-沤]");
							break;
						}
						case 'p':
						{
							str = string.Concat(str, "[p趴-曝]");
							break;
						}
						case 'q':
						{
							str = string.Concat(str, "[q七-群]");
							break;
						}
						case 'r':
						{
							str = string.Concat(str, "[r蚺-箬]");
							break;
						}
						case 's':
						{
							str = string.Concat(str, "[s仨-锁]");
							break;
						}
						case 't':
						{
							str = string.Concat(str, "[t他-箨]");
							break;
						}
						case 'u':
						{
							str = string.Concat(str, chr);
							break;
						}
						case 'v':
						{
							str = string.Concat(str, chr);
							break;
						}
						case 'w':
						{
							str = string.Concat(str, "[w哇-鋈]");
							break;
						}
						case 'x':
						{
							str = string.Concat(str, "[x夕-蕈]");
							break;
						}
						case 'y':
						{
							str = string.Concat(str, "[y丫-蕴]");
							break;
						}
						case 'z':
						{
							str = string.Concat(str, "[z匝-做]");
							break;
						}
					}
				}
				else
				{
					str = string.Concat(str, chr);
				}
			}
			return str;
		}

		public static string StrDecode(string str)
		{
			int i;
			string empty;
			char[] chrArray;
			str = str.Trim();
			if (str.Length == 75)
			{
				try
				{
					string[] strArrays = new string[] { "S", "X", "R", "T", "V", "F", "G", "H", "I", "J" };
					string[] strArrays1 = strArrays;
					string empty1 = string.Empty;
					string str1 = string.Empty;
					for (i = 0; i < str.Length; i = i + 3)
					{
						int num = 0;
						int num1 = 0;
						int num2 = 0;
						int num3 = 0;
						while (num3 < (int)strArrays1.Length)
						{
							if (!(str[i].ToString() == strArrays1[num3]))
							{
								num3++;
							}
							else
							{
								num = num3;
								break;
							}
						}
						num3 = 0;
						while (num3 < (int)strArrays1.Length)
						{
							if (!(str[i + 1].ToString() == strArrays1[num3]))
							{
								num3++;
							}
							else
							{
								num1 = num3;
								break;
							}
						}
						num3 = 0;
						while (num3 < (int)strArrays1.Length)
						{
							if (!(str[i + 2].ToString() == strArrays1[num3]))
							{
								num3++;
							}
							else
							{
								num2 = num3;
								break;
							}
						}
						str1 = string.Concat(num.ToString(), num1.ToString(), num2.ToString());
						chrArray = new char[] { '0' };
						string str2 = str1.TrimStart(chrArray);
						chrArray = new char[] { '0' };
						str1 = str2.TrimStart(chrArray);
						empty1 = string.Concat(empty1, (char)int.Parse(str1));
					}
					string empty2 = string.Empty;
					for (i = 0; i < empty1.Length; i++)
					{
						empty2 = string.Concat(empty2, (char)(empty1[i] - (char)(2 * i - empty1.Length - 6)));
					}
					string str3 = empty2.Substring(22, 2);
					chrArray = new char[] { '0' };
					str3 = str3.TrimStart(chrArray);
					empty = empty2.Substring(2, int.Parse(str3));
				}
				catch
				{
					empty = "-1";
				}
			}
			else
			{
				empty = string.Empty;
			}
			return empty;
		}

		public static string StrEncode(string str)
		{
			int i;
			string empty;
			int num;
			if (str.Trim() == string.Empty)
			{
				empty = string.Empty;
			}
			else if (str.Length <= 20)
			{
				string[] strArrays = new string[] { "S", "X", "R", "T", "V", "F", "G", "H", "I", "J" };
				string[] strArrays1 = strArrays;
				string str1 = str.Length.ToString();
				Random random = new Random();
				while (str.Length < 20)
				{
					num = random.Next(9);
					str = string.Concat(str, num.ToString());
				}
				for (i = 0; i < 2; i++)
				{
					num = random.Next(9);
					str = string.Concat(num.ToString(), str);
				}
				while (str1.Length < 2)
				{
					str1 = string.Concat("0", str1);
				}
				str = string.Concat(str, str1, random.Next(9));
				string empty1 = string.Empty;
				for (i = 0; i < str.Length; i++)
				{
					empty1 = string.Concat(empty1, (char)(str[i] + (char)(2 * i - str.Length - 6)));
				}
				string empty2 = string.Empty;
				string str2 = string.Empty;
				for (i = 0; i < empty1.Length; i++)
				{
					str2 = Convert.ToString((int)empty1[i]);
					while (str2.Length < 3)
					{
						str2 = string.Concat("0", str2);
					}
					empty2 = string.Concat(empty2, strArrays1[int.Parse(str2.Substring(0, 1))], strArrays1[int.Parse(str2.Substring(1, 1))], strArrays1[int.Parse(str2.Substring(2, 1))]);
				}
				empty = empty2;
			}
			else
			{
				empty = string.Empty;
			}
			return empty;
		}

		public static string StringMd5(string str)
		{
			string str1 = FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToUpper().Substring(0, 32);
			return str1;
		}
	}
}