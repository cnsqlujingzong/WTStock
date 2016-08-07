using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.Model;
using wt.OtherLibrary;

public partial class Branch_Services_ModS : Page, IRequiresSessionState
{
	private int id;

	

	protected string EnforceInput
	{
		get
		{
			string result;
			if (this.hfEnforceInput.Value == "1" && this.tbDoStyle.Text.Trim().Equals("完成关闭"))
			{
				result = "true";
			}
			else
			{
				result = "false";
			}
			return result;
		}
	}

	protected string EnforceStyle
	{
		get
		{
			string result;
			if (this.hfEnforceInput.Value == "1" && this.tbDoStyle.Text.Trim().Equals("完成关闭"))
			{
				result = "class='sysred'";
			}
			else
			{
				result = "";
			}
			return result;
		}
	}

	public string Str_id
	{
		get
		{
			return this.id.ToString();
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"].Replace("s", ""), out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		DALServices dALServices = new DALServices();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "gd_r7"))
				{
					this.btnAdd.Enabled = false;
				}
				if (!dALServices.GetSerStatus(this.id))
				{
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindTrobleReason(this.ddlTroubleReason);
			DataTable dataTable = DALCommon.GetDataList("fw_servicesprocess", "", " [ID]=" + this.id.ToString()).Tables[0];
			DataTable dataTable2 = DALCommon.GetDataList("ServicesTakeSteps", "StepID", " [SPID]=" + this.id.ToString()).Tables[0];
			IEnumerator enumerator;
			if (dataTable2.Rows.Count > 0)
			{
				string text = string.Empty;
				enumerator = dataTable2.Rows.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						DataRow dataRow = (DataRow)enumerator.Current;
						text = text + dataRow["StepID"].ToString() + ",";
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
				this.hfTakeSteps.Value = text.Trim().Trim(new char[]
				{
					','
				});
			}
			if (dataTable.Rows.Count > 0)
			{
				this.tbDoStyle.Text = dataTable.Rows[0]["DoStyle"].ToString();
				this.tbArrDate.Text = dataTable.Rows[0]["ArrivedTime"].ToString();
				this.tbOperator.Text = dataTable.Rows[0]["Person"].ToString();
				this.tbDisposal.Text = dataTable.Rows[0]["Operator"].ToString();
				this.tbDate.Text = dataTable.Rows[0]["_Date"].ToString();
				if (!dataTable.Rows[0]["visitdate"].ToString().Trim().Equals(""))
				{
					this.tbDoorDate.Text = DateTime.Parse(dataTable.Rows[0]["visitdate"].ToString()).ToString("yyyy-MM-dd");
				}
				DataTable dataTable3 = DALCommon.GetDataList("ServicesList", "*", " [ID]=" + dataTable.Rows[0]["BillID"].ToString()).Tables[0];
				if (dataTable3.Rows.Count > 0)
				{
					this.tbFault.Text = dataTable3.Rows[0]["Fault"].ToString();
					if (dataTable3.Rows[0]["bTake"].ToString() != "" && dataTable3.Rows[0]["bTake"].ToString() != null)
					{
						this.chkOver.Checked = (bool)dataTable3.Rows[0]["bTake"];
					}
				}
				this.tbTakeSteps.Text = dataTable.Rows[0]["TakeSteps"].ToString();
				this.tbReason.Value = dataTable.Rows[0]["Reason"].ToString();
				this.tbDay.Text = dataTable.Rows[0]["iDays"].ToString();
				this.tbHour.Text = dataTable.Rows[0]["iHours"].ToString();
				this.tbCourse.Text = dataTable.Rows[0]["Course"].ToString();
			}
			DataTable dataTable4 = DALCommon.GetList("SerAttach", "ID", "BillID=" + this.id + " and iType=2").Tables[0];
			string text2 = string.Empty;
			enumerator = dataTable4.Rows.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					text2 = text2 + dataRow["ID"].ToString().Trim() + ",";
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			this.hfTSAttachs.Value = text2.Trim(new char[]
			{
				','
			});
			DataTable dataTable5 = DALCommon.GetList("SerAttach", "ID", "BillID=" + this.id + " and iType=3").Tables[0];
			text2 = string.Empty;
			enumerator = dataTable5.Rows.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					text2 = text2 + dataRow["ID"].ToString().Trim() + ",";
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			this.hfReasonAttachs.Value = text2.Trim(new char[]
			{
				','
			});
			DataTable dataTable6 = DALCommon.GetList("SerAttach", "ID", "BillID=" + dataTable.Rows[0]["BillID"].ToString() + " and iType=1").Tables[0];
			text2 = string.Empty;
			enumerator = dataTable6.Rows.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					DataRow dataRow = (DataRow)enumerator.Current;
					text2 = text2 + dataRow["ID"].ToString().Trim() + ",";
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			this.hfAttachs.Value = text2.Trim(new char[]
			{
				','
			});
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo model = dALSysParm.GetModel(1);
			if (model.bTakeStepsNoInput)
			{
				this.tbTakeSteps.Attributes["onfocus"] = "blur();";
			}
			this.hfEnforceInput.Value = (model.bEnforceInput ? "1" : "0");
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALServices dALServices = new DALServices();
		string reason = FunLibrary.ChkInput(this.tbReason.Value);
		string takeSteps = FunLibrary.ChkInput(this.tbTakeSteps.Text);
		int iDays = 0;
		decimal iHours = 0m;
		int.TryParse(this.tbDay.Text, out iDays);
		decimal.TryParse(this.tbHour.Text, out iHours);
		DateTime minValue = DateTime.MinValue;
		if (!this.tbDoorDate.Text.Trim().Equals(""))
		{
			DateTime.TryParse(this.tbDoorDate.Text, out minValue);
		}
		dALServices.UpdateProcess(this.id, reason, takeSteps, DateTime.Parse(this.tbArrDate.Text), iDays, iHours, minValue, this.tbCourse.Text.Trim());
		dALServices.UpdateProcessSteps(this.id, this.hfTakeSteps.Value);
		int serID = dALServices.GetSerID(this.id);
		if (this.chkOver.Checked)
		{
			dALServices.SetIsTake(serID, true);
		}
		else
		{
			dALServices.SetIsTake(serID, false);
		}
		string ids = this.hfTSAttachs.Value.Trim().Trim(new char[]
		{
			','
		});
		dALServices.UpdateAttachs(this.id, 2, ids);
		ids = this.hfReasonAttachs.Value.Trim().Trim(new char[]
		{
			','
		});
		dALServices.UpdateAttachs(this.id, 3, ids);
		this.SysInfo("parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
