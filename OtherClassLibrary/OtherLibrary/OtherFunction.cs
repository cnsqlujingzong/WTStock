using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;

namespace wt.OtherLibrary
{
	public sealed class OtherFunction
	{
		public OtherFunction()
		{
		}

		public static void BindAllotReason(DropDownList ddlAllotReason)
		{
			ddlAllotReason.DataSource = DALCommon.GetDataList("AllotReason", "", " 1=1 order by Array asc");
			ddlAllotReason.DataTextField = "_Name";
			ddlAllotReason.DataValueField = "ID";
			ddlAllotReason.DataBind();
			ddlAllotReason.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindArea(DropDownList ddlArea)
		{
			int num = 0;
			ddlArea.DataSource = DALCommon.GetList_HL(0, "AreaList", "", 0, 0, "", " Array asc ", out num);
			ddlArea.DataTextField = "_Name";
			ddlArea.DataValueField = "ID";
			ddlArea.DataBind();
			ddlArea.Items.Insert(0, new ListItem("", "-1"));
			ddlArea.Items.Add(new ListItem("新建...", "0"));
		}

		public static void BindBranch(DropDownList ddlBranch)
		{
			int num = 0;
			ddlBranch.DataSource = DALCommon.GetList_HL(0, "BranchList", "[ID],_Name", 0, 0, " bStop=0 ", "Array", out num);
			ddlBranch.DataTextField = "_Name";
			ddlBranch.DataValueField = "ID";
			ddlBranch.DataBind();
		}

		public static void BindCancelReason(DropDownList ddlCancel)
		{
			int num = 0;
			ddlCancel.DataSource = DALCommon.GetList_HL(0, "CancelReason", "", 0, 0, "", "Array asc", out num);
			ddlCancel.DataTextField = "_Name";
			ddlCancel.DataValueField = "ID";
			ddlCancel.DataBind();
			ddlCancel.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindChargeAccount(DropDownList ddlChargeAccount, string strWhere)
		{
			string str = "[ID],[_Name]";
			DALSysParm dALSysParm = new DALSysParm();
			dALSysParm.bHeadCharge();
			if ((HttpContext.Current.Session["Session_wtBranch"] == null || HttpContext.Current.Session["Session_wtUserB"] == null || HttpContext.Current.Session["Session_wtUserBID"] == null || HttpContext.Current.Session["Session_wtPurB"] == null || HttpContext.Current.Session["Session_wtBranchID"] == null ? false : dALSysParm.bHeadCharge()))
			{
				str = "[ID],[_Name]+'(总部)' as _Name";
				strWhere = " DeptID=1 ";
			}
			int num = 0;
			ddlChargeAccount.DataSource = DALCommon.GetList_HL(0, "Account", str, 0, 0, strWhere, "ID", out num);
			ddlChargeAccount.DataTextField = "_Name";
			ddlChargeAccount.DataValueField = "ID";
			ddlChargeAccount.DataBind();
			ddlChargeAccount.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindChargeItem(DropDownList ddlChargeItem, string strWhere)
		{
			int num = 0;
			ddlChargeItem.DataSource = DALCommon.GetList_HL(0, "ChargeItem", "[ID],[_Name]", 0, 0, strWhere, "ID", out num);
			ddlChargeItem.DataTextField = "_Name";
			ddlChargeItem.DataValueField = "ID";
			ddlChargeItem.DataBind();
			ddlChargeItem.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindChargeStyle(DropDownList ddlChargeStyle, string strWhere)
		{
			int num = 0;
			ddlChargeStyle.DataSource = DALCommon.GetList_HL(0, "ChargeMode", "[ID],[_Name]", 0, 0, strWhere, " Array asc ", out num);
			ddlChargeStyle.DataTextField = "_Name";
			ddlChargeStyle.DataValueField = "ID";
			ddlChargeStyle.DataBind();
			ddlChargeStyle.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindCustomerStatus(DropDownList ddlCustomerStatus)
		{
			ddlCustomerStatus.DataSource = DALCommon.GetDataList("CustomerStatus", "", " 1=1 order by Array asc");
			ddlCustomerStatus.DataTextField = "_Name";
			ddlCustomerStatus.DataValueField = "ID";
			ddlCustomerStatus.DataBind();
			ddlCustomerStatus.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindDocClass(DropDownList ddlClass, string strWhere)
		{
			DataTable item = DALCommon.GetDataList("OA_DocClass", "", strWhere).Tables[0];
			ddlClass.DataSource = item;
			ddlClass.DataTextField = "_Name";
			ddlClass.DataValueField = "ID";
			ddlClass.DataBind();
			ddlClass.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindDrpClass(string parentid, DataTable dt, string blank, string travel, DropDownList controlID)
		{
			DataRow[] dataRowArray = dt.Select(string.Concat(" Father= '", parentid, "'"));
			DataRow[] dataRowArray1 = dataRowArray;
			for (int i = 0; i < (int)dataRowArray1.Length; i++)
			{
				DataRow dataRow = dataRowArray1[i];
				string str = dataRow["ID"].ToString();
				string str1 = dataRow["_Name"].ToString();
				str1 = string.Concat(blank, str1);
				string str2 = str;
				string str3 = string.Concat("│", HttpUtility.HtmlDecode("&nbsp;&nbsp;"), blank);
				controlID.Items.Add(new ListItem(str1, str2));
				OtherFunction.BindDrpClass(str, dt, str3, str2, controlID);
			}
		}

		public static void BindDrpClass(string parentid, DataTable dt, string blank, string travel, HtmlSelect controlID)
		{
			DataRow[] dataRowArray = dt.Select(string.Concat(" Father= '", parentid, "'"));
			DataRow[] dataRowArray1 = dataRowArray;
			for (int i = 0; i < (int)dataRowArray1.Length; i++)
			{
				DataRow dataRow = dataRowArray1[i];
				string str = dataRow["ID"].ToString();
				string str1 = dataRow["_Name"].ToString();
				str1 = string.Concat(blank, str1);
				string str2 = str;
				string str3 = string.Concat("│", HttpUtility.HtmlDecode("&nbsp;&nbsp;"), blank);
				controlID.Items.Add(new ListItem(str1, str2));
				OtherFunction.BindDrpClass(str, dt, str3, str2, controlID);
			}
		}

		public static void BindDrpLevelClass(string parentid, DataTable dt, string blank, string travel, HtmlSelect controlID)
		{
			DataRow[] dataRowArray = dt.Select(string.Concat(" Father= '", parentid, "'"));
			DataRow[] dataRowArray1 = dataRowArray;
			for (int i = 0; i < (int)dataRowArray1.Length; i++)
			{
				DataRow dataRow = dataRowArray1[i];
				string str = dataRow["_Level"].ToString();
				string str1 = dataRow["_Name"].ToString();
				string str2 = dataRow["ID"].ToString();
				str1 = string.Concat(blank, str1);
				string str3 = str;
				string str4 = string.Concat("│", HttpUtility.HtmlDecode("&nbsp;&nbsp;"), blank);
				controlID.Items.Add(new ListItem(str1, str3));
				OtherFunction.BindDrpLevelClass(str2, dt, str4, str3, controlID);
			}
		}

		public static void BindFrom(DropDownList ddlFrom)
		{
			int num = 0;
			ddlFrom.DataSource = DALCommon.GetList_HL(0, "CustomerFrom", "", 0, 0, "", " Array asc ", out num);
			ddlFrom.DataTextField = "_Name";
			ddlFrom.DataValueField = "ID";
			ddlFrom.DataBind();
			ddlFrom.Items.Insert(0, new ListItem("", "-1"));
			ddlFrom.Items.Add(new ListItem("新建...", "0"));
		}

		public static void BindGoodsGone(DropDownList ddlGoodsGone)
		{
			int num = 0;
			ddlGoodsGone.DataSource = DALCommon.GetList_HL(0, "GoodsGone", "", 0, 0, "", " Array asc ", out num);
			ddlGoodsGone.DataTextField = "_Name";
			ddlGoodsGone.DataValueField = "ID";
			ddlGoodsGone.DataBind();
			ddlGoodsGone.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindINReason(DropDownList ddlReason, string strWhere)
		{
			int num = 0;
			ddlReason.DataSource = DALCommon.GetList_HL(0, "INStockReason", "[ID],[_Name]", 0, 0, strWhere, " Array asc ", out num);
			ddlReason.DataTextField = "_Name";
			ddlReason.DataValueField = "ID";
			ddlReason.DataBind();
			ddlReason.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindInviceClass(DropDownList ddlInviceClass, string strWhere)
		{
			int num = 0;
			ddlInviceClass.DataSource = DALCommon.GetList_HL(0, "InvoiceClass", "[ID],[_Name]", 0, 0, strWhere, " Array asc ", out num);
			ddlInviceClass.DataTextField = "_Name";
			ddlInviceClass.DataValueField = "ID";
			ddlInviceClass.DataBind();
			ddlInviceClass.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindMember(DropDownList ddlMember)
		{
			ddlMember.DataSource = DALCommon.GetDataList("CustomerMembers", "", "");
			ddlMember.DataTextField = "_Name";
			ddlMember.DataValueField = "ID";
			ddlMember.DataBind();
			ddlMember.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindOutReason(DropDownList ddlReason, string strWhere)
		{
			int num = 0;
			ddlReason.DataSource = DALCommon.GetList_HL(0, "OUTStockReason", "[ID],[_Name]", 0, 0, strWhere, " Array asc ", out num);
			ddlReason.DataTextField = "_Name";
			ddlReason.DataValueField = "ID";
			ddlReason.DataBind();
			ddlReason.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindProductAspect(DropDownList ddlAspect)
		{
			int num = 0;
			ddlAspect.DataSource = DALCommon.GetList_HL(0, "ProductAspect", "", 0, 0, "", " Array asc ", out num);
			ddlAspect.DataTextField = "_Name";
			ddlAspect.DataValueField = "ID";
			ddlAspect.DataBind();
			ddlAspect.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindProductBrand(DropDownList ddlBrand)
		{
			int num = 0;
			ddlBrand.DataSource = DALCommon.GetList_HL(0, "ProductBrand", "", 0, 0, "", "_Name", out num);
			ddlBrand.DataTextField = "_Name";
			ddlBrand.DataValueField = "ID";
			ddlBrand.DataBind();
			ddlBrand.Items.Insert(0, new ListItem("", "-1"));
			ddlBrand.Items.Add(new ListItem("新建...", "0"));
		}

		public static void BindProductClass(DropDownList ddlClass)
		{
			int num = 0;
			ddlClass.DataSource = DALCommon.GetList_HL(0, "ProductClass", "", 0, 0, "", "_Name", out num);
			ddlClass.DataTextField = "_Name";
			ddlClass.DataValueField = "ID";
			ddlClass.DataBind();
			ddlClass.Items.Insert(0, new ListItem("", "-1"));
			ddlClass.Items.Add(new ListItem("新建...", "0"));
		}

		public static void BindProductModel(DropDownList ddlModel, string strWhere)
		{
			int num = 0;
			ddlModel.DataSource = DALCommon.GetList_HL(0, "ProductModel", "", 0, 0, strWhere, "_Name", out num);
			ddlModel.DataTextField = "_Name";
			ddlModel.DataValueField = "ID";
			ddlModel.DataBind();
			ddlModel.Items.Insert(0, new ListItem("", "-1"));
			ddlModel.Items.Add(new ListItem("新建...", "0"));
		}

		public static void BindQtyType(DropDownList ddlQtyType)
		{
			ddlQtyType.DataSource = DALCommon.GetDataList("QtyType", "", " 1=1 order by Array asc");
			ddlQtyType.DataTextField = "_Name";
			ddlQtyType.DataValueField = "ID";
			ddlQtyType.DataBind();
			ddlQtyType.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindQuarters(DropDownList ddlQuarters)
		{
			int num = 0;
			ddlQuarters.DataSource = DALCommon.GetList_HL(0, "Quarters", "", 0, 0, "", " Array asc ", out num);
			ddlQuarters.DataTextField = "_Name";
			ddlQuarters.DataValueField = "ID";
			ddlQuarters.DataBind();
			ddlQuarters.Items.Insert(0, new ListItem("", "-1"));
			ddlQuarters.Items.Add(new ListItem("新建...", "0"));
		}

		public static void BindRepairClass(DropDownList ddlRepairClass)
		{
			int num = 0;
			ddlRepairClass.DataSource = DALCommon.GetList_HL(0, "RepairClass", "", 0, 0, "", " Array asc ", out num);
			ddlRepairClass.DataTextField = "_Name";
			ddlRepairClass.DataValueField = "ID";
			ddlRepairClass.DataBind();
			ddlRepairClass.Items.Insert(0, new ListItem("", "-1"));
			ddlRepairClass.Items.Add(new ListItem("新建...", "0"));
		}

		public static void BindRepositoryClass(DropDownList ddlClass, string strWhere)
		{
			DataTable item = DALCommon.GetDataList("RepositoryClass", "", strWhere).Tables[0];
			ddlClass.DataSource = item;
			ddlClass.DataTextField = "_Name";
			ddlClass.DataValueField = "ID";
			ddlClass.DataBind();
			ddlClass.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindServiceLevel(DropDownList ddlLevel)
		{
			ddlLevel.DataSource = DALCommon.GetDataList("ServiceLevel", "", "");
			ddlLevel.DataTextField = "_Name";
			ddlLevel.DataValueField = "ID";
			ddlLevel.DataBind();
			ddlLevel.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindServicesStatus(DropDownList ddlStatus)
		{
			int num = 0;
			ddlStatus.DataSource = DALCommon.GetList_HL(0, "ServicesStatus", "", 0, 0, "", "ID", out num);
			ddlStatus.DataTextField = "_Name";
			ddlStatus.DataValueField = "ID";
			ddlStatus.DataBind();
			ddlStatus.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindServicesType(DropDownList ddlType)
		{
			int num = 0;
			ddlType.DataSource = DALCommon.GetList_HL(0, "ServicesType", "", 0, 0, "", " Array asc ", out num);
			ddlType.DataTextField = "_Name";
			ddlType.DataValueField = "ID";
			ddlType.DataBind();
		}

		public static void BindSndStyle(DropDownList ddlSndStyle, string strWhere)
		{
			int num = 0;
			ddlSndStyle.DataSource = DALCommon.GetList_HL(0, "ShippingStyle", "[ID],[_Name]", 0, 0, strWhere, "ID", out num);
			ddlSndStyle.DataTextField = "_Name";
			ddlSndStyle.DataValueField = "ID";
			ddlSndStyle.DataBind();
			ddlSndStyle.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindStaff(DropDownList ddlStaff, string strWhere)
		{
			int num = 0;
			ddlStaff.DataSource = DALCommon.GetList_HL(0, "StaffList", "[ID],[_Name]", 0, 0, strWhere, "ID", out num);
			ddlStaff.DataTextField = "_Name";
			ddlStaff.DataValueField = "ID";
			ddlStaff.DataBind();
			ddlStaff.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindStock(DropDownList dllStock, string strWhere)
		{
			int num = 0;
			dllStock.DataSource = DALCommon.GetList_HL(0, "StockList", "", 0, 0, strWhere, "ID", out num);
			dllStock.DataTextField = "_Name";
			dllStock.DataValueField = "ID";
			dllStock.DataBind();
			dllStock.Items.Insert(0, new ListItem("", "-1"));
			dllStock.Items.Add(new ListItem("新建...", "0"));
		}

		public static void BindStockLoc(DropDownList ddlStockLoc, string strWhere)
		{
			int num = 0;
			ddlStockLoc.DataSource = DALCommon.GetList_HL(0, "StockLocation", "", 0, 0, strWhere, " Array asc ", out num);
			ddlStockLoc.DataTextField = "_Name";
			ddlStockLoc.DataValueField = "ID";
			ddlStockLoc.DataBind();
			ddlStockLoc.Items.Insert(0, new ListItem("", "-1"));
			ddlStockLoc.Items.Add(new ListItem("新建...", "0"));
		}

		public static void BindStocks(DropDownList dllStock, string strWhere)
		{
			int num = 0;
			dllStock.DataSource = DALCommon.GetList_HL(0, "StockList", "", 0, 0, strWhere, "ID", out num);
			dllStock.DataTextField = "_Name";
			dllStock.DataValueField = "ID";
			dllStock.DataBind();
			dllStock.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindSupplier(DropDownList ddlProvider, string strWhere)
		{
			int num = 0;
			ddlProvider.DataSource = DALCommon.GetList_HL(0, "SuppLierList", "[ID],[_Name]", 0, 0, strWhere, "ID", out num);
			ddlProvider.DataTextField = "_Name";
			ddlProvider.DataValueField = "ID";
			ddlProvider.DataBind();
			ddlProvider.Items.Insert(0, new ListItem("", "-1"));
			ddlProvider.Items.Add(new ListItem("新建...", "0"));
		}

		public static void BindTakeStyle(DropDownList ddlTakeStyle)
		{
			int num = 0;
			ddlTakeStyle.DataSource = DALCommon.GetList_HL(0, "TakeStyle", "", 0, 0, "", " Array asc ", out num);
			ddlTakeStyle.DataTextField = "_Name";
			ddlTakeStyle.DataValueField = "ID";
			ddlTakeStyle.DataBind();
		}

		public static void BindTrackStyle(DropDownList ddlTrackStyle)
		{
			ddlTrackStyle.DataSource = DALCommon.GetDataList("TrackStyle", "", " 1=1 order by Array asc");
			ddlTrackStyle.DataTextField = "_Name";
			ddlTrackStyle.DataValueField = "ID";
			ddlTrackStyle.DataBind();
			ddlTrackStyle.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindTrackType(DropDownList ddlTrackType)
		{
			ddlTrackType.DataSource = DALCommon.GetDataList("TrackType", "", " 1=1 order by Array asc");
			ddlTrackType.DataTextField = "_Name";
			ddlTrackType.DataValueField = "ID";
			ddlTrackType.DataBind();
			ddlTrackType.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindTreeNode(TreeNode node, DataTable dt, string parentid)
		{
			DataRow[] dataRowArray = dt.Select(string.Concat(" Father=", parentid));
			for (int i = 0; i < (int)dataRowArray.Length; i++)
			{
				DataRow dataRow = dataRowArray[i];
				TreeNode treeNode = new TreeNode()
				{
					Text = dataRow["_Name"].ToString(),
					Value = dataRow["_Level"].ToString()
				};
				node.ChildNodes.Add(treeNode);
				OtherFunction.BindTreeNode(treeNode, dt, dataRow["ID"].ToString());
			}
		}

		public static void BindTreeNode2(TreeNode node, DataTable dt, string parentid)
		{
			DataRow[] dataRowArray = dt.Select(string.Concat(" Father=", parentid));
			for (int i = 0; i < (int)dataRowArray.Length; i++)
			{
				DataRow dataRow = dataRowArray[i];
				TreeNode treeNode = new TreeNode()
				{
					Text = dataRow["_Name"].ToString(),
					Value = dataRow["ID"].ToString()
				};
				node.ChildNodes.Add(treeNode);
				OtherFunction.BindTreeNode2(treeNode, dt, dataRow["ID"].ToString());
			}
		}

		public static void BindTrobleReason(DropDownList ddlTrobleReason)
		{
			int num = 0;
			ddlTrobleReason.DataSource = DALCommon.GetList_HL(0, "TroubleReason", "", 0, 0, "", " Array asc ", out num);
			ddlTrobleReason.DataTextField = "_Name";
			ddlTrobleReason.DataValueField = "ID";
			ddlTrobleReason.DataBind();
			ddlTrobleReason.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindUnit(DropDownList ddlUnit)
		{
			int num = 0;
			ddlUnit.DataSource = DALCommon.GetList_HL(0, "UnitList", "", 0, 0, "", " Array asc ", out num);
			ddlUnit.DataTextField = "_Name";
			ddlUnit.DataValueField = "ID";
			ddlUnit.DataBind();
			ddlUnit.Items.Insert(0, new ListItem("", "-1"));
			ddlUnit.Items.Add(new ListItem("新建...", "0"));
		}

		public static void BindUser(DropDownList ddlUser, string strWhere)
		{
			int num = 0;
			ddlUser.DataSource = DALCommon.GetList_HL(0, "xt_usermanage", "[ID],[_Name]", 0, 0, strWhere, "ID", out num);
			ddlUser.DataTextField = "_Name";
			ddlUser.DataValueField = "ID";
			ddlUser.DataBind();
			ddlUser.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindUserSortJobNO(DropDownList ddlUser, string strWhere)
		{
			int num = 0;
			ddlUser.DataSource = DALCommon.GetList_HL(0, "xt_usermanage", "[ID],[_Name]", 0, 0, strWhere, "JobNO", out num);
			ddlUser.DataTextField = "_Name";
			ddlUser.DataValueField = "ID";
			ddlUser.DataBind();
			ddlUser.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindVisitStyle(DropDownList ddlVisitStyle)
		{
			int num = 0;
			ddlVisitStyle.DataSource = DALCommon.GetList_HL(0, "VisitStyle", "", 0, 0, "", " Array asc ", out num);
			ddlVisitStyle.DataTextField = "_Name";
			ddlVisitStyle.DataValueField = "ID";
			ddlVisitStyle.DataBind();
			ddlVisitStyle.Items.Insert(0, new ListItem("", "-1"));
		}

		public static void BindWarranty(DropDownList ddlWarranty)
		{
			int num = 0;
			ddlWarranty.DataSource = DALCommon.GetList_HL(0, "Warranty", "", 0, 0, " bStopUse=0", " Array asc ", out num);
			ddlWarranty.DataTextField = "_Name";
			ddlWarranty.DataValueField = "ID";
			ddlWarranty.DataBind();
			ddlWarranty.Items.Insert(0, new ListItem("", "-1"));
			ddlWarranty.Items.Add(new ListItem("新建...", "0"));
		}
	}
}