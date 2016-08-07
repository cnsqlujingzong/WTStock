using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class MyTemplatexb : ITemplate
{
	private string strColumnName;

	private DataControlRowType dcrtColumnType;

	public MyTemplatexb()
	{
	}

	public MyTemplatexb(string strColumnName, DataControlRowType dcrtColumnType)
	{
		this.strColumnName = strColumnName;
		this.dcrtColumnType = dcrtColumnType;
	}

	public void InstantiateIn(Control ctlContainer)
	{
		switch (this.dcrtColumnType)
		{
		case DataControlRowType.Header:
		{
			HtmlInputCheckBox htmlInputCheckBox = new HtmlInputCheckBox();
			htmlInputCheckBox.Attributes["id"] = "cball";
			htmlInputCheckBox.Attributes["class"] = "cb1";
			htmlInputCheckBox.Attributes["onclick"] = "SltAllValue();";
			htmlInputCheckBox.Attributes["title"] = "全选/取消全选";
			ctlContainer.Controls.Add(htmlInputCheckBox);
			break;
		}
		case DataControlRowType.DataRow:
		{
			CheckBox checkBox = new CheckBox();
			checkBox.ID = "cb";
			checkBox.Checked = false;
			ctlContainer.Controls.Add(checkBox);
			break;
		}
		}
	}
}
