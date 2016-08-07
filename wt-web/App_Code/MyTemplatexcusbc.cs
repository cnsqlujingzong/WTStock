using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public class MyTemplatexcusbc : ITemplate
{
	private string strColumnName;

	private DataControlRowType dcrtColumnType;

	public MyTemplatexcusbc()
	{
	}

	public MyTemplatexcusbc(string strColumnName, DataControlRowType dcrtColumnType)
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
			Literal literal = new Literal();
			literal.Text = this.strColumnName;
			ctlContainer.Controls.Add(literal);
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
