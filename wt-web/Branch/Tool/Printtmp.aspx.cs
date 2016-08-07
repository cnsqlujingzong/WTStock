using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.Library;

public partial class Branch_Tool_Printtmp : Page, IRequiresSessionState
{
	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			this.FillData();
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkID('",
				e.Row.Cells[0].Text,
				"');ChkTname('",
				e.Row.Cells[2].Text,
				"');"
			}));
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Attributes.Add("ondblclick", "ChkTmp('Modify');");
			e.Row.Cells[0].Attributes.Add("id", "t" + e.Row.Cells[0].Text);
			e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
		}
	}

	protected void FillData()
	{
		string[] array = new string[]
		{
			"��ⵥ",
			"���ⵥ",
			"���˵�",
			"������",
			"��װ��",
			"���۵�",
			"�̵㵥",
			"���۵�",
			"���۶���",
			"ƾ֤��",
			"�ɹ���",
			"�����",
			"���۵�",
			"���㵥",
			"�굥",
			"������",
			"�տ",
			"���",
			"���޺�ͬ",
			"���޽��㵥",
			"�����ͬ",
			"�ڲ�������",
			"�����",
			"������",
			"Ӧ��Ӧ��",
			"��Ʒ���к�",
			"ƾ֤��(����)",
			"���㵥(����)",
			"���ƾ֤",
			"����ƾ֤"
		};
		string[] array2 = new string[]
		{
			"RKD.frf",
			"CKD.frf",
			"LTD.frf",
			"DBD.frf",
			"CZD.frf",
			"TJD.frf",
			"PDD.frf",
			"XSD.frf",
			"XSDD.frf",
			"PZD.frf",
			"PGD.frf",
			"SJD.frf",
			"BJD.frf",
			"JSD.frf",
			"XD.frf",
			"FHD.frf",
			"SKD.frf",
			"FKD.frf",
			"ZLD.frf",
			"ZLJSD.frf",
			"HT.frf",
			"NBDBD.frf",
			"JCD.frf",
			"BXD.frf",
			"YSYF.frf",
			"CPSN.frf",
			"PLPZD.frf",
			"PLJSD.frf",
			"JCD.frf",
			"BXPZ.frf"
		};
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add(new DataColumn("RecID", typeof(int)));
		dataTable.Columns.Add(new DataColumn("BillName", typeof(string)));
		dataTable.Columns.Add(new DataColumn("TmpName", typeof(string)));
		for (int i = 0; i < 25; i++)
		{
			DataRow dataRow = dataTable.NewRow();
			dataRow["RecID"] = i + 1;
			dataRow["BillName"] = array[i];
			dataRow["TmpName"] = array2[i];
			dataTable.Rows.Add(dataRow);
		}
		this.GridView1.DataSource = dataTable;
		this.GridView1.DataBind();
	}
}
