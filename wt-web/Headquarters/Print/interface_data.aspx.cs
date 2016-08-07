using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using wt.DAL;
using wt.Library;
using wt.Model;

public partial class Headquarters_Print_interface_data : Page, IRequiresSessionState
{
	public struct FormulaInterval
	{
		public int start;

		public int end;

		public decimal price;
	}

	
	protected void Page_Load(object sender, EventArgs e)
	{
		string text = base.Request["type"];
		string text2 = base.Request["obj"];
		string text3 = base.Request["id"];
		string text4 = base.Request["ids"];
		text3 = FunLibrary.ChkInput(text3);
		text4 = FunLibrary.ChkInput(text4);
		int num = 0;
		int.TryParse(text3, out num);
		if (text == null || text == "" || text2 == null || text2 == "" || text3 == null)
		{
			base.Response.End();
		}
		DALSysParm dALSysParm = new DALSysParm();
		SysParmInfo sysParm = dALSysParm.GetSysParm();
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<xml xmlns:s='uuid:BDC6E3F0-6DA3-11d1-A2A3-00AA00C14882' \n");
		stringBuilder.Append("\txmlns:dt='uuid:C2F41010-65B3-11d1-A29F-00AA00C14882' \n");
		stringBuilder.Append("\txmlns:rs='urn:schemas-microsoft-com:rowset' \n");
		stringBuilder.Append("\txmlns:z='#RowsetSchema'> \n");
		if (text2.ToLower() == "rkd")
		{
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("     <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("     <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("     \t\t rs:basetable='StockIN' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("     <s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='Dept' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='DeptID' rs:number='3' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("     \t rs:basetable='StockIN' rs:basecolumn='DeptID'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='BillID' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='StockIN' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='c4' rs:name='_Date' rs:number='5' rs:nullable='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='OperatorID' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='StockIN' rs:basecolumn='OperatorID'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='PersonID' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='StockIN' rs:basecolumn='PersonID'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='ReasonID' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='StockIN' rs:basecolumn='ReasonID'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='Type' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='StockIN' rs:basecolumn='Type'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='OperationID' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='StockIN' rs:basecolumn='OperationID'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='Status' rs:number='11'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='6' rs:maybenull='false'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='ChkDate' rs:number='12' rs:nullable='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='ChkOperatorID' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='StockIN' rs:basecolumn='ChkOperatorID'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='Remark' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='StockIN' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='300'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='Operator' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='Person' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='Reason' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='INStockReason' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='ChkOperator' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='ReasonCode' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='INStockReason' rs:basecolumn='pyCode'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='25'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='c19' rs:name='ID' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='c20' rs:name='ID' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='c21' rs:name='ID' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='c22' rs:name='ID' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='c23' rs:name='ID' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='INStockReason' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("     </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable = DALCommon.GetDataList("ck_stockin", "", " [ID]=" + text3.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"      <z:row ID='1' Dept='",
					dataTable.Rows[0]["Dept"].ToString(),
					"' DeptID='1' BillID='",
					dataTable.Rows[0]["BillID"].ToString(),
					"' c4='",
					dataTable.Rows[0]["_Date"].ToString(),
					"' OperatorID='2' PersonID='2' ReasonID='9' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      Type='",
					dataTable.Rows[0]["Type"].ToString(),
					"' OperationID='",
					dataTable.Rows[0]["OperationID"].ToString(),
					"' Status='",
					dataTable.Rows[0]["Status"].ToString(),
					"' ChkDate='",
					dataTable.Rows[0]["ChkDate"].ToString(),
					"' ChkOperatorID='2' Remark='",
					dataTable.Rows[0]["Remark"].ToString(),
					"' Operator='",
					dataTable.Rows[0]["Operator"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      Person='",
					dataTable.Rows[0]["Person"].ToString(),
					"' Reason='",
					dataTable.Rows[0]["Reason"].ToString(),
					"' ChkOperator='",
					dataTable.Rows[0]["ChkOperator"].ToString(),
					"' ReasonCode='",
					dataTable.Rows[0]["ReasonCode"].ToString(),
					"' c19='1' c20='2' c21='2' c22='2' \n"
				}));
				stringBuilder.Append("      c23='9'/> \n");
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("<s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("rs:basetable='StockINDetail' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='StockID' rs:number='2' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("rs:basetable='StockINDetail' rs:basecolumn='StockID'> \n");
			stringBuilder.Append("<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='GoodsID' rs:number='3' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("rs:basetable='StockINDetail' rs:basecolumn='GoodsID'> \n");
			stringBuilder.Append("<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='UnitID' rs:number='4' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("rs:basetable='StockINDetail' rs:basecolumn='UnitID'> \n");
			stringBuilder.Append("<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='SNID' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("rs:baseschema='dbo' rs:basetable='StockINDetail' rs:basecolumn='SNID'> \n");
			stringBuilder.Append("<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Remark' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("rs:baseschema='dbo' rs:basetable='StockINDetail' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='GoodsNO' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='GoodsNO'> \n");
			stringBuilder.Append("<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c7' rs:name='_Name' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Spec' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='Spec'> \n");
			stringBuilder.Append("<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='MainTenancePeriod' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='MainTenancePeriod'> \n");
			stringBuilder.Append("<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='ProductBrand' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='StockName' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Unit' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='BillID' rs:number='14' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("rs:basetable='StockINDetail' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Qty' rs:number='15' rs:nullable='true'> \n");
			stringBuilder.Append("<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Price' rs:number='16' rs:nullable='true'> \n");
			stringBuilder.Append("<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Total' rs:number='17' rs:nullable='true'> \n");
			stringBuilder.Append("<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='SN' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("rs:baseschema='dbo' rs:basetable='StockINDetail' rs:basecolumn='SN'> \n");
			stringBuilder.Append("<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='8000'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c18' rs:name='ID' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c19' rs:name='ID' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c20' rs:name='ID' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("rs:baseschema='dbo' rs:basetable='GoodsUnit' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c21' rs:name='ID' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c22' rs:name='ID' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable2 = DALCommon.GetDataList("ck_stockindetail", "", " [BillID]=" + text3.ToString()).Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"<z:row ID='",
						dataTable2.Rows[i]["ID"].ToString(),
						"' StockID='",
						dataTable2.Rows[i]["StockID"].ToString(),
						"' GoodsID='",
						dataTable2.Rows[i]["GoodsID"].ToString(),
						"' UnitID='",
						dataTable2.Rows[i]["UnitID"].ToString(),
						"' SNID='",
						dataTable2.Rows[i]["SNID"].ToString(),
						"' Remark='",
						dataTable2.Rows[i]["Remark"].ToString(),
						"' GoodsNO='",
						dataTable2.Rows[i]["GoodsNO"].ToString(),
						"' c7='",
						dataTable2.Rows[i]["_Name"].ToString(),
						"' Spec='",
						dataTable2.Rows[i]["Spec"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						" MainTenancePeriod='",
						dataTable2.Rows[i]["MainTenancePeriod"].ToString(),
						"' ProductBrand='",
						dataTable2.Rows[i]["ProductBrand"].ToString(),
						"' StockName='",
						dataTable2.Rows[i]["StockName"].ToString(),
						"' Unit='",
						dataTable2.Rows[i]["Unit"].ToString(),
						"' BillID='",
						dataTable2.Rows[i]["BillID"].ToString(),
						"' Qty='",
						dataTable2.Rows[i]["Qty"].ToString(),
						"' Price='",
						dataTable2.Rows[i]["Price"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						" Total='",
						dataTable2.Rows[i]["Total"].ToString(),
						"' SN='",
						dataTable2.Rows[i]["SN"].ToString(),
						"' /> \n"
					}));
				}
			}
			stringBuilder.Append("     </rs:data> \n");
		}
		if (text2.ToLower() == "ckd")
		{
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append(" \t<s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append(" \t<s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append(" \t rs:basetable='StockOUT' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append(" \t</s:AttributeType> \n");
			stringBuilder.Append(" \t<s:AttributeType name='DeptID' rs:number='2' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append(" \t\t rs:basetable='StockOUT' rs:basecolumn='DeptID'> \n");
			stringBuilder.Append(" \t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append(" \t</s:AttributeType> \n");
			stringBuilder.Append(" \t<s:AttributeType name='Dept' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append(" \t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" \t</s:AttributeType> \n");
			stringBuilder.Append(" \t<s:AttributeType name='BillID' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t\t rs:baseschema='dbo' rs:basetable='StockOUT' rs:basecolumn='BillID'> \n");
			stringBuilder.Append(" \t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" \t</s:AttributeType> \n");
			stringBuilder.Append(" \t<s:AttributeType name='c4' rs:name='_Date' rs:number='5' rs:nullable='true'> \n");
			stringBuilder.Append(" \t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" \t</s:AttributeType> \n");
			stringBuilder.Append(" \t<s:AttributeType name='OperatorID' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t\t rs:baseschema='dbo' rs:basetable='StockOUT' rs:basecolumn='OperatorID'> \n");
			stringBuilder.Append(" \t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" \t</s:AttributeType> \n");
			stringBuilder.Append(" \t<s:AttributeType name='PersonID' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t\t rs:baseschema='dbo' rs:basetable='StockOUT' rs:basecolumn='PersonID'> \n");
			stringBuilder.Append(" \t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" \t</s:AttributeType> \n");
			stringBuilder.Append(" \t<s:AttributeType name='ReasonID' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t\t rs:baseschema='dbo' rs:basetable='StockOUT' rs:basecolumn='ReasonID'> \n");
			stringBuilder.Append(" \t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" \t</s:AttributeType> \n");
			stringBuilder.Append(" \t<s:AttributeType name='Type' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t\t rs:baseschema='dbo' rs:basetable='StockOUT' rs:basecolumn='Type'> \n");
			stringBuilder.Append(" \t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/> \n");
			stringBuilder.Append(" \t</s:AttributeType> \n");
			stringBuilder.Append(" \t<s:AttributeType name='OperationID' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t\t rs:baseschema='dbo' rs:basetable='StockOUT' rs:basecolumn='OperationID'> \n");
			stringBuilder.Append(" \t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" \t</s:AttributeType> \n");
			stringBuilder.Append(" \t<s:AttributeType name='ChkDate' rs:number='11' rs:nullable='true'> \n");
			stringBuilder.Append(" \t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" \t</s:AttributeType> \n");
			stringBuilder.Append(" \t<s:AttributeType name='ChkOperatorID' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t\t rs:baseschema='dbo' rs:basetable='StockOUT' rs:basecolumn='ChkOperatorID'> \n");
			stringBuilder.Append(" \t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" \t</s:AttributeType> \n");
			stringBuilder.Append(" \t<s:AttributeType name='Remark' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t\t rs:baseschema='dbo' rs:basetable='StockOUT' rs:basecolumn='Remark'> \n");
			stringBuilder.Append(" \t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='300'/> \n");
			stringBuilder.Append(" \t</s:AttributeType> \n");
			stringBuilder.Append(" \t<s:AttributeType name='Status' rs:number='14'> \n");
			stringBuilder.Append(" \t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='6' rs:maybenull='false'/> \n");
			stringBuilder.Append(" \t</s:AttributeType> \n");
			stringBuilder.Append(" \t<s:AttributeType name='Operator' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append(" \t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" \t</s:AttributeType> \n");
			stringBuilder.Append(" \t<s:AttributeType name='Person' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append(" \t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" \t</s:AttributeType> \n");
			stringBuilder.Append(" \t<s:AttributeType name='Reason' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t\t rs:baseschema='dbo' rs:basetable='OUTStockReason' rs:basecolumn='_Name'> \n");
			stringBuilder.Append(" \t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" \t</s:AttributeType> \n");
			stringBuilder.Append(" \t<s:AttributeType name='ChkOperator' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append(" \t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" \t</s:AttributeType> \n");
			stringBuilder.Append(" \t<s:AttributeType name='ReasonCode' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t\t rs:baseschema='dbo' rs:basetable='OUTStockReason' rs:basecolumn='pyCode'> \n");
			stringBuilder.Append(" \t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='25'/> \n");
			stringBuilder.Append(" \t</s:AttributeType> \n");
			stringBuilder.Append(" \t<s:AttributeType name='c19' rs:name='ID' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append(" \t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" \t</s:AttributeType> \n");
			stringBuilder.Append(" \t<s:AttributeType name='c20' rs:name='ID' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append(" \t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" \t</s:AttributeType> \n");
			stringBuilder.Append(" \t<s:AttributeType name='c21' rs:name='ID' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append(" \t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" \t</s:AttributeType> \n");
			stringBuilder.Append(" \t<s:AttributeType name='c22' rs:name='ID' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append(" \t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" \t</s:AttributeType> \n");
			stringBuilder.Append(" \t<s:AttributeType name='c23' rs:name='ID' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t\t rs:baseschema='dbo' rs:basetable='OUTStockReason' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append(" \t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("     </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable = DALCommon.GetDataList("ck_stockout", "", " [ID]=" + text3.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"     <z:row ID='1' DeptID='1' Dept='",
					dataTable.Rows[0]["Dept"].ToString(),
					"' BillID='",
					dataTable.Rows[0]["BillID"].ToString(),
					"' c4='",
					dataTable.Rows[0]["_Date"].ToString(),
					"' OperatorID='6' PersonID='6' ReasonID='6' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       Type='",
					dataTable.Rows[0]["Type"].ToString(),
					"' OperationID='",
					dataTable.Rows[0]["OperationID"].ToString(),
					"' ChkDate='",
					dataTable.Rows[0]["ChkDate"].ToString(),
					"' ChkOperatorID='6' Remark='",
					dataTable.Rows[0]["Remark"].ToString(),
					"' Status='",
					dataTable.Rows[0]["Status"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       Operator='",
					dataTable.Rows[0]["Operator"].ToString(),
					"' Person='",
					dataTable.Rows[0]["Person"].ToString(),
					"' Reason='",
					dataTable.Rows[0]["Reason"].ToString(),
					"' ChkOperator='",
					dataTable.Rows[0]["ChkOperator"].ToString(),
					"' ReasonCode='1' c19='1' c20='6' \n"
				}));
				stringBuilder.Append("       c21='6' c22='6' c23='6'/> \n");
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t   <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t \t rs:basetable='StockOUTDetail' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='StockID' rs:number='2' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t \t rs:basetable='StockOUTDetail' rs:basecolumn='StockID'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='GoodsID' rs:number='3' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t \t rs:basetable='StockOUTDetail' rs:basecolumn='GoodsID'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='UnitID' rs:number='4' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t \t rs:basetable='StockOUTDetail' rs:basecolumn='UnitID'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='SNID' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t \t rs:baseschema='dbo' rs:basetable='StockOUTDetail' rs:basecolumn='SNID'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='Remark' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t \t rs:baseschema='dbo' rs:basetable='StockOUTDetail' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='Qty' rs:number='7' rs:nullable='true'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='Price' rs:number='8' rs:nullable='true'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='Total' rs:number='9' rs:nullable='true'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='CostPrice' rs:number='10' rs:nullable='true'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='GoodsNO' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t  rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='GoodsNO'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='c11' rs:name='_Name' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t \t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='Spec' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t  rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='Spec'> \n");
			stringBuilder.Append("\t <s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='MainTenancePeriod' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t  rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='MainTenancePeriod'> \n");
			stringBuilder.Append("\t <s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='ProductBrand' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t  rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t <s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='StockName' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t  rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t <s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='SN' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t  rs:baseschema='dbo' rs:basetable='StockOUTDetail' rs:basecolumn='SN'> \n");
			stringBuilder.Append("\t <s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='8000'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='Unit' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t <s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='BillID' rs:number='19' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t  rs:basetable='StockOUTDetail' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t <s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='c19' rs:name='ID' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t  rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t <s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='c20' rs:name='ID' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t \t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t <s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='c21' rs:name='ID' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t  rs:baseschema='dbo' rs:basetable='GoodsUnit' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t <s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='c22' rs:name='ID' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t \t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t <s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='c23' rs:name='ID' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t \t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t \t</s:AttributeType> \n");
			stringBuilder.Append("\t <s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable2 = DALCommon.GetDataList("ck_stockoutdetail", "", " [BillID]=" + text3.ToString()).Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"<z:row ID='",
						dataTable2.Rows[i]["ID"].ToString(),
						"' StockID='",
						dataTable2.Rows[i]["StockID"].ToString(),
						"' GoodsID='",
						dataTable2.Rows[i]["GoodsID"].ToString(),
						"' UnitID='",
						dataTable2.Rows[i]["UnitID"].ToString(),
						"' SNID='",
						dataTable2.Rows[i]["SNID"].ToString(),
						"' Remark='",
						dataTable2.Rows[i]["Remark"].ToString(),
						"' GoodsNO='",
						dataTable2.Rows[i]["GoodsNO"].ToString(),
						"' c11='",
						dataTable2.Rows[i]["_Name"].ToString(),
						"' Spec='",
						dataTable2.Rows[i]["Spec"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						" MainTenancePeriod='",
						dataTable2.Rows[i]["MainTenancePeriod"].ToString(),
						"' ProductBrand='",
						dataTable2.Rows[i]["ProductBrand"].ToString(),
						"' StockName='",
						dataTable2.Rows[i]["StockName"].ToString(),
						"' Unit='",
						dataTable2.Rows[i]["Unit"].ToString(),
						"' BillID='",
						dataTable2.Rows[i]["BillID"].ToString(),
						"' Qty='",
						dataTable2.Rows[i]["Qty"].ToString(),
						"' Price='",
						dataTable2.Rows[i]["Price"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						" Total='",
						dataTable2.Rows[i]["Total"].ToString(),
						"' SN='",
						dataTable2.Rows[i]["SN"].ToString(),
						"' /> \n"
					}));
				}
			}
			stringBuilder.Append("     </rs:data> \n");
		}
		if (text2.ToLower() == "jcd")
		{
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append(" \t<s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append(" \t<s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo'\r\n\t\t\t rs:basetable='LendingReturn' rs:basecolumn='ID' rs:keycolumn='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='DeptID' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='LendingReturn' rs:basecolumn='DeptID'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='BillID' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='LendingReturn' rs:basecolumn='BillID'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c3' rs:name='_Date' rs:number='4' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Operator' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='iOperator' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='LendingReturn' rs:basecolumn='iOperator'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='iPerson' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='LendingReturn' rs:basecolumn='iPerson'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Person' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='CustomerID' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='LendingReturn' rs:basecolumn='CustomerID'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='LinkMan' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='LendingReturn' rs:basecolumn='LinkMan'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='CustomerName' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='CustomerList' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Tel' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='LendingReturn' rs:basecolumn='Tel'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='iStock' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='LendingReturn' rs:basecolumn='iStock'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='StockName' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='OperationID' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='LendingReturn' rs:basecolumn='OperationID'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='WDate' rs:number='16' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Deposit' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='LendingReturn' rs:basecolumn='Deposit'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Remark' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='LendingReturn' rs:basecolumn='Remark'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='500'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='curStatus' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='LendingReturn' rs:basecolumn='curStatus'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='ChkDate' rs:number='20' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='ChkOperator' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c21' rs:name='ID' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c22' rs:name='ID' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c23' rs:name='ID' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='CustomerList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c24' rs:name='ID' rs:number='25' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c25' rs:name='ID' rs:number='26' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("     </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable = DALCommon.GetDataList("ck_lendingreturn", "", " [ID]=" + text3.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"     <z:row ID='1' DeptID='",
					dataTable.Rows[0]["DeptID"].ToString(),
					"' BillID='",
					dataTable.Rows[0]["BillID"].ToString(),
					"' c3='",
					dataTable.Rows[0]["_Date"].ToString(),
					"' Operator='",
					dataTable.Rows[0]["Operator"].ToString(),
					"' iOperator='",
					dataTable.Rows[0]["iOperator"].ToString(),
					"' iPerson='",
					dataTable.Rows[0]["iPerson"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       Person='",
					dataTable.Rows[0]["Person"].ToString(),
					"' CustomerID='",
					dataTable.Rows[0]["CustomerID"].ToString(),
					"' LinkMan='",
					dataTable.Rows[0]["LinkMan"].ToString(),
					"' CustomerName='",
					dataTable.Rows[0]["CustomerName"].ToString(),
					"' Tel='",
					dataTable.Rows[0]["Tel"].ToString(),
					"' iStock='",
					dataTable.Rows[0]["iStock"].ToString(),
					"' StockName='",
					dataTable.Rows[0]["StockName"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       OperationID='",
					dataTable.Rows[0]["OperationID"].ToString(),
					"' WDate='",
					dataTable.Rows[0]["WDate"].ToString(),
					"' Deposit='",
					dataTable.Rows[0]["Deposit"].ToString(),
					"' Remark='",
					dataTable.Rows[0]["Remark"].ToString(),
					"' curStatus='",
					dataTable.Rows[0]["curStatus"].ToString(),
					"' ChkDate='",
					dataTable.Rows[0]["ChkDate"].ToString(),
					"' ChkOperator='",
					dataTable.Rows[0]["ChkOperator"].ToString(),
					"' \n"
				}));
				stringBuilder.Append("       c21='6' c22='6' c23='6'/> \n");
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t   <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo'\r\n\t\t\t rs:basetable='LendingReturnDetail' rs:basecolumn='ID' rs:keycolumn='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='BillID' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='LendingReturnDetail' rs:basecolumn='BillID'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='GoodsID' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='LendingReturnDetail' rs:basecolumn='GoodsID'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='UnitID' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='LendingReturnDetail' rs:basecolumn='UnitID'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Qty' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='LendingReturnDetail' rs:basecolumn='Qty'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='SN' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo'\r\n\t\t\t rs:basetable='LendingReturnDetail' rs:basecolumn='SN'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='5000'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Remark' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='LendingReturnDetail' rs:basecolumn='Remark'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='CostPrice' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='LendingReturnDetail' rs:basecolumn='CostPrice'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='GoodsNO' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='GoodsNO'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c9' rs:name='_Name' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Spec' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='Spec'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='ProductBrand' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Attr' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='Attr'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Unit' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Sequence' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='Sequence'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c14' rs:name='ID' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c15' rs:name='ID' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='GoodsUnit' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c16' rs:name='ID' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c17' rs:name='ID' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>");
			stringBuilder.Append("\t <s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable2 = DALCommon.GetDataList("ck_lendingreturndetail", "", " [BillID]=" + text3.ToString()).Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"<z:row ID='",
						dataTable2.Rows[i]["ID"].ToString(),
						"' BillID='",
						dataTable2.Rows[i]["BillID"].ToString(),
						"' GoodsID='",
						dataTable2.Rows[i]["GoodsID"].ToString(),
						"' UnitID='",
						dataTable2.Rows[i]["UnitID"].ToString(),
						"' Qty='",
						dataTable2.Rows[i]["Qty"].ToString(),
						"' SN='",
						dataTable2.Rows[i]["SN"].ToString(),
						"' Remark='",
						dataTable2.Rows[i]["Remark"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						" CostPrice='",
						dataTable2.Rows[i]["CostPrice"].ToString(),
						"' GoodsNO='",
						dataTable2.Rows[i]["GoodsNO"].ToString(),
						"' c9='",
						dataTable2.Rows[i]["_Name"].ToString(),
						"' Spec='",
						dataTable2.Rows[i]["Spec"].ToString(),
						"' ProductBrand='",
						dataTable2.Rows[i]["ProductBrand"].ToString(),
						"' Attr='",
						dataTable2.Rows[i]["Attr"].ToString(),
						"' Unit='",
						dataTable2.Rows[i]["Unit"].ToString(),
						"' c14='95' \n"
					}));
					stringBuilder.Append(" c15='95' c16='1' c17='4' Sequence='" + (i + 1) + "' /> \n");
				}
			}
			stringBuilder.Append("     </rs:data> \n");
		}
		if (text2.ToLower() == "dbd")
		{
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append(" \t<s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t\t    <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='Allocate' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BillID' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Allocate' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c2' rs:name='_Date' rs:number='3' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkDate' rs:number='4' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SndDate' rs:number='5' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SignedDate' rs:number='6' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SignedOper' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='PersonID' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Allocate' rs:basecolumn='PersonID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ToDeptID' rs:number='9' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='Allocate' rs:basecolumn='ToDept'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='FromDeptID' rs:number='10' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='Allocate' rs:basecolumn='FromDept'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Status' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Allocate' rs:basecolumn='Status'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='curStatus' rs:number='12'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='6' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Remark' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Allocate' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='1000'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ToDept' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='FromDept' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ToDeptNO' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='BranchNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ToDeptCode' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='pyCode'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='25'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='FromDeptNO' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='BranchNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='FromDeptCode' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='pyCode'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='25'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SndOper' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SndOperNO' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='JobNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkOperatorNO' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='JobNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkOperator' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='PersonNO' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='JobNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Person' rs:number='25' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c25' rs:name='ID' rs:number='26' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c26' rs:name='ID' rs:number='27' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c27' rs:name='ID' rs:number='28' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c28' rs:name='ID' rs:number='29' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c29' rs:name='ID' rs:number='30' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c30' rs:name='ID' rs:number='31' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c31' rs:name='ID' rs:number='32' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("     </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable = DALCommon.GetDataList("ck_allocate", "", " [ID]=" + text3.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"     <z:row ID='1' BillID='",
					dataTable.Rows[0]["BillID"].ToString(),
					"' c2='",
					dataTable.Rows[0]["_Date"].ToString(),
					"' PersonID='6' ToDeptID='1' FromDeptID='1' Status='1' curStatus='",
					dataTable.Rows[0]["curStatus"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      Remark='",
					dataTable.Rows[0]["Remark"].ToString(),
					"' ToDept='",
					dataTable.Rows[0]["ToDept"].ToString(),
					"' FromDept='",
					dataTable.Rows[0]["FromDept"].ToString(),
					"' ToDeptNO='",
					dataTable.Rows[0]["ToDeptNO"].ToString(),
					"' ToDeptCode='",
					dataTable.Rows[0]["ToDeptCode"].ToString(),
					"' FromDeptNO='",
					dataTable.Rows[0]["FromDeptNO"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"     FromDeptCode='",
					dataTable.Rows[0]["FromDeptCode"].ToString(),
					"' ChkDate='",
					dataTable.Rows[0]["ChkDate"].ToString(),
					"' PersonNO='",
					dataTable.Rows[0]["PersonNO"].ToString(),
					"' Person='",
					dataTable.Rows[0]["Person"].ToString(),
					"' c26='6' c28='1' c29='1'/> \n"
				}));
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t<s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t rs:basetable='AllocateDetail' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='BillID' rs:number='2' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t rs:basetable='AllocateDetail' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='GoodsID' rs:number='3' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t rs:basetable='AllocateDetail' rs:basecolumn='GoodsID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='UnitID' rs:number='4' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t rs:basetable='AllocateDetail' rs:basecolumn='UnitID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='AppQty' rs:number='5' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t rs:basetable='AllocateDetail' rs:basecolumn='AppQty'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true' \n");
			stringBuilder.Append("\t\t rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Price' rs:number='6' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t rs:basetable='AllocateDetail' rs:basecolumn='Price'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true' \n");
			stringBuilder.Append("\t\t rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Total' rs:number='7' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='SndQty' rs:number='8' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t rs:basetable='AllocateDetail' rs:basecolumn='SndQty'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true' \n");
			stringBuilder.Append("\t\t rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Totals' rs:number='9' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='RecQty' rs:number='10' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t rs:basetable='AllocateDetail' rs:basecolumn='RecQty'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true' \n");
			stringBuilder.Append("\t\t rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Totalr' rs:number='11' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Remark' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='AllocateDetail' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ErrorQty' rs:number='13' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ErrorTotal' rs:number='14' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='GoodsNO' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='GoodsNO'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c15' rs:name='_Name' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Spec' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='Spec'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ProductBrand' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Unit' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='MainTenancePeriod' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='MainTenancePeriod'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='SN' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='AllocateDetail' rs:basecolumn='SN'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='8000'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c21' rs:name='ID' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c22' rs:name='ID' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='GoodsUnit' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c23' rs:name='ID' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c24' rs:name='ID' rs:number='25' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable2 = DALCommon.GetDataList("ck_allocatedetail", "", " [BillID]=" + text3.ToString()).Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"<z:row ID='1' BillID='1' GoodsID='1' UnitID='1' AppQty='",
						dataTable2.Rows[i]["AppQty"].ToString(),
						"' Price='",
						dataTable2.Rows[i]["Price"].ToString(),
						"' Total='",
						dataTable2.Rows[i]["Total"].ToString(),
						"' SndQty='",
						dataTable2.Rows[i]["SndQty"].ToString(),
						"' Totals='",
						dataTable2.Rows[i]["Totals"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"RecQty='",
						dataTable2.Rows[i]["RecQty"].ToString(),
						"' Totalr='",
						dataTable2.Rows[i]["Totalr"].ToString(),
						"' Remark='",
						dataTable2.Rows[i]["Remark"].ToString(),
						"' ErrorQty='",
						dataTable2.Rows[i]["ErrorQty"].ToString(),
						"' ErrorTotal='",
						dataTable2.Rows[i]["ErrorTotal"].ToString(),
						"' GoodsNO='",
						dataTable2.Rows[i]["GoodsNO"].ToString(),
						"' c15='",
						dataTable2.Rows[i]["_Name"].ToString(),
						"' Spec='",
						dataTable2.Rows[i]["Spec"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"ProductBrand='",
						dataTable2.Rows[i]["ProductBrand"].ToString(),
						"' Unit='",
						dataTable2.Rows[i]["Unit"].ToString(),
						"' MainTenancePeriod='",
						dataTable2.Rows[i]["MainTenancePeriod"].ToString(),
						"' SN='",
						dataTable2.Rows[i]["SN"].ToString(),
						"' c20='1' c21='1' c22='19' c23='13'/> \n"
					}));
				}
			}
			stringBuilder.Append("     </rs:data> \n");
		}
		if (text2.ToLower() == "ltd")
		{
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append(" \t<s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t\t   <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='BroughtBack' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BillID' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BroughtBack' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DeptID' rs:number='3' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='BroughtBack' rs:basecolumn='DeptID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Dept' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c4' rs:name='_Date' rs:number='5' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Person' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='AppOperator' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkOperator' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Type' rs:number='9'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='4' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Status' rs:number='10'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='6' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkDate' rs:number='11' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Remark' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BroughtBack' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='300'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CustomerName' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BroughtBack' rs:basecolumn='CustomerName'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='300'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c12' rs:name='ID' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c13' rs:name='ID' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c14' rs:name='ID' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c15' rs:name='ID' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("     </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable = DALCommon.GetDataList("ck_broughtback", "", " [ID]=" + text3.ToString()).Tables[0];
			DataTable dataTable2 = DALCommon.GetDataList("ck_broughtbackdetail", "", " [BillID]=" + text3.ToString()).Tables[0];
			string text5 = string.Empty;
			for (int i = 0; i < dataTable2.Rows.Count; i++)
			{
				string text6 = dataTable2.Rows[i]["CustomerName"].ToString().Trim();
				if (!text6.Equals("") && !text5.Contains(text6 + ","))
				{
					text5 = text5 + text6 + ",";
				}
			}
			text5 = text5.Trim(new char[]
			{
				','
			});
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"     <z:row ID='1' BillID='",
					dataTable.Rows[0]["BillID"].ToString(),
					"' DeptID='1' Dept='",
					dataTable.Rows[0]["Dept"].ToString(),
					"' c4='",
					dataTable.Rows[0]["_Date"].ToString(),
					"' Person='",
					dataTable.Rows[0]["Person"].ToString(),
					"' ChkDate='",
					dataTable.Rows[0]["ChkDate"].ToString(),
					"' AppOperator='",
					dataTable.Rows[0]["AppOperator"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"     Type='",
					dataTable.Rows[0]["Type"].ToString(),
					"' Status='",
					dataTable.Rows[0]["Status"].ToString(),
					"' Remark='",
					dataTable.Rows[0]["Remark"].ToString(),
					"' CustomerName='",
					text5,
					"' c12='1' c13='6' c14='6'/> \n"
				}));
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t<s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t rs:basetable='BroughtBackDetail' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='BillID' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='BroughtBackDetail' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='StockName' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='StockID' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='BroughtBackDetail' rs:basecolumn='StockID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='GoodsID' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='BroughtBackDetail' rs:basecolumn='GoodsID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='GoodsNO' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='GoodsNO'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c6' rs:name='_Name' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Spec' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='Spec'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ProductBrand' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Unit' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='UnitID' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='BroughtBackDetail' rs:basecolumn='UnitID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Qty' rs:number='12' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Price' rs:number='13' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Total' rs:number='14' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Remark' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='BroughtBackDetail' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='OperationID' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='BroughtBackDetail' rs:basecolumn='OperationID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='MaintenancePeriod' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='ServicesMaterial' rs:basecolumn='MaintenancePeriod'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='PeriodEndDate' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='ServicesMaterial' rs:basecolumn='PeriodEndDate'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='CostPrice' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='BroughtBackDetail' rs:basecolumn='CostPrice'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='CiteID' rs:number='20'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='SN' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='BroughtBackDetail' rs:basecolumn='SN'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='8000'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c21' rs:name='ID' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c22' rs:name='ID' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c23' rs:name='ID' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='GoodsUnit' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c24' rs:name='ID' rs:number='25' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c25' rs:name='ID' rs:number='26' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c26' rs:name='ID' rs:number='27' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='ServicesMaterial' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"<z:row ID='1' BillID='1' StockName='",
						dataTable2.Rows[i]["StockName"].ToString(),
						"' StockID='4' GoodsID='9' GoodsNO='",
						dataTable2.Rows[i]["GoodsNO"].ToString(),
						"' c6='",
						dataTable2.Rows[i]["_Name"].ToString(),
						"' Spec='",
						dataTable2.Rows[i]["Spec"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						" ProductBrand='",
						dataTable2.Rows[i]["ProductBrand"].ToString(),
						"' Unit='",
						dataTable2.Rows[i]["Unit"].ToString(),
						"' UnitID='10' Qty='",
						dataTable2.Rows[i]["Qty"].ToString(),
						"' Price='",
						dataTable2.Rows[i]["Price"].ToString(),
						"' Total='",
						dataTable2.Rows[i]["Total"].ToString(),
						"' Remark='",
						dataTable2.Rows[i]["Remark"].ToString(),
						"' OperationID='",
						dataTable2.Rows[i]["OperationID"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"MaintenancePeriod='",
						dataTable2.Rows[i]["MaintenancePeriod"].ToString(),
						"' PeriodEndDate='",
						dataTable2.Rows[i]["PeriodEndDate"].ToString(),
						"' SN='",
						dataTable2.Rows[i]["SN"].ToString(),
						"' CostPrice='",
						dataTable2.Rows[i]["CostPrice"].ToString(),
						"' CiteID='1' c20='4' c21='9' c22='10' \n"
					}));
					stringBuilder.Append(" c23='1' c24='20' c25='1'/> \n");
				}
			}
			stringBuilder.Append("     </rs:data> \n");
		}
		if (text2.ToLower() == "czd")
		{
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append(" \t<s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t\t    <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='Disassembling' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BillID' rs:number='2' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='Disassembling' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DeptID' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Disassembling' rs:basecolumn='DeptID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='OperatorID' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Disassembling' rs:basecolumn='OperatorID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='PersonID' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Disassembling' rs:basecolumn='PersonID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Type' rs:number='6'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='4' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c6' rs:name='_Date' rs:number='7' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkDate' rs:number='8' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Status' rs:number='9'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='6' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkOperatorID' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Disassembling' rs:basecolumn='ChkOperatorID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='StockID' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Disassembling' rs:basecolumn='StockID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='GoodsID' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Disassembling' rs:basecolumn='GoodsID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='UnitID' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Disassembling' rs:basecolumn='UnitID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Qty' rs:number='14' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Price' rs:number='15' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Remark' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Disassembling' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='300'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='OperatorNO' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='JobNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Operator' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='PersonNO' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='JobNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Person' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkOperatorNO' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='JobNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkOperator' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='StockName' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='GoodsNO' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='GoodsNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c24' rs:name='_Name' rs:number='25' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Spec' rs:number='26' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='Spec'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ProductBrand' rs:number='27' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Unit' rs:number='28' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c28' rs:name='ID' rs:number='29' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c29' rs:name='ID' rs:number='30' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c30' rs:name='ID' rs:number='31' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c31' rs:name='ID' rs:number='32' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c32' rs:name='ID' rs:number='33' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c33' rs:name='ID' rs:number='34' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='GoodsUnit' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c34' rs:name='ID' rs:number='35' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c35' rs:name='ID' rs:number='36' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c36' rs:name='ID' rs:number='37' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c37' rs:name='ID' rs:number='38' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='SupplierList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("     </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable = DALCommon.GetDataList("ck_disassembling", "", " [ID]=" + text3.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"     <z:row ID='1' BillID='",
					dataTable.Rows[0]["BillID"].ToString(),
					"' DeptID='1' OperatorID='6' PersonID='6' Type='",
					dataTable.Rows[0]["Type"].ToString(),
					"' c6='",
					dataTable.Rows[0]["_Date"].ToString(),
					"' Status='",
					dataTable.Rows[0]["Status"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"     StockID='4' GoodsID='10' UnitID='11' Qty='",
					dataTable.Rows[0]["Qty"].ToString(),
					"' Price='",
					dataTable.Rows[0]["Price"].ToString(),
					"' Remark='",
					dataTable.Rows[0]["Remark"].ToString(),
					"' OperatorNO='",
					dataTable.Rows[0]["OperatorNO"].ToString(),
					"' Operator='",
					dataTable.Rows[0]["Operator"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      PersonNO='",
					dataTable.Rows[0]["PersonNO"].ToString(),
					"' Person='",
					dataTable.Rows[0]["Person"].ToString(),
					"' StockName='",
					dataTable.Rows[0]["StockName"].ToString(),
					"' GoodsNO='",
					dataTable.Rows[0]["GoodsNO"].ToString(),
					"' c24='",
					dataTable.Rows[0]["_Name"].ToString(),
					"' Spec='",
					dataTable.Rows[0]["Spec"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      ProductBrand='",
					dataTable.Rows[0]["ProductBrand"].ToString(),
					"' Unit='",
					dataTable.Rows[0]["Unit"].ToString(),
					"' c28='4' c29='10' c31='6' c32='6' c33='11' c34='1' c35='15' c36='4' c37='10'/> \n"
				}));
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t<s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t rs:basetable='DisassemblingDetail' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='StockID' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='DisassemblingDetail' rs:basecolumn='StockID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='GoodsID' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='DisassemblingDetail' rs:basecolumn='GoodsID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='UnitID' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='DisassemblingDetail' rs:basecolumn='UnitID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Remark' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='DisassemblingDetail' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='GoodsNO' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='GoodsNO'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c6' rs:name='_Name' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Spec' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='Spec'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='MainTenancePeriod' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='MainTenancePeriod'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ProductBrand' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='StockName' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Unit' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='BillID' rs:number='13' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t rs:basetable='DisassemblingDetail' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Qty' rs:number='14' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Price' rs:number='15' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Total' rs:number='16' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c16' rs:name='ID' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c17' rs:name='ID' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c18' rs:name='ID' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='GoodsUnit' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c19' rs:name='ID' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c20' rs:name='ID' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable2 = DALCommon.GetDataList("ck_disassemblingdetail", "", " [BillID]=" + text3.ToString()).Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"<z:row ID='1' StockID='7' GoodsID='6' UnitID='6' Remark='",
						dataTable2.Rows[i]["Remark"].ToString(),
						"' GoodsNO='",
						dataTable2.Rows[i]["GoodsNO"].ToString(),
						"' c6='",
						dataTable2.Rows[i]["_Name"].ToString(),
						"' Spec='",
						dataTable2.Rows[i]["Spec"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"MainTenancePeriod='",
						dataTable2.Rows[i]["MainTenancePeriod"].ToString(),
						"' ProductBrand='",
						dataTable2.Rows[i]["ProductBrand"].ToString(),
						"' StockName='",
						dataTable2.Rows[i]["StockName"].ToString(),
						"' Unit='",
						dataTable2.Rows[i]["Unit"].ToString(),
						"' BillID='1' Qty='",
						dataTable2.Rows[i]["Qty"].ToString(),
						"' Price='",
						dataTable2.Rows[i]["Price"].ToString(),
						"' \n"
					}));
					stringBuilder.Append("Total='" + dataTable2.Rows[i]["Total"].ToString() + "' c16='7' c17='6' c18='6' c19='1' c20='9'/> \n");
				}
			}
			stringBuilder.Append("     </rs:data> \n");
		}
		if (text2.ToLower() == "tjd")
		{
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append(" \t<s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t\t    <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='Regulate' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DeptID' rs:number='2' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='Regulate' rs:basecolumn='DeptID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BillID' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Regulate' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c3' rs:name='_Date' rs:number='4' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkDate' rs:number='5' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Status' rs:number='6'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='6' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Remark' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Regulate' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='200'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Person' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Operator' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkOperator' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='StockName' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Dept' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c12' rs:name='ID' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c13' rs:name='ID' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c14' rs:name='ID' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c15' rs:name='ID' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c16' rs:name='ID' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("     </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable = DALCommon.GetDataList("ck_regulage", "", " [ID]=" + text3.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"     <z:row ID='1' DeptID='1' BillID='",
					dataTable.Rows[0]["BillID"].ToString(),
					"' c3='",
					dataTable.Rows[0]["_Date"].ToString(),
					"' Status='",
					dataTable.Rows[0]["Status"].ToString(),
					"' Remark='",
					dataTable.Rows[0]["Remark"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"     Person='",
					dataTable.Rows[0]["Person"].ToString(),
					"' Operator='",
					dataTable.Rows[0]["Operator"].ToString(),
					"' StockName='",
					dataTable.Rows[0]["StockName"].ToString(),
					"' Dept='",
					dataTable.Rows[0]["Dept"].ToString(),
					"' c12='6' c13='6' c14='4' c16='1'/> \n"
				}));
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("<s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t rs:basetable='RegulateDetail' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='GoodsID' rs:number='2' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t rs:basetable='RegulateDetail' rs:basecolumn='GoodsID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Remark' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='RegulateDetail' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Qty' rs:number='4' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Price' rs:number='5' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Total' rs:number='6' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='GoodsNO' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='GoodsNO'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c7' rs:name='_Name' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Spec' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='Spec'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='ProductBrand' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='BillID' rs:number='11' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t rs:basetable='RegulateDetail' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='RegulatePrice' rs:number='12' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='RegulateTotal' rs:number='13' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c13' rs:name='ID' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c14' rs:name='ID' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable2 = DALCommon.GetDataList("ck_regulatedetail", "", " [BillID]=" + text3.ToString()).Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"<z:row ID='1' GoodsID='10' Remark='",
						dataTable2.Rows[i]["Remark"].ToString(),
						"' Qty='",
						dataTable2.Rows[i]["Qty"].ToString(),
						"' Price='",
						dataTable2.Rows[i]["Price"].ToString(),
						"' Total='",
						dataTable2.Rows[i]["Total"].ToString(),
						"' GoodsNO='",
						dataTable2.Rows[i]["GoodsNO"].ToString(),
						"' c7='",
						dataTable2.Rows[i]["_Name"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"Spec='",
						dataTable2.Rows[i]["Spec"].ToString(),
						"' ProductBrand='",
						dataTable2.Rows[i]["ProductBrand"].ToString(),
						"' BillID='1' RegulatePrice='",
						dataTable2.Rows[i]["RegulatePrice"].ToString(),
						"' RegulateTotal='",
						dataTable2.Rows[i]["RegulateTotal"].ToString(),
						"' c13='10' c14='1'/> \n"
					}));
				}
			}
			stringBuilder.Append("     </rs:data> \n");
		}
		if (text2.ToLower() == "pdd")
		{
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append(" \t<s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t\t     <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='StockCheck' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BillID' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StockCheck' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BranchNO' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='BranchNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Dept' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DeptID' rs:number='5' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='StockCheck' rs:basecolumn='DeptID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='OperatorID' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StockCheck' rs:basecolumn='OperatorID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='OperatorNO' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='JobNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Operator' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='StockID' rs:number='9' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='StockCheck' rs:basecolumn='StockID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='StockName' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkOperatorID' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StockCheck' rs:basecolumn='ChkOperatorID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Remark' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StockCheck' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='300'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkOperatorNO' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='JobNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c13' rs:name='_Date' rs:number='14' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkDate' rs:number='15' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Status' rs:number='16'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='6' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkOperator' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c17' rs:name='ID' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c18' rs:name='ID' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c19' rs:name='ID' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c20' rs:name='ID' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("     </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable = DALCommon.GetDataList("ck_stockcheck", "", " [ID]=" + text3.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"<z:row ID='1' BillID='",
					dataTable.Rows[0]["BillID"].ToString(),
					"' BranchNO='",
					dataTable.Rows[0]["BranchNO"].ToString(),
					"' Dept='",
					dataTable.Rows[0]["Dept"].ToString(),
					"' DeptID='1' OperatorID='6' OperatorNO='",
					dataTable.Rows[0]["OperatorNO"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"Operator='",
					dataTable.Rows[0]["Operator"].ToString(),
					"' StockID='4' StockName='",
					dataTable.Rows[0]["StockName"].ToString(),
					"' Remark='",
					dataTable.Rows[0]["Remark"].ToString(),
					"' c13='",
					dataTable.Rows[0]["_Date"].ToString(),
					"' Status='",
					dataTable.Rows[0]["Status"].ToString(),
					"' ChkDate='",
					dataTable.Rows[0]["ChkDate"].ToString(),
					"' ChkOperator='",
					dataTable.Rows[0]["ChkOperator"].ToString(),
					"' c17='1' \n"
				}));
				stringBuilder.Append("c18='6' c20='4'/> \n");
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t<s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t rs:basetable='StockCheckDetail' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='BillID' rs:number='2' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t rs:basetable='StockCheckDetail' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='GoodsID' rs:number='3' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t rs:basetable='StockCheckDetail' rs:basecolumn='GoodsID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='StockLocID' rs:number='4'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Stock' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='StockCheckDetail' rs:basecolumn='Stock'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Qty' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='StockCheckDetail' rs:basecolumn='Qty'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='YKQty' rs:number='7' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='19' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Remark' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='StockCheckDetail' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='GoodsNO' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='GoodsNO'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c9' rs:name='_Name' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Spec' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='Spec'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ProductBrand' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='StockLoc' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='StockLocation' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c13' rs:name='ID' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c14' rs:name='ID' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='StockLocation' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c15' rs:name='ID' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable2 = DALCommon.GetDataList("ck_stockcheckdetail", "", " [BillID]=" + text3.ToString()).Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"<z:row ID='1' BillID='1' GoodsID='9' StockLocID='0' StockLoc='",
						dataTable2.Rows[i]["StockLoc"].ToString(),
						"' Stock='",
						dataTable2.Rows[i]["Stock"].ToString(),
						"' Qty='",
						dataTable2.Rows[i]["Qty"].ToString(),
						"' YKQty='",
						dataTable2.Rows[i]["YKQty"].ToString(),
						"' Remark='",
						dataTable2.Rows[i]["Remark"].ToString(),
						"' GoodsNO='",
						dataTable2.Rows[i]["GoodsNO"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"c9='",
						dataTable2.Rows[i]["_Name"].ToString(),
						"' Spec='",
						dataTable2.Rows[i]["Spec"].ToString(),
						"' ProductBrand='",
						dataTable2.Rows[i]["ProductBrand"].ToString(),
						"' c13='9' c15='20'/> \n"
					}));
				}
			}
			stringBuilder.Append("     </rs:data> \n");
		}
		if (text2.ToLower() == "cgd")
		{
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append(" \t<s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append(" <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("  rs:basetable='Purchase' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append(" <s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='DeptID' rs:number='2' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append(" \t rs:basetable='Purchase' rs:basecolumn='DeptID'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='Dept' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='BillID' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='Purchase' rs:basecolumn='BillID'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='Type' rs:number='5'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='4' rs:maybenull='false'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='c5' rs:name='_Date' rs:number='6' rs:nullable='true'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='OperatorID' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='Purchase' rs:basecolumn='OperatorID'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='ProvID' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='Purchase' rs:basecolumn='ProvID'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='StockID' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='Purchase' rs:basecolumn='StockID'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='ChkDate' rs:number='10' rs:nullable='true'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='ChkOperatorID' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='Purchase' rs:basecolumn='ChkOperatorID'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='Status' rs:number='12'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='6' rs:maybenull='false'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='Remark' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='Purchase' rs:basecolumn='Remark'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='300'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='OperatorNO' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='JobNO'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='Operator' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='SupNO' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='SupplierList' rs:basecolumn='SupNO'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='Provider' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='SupplierList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='StockName' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='ChkOperatorNO' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='JobNO'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='InCash' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='Purchase' rs:basecolumn='InCash'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='ChkOperator' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='ProviderCode' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='SupplierList' rs:basecolumn='pyCode'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='25'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='OperationID' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='Purchase' rs:basecolumn='OperationID'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='Total' rs:number='24' rs:nullable='true'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='4' rs:precision='18' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='GoodsAmount' rs:number='25' rs:nullable='true'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='4' rs:precision='18' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='LinkMan' rs:number='31' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='SupplierList' rs:basecolumn='LinkMan'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='Tel' rs:number='32' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='SupplierList' rs:basecolumn='Tel'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='InCashCh' rs:number='33' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='Purchase' rs:basecolumn='InCashCh'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='Adr' rs:number='34' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='SupplierList' rs:basecolumn='Tel'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='200'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='c25' rs:name='ID' rs:number='26' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='c26' rs:name='ID' rs:number='27' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='c27' rs:name='ID' rs:number='28' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='c28' rs:name='ID' rs:number='29' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='SupplierList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='c29' rs:name='ID' rs:number='30' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("     </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable = DALCommon.GetDataList("cg_purchase", "", " [ID]=" + text3.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"     <z:row ID='2' DeptID='1' BillID='",
					dataTable.Rows[0]["BillID"].ToString(),
					"' Type='",
					dataTable.Rows[0]["Type"].ToString(),
					"' c5='",
					dataTable.Rows[0]["_Date"].ToString(),
					"' OperatorID='6' ProvID='14' StockID='4' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"     ChkDate='",
					dataTable.Rows[0]["ChkDate"].ToString(),
					"' ChkOperatorID='6' Status='",
					dataTable.Rows[0]["Status"].ToString(),
					"' Remark='",
					dataTable.Rows[0]["Remark"].ToString(),
					"' OperatorNO='",
					dataTable.Rows[0]["OperatorNO"].ToString(),
					"' Operator='",
					dataTable.Rows[0]["Operator"].ToString(),
					"' SupNO='",
					dataTable.Rows[0]["SupNO"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"     Provider='",
					dataTable.Rows[0]["Provider"].ToString(),
					"' StockName='",
					dataTable.Rows[0]["StockName"].ToString(),
					"' ChkOperatorNO='",
					dataTable.Rows[0]["ChkOperatorNO"].ToString(),
					"' ChkOperator='",
					dataTable.Rows[0]["ChkOperator"].ToString(),
					"'   ProviderCode='",
					dataTable.Rows[0]["ProviderCode"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"     LinkMan='",
					dataTable.Rows[0]["LinkMan"].ToString(),
					"' Tel='",
					dataTable.Rows[0]["Tel"].ToString(),
					"' Adr='",
					dataTable.Rows[0]["Adr"].ToString(),
					"'  OperationID='",
					dataTable.Rows[0]["OperationID"].ToString(),
					"' Total='",
					dataTable.Rows[0]["Total"].ToString(),
					"' GoodsAmount='",
					dataTable.Rows[0]["GoodsAmount"].ToString(),
					"' InCash='",
					dataTable.Rows[0]["InCash"].ToString(),
					"' InCashCh='",
					FunLibrary.NumChs(dataTable.Rows[0]["InCash"].ToString(), 2),
					"' c21='6' c22='6' c23='4' c24='14'/> \n"
				}));
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("<s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t rs:basetable='PurchaseDetail' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='BillID' rs:number='2' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t rs:basetable='PurchaseDetail' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='GoodsID' rs:number='3' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t rs:basetable='PurchaseDetail' rs:basecolumn='GoodsID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='UnitID' rs:number='4' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t rs:basetable='PurchaseDetail' rs:basecolumn='UnitID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Qty' rs:number='5' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Price' rs:number='6' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Total' rs:number='7' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Remark' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='PurchaseDetail' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='GoodsNO' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='GoodsNO'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c9' rs:name='_Name' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Spec' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='Spec'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='ProductBrand' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='MainTenancePeriod' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='MainTenancePeriod'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Unit' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='SN' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='PurchaseDetail' rs:basecolumn='SN'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='8000'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='TaxRate' rs:number='16' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='TaxAmount' rs:number='17' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='GoodsAmount' rs:number='18' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c18' rs:name='ID' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c19' rs:name='ID' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='GoodsUnit' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c20' rs:name='ID' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c21' rs:name='ID' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable2 = DALCommon.GetDataList("cg_purchasedetail", "", " [BillID]=" + text3.ToString()).Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"<z:row ID='1' BillID='1' GoodsID='3' UnitID='3' Qty='",
						dataTable2.Rows[i]["Qty"].ToString(),
						"' Price='",
						dataTable2.Rows[i]["Price"].ToString(),
						"' Total='",
						dataTable2.Rows[i]["Total"].ToString(),
						"' Remark='",
						dataTable2.Rows[i]["Remark"].ToString(),
						"' GoodsNO='",
						dataTable2.Rows[i]["GoodsNO"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						" c9=\"",
						dataTable2.Rows[i]["_Name"].ToString(),
						"\" Spec='",
						dataTable2.Rows[i]["Spec"].ToString(),
						"' ProductBrand='",
						dataTable2.Rows[i]["ProductBrand"].ToString(),
						"' MainTenancePeriod='",
						dataTable2.Rows[i]["MainTenancePeriod"].ToString(),
						"' Unit='",
						dataTable2.Rows[i]["Unit"].ToString(),
						"' SN='",
						dataTable2.Rows[i]["SN"].ToString(),
						"' c14='3' c15='3' c16='13' \n"
					}));
					stringBuilder.Append("c17='10'/> \n");
				}
			}
			stringBuilder.Append("     </rs:data> \n");
		}
		if (text2.ToLower() == "cgdd")
		{
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append(" \t<s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t\t     <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='PurchasePlan' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DeptID' rs:number='2' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='PurchasePlan' rs:basecolumn='DeptID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BillID' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='PurchasePlan' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c3' rs:name='_Date' rs:number='4' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='OperatorID' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='PurchasePlan' rs:basecolumn='OperatorID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ProvID' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='PurchasePlan' rs:basecolumn='ProvID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='StockID' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='PurchasePlan' rs:basecolumn='StockID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkDate' rs:number='8' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkOperatorID' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='PurchasePlan' rs:basecolumn='ChkOperatorID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Status' rs:number='10'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='6' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Remark' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='PurchasePlan' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='300'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='OperatorNO' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='JobNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Operator' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SupNO' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='SupplierList' rs:basecolumn='SupNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Provider' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='SupplierList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='StockName' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkOperatorNO' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='JobNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkOperator' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ProviderCode' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='SupplierList' rs:basecolumn='pyCode'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='25'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='LinkMan' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t    rs:baseschema='dbo' rs:basetable='SupplierList' rs:basecolumn='LinkMan'> \n");
			stringBuilder.Append(" \t    <s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='Tel' rs:number='25' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t    rs:baseschema='dbo' rs:basetable='SupplierList' rs:basecolumn='Tel'> \n");
			stringBuilder.Append(" \t    <s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='Adr' rs:number='26' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='SupplierList' rs:basecolumn='Tel'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='200'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c19' rs:name='ID' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c20' rs:name='ID' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c21' rs:name='ID' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c22' rs:name='ID' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='SupplierList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("     </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable = DALCommon.GetDataList("cg_purchaseplan", "", " [ID]=" + text3.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"     <z:row ID='1' DeptID='1' BillID='",
					dataTable.Rows[0]["BillID"].ToString(),
					"' c3='",
					dataTable.Rows[0]["_Date"].ToString(),
					"' OperatorID='6' ProvID='14' StockID='4' ChkDate='",
					dataTable.Rows[0]["ChkDate"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"     ChkOperatorID='6' Status='",
					dataTable.Rows[0]["Status"].ToString(),
					"' Remark='",
					dataTable.Rows[0]["Remark"].ToString(),
					"' OperatorNO='",
					dataTable.Rows[0]["OperatorNO"].ToString(),
					"' Operator='",
					dataTable.Rows[0]["Operator"].ToString(),
					"' SupNO='",
					dataTable.Rows[0]["SupNO"].ToString(),
					"' Provider='",
					dataTable.Rows[0]["Provider"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"     StockName='",
					dataTable.Rows[0]["StockName"].ToString(),
					"' ChkOperatorNO='",
					dataTable.Rows[0]["ChkOperatorNO"].ToString(),
					"' ChkOperator='",
					dataTable.Rows[0]["ChkOperator"].ToString(),
					"' ProviderCode='",
					dataTable.Rows[0]["ProviderCode"].ToString(),
					"' c19='6' c20='6' c21='4' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"     LinkMan='",
					dataTable.Rows[0]["LinkMan"].ToString(),
					"' Tel='",
					dataTable.Rows[0]["Tel"].ToString(),
					"' Adr='",
					dataTable.Rows[0]["Adr"].ToString(),
					"' c22='14'/> \n"
				}));
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t \t rs:basetable='PurchasePlanDetail' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='BillID' rs:number='2' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t \t rs:basetable='PurchasePlanDetail' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='GoodsID' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t \t rs:baseschema='dbo' rs:basetable='PurchasePlanDetail' rs:basecolumn='GoodsID'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='UnitID' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t \t rs:baseschema='dbo' rs:basetable='PurchasePlanDetail' rs:basecolumn='UnitID'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='Qty' rs:number='5' rs:nullable='true'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='PurQty' rs:number='6' rs:nullable='true'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='Price' rs:number='7' rs:nullable='true'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='Total' rs:number='8' rs:nullable='true'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='Remark' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t \t rs:baseschema='dbo' rs:basetable='PurchasePlanDetail' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='GoodsNO' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t \t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='GoodsNO'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='c10' rs:name='_Name' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t \t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='Spec' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t \t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='Spec'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='ProductBrand' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t \t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='MainTenancePeriod' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t \t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='MainTenancePeriod'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Unit' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t \t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='TaxRate' rs:number='16' rs:nullable='true'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='TaxAmount' rs:number='17' rs:nullable='true'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='GoodsAmount' rs:number='18' rs:nullable='true'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='c18' rs:name='ID' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t \t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='c19' rs:name='ID' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t \t rs:baseschema='dbo' rs:basetable='GoodsUnit' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='c20' rs:name='ID' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t \t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:AttributeType name='c21' rs:name='ID' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t \t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t </s:AttributeType> \n");
			stringBuilder.Append("\t <s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable2 = DALCommon.GetDataList("cg_purchaseplandetail", "", " [BillID]=" + text3.ToString()).Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"<z:row ID='1' BillID='1' GoodsID='10' UnitID='11' Qty='",
						dataTable2.Rows[i]["Qty"].ToString(),
						"' PurQty='",
						dataTable2.Rows[i]["PurQty"].ToString(),
						"' Price='",
						dataTable2.Rows[i]["Price"].ToString(),
						"' Total='",
						dataTable2.Rows[i]["Total"].ToString(),
						"' Remark='",
						dataTable2.Rows[i]["Remark"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"GoodsNO='",
						dataTable2.Rows[i]["GoodsNO"].ToString(),
						"' c10='",
						dataTable2.Rows[i]["_Name"].ToString(),
						"' Spec='",
						dataTable2.Rows[i]["Spec"].ToString(),
						"' ProductBrand='",
						dataTable2.Rows[i]["ProductBrand"].ToString(),
						"' MainTenancePeriod='",
						dataTable2.Rows[i]["MainTenancePeriod"].ToString(),
						"' Unit='",
						dataTable2.Rows[i]["Unit"].ToString(),
						"' c15='10' \n"
					}));
					stringBuilder.Append("c16='11' c17='1' c18='15'/> \n");
				}
			}
			stringBuilder.Append("     </rs:data> \n");
		}
		if (text2.ToLower() == "xsd")
		{
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("     <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("<s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t rs:basetable='Sell' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='DeptID' rs:number='2' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t rs:basetable='Sell' rs:basecolumn='DeptID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='BillID' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Sell' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Type' rs:number='4'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='4' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c4' rs:name='_Date' rs:number='5' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='ChkDate' rs:number='6' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Status' rs:number='7'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='6' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='OperatorID' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Sell' rs:basecolumn='OperatorID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='PersonID' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Sell' rs:basecolumn='PersonID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='CustomerID' rs:number='10' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t rs:basetable='Sell' rs:basecolumn='CustomerID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='InCash' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Sell' rs:basecolumn='InCash'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='InCashCh' rs:number='42' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Sell' rs:basecolumn='InCashCh'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='500'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='ChkOperatorID' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Sell' rs:basecolumn='ChkOperatorID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='OperationID' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Sell' rs:basecolumn='OperationID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Remark' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Sell' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='300'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='AutoNO' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Sell' rs:basecolumn='AutoNO'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='BranchNO' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='BranchNO'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Dept' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='OperatorNO' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='JobNO'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Operator' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='PersonNO' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='JobNO'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Person' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='ChkOperatorNO' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='JobNO'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='ChkOperator' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='CustomerNO' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='CustomerList' rs:basecolumn='CustomerNO'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c24' rs:name='_Name' rs:number='25' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='CustomerList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='pyCode' rs:number='26' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='CustomerList' rs:basecolumn='pyCode'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='25'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='SndOperatorID' rs:number='27' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Sell' rs:basecolumn='SndOperatorID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='LinkMan' rs:number='28' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Sell' rs:basecolumn='LinkMan'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Tel' rs:number='29' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Sell' rs:basecolumn='Tel'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Adr' rs:number='30' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Sell' rs:basecolumn='Adr'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='200'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='SndOperator' rs:number='31' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Total' rs:number='32' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='4' rs:precision='18' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='ChargeMode' rs:number='42' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50' rs:scale='4' rs:precision='18' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='InvoiceNO' rs:number='43' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50' rs:scale='4' rs:precision='18' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='GoodsAmount' rs:number='33' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='4' rs:precision='18' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Profit' rs:number='34' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='4' rs:precision='18' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Types' rs:number='35' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t rs:basetable='Sell' rs:basecolumn='Type'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='PriceSumCh' rs:number='43' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Sell' rs:basecolumn='PriceSumCh'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='500'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='BranchNum' rs:number='44' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50' rs:scale='4' rs:precision='18' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c35' rs:name='ID' rs:number='36' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='CustomerList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c36' rs:name='ID' rs:number='37' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c37' rs:name='ID' rs:number='38' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c38' rs:name='ID' rs:number='39' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c39' rs:name='ID' rs:number='40' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c40' rs:name='ID' rs:number='41' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("     </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable = DALCommon.GetDataList("xs_sell", "", " [ID]=" + text3.ToString()).Tables[0];
			DataTable dataTable2 = DALCommon.GetDataList("xs_selldetail", "", " [BillID]=" + text3.ToString()).Tables[0];
			decimal d = 0m;
			decimal d2 = 0m;
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					decimal.TryParse(dataTable2.Rows[i]["GoodsAmount"].ToString(), out d2);
					d += d2;
				}
			}
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"     <z:row ID='1' DeptID='1' BillID='",
					dataTable.Rows[0]["BillID"].ToString(),
					"' Type='",
					dataTable.Rows[0]["Type"].ToString(),
					"' c4='",
					dataTable.Rows[0]["_Date"].ToString(),
					"' Status='",
					dataTable.Rows[0]["Status"].ToString(),
					"' OperatorID='1' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"     PersonID='1' CustomerID='1' InCash='",
					dataTable.Rows[0]["InCash"].ToString(),
					"' OperationID='",
					dataTable.Rows[0]["OperationID"].ToString(),
					"' Remark='",
					dataTable.Rows[0]["Remark"].ToString(),
					"' AutoNO='",
					dataTable.Rows[0]["AutoNO"].ToString(),
					"' BranchNO='",
					dataTable.Rows[0]["BranchNO"].ToString(),
					"' Dept='",
					dataTable.Rows[0]["Dept"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"     OperatorNO='",
					dataTable.Rows[0]["OperatorNO"].ToString(),
					"' Operator='",
					dataTable.Rows[0]["Operator"].ToString(),
					"' PersonNO='",
					dataTable.Rows[0]["PersonNO"].ToString(),
					"' Person='",
					dataTable.Rows[0]["Person"].ToString(),
					"' CustomerNO='",
					dataTable.Rows[0]["CustomerNO"].ToString(),
					"' c24='",
					dataTable.Rows[0]["_Name"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new object[]
				{
					"     pyCode='",
					dataTable.Rows[0]["pyCode"].ToString(),
					"' SndOperatorID='1' LinkMan='",
					dataTable.Rows[0]["LinkMan"].ToString(),
					"' Tel='",
					dataTable.Rows[0]["Tel"].ToString(),
					"' Adr='",
					dataTable.Rows[0]["Adr"].ToString(),
					"' SndOperator='",
					dataTable.Rows[0]["SndOperator"].ToString(),
					"' Total='",
					dataTable.Rows[0]["Total"].ToString(),
					"' ChargeMode='",
					dataTable.Rows[0]["ChargeMode"],
					"' InvoiceNO='",
					dataTable.Rows[0]["InvoiceNO"],
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"     GoodsAmount='",
					dataTable.Rows[0]["GoodsAmount"].ToString(),
					"' Profit='",
					dataTable.Rows[0]["Profit"].ToString(),
					"' Types='1' c35='1' c36='1' c37='1' c38='1' c40='1' PriceSumCh='",
					FunLibrary.NumChs(d.ToString("f2"), 2),
					"' InCashCh='",
					FunLibrary.NumChs(dataTable.Rows[0]["InCash"].ToString(), 2),
					"'/> \n"
				}));
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t<s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t rs:basetable='SellDetail' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='StockID' rs:number='2' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t rs:basetable='SellDetail' rs:basecolumn='StockID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='GoodsID' rs:number='3' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t rs:basetable='SellDetail' rs:basecolumn='GoodsID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='UnitID' rs:number='4' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t rs:basetable='SellDetail' rs:basecolumn='UnitID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Remark' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='SellDetail' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Qty' rs:number='6' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Price' rs:number='7' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Dis' rs:number='8' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Total' rs:number='9' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='GoodsNO' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='GoodsNO'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c10' rs:name='_Name' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Spec' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='Spec'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ProductBrand' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='StockName' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Unit' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='BillID' rs:number='16' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t rs:basetable='SellDetail' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='CostPrice' rs:number='17' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t rs:basetable='SellDetail' rs:basecolumn='CostPrice'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true' \n");
			stringBuilder.Append("\t\t rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='SN' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='SellDetail' rs:basecolumn='SN'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='8000'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='MaintenancePeriod' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='SellDetail' rs:basecolumn='MaintenancePeriod'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='PeriodEndDate' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='SellDetail' rs:basecolumn='PeriodEndDate'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='TaxRate' rs:number='21' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='TaxAmount' rs:number='22' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='GoodsAmount' rs:number='23' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ClassName' rs:number='29' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='SellDetail' rs:basecolumn='ClassName'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c23' rs:name='ID' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c24' rs:name='ID' rs:number='25' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c25' rs:name='ID' rs:number='26' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='GoodsUnit' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c26' rs:name='ID' rs:number='27' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c27' rs:name='ID' rs:number='28' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"     <z:row ID='1' StockID='1' GoodsID='91' UnitID='91' Remark='",
						dataTable2.Rows[i]["Remark"].ToString(),
						"' Qty='",
						dataTable2.Rows[i]["Qty"].ToString(),
						"' Price='",
						dataTable2.Rows[i]["Price"].ToString(),
						"' Dis='",
						dataTable2.Rows[i]["Dis"].ToString(),
						"' Total='",
						dataTable2.Rows[i]["Total"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"     GoodsNO='",
						dataTable2.Rows[i]["GoodsNO"].ToString(),
						"' c10='",
						dataTable2.Rows[i]["_Name"].ToString(),
						"' Spec='",
						dataTable2.Rows[i]["Spec"].ToString(),
						"' ProductBrand='",
						dataTable2.Rows[i]["ProductBrand"].ToString(),
						"' StockName='",
						dataTable2.Rows[i]["StockName"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"     Unit='",
						dataTable2.Rows[i]["Unit"].ToString(),
						"' BillID='1' CostPrice='",
						dataTable2.Rows[i]["CostPrice"].ToString(),
						"' SN='",
						dataTable2.Rows[i]["SN"].ToString(),
						"' MaintenancePeriod='",
						dataTable2.Rows[i]["MaintenancePeriod"].ToString(),
						"' PeriodEndDate='",
						dataTable2.Rows[i]["PeriodEndDate"].ToString(),
						"' TaxRate='",
						dataTable2.Rows[i]["TaxRate"].ToString(),
						"' TaxAmount='",
						dataTable2.Rows[i]["TaxAmount"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"     GoodsAmount='",
						dataTable2.Rows[i]["GoodsAmount"].ToString(),
						"' PriceSum='",
						d.ToString("f2"),
						"' PriceSumCh='",
						FunLibrary.NumChs(d.ToString("f2"), 2),
						"' ClassName='",
						dataTable2.Rows[i]["ClassName"].ToString(),
						"' c23='1' c24='91' c25='91' c26='1' c27='22'/> \n"
					}));
				}
			}
			stringBuilder.Append("     </rs:data> \n");
		}
		if (text2.ToLower() == "xsdd")
		{
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append(" \t<s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t\t    <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='SellPlan' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DeptID' rs:number='2' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='SellPlan' rs:basecolumn='DeptID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BillID' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='SellPlan' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c3' rs:name='_Date' rs:number='4' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkDate' rs:number='5' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Status' rs:number='6'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='6' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='OperatorID' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='SellPlan' rs:basecolumn='OperatorID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CustomerID' rs:number='8' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='SellPlan' rs:basecolumn='CustomerID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkOperatorID' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='SellPlan' rs:basecolumn='ChkOperatorID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Remark' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='SellPlan' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='300'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BranchNO' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='BranchNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Dept' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='OperatorNO' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='JobNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Operator' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkOperatorNO' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='JobNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkOperator' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CustomerNO' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='CustomerList' rs:basecolumn='CustomerNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c17' rs:name='_Name' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='CustomerList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='LinkMan' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='CustomerList' rs:basecolumn='LinkMan'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Tel' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='CustomerList' rs:basecolumn='Tel'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Adr' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='CustomerList' rs:basecolumn='Adr'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='200'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SndOperator' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='PriceSum' rs:number='30' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='SupplierList' rs:basecolumn='pyCode'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='25'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='PriceSumCh' rs:number='31' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='SupplierList' rs:basecolumn='pyCode'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='25'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='pyCode' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='CustomerList' rs:basecolumn='pyCode'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='25'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ContractNO' rs:number='29' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='SellPlan' rs:basecolumn='ContractNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Fax' rs:number='32' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='CustomerList' rs:basecolumn='Fax'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c25' rs:name='ID' rs:number='25' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='CustomerList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c26' rs:name='ID' rs:number='26' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c27' rs:name='ID' rs:number='27' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c28' rs:name='ID' rs:number='28' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("     </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable = DALCommon.GetDataList("xs_sellplan", "", " [ID]=" + text3.ToString()).Tables[0];
			DataTable dataTable2 = DALCommon.GetDataList("xs_sellplandetail", "", " [BillID]=" + text3.ToString()).Tables[0];
			decimal d = 0m;
			decimal d2 = 0m;
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					decimal.TryParse(dataTable2.Rows[i]["GoodsAmount"].ToString(), out d2);
					d += d2;
				}
			}
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"      <z:row ID='1' DeptID='1' BillID='",
					dataTable.Rows[0]["BillID"].ToString(),
					"' c3='",
					dataTable.Rows[0]["_Date"].ToString(),
					"' Status='",
					dataTable.Rows[0]["Status"].ToString(),
					"' OperatorID='6' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      PersonID='6' CustomerID='51' Remark='",
					dataTable.Rows[0]["Remark"].ToString(),
					"' BranchNO='",
					dataTable.Rows[0]["BranchNO"].ToString(),
					"' Dept='",
					dataTable.Rows[0]["Dept"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      OperatorNO='",
					dataTable.Rows[0]["OperatorNO"].ToString(),
					"' Operator='",
					dataTable.Rows[0]["Operator"].ToString(),
					"' CustomerNO='",
					dataTable.Rows[0]["CustomerNO"].ToString(),
					"' c17='",
					dataTable.Rows[0]["_Name"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      LinkMan='",
					dataTable.Rows[0]["LinkMan"].ToString(),
					"' Tel='",
					dataTable.Rows[0]["Tel"].ToString(),
					"' Fax='",
					dataTable.Rows[0]["Fax"].ToString(),
					"' Adr='",
					dataTable.Rows[0]["Adr"].ToString(),
					"' SndOperator='",
					dataTable.Rows[0]["SndOperator"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      pyCode='",
					dataTable.Rows[0]["pyCode"].ToString(),
					"' ContractNO='",
					dataTable.Rows[0]["ContractNO"].ToString(),
					"' PriceSum='",
					d.ToString("f2"),
					"' PriceSumCh='",
					FunLibrary.NumChs(d.ToString("f2"), 2),
					"' /> \n"
				}));
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("<s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t rs:basetable='SellPlanDetail' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='StockID' rs:number='2' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t rs:basetable='SellPlanDetail' rs:basecolumn='StockID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='GoodsID' rs:number='3' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t rs:basetable='SellPlanDetail' rs:basecolumn='GoodsID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='UnitID' rs:number='4' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t rs:basetable='SellPlanDetail' rs:basecolumn='UnitID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Remark' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='SellPlanDetail' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Qty' rs:number='6' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='SellQty' rs:number='7' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Price' rs:number='8' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Dis' rs:number='9' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Total' rs:number='10' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='GoodsNO' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='GoodsNO'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c11' rs:name='_Name' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Spec' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='Spec'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='MainTenancePeriod' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='MainTenancePeriod'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='ProductBrand' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='StockName' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Unit' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='BillID' rs:number='18' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t rs:basetable='SellPlanDetail' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='TaxRate' rs:number='19' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='TaxAmount' rs:number='20' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='GoodsAmount' rs:number='21' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c21' rs:name='ID' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c22' rs:name='ID' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c23' rs:name='ID' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='GoodsUnit' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c24' rs:name='ID' rs:number='25' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c25' rs:name='ID' rs:number='26' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"<z:row ID='1' StockID='4' GoodsID='4' UnitID='4' Remark='",
						dataTable2.Rows[i]["Remark"].ToString(),
						"' Qty='",
						dataTable2.Rows[i]["Qty"].ToString(),
						"' SellQty='",
						dataTable2.Rows[i]["SellQty"].ToString(),
						"' Price='",
						dataTable2.Rows[i]["Price"].ToString(),
						"' Dis='",
						dataTable2.Rows[i]["Dis"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"Total='",
						dataTable2.Rows[i]["Total"].ToString(),
						"' GoodsNO='",
						dataTable2.Rows[i]["GoodsNO"].ToString(),
						"' c11='",
						dataTable2.Rows[i]["_Name"].ToString(),
						"' Spec='",
						dataTable2.Rows[i]["Spec"].ToString(),
						"' MainTenancePeriod='",
						dataTable2.Rows[i]["MainTenancePeriod"].ToString(),
						"' ProductBrand='",
						dataTable2.Rows[i]["ProductBrand"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"StockName='",
						dataTable2.Rows[i]["StockName"].ToString(),
						"' Unit='",
						dataTable2.Rows[i]["Unit"].ToString(),
						"' BillID='1' c18='4' c19='4' c20='4' c21='13' c22='19'/> \n"
					}));
				}
			}
			stringBuilder.Append("     </rs:data> \n");
		}
		if (text2.ToLower() == "pzd" || text2.ToLower() == "pgd" || text2.ToLower() == "sjd" || text2.ToLower() == "bjd")
		{
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append(" \t<s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t\t    <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='ID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BillID' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='TakeDept' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='TakeDept'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DisposalDept' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='DisposalDept'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='curStatus' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='curStatus'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='TakeOverID' rs:number='6' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='TakeOverID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DisposalID' rs:number='7' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='DisposalID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ServicesType' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ServicesType'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='TakeStyle' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='TakeStyle'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='TakeStyleID' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='TakeStyleID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Time_Make' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Time_Make'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Time_TakeOver' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Time_TakeOver'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Time_Start' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Time_Start'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Time_Over' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Time_Over'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Time_Payee' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Time_Payee'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='OperatorID' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='OperatorID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Time_BackSee' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Time_BackSee'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Time_Close' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Time_Close'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Operator' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Operator'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Person' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Person'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='PersonID' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='PersonID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='StartOperator' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='StartOperator'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='PayeeOper' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='PayeeOper'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkOperator' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ChkOperator'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BackSeeOper' rs:number='25' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='BackSeeOper'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CustomerName' rs:number='26' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='CustomerName'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='LinkMan' rs:number='27' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='fw_services' rs:basecolumn='LinkMan'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Tel' rs:number='28' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Tel'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='UsePerson' rs:number='29' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='UsePerson'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='UsePersonDept' rs:number='30' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='UsePersonDept'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='UsePersonTel' rs:number='31' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='UsePersonTel'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Area' rs:number='32' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Area'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Adr' rs:number='33' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Adr'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='200'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ProductSN1' rs:number='34' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ProductSN1'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ProductSN2' rs:number='35' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ProductSN2'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BuyDate' rs:number='36' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='BuyDate'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BuyFrom' rs:number='37' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='BuyFrom'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ProductClass' rs:number='38' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ProductClass'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ProductModel' rs:number='39' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ProductModel'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ProductBrand' rs:number='40' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ProductBrand'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Aspect' rs:number='41' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Aspect'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CusType' rs:number='42' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='CusType'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='WarrantyID' rs:number='43' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='WarrantyID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Accessory' rs:number='44' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Accessory'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='200'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Fault' rs:number='45' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Fault'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='1000'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Warranty' rs:number='46' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Warranty'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c46' rs:name='_PRI' rs:number='47' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='_PRI'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BuyInvoice' rs:number='48' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='BuyInvoice'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='dPoint' rs:number='49' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='dPoint'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Speding' rs:number='50' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Speding'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='bRepair' rs:number='51' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='bRepair'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SaveID' rs:number='52' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='SaveID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SupplierID' rs:number='53' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='SupplierID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChargeCorp' rs:number='54' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ChargeCorp'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DisposalOper' rs:number='55' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='DisposalOper'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SubscribeTime' rs:number='56' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='SubscribeTime'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SubscribeConnectTime' rs:number='57' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='SubscribeConnectTime'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SubscribePrice' rs:number='58' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='SubscribePrice'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='PreCharge' rs:number='59' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='PreCharge'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RepairStatus' rs:number='60' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='RepairStatus'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RepairType' rs:number='61' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='RepairType'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='8' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RepairCorpID' rs:number='62' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='RepairCorpID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RepairCorp' rs:number='63' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='RepairCorp'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Remark' rs:number='64' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='500'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CancelReason' rs:number='65' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='CancelReason'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RepairSndDate' rs:number='66' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='RepairSndDate'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RepairRcvDate' rs:number='67' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='RepairRcvDate'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RepairCost' rs:number='68' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='RepairCost'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CustomerID' rs:number='69' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='CustomerID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='WarrantyChargeCorpID' rs:number='70' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='WarrantyChargeCorpID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='PostNO' rs:number='71' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='PostNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Postage' rs:number='72' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Postage'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='MaterailCost' rs:number='73' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='MaterailCost'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ExtraCost' rs:number='74' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ExtraCost'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Fee_Materail' rs:number='75' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Fee_Materail'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Fee_Labor' rs:number='76' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Fee_Labor'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Fee_Add' rs:number='77' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Fee_Add'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='WarrantyChargeValue' rs:number='78' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='WarrantyChargeValue'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChargeValue' rs:number='79' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ChargeValue'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Fee_Total' rs:number='80' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Fee_Total'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Profit' rs:number='81' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Profit'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='WarrantyEndDate' rs:number='82' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='WarrantyEndDate'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='WarrantyBound' rs:number='83' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='WarrantyBound'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='200'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='GoodsTo' rs:number='84' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='GoodsTo'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ConnectDate' rs:number='85' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ConnectDate'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='bCall' rs:number='86' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='bCall'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SmsStatus' rs:number='87' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='SmsStatus'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ConfirmDate' rs:number='88' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ConfirmDate'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BranchName' rs:number='89' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='BranchName'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CorpName' rs:number='90' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='CorpName'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CorpLinkMan' rs:number='91' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='LinkMan'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CorpTel' rs:number='92' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='Tel'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CorpZip' rs:number='93' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='Zip'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CorpFax' rs:number='94' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='Fax'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CorpArea' rs:number='95' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='Area'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CorpAdr' rs:number='96' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='Adr'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DeviceNO' rs:number='97' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='ServicesList' rs:basecolumn='DeviceNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='TakeSteps' rs:number='98' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='ServicesList' rs:basecolumn='TakeSteps'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='8000' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='QtyType' rs:number='99' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='ServicesList' rs:basecolumn='QtyType'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='8000' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CustomerClass' rs:number='101' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='ServicesList' rs:basecolumn='CustomerClass'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='200' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ContractWarrantyEnd' rs:number='102' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='ServicesList' rs:basecolumn='ContractWarrantyEnd'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='200' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DeviceRemark' rs:number='103' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='ServicesList' rs:basecolumn='DeviceRemark'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='3000' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SumFwbj' rs:number='104' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='ServicesList' rs:basecolumn='SumFwbj'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='3000' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CustomerNO' rs:number='105' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='ServicesList' rs:basecolumn='CustomerNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='OldQtyType' rs:number='100' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='ServicesList' rs:basecolumn='OldQtyType'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='8000' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Member' rs:number='106' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='ServicesList' rs:basecolumn='Member'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("     </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable2 = DALCommon.GetDataList("fw_servicesoffer", "", " [BillID]=" + text3.ToString()).Tables[0];
			decimal d3 = 0m;
			decimal d4 = 0m;
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					decimal.TryParse(dataTable2.Rows[i]["dAmount"].ToString(), out d4);
					d3 += d4;
				}
			}
			DataTable dataTable = DALCommon.GetDataList("fw_servicesprint", "", " [ID]=" + text3.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"       <z:row ID='1' CustomerNO='",
					dataTable.Rows[0]["CustomerNO"].ToString(),
					"' BillID='",
					dataTable.Rows[0]["BillID"].ToString(),
					"' TakeDept='",
					dataTable.Rows[0]["TakeDept"].ToString(),
					"' DisposalDept='",
					dataTable.Rows[0]["DisposalDept"].ToString(),
					"' curStatus='",
					dataTable.Rows[0]["curStatus"].ToString(),
					"' TakeOverID='1' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       DisposalID='1' ServicesType='",
					dataTable.Rows[0]["ServicesType"].ToString(),
					"' TakeStyle='",
					dataTable.Rows[0]["TakeStyle"].ToString(),
					"' TakeStyleID='4' Time_Make='",
					dataTable.Rows[0]["Time_Make"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       Time_TakeOver='",
					dataTable.Rows[0]["Time_TakeOver"].ToString(),
					"' Time_Start='",
					dataTable.Rows[0]["Time_Start"].ToString(),
					"' Time_Over='",
					dataTable.Rows[0]["Time_Over"].ToString(),
					"' Time_Payee='",
					dataTable.Rows[0]["Time_Payee"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       OperatorID='6' Time_Close='",
					dataTable.Rows[0]["Time_Close"].ToString(),
					"' Operator='",
					dataTable.Rows[0]["Operator"].ToString(),
					"' Person='",
					dataTable.Rows[0]["Person"].ToString(),
					"' PersonID='6' StartOperator='",
					dataTable.Rows[0]["StartOperator"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       PayeeOper='",
					dataTable.Rows[0]["PayeeOper"].ToString(),
					"' ChkOperator='",
					dataTable.Rows[0]["ChkOperator"].ToString(),
					"' CustomerName='",
					dataTable.Rows[0]["CustomerName"].ToString(),
					"' LinkMan='",
					dataTable.Rows[0]["LinkMan"].ToString(),
					"' Tel='",
					dataTable.Rows[0]["Tel"].ToString(),
					"' UsePerson='",
					dataTable.Rows[0]["UsePerson"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       UsePersonDept='",
					dataTable.Rows[0]["UsePersonDept"].ToString(),
					"' UsePersonTel='",
					dataTable.Rows[0]["UsePersonTel"].ToString(),
					"' Area='",
					dataTable.Rows[0]["Area"].ToString(),
					"' Adr='",
					dataTable.Rows[0]["Adr"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       ProductSN1='",
					dataTable.Rows[0]["ProductSN1"].ToString(),
					"' ProductSN2='",
					dataTable.Rows[0]["ProductSN2"].ToString(),
					"' BuyFrom='",
					dataTable.Rows[0]["BuyFrom"].ToString(),
					"' ProductClass='",
					dataTable.Rows[0]["ProductClass"].ToString(),
					"' ProductModel='",
					dataTable.Rows[0]["ProductModel"].ToString(),
					"' ProductBrand='",
					dataTable.Rows[0]["ProductBrand"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       Aspect='",
					dataTable.Rows[0]["Aspect"].ToString(),
					"' CusType='1' WarrantyID='3' Accessory='",
					dataTable.Rows[0]["Accessory"].ToString(),
					"' Fault='",
					dataTable.Rows[0]["Fault"].ToString(),
					"' Warranty='",
					dataTable.Rows[0]["Warranty"].ToString(),
					"' c46='",
					dataTable.Rows[0]["_PRI"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       BuyInvoice='",
					dataTable.Rows[0]["BuyInvoice"].ToString(),
					"' dPoint='",
					dataTable.Rows[0]["dPoint"].ToString(),
					"' Speding='",
					dataTable.Rows[0]["Speding"].ToString(),
					"' bRepair='",
					dataTable.Rows[0]["bRepair"].ToString(),
					"' SaveID='",
					dataTable.Rows[0]["SaveID"].ToString(),
					"' SupplierID='",
					dataTable.Rows[0]["SupplierID"].ToString(),
					"' DisposalOper='",
					dataTable.Rows[0]["DisposalOper"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       SubscribeTime='",
					dataTable.Rows[0]["SubscribeTime"].ToString(),
					"' SubscribeConnectTime='",
					dataTable.Rows[0]["SubscribeConnectTime"].ToString(),
					"' SubscribePrice='",
					dataTable.Rows[0]["SubscribePrice"].ToString(),
					"' PreCharge='",
					dataTable.Rows[0]["PreCharge"].ToString(),
					"' RepairStatus='",
					dataTable.Rows[0]["RepairStatus"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       RepairType='",
					dataTable.Rows[0]["RepairType"].ToString(),
					"' RepairCorpID='4' RepairCorp='",
					dataTable.Rows[0]["RepairCorp"].ToString(),
					"' Remark='",
					dataTable.Rows[0]["Remark"].ToString(),
					"' CancelReason='",
					dataTable.Rows[0]["CancelReason"].ToString(),
					"' RepairSndDate='",
					dataTable.Rows[0]["RepairSndDate"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       RepairRcvDate='",
					dataTable.Rows[0]["RepairRcvDate"].ToString(),
					"' RepairCost='",
					dataTable.Rows[0]["RepairCost"].ToString(),
					"' CustomerID='",
					dataTable.Rows[0]["CustomerID"].ToString(),
					"' WarrantyChargeCorpID='",
					dataTable.Rows[0]["WarrantyChargeCorpID"].ToString(),
					"' PostNO='",
					dataTable.Rows[0]["PostNO"].ToString(),
					"' Postage='",
					dataTable.Rows[0]["Postage"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      MaterailCost='",
					dataTable.Rows[0]["MaterailCost"].ToString(),
					"' ExtraCost='",
					dataTable.Rows[0]["ExtraCost"].ToString(),
					"' Fee_Materail='",
					dataTable.Rows[0]["Fee_Materail"].ToString(),
					"' Fee_Labor='",
					dataTable.Rows[0]["Fee_Labor"].ToString(),
					"' Fee_Add='",
					dataTable.Rows[0]["Fee_Add"].ToString(),
					"' WarrantyChargeValue='",
					dataTable.Rows[0]["WarrantyChargeValue"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       ChargeValue='",
					dataTable.Rows[0]["ChargeValue"].ToString(),
					"' Fee_Total='",
					dataTable.Rows[0]["Fee_Total"].ToString(),
					"' Profit='",
					dataTable.Rows[0]["Profit"].ToString(),
					"' WarrantyEndDate='",
					dataTable.Rows[0]["WarrantyEndDate"].ToString(),
					"' WarrantyBound='",
					dataTable.Rows[0]["WarrantyBound"].ToString(),
					"' GoodsTo='",
					dataTable.Rows[0]["GoodsTo"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      ConnectDate='",
					dataTable.Rows[0]["ConnectDate"].ToString(),
					"' bCall='0' SmsStatus='",
					dataTable.Rows[0]["SmsStatus"].ToString(),
					"' BranchName='",
					sysParm.CorpName,
					"' CorpName='",
					dataTable.Rows[0]["CorpName"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      CorpLinkMan='",
					dataTable.Rows[0]["CorpLinkMan"].ToString(),
					"' CorpTel='",
					dataTable.Rows[0]["CorpTel"].ToString(),
					"' CorpZip='",
					dataTable.Rows[0]["CorpZip"].ToString(),
					"' CorpFax='",
					dataTable.Rows[0]["CorpFax"].ToString(),
					"' CorpArea='",
					dataTable.Rows[0]["CorpArea"].ToString(),
					"' CorpAdr='",
					dataTable.Rows[0]["CorpAdr"].ToString(),
					"' BuyDate='",
					dataTable.Rows[0]["BuyDate"].ToString(),
					"' DeviceNO='",
					dataTable.Rows[0]["DeviceNO"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      CustomerClass='",
					dataTable.Rows[0]["CustomerClass"].ToString(),
					"' ContractWarrantyEnd='",
					dataTable.Rows[0]["ContractWarrantyEnd"].ToString(),
					"' DeviceRemark='",
					dataTable.Rows[0]["DeviceRemark"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       TakeSteps='' Member='",
					dataTable.Rows[0]["Member"].ToString(),
					"' QtyType='",
					dataTable.Rows[0]["QtyType"].ToString(),
					"' OldQtyType='",
					dataTable.Rows[0]["OldQtyType"].ToString(),
					"' SumFwbj='",
					d3.ToString(),
					"' /> \n"
				}));
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("      <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("     <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("     <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("     \t\t rs:basetable='ServiceOffer' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("     \t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("     \t</s:AttributeType> \n");
			stringBuilder.Append("     \t<s:AttributeType name='BillID' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t\t rs:baseschema='dbo' rs:basetable='ServiceOffer' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("     \t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     \t</s:AttributeType> \n");
			stringBuilder.Append("     \t<s:AttributeType name='c2' rs:name='_Date' rs:number='3' rs:nullable='true'> \n");
			stringBuilder.Append("     \t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     \t</s:AttributeType> \n");
			stringBuilder.Append("     \t<s:AttributeType name='OperatorID' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t\t rs:baseschema='dbo' rs:basetable='ServiceOffer' rs:basecolumn='OperatorID'> \n");
			stringBuilder.Append("     \t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     \t</s:AttributeType> \n");
			stringBuilder.Append("     \t<s:AttributeType name='SellerID' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t\t rs:baseschema='dbo' rs:basetable='ServiceOffer' rs:basecolumn='SellerID'> \n");
			stringBuilder.Append("     \t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     \t</s:AttributeType> \n");
			stringBuilder.Append("     \t<s:AttributeType name='ItemID' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t\t rs:baseschema='dbo' rs:basetable='ServiceOffer' rs:basecolumn='ItemID'> \n");
			stringBuilder.Append("     \t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     \t</s:AttributeType> \n");
			stringBuilder.Append("     \t<s:AttributeType name='dAmount' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t\t rs:baseschema='dbo' rs:basetable='ServiceOffer' rs:basecolumn='dAmount'> \n");
			stringBuilder.Append("     \t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     \t</s:AttributeType> \n");
			stringBuilder.Append("     \t<s:AttributeType name='bCusConf' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t\t rs:baseschema='dbo' rs:basetable='ServiceOffer' rs:basecolumn='bCusConf'> \n");
			stringBuilder.Append("     \t\t<s:datatype dt:type='boolean' dt:maxLength='2' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     \t</s:AttributeType> \n");
			stringBuilder.Append("     \t<s:AttributeType name='Remark' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t\t rs:baseschema='dbo' rs:basetable='ServiceOffer' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("     \t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='300'/> \n");
			stringBuilder.Append("     \t</s:AttributeType> \n");
			stringBuilder.Append("     \t<s:AttributeType name='c9' rs:name='_Name' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t\t rs:baseschema='dbo' rs:basetable='OfferItem' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("     \t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("     \t</s:AttributeType> \n");
			stringBuilder.Append("     \t<s:AttributeType name='Operator' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("     \t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     \t</s:AttributeType> \n");
			stringBuilder.Append("     \t<s:AttributeType name='Seller' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("     \t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     \t</s:AttributeType> \n");
			stringBuilder.Append("     \t<s:AttributeType name='CusConf' rs:number='13'> \n");
			stringBuilder.Append("     \t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2' rs:maybenull='false'/> \n");
			stringBuilder.Append("     \t</s:AttributeType> \n");
			stringBuilder.Append("     \t<s:AttributeType name='c13' rs:name='ID' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("     \t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     \t</s:AttributeType> \n");
			stringBuilder.Append("     \t<s:AttributeType name='c14' rs:name='ID' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("     \t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     \t</s:AttributeType> \n");
			stringBuilder.Append("     \t<s:AttributeType name='c15' rs:name='ID' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t\t rs:baseschema='dbo' rs:basetable='OfferItem' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("     \t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     \t</s:AttributeType> \n");
			stringBuilder.Append("     \t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("     </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"     <z:row ID='1' BillID='1' c2='",
						dataTable2.Rows[i]["_Date"].ToString(),
						"' OperatorID='1' SellerID='1' ItemID='1' dAmount='",
						dataTable2.Rows[i]["dAmount"].ToString(),
						"' bCusConf='",
						dataTable2.Rows[i]["bCusConf"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"     \t Remark='",
						dataTable2.Rows[i]["Remark"].ToString(),
						"' c9='",
						dataTable2.Rows[i]["_Name"].ToString(),
						"' Operator='",
						dataTable2.Rows[i]["Operator"].ToString(),
						"' Seller='",
						dataTable2.Rows[i]["Seller"].ToString(),
						"' CusConf='",
						dataTable2.Rows[i]["CusConf"].ToString(),
						"' c13='1' c14='1' c15='1'/> \n"
					}));
				}
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append(" \t<s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t\t    <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='ID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BillID' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='TakeDept' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='TakeDept'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DisposalDept' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='DisposalDept'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='curStatus' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='curStatus'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='TakeOverID' rs:number='6' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='TakeOverID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DisposalID' rs:number='7' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='DisposalID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ServicesType' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ServicesType'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='TakeStyle' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='TakeStyle'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='TakeStyleID' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='TakeStyleID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Time_Make' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Time_Make'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Time_TakeOver' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Time_TakeOver'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Time_Start' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Time_Start'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Time_Over' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Time_Over'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Time_Payee' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Time_Payee'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='OperatorID' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='OperatorID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Time_BackSee' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Time_BackSee'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Time_Close' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Time_Close'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Operator' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Operator'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Person' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Person'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='PersonID' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='PersonID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='StartOperator' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='StartOperator'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='PayeeOper' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='PayeeOper'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkOperator' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ChkOperator'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BackSeeOper' rs:number='25' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='BackSeeOper'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CustomerName' rs:number='26' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='CustomerName'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='LinkMan' rs:number='27' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='fw_services' rs:basecolumn='LinkMan'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Tel' rs:number='28' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Tel'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='UsePerson' rs:number='29' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='UsePerson'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='UsePersonDept' rs:number='30' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='UsePersonDept'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='UsePersonTel' rs:number='31' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='UsePersonTel'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Area' rs:number='32' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Area'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Adr' rs:number='33' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Adr'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='200'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ProductSN1' rs:number='34' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ProductSN1'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ProductSN2' rs:number='35' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ProductSN2'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BuyDate' rs:number='36' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='BuyDate'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BuyFrom' rs:number='37' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='BuyFrom'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ProductClass' rs:number='38' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ProductClass'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ProductModel' rs:number='39' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ProductModel'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ProductBrand' rs:number='40' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ProductBrand'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Aspect' rs:number='41' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Aspect'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CusType' rs:number='42' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='CusType'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='WarrantyID' rs:number='43' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='WarrantyID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Accessory' rs:number='44' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Accessory'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='200'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Fault' rs:number='45' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Fault'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='1000'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Warranty' rs:number='46' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Warranty'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c46' rs:name='_PRI' rs:number='47' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='_PRI'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BuyInvoice' rs:number='48' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='BuyInvoice'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='dPoint' rs:number='49' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='dPoint'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Speding' rs:number='50' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Speding'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='bRepair' rs:number='51' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='bRepair'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SaveID' rs:number='52' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='SaveID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SupplierID' rs:number='53' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='SupplierID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChargeCorp' rs:number='54' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ChargeCorp'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DisposalOper' rs:number='55' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='DisposalOper'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SubscribeTime' rs:number='56' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='SubscribeTime'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SubscribeConnectTime' rs:number='57' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='SubscribeConnectTime'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SubscribePrice' rs:number='58' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='SubscribePrice'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='PreCharge' rs:number='59' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='PreCharge'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RepairStatus' rs:number='60' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='RepairStatus'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RepairType' rs:number='61' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='RepairType'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='8' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RepairCorpID' rs:number='62' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='RepairCorpID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RepairCorp' rs:number='63' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='RepairCorp'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Remark' rs:number='64' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='500'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CancelReason' rs:number='65' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='CancelReason'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RepairSndDate' rs:number='66' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='RepairSndDate'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RepairRcvDate' rs:number='67' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='RepairRcvDate'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RepairCost' rs:number='68' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='RepairCost'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CustomerID' rs:number='69' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='CustomerID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='WarrantyChargeCorpID' rs:number='70' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='WarrantyChargeCorpID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='PostNO' rs:number='71' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='PostNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Postage' rs:number='72' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Postage'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='MaterailCost' rs:number='73' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='MaterailCost'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ExtraCost' rs:number='74' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ExtraCost'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Fee_Materail' rs:number='75' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Fee_Materail'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Fee_Labor' rs:number='76' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Fee_Labor'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Fee_Add' rs:number='77' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Fee_Add'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='WarrantyChargeValue' rs:number='78' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='WarrantyChargeValue'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChargeValue' rs:number='79' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ChargeValue'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Fee_Total' rs:number='80' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Fee_Total'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Profit' rs:number='81' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Profit'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='WarrantyEndDate' rs:number='82' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='WarrantyEndDate'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='WarrantyBound' rs:number='83' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='WarrantyBound'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='200'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='GoodsTo' rs:number='84' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='GoodsTo'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ConnectDate' rs:number='85' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ConnectDate'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='bCall' rs:number='86' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='bCall'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SmsStatus' rs:number='87' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='SmsStatus'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ConfirmDate' rs:number='88' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ConfirmDate'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BranchName' rs:number='89' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='BranchName'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CorpName' rs:number='90' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='CorpName'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CorpLinkMan' rs:number='91' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='LinkMan'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CorpTel' rs:number='92' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='Tel'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CorpZip' rs:number='93' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='Zip'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CorpFax' rs:number='94' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='Fax'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CorpArea' rs:number='95' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='Area'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CorpAdr' rs:number='96' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='Adr'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DeviceNO' rs:number='97' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='ServicesList' rs:basecolumn='DeviceNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='TakeSteps' rs:number='98' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='ServicesList' rs:basecolumn='TakeSteps'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='8000' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='QtyType' rs:number='99' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='ServicesList' rs:basecolumn='QtyType'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='8000' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='OldQtyType' rs:number='100' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='ServicesList' rs:basecolumn='OldQtyType'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='8000' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='mrID' rs:number='101' rs:basecatalog='wt_it' rs:baseschema='dbo' rs:basetable='QtyList'\r\n\t\t\t rs:basecolumn='ID' rs:keycolumn='true' rs:autoincrement='true'>\r\n\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c1' rs:name='_Date' rs:number='102' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='mrOperator' rs:number='103' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='mrInfo' rs:number='104' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='QtyList' rs:basecolumn='QtyType'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='8000'/>\r\n\t\t</s:AttributeType>\r\n");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("     </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			string text7 = dataTable.Rows[0]["DeviceNO"].ToString().Trim();
			string text8 = dataTable.Rows[0]["ProductSN1"].ToString().Trim();
			int num2 = 0;
			string strCondition;
			if (!text8.Trim().Equals(""))
			{
				strCondition = " ProductSN1='" + text8 + "' and curStatus='已结束'";
			}
			else if (!text7.Trim().Equals(""))
			{
				strCondition = " DeviceNO='" + text7 + "' and curStatus='已结束'";
			}
			else
			{
				strCondition = " 0=1 ";
			}
			dataTable = DALCommon.GetList_HL(0, "fw_services", "top 1 *", 0, 0, strCondition, "ID desc", out num2).Tables[0];
			string text9 = "";
			if (dataTable.Rows.Count > 0)
			{
				text9 = dataTable.Rows[0]["ID"].ToString().Trim();
				stringBuilder.Append(string.Concat(new string[]
				{
					"       <z:row ID='1' BillID='",
					dataTable.Rows[0]["BillID"].ToString(),
					"' TakeDept='",
					dataTable.Rows[0]["TakeDept"].ToString(),
					"' DisposalDept='",
					dataTable.Rows[0]["DisposalDept"].ToString(),
					"' curStatus='",
					dataTable.Rows[0]["curStatus"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       DisposalID='1' ServicesType='",
					dataTable.Rows[0]["ServicesType"].ToString(),
					"' TakeStyle='",
					dataTable.Rows[0]["TakeStyle"].ToString(),
					"' TakeStyleID='4' Time_Make='",
					dataTable.Rows[0]["Time_Make"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       Time_TakeOver='",
					dataTable.Rows[0]["Time_TakeOver"].ToString(),
					"' Time_Start='",
					dataTable.Rows[0]["Time_Start"].ToString(),
					"' Time_Over='",
					dataTable.Rows[0]["Time_Over"].ToString(),
					"' Time_Payee='",
					dataTable.Rows[0]["Time_Payee"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       OperatorID='6' Time_Close='",
					dataTable.Rows[0]["Time_Close"].ToString(),
					"' Operator='",
					dataTable.Rows[0]["Operator"].ToString(),
					"' Person='",
					dataTable.Rows[0]["Person"].ToString(),
					"' PersonID='6' StartOperator='",
					dataTable.Rows[0]["StartOperator"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       PayeeOper='",
					dataTable.Rows[0]["PayeeOper"].ToString(),
					"' ChkOperator='",
					dataTable.Rows[0]["ChkOperator"].ToString(),
					"' CustomerName='",
					dataTable.Rows[0]["CustomerName"].ToString(),
					"' LinkMan='",
					dataTable.Rows[0]["LinkMan"].ToString(),
					"' Tel='",
					dataTable.Rows[0]["Tel"].ToString(),
					"' UsePerson='",
					dataTable.Rows[0]["UsePerson"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       UsePersonDept='",
					dataTable.Rows[0]["UsePersonDept"].ToString(),
					"' UsePersonTel='",
					dataTable.Rows[0]["UsePersonTel"].ToString(),
					"' Area='",
					dataTable.Rows[0]["Area"].ToString(),
					"' Adr='",
					dataTable.Rows[0]["Adr"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       ProductSN1='",
					dataTable.Rows[0]["ProductSN1"].ToString(),
					"' ProductSN2='",
					dataTable.Rows[0]["ProductSN2"].ToString(),
					"' BuyFrom='",
					dataTable.Rows[0]["BuyFrom"].ToString(),
					"' ProductClass='",
					dataTable.Rows[0]["ProductClass"].ToString(),
					"' ProductModel='",
					dataTable.Rows[0]["ProductModel"].ToString(),
					"' ProductBrand='",
					dataTable.Rows[0]["ProductBrand"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       Aspect='",
					dataTable.Rows[0]["Aspect"].ToString(),
					"' CusType='1' WarrantyID='3' Accessory='",
					dataTable.Rows[0]["Accessory"].ToString(),
					"' Fault='",
					dataTable.Rows[0]["Fault"].ToString(),
					"' Warranty='",
					dataTable.Rows[0]["Warranty"].ToString(),
					"' c46='",
					dataTable.Rows[0]["_PRI"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       BuyInvoice='",
					dataTable.Rows[0]["BuyInvoice"].ToString(),
					"' dPoint='",
					dataTable.Rows[0]["dPoint"].ToString(),
					"' Speding='",
					dataTable.Rows[0]["Speding"].ToString(),
					"' bRepair='",
					dataTable.Rows[0]["bRepair"].ToString(),
					"' SaveID='",
					dataTable.Rows[0]["SaveID"].ToString(),
					"' SupplierID='",
					dataTable.Rows[0]["SupplierID"].ToString(),
					"' DisposalOper='",
					dataTable.Rows[0]["DisposalOper"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       SubscribeTime='",
					dataTable.Rows[0]["SubscribeTime"].ToString(),
					"' SubscribeConnectTime='",
					dataTable.Rows[0]["SubscribeConnectTime"].ToString(),
					"' SubscribePrice='",
					dataTable.Rows[0]["SubscribePrice"].ToString(),
					"' PreCharge='",
					dataTable.Rows[0]["PreCharge"].ToString(),
					"' RepairStatus='",
					dataTable.Rows[0]["RepairStatus"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       RepairType='",
					dataTable.Rows[0]["RepairType"].ToString(),
					"' RepairCorpID='4' RepairCorp='",
					dataTable.Rows[0]["RepairCorp"].ToString(),
					"' Remark='",
					dataTable.Rows[0]["Remark"].ToString(),
					"' CancelReason='",
					dataTable.Rows[0]["CancelReason"].ToString(),
					"' RepairSndDate='",
					dataTable.Rows[0]["RepairSndDate"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       RepairRcvDate='",
					dataTable.Rows[0]["RepairRcvDate"].ToString(),
					"' RepairCost='",
					dataTable.Rows[0]["RepairCost"].ToString(),
					"' CustomerID='",
					dataTable.Rows[0]["CustomerID"].ToString(),
					"' WarrantyChargeCorpID='",
					dataTable.Rows[0]["WarrantyChargeCorpID"].ToString(),
					"' PostNO='",
					dataTable.Rows[0]["PostNO"].ToString(),
					"' Postage='",
					dataTable.Rows[0]["Postage"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      MaterailCost='",
					dataTable.Rows[0]["MaterailCost"].ToString(),
					"' ExtraCost='",
					dataTable.Rows[0]["ExtraCost"].ToString(),
					"' Fee_Materail='",
					dataTable.Rows[0]["Fee_Materail"].ToString(),
					"' Fee_Labor='",
					dataTable.Rows[0]["Fee_Labor"].ToString(),
					"' Fee_Add='",
					dataTable.Rows[0]["Fee_Add"].ToString(),
					"' WarrantyChargeValue='",
					dataTable.Rows[0]["WarrantyChargeValue"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       ChargeValue='",
					dataTable.Rows[0]["ChargeValue"].ToString(),
					"' Fee_Total='",
					dataTable.Rows[0]["Fee_Total"].ToString(),
					"' Profit='",
					dataTable.Rows[0]["Profit"].ToString(),
					"' WarrantyEndDate='",
					dataTable.Rows[0]["WarrantyEndDate"].ToString(),
					"' WarrantyBound='",
					dataTable.Rows[0]["WarrantyBound"].ToString(),
					"' GoodsTo='",
					dataTable.Rows[0]["GoodsTo"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      ConnectDate='",
					dataTable.Rows[0]["ConnectDate"].ToString(),
					"' bCall='0' SmsStatus='",
					dataTable.Rows[0]["SmsStatus"].ToString(),
					"' BranchName='",
					sysParm.CorpName,
					"' CorpName='",
					dataTable.Rows[0]["CorpName"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      CorpLinkMan='",
					dataTable.Rows[0]["CorpLinkMan"].ToString(),
					"' CorpTel='",
					dataTable.Rows[0]["CorpTel"].ToString(),
					"' CorpZip='",
					dataTable.Rows[0]["CorpZip"].ToString(),
					"' CorpFax='",
					dataTable.Rows[0]["CorpFax"].ToString(),
					"' CorpArea='",
					dataTable.Rows[0]["CorpArea"].ToString(),
					"' CorpAdr='",
					dataTable.Rows[0]["CorpAdr"].ToString(),
					"' BuyDate='",
					dataTable.Rows[0]["BuyDate"].ToString(),
					"' DeviceNO='",
					dataTable.Rows[0]["DeviceNO"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       TakeSteps='' QtyType='",
					dataTable.Rows[0]["QtyType"].ToString(),
					"' OldQtyType='",
					dataTable.Rows[0]["OldQtyType"].ToString(),
					"' TakeOverID='' Time_BackSee='' ChargeCorp='' ConfirmDate='' "
				}));
				string text10 = "     mrID='' c1='' mrOperator='' mrQtyType='' mrQty='' mrAllowance='' mrRemark=''\n";
				if (!text9.Equals(""))
				{
					dataTable2 = DALCommon.GetList_HL(0, "ks_qtylist", "ID,_Date,Operator,QtyType,Qty,Allowance,Remark", 0, 0, string.Format("BillID={0} or (SN='{1}' and isnull(SN,'')<>'') and _Date=(select max(_Date) from ks_qtylist where BillID={0} or (SN='{1}' and isnull(SN,'')<>''))", text9, text8), "ID desc", out num2).Tables[0];
					if (dataTable2.Rows.Count > 0)
					{
						text10 = string.Concat(new string[]
						{
							"     mrID='",
							dataTable2.Rows[0]["ID"].ToString(),
							"' c1='",
							dataTable2.Rows[0]["_Date"].ToString(),
							"' mrOperator='",
							dataTable2.Rows[0]["Operator"].ToString(),
							"' mrInfo='"
						});
						for (int i = 0; i < dataTable2.Rows.Count; i++)
						{
							text10 += string.Format("(类型：{0},读数：{1},额定量：{2},备注：{3};)", new object[]
							{
								dataTable2.Rows[i]["QtyType"].ToString(),
								dataTable2.Rows[i]["Qty"].ToString(),
								dataTable2.Rows[i]["Allowance"].ToString(),
								dataTable2.Rows[i]["Remark"].ToString()
							});
						}
						text10 += "' \n";
					}
				}
				stringBuilder.Append(text10);
				stringBuilder.Append("/> \n");
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("<s:Schema id='RowsetSchema'>\r\n\t<s:ElementType name='row' content='eltOnly' rs:updatable='true'>\r\n\t\t<s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo'\r\n\t\t\t rs:basetable='ServicesProcess' rs:basecolumn='ID' rs:keycolumn='true'>\r\n\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='DoStyle' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesProcess' rs:basecolumn='DoStyle'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Person' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Dept' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Operator' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c5' rs:name='_Date' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesProcess' rs:basecolumn='_Date'>\r\n\t\t\t<s:datatype dt:type='dateTime' rs:dbtype='timestamp' dt:maxLength='16' rs:scale='3' rs:precision='23' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='TakeSteps' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesProcess' rs:basecolumn='TakeSteps'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2000'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='StartTime' rs:number='8' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='dateTime' rs:dbtype='timestamp' dt:maxLength='16' rs:scale='3' rs:precision='23' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Spending' rs:number='9' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='106'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='ArrivedTime' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesProcess' rs:basecolumn='ArrivedTime'>\r\n\t\t\t<s:datatype dt:type='dateTime' rs:dbtype='timestamp' dt:maxLength='16' rs:scale='3' rs:precision='23' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Reason' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesProcess' rs:basecolumn='Reason'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='DoDept' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesProcess' rs:basecolumn='DoDept'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='DoOperator' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesProcess' rs:basecolumn='DoOperator'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='visitdate' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesProcess' rs:basecolumn='visitdate'>\r\n\t\t\t<s:datatype dt:type='dateTime' rs:dbtype='timestamp' dt:maxLength='16' rs:scale='3' rs:precision='23' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n        <s:AttributeType name='Course' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesProcess' rs:basecolumn='Course'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:extends type='rs:rowbase'/>\r\n\t</s:ElementType>\r\n</s:Schema>\r\n<rs:data>\r\n");
			if (!text9.Equals(""))
			{
				dataTable2 = DALCommon.GetDataList("fw_servicesprocess", "ID,DoStyle,Person,Dept,Operator,_Date,TakeSteps,StartTime,Spending,ArrivedTime,Reason,DoDept,DoOperator,visitdate,Course", "BillID=" + text9).Tables[0];
				if (dataTable2.Rows.Count > 0)
				{
					for (int i = 0; i < dataTable2.Rows.Count; i++)
					{
						stringBuilder.Append(string.Concat(new string[]
						{
							"     <z:row ID='",
							dataTable2.Rows[i]["ID"].ToString(),
							"' DoStyle='",
							dataTable2.Rows[i]["DoStyle"].ToString(),
							"' Person='",
							dataTable2.Rows[i]["Person"].ToString(),
							"' Dept='",
							dataTable2.Rows[i]["Dept"].ToString(),
							"' Operator='",
							dataTable2.Rows[i]["Operator"].ToString(),
							"' c5='",
							dataTable2.Rows[i]["_Date"].ToString(),
							"'\n"
						}));
						stringBuilder.Append(string.Concat(new string[]
						{
							"     TakeSteps='",
							dataTable2.Rows[i]["TakeSteps"].ToString(),
							"' StartTime='",
							dataTable2.Rows[i]["StartTime"].ToString(),
							"' Spending='",
							dataTable2.Rows[i]["Spending"].ToString(),
							"' ArrivedTime='",
							dataTable2.Rows[i]["ArrivedTime"].ToString(),
							"'\n"
						}));
						stringBuilder.Append(string.Concat(new string[]
						{
							"     Reason='",
							dataTable2.Rows[i]["Reason"].ToString(),
							"' DoDept='",
							dataTable2.Rows[i]["DoDept"].ToString(),
							"' Course='",
							dataTable2.Rows[i]["Course"].ToString(),
							"' DoOperator='",
							dataTable2.Rows[i]["DoOperator"].ToString(),
							"'/>\n"
						}));
					}
				}
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("<s:Schema id='RowsetSchema'>\r\n\t<s:ElementType name='row' content='eltOnly' rs:updatable='true'>\r\n\t\t<s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo'\r\n\t\t\t rs:basetable='ServicesMaterial' rs:basecolumn='ID' rs:keycolumn='true'>\r\n\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='GoodsNO' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='GoodsNO'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c2' rs:name='_Name' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Spec' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='Spec'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='ProductBrand' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Unit' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Qty' rs:number='7' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='LQty' rs:number='8' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Price' rs:number='9' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='TaxRate' rs:number='10' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='TaxAmount' rs:number='10' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Total' rs:number='10' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='SN' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesMaterial' rs:basecolumn='SN'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='8000'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='MaintenancePeriod' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesMaterial' rs:basecolumn='MaintenancePeriod'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='PeriodEndDate' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesMaterial' rs:basecolumn='PeriodEndDate'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='ChargeStyle' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesMaterial' rs:basecolumn='ChargeStyle'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='OutSourcing' rs:number='15'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2' rs:maybenull='false'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='OutCostPrice' rs:number='16' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Remark' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesMaterial' rs:basecolumn='Remark'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:extends type='rs:rowbase'/>\r\n\t</s:ElementType>\r\n</s:Schema>\r\n");
			stringBuilder.Append("     <rs:data> \n");
			if (!text9.Equals(""))
			{
				dataTable2 = DALCommon.GetDataList("fw_servicesmaterial", "ID,GoodsNO,_Name,Spec,ProductBrand,Unit,Qty,LQty,Price,Total,SN,MaintenancePeriod,PeriodEndDate,ChargeStyle,OutSourcing,OutCostPrice,Remark", "BillID=" + text9).Tables[0];
				if (dataTable2.Rows.Count > 0)
				{
					for (int i = 0; i < dataTable2.Rows.Count; i++)
					{
						stringBuilder.Append(string.Concat(new string[]
						{
							"     <z:row ID='",
							dataTable2.Rows[i]["ID"].ToString(),
							"' GoodsNO='",
							dataTable2.Rows[i]["GoodsNO"].ToString(),
							"' c2='",
							dataTable2.Rows[i]["_Name"].ToString(),
							"' Spec='",
							dataTable2.Rows[i]["Spec"].ToString(),
							"' ProductBrand='",
							dataTable2.Rows[i]["ProductBrand"].ToString(),
							"' Unit='",
							dataTable2.Rows[i]["Unit"].ToString(),
							"'\n"
						}));
						stringBuilder.Append(string.Concat(new string[]
						{
							"     Qty='",
							dataTable2.Rows[i]["Qty"].ToString(),
							"' LQty='",
							dataTable2.Rows[i]["LQty"].ToString(),
							"' Price='",
							dataTable2.Rows[i]["Price"].ToString(),
							"' Total='",
							dataTable2.Rows[i]["Total"].ToString(),
							"' SN='",
							dataTable2.Rows[i]["SN"].ToString(),
							"' MaintenancePeriod='",
							dataTable2.Rows[i]["MaintenancePeriod"].ToString(),
							"' PeriodEndDate='",
							dataTable2.Rows[i]["PeriodEndDate"].ToString(),
							"' ChargeStyle='",
							dataTable2.Rows[i]["ChargeStyle"].ToString(),
							"'\n"
						}));
						stringBuilder.Append(string.Concat(new string[]
						{
							"     OutSourcing='",
							dataTable2.Rows[i]["OutSourcing"].ToString(),
							"' OutCostPrice='",
							dataTable2.Rows[i]["OutCostPrice"].ToString(),
							"' Remark='",
							dataTable2.Rows[i]["Remark"].ToString(),
							"'/>\n"
						}));
					}
				}
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("<s:Schema id='RowsetSchema'>\r\n\t<s:ElementType name='row' content='eltOnly' rs:updatable='true'>\r\n\t\t<s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo'\r\n\t\t\t rs:basetable='ServicesItem' rs:basecolumn='ID' rs:keycolumn='true'>\r\n\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='ItemNO' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesItemList' rs:basecolumn='ItemNO'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c2' rs:name='_Name' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesItemList' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Price' rs:number='4' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='dPoint' rs:number='5' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='TecDeduct' rs:number='6' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Tec' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesItem' rs:basecolumn='Tec'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='ChargeStyle' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesItem' rs:basecolumn='ChargeStyle'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='bComplete' rs:number='9'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2' rs:maybenull='false'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Remark' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesItem' rs:basecolumn='Remark'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:extends type='rs:rowbase'/>\r\n\t</s:ElementType>\r\n</s:Schema>\r\n<rs:data>\r\n");
			if (!text9.Equals(""))
			{
				dataTable2 = DALCommon.GetDataList("fw_servicesitem", "ID,ItemNO,_Name,Price,dPoint,TecDeduct,Tec,ChargeStyle,bComplete,Remark", "BillID=" + text9).Tables[0];
				if (dataTable2.Rows.Count > 0)
				{
					for (int i = 0; i < dataTable2.Rows.Count; i++)
					{
						stringBuilder.Append(string.Concat(new string[]
						{
							"     <z:row ID='",
							dataTable2.Rows[i]["ID"].ToString(),
							"' ItemNO='",
							dataTable2.Rows[i]["ItemNO"].ToString(),
							"' c2='",
							dataTable2.Rows[i]["_Name"].ToString(),
							"' Price='",
							dataTable2.Rows[i]["Price"].ToString(),
							"' dPoint='",
							dataTable2.Rows[i]["dPoint"].ToString(),
							"' TecDeduct='",
							dataTable2.Rows[i]["TecDeduct"].ToString(),
							"' Tec='",
							dataTable2.Rows[i]["Tec"].ToString(),
							"' ChargeStyle='",
							dataTable2.Rows[i]["ChargeStyle"].ToString(),
							"'\n"
						}));
						stringBuilder.Append(string.Concat(new string[]
						{
							"     bComplete='",
							dataTable2.Rows[i]["bComplete"].ToString(),
							"' Remark='",
							dataTable2.Rows[i]["Remark"].ToString(),
							"'/>\n"
						}));
					}
				}
			}
			stringBuilder.Append("</rs:data>\n");
		}
		if (text2.ToLower() == "jsd" || text2.ToLower() == "xd")
		{
			decimal d5 = 0m;
			decimal d6 = 0m;
			decimal d7 = 0m;
			decimal d8 = 0m;
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("     <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("        <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("     \t rs:basetable='ServicesItem' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='BillID' rs:number='2' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("     \t rs:basetable='ServicesItem' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='ItemID' rs:number='3' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("     \t rs:basetable='ServicesItem' rs:basecolumn='ItemID'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='Price' rs:number='4' rs:nullable='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='dPoint' rs:number='5' rs:nullable='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='Tec' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='ServicesItem' rs:basecolumn='Tec'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='ChargeStyle' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='ServicesItem' rs:basecolumn='ChargeStyle'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='TecDeduct' rs:number='8' rs:nullable='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='Remark' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='ServicesItem' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='ItemNO' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='ServicesItemList' rs:basecolumn='ItemNO'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='c10' rs:name='_Name' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='ServicesItemList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='c11' rs:name='ID' rs:number='12' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("     \t rs:basetable='ServicesItemList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("     </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable2 = DALCommon.GetDataList("fw_servicesitem", "", " [BillID]=" + text3.ToString()).Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					string a = Convert.ToString(dataTable2.Rows[i]["ChargeStyle"].ToString());
					decimal d9 = Convert.ToDecimal(dataTable2.Rows[i]["Price"].ToString());
					if (a == "客付")
					{
						d7 += d9;
					}
					else if (a == "厂付")
					{
						d8 += d9;
					}
					stringBuilder.Append(string.Concat(new string[]
					{
						"<z:row ID='1' BillID='2' ItemID='8' Price='",
						dataTable2.Rows[i]["Price"].ToString(),
						"' dPoint='",
						dataTable2.Rows[i]["dPoint"].ToString(),
						"' Tec='",
						dataTable2.Rows[i]["Tec"].ToString(),
						"' ChargeStyle='",
						dataTable2.Rows[i]["ChargeStyle"].ToString(),
						"' TecDeduct='",
						dataTable2.Rows[i]["TecDeduct"].ToString(),
						"' Remark='",
						dataTable2.Rows[i]["Remark"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"ItemNO='",
						dataTable2.Rows[i]["ItemNO"].ToString(),
						"' c10='",
						dataTable2.Rows[i]["_Name"].ToString(),
						"' c11='8'/> \n"
					}));
				}
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("     <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("         <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("     \t rs:basetable='ServicesMaterial' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='GoodsID' rs:number='2' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("     \t rs:basetable='ServicesMaterial' rs:basecolumn='GoodsID'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='UnitID' rs:number='3' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("     \t rs:basetable='ServicesMaterial' rs:basecolumn='UnitID'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='Remark' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='ServicesMaterial' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='GoodsNO' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='GoodsNO'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='c5' rs:name='_Name' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='Spec' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='Spec'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='MaintenancePeriod' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='ServicesMaterial' rs:basecolumn='MaintenancePeriod'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='PeriodEndDate' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='ServicesMaterial' rs:basecolumn='PeriodEndDate'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='ChargeStyle' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='ServicesMaterial' rs:basecolumn='ChargeStyle'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='ProductBrand' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='Unit' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='BillID' rs:number='13' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("     \t rs:basetable='ServicesMaterial' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SN' rs:number='21' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' dt:maxLength='5000' />  \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='Qty' rs:number='14' rs:nullable='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='Price' rs:number='15' rs:nullable='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='TaxRate' rs:number='15' rs:nullable='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='TaxAmount' rs:number='15' rs:nullable='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='Total' rs:number='16' rs:nullable='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='c16' rs:name='ID' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='c17' rs:name='ID' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='GoodsUnit' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='c18' rs:name='ID' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='c19' rs:name='ID' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("     </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable3 = DALCommon.GetDataList("fw_servicesmaterial", "", " [BillID]=" + text3.ToString()).Tables[0];
			if (dataTable3.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable3.Rows.Count; i++)
				{
					string a = Convert.ToString(dataTable3.Rows[i]["ChargeStyle"].ToString());
					decimal d9 = Convert.ToDecimal(dataTable3.Rows[i]["Total"].ToString());
					if (a == "客付")
					{
						d5 += d9;
					}
					else if (a == "厂付")
					{
						d6 += d9;
					}
					stringBuilder.Append(string.Concat(new string[]
					{
						"<z:row ID='1' GoodsID='9' UnitID='10' Remark='",
						dataTable3.Rows[i]["Remark"].ToString(),
						"' GoodsNO='",
						dataTable3.Rows[i]["GoodsNO"].ToString(),
						"' c5='",
						dataTable3.Rows[i]["_Name"].ToString(),
						"' Spec='",
						dataTable3.Rows[i]["Spec"].ToString(),
						"' MaintenancePeriod='",
						dataTable3.Rows[i]["MaintenancePeriod"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"PeriodEndDate='",
						dataTable3.Rows[i]["PeriodEndDate"].ToString(),
						"' ChargeStyle='",
						dataTable3.Rows[i]["ChargeStyle"].ToString(),
						"' ProductBrand='",
						dataTable3.Rows[i]["ProductBrand"].ToString(),
						"' Unit='",
						dataTable3.Rows[i]["Unit"].ToString(),
						"' BillID='6' Qty='",
						dataTable3.Rows[i]["Qty"].ToString(),
						"' Price='",
						dataTable3.Rows[i]["Price"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						" Total='",
						dataTable3.Rows[i]["Total"].ToString(),
						"' TaxRate='",
						dataTable3.Rows[i]["TaxRate"].ToString(),
						"' TaxAmount='",
						dataTable3.Rows[i]["TaxAmount"].ToString(),
						"' SN='",
						dataTable3.Rows[i]["SN"].ToString(),
						"' c16='9' c17='10' c18='1' c19='20'/> \n"
					}));
				}
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append(" \t<s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t\t    <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='ID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BillID' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='TakeDept' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='TakeDept'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DisposalDept' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='DisposalDept'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='curStatus' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='curStatus'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='TakeOverID' rs:number='6' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='TakeOverID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DisposalID' rs:number='7' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='DisposalID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ServicesType' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ServicesType'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='TakeStyle' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='TakeStyle'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='TakeStyleID' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='TakeStyleID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Time_Make' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Time_Make'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Time_TakeOver' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Time_TakeOver'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Time_Start' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Time_Start'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Time_Over' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Time_Over'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Time_Payee' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Time_Payee'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='OperatorID' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='OperatorID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Time_BackSee' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Time_BackSee'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Time_Close' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Time_Close'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Operator' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Operator'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Person' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Person'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='PersonID' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='PersonID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='StartOperator' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='StartOperator'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='PayeeOper' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='PayeeOper'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChkOperator' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ChkOperator'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BackSeeOper' rs:number='25' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='BackSeeOper'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CustomerName' rs:number='26' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='CustomerName'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='LinkMan' rs:number='27' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='fw_services' rs:basecolumn='LinkMan'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Tel' rs:number='28' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Tel'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='UsePerson' rs:number='29' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='UsePerson'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='UsePersonDept' rs:number='30' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='UsePersonDept'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='UsePersonTel' rs:number='31' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='UsePersonTel'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Area' rs:number='32' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Area'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Adr' rs:number='33' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Adr'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='200'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ProductSN1' rs:number='34' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ProductSN1'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ProductSN2' rs:number='35' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ProductSN2'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BuyDate' rs:number='36' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='BuyDate'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BuyFrom' rs:number='37' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='BuyFrom'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ProductClass' rs:number='38' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ProductClass'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ProductModel' rs:number='39' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ProductModel'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ProductBrand' rs:number='40' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ProductBrand'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Aspect' rs:number='41' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Aspect'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CusType' rs:number='42' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='CusType'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='WarrantyID' rs:number='43' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='WarrantyID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Accessory' rs:number='44' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Accessory'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='200'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Fault' rs:number='45' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Fault'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='1000'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Warranty' rs:number='46' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Warranty'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c46' rs:name='_PRI' rs:number='47' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='_PRI'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BuyInvoice' rs:number='48' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='BuyInvoice'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='dPoint' rs:number='49' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='dPoint'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Speding' rs:number='50' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Speding'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='bRepair' rs:number='51' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='bRepair'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SaveID' rs:number='52' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='SaveID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SupplierID' rs:number='53' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='SupplierID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChargeCorp' rs:number='54' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ChargeCorp'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DisposalOper' rs:number='55' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='DisposalOper'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SubscribeTime' rs:number='56' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='SubscribeTime'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SubscribeConnectTime' rs:number='57' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='SubscribeConnectTime'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SubscribePrice' rs:number='58' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='SubscribePrice'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='PreCharge' rs:number='59' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='PreCharge'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RepairStatus' rs:number='60' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='RepairStatus'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RepairType' rs:number='61' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='RepairType'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='8' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RepairCorpID' rs:number='62' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='RepairCorpID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RepairCorp' rs:number='63' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='RepairCorp'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Remark' rs:number='64' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='500'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CancelReason' rs:number='65' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='CancelReason'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RepairSndDate' rs:number='66' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='RepairSndDate'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RepairRcvDate' rs:number='67' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='RepairRcvDate'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RepairCost' rs:number='68' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='RepairCost'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CustomerID' rs:number='69' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='CustomerID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='WarrantyChargeCorpID' rs:number='70' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='WarrantyChargeCorpID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='PostNO' rs:number='71' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='PostNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Postage' rs:number='72' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Postage'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='MaterailCost' rs:number='73' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='MaterailCost'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ExtraCost' rs:number='74' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ExtraCost'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Fee_Materail' rs:number='75' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Fee_Materail'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Fee_Labor' rs:number='76' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Fee_Labor'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Fee_Add' rs:number='77' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Fee_Add'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='WarrantyChargeValue' rs:number='78' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='WarrantyChargeValue'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChargeValue' rs:number='79' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ChargeValue'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='InCash' rs:number='104' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='InCash'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='InCashCh' rs:number='105' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='InCashCh'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Fee_Total' rs:number='80' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Fee_Total'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Profit' rs:number='81' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='Profit'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='WarrantyEndDate' rs:number='82' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='WarrantyEndDate'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='WarrantyBound' rs:number='83' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='WarrantyBound'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='200'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='GoodsTo' rs:number='84' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='GoodsTo'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ConnectDate' rs:number='85' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ConnectDate'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='bCall' rs:number='86' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='bCall'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SmsStatus' rs:number='87' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='fw_services' \n");
			stringBuilder.Append("\t\t\t rs:basecolumn='SmsStatus'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ConfirmDate' rs:number='88' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='fw_services' rs:basecolumn='ConfirmDate'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BranchName' rs:number='89' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='Value'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='CusChargeMoney' rs:number='90' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt21Cus' \n");
			stringBuilder.Append("     \t rs:basetable='wt1_ServicesDoc' rs:basecolumn='CusChargeMoney'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='number' rs:dbtype='currency' dt:maxLength='8' rs:precision='19' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='SupChargeMoney' rs:number='91' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt21Cus' \n");
			stringBuilder.Append("     \t rs:basetable='wt1_ServicesDoc' rs:basecolumn='SupChargeMoney'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='number' rs:dbtype='currency' dt:maxLength='8' rs:precision='19' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='CusServiceChargeMoney' rs:number='92' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt21Cus' \n");
			stringBuilder.Append("     \t rs:basetable='wt1_ServicesDoc' rs:basecolumn='CusServiceChargeMoney'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='number' rs:dbtype='currency' dt:maxLength='8' rs:precision='19' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='SupServiceChargeMoney' rs:number='93' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt21Cus' \n");
			stringBuilder.Append("     \t rs:basetable='wt1_ServicesDoc' rs:basecolumn='SupServiceChargeMoney'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='number' rs:dbtype='currency' dt:maxLength='8' rs:precision='19' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CorpName' rs:number='94' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='CorpName'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CorpLinkMan' rs:number='95' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='LinkMan'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CorpTel' rs:number='96' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='Tel'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CorpZip' rs:number='97' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='Zip'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CorpFax' rs:number='98' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='Fax'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CorpArea' rs:number='99' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='Area'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CorpAdr' rs:number='100' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='Adr'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DeviceNO' rs:number='100' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='ServicesList' rs:basecolumn='DeviceNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='TakeSteps' rs:number='101' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='ServicesList' rs:basecolumn='TakeSteps'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='8000' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='QtyType' rs:number='102' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='ServicesList' rs:basecolumn='QtyType'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='8000' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='OldQtyType' rs:number='103' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='ServicesList' rs:basecolumn='OldQtyType'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='8000' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("     </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable = DALCommon.GetDataList("fw_services", "", " [ID]=" + text3.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"       <z:row ID='1' BillID='",
					dataTable.Rows[0]["BillID"].ToString(),
					"' TakeDept='",
					dataTable.Rows[0]["TakeDept"].ToString(),
					"' DisposalDept='",
					dataTable.Rows[0]["DisposalDept"].ToString(),
					"' curStatus='",
					dataTable.Rows[0]["curStatus"].ToString(),
					"' TakeOverID='1' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       DisposalID='1' ServicesType='",
					dataTable.Rows[0]["ServicesType"].ToString(),
					"' TakeStyle='",
					dataTable.Rows[0]["TakeStyle"].ToString(),
					"' TakeStyleID='4' Time_Make='",
					dataTable.Rows[0]["Time_Make"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       Time_TakeOver='",
					dataTable.Rows[0]["Time_TakeOver"].ToString(),
					"' Time_Start='",
					dataTable.Rows[0]["Time_Start"].ToString(),
					"' Time_Over='",
					dataTable.Rows[0]["Time_Over"].ToString(),
					"' Time_Payee='",
					dataTable.Rows[0]["Time_Payee"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       OperatorID='6' Time_Close='",
					dataTable.Rows[0]["Time_Close"].ToString(),
					"' Operator='",
					dataTable.Rows[0]["Operator"].ToString(),
					"' Person='",
					dataTable.Rows[0]["Person"].ToString(),
					"' PersonID='6' StartOperator='",
					dataTable.Rows[0]["StartOperator"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       PayeeOper='",
					dataTable.Rows[0]["PayeeOper"].ToString(),
					"' ChkOperator='",
					dataTable.Rows[0]["ChkOperator"].ToString(),
					"' CustomerName='",
					dataTable.Rows[0]["CustomerName"].ToString(),
					"' LinkMan='",
					dataTable.Rows[0]["LinkMan"].ToString(),
					"' Tel='",
					dataTable.Rows[0]["Tel"].ToString(),
					"' UsePerson='",
					dataTable.Rows[0]["UsePerson"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       UsePersonDept='",
					dataTable.Rows[0]["UsePersonDept"].ToString(),
					"' UsePersonTel='",
					dataTable.Rows[0]["UsePersonTel"].ToString(),
					"' Area='",
					dataTable.Rows[0]["Area"].ToString(),
					"' Adr='",
					dataTable.Rows[0]["Adr"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       ProductSN1='",
					dataTable.Rows[0]["ProductSN1"].ToString(),
					"' ProductSN2='",
					dataTable.Rows[0]["ProductSN2"].ToString(),
					"' BuyFrom='",
					dataTable.Rows[0]["BuyFrom"].ToString(),
					"' ProductClass='",
					dataTable.Rows[0]["ProductClass"].ToString(),
					"' ProductModel='",
					dataTable.Rows[0]["ProductModel"].ToString(),
					"' ProductBrand='",
					dataTable.Rows[0]["ProductBrand"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       Aspect='",
					dataTable.Rows[0]["Aspect"].ToString(),
					"' CusType='1' WarrantyID='3' Accessory='",
					dataTable.Rows[0]["Accessory"].ToString(),
					"' Fault='",
					dataTable.Rows[0]["Fault"].ToString(),
					"' Warranty='",
					dataTable.Rows[0]["Warranty"].ToString(),
					"' c46='",
					dataTable.Rows[0]["_PRI"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       BuyInvoice='",
					dataTable.Rows[0]["BuyInvoice"].ToString(),
					"' dPoint='",
					dataTable.Rows[0]["dPoint"].ToString(),
					"' Speding='",
					dataTable.Rows[0]["Speding"].ToString(),
					"' bRepair='",
					dataTable.Rows[0]["bRepair"].ToString(),
					"' SaveID='",
					dataTable.Rows[0]["SaveID"].ToString(),
					"' SupplierID='",
					dataTable.Rows[0]["SupplierID"].ToString(),
					"' DisposalOper='",
					dataTable.Rows[0]["DisposalOper"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       SubscribeTime='",
					dataTable.Rows[0]["SubscribeTime"].ToString(),
					"' SubscribeConnectTime='",
					dataTable.Rows[0]["SubscribeConnectTime"].ToString(),
					"' SubscribePrice='",
					dataTable.Rows[0]["SubscribePrice"].ToString(),
					"' PreCharge='",
					dataTable.Rows[0]["PreCharge"].ToString(),
					"' RepairStatus='",
					dataTable.Rows[0]["RepairStatus"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       RepairType='",
					dataTable.Rows[0]["RepairType"].ToString(),
					"' RepairCorpID='4' RepairCorp='",
					dataTable.Rows[0]["RepairCorp"].ToString(),
					"' Remark='",
					dataTable.Rows[0]["Remark"].ToString(),
					"' CancelReason='",
					dataTable.Rows[0]["CancelReason"].ToString(),
					"' RepairSndDate='",
					dataTable.Rows[0]["RepairSndDate"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       RepairRcvDate='",
					dataTable.Rows[0]["RepairRcvDate"].ToString(),
					"' RepairCost='",
					dataTable.Rows[0]["RepairCost"].ToString(),
					"' CustomerID='",
					dataTable.Rows[0]["CustomerID"].ToString(),
					"' WarrantyChargeCorpID='",
					dataTable.Rows[0]["WarrantyChargeCorpID"].ToString(),
					"' PostNO='",
					dataTable.Rows[0]["PostNO"].ToString(),
					"' Postage='",
					dataTable.Rows[0]["Postage"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      MaterailCost='",
					dataTable.Rows[0]["MaterailCost"].ToString(),
					"' ExtraCost='",
					dataTable.Rows[0]["ExtraCost"].ToString(),
					"' Fee_Materail='",
					dataTable.Rows[0]["Fee_Materail"].ToString(),
					"' Fee_Labor='",
					dataTable.Rows[0]["Fee_Labor"].ToString(),
					"' Fee_Add='",
					dataTable.Rows[0]["Fee_Add"].ToString(),
					"' WarrantyChargeValue='",
					dataTable.Rows[0]["WarrantyChargeValue"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       ChargeValue='",
					dataTable.Rows[0]["ChargeValue"].ToString(),
					"' Fee_Total='",
					dataTable.Rows[0]["Fee_Total"].ToString(),
					"' Profit='",
					dataTable.Rows[0]["Profit"].ToString(),
					"' WarrantyEndDate='",
					dataTable.Rows[0]["WarrantyEndDate"].ToString(),
					"' WarrantyBound='",
					dataTable.Rows[0]["WarrantyBound"].ToString(),
					"' GoodsTo='",
					dataTable.Rows[0]["GoodsTo"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      ConnectDate='",
					dataTable.Rows[0]["ConnectDate"].ToString(),
					"' bCall='0' SmsStatus='",
					dataTable.Rows[0]["SmsStatus"].ToString(),
					"' BranchName='",
					sysParm.CorpName,
					"' CorpName='",
					dataTable.Rows[0]["CorpName"].ToString(),
					"' InCashCh='",
					FunLibrary.NumChs(dataTable.Rows[0]["InCash"].ToString(), 2),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      CorpLinkMan='",
					dataTable.Rows[0]["CorpLinkMan"].ToString(),
					"' CorpTel='",
					dataTable.Rows[0]["CorpTel"].ToString(),
					"' CorpZip='",
					dataTable.Rows[0]["CorpZip"].ToString(),
					"' CorpFax='",
					dataTable.Rows[0]["CorpFax"].ToString(),
					"' CorpArea='",
					dataTable.Rows[0]["CorpArea"].ToString(),
					"' CorpAdr='",
					dataTable.Rows[0]["CorpAdr"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"     CusChargeMoney='",
					d5.ToString("#0.00"),
					"' SupChargeMoney='",
					d6.ToString("#0.00"),
					"' CusServiceChargeMoney='",
					d7.ToString("#0.00"),
					"' SupServiceChargeMoney='",
					d8.ToString("#0.00"),
					"' BuyDate='",
					dataTable.Rows[0]["BuyDate"].ToString(),
					"' DeviceNO='",
					dataTable.Rows[0]["DeviceNO"].ToString(),
					"' InCash='",
					dataTable.Rows[0]["InCash"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       TakeSteps='",
					dataTable.Rows[0]["TakeSteps"].ToString(),
					"' QtyType='",
					dataTable.Rows[0]["QtyType"].ToString(),
					"' OldQtyType='",
					dataTable.Rows[0]["OldQtyType"].ToString(),
					"' /> \n"
				}));
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("<s:Schema id='RowsetSchema'>\r\n\t<s:ElementType name='row' content='eltOnly' rs:updatable='true'>\r\n\t\t<s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo'\r\n\t\t\t rs:basetable='ServicesProcess' rs:basecolumn='ID' rs:keycolumn='true'>\r\n\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='DoStyle' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesProcess' rs:basecolumn='DoStyle'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Person' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Dept' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Operator' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c5' rs:name='_Date' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesProcess' rs:basecolumn='_Date'>\r\n\t\t\t<s:datatype dt:type='dateTime' rs:dbtype='timestamp' dt:maxLength='16' rs:scale='3' rs:precision='23' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='TakeSteps' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesProcess' rs:basecolumn='TakeSteps'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2000'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='StartTime' rs:number='8' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='dateTime' rs:dbtype='timestamp' dt:maxLength='16' rs:scale='3' rs:precision='23' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Spending' rs:number='9' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='106'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='ArrivedTime' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesProcess' rs:basecolumn='ArrivedTime'>\r\n\t\t\t<s:datatype dt:type='dateTime' rs:dbtype='timestamp' dt:maxLength='16' rs:scale='3' rs:precision='23' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Reason' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesProcess' rs:basecolumn='Reason'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='DoDept' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesProcess' rs:basecolumn='DoDept'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='DoOperator' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesProcess' rs:basecolumn='DoOperator'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='visitdate' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ServicesProcess' rs:basecolumn='visitdate'>\r\n\t\t\t<s:datatype dt:type='dateTime' rs:dbtype='timestamp' dt:maxLength='16' rs:scale='3' rs:precision='23' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:extends type='rs:rowbase'/>\r\n\t</s:ElementType>\r\n</s:Schema>\r\n<rs:data>\r\n");
			dataTable2 = DALCommon.GetDataList("fw_servicesprocess", "ID,DoStyle,Person,Dept,Operator,_Date,TakeSteps,StartTime,Spending,ArrivedTime,Reason,DoDept,DoOperator,visitdate", " [BillID]=" + text3.ToString()).Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"     <z:row ID='",
						dataTable2.Rows[i]["ID"].ToString(),
						"' DoStyle='",
						dataTable2.Rows[i]["DoStyle"].ToString(),
						"' Person='",
						dataTable2.Rows[i]["Person"].ToString(),
						"' Dept='",
						dataTable2.Rows[i]["Dept"].ToString(),
						"' Operator='",
						dataTable2.Rows[i]["Operator"].ToString(),
						"' c5='",
						dataTable2.Rows[i]["_Date"].ToString(),
						"'\n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"     TakeSteps='",
						dataTable2.Rows[i]["TakeSteps"].ToString(),
						"' StartTime='",
						dataTable2.Rows[i]["StartTime"].ToString(),
						"' Spending='",
						dataTable2.Rows[i]["Spending"].ToString(),
						"' ArrivedTime='",
						dataTable2.Rows[i]["ArrivedTime"].ToString(),
						"'\n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"     Reason='",
						dataTable2.Rows[i]["Reason"].ToString(),
						"' DoDept='",
						dataTable2.Rows[i]["DoDept"].ToString(),
						"' DoOperator='",
						dataTable2.Rows[i]["DoOperator"].ToString(),
						"'/>\n"
					}));
				}
			}
			stringBuilder.Append("     </rs:data> \n");
		}
		if (text2.ToLower() == "fhd")
		{
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append(" \t<s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t\t    <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='RcvSnd' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BillID' rs:number='2' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='RcvSnd' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DeptID' rs:number='3' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='RcvSnd' rs:basecolumn='DeptID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c3' rs:name='_Date' rs:number='4' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='OperatorID' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='RcvSnd' rs:basecolumn='OperatorID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='PersonID' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='RcvSnd' rs:basecolumn='PersonID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='OperationType' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='RcvSnd' rs:basecolumn='OperationType'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RcvType' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='RcvSnd' rs:basecolumn='RcvType'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SndStyleID' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='RcvSnd' rs:basecolumn='SndStyleID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='PostNO' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='RcvSnd' rs:basecolumn='PostNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Postage' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='RcvSnd' rs:basecolumn='Postage'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RcvDeptID' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='RcvSnd' rs:basecolumn='RcvDeptID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CorpName' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='RcvSnd' rs:basecolumn='CorpName'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='LinkMan' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='RcvSnd' rs:basecolumn='LinkMan'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Tel' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='RcvSnd' rs:basecolumn='Tel'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Adr' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='RcvSnd' rs:basecolumn='Adr'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='200'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Zip' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='RcvSnd' rs:basecolumn='Zip'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Summary' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='RcvSnd' rs:basecolumn='Summary'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='8000'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RcvDate' rs:number='19' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SignManID' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='RcvSnd' rs:basecolumn='SignManID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Remark' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='RcvSnd' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2000'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SndDeptNO' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='BranchNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SndDept' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='OperatorNO' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='JobNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Operator' rs:number='25' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='PersonNO' rs:number='26' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='JobNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SignManNO' rs:number='27' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='JobNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SndStyle' rs:number='28' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ShippingStyle' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SndStyleCode' rs:number='29' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ShippingStyle' rs:basecolumn='pyCode'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='25'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Person' rs:number='30' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SignMan' rs:number='31' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RcvDeptNO' rs:number='32' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='BranchNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Status' rs:number='33'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='RcvDept' rs:number='34' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c34' rs:name='ID' rs:number='35' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c35' rs:name='ID' rs:number='36' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c36' rs:name='ID' rs:number='37' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c37' rs:name='ID' rs:number='38' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c38' rs:name='ID' rs:number='39' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c39' rs:name='ID' rs:number='40' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ShippingStyle' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("     </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable = DALCommon.GetDataList("sf_rcvsnd", "", " [ID]=" + text3.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"      <z:row ID='1' BillID='",
					dataTable.Rows[0]["BillID"].ToString(),
					"' DeptID='1' c3='",
					dataTable.Rows[0]["_Date"].ToString(),
					"' OperatorID='1' PersonID='1' OperationType='",
					dataTable.Rows[0]["OperationType"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      RcvType='",
					dataTable.Rows[0]["RcvType"].ToString(),
					"' SndStyleID='1' PostNO='",
					dataTable.Rows[0]["PostNO"].ToString(),
					"' Postage='",
					dataTable.Rows[0]["Postage"].ToString(),
					"' RcvDeptID='2' CorpName='",
					dataTable.Rows[0]["CorpName"].ToString(),
					"' LinkMan='",
					dataTable.Rows[0]["LinkMan"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      Tel='",
					dataTable.Rows[0]["Tel"].ToString(),
					"' Adr='",
					dataTable.Rows[0]["Adr"].ToString(),
					"' Zip='",
					dataTable.Rows[0]["Zip"].ToString(),
					"' Summary='",
					dataTable.Rows[0]["Summary"].ToString(),
					"' RcvDate='",
					dataTable.Rows[0]["RcvDate"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       SignManID='12' Remark='",
					dataTable.Rows[0]["Remark"].ToString(),
					"' SndDeptNO='",
					dataTable.Rows[0]["SndDeptNO"].ToString(),
					"' SndDept='",
					dataTable.Rows[0]["SndDept"].ToString(),
					"' OperatorNO='",
					dataTable.Rows[0]["OperatorNO"].ToString(),
					"' Operator='",
					dataTable.Rows[0]["Operator"].ToString(),
					"' PersonNO='",
					dataTable.Rows[0]["PersonNO"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      SignManNO='",
					dataTable.Rows[0]["SignManNO"].ToString(),
					"' SndStyle='",
					dataTable.Rows[0]["SndStyle"].ToString(),
					"' SndStyleCode='",
					dataTable.Rows[0]["SndStyleCode"].ToString(),
					"' Person='",
					dataTable.Rows[0]["Person"].ToString(),
					"' SignMan='",
					dataTable.Rows[0]["SignMan"].ToString(),
					"' RcvDeptNO='",
					dataTable.Rows[0]["RcvDeptNO"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      Status='",
					dataTable.Rows[0]["Status"].ToString(),
					"' RcvDept='",
					dataTable.Rows[0]["RcvDept"].ToString(),
					"' c34='2' c35='1' c36='12' c37='1' c38='1' c39='1'/> \n"
				}));
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Value' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\trs:basetable='BranchList' rs:basecolumn='Value'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='300'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			stringBuilder.Append(string.Concat(new string[]
			{
				"<z:row BranchName='",
				sysParm.CorpName,
				",电话：",
				sysParm.Tel,
				"' />\n"
			}));
			stringBuilder.Append("     </rs:data> \n");
		}
		if (text2.ToLower() == "skd" || text2.ToLower() == "fkd")
		{
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append(" \t<s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t   <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='zk_incomeexpenses' \n");
			stringBuilder.Append("\t\t rs:basecolumn='ID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='BillID' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='DeptID' rs:number='3' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='zk_incomeexpenses' \n");
			stringBuilder.Append("\t\t rs:basecolumn='DeptID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Type' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='Type'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='RecType' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='RecType'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c5' rs:name='_Date' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='_Date'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ChkDate' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='ChkDate'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='PersonID' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='PersonID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='CusType' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='CusType'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='CustomerName' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='CustomerName'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='CustomerID' rs:number='11' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='zk_incomeexpenses' \n");
			stringBuilder.Append("\t\t rs:basecolumn='CustomerID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='RecMoney' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='RecMoney'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='RealRecMoney' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='RealRecMoney'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='PreMoney' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='PreMoney'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='DueMoney' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='DueMoney'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='RealDueMoney' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='RealDueMoney'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ChargeModeID' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='ChargeModeID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='AccountID' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='AccountID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ItemID' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='ItemID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='InvoiceClassID' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='InvoiceClassID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='InvoiceNO' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='InvoiceNO'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='CheckNO' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='CheckNO'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='VoucherNO' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='VoucherNO'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ChkOperatorID' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='ChkOperatorID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Status' rs:number='25' rs:writeunknown='true' rs:basecatalog='wt_it' rs:basetable='zk_incomeexpenses' \n");
			stringBuilder.Append("\t\t rs:basecolumn='Status'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='6' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Remark' rs:number='26' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2000'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='OperatorNO' rs:number='27' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='OperatorNO'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Operator' rs:number='28' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='Operator'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ChkJobNO' rs:number='29' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='ChkJobNO'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ChkOperator' rs:number='30' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='ChkOperator'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ChargeStyle' rs:number='31' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='ChargeStyle'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ChargeStyleCode' rs:number='32' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='ChargeStyleCode'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='25'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Account' rs:number='33' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='Account'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ChargeItem' rs:number='34' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='ChargeItem'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='InvoiceClass' rs:number='35' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='InvoiceClass'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='InvoiceClsCode' rs:number='36' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='InvoiceClsCode'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='25'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Dept' rs:number='37' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='Dept'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='InvoiceDate' rs:number='38' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='InvoiceDate'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='InvoiceAmount' rs:number='39' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='InvoiceAmount'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='iFlag' rs:number='40' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='iFlag'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='CustomerNO' rs:number='41' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:basetable='zk_incomeexpenses' rs:basecolumn='CustomerNO'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("     </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable = DALCommon.GetDataList("zk_incomeexpenses", "", " [ID]=" + text3.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"     <z:row ID='1' BillID='",
					dataTable.Rows[0]["BillID"].ToString(),
					"' DeptID='1' Type='",
					dataTable.Rows[0]["Type"].ToString(),
					"' RecType='",
					dataTable.Rows[0]["RecType"].ToString(),
					"' c5='",
					dataTable.Rows[0]["_Date"].ToString(),
					"' PersonID='1' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"     CusType='2' CustomerName='",
					dataTable.Rows[0]["CustomerName"].ToString(),
					"' CustomerID='4' RecMoney='",
					dataTable.Rows[0]["RecMoney"].ToString(),
					"' RealRecMoney='",
					dataTable.Rows[0]["RealRecMoney"].ToString(),
					"' PreMoney='",
					dataTable.Rows[0]["PreMoney"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"     DueMoney='",
					dataTable.Rows[0]["DueMoney"].ToString(),
					"' CustomerNO='",
					dataTable.Rows[0]["CustomerNO"].ToString(),
					"' RealDueMoney='",
					dataTable.Rows[0]["RealDueMoney"].ToString(),
					"' InvoiceNO='",
					dataTable.Rows[0]["InvoiceNO"].ToString(),
					"' CheckNO='",
					dataTable.Rows[0]["CheckNO"].ToString(),
					"' VoucherNO='",
					dataTable.Rows[0]["VoucherNO"].ToString(),
					"' Status='",
					dataTable.Rows[0]["Status"].ToString(),
					"' Remark='",
					dataTable.Rows[0]["Remark"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"     Account='",
					dataTable.Rows[0]["Account"].ToString(),
					"' ChargeItem='",
					dataTable.Rows[0]["ChargeItem"].ToString(),
					"' ChargeStyle='",
					dataTable.Rows[0]["ChargeStyle"].ToString(),
					"' InvoiceClass='",
					dataTable.Rows[0]["InvoiceClass"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"     OperatorNO='",
					dataTable.Rows[0]["OperatorNO"].ToString(),
					"' ChkOperator='",
					dataTable.Rows[0]["ChkOperator"].ToString(),
					"' ChkDate='",
					dataTable.Rows[0]["ChkDate"].ToString(),
					"' Operator='",
					dataTable.Rows[0]["Operator"].ToString(),
					"' InvoiceAmount='",
					dataTable.Rows[0]["InvoiceAmount"].ToString(),
					"' InvoiceDate='",
					dataTable.Rows[0]["InvoiceDate"].ToString(),
					"' /> \n"
				}));
			}
			stringBuilder.Append("     </rs:data> \n");
		}
		if (text2.ToLower() == "bxd")
		{
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append(" \t<s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append(" \t<s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo'\r\n\t\t\t rs:basetable='Expense' rs:basecolumn='ID' rs:keycolumn='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c1' rs:name='_Date' rs:number='2' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Operator' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='dMoney' rs:number='4' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Summary' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Expense' rs:basecolumn='Summary'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='300'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Status' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Expense' rs:basecolumn='Status'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='ChkOperator' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='ChkDate' rs:number='8' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='ChkOperatorID' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Expense' rs:basecolumn='ChkOperatorID'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='OperatorID' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Expense' rs:basecolumn='OperatorID'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='FromAdr' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Expense' rs:basecolumn='FromAdr'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='200'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='ToAdr' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Expense' rs:basecolumn='ToAdr'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='200'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='PaymentOperID' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Expense' rs:basecolumn='PaymentOperID'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='PaymentOper' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='PaymentDate' rs:number='15' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Account' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Account' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='AccountID' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Expense' rs:basecolumn='AccountID'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='ItemID' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Expense' rs:basecolumn='ItemID'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Dept' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Item' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ChargeItem' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Remark' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Expense' rs:basecolumn='Remark'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='500'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='DeptID' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='DeptID'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='RelatedBusiness' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Expense' rs:basecolumn='RelatedBusiness'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c23' rs:name='ID' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c24' rs:name='ID' rs:number='25' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c25' rs:name='ID' rs:number='26' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c26' rs:name='ID' rs:number='27' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c27' rs:name='ID' rs:number='28' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Account' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c28' rs:name='ID' rs:number='29' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ChargeItem' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("     </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable = DALCommon.GetDataList("zk_expense", "", " [ID]=" + text3.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"     <z:row ID='1' c1='",
					dataTable.Rows[0]["_Date"].ToString(),
					"' Operator='",
					dataTable.Rows[0]["Operator"].ToString(),
					"' dMoney='",
					dataTable.Rows[0]["dMoney"].ToString(),
					"' Summary='",
					dataTable.Rows[0]["Summary"].ToString(),
					"' Status='",
					dataTable.Rows[0]["Status"].ToString(),
					"' ChkOperator='",
					dataTable.Rows[0]["ChkOperator"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       ChkDate='",
					dataTable.Rows[0]["ChkDate"].ToString(),
					"' FromAdr='",
					dataTable.Rows[0]["FromAdr"].ToString(),
					"' ToAdr='",
					dataTable.Rows[0]["ToAdr"].ToString(),
					"' PaymentOperID='",
					dataTable.Rows[0]["PaymentOperID"].ToString(),
					"' PaymentOper='",
					dataTable.Rows[0]["PaymentOper"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       PaymentDate='",
					dataTable.Rows[0]["PaymentDate"].ToString(),
					"' Account='",
					dataTable.Rows[0]["Account"].ToString(),
					"' Dept='",
					dataTable.Rows[0]["Dept"].ToString(),
					"' Item='",
					dataTable.Rows[0]["Item"].ToString(),
					"' Remark='",
					dataTable.Rows[0]["Remark"].ToString(),
					"' \n"
				}));
				stringBuilder.Append("       RelatedBusiness='" + dataTable.Rows[0]["RelatedBusiness"].ToString() + "' c23='1' c24='1' c25='1' c26='1' c27='1' c28='2'/> \n");
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t   <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo'\r\n\t\t\t rs:basetable='ExpenseDetail' rs:basecolumn='ID' rs:keycolumn='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='BillID' rs:number='2' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo'\r\n\t\t\t rs:basetable='ExpenseDetail' rs:basecolumn='BillID'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c2' rs:name='_Name' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ExpenseItem' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='ItemID' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ExpenseDetail' rs:basecolumn='ItemID'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Price' rs:number='5' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo'\r\n\t\t\t rs:basetable='ExpenseDetail' rs:basecolumn='Price'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='numeric' dt:maxLength='19' rs:scale='4' rs:precision='18' rs:fixedlength='true'\r\n\t\t\t rs:maybenull='false'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Remark' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ExpenseDetail' rs:basecolumn='Remark'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Sequence' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='Sequence'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c6' rs:name='ID' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ExpenseItem' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>");
			stringBuilder.Append("\t <s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable2 = DALCommon.GetDataList("zk_expensedetail", "", " [BillID]=" + text3.ToString()).Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new object[]
					{
						"<z:row ID='",
						dataTable2.Rows[i]["ID"].ToString(),
						"' BillID='",
						dataTable2.Rows[i]["BillID"].ToString(),
						"' c2='",
						dataTable2.Rows[i]["_Name"].ToString(),
						"' ItemID='",
						dataTable2.Rows[i]["ItemID"].ToString(),
						"' Price='",
						dataTable2.Rows[i]["Price"].ToString(),
						"' Remark='",
						dataTable2.Rows[i]["Remark"].ToString(),
						"' Sequence='",
						i + 1,
						"' c6='2' />\n"
					}));
				}
			}
			stringBuilder.Append("     </rs:data> \n");
		}
		if (text2.ToLower() == "ysyf")
		{
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append(" \t<s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append(" \t<s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo'\r\n\t\t\t rs:basetable='Arrearage' rs:basecolumn='ID' rs:keycolumn='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Type' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:basetable='t' rs:basecolumn='Type'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Rec' rs:number='6' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Due' rs:number='7' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Balance' rs:number='8' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='CustomerNO' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:basetable='t' rs:basecolumn='CustomerNO'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c9' rs:name='_Name' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:basetable='t' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='LinkMan' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:basetable='t' rs:basecolumn='LinkMan'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Tel' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:basetable='t' rs:basecolumn='Tel'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='BeginStatus' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Arrearage' rs:basecolumn='BeginStatus'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Dept' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c14' rs:name='ID' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("     </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable = DALCommon.GetDataList("zk_arrearage", "", " [ID]=" + text3.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"     <z:row ID='1' Type='",
					dataTable.Rows[0]["Type"].ToString(),
					"' Rec='",
					dataTable.Rows[0]["Rec"].ToString(),
					"' Due='",
					dataTable.Rows[0]["Due"].ToString(),
					"' Balance='",
					dataTable.Rows[0]["Balance"].ToString(),
					"' CustomerNO='",
					dataTable.Rows[0]["CustomerNO"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"       c9='",
					dataTable.Rows[0]["_Name"].ToString(),
					"' LinkMan='",
					dataTable.Rows[0]["LinkMan"].ToString(),
					"' Tel='",
					dataTable.Rows[0]["Tel"].ToString(),
					"' BeginStatus='",
					dataTable.Rows[0]["BeginStatus"].ToString(),
					"' Dept='",
					dataTable.Rows[0]["Dept"].ToString(),
					"' c14='1'/>\n"
				}));
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t   <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo'\r\n\t\t\t rs:basetable='ArrearageDetail' rs:basecolumn='ID' rs:keycolumn='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='BillID' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ArrearageDetail' rs:basecolumn='BillID'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Type' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ArrearageDetail' rs:basecolumn='Type'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='RecType' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ArrearageDetail' rs:basecolumn='RecType'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='OperationID' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ArrearageDetail' rs:basecolumn='OperationID'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c5' rs:name='_Date' rs:number='6' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c6' rs:name='_Name' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Amount' rs:number='8' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='HaveAmount' rs:number='9' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='NotChargeAmount' rs:number='10' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Remark' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ArrearageDetail' rs:basecolumn='Remark'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Status' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ArrearageDetail' rs:basecolumn='Status'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='RemindDate' rs:number='13' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='DeptID' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='DeptID'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='InvoiceNO' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ArrearageDetail' rs:basecolumn='InvoiceNO'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='InvoiceMoney' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ArrearageDetail' rs:basecolumn='InvoiceMoney'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='currency' dt:maxLength='8' rs:precision='19' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='InvoiceDate' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ArrearageDetail' rs:basecolumn='InvoiceDate'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='timestamp' dt:maxLength='16' rs:scale='3' rs:precision='23' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='AccountName' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Account' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Sequence' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='Sequence'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c18' rs:name='ID' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c19' rs:name='ID' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Account' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>");
			stringBuilder.Append("\t <s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable4 = DALCommon.GetDataList("zk_arrearagedetail", "", " Type='应收款' and [BillID]=" + text3.ToString()).Tables[0];
			if (dataTable4.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable4.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"     <z:row ID='",
						dataTable4.Rows[i]["ID"].ToString(),
						"' BillID='",
						dataTable4.Rows[i]["BillID"].ToString(),
						"' Type='",
						dataTable4.Rows[i]["Type"].ToString(),
						"' RecType='",
						dataTable4.Rows[i]["RecType"].ToString(),
						"' OperationID='",
						dataTable4.Rows[i]["OperationID"].ToString(),
						"' c5='",
						dataTable4.Rows[i]["_Date"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"     c6='",
						dataTable4.Rows[i]["_Name"].ToString(),
						"' Amount='",
						dataTable4.Rows[i]["Amount"].ToString(),
						"' HaveAmount='",
						dataTable4.Rows[i]["HaveAmount"].ToString(),
						"' NotChargeAmount='",
						dataTable4.Rows[i]["NotChargeAmount"].ToString(),
						"' Remark='",
						dataTable4.Rows[i]["Remark"].ToString(),
						"' Status='",
						dataTable4.Rows[i]["Status"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new object[]
					{
						"     RemindDate='",
						dataTable4.Rows[i]["RemindDate"].ToString(),
						"' DeptID='1' c18='1' Sequence='",
						i + 1,
						"'/>\n"
					}));
				}
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t   <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo'\r\n\t\t\t rs:basetable='ArrearageDetail' rs:basecolumn='ID' rs:keycolumn='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='BillID' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ArrearageDetail' rs:basecolumn='BillID'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Type' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ArrearageDetail' rs:basecolumn='Type'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='RecType' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ArrearageDetail' rs:basecolumn='RecType'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='OperationID' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ArrearageDetail' rs:basecolumn='OperationID'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c5' rs:name='_Date' rs:number='6' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c6' rs:name='_Name' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Amount' rs:number='8' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='HaveAmount' rs:number='9' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='NotChargeAmount' rs:number='10' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Remark' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ArrearageDetail' rs:basecolumn='Remark'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Status' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ArrearageDetail' rs:basecolumn='Status'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='RemindDate' rs:number='13' rs:nullable='true'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='DeptID' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='DeptID'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='InvoiceNO' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ArrearageDetail' rs:basecolumn='InvoiceNO'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='InvoiceMoney' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ArrearageDetail' rs:basecolumn='InvoiceMoney'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='currency' dt:maxLength='8' rs:precision='19' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='InvoiceDate' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='ArrearageDetail' rs:basecolumn='InvoiceDate'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='timestamp' dt:maxLength='16' rs:scale='3' rs:precision='23' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='AccountName' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Account' rs:basecolumn='_Name'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='Sequence' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='Sequence'>\r\n\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c18' rs:name='ID' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>\r\n\t\t<s:AttributeType name='c19' rs:name='ID' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it'\r\n\t\t\t rs:baseschema='dbo' rs:basetable='Account' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'>\r\n\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/>\r\n\t\t</s:AttributeType>");
			stringBuilder.Append("\t <s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable5 = DALCommon.GetDataList("zk_arrearagedetail", "", " Type='应付款' and [BillID]=" + text3.ToString()).Tables[0];
			if (dataTable5.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable5.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"     <z:row ID='",
						dataTable5.Rows[i]["ID"].ToString(),
						"' BillID='",
						dataTable5.Rows[i]["BillID"].ToString(),
						"' Type='",
						dataTable5.Rows[i]["Type"].ToString(),
						"' RecType='",
						dataTable5.Rows[i]["RecType"].ToString(),
						"' OperationID='",
						dataTable5.Rows[i]["OperationID"].ToString(),
						"' c5='",
						dataTable5.Rows[i]["_Date"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"     c6='",
						dataTable5.Rows[i]["_Name"].ToString(),
						"' Amount='",
						dataTable5.Rows[i]["Amount"].ToString(),
						"' HaveAmount='",
						dataTable5.Rows[i]["HaveAmount"].ToString(),
						"' NotChargeAmount='",
						dataTable5.Rows[i]["NotChargeAmount"].ToString(),
						"' Remark='",
						dataTable5.Rows[i]["Remark"].ToString(),
						"' Status='",
						dataTable5.Rows[i]["Status"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new object[]
					{
						"     RemindDate='",
						dataTable5.Rows[i]["RemindDate"].ToString(),
						"' DeptID='1' c18='1' Sequence='",
						i + 1,
						"'/>\n"
					}));
				}
			}
			stringBuilder.Append("     </rs:data> \n");
		}
		if (text2.ToLower() == "zld")
		{
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t<s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t rs:basetable='Lease' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='BillID' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='DeptID' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='DeptID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Dept' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Status' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='Status'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c5' rs:name='_Date' rs:number='6' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Type' rs:number='7'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='4' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='OperatorID' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='OperatorID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ContractNO' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='ContractNO'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='CustomerID' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='CustomerID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='CustomerName' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='CustomerName'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='LinkMan' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='LinkMan'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Tel' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='Tel'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Adr' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='Adr'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='200'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Accessory' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='Accessory'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Rent' rs:number='16' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ChkDate' rs:number='17' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ReleaseDate' rs:number='18' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Deposit' rs:number='19' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='StartDate' rs:number='20' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='EndDate' rs:number='21' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Remark' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='500'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='SellerID' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='SellerID'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Seller' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='OperatorNO' rs:number='25' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='JobNO'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ChkOperator' rs:number='26' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ReleaseOper' rs:number='27' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='Operator' rs:number='28' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='curStatus' rs:number='29'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='6' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ChargeStatus' rs:number='30' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='ChargeStatus'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ChargeCycle' rs:number='31' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='ChargeCycle'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ChargeDate' rs:number='32' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='ReadingDate' rs:number='33' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='CancelReason' rs:number='34' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='CancelReason'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c34' rs:name='ID' rs:number='35' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c35' rs:name='ID' rs:number='36' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c36' rs:name='ID' rs:number='37' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c37' rs:name='ID' rs:number='38' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:AttributeType name='c38' rs:name='ID' rs:number='39' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t</s:AttributeType> \n");
			stringBuilder.Append("\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable = DALCommon.GetDataList("zl_lease", "", " [ID]=" + text3.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"     <z:row ID='",
					dataTable.Rows[0]["ID"].ToString(),
					"' BillID='",
					dataTable.Rows[0]["BillID"].ToString(),
					"' DeptID='1' Dept='",
					dataTable.Rows[0]["Dept"].ToString(),
					"' Status='",
					dataTable.Rows[0]["Status"].ToString(),
					"' c5='",
					dataTable.Rows[0]["_Date"].ToString(),
					"' Type='",
					dataTable.Rows[0]["Type"].ToString(),
					"' SellerID='6' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"     OperatorID='1' ContractNO='",
					dataTable.Rows[0]["ContractNO"].ToString(),
					"' CustomerID='86' CustomerName='",
					dataTable.Rows[0]["CustomerName"].ToString(),
					"' LinkMan='",
					dataTable.Rows[0]["LinkMan"].ToString(),
					"' Tel='",
					dataTable.Rows[0]["Tel"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"     Adr='",
					dataTable.Rows[0]["Adr"].ToString(),
					"' Accessory='' Rent='",
					dataTable.Rows[0]["Rent"].ToString(),
					"' ChkDate='",
					dataTable.Rows[0]["ChkDate"].ToString(),
					"' ReleaseDate='",
					dataTable.Rows[0]["ReleaseDate"].ToString(),
					"'  Deposit='",
					dataTable.Rows[0]["Deposit"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      StartDate='",
					dataTable.Rows[0]["StartDate"].ToString(),
					"' EndDate='",
					dataTable.Rows[0]["EndDate"].ToString(),
					"' Remark='",
					dataTable.Rows[0]["Remark"].ToString(),
					"' Seller='",
					dataTable.Rows[0]["Seller"].ToString(),
					"' OperatorNO='",
					dataTable.Rows[0]["OperatorNO"].ToString(),
					"' ChkOperator='",
					dataTable.Rows[0]["ChkOperator"].ToString(),
					"' ReleaseOper='",
					dataTable.Rows[0]["ReleaseOper"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      Operator='",
					dataTable.Rows[0]["Operator"].ToString(),
					"' curStatus='",
					dataTable.Rows[0]["curStatus"].ToString(),
					"' ChargeStatus='0' ChargeCycle='",
					dataTable.Rows[0]["ChargeCycle"].ToString(),
					"' ChargeDate='",
					dataTable.Rows[0]["ChargeDate"].ToString(),
					"' ReadingDate='",
					dataTable.Rows[0]["ReadingDate"].ToString(),
					"' CancelReason='",
					dataTable.Rows[0]["CancelReason"].ToString(),
					"' c30='1' \n"
				}));
				stringBuilder.Append("     c31='6' c32='1'/> \n");
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("<s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t rs:basetable='LeaseDevice' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='BillID' rs:number='2' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t rs:basetable='LeaseDevice' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='StockID' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='StockID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='GoodsID' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='GoodsID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='DeviceID' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='DeviceID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='BrandID' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='BrandID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='ClassID' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='ClassID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='ModelID' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='ModelID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='DeviceNO' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='DeviceNO'> \n");
			stringBuilder.Append("<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='ProductSN1' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='ProductSN1'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='ProductSN2' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='ProductSN2'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='StrQty' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='StrQty'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='4000'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='OutPrice' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='OutPrice'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:scale='2' rs:precision='18' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='InPrice' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='InPrice'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:scale='2' rs:precision='18' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Remark' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='300'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='OutDate' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='OutDate'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:scale='3' rs:precision='23' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='InDate' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='InDate'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:scale='3' rs:precision='23' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='StockName' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='GoodsNO' rs:number='19' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='151'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Brand' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Class' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='ProductClass' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Model' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='ProductModel' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='DeptID' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='DeptID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Status' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='Status'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c24' rs:name='_Date' rs:number='25' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Type' rs:number='26'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='4' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='ContractNO' rs:number='27' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='ContractNO'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='CustomerID' rs:number='28' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='CustomerID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='CustomerName' rs:number='29' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='CustomerName'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='LinkMan' rs:number='30' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='LinkMan'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Tel' rs:number='31' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='Tel'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Adr' rs:number='32' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='Adr'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='200'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Accessory' rs:number='33' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='Accessory'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Rent' rs:number='34' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Deposit' rs:number='35' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='StartDate' rs:number='36' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='EndDate' rs:number='37' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='LRemark' rs:number='38' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='500'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Seller' rs:number='39' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Operator' rs:number='40' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='curStatus' rs:number='41'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='6' rs:maybenull='false'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='ChargeStatus' rs:number='42' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='ChargeStatus'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='ChargeCycle' rs:number='43' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='ChargeCycle'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='strBillID' rs:number='44' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='ChargeDate' rs:number='45' rs:nullable='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='Dept' rs:number='46' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='DevStatus' rs:number='47' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='Status'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='iCount' rs:number='48' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='iCount'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='LeasePrice' rs:number='49' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='LeasePrice'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c47' rs:name='ID' rs:number='50' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append(" rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c48' rs:name='ID' rs:number='51' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c49' rs:name='ID' rs:number='52' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c50' rs:name='ID' rs:number='53' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='ProductClass' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c51' rs:name='ID' rs:number='54' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='ProductModel' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c52' rs:name='ID' rs:number='55' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c53' rs:name='ID' rs:number='56' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c54' rs:name='ID' rs:number='57' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c55' rs:name='ID' rs:number='58' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c56' rs:name='ID' rs:number='59' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:AttributeType name='c57' rs:name='ID' rs:number='60' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("</s:AttributeType> \n");
			stringBuilder.Append("<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable2 = DALCommon.GetDataList("zl_leasedevice", "", " DevStatus='正常' and [BillID]=" + text3.ToString()).Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"     <z:row ID='3' BillID='3' StockID='1' GoodsID='2' DeviceID='421' BrandID='2' ClassID='5' ModelID='18' DeviceNO='",
						dataTable2.Rows[i]["DeviceNO"].ToString(),
						"' iCount='",
						dataTable2.Rows[i]["iCount"].ToString(),
						"' LeasePrice='",
						dataTable2.Rows[i]["LeasePrice"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"     ProductSN1='",
						dataTable2.Rows[i]["ProductSN1"].ToString(),
						"' ProductSN2='",
						dataTable2.Rows[i]["ProductSN2"].ToString(),
						"' StrQty='",
						dataTable2.Rows[i]["StrQty"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"     OutPrice='",
						dataTable2.Rows[i]["OutPrice"].ToString(),
						"' InPrice='",
						dataTable2.Rows[i]["InPrice"].ToString(),
						"' Remark='",
						dataTable2.Rows[i]["Remark"].ToString(),
						"' StockName='",
						dataTable2.Rows[i]["StockName"].ToString(),
						"' GoodsNO='",
						dataTable2.Rows[i]["GoodsNO"].ToString(),
						"' Brand='",
						dataTable2.Rows[i]["Brand"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"     Class='",
						dataTable2.Rows[i]["Class"].ToString(),
						"' Model='",
						dataTable2.Rows[i]["Model"].ToString(),
						"' DeptID='1' Status='2' c22='",
						dataTable2.Rows[i]["_Date"].ToString(),
						"' Type='",
						dataTable2.Rows[i]["Type"].ToString(),
						"' ContractNO='",
						dataTable2.Rows[i]["ContractNO"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"     CustomerID='86' CustomerName='",
						dataTable2.Rows[i]["CustomerName"].ToString(),
						"' LinkMan='",
						dataTable2.Rows[i]["LinkMan"].ToString(),
						"' Tel='",
						dataTable2.Rows[i]["Tel"].ToString(),
						"' Adr='",
						dataTable2.Rows[i]["Adr"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"     Accessory='' Rent='",
						dataTable2.Rows[i]["Rent"].ToString(),
						"' Deposit='",
						dataTable2.Rows[i]["Deposit"].ToString(),
						"' StartDate='",
						dataTable2.Rows[i]["StartDate"].ToString(),
						"' EndDate='",
						dataTable2.Rows[i]["EndDate"].ToString(),
						"' LRemark='",
						dataTable2.Rows[i]["LRemark"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"     Seller='",
						dataTable2.Rows[i]["Seller"].ToString(),
						"' Operator='",
						dataTable2.Rows[i]["Operator"].ToString(),
						"' curStatus='",
						dataTable2.Rows[i]["curStatus"].ToString(),
						"' ChargeStatus='0' ChargeCycle='",
						dataTable2.Rows[i]["ChargeCycle"].ToString(),
						"' strBillID='",
						dataTable2.Rows[i]["strBillID"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"     ChargeDate='",
						dataTable2.Rows[i]["ChargeDate"].ToString(),
						"' Dept='",
						dataTable2.Rows[i]["Dept"].ToString(),
						"' DevStatus='",
						dataTable2.Rows[i]["DevStatus"].ToString(),
						"' c44='1' c45='2' c46='2' c47='5' c48='18' c49='3' c50='1' c51='6' c52='1'/> \n"
					}));
				}
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t\t    <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='LeaseChargeDetail' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BillID' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DeviceID' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='DeviceID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='QtyTypeID' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='QtyTypeID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BenQty' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='BenQty'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ShangQty' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='ShangQty'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='LossQty' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='LossQty'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ZhangQty' rs:number='8' rs:nullable='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='LeaseChargeDetail' rs:basecolumn='ZhangQty'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Rated' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='Rated'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SuperZhangFee' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='SupperZhangFee'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Brand' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Class' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductClass' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Model' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductModel' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='QtyTypeName' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='QtyType' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Rent' rs:number='31' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseCharge' rs:basecolumn='Rent'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DeviceNO' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='DeviceNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ProductSN1' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='ProductSN1'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='UseCount' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='UseCount'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c18' rs:name='ID' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseDetail' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c19' rs:name='ID' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c20' rs:name='ID' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='QtyType' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c21' rs:name='ID' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c22' rs:name='ID' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c23' rs:name='ID' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c24' rs:name='ID' rs:number='25' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductClass' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c25' rs:name='ID' rs:number='26' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductModel' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c26' rs:name='ID' rs:number='27' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c27' rs:name='ID' rs:number='28' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c28' rs:name='ID' rs:number='29' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c29' rs:name='ID' rs:number='30' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			string tblName = string.Format("(select a.*,b.Qty as ShangQty,b._Name as QtyTypeName,b.useCount,b.DeviceNO,b.ProductSN1,b.Brand,b.Class,b.Model,b.Rated,b.SuperZhangFee from zl_lease as a left join (select * from zl_meterreading where id in(select max(ID) from zl_meterreading group by iBillID,QtyType))as b on a.ID =b.BillID  left join (select * from zl_leasedevice where DevStatus='正常' ) as c on a.BillID=c.strBillID  where a.id in ({0})) as d", text3.ToString());
			string strCondition2 = string.Format(" d.DeviceNO in (select DeviceNO from zl_leasedevice where billid = {0} and DevStatus='正常') group by d.deviceNO,d.[ID],d.BillID,d.DeptID,d.Dept,Status,_Date,Type,OperatorID,CustomerID,CustomerName,LinkMan,Tel,Adr,Accessory,Rent,ChkDate,ReleaseDate,Deposit,StartDate,EndDate,Remark,SellerID,Seller,OperatorNO,ChkOperator,ReleaseOper,Operator,curStatus,ChargeStatus,ChargeCycle,ChargeDate,ReadingDate,CancelReason,ShangQty,QtyTypeName,ProductSN1,Brand,Class,Model,Rated,SuperZhangFee,ContractNO,useCount", text3.ToString());
			DataTable dataTable6 = DALCommon.GetDataList(tblName, "* ", strCondition2).Tables[0];
			string text11 = "";
			if (dataTable6.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable6.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"      <z:row ID='1' BillID='2' DeviceID='3' QtyTypeID='3' ShangQty='",
						dataTable6.Rows[i]["ShangQty"].ToString(),
						"' Rated='",
						dataTable6.Rows[i]["Rated"].ToString(),
						"' Rent='",
						dataTable6.Rows[i]["Rent"].ToString(),
						"' UseCount='",
						dataTable6.Rows[i]["useCount"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"      SuperZhangFee='",
						dataTable6.Rows[i]["SuperZhangFee"].ToString(),
						"' Brand='",
						dataTable6.Rows[i]["Brand"].ToString(),
						"' Class='",
						dataTable6.Rows[i]["Class"].ToString(),
						"' Model='",
						dataTable6.Rows[i]["Model"].ToString(),
						"' QtyTypeName='",
						dataTable6.Rows[i]["QtyTypeName"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"     DeviceNO='",
						dataTable6.Rows[i]["DeviceNO"].ToString(),
						"' ProductSN1='",
						dataTable6.Rows[i]["ProductSN1"].ToString(),
						"' c18='3' c19='3' c20='2' c21='1' c22='2' \n"
					}));
					stringBuilder.Append("      c23='2' c24='5' c25='18' c26='3' c27='1' c28='6' c29='1'/> \n");
					text11 += ",";
				}
			}
			else
			{
				stringBuilder.Append("      <z:row ID='1' BillID='2' DeviceID='3' QtyTypeID='3' BenQty='0' ShangQty='0' LossQty='0' ZhangQty='0' Rated='0' \n");
				stringBuilder.Append("      SupperZhangFee='' ZSupperZhangFee='' Brand='' Class='' Model='' QtyTypeName=''  \n");
				stringBuilder.Append("      DeviceNO='' ProductSN1='' c18='3' c19='3' c20='2' c21='1' c22='2' \n");
				stringBuilder.Append("      c23='2' c24='5' c25='18' c26='3' c27='1' c28='6' c29='1'/>  \n");
			}
			text11 = text11.Trim(new char[]
			{
				','
			});
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t\t    <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='LeaseChargeDetail' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BillID' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DeviceID' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='DeviceID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='QtyTypeID' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='QtyTypeID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BenQty' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='BenQty'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ShangQty' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='ShangQty'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='LossQty' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='LossQty'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ZhangQty' rs:number='8' rs:nullable='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='LeaseChargeDetail' rs:basecolumn='ZhangQty'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Rated' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='Rated'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SuperZhangFee' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='SupperZhangFee'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Brand' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Class' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductClass' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Model' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductModel' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='QtyTypeName' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='QtyType' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Rent' rs:number='31' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseCharge' rs:basecolumn='Rent'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DeviceNO' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='DeviceNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ProductSN1' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='ProductSN1'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c18' rs:name='ID' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseDetail' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c19' rs:name='ID' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c20' rs:name='ID' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='QtyType' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c21' rs:name='ID' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c22' rs:name='ID' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c23' rs:name='ID' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c24' rs:name='ID' rs:number='25' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductClass' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c25' rs:name='ID' rs:number='26' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductModel' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c26' rs:name='ID' rs:number='27' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c27' rs:name='ID' rs:number='28' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c28' rs:name='ID' rs:number='29' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c29' rs:name='ID' rs:number='30' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' dt:maxLength='50' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			string tblName2 = string.Format("(select a.*,b.Qty as ShangQty,b._Name as QtyTypeName,b.DeviceNO,b.ProductSN1,b.Brand,b.Class,b.Model,b.Rated,b.SuperZhangFee from zl_lease as a left join (select * from zl_meterreading where id in(select max(ID) from zl_meterreading group by iBillID))as b on a.ID =b.BillID  left join (select * from zl_leasedevice where DevStatus='正常' ) as c on a.BillID=c.strBillID  where a.id in ({0})) as d", text3.ToString());
			string strCondition3 = string.Format(" d.DeviceNO in (select DeviceNO from zl_leasedevice where billid = {0} and DevStatus='正常') group by d.deviceNO,d.[ID],d.BillID,d.DeptID,d.Dept,Status,_Date,Type,OperatorID,CustomerID,CustomerName,LinkMan,Tel,Adr,Accessory,Rent,ChkDate,ReleaseDate,Deposit,StartDate,EndDate,Remark,SellerID,Seller,OperatorNO,ChkOperator,ReleaseOper,Operator,curStatus,ChargeStatus,ChargeCycle,ChargeDate,ReadingDate,CancelReason,ShangQty,QtyTypeName,ProductSN1,Brand,Class,Model,Rated,SuperZhangFee,ContractNO", text3.ToString());
			DataTable dataTable7 = DALCommon.GetDataList(tblName2, "* ", strCondition3).Tables[0];
			string text12 = "";
			if (dataTable7.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable7.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"      <z:row ID='1' BillID='2' DeviceID='3' QtyTypeID='3' ShangQty='",
						dataTable7.Rows[i]["ShangQty"].ToString(),
						"' Rated='",
						dataTable7.Rows[i]["Rated"].ToString(),
						"' Rent='",
						dataTable7.Rows[i]["Rent"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"      SuperZhangFee='",
						dataTable7.Rows[i]["SuperZhangFee"].ToString(),
						"' Brand='",
						dataTable7.Rows[i]["Brand"].ToString(),
						"' Class='",
						dataTable7.Rows[i]["Class"].ToString(),
						"' Model='",
						dataTable7.Rows[i]["Model"].ToString(),
						"' QtyTypeName='",
						dataTable7.Rows[i]["QtyTypeName"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"     DeviceNO='",
						dataTable7.Rows[i]["DeviceNO"].ToString(),
						"' ProductSN1='",
						dataTable6.Rows[i]["ProductSN1"].ToString(),
						"' c18='3' c19='3' c20='2' c21='1' c22='2' \n"
					}));
					stringBuilder.Append("      c23='2' c24='5' c25='18' c26='3' c27='1' c28='6' c29='1'/> \n");
					text12 += ",";
				}
			}
			else
			{
				stringBuilder.Append("      <z:row ID='1' BillID='2' DeviceID='3' QtyTypeID='3' BenQty='0' ShangQty='0' LossQty='0' ZhangQty='0' Rated='0' \n");
				stringBuilder.Append("      SupperZhangFee='' ZSupperZhangFee='' Brand='' Class='' Model='' QtyTypeName=''  \n");
				stringBuilder.Append("      DeviceNO='' ProductSN1='' c18='3' c19='3' c20='2' c21='1' c22='2' \n");
				stringBuilder.Append("      c23='2' c24='5' c25='18' c26='3' c27='1' c28='6' c29='1'/>  \n");
			}
			text11 = text12.Trim(new char[]
			{
				','
			});
			stringBuilder.Append("     </rs:data> \n");
		}
		if (text2.ToLower() == "zljsd")
		{
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t\t   <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='LeaseCharge' rs:basecolumn='ID' rs:keycolumn= 'true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='OperationID' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseCharge' rs:basecolumn='OperationID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BillID' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseCharge' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c3' rs:name='_Date' rs:number='4' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='OperatorID' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='OperatorID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='StartDate' rs:number='6' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='EndDate' rs:number='7' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Cycle' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseCharge' rs:basecolumn='Cycle'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SuperZhangFee' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseCharge' rs:basecolumn='SuperZhangFee'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='dRec' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseCharge' rs:basecolumn='dRec'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Status' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseCharge' rs:basecolumn='Status'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Operator' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Type' rs:number='13'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='4' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ContractNO' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='ContractNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CustomerID' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='CustomerID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CustomerName' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='CustomerName'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='LinkMan' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='LinkMan'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Tel' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='Tel'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Adr' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='Adr'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='200'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Accessory' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='Accessory'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='StockID' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='StockID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='GoodsID' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='GoodsID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DeviceID' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='DeviceID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BrandID' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='BrandID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ClassID' rs:number='25' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='ClassID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ModelID' rs:number='26' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='ModelID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ProductSN1' rs:number='27' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='ProductSN1'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ProductSN2' rs:number='28' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='ProductSN2'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Rent' rs:number='29' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseCharge' rs:basecolumn='Rent'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='StockName' rs:number='30' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='GoodsNO' rs:number='31' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='151'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Brand' rs:number='32' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Class' rs:number='33' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductClass' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Model' rs:number='34' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductModel' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Deposit' rs:number='35' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Seller' rs:number='36' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SellerNO' rs:number='37' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='JobNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='LRemark' rs:number='38' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='500'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Loss' rs:number='39' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseCharge' rs:basecolumn='Loss'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='OperatorNO' rs:number='40' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='JobNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='InCash' rs:number='41' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseCharge' rs:basecolumn='InCash'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='strStatus' rs:number='42'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='6' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DeviceNO' rs:number='43' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='DeviceNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Remark' rs:number='44' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseCharge' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='500'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ShangQty' rs:number='45'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BenQty' rs:number='46'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='NotChargeAmount' rs:number='47' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='HaveAmount' rs:number='48' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Dept' rs:number='49' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DeptID' rs:number='50' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='DeptID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SellerID' rs:number='51' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='SellerID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CHdRec' rs:number='68' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseCharge' rs:basecolumn='CHdRec'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c51' rs:name='ID' rs:number='52' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c52' rs:name='ID' rs:number='53' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c53' rs:name='ID' rs:number='54' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c54' rs:name='ID' rs:number='55' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ArrearageDetail' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c55' rs:name='ID' rs:number='56' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c56' rs:name='ID' rs:number='57' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c57' rs:name='ID' rs:number='58' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c58' rs:name='ID' rs:number='59' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c59' rs:name='ID' rs:number='60' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c60' rs:name='ID' rs:number='61' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c61' rs:name='ID' rs:number='62' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductClass' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c62' rs:name='ID' rs:number='63' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductModel' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c63' rs:name='ID' rs:number='64' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c64' rs:name='ID' rs:number='65' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c65' rs:name='ID' rs:number='66' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c66' rs:name='ID' rs:number='67' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable = DALCommon.GetDataList("zl_leasecharge", "", " [ID]=" + text3.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"        <z:row ID='1' OperationID='",
					dataTable.Rows[0]["OperationID"].ToString(),
					"' BillID='3' c3='",
					dataTable.Rows[0]["_Date"].ToString(),
					"' OperatorID='1' StartDate='",
					dataTable.Rows[0]["StartDate"].ToString(),
					"' EndDate='",
					dataTable.Rows[0]["EndDate"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"     Cycle='",
					dataTable.Rows[0]["Cycle"].ToString(),
					"' SuperZhangFee='",
					dataTable.Rows[0]["SuperZhangFee"].ToString(),
					"' dRec='",
					dataTable.Rows[0]["dRec"].ToString(),
					"' CHdRec='",
					FunLibrary.NumChs(dataTable.Rows[0]["dRec"].ToString(), 2),
					"' Status='3' Operator='",
					dataTable.Rows[0]["Operator"].ToString(),
					"' Type='",
					dataTable.Rows[0]["Type"].ToString(),
					"' ContractNO='",
					dataTable.Rows[0]["ContractNO"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      CustomerID='86' CustomerName='",
					dataTable.Rows[0]["CustomerName"].ToString(),
					"' LinkMan='",
					dataTable.Rows[0]["LinkMan"].ToString(),
					"' Tel='",
					dataTable.Rows[0]["Tel"].ToString(),
					"' Adr='",
					dataTable.Rows[0]["Adr"].ToString(),
					"' \n"
				}));
				stringBuilder.Append("      Accessory='' StockID='1' GoodsID='2' DeviceID='421' BrandID='2' ClassID='5' ModelID='18' ProductSN1='" + dataTable.Rows[0]["ProductSN1"].ToString() + "' \n");
				stringBuilder.Append(string.Concat(new string[]
				{
					"      ProductSN2='",
					dataTable.Rows[0]["ProductSN2"].ToString(),
					"' Rent='",
					dataTable.Rows[0]["Rent"].ToString(),
					"' StockName='",
					dataTable.Rows[0]["StockName"].ToString(),
					"' GoodsNO='",
					dataTable.Rows[0]["GoodsNO"].ToString(),
					"' Brand='",
					dataTable.Rows[0]["Brand"].ToString(),
					"' Class='",
					dataTable.Rows[0]["Class"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      Model='",
					dataTable.Rows[0]["Model"].ToString(),
					"' Deposit='",
					dataTable.Rows[0]["Deposit"].ToString(),
					"' Seller='",
					dataTable.Rows[0]["Seller"].ToString(),
					"' LRemark='",
					dataTable.Rows[0]["LRemark"].ToString(),
					"' Loss='",
					dataTable.Rows[0]["Loss"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      OperatorNO='",
					dataTable.Rows[0]["OperatorNO"].ToString(),
					"' InCash='",
					dataTable.Rows[0]["InCash"].ToString(),
					"' strStatus='",
					dataTable.Rows[0]["strStatus"].ToString(),
					"' DeviceNO='",
					dataTable.Rows[0]["DeviceNO"].ToString(),
					"' Remark='",
					dataTable.Rows[0]["Remark"].ToString(),
					"' ShangQty='",
					dataTable.Rows[0]["ShangQty"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      BenQty='",
					dataTable.Rows[0]["BenQty"].ToString(),
					"' Dept='",
					dataTable.Rows[0]["Dept"].ToString(),
					"' DeptID='1' SellerID='6' c51='1' c52='3' c53='3' c55='1' c56='6' c57='1' c58='1' c59='2' \n"
				}));
				stringBuilder.Append("      c60='2' c61='5' c62='18' c63='3' c64='1' c65='6' c66='1'/> \n");
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t\t    <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='LeaseChargeDetail' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BillID' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DeviceID' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='DeviceID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='QtyTypeID' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='QtyTypeID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BenQty' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='BenQty'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ShangQty' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='ShangQty'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='LossQty' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='LossQty'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ZhangQty' rs:number='8' rs:nullable='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='LeaseChargeDetail' rs:basecolumn='ZhangQty'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Rated' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='Rated'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SupperZhangFee' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='SupperZhangFee'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ZSupperZhangFee' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='ZSupperZhangFee'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Brand' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Class' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductClass' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Model' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductModel' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='QtyTypeName' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='QtyType' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DeviceNO' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='DeviceNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ProductSN1' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='ProductSN1'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ChargeStyle' rs:number='18'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='GoodsNO' rs:number='31' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='zl_leasedetail' rs:basecolumn='GoodsNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Cost' rs:number='31' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='ZSupperZhangFee'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Remark' rs:number='31' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c18' rs:name='ID' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseDetail' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c19' rs:name='ID' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='LeaseDevice' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c20' rs:name='ID' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='QtyType' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c21' rs:name='ID' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c22' rs:name='ID' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c23' rs:name='ID' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c24' rs:name='ID' rs:number='25' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductClass' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c25' rs:name='ID' rs:number='26' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ProductModel' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c26' rs:name='ID' rs:number='27' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='Lease' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c27' rs:name='ID' rs:number='28' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c28' rs:name='ID' rs:number='29' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c29' rs:name='ID' rs:number='30' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable2 = DALCommon.GetDataList("zl_leasechargedetail", "", " [BillID]=" + text3.ToString()).Tables[0];
			string text13 = "";
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"      <z:row ID='1' BillID='2' DeviceID='3' QtyTypeID='3' BenQty='",
						dataTable2.Rows[i]["BenQty"].ToString(),
						"' ShangQty='",
						dataTable2.Rows[i]["ShangQty"].ToString(),
						"' LossQty='",
						dataTable2.Rows[i]["LossQty"].ToString(),
						"' ZhangQty='",
						dataTable2.Rows[i]["ZhangQty"].ToString(),
						"' Rated='",
						dataTable2.Rows[i]["Rated"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"      SupperZhangFee='",
						dataTable2.Rows[i]["SupperZhangFee"].ToString(),
						"' ZSupperZhangFee='",
						dataTable2.Rows[i]["ZSupperZhangFee"].ToString(),
						"' Brand='",
						dataTable2.Rows[i]["Brand"].ToString(),
						"' Class='",
						dataTable2.Rows[i]["Class"].ToString(),
						"' Model='",
						dataTable2.Rows[i]["Model"].ToString(),
						"' QtyTypeName='",
						dataTable2.Rows[i]["QtyTypeName"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"     GoodsNO='",
						dataTable2.Rows[i]["GoodsNO"].ToString(),
						"' DeviceNO='",
						dataTable2.Rows[i]["DeviceNO"].ToString(),
						"' ProductSN1='",
						dataTable2.Rows[i]["ProductSN1"].ToString(),
						"' ChargeStyle='",
						dataTable2.Rows[i]["ChargeStyle"].ToString(),
						"' Cost='",
						dataTable2.Rows[i]["Cost"].ToString(),
						"' Remark='",
						dataTable2.Rows[i]["Remark"].ToString(),
						"' c18='3' c19='3' c20='2' c21='1' c22='2' \n"
					}));
					stringBuilder.Append("      c23='2' c24='5' c25='18' c26='3' c27='1' c28='6' c29='1'/> \n");
					text13 = text13 + "," + dataTable2.Rows[i]["QtyTypeID"].ToString().Trim();
				}
			}
			else
			{
				stringBuilder.Append("      <z:row ID='1' BillID='2' DeviceID='3' QtyTypeID='3' BenQty='0' ShangQty='0' LossQty='0' ZhangQty='0' Rated='0' \n");
				stringBuilder.Append("      SupperZhangFee='' ZSupperZhangFee='' Brand='' Class='' Model='' QtyTypeName=''  \n");
				stringBuilder.Append("      GoodsNO='' DeviceNO='' ProductSN1='' ChargeStyle='' c18='3' c19='3' c20='2' c21='1' c22='2' \n");
				stringBuilder.Append("      c23='2' c24='5' c25='18' c26='3' c27='1' c28='6' c29='1'/>  \n");
			}
			text13 = text13.Trim(new char[]
			{
				','
			});
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("<s:Schema id='RowsetSchema'>\r\n\t\t<s:ElementType name='row' content='eltOnly' rs:updatable='true'>\r\n\t\t\t<s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='ID' rs:keycolumn='true'>\r\n\t\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/>\r\n\t\t\t</s:AttributeType>\r\n\t\t\t<s:AttributeType name='Index' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='ID' rs:keycolumn='true'>\r\n\t\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/>\r\n\t\t\t</s:AttributeType>\r\n\t\t\t<s:AttributeType name='StartCount' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='ID' rs:keycolumn='true'>\r\n\t\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/>\r\n\t\t\t</s:AttributeType>\r\n\t\t\t<s:AttributeType name='EndCount' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='ID' rs:keycolumn='true'>\r\n\t\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/>\r\n\t\t\t</s:AttributeType>\r\n\t\t\t<s:AttributeType name='Price' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='SupperZhangFee'>\r\n\t\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t\t</s:AttributeType>\r\n\t\t\t<s:AttributeType name='Total' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='SupperZhangFee'>\r\n\t\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t\t</s:AttributeType>\r\n\t\t\t<s:AttributeType name='LeftCount' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' rs:basetable='LeaseChargeDetail' rs:basecolumn='ID' rs:keycolumn='true'>\r\n\t\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/>\r\n\t\t\t</s:AttributeType>\r\n\t\t\t<s:AttributeType name='sType' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' rs:basetable='QtyType' rs:basecolumn='_Name'>\r\n\t\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/>\r\n\t\t\t</s:AttributeType>\r\n\t\t\t<s:extends type='rs:rowbase'/>\r\n\t\t</s:ElementType>\r\n\t</s:Schema>\r\n\t<rs:data>\r\n");
			DataTable dataTable8 = new DataTable();
			dataTable8.Columns.Add("ID", Type.GetType("System.Int32"));
			dataTable8.Columns.Add("Index", Type.GetType("System.Int32"));
			dataTable8.Columns.Add("StartCount", Type.GetType("System.Int32"));
			dataTable8.Columns.Add("EndCount", Type.GetType("System.Int32"));
			dataTable8.Columns.Add("Price", Type.GetType("System.Decimal"));
			dataTable8.Columns.Add("Total", Type.GetType("System.Decimal"));
			dataTable8.Columns.Add("LeftCount", Type.GetType("System.Int32"));
			dataTable8.Columns.Add("sType", Type.GetType("System.String"));
			if (!text13.Equals(""))
			{
				DataTable dataTable9 = DALCommon.GetList("leasedetail a left join QtyType b on a.QtyType=b.ID", "a.*,b._Name as TypeName", string.Format(" a.[ID] in({0}) ", text13)).Tables[0];
				int num3 = 1;
				for (int i = 0; i < dataTable9.Rows.Count; i++)
				{
					if (dataTable9.Rows[i]["ChargeStyle"].ToString().Trim().Equals("2"))
					{
						int j = 0;
						int num4 = 0;
						int num5 = 0;
						int num6 = 0;
						decimal num7 = 0m;
						int num8 = 0;
						DataRow[] array = dataTable2.Select("QtyTypeID=" + dataTable9.Rows[i]["ID"].ToString());
						int.TryParse(array[0]["ZhangQty"].ToString(), out j);
						int.TryParse(array[0]["Rated"].ToString(), out num4);
						int.TryParse(array[0]["LossQty"].ToString(), out num5);
						int.TryParse(array[0]["shangqty"].ToString(), out num6);
						decimal.TryParse(dataTable9.Rows[i]["superzhangfee"].ToString(), out num7);
						string text14 = dataTable9.Rows[i]["Formula"].ToString().Trim();
						List<Headquarters_Print_interface_data.FormulaInterval> list = new List<Headquarters_Print_interface_data.FormulaInterval>();
						string[] array2 = text14.Split(new char[]
						{
							'$'
						});
						for (int k = 0; k < array2.Length; k++)
						{
							Headquarters_Print_interface_data.FormulaInterval item = default(Headquarters_Print_interface_data.FormulaInterval);
							string[] array3 = array2[k].Split(new char[]
							{
								'|'
							});
							item.price = decimal.Parse(array3[0]);
							item.start = int.Parse(array3[1]);
							item.end = int.Parse(array3[2]);
							list.Add(item);
						}
						int num9 = 1;
						bool flag = true;
						while (j > 0)
						{
							DataRow dataRow = dataTable8.NewRow();
							dataRow["ID"] = num3;
							dataRow["Index"] = num9;
							if (num9 == 1 && num4 > 0)
							{
								dataRow["StartCount"] = num6 + num5;
								dataRow["EndCount"] = ((num4 > j) ? j : num4) + num6 + num5;
								dataRow["Price"] = 0;
								dataRow["Total"] = 0;
								dataRow["LeftCount"] = ((num4 > j) ? 0 : (j - num4));
								dataRow["sType"] = dataTable9.Rows[i]["TypeName"].ToString().Trim() + "基本信息";
								if (num4 > j)
								{
									j = 0;
								}
								else
								{
									num8 = num4;
								}
							}
							else
							{
								if (flag)
								{
									flag = false;
									dataRow["sType"] = dataTable9.Rows[i]["TypeName"].ToString().Trim() + "超张费用";
								}
								int k;
								for (k = 0; k < list.Count; k++)
								{
									if (list[k].start > num8)
									{
										break;
									}
								}
								if (k < list.Count)
								{
									dataRow["StartCount"] = list[k].start + num6 + num5;
									dataRow["EndCount"] = ((list[k].end > j) ? j : list[k].end) + num6 + num5;
									dataRow["Price"] = list[k].price;
									dataRow["Total"] = list[k].price * (((list[k].end > j) ? j : list[k].end) - num8);
									dataRow["LeftCount"] = ((list[k].end > j) ? 0 : (j - list[k].end));
									if (list[k].end > j)
									{
										j = 0;
									}
									else
									{
										num8 = list[k].end;
									}
								}
								else
								{
									dataRow["StartCount"] = num8 + 1 + num6 + num5;
									dataRow["EndCount"] = j + num6 + num5;
									dataRow["Price"] = num7;
									dataRow["Total"] = num7 * (j - num8);
									dataRow["LeftCount"] = 0;
									j = 0;
								}
							}
							dataTable8.Rows.Add(dataRow);
							num9++;
							num3++;
						}
					}
				}
			}
			for (int i = 0; i < dataTable8.Rows.Count; i++)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"<z:row ID='",
					dataTable8.Rows[i]["ID"].ToString(),
					"' Index='",
					dataTable8.Rows[i]["Index"].ToString(),
					"' StartCount='",
					dataTable8.Rows[i]["StartCount"].ToString(),
					"' EndCount='",
					dataTable8.Rows[i]["EndCount"].ToString(),
					"' Price='",
					dataTable8.Rows[i]["Price"].ToString(),
					"' Total='",
					dataTable8.Rows[i]["Total"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					" LeftCount='",
					dataTable8.Rows[i]["LeftCount"].ToString(),
					"' sType='",
					dataTable8.Rows[i]["sType"].ToString(),
					"'/>\n"
				}));
			}
			stringBuilder.Append("</rs:data>\n");
		}
		if (text2.ToLower() == "ht")
		{
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t\t    <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t\t\t rs:basetable='MaintenanceContract' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c1' rs:name='_Date' rs:number='2' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='OperatorID' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='MaintenanceContract' rs:basecolumn='OperatorID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ContractNO' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='MaintenanceContract' rs:basecolumn='ContractNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='StartDate' rs:number='5' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='EndDate' rs:number='6' rs:nullable='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Summary' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='MaintenanceContract' rs:basecolumn='Summary'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='5000'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='dAmount' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='MaintenanceContract' rs:basecolumn='dAmount'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CustomerID' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='MaintenanceContract' rs:basecolumn='CustomerID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='LinkMan' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='MaintenanceContract' rs:basecolumn='LinkMan'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Tel' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='MaintenanceContract' rs:basecolumn='Tel'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Adr' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='MaintenanceContract' rs:basecolumn='Adr'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='200'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='DeptID' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='MaintenanceContract' rs:basecolumn='DeptID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CustomerNO' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='CustomerList' rs:basecolumn='CustomerNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='CustomerName' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='CustomerList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Accessory' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='MaintenanceContract' rs:basecolumn='Accessory'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Remark' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='MaintenanceContract' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='5000'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Operator' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Seller' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SellerID' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='MaintenanceContract' rs:basecolumn='SellerID'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='dInCash' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='MaintenanceContract' rs:basecolumn='dInCash'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='ContractType' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ContractType' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Status' rs:number='23'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='6' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c23' rs:name='ID' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='CustomerList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c24' rs:name='ID' rs:number='25' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c25' rs:name='ID' rs:number='26' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='c26' rs:name='ID' rs:number='27' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:baseschema='dbo' rs:basetable='ContractType' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable = DALCommon.GetDataList("ks_maintenancecontract", "", " [ID]=" + text3.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"      <z:row ID='1' c1='",
					dataTable.Rows[0]["_Date"].ToString(),
					"' OperatorID='1' ContractNO='",
					dataTable.Rows[0]["ContractNO"].ToString(),
					"' StartDate='",
					dataTable.Rows[0]["StartDate"].ToString(),
					"' EndDate='",
					dataTable.Rows[0]["EndDate"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      Summary='",
					dataTable.Rows[0]["Summary"].ToString(),
					"' dAmount='",
					dataTable.Rows[0]["dAmount"].ToString(),
					"' CustomerID='153' LinkMan='",
					dataTable.Rows[0]["LinkMan"].ToString(),
					"' Tel='",
					dataTable.Rows[0]["Tel"].ToString(),
					"' Adr='",
					dataTable.Rows[0]["Adr"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"     DeptID='1' CustomerNO='",
					dataTable.Rows[0]["CustomerNO"].ToString(),
					"' CustomerName='",
					dataTable.Rows[0]["CustomerName"].ToString(),
					"' Accessory='' Remark='",
					dataTable.Rows[0]["Remark"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"      Operator='",
					dataTable.Rows[0]["Operator"].ToString(),
					"' Seller='",
					dataTable.Rows[0]["Seller"].ToString(),
					"' SellerID='1' dInCash='",
					dataTable.Rows[0]["dInCash"].ToString(),
					"' ContractType='",
					dataTable.Rows[0]["ContractType"].ToString(),
					"' Status='",
					dataTable.Rows[0]["Status"].ToString(),
					"' \n"
				}));
				stringBuilder.Append("     c23='153' c24='1' c25='1' c26='1'/> \n");
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("          <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it' rs:baseschema='dbo' \n");
			stringBuilder.Append("     \t rs:basetable='ContractDetail' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='BillID' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='ContractDetail' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='DeviceID' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='ContractDetail' rs:basecolumn='DeviceID'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='bRepair' rs:number='4'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2' rs:maybenull='false'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='bConsumables' rs:number='5'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2' rs:maybenull='false'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='bMaterial' rs:number='6'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2' rs:maybenull='false'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='ServiceLevelID' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='ContractDetail' rs:basecolumn='ServiceLevelID'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='Remark' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='ContractDetail' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='300'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='ProductBrand' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='ProductClass' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='ProductClass' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='ProductModel' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='ProductModel' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='ProductSN1' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='DeviceList' rs:basecolumn='ProductSN1'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='ServiceLevel' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='ServiceLevel' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='c13' rs:name='ID' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='ServiceLevel' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='c14' rs:name='ID' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='DeviceList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='c15' rs:name='ID' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='CustomerList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='c16' rs:name='ID' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='ProductClass' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='c17' rs:name='ID' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     \t<s:AttributeType name='c18' rs:name='ID' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='ProductModel' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("     <s:AttributeType name='c19' rs:name='ID' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("     \t rs:baseschema='dbo' rs:basetable='Warranty' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("     \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("     </s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable2 = DALCommon.GetDataList("ks_contractdetail", "", " [BillID]=" + text3.ToString()).Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"          <z:row ID='1' BillID='1' DeviceID='206' bRepair='",
						dataTable2.Rows[i]["bRepair"].ToString(),
						"' bConsumables='",
						dataTable2.Rows[i]["bConsumables"].ToString(),
						"' bMaterial='",
						dataTable2.Rows[i]["bMaterial"].ToString(),
						"' Remark='",
						dataTable2.Rows[i]["Remark"].ToString(),
						"' ProductBrand='",
						dataTable2.Rows[i]["ProductBrand"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						"      ProductClass='",
						dataTable2.Rows[i]["ProductClass"].ToString(),
						"' ProductModel='",
						dataTable2.Rows[i]["ProductModel"].ToString(),
						"' ProductSN1='",
						dataTable2.Rows[i]["ProductSN1"].ToString(),
						"' ServiceLevel='",
						dataTable2.Rows[i]["ServiceLevel"].ToString(),
						"' c14='206' c15='153' \n"
					}));
					stringBuilder.Append("     c16='5' c17='7' c18='22' c19='5'/> \n");
				}
			}
			stringBuilder.Append("     </rs:data> \n");
		}
		if (text2.ToLower() == "nbdbd")
		{
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append(" \t<s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append(" <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it1230' rs:baseschema='dbo' \n");
			stringBuilder.Append(" \t rs:basetable='InnerAllocate' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='BillID' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='InnerAllocate' rs:basecolumn='BillID'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='c2' rs:name='_Date' rs:number='3' rs:nullable='true'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='ChkDate' rs:number='4' rs:nullable='true'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='PersonID' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='InnerAllocate' rs:basecolumn='PersonID'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='DeptID' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='InnerAllocate' rs:basecolumn='DeptID'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='Status' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='InnerAllocate' rs:basecolumn='Status'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='curStatus' rs:number='8'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='6' rs:maybenull='false'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='Remark' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='InnerAllocate' rs:basecolumn='Remark'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='300'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='Dept' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='Operator' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='ChkOperator' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='Person' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='StockOut' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='StockIn' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='StockOutID' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='InnerAllocate' rs:basecolumn='StockOutID'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='StockInID' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='InnerAllocate' rs:basecolumn='StockInID'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='OperatorID' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='InnerAllocate' rs:basecolumn='OperatorID'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='ChkOperatorID' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='InnerAllocate' rs:basecolumn='ChkOperatorID'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='c19' rs:name='ID' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='c20' rs:name='ID' rs:number='21' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='c21' rs:name='ID' rs:number='22' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='StaffList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='c22' rs:name='ID' rs:number='23' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='BranchList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='c23' rs:name='ID' rs:number='24' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:AttributeType name='c24' rs:name='ID' rs:number='25' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append(" \t rs:baseschema='dbo' rs:basetable='StockList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append(" \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append(" </s:AttributeType> \n");
			stringBuilder.Append(" <s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("     </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable = DALCommon.GetDataList("ck_innerallocate", "", " [ID]=" + text3.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"  <z:row ID='1' BillID='",
					dataTable.Rows[0]["BillID"].ToString(),
					"' c2='",
					dataTable.Rows[0]["_Date"].ToString(),
					"' ChkDate='",
					dataTable.Rows[0]["ChkDate"].ToString(),
					"'  PersonID='",
					dataTable.Rows[0]["PersonID"].ToString(),
					"' DeptID='1' Status='",
					dataTable.Rows[0]["Status"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"   curStatus='",
					dataTable.Rows[0]["curStatus"].ToString(),
					"' Remark='",
					dataTable.Rows[0]["Remark"].ToString(),
					"' Dept='",
					dataTable.Rows[0]["Dept"].ToString(),
					"' Operator='",
					dataTable.Rows[0]["Operator"].ToString(),
					"' ChkOperator='",
					dataTable.Rows[0]["ChkOperator"].ToString(),
					"' Person='",
					dataTable.Rows[0]["Person"].ToString(),
					"' \n"
				}));
				stringBuilder.Append(string.Concat(new string[]
				{
					"  StockOut='",
					dataTable.Rows[0]["StockOut"].ToString(),
					"' StockIn='",
					dataTable.Rows[0]["StockIn"].ToString(),
					"' StockOutID='",
					dataTable.Rows[0]["StockOutID"].ToString(),
					"' StockInID='",
					dataTable.Rows[0]["StockInID"].ToString(),
					"' OperatorID='",
					dataTable.Rows[0]["OperatorID"].ToString(),
					"' c19='1' \n"
				}));
				stringBuilder.Append("  c20='1' c21='1' c22='1' c23='1' c24='2'/> \n");
			}
			stringBuilder.Append("     </rs:data> \n");
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t    <s:AttributeType name='ID' rs:number='1' rs:writeunknown='true' rs:basecatalog='wt_it1230' rs:baseschema='dbo' \n");
			stringBuilder.Append("\t    \t rs:basetable='InnerAllocateDetail' rs:basecolumn='ID' rs:keycolumn='true'> \n");
			stringBuilder.Append("\t    \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true' rs:maybenull='false'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t    <s:AttributeType name='BillID' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append("\t    \t rs:baseschema='dbo' rs:basetable='InnerAllocateDetail' rs:basecolumn='BillID'> \n");
			stringBuilder.Append("\t    \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t    <s:AttributeType name='GoodsID' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append("\t    \t rs:baseschema='dbo' rs:basetable='InnerAllocateDetail' rs:basecolumn='GoodsID'> \n");
			stringBuilder.Append("\t    \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t    <s:AttributeType name='UnitID' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append("\t    \t rs:baseschema='dbo' rs:basetable='InnerAllocateDetail' rs:basecolumn='UnitID'> \n");
			stringBuilder.Append("\t    \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t    <s:AttributeType name='Qty' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append("\t    \t rs:baseschema='dbo' rs:basetable='InnerAllocateDetail' rs:basecolumn='Qty'> \n");
			stringBuilder.Append("\t    \t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t    <s:AttributeType name='Price' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append("\t    \t rs:baseschema='dbo' rs:basetable='InnerAllocateDetail' rs:basecolumn='Price'> \n");
			stringBuilder.Append("\t    \t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='18' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t    <s:AttributeType name='Total' rs:number='7' rs:nullable='true'> \n");
			stringBuilder.Append("\t    \t<s:datatype dt:type='number' rs:dbtype='numeric' dt:maxLength='19' rs:scale='2' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t    <s:AttributeType name='Remark' rs:number='8' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append("\t    \t rs:baseschema='dbo' rs:basetable='InnerAllocateDetail' rs:basecolumn='Remark'> \n");
			stringBuilder.Append("\t    \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t    <s:AttributeType name='GoodsNO' rs:number='9' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append("\t    \t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='GoodsNO'> \n");
			stringBuilder.Append("\t    \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t    <s:AttributeType name='c9' rs:name='_Name' rs:number='10' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append("\t    \t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t    \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t    <s:AttributeType name='Spec' rs:number='11' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append("\t    \t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='Spec'> \n");
			stringBuilder.Append("\t    \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='100'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t    <s:AttributeType name='ProductBrand' rs:number='12' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append("\t    \t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t    \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='50'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t    <s:AttributeType name='Unit' rs:number='13' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append("\t    \t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='_Name'> \n");
			stringBuilder.Append("\t    \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='20'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t    <s:AttributeType name='MainTenancePeriod' rs:number='14' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append("\t    \t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='MainTenancePeriod'> \n");
			stringBuilder.Append("\t    \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='10'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t    <s:AttributeType name='SN' rs:number='15' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append("\t    \t rs:baseschema='dbo' rs:basetable='InnerAllocateDetail' rs:basecolumn='SN'> \n");
			stringBuilder.Append("\t    \t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='8000'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t    <s:AttributeType name='c15' rs:name='ID' rs:number='16' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append("\t    \t rs:baseschema='dbo' rs:basetable='Goods' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t    \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t    <s:AttributeType name='c16' rs:name='ID' rs:number='17' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append("\t    \t rs:baseschema='dbo' rs:basetable='GoodsUnit' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t    \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t    <s:AttributeType name='c17' rs:name='ID' rs:number='18' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append("\t    \t rs:baseschema='dbo' rs:basetable='ProductBrand' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t    \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t    <s:AttributeType name='c18' rs:name='ID' rs:number='19' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it1230' \n");
			stringBuilder.Append("\t    \t rs:baseschema='dbo' rs:basetable='UnitList' rs:basecolumn='ID' rs:keycolumn='true' rs:hidden='true'> \n");
			stringBuilder.Append("\t    \t<s:datatype dt:type='int' dt:maxLength='4' rs:precision='10' rs:fixedlength='true'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t    <s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable2 = DALCommon.GetDataList("ck_innerallocatedetail", "", " [BillID]=" + text3.ToString()).Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"<z:row ID='1' BillID='",
						dataTable2.Rows[i]["BillID"].ToString(),
						"' GoodsID='",
						dataTable2.Rows[i]["GoodsID"].ToString(),
						"' UnitID='",
						dataTable2.Rows[i]["UnitID"].ToString(),
						"' Qty='",
						dataTable2.Rows[i]["Qty"].ToString(),
						"' Price='",
						dataTable2.Rows[i]["Price"].ToString(),
						"' Total='",
						dataTable2.Rows[i]["Total"].ToString(),
						"' Remark='",
						dataTable2.Rows[i]["Remark"].ToString(),
						"' GoodsNO='",
						dataTable2.Rows[i]["GoodsNO"].ToString(),
						"' \n"
					}));
					stringBuilder.Append(string.Concat(new string[]
					{
						" c9='",
						dataTable2.Rows[i]["_Name"].ToString(),
						"' Spec='",
						dataTable2.Rows[i]["Spec"].ToString(),
						"' ProductBrand='",
						dataTable2.Rows[i]["ProductBrand"].ToString(),
						"' Unit='",
						dataTable2.Rows[i]["Unit"].ToString(),
						"' MainTenancePeriod='",
						dataTable2.Rows[i]["MainTenancePeriod"].ToString(),
						"' SN='",
						dataTable2.Rows[i]["SN"].ToString(),
						"' c15='94' \n"
					}));
					stringBuilder.Append(" c16='94' c17='22' c18='1'/> \n");
				}
			}
			stringBuilder.Append("     </rs:data> \n");
		}
		if (text2.ToLower() == "cpsn")
		{
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='SN' rs:number='20' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='StockSN' rs:basecolumn='SN'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2147483647' rs:long='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			string[] array4 = text4.Split(new char[]
			{
				','
			});
			if (array4.Length > 0)
			{
				for (int i = 0; i < array4.Length; i++)
				{
					stringBuilder.Append("<z:row SN='" + array4[i].ToString() + "'/>  \n");
				}
			}
			stringBuilder.Append("     </rs:data> \n");
		}
		if (text2.ToLower() == "tm")
		{
			stringBuilder.Append("     <s:Schema id='RowsetSchema'> \n");
			stringBuilder.Append("\t    <s:ElementType name='row' content='eltOnly' rs:updatable='true'> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='BarCode' rs:number='1' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='Goods' rs:basecolumn='BarCode'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2147483647' rs:long='true'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='GoodsNO' rs:number='2' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='Goods' rs:basecolumn='GoodsNO'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2147483647' rs:long='true'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='GoodsName' rs:number='3' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='Goods' rs:basecolumn='GoodsName'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2147483647' rs:long='true'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='PriceCost' rs:number='4' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='Goods' rs:basecolumn='PriceCost'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2147483647' rs:long='true'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='PriceDetail' rs:number='5' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='Goods' rs:basecolumn='PriceDetail'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2147483647' rs:long='true'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Spec' rs:number='6' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='Goods' rs:basecolumn='Spec'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2147483647' rs:long='true'/> \n");
			stringBuilder.Append("\t    </s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:AttributeType name='Attr' rs:number='7' rs:nullable='true' rs:writeunknown='true' rs:basecatalog='wt_it' \n");
			stringBuilder.Append("\t\t\t rs:basetable='Goods' rs:basecolumn='Attr'> \n");
			stringBuilder.Append("\t\t\t<s:datatype dt:type='string' rs:dbtype='str' dt:maxLength='2147483647' rs:long='true'/> \n");
			stringBuilder.Append("\t\t</s:AttributeType> \n");
			stringBuilder.Append("\t\t<s:extends type='rs:rowbase'/> \n");
			stringBuilder.Append("\t    </s:ElementType> \n");
			stringBuilder.Append("     </s:Schema> \n");
			stringBuilder.Append("     <rs:data> \n");
			DataTable dataTable10 = DALCommon.GetDataList("v_GoodsBarCode", "", " [ID] in(" + text3.TrimEnd(new char[]
			{
				','
			}) + ")").Tables[0];
			if (dataTable10.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable10.Rows.Count; i++)
				{
					stringBuilder.Append(string.Concat(new string[]
					{
						"<z:row BarCode='",
						dataTable10.Rows[i]["BarCode"].ToString(),
						"' PriceDetail='",
						dataTable10.Rows[i]["PriceDetail"].ToString(),
						"' GoodsNO='",
						dataTable10.Rows[i]["GoodsNO"].ToString(),
						"' Spec='",
						dataTable10.Rows[i]["Spec"].ToString(),
						"' Attr='",
						dataTable10.Rows[i]["Attr"].ToString(),
						"' GoodsName='",
						dataTable10.Rows[i]["_Name"].ToString(),
						"' PriceCost='",
						dataTable10.Rows[i]["PriceCost"].ToString(),
						"'/> \n"
					}));
				}
			}
			stringBuilder.Append("     </rs:data> \n");
		}
		stringBuilder.Append(" </xml>");
		base.Response.Write(stringBuilder.ToString());
	}
}
