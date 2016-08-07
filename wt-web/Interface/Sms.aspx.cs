using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using wt.DAL;
using wt.Model;

public partial class Interface_Sms : Page, IRequiresSessionState
{
	
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!base.IsPostBack)
		{
			string b = base.Request["uCode"];
			string text = base.Request["mType"];
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo sysParm = dALSysParm.GetSysParm();
			if (sysParm == null)
			{
				base.Response.Write("未设置验证码.");
			}
			else if (sysParm.SmsCode == string.Empty)
			{
				base.Response.Write("未设置验证码.");
			}
			else if (sysParm.SmsCode != b)
			{
				base.Response.Write("验证码不正确.");
			}
			else
			{
				if (text == null)
				{
					text = string.Empty;
				}
				string text2 = text.ToLower();
				if (text2 != null)
				{
					if (!(text2 == "msndsms"))
					{
						if (text2 == "mrcvsms")
						{
							string text3 = base.Request["RcvFrom"];
							string text4 = base.Request["RcvInfo"];
							if (text3 != null && !(text3 == "") && text4 != null && !(text4 == ""))
							{
								DALSmsRcv dALSmsRcv = new DALSmsRcv();
								SmsRcvInfo smsRcvInfo = new SmsRcvInfo();
								smsRcvInfo.SndFrom = text3;
								smsRcvInfo.Content = text4;
								smsRcvInfo.SDate = DateTime.Now;
								dALSmsRcv.Add(smsRcvInfo);
								if (text4.Substring(0, 2).ToLower() == "qr")
								{
									int num;
									int.TryParse(text4.Substring(2), out num);
									if (num > 0)
									{
										DALServices dALServices = new DALServices();
										string text5 = "";
										int num2 = dALServices.SerConf(2, num, 0, smsRcvInfo.SndFrom, DateTime.Now.ToString(), out text5);
									}
								}
								else if (text4.ToLower() == "kq")
								{
									DataTable dataTable = DALCommon.GetDataList("StaffList", "[ID]", " Tel='" + text3 + "'").Tables[0];
									if (dataTable.Rows.Count > 0)
									{
										DALAttendanceDetail dALAttendanceDetail = new DALAttendanceDetail();
										AttendanceDetailInfo attendanceDetailInfo = new AttendanceDetailInfo();
										attendanceDetailInfo.iOperator = int.Parse(dataTable.Rows[0]["ID"].ToString());
										attendanceDetailInfo._Date = smsRcvInfo.SDate.ToString();
										attendanceDetailInfo.Remark = "短信考勤";
										string text5 = "";
										int num = 0;
										dALAttendanceDetail.Add(attendanceDetailInfo, out text5, out num);
									}
								}
							}
						}
					}
					else
					{
						StringBuilder stringBuilder = new StringBuilder();
						stringBuilder.Append("<?xml version='1.0' encoding='utf-8' ?>\n");
						DALSmsSnd dALSmsSnd = new DALSmsSnd();
						DataTable dataTable2 = dALSmsSnd.GetList("SFlag=0 ").Tables[0];
						int count = dataTable2.Rows.Count;
						stringBuilder.Append("<SMS>\n");
						stringBuilder.Append("<Counts>" + count.ToString() + "</Counts>\n");
						if (count > 0)
						{
							for (int i = 0; i < count; i++)
							{
								stringBuilder.Append("<Item>\n");
								stringBuilder.Append("<SndTo>" + dataTable2.Rows[i]["SndTo"].ToString() + "</SndTo>\n");
								stringBuilder.Append("<Info>" + dataTable2.Rows[i]["Content"].ToString() + "</Info>\n");
								stringBuilder.Append("</Item>\n");
								dALSmsSnd.Update(int.Parse(dataTable2.Rows[i]["RecID"].ToString()), DateTime.Now);
							}
						}
						stringBuilder.Append("</SMS>");
						base.Response.Write(stringBuilder.ToString());
					}
				}
			}
		}
	}
}
