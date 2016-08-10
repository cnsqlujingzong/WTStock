<%@ page language="C#"  CodeFile="default.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Default" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title><%=strTitle %>总部平台</title>
<link rel="shortcut icon" href="../Public/Images/sico.ico" />
<link rel="icon" type="image/gif" href="../Public/Images/dtico.gif" />
<link rel="Stylesheet" type="text/css" href="../Public/Style/basic.css" />
<link rel="Stylesheet" type="text/css" href="../Public/Style/menu.css" />
<link rel="Stylesheet" type="text/css" href="../Public/Style/wintab.css" />
<script language="javascript" type="text/javascript" src="../Public/Script/Ajax.js"></script>
<script language="javascript" type="text/javascript" src="../Public/Script/dlg.js"></script>
<script language="javascript" type="text/javascript" src="../Public/Script/menu.js"></script>
<script language="javascript" type="text/javascript">
if  (self != top)
{
    top.location  =  self.location;
}
function ChkExit()
{
    if(confirm("确认要退出总部系统吗？"))
    {
        document.getElementById("btnExit").click();
    }
}

function ChkClose()
{
    event.returnValue="";
}
/*-----菜单设置-----------*/
var fmenu=false;
function ClickSetmenu(mleft,mheight,id)
{
    <%=_Menu %>
    fmenu=true;
    Setmenu(mleft,mheight,id);
}

function Setmenu(mleft,mheight,id)
{
    if(!fmenu)
    {
        return;
    }
    with($(id).style)
    {
        display='block';
        top = "21px";
        left =mleft+"px";
        width="162px";
        height=mheight+"px";
    }
    with($(id+"s").style)
    {
        display='block';
        top = "0px";
        left ="0px";
        width="130px";
        height=mheight+"px";
    }
    var i=1;
    while($("menu_s_sub_"+i))
    {
        if(("menu_s_sub_"+i)!=id)
        {
            $("menu_s_sub_"+i).style.display="none";
        }
        i++;
    }
    
    for(var i=1;i<=15;i++)
    {
        if(("menu_s_"+i)!=id)
        {
            $("menu_s_"+i).style.display="none";
        }
    }
}

function SetFrame(Aid,url,title)
{
    <%=_Menu %>
    AddWin(Aid,title,url,0,0,1,0,0);
    setTimeout("Sethidden1()",0);
}

function Setmenu_sub(mtop,mleft,id)
{
    with($(id).style)
    {
        top = mtop+"px";
        left =mleft+"px"; 
        display="block";  
    }
    
    var i=1;
    while($("menu_s_sub_"+i))
    {
        if(("menu_s_sub_"+i)!=id)
        {
            $("menu_s_sub_"+i).style.display="none";
        }
        i++;
    }
}

function Sethidden1()
{
    var i=1;
    while($("menu_s_sub_"+i))
    {
        $("menu_s_sub_"+i).style.display="none";
        i++;
    }
    for(var i=1;i<=15;i++)
    {
        $("menu_s_"+i).style.display="none";
    }
    fmenu=false;
}

function Sethiddensub(id)
{
    $(id).style.display="none";
}

window.onload=function() 
{
var obj = document.getElementById("divTitleName");
  var target = document.getElementById("divDialog");
  drag(obj, target);
  var obj1 = document.getElementById("divTitleName1");
  var target1 = document.getElementById("divDialog1");
  drag(obj1, target1);
    
  var obj2 = document.getElementById("divTitleName2");
  var target2 = document.getElementById("divDialog2");
  drag(obj2, target2);
  var obj3 = document.getElementById("divTitleName3");
  var target3 = document.getElementById("divDialog3");
  drag(obj3, target3);
  
  Loading("over");
  AddWin('YWDH','业务导航','Mynavigation/all.html',0,0,1,0,0);
  ChangeWin();
　<%=_Reg%>
}
</script>
</head>
<body scroll="no" onresize="ChangeWin()">
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="hfServerDate" runat="server" />
    <asp:HiddenField ID="hfUser" runat="server" />
    <asp:HiddenField ID="hfPurview" runat="server" />
    <asp:HiddenField ID="hfAdmin" runat="server" />
    <asp:HiddenField ID="hfActiveWin" runat="server" />
    <asp:HiddenField ID="hfActiveWinID" runat="server" />
    <span style="display:none;"><asp:Button ID="btnExit" runat="server" OnClick="btnExit_Click"  UseSubmitBehavior="false" />
        <asp:Button ID="btnRefreshOnline" runat="server" Text="Button" OnClick="btnRefreshOnline_Click" UseSubmitBehavior="false" /><asp:UpdatePanel
            ID="UpdatePanel1" runat="server">
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnRefreshOnline" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </span>
<div id="dtop">
<div id="menu">
    <ul id="menu_par">
        <li id="sptitle"></li>
        <li <%=moduln[0] %>><a href="#" onclick="<%=module[0] %>ClickSetmenu('<%=modulm[0] %>','<%=modulh[0] %>','menu_s_1');" onmouseover="<%=module[0] %>Setmenu('<%=modulm[0] %>','<%=modulh[0] %>','menu_s_1');">仓库管理</a></li><li <%=moduln[1] %>><a href="#" onclick="<%=module[1] %>ClickSetmenu('<%=modulm[1] %>','<%=modulh[1] %>','menu_s_2');" onmouseover="<%=module[1] %>Setmenu('<%=modulm[1] %>','<%=modulh[1] %>','menu_s_2');">采购管理</a></li><li <%=moduln[2] %>><a href="#" onclick="<%=module[2] %>ClickSetmenu('<%=modulm[2] %>','<%=modulh[2] %>','menu_s_3');" onmouseover="<%=module[2] %>Setmenu('<%=modulm[2] %>','<%=modulh[2] %>','menu_s_3');">销售管理</a></li><li <%=moduln[3] %>><a href="#" onclick="<%=module[3] %>ClickSetmenu('<%=modulm[3] %>','<%=modulh[3] %>','menu_s_4');" onmouseover="<%=module[3] %>Setmenu('<%=modulm[3] %>','<%=modulh[3] %>','menu_s_4');">服务管理</a></li><li <%=moduln[4] %>><a style="line-height:23px;" href="#" onclick="<%=module[4] %>ClickSetmenu('<%=modulm[4] %>','<%=modulh[4] %>','menu_s_5');" onmouseover="<%=module[4] %>Setmenu('<%=modulm[4] %>','<%=modulh[4] %>','menu_s_5');">租赁/全保</a></li><li <%=moduln[5] %>><a href="#" onclick="<%=module[5] %>ClickSetmenu('<%=modulm[5] %>','<%=modulh[5] %>','menu_s_6');" onmouseover="<%=module[5] %>Setmenu('<%=modulm[5] %>','<%=modulh[5] %>','menu_s_6');">客户关系</a></li><li <%=moduln[6] %>><a href="#" onclick="<%=module[6] %>ClickSetmenu('<%=modulm[6] %>','<%=modulh[6] %>','menu_s_7');" onmouseover="<%=module[6] %>Setmenu('<%=modulm[6] %>','<%=modulh[6] %>','menu_s_7');">帐款管理</a></li><li <%=moduln[7] %>><a href="#" onclick="<%=module[7] %>ClickSetmenu('<%=modulm[7] %>','<%=modulh[7] %>','menu_s_8');" onmouseover="<%=module[7] %>Setmenu('<%=modulm[7] %>','<%=modulh[7] %>','menu_s_8');">收发管理</a></li><li <%=moduln[8] %>><a href="#" onclick="<%=module[8] %>ClickSetmenu('<%=modulm[8] %>','<%=modulh[8] %>','menu_s_9');" onmouseover="<%=module[8] %>Setmenu('<%=modulm[8] %>','<%=modulh[8] %>','menu_s_9');" style="width:55px; line-height:23px;">办公OA</a></li><li <%=moduln[9] %>><a href="#" onclick="<%=module[9] %>ClickSetmenu('<%=modulm[9] %>','<%=modulh[9] %>','menu_s_10');" onmouseover="<%=module[9] %>Setmenu('<%=modulm[9] %>','<%=modulh[9] %>','menu_s_10');">期初录入</a></li><li <%=moduln[10] %>><a href="#" onclick="<%=module[10] %>ClickSetmenu('<%=modulm[10] %>','<%=modulh[10] %>','menu_s_11');" onmouseover="<%=module[10] %>Setmenu('<%=modulm[10] %>','<%=modulh[10] %>','menu_s_11');">统计分析</a></li><li <%=moduln[11] %>><a href="#" onclick="<%=module[11] %>ClickSetmenu('<%=modulm[11] %>','<%=modulh[11] %>','menu_s_12');" onmouseover="<%=module[11] %>Setmenu('<%=modulm[11] %>','<%=modulh[11] %>','menu_s_12');">基础数据</a></li><li><a href="#" onclick="ClickSetmenu('<%=modulm[12] %>','<%=modulh[12] %>','menu_s_13');" onmouseover="Setmenu('<%=modulm[12] %>','<%=modulh[12] %>','menu_s_13');">系统维护</a></li><li><a href="#" onclick="ClickSetmenu('<%=modulm[13] %>','<%=modulh[13] %>','menu_s_14');" onmouseover="Setmenu('<%=modulm[13] %>','<%=modulh[13] %>','menu_s_14');" style="width:35px;">工具</a></li>
<%--        <li><a href="#" onclick="ClickSetmenu('<%=modulm[14] %>','<%=modulh[14] %>','menu_s_15');" onmouseover="Setmenu('<%=modulm[14] %>','<%=modulh[14] %>','menu_s_15');" style="width:35px;">帮助</a></li>--%>
 <%--       <li><a href ="http://www.18bg.com" target ="_blank">18云办公</a></li>--%>
    </ul>
    
    <div id="menu_s_1" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:298px;width:162px;" frameborder="0"></iframe>
         <div id="menu_s_1s" class="KsMenu2">
            <a href="#" <%=menu[0] %> onclick="ShowDialog(600, 380, 'Stock/GoodsClassAdm.aspx', '产品分类');">产品分类</a>
            <a href="#" <%=menu[1] %> onclick="SetFrame('cpml','Stock/GoodsAdm.aspx','产品目录');">产品目录</a>
            <div class="KsLine"></div>
            <a href="#" <%=menu[2] %> onclick="SetFrame('dqkc','Stock/StockAdm.aspx','当前库存');">当前库存</a>
            <a href="#" <%=menu[3] %> onclick="SetFrame('fpkc','Stock/StockrAdm.aspx','废品库存');">废品库存</a>
            <a href="#" <%=menu[4] %> onclick="SetFrame('fckc','Stock/DeptStock.aspx','分仓库存');">分仓库存</a>
            <a href="#" <%=menu[5] %> onclick="SetFrame('xlhk','Stock/SNAdm.aspx','序列号库');">序列号库</a>
            <div class="KsLine"></div>
            <a href="#" <%=menu[6] %> onclick="SetFrame('qtrk','Stock/StockIn.aspx','其他入库');">其他入库</a>			
            <a href="#" <%=menu[7] %> onclick="SetFrame('qtck','Stock/StockOut.aspx','其他出库');">其他出库</a>
            <a href="#" <%=menu[8] %> onclick="SetFrame('llkd','Stock/BroughtBack.aspx','领退开单');" onmouseover="Sethiddensub('menu_s_sub_22');">领退开单</a>
            <div class="KsLine"></div>
            <a href="#" id="row22" onmouseover="Sethiddensub('menu_s_sub_21');Setmenu_sub('190','158','menu_s_sub_22');">内部调拨</a>
            <a href="#" id="row21" onmouseover="Sethiddensub('menu_s_sub_22');Setmenu_sub('211','158','menu_s_sub_21');">网点调拨</a>
            <div class="KsLine"></div>
            <a href="#" <%=menu[13] %> id="row1" onmouseover="Setmenu_sub('<%=modulh_s[0] %>','158','menu_s_sub_1');">借出管理</a>
			<a href="#" <%=menu[14] %> id="row2" onmouseover="Setmenu_sub('<%=modulh_s[1] %>','158','menu_s_sub_2');">仓库业务</a>
			<a href="#" <%=menu[15] %> id="row3" onmouseover="Setmenu_sub('<%=modulh_s[2] %>','158','menu_s_sub_3');">单据查询</a>
		</div>
		<div id="menu_s_sub_21" class="KsMenu" style="height:84px;z-index:9999;">
		    <iframe style="position: absolute;z-index: -2;height:80px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" <%=menu[9] %>  onclick="SetFrame('dbsq','Stock/AllocateApp.aspx','调拨申请');">调拨申请</a>
                <a href="#" <%=menu[10] %> onclick="SetFrame('dbsh','Stock/AllocateAppChk.aspx','调拨审核');">调拨审核</a>
                <a href="#" <%=menu[11] %> onclick="SetFrame('dbfh','Stock/AllocateRec.aspx','调拨发货');">调拨发货</a>
                <a href="#" <%=menu[12] %> onclick="SetFrame('dbqs','Stock/AllocateSigned.aspx','调拨签收');" onmouseover="Sethiddensub('menu_s_sub_1');">调拨签收</a>
		    </div>
		</div>
		<div id="menu_s_sub_22" class="KsMenu" style="height:63px;z-index:9999;">
		    <iframe style="position: absolute;z-index: -2;height:60px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" onclick="SetFrame('nbdbsq','Stock/AllocateAdd.aspx','内部调拨申请');">内部调拨申请</a>
                <a href="#" onclick="SetFrame('nbdbcksh','Stock/InnerOutChk.aspx','内部调拨出库审核');">内部调拨出库审核</a>
                <a href="#" onclick="SetFrame('nbdbrksh','Stock/InnerInChk.aspx','内部调拨入库审核');">内部调拨入库审核</a>
		    </div>
		</div>
		<div id="menu_s_sub_1" class="KsMenu" style="height:42px;z-index:9999;">
		    <iframe style="position: absolute;z-index: -2;height:40px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" <%=menu[16] %> onclick="SetFrame('jckd','Stock/LendingAdd.aspx','借出开单');">借出开单</a>
                <a href="#" <%=menu[17] %> onclick="SetFrame('jccx','Stock/SchLendingReturn.aspx','借出查询');">借出查询</a>
		    </div>
		</div>
		
		<div id="menu_s_sub_2" class="KsMenu" style="height:63px;z-index:9999;">
		    <iframe style="position: absolute;z-index: -2;height:60px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" <%=menu[18] %> onclick="SetFrame('cxzz','Stock/DisBiling.aspx','拆装开单');">拆装开单</a>
                <a href="#" <%=menu[19] %> onclick="SetFrame('tjkd','Stock/Regulate.aspx','调价开单');">调价开单</a>
                <a href="#" <%=menu[20] %> onclick="SetFrame('pdkd','Stock/StockCheck.aspx','盘点开单');">盘点开单</a>
		    </div>
		</div>
		<div id="menu_s_sub_3" class="KsMenu" style="height:168px;z-index:9999;">
		    <iframe style="position: absolute;z-index: -2;height:160px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" <%=menu[21] %> onclick="SetFrame('rkdcx','Stock/SchStockIn.aspx','入库单查询');">入库单查询</a>
		        <a href="#" <%=menu[22] %> onclick="SetFrame('ckdcx','Stock/SchStockOut.aspx','出库单查询');">出库单查询</a>
				<a href="#" <%=menu[23] %> onclick="SetFrame('ltdcx','Stock/SchBroughtBack.aspx','领退单查询');">领退单查询</a>
				<a href="#" <%=menu[24] %> onclick="SetFrame('nbdbdcx','Stock/SchInnerAllocate.aspx','内部调拨单查询');">内部调拨单查询</a>
				<a href="#" <%=menu[24] %> onclick="SetFrame('dbdcx','Stock/SchAllocate.aspx','网点调拨单查询');">网点调拨单查询</a>
				<a href="#" <%=menu[25] %> onclick="SetFrame('czdcx','Stock/SchDisBiling.aspx','拆装单查询');">拆装单查询</a>
				<a href="#" <%=menu[26] %> onclick="SetFrame('tjdcx','Stock/SchRegulate.aspx','调价单查询');">调价单查询</a>
				<a href="#" <%=menu[27] %> onclick="SetFrame('pddcx','Stock/SchStockCheck.aspx','盘点单查询');">盘点单查询</a>
			</div>
		</div>
    </div>
     <div id="menu_s_2" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:105px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_2s" class="KsMenu2">
			<a href="#" <%=menu[28] %> onclick="SetFrame('cgkd','Purchase/PurchaseAdd.aspx', '采购开单');">采购开单</a>
			<a href="#" <%=menu[29] %> onclick="SetFrame('cgth','Purchase/PurReturn.aspx', '采购退货');">采购退货</a>
			<a href="#" <%=menu[30] %> onclick="SetFrame('cgdcx','Purchase/SchPurchase.aspx','采购单查询');">采购单查询</a>
			<div class="KsLine"></div>
            <a href="#" <%=menu[31] %> onclick="SetFrame('cgdd','Purchase/PurPlanAdd.aspx', '采购订单');">采购订单</a>
			<a href="#" <%=menu[32] %> onclick="SetFrame('cgddcx','Purchase/SchPurPlan.aspx','采购订单查询');">采购订单查询</a>
		</div>
    </div>
    
    <div id="menu_s_3" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:105px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_3s" class="KsMenu2">
			<a href="#" <%=menu[33] %> onclick="SetFrame('xskd','Sell/SellAdd.aspx', '销售开单');">销售开单</a>
			<a href="#" <%=menu[34] %> onclick="SetFrame('xsth','Sell/SellReturn.aspx', '销售退货');">销售退货</a>
			<a href="#" <%=menu[35] %> onclick="SetFrame('xsdcx','Sell/SchSell.aspx','销售单查询');">销售单查询</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[36] %> onclick="SetFrame('xsdd','Sell/SellPlanAdd.aspx', '销售订单');">销售订单</a>
			<a href="#" <%=menu[37] %> onclick="SetFrame('xsddcx','Sell/SchSellPlan.aspx','销售订单查询');">销售订单查询</a>
		</div>
    </div>
    
    <div id="menu_s_4" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:191px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_4s" class="KsMenu2">
            <a href="#" <%=menu[38] %> onclick="SetFrame('bxsh','Services/ServicesNet.aspx', '报修审核');">报修审核</a>
            <a href="#" <%=menu[39] %> onclick="SetFrame('sqqr','Services/ServicesConf.aspx','送修确认');">送修确认</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[40] %> onclick="SetFrame('fwzx','Services/ServicesAllot.aspx','服务中心')" onmouseover="Sethiddensub('menu_s_sub_4');">服务中心</a>
            <div class="KsLine"></div>
            <a href="#" <%=menu[41] %> id="row4" onmouseover="Setmenu_sub('<%=modulh_s[3] %>','158','menu_s_sub_4');">送修管理</a>
			<a href="#" <%=menu[42] %> onclick="SetFrame('wgjs','Services/ServicesBln.aspx','完工结算');" onmouseover="Sethiddensub('menu_s_sub_4');">完工结算</a>
			<a href="#" <%=menu[43] %> onclick="SetFrame('shgb','Services/ServicesOver.aspx','审核关闭');">审核关闭</a>
            <a href="#" <%=menu[44] %> onclick="SetFrame('fwhf','Services/ServicesCall.aspx','服务回访');">服务回访</a>
            <div class="KsLine"></div>
            <a href="#" <%=menu[45] %> onclick="SetFrame('fwdcx','Services/SchServices.aspx','服务单查询');">服务单查询</a>
            <a href="#" <%=menu[45] %> onclick="SetFrame('xxfwdcx','Services/SchFullServices.aspx','详细服务单');">详细服务单</a>
	    </div>
	    <div id="menu_s_sub_4" class="KsMenu" style="height:63px;z-index:9999;">
		    <iframe style="position: absolute;z-index: -2;height:60px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" <%=menu[46] %> onclick="SetFrame('sxfh','Services/ServicesSnd.aspx','送修发货');">送修发货</a>
		        <a href="#" <%=menu[47] %> onclick="SetFrame('shjs','Services/ServicesRcv.aspx','收货结算');">收货结算</a>
		        <a href="#" <%=menu[48] %> onclick="SetFrame('lssx','Services/HistorySnd.aspx','历史送修');">历史送修</a>
	        </div>
        </div>
    </div>
     <div id="menu_s_5" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:150px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_5s" class="KsMenu2">
			<a href="#" <%=menu[49] %> onclick="SetFrame('xjyw','Lease/LeaseAdd.aspx', '新建业务');">新建业务</a>
			<a href="#" <%=menu[49] %> onclick="SetFrame('ywsh','Lease/LeaseChk.aspx', '业务审核');">业务审核</a>
			<div class="KsLine"></div>			
			<a href="#" <%=menu[50] %> onclick="SetFrame('cbdd','Lease/MeterReading.aspx', '抄表登记');">抄表登记</a>
			<a href="#" <%=menu[51] %> onclick="SetFrame('sbgh','Lease/ChangeMachine.aspx', '设备退换');">设备退换</a>
			<a href="#" <%=menu[52] %> onclick="SetFrame('htjy','Lease/Release.aspx', '合同解约');">合同解约</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[53] %> onclick="SetFrame('jssh','Lease/Settlement.aspx', '结算审核');">结算审核</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[54] %> onclick="SetFrame('ywcx','Lease/SchLease.aspx','业务查询');">业务查询</a>
		</div>
    </div>
    <div id="menu_s_6" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:213px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_6s" class="KsMenu2">
            <a href="#" <%=menu[55] %> onclick="ShowDialog(600, 380, 'Customer/CusClassAdm.aspx', '客户分类');">客户分类</a>
			<a href="#" <%=menu[56] %> onclick="ShowDialog(600, 380, 'Customer/MembersAdm.aspx', '会员级别');">会员级别</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[57] %> onclick="SetFrame('khda','Customer/CusListAdm.aspx','客户档案');">客户档案</a>
			<a href="#" <%=menu[58] %> onclick="SetFrame('jqda','Customer/DeviceListAdm.aspx','机器档案');">机器档案</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[59] %> onclick="SetFrame('fwht','Customer/MaintenanceContract.aspx','服务合同');">服务合同</a>
			<a href="#" <%=menu[60] %> onclick="SetFrame('bypg','Customer/MaintenanceAllot.aspx','保养派工');">保养派工</a>
			<a href="#" <%=menu[61] %> onclick="SetFrame('khgz','Customer/CustomerTrack.aspx','客户跟踪');">客户跟踪</a>
			<a href="#" <%=menu[62] %> onclick="SetFrame('hcgz','Customer/ConsumablesTrack.aspx','耗材跟踪');">耗材跟踪</a>
			<a href="#" <%=menu[63] %> onclick="SetFrame('tscl','Customer/ComplaintAdm.aspx','投诉管理');">投诉管理</a>
		    <div class="KsLine"></div>
		    <a href="#" <%=menu[64] %> onclick="SetFrame('bxhygl','Customer/AssAdm.aspx','报修会员管理');">报修会员管理</a>
		</div>
    </div>
    
    <div id="menu_s_7" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:128px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_7s" class="KsMenu2">
            <a href="#" <%=menu[65] %> id="row5" onmouseover="Setmenu_sub('<%=modulh_s[4] %>','158','menu_s_sub_5');">收款开单</a>
            <a href="#" <%=menu[66] %> id="row6" onmouseover="Setmenu_sub('<%=modulh_s[5] %>','158','menu_s_sub_6');">付款开单</a>
            <a href="#" <%=menu[67] %> onclick="SetFrame('sfkcx','Financial/IncomeAdm.aspx','收付款查询');" onmouseover="Sethiddensub('menu_s_sub_6');">收付款查询</a>
            <div class="KsLine"></div>
            <a href="#" <%=menu[68] %> onclick="SetFrame('ysyf','Financial/ArrearageAdm.aspx','应收应付');" onmouseover="Sethiddensub('menu_s_sub_7');">应收应付</a>
            <div class="KsLine"></div>
            <a href="#" <%=menu[69] %> id="row7"  onmouseover="Setmenu_sub('<%=modulh_s[6] %>','158','menu_s_sub_7');">现金银行</a>
            <a href="#" <%=menu[70] %> id="row8" onmouseover="Sethiddensub('menu_s_sub_7');Setmenu_sub('<%=modulh_s[7] %>','158','menu_s_sub_8');">费用报销</a>
		</div>
		<div id="menu_s_sub_5" class="KsMenu" style="height:63px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:60px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
	            <a href="#" <%=menu[71] %> onclick="SetFrame('sysk','Financial/IncomeAdd.aspx', '收应收款');">收应收款</a>
	            <a href="#" <%=menu[72] %> onclick="SetFrame('sysk2','Financial/AdvanceInAdd.aspx', '收预收款');">收预收款</a>
	            <a href="#" <%=menu[73] %> onclick="SetFrame('qtsk','Financial/OtherInAdd.aspx', '其他收款');">其他收款</a>
            </div>
        </div>
        <div id="menu_s_sub_6" class="KsMenu" style="height:63px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:60px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
	            <a href="#" <%=menu[74] %> onclick="SetFrame('fyfk','Financial/PaymentAdd.aspx','付应付款');">付应付款</a>
	            <a href="#" <%=menu[75] %> onclick="SetFrame('fyfk2','Financial/AdvancePayAdd.aspx','付预付款');">付预付款</a>
	            <a href="#" <%=menu[76] %> onclick="SetFrame('qtfk','Financial/OtherPayAdd.aspx','其他付款');">其他付款</a>
            </div>
        </div>
        <div id="menu_s_sub_7" class="KsMenu" style="height:42px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:40px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
                <a href="#" <%=menu[77] %> onclick="SetFrame('zhzz','Financial/Transfer.aspx','帐户转账');">帐户转账</a>
	            <a href="#" <%=menu[78] %> onclick="SetFrame('zhhz','Financial/IncomeBank.aspx','帐户汇总');">帐户汇总</a>
            </div>
        </div>
        
        <div id="menu_s_sub_8" class="KsMenu" style="height:106px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:100px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
                <a href="#" <%=menu[79] %> onclick="SetFrame('bxsq','Financial/Expense.aspx','报销申请');">报销申请</a>
	            <a href="#" <%=menu[80] %> onclick="SetFrame('zgsh','Financial/ChkExpense.aspx','主管审核');">主管审核</a>
	            <a href="#" <%=menu[81] %> onclick="SetFrame('kxff','Financial/PayExpense.aspx','款项发放');">款项发放</a>
	            <div class="KsLine"></div>
	            <a href="#" <%=menu[82] %> onclick="SetFrame('bxcx','Financial/SchExpense.aspx','报销查询');">报销查询</a>
	            <a href="#" <%=menu[82] %> onclick="SetFrame('bxmxd','Financial/SchFullExpense.aspx','报销明细');">报销明细</a>
            </div>
        </div>
    </div>
    
    <div id="menu_s_8" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:80px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_8s" class="KsMenu2">
			<a href="#" <%=menu[83] %> onclick="SetFrame('xjfh','Receive/SndNew.aspx', '新建发货');">新建发货</a>
			<a href="#" <%=menu[84] %> onclick="SetFrame('fhqr','Receive/SndSure.aspx','发货确认');">发货确认</a>
			<a href="#" <%=menu[85] %> onclick="SetFrame('qsqr','Receive/SndSign.aspx','签收确认');">签收确认</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[86] %> class="isch" onclick="SetFrame('fhcx','Receive/SndSch.aspx','收发查询');">收发查询</a>
		</div>
    </div>

     <div id="menu_s_9" class="KsMenu">
       <iframe style="position: absolute;z-index: -2;height:210px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_9s" class="KsMenu2">
			<a href="#" <%=menu[87] %> onclick="SetFrame('wdgl','Office/DocAdm.aspx','文档管理');">文档管理</a>
			<a href="#" <%=menu[88] %> onclick="SetFrame('gggl','Office/AnnunciateAdm.aspx','公告管理');">公告管理</a>
			<a href="#" <%=menu[89] %> onclick="SetFrame('zsgl','Repository/RepositoryAdm.aspx','知识管理');">知识管理</a>
			<a href="#" <%=menu[90] %> onclick="SetFrame('znxj','Office/MailAdm.aspx','站内信件');" class="iline" onmouseover="Sethiddensub('menu_s_sub_9');">站内信件</a>
			<a href="#" <%=menu[89] %> onclick="SetFrame('xxfk','Office/FeedBackadm.aspx','信息反馈');" onmouseover="Sethiddensub('menu_s_sub_23');">信息反馈</a>
			<a href="#" <%=menu[89] %> id="row23" onmouseover="Setmenu_sub('103','158','menu_s_sub_23');">合同管理</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[91] %> id="row9" onmouseover="Setmenu_sub('<%=modulh_s[8] %>','158','menu_s_sub_9');">考勤管理</a>
			<a href="#" <%=menu[92] %> onclick="SetFrame('rwgl','Office/TaskAdm.aspx','任务管理');" onmouseover="Sethiddensub('menu_s_sub_9');">任务管理</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[93] %> onclick="SetFrame('ggtcmx','Office/TecDeduct.aspx','员工提成明细');">员工提成明细</a>
			<a href="#" <%=menu[94] %> onclick="SetFrame('yckqmx','Office/AttendanceDe.aspx','异常考勤明细');">异常考勤明细</a>
			<a href="#" <%=menu[95] %> onclick="SetFrame('ygydxz','Office/TecWage.aspx','员工月度薪资');">员工月度薪资</a>
			<a href="#" <%=menu[96] %> onclick="SetFrame('ygrgzhz','Office/TecDayWork.aspx','员工工作汇总');">员工工作汇总</a>
		</div>
	    <div id="menu_s_sub_9" class="KsMenu" style="height:84px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:80px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
                <a href="#" <%=menu[97] %> onclick="ShowDialog(400, 150, 'Office/Absence.aspx', '考勤签到');">考勤签到</a>
	            <a href="#" <%=menu[98] %> onclick="SetFrame('qqsh','Office/ChkAttendance.aspx','缺勤审核');">缺勤审核</a>
	            <a href="#" <%=menu[99] %> onclick="SetFrame('kqhz','Office/Attendance.aspx','考勤汇总');">考勤汇总</a>
	            <a href="#" <%=menu[100] %> onclick="ShowDialog(600, 380, 'Office/AbsenceSet.aspx', '考勤设置');">考勤设置</a>
            </div>
        </div>
        <div id="menu_s_sub_23" class="KsMenu" style="height:21px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:21px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2" style="width:140px">
                <a href="#" onclick="SetFrame('xshegl', 'Office/SalesContract.aspx', '销售合同');">销售合同管理</a>
            </div>
        </div>
    </div>

    <div id="menu_s_10" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:60px;width:162px;" frameborder="0"></iframe>
         <div id="menu_s_10s" class="KsMenu2">
			<a href="#" <%=menu[101] %> onclick="SetFrame('qckc','BeginAccount/BeginStock.aspx','期初产品库存');" onmouseover="Sethiddensub('menu_s_sub_10');">期初产品库存</a>
			<a href="#" <%=menu[102] %> id="row10" onmouseover="Setmenu_sub('<%=modulh_s[9] %>','158','menu_s_sub_10');">期初应收应付</a>
			<a href="#" <%=menu[103] %> onclick="SetFrame('qcxjyh','BeginAccount/BeginCash.aspx','期初现金银行');" onmouseover="Sethiddensub('menu_s_sub_10');">期初现金银行</a>
		</div>
	    <div id="menu_s_sub_10" class="KsMenu" style="height:63px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:60px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" <%=menu[104] %> onclick="SetFrame('khqcysyf','BeginAccount/CusBeginArr.aspx','客户期初应收应付');">客户期初应收应付</a>
		        <a href="#" <%=menu[105] %> onclick="SetFrame('csqcysyf','BeginAccount/SupBeginArr.aspx','厂商期初应收应付');">厂商期初应收应付</a>
		        <a href="#" <%=menu[106] %> onclick="SetFrame('wdqcysyf','BeginAccount/BraBeginArr.aspx','网点期初应收应付');">网点期初应收应付</a>
	        </div>
        </div>
    </div>
    
    <div id="menu_s_11" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:185px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_11s" class="KsMenu2">
            <a href="#" <%=menu[107] %> id="row11" onmouseover="Setmenu_sub('<%=modulh_s[10] %>','158','menu_s_sub_11');">综合业务报表</a>
            <a href="#" <%=menu[108] %> id="row12" onmouseover="Setmenu_sub('<%=modulh_s[11] %>','158','menu_s_sub_12');">仓库业务报表</a>
            <a href="#" <%=menu[109] %> id="row13" onmouseover="Setmenu_sub('<%=modulh_s[12] %>','158','menu_s_sub_13');">采购业务报表</a>
            <a href="#" <%=menu[110] %> id="row14" onmouseover="Setmenu_sub('<%=modulh_s[13] %>','158','menu_s_sub_14');">销售业务报表</a>
            <a href="#" <%=menu[111] %> id="row15" onmouseover="Setmenu_sub('<%=modulh_s[14] %>','158','menu_s_sub_15');">服务业务报表</a>
            <a href="#" <%=menu[112] %> id="row16" onmouseover="Setmenu_sub('<%=modulh_s[15] %>','158','menu_s_sub_16');">租赁/全保报表</a>
            <a href="#" <%=menu[113] %> id="row17" onmouseover="Setmenu_sub('<%=modulh_s[16] %>','158','menu_s_sub_17');">客户关系报表</a>
            <a href="#" <%=menu[114] %> id="row18" onmouseover="Setmenu_sub('<%=modulh_s[17] %>','158','menu_s_sub_18');">帐款业务报表</a>
            <a href="#" <%=menu[115] %> id="row19" onmouseover="Setmenu_sub('<%=modulh_s[18] %>','158','menu_s_sub_19');">数据挖掘报表</a>
		</div>
		<div id="menu_s_sub_11" class="KsMenu" style="height:42px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:40px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" <%=menu[116] %> onclick="SetFrame('ryyehzb','Stat/StDaySeller.aspx','日营业额汇总表');">日营业额汇总表</a>
		        <a href="#" <%=menu[117] %> onclick="SetFrame('yyyehzb','Stat/StMonthSeller.aspx','月营业额汇总表');">月营业额汇总表</a>
	        </div>
        </div>
        <div id="menu_s_sub_12" class="KsMenu" style="height:210px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:200px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" <%=menu[118] %> onclick="SetFrame('ckrbb','Stat/StStockDay.aspx','仓库日报表');">仓库日报表</a>
		        <a href="#" <%=menu[119] %> onclick="SetFrame('ckhzb','Stat/StStock.aspx','仓库汇总表');">仓库汇总表</a>
		        <a href="#" <%=menu[120] %> onclick="SetFrame('cprkhzb','Stat/StStockINg.aspx','产品入库汇总表');">产品入库汇总表</a>
		        <a href="#" <%=menu[121] %> onclick="SetFrame('ckrkhzb','Stat/StStockINs.aspx','仓库入库汇总表');">仓库入库汇总表</a>
		        <a href="#" <%=menu[122] %> onclick="SetFrame('rkmxhzb','Stat/StStockINDe.aspx','入库明细汇总表');">入库明细汇总表</a>
		        <a href="#" <%=menu[123] %> onclick="SetFrame('cpckhzb','Stat/StStockOUTg.aspx','产品出库汇总表');">产品出库汇总表</a>
		        <a href="#" <%=menu[124] %> onclick="SetFrame('ckckhzb','Stat/StStockOUTs.aspx','仓库出库汇总表');">仓库出库汇总表</a>
		        <a href="#" <%=menu[125] %> onclick="SetFrame('ckmxhzb','Stat/StStockOUTDe.aspx','出库明细汇总表');">出库明细汇总表</a>
		        <a href="#" <%=menu[126] %> onclick="SetFrame('cplthzb','Stat/StBroughtBack.aspx','产品领退汇总表');">产品领退汇总表</a>
		        <a href="#" <%=menu[127] %> onclick="SetFrame('sqrkthzb','Stat/StBroughtBacka.aspx','申请人领退汇总表');">申请人领退汇总表</a>
	        </div>
        </div>
        <div id="menu_s_sub_13" class="KsMenu" style="height:148px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:140px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" <%=menu[128] %> onclick="SetFrame('cgrbb','Stat/StPurchaseDay.aspx','采购日报表');">采购日报表</a>
		        <a href="#" <%=menu[129] %> onclick="SetFrame('cpcghzb','Stat/StPurchaseg.aspx','产品采购汇总表');">产品采购汇总表</a>
	            <a href="#" <%=menu[130] %> onclick="SetFrame('gyscghzb','Stat/StPurchasep.aspx','供应商采购汇总表');">供应商采购汇总表</a>
	            <a href="#" <%=menu[131] %> onclick="SetFrame('cgmxhzb','Stat/StPurchaseDe.aspx','采购明细汇总表');">采购明细汇总表</a>
	            <div class="KsLine"></div>
	            <a href="#" <%=menu[132] %> onclick="SetFrame('cpthhzb','Stat/StPurReturng.aspx','产品退货汇总表');">产品退货汇总表</a>
	            <a href="#" <%=menu[133] %> onclick="SetFrame('gysthhzb','Stat/StPurReturnp.aspx','供应商退货汇总表');">供应商退货汇总表</a>
	            <a href="#" <%=menu[134] %> onclick="SetFrame('thmxb','Stat/StPurReturnDe.aspx','退货明细汇总表');">退货明细汇总表</a>
	        </div>
        </div>
        <div id="menu_s_sub_14" class="KsMenu" style="height:170px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:160px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
	            <a href="#" <%=menu[135] %> onclick="SetFrame('xsrbb','Stat/StSellDay.aspx','销售日报表');">销售日报表</a>
	            <a href="#" <%=menu[136] %> onclick="SetFrame('xsybb','Stat/StSellMonth.aspx','销售月报表');">销售月报表</a>
		        <div class="KsLine"></div>
		        <a href="#" <%=menu[137] %> onclick="SetFrame('cpxshzb','Stat/StSellg.aspx','产品销售汇总表');">产品销售汇总表</a>
	            <a href="#" <%=menu[138] %> onclick="SetFrame('khxshzb','Stat/StSellc.aspx','客户销售汇总表');">客户销售汇总表</a>
	            <a href="#" <%=menu[139] %> onclick="SetFrame('xsmxhzb','Stat/StSellDe.aspx','销售明细汇总表');">销售明细汇总表</a>
	            <div class="KsLine"></div>
	            <a href="#" <%=menu[140] %> onclick="SetFrame('cpthhzb2','Stat/StSellReturng.aspx','产品退货汇总表');">产品退货汇总表</a>
	            <a href="#" <%=menu[141] %> onclick="SetFrame('khthhzb','Stat/StSellReturnc.aspx','客户退货汇总表');">客户退货汇总表</a>
	            <a href="#" <%=menu[142] %> onclick="SetFrame('thmxhzb2','Stat/StSellReturnDe.aspx','退货明细汇总表');">退货明细汇总表</a>
	       </div>
        </div>
        <div id="menu_s_sub_15" class="KsMenu" style="height:615px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:550px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
	            <a href="#" <%=menu[143] %> onclick="SetFrame('fwrbb','Stat/StServiceDay.aspx','服务日报表');">服务日报表</a>
		        <a href="#" <%=menu[144] %> onclick="SetFrame('fwybb','Stat/StServiceMon.aspx','服务月报表');">服务月报表</a>
	            <div class="KsLine"></div>
	            <a href="#" <%=menu[145] %> onclick="SetFrame('fwhzb','Stat/StServicec.aspx','服务汇总表');">服务汇总表</a>
		        <a href="#" <%=menu[146] %> onclick="SetFrame('fwmxb','Stat/StServiceDe.aspx','服务明细表');">服务明细表</a>
		        <div class="KsLine"></div>
		        <a href="#" <%=menu[147] %> onclick="SetFrame('fwxmhzb','Stat/StSerItem.aspx','服务项目汇总表');">服务项目汇总表</a>
		        <a href="#" <%=menu[148] %> onclick="SetFrame('fuxmmxb','Stat/StSerItemDe.aspx','服务项目明细表');">服务项目明细表</a>
	            <div class="KsLine"></div>
	            <a href="#" <%=menu[149] %> onclick="SetFrame('fwdgl','Stat/StBillView.aspx','服务单概览');">服务单概览</a>
		        <a href="#" <%=menu[150] %> onclick="SetFrame('fwdfb','Stat/StBillFrom.aspx','服务单分布');">服务单分布</a>
		        <a href="#" <%=menu[151] %> onclick="SetFrame('jsyyj','Stat/StTechnician.aspx','技术员业绩');">技术员业绩</a>
		        <a href="#" <%=menu[151] %> onclick="SetFrame('jsygzrz','Stat/StDateSer.aspx','技术员工作日志');">技术员工作日志</a>
		        <a href="#" <%=menu[152] %> onclick="SetFrame('cqdtj','Stat/StExtServices.aspx','超期单统计');">超期单统计</a>
		        <a href="#" <%=menu[153] %> onclick="SetFrame('fwddt','Stat/StSerMap.aspx','服务单地图');">服务单地图</a>
		        <a href="#" onclick="SetFrame('fubjhzb','Stat/StSerMaterial.aspx','服务备件汇总表');">服务备件汇总表</a>
		        <a href="#" onclick="SetFrame('bjmxhzb','Stat/MaterialDe.aspx','备件明细汇总表');">备件明细汇总表</a>
		        <a href="#" onclick="SetFrame('bjltmxb','Stat/StSerBroughtBack.aspx','备件领退明细表');">备件领退明细表</a>
		        <a href="#" onclick="SetFrame('bjltmxbpm','Stat/MaterialDeByGoods.aspx','备件(仓库)汇总表');">备件(仓库)汇总表</a>
		        <a href="#" onclick="SetFrame('bjltmxbywy','Stat/MaterialDeByAppOperator.aspx','备件(领料人)汇总表');">备件(领料人)汇总表</a>
		        <a href="#" <%=menu[151] %> onclick="SetFrame('jsyhf','Stat/TecDeduct.aspx','回访统计');">回访统计</a>
		        <a href="#" onclick="SetFrame('hfmxb','Stat/StSeeBackDe.aspx','回访明细表');">回访明细表</a>
		        <div class="KsLine"></div>
		        <a href="#" onclick="SetFrame('fwhtxsb','Stat/stSerContract.aspx','维保合同序时簿');">维保合同序时簿</a>
		        <a href="#" onclick="SetFrame('wbjqwxcb','Stat/StSerWarranty.aspx','维保期内机器维修成本');">维保期内机器维修成本</a>
		        <a href="#" onclick="SetFrame('wbwjqwxcb','Stat/StSerOutWarranty.aspx','维保期外机器维修成本');">维保期外机器维修成本</a>
		        <a href="#" onclick="SetFrame('fwcb','Stat/StSerCosts.aspx','服务成本');">服务成本</a>
		        <div class="KsLine"></div>
		        <a href="#" <%=menu[154] %> onclick="SetFrame('xpfbtb','Stat/StRepairDis.aspx','修品分布图表');">修品分布图表</a>
		        <a href="#" <%=menu[155] %> onclick="SetFrame('gzfbtb','Stat/StFaultDis.aspx','故障分布图表');">故障分布图表</a>
		        <a href="#" <%=menu[155] %> onclick="SetFrame('gztjb','Stat/stSerTakeSteps.aspx','故障统计表');">故障统计表</a>
		        <a href="#" <%=menu[155] %> onclick="SetFrame('clcsfbtb','Stat/StTakeStepsDis.aspx','处理措施分布图');">处理措施分布图</a>
		        <div class="KsLine"></div>
		        <a href="#" <%=menu[151] %> onclick="SetFrame('jsyfxhzb','Stat/StTecbRepair.aspx','技术员返修汇总表');">技术员返修汇总表</a>
		        <a href="#" <%=menu[151] %> onclick="SetFrame('jsycfwxl','Stat/StTecRepairRate.aspx','技术员重复维修率');">技术员重复维修率</a>
	        </div>
        </div>
        <div id="menu_s_sub_16" class="KsMenu" style="height:42px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:40px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" <%=menu[156] %> onclick="SetFrame('jsdhzb','Stat/StLeaseCharge.aspx','结算单汇总表');">结算单汇总表</a>
		        <a href="#" <%=menu[157] %> onclick="SetFrame('jsdmxb','Stat/StLeaseChargeDe.aspx','结算单明细表');">结算单明细表</a>
	        </div>
        </div>
        <div id="menu_s_sub_17" class="KsMenu" style="height:63px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:60px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
	            <a href="#" <%=menu[158] %> onclick="SetFrame('khzzqk','Stat/StCustomerAdd.aspx','客户增长情况');">客户增长情况</a>
	            <a href="#" <%=menu[159] %> onclick="SetFrame('khjzph','Stat/StCusValueList.aspx','客户价值排行');">客户价值排行</a>
	            <a href="#" <%=menu[159] %> onclick="SetFrame('khgzhz','Stat/StCusTrack.aspx','客户跟踪汇总');">客户跟踪汇总</a>
	        </div>
        </div>
        <div id="menu_s_sub_18" class="KsMenu" style="height:256px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:250px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" <%=menu[160] %> onclick="SetFrame('szrbb','Stat/StDayInTo.aspx','收支日报表');">收支日报表</a>
		        <a href="#" <%=menu[161] %> onclick="SetFrame('szybb','Stat/StMonthInTo.aspx','收支月报表');">收支月报表</a>
		        <div class="KsLine"></div>
		        <a href="#" <%=menu[162] %> onclick="SetFrame('skdhzb','Stat/StIncome.aspx','收款单汇总表');">收款单汇总表</a>
		        <a href="#" <%=menu[163] %> onclick="SetFrame('skdmxb','Stat/StIncomeDe.aspx','收款单明细表');">收款单明细表</a>
		        <div class="KsLine"></div>
		        <a href="#" <%=menu[164] %> onclick="SetFrame('fkdhzb','Stat/StPay.aspx','付款单汇总表');">付款单汇总表</a>
		        <a href="#" <%=menu[165] %> onclick="SetFrame('fkdmxb','Stat/StPayDe.aspx','付款单明细表');">付款单明细表</a>
		        <div class="KsLine"></div>
		        <a href="#" <%=menu[166] %> onclick="SetFrame('ysyfhzb','Stat/StArr.aspx','应收应付汇总表');">应收应付汇总表</a>
		        <a href="#" <%=menu[167] %> onclick="SetFrame('ysyfmxb','Stat/StArrDe.aspx','应收应付明细表');">应收应付明细表</a>
		        <a href="#" <%=menu[168] %> onclick="SetFrame('ysyfzlb','Stat/StArrAge.aspx','应收应付账龄表');">应收应付账龄表</a>
		        <a href="#" <%=menu[169] %> onclick="SetFrame('ysyfhzb','Stat/StArrCanl.aspx','应收应付坏账表');">应收应付坏账表</a>
		        <div class="KsLine"></div>
		        <a href="#" <%=menu[169] %> onclick="SetFrame('bxhzb','Stat/ExpenseDe.aspx','报销汇总表');">报销汇总表</a>
		        <a href="#" <%=menu[169] %> onclick="SetFrame('bxmxb','Stat/ExpenseDetail.aspx','报销明细表');">报销明细表</a>
	        </div>
        </div>
        <div id="menu_s_sub_19" class="KsMenu" style="height:168px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:160px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" <%=menu[170] %> onclick="SetFrame('ywqsfx','Stat/AnCurrent.aspx','业务趋势分析');">业务趋势分析</a>
		        <a href="#" <%=menu[171] %> onclick="SetFrame('gzjdfx','Stat/AnProgress.aspx','工作进度分析');">工作进度分析</a>
		        <a href="#" <%=menu[172] %> onclick="SetFrame('skfsfx','Stat/AnIncomeType.aspx','收款方式分析');">收款方式分析</a>
		        <a href="#" <%=menu[173] %> onclick="SetFrame('qxyyfx','Stat/AnCancelReason.aspx','取消原因分析');">取消原因分析</a>
		        <a href="#" <%=menu[174] %> onclick="SetFrame('fwlbfx','Stat/AnOperationType.aspx','服务类别分析');">服务类别分析</a>
		        <a href="#" <%=menu[175] %> onclick="SetFrame('slfsfx','Stat/AnTakeType.aspx','受理方式分析');">受理方式分析</a>
		        <a href="#" <%=menu[176] %> onclick="SetFrame('khlyfx','Stat/AnSatisCusFrom.aspx','客户来源分析');">客户来源分析</a>
		        <a href="#" <%=menu[177] %> onclick="SetFrame('khlbfx','Stat/AnSatisCusClass.aspx','客户类别分析');">客户类别分析</a>
	        </div>
        </div>
    </div>
    
    <div id="menu_s_12" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:421px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_12s" class="KsMenu2" style="height:421px;">
            <a href="#" <%=menu[178] %> onclick="ShowDialog(660, 400, 'Basic/BaseInfo.aspx', '基础信息');">基础信息</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[179] %> onclick="SetFrame('wdml','Basic/BranchAdm.aspx','网点目录');">网点目录</a>
			<a href="#" <%=menu[180] %> onclick="ShowDialog(600, 380, 'Basic/StaffDeptAdm.aspx', '员工部门');">员工部门</a>
			<a href="#" <%=menu[180] %> onclick="SetFrame('ygml','Basic/StaffAdm.aspx','员工目录');">员工目录</a>
			<a href="#" <%=menu[181] %> onclick="SetFrame('ckml','Basic/StockListAdm.aspx','仓库目录');">仓库目录</a>
			<a href="#" <%=menu[182] %> onclick="ShowDialog(600, 380, 'Basic/SupplierClassAdm.aspx', '厂商分类');">厂商分类</a>
			<a href="#" <%=menu[183] %> onclick="SetFrame('wlcs','Basic/SupplierAdm.aspx','往来厂商');">往来厂商</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[184] %> onclick="ShowDialog(600, 380, 'Basic/ProductBrandAdm.aspx', '机器品牌');">机器品牌</a>
		    <a href="#" <%=menu[185] %> onclick="ShowDialog(600, 380, 'Basic/ProductClassAdm.aspx', '机器类别');">机器类别</a>
		    <a href="#" <%=menu[186] %> onclick="ShowDialog(600, 380, 'Basic/ProductModelAdm.aspx', '机器型号');">机器型号</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[187] %> onclick="ShowDialog(600, 380, 'Basic/RepairClassAdm.aspx', '维修类别');">维修类别</a>
	        <a href="#" <%=menu[188] %> onclick="ShowDialog(600, 380, 'Basic/TroubleClassAdm.aspx', '故障分类');">故障分类</a>
	        <a href="#" <%=menu[189] %> onclick="ShowDialog(600, 380, 'Basic/TroubleReasonAdm.aspx', '故障原因');">故障原因</a>
	        <a href="#" <%=menu[190] %> onclick="SetFrame('cjgz','Basic/TroubleListAdm.aspx','常见故障');" onmouseover="Sethiddensub('menu_s_sub_20');">常见故障</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[191] %> id="row20" onmouseover="Setmenu_sub('<%=modulh_s[19] %>','158','menu_s_sub_20');">服务信息</a>
			<a href="#" <%=menu[192] %> onclick="ShowDialog(600, 380, 'Basic/DeviceConfItem.aspx', '机器配置项');" onmouseover="Sethiddensub('menu_s_sub_20');">机器配置项</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[193] %> onclick="ShowDialog(600, 380, 'Basic/AccountAdm.aspx', '收支帐户');">收支帐户</a>
			<a href="#" <%=menu[194] %> onclick="ShowDialog(600, 380, 'Basic/ChargeItemAdm.aspx', '收支项目');">收支项目</a>
			<a href="#" <%=menu[195] %> onclick="ShowDialog(600, 380, 'Basic/ExpenseItemAdm.aspx', '报销项目');">报销项目</a>
			<a href="#" <%=menu[196] %> onclick="ShowDialog(600, 380, 'Basic/ShippingStyleAdm.aspx', '货运方式');">货运方式</a>
		</div>
		<div id="menu_s_sub_20" class="KsMenu" style="height:169px;z-index:9999;">
	    <iframe style="position: absolute;z-index: -2;height:160px;width:162px;" frameborder="0"></iframe>
        <div class="KsMenu2">
		    <a href="#" <%=menu[197] %> onclick="ShowDialog(600, 380, 'Basic/ServicesTypeAdm.aspx', '服务类别');">服务类别</a>
	        <a href="#" <%=menu[198] %> onclick="ShowDialog(600, 380, 'Basic/WarrantyAdm.aspx', '保修情况');">保修情况</a>
	        <a href="#" <%=menu[199] %> onclick="ShowDialog(600, 380, 'Basic/ServiceLevel.aspx', '服务级别');">服务级别</a>
	        <div class="KsLine"></div>
	        <a href="#" <%=menu[200] %> onclick="ShowDialog(600, 380, 'Basic/ServicesItemAdm.aspx', '服务项目');">服务项目</a>
            <a href="#" <%=menu[201] %> onclick="ShowDialog(600, 380, 'Basic/OfferItemAdm.aspx', '报价项目');">报价项目</a>
            <a href="#" <%=menu[202] %> onclick="ShowDialog(600, 380, 'Basic/GoodsGone.aspx', '物品去向');">物品去向</a>
            <a href="#" <%=menu[203] %> onclick="SetFrame('hfnr','Basic/VisitContent.aspx', '回访内容');">回访内容</a>
            <a href="#" <%=menu[204] %> onclick="ShowDialog(600, 380, 'Basic/ExtendedSet.aspx', '超期单设置');">超期单设置</a>
	    </div>
    </div>
    </div>
    
    <div id="menu_s_13" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:165px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_13s" class="KsMenu2">
			<a href="#" <%=menu[205] %> onclick="ShowDialog(600, 190, 'System/Starting.aspx', '系统初始化');" >系统初始化</a>
			<a href="#" <%=menu[205] %> onclick="ShowDialog(620, 456, 'System/Setting.aspx', '系统设置');">系统设置</a>
			<a href="#" <%=menu[205] %> onclick="ShowDialog(650, 143, 'System/BackupPlan.aspx', '备份计划');" >备份计划</a>
			<a href="#" <%=menu[205] %> onclick="SetFrame('xtrz','System/SysLog.aspx','系统日志');">系统日志</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[205] %> onclick="SetFrame('qxgl','System/RightAdm.aspx','权限管理');">权限管理</a>
			<a href="#" <%=menu[205] %> onclick="SetFrame('yygl','System/UserManage.aspx','用户管理');">用户管理</a>
			<a href="#" onclick="ShowDialog(600, 190, 'System/UserPwd.aspx', '修改密码');">修改密码</a>
			<a href="#" onclick="ChkExit();">退出系统</a>
		</div>
    </div>
    
    <div id="menu_s_14" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:<%=toolHeight %>px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_15s" class="KsMenu2" >
			<a href="#" <%=menu[205] %> onclick="ShowDialog(800,520,'Tool/Layout.aspx','表格布局');">表格布局</a>
			<a href="#" onclick="ShowDialog(640, 480, 'Tool/ToolBar.aspx', '工具栏定义');">工具栏定义</a>
			<div class="KsLine"></div>
			<a href="#" onclick="ShowDialog(600, 350, 'Tool/SmsAdm.aspx','短信模块');">短信模块</a>
			<a href="#" onclick="ShowDialog(600, 310, 'Tool/Printtmp.aspx', '打印模板');">打印模板</a>
			<div class="KsLine"></div>
			<a href="#"  onclick="ShowDialog(600, 310, 'Tool/OnlineList.aspx', '在线用户');">在线用户</a>
	  <a <%=menu[205] %> href="#" onclick="ShowDialog(800, 500, 'CDIY/UserInter.aspx', '员工打分');">员工打分</a>
		 <a <%=menu[205] %> href="../CodingPages/Cd_ProType/ProTypeList.aspx" target="_blank">产品仓库</a>
            	</div>
    </div>
    
    <div id="menu_s_15" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:125px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_14s" class="KsMenu2">
			<%--<a onclick="Sethidden1();" href="http://www.differsoft.com" target="_blank">官方网站</a>
			<a onclick="Sethidden1();" href="http://bbs.differsoft.com/" target="_blank">意见反馈</a>
			<a onclick="Sethidden1();" href="http://www.differsoft.com/production/files/Prodoc/WTnet_IT_Help.mht" target="_blank">在线帮助</a>--%>
			<div class="KsLine"></div>
			<%--<a <%=menu[205] %> href="#" onclick="ShowDialog(500, 208, 'System/Update.aspx', '在线升级');">在线升级</a>
			<a href="#" <%=menu[205] %> onclick="ShowDialog(600, 290, 'System/SoftReg.aspx', '注册');" >软件注册</a>
			<a onclick="ShowDialog(500, 228, 'About.aspx', '关于');" href="#">关于</a>--%>
          </div>
    </div>    
</div>
<div id="tool" onclick="Sethidden1();" style="overflow:hidden;">
<div class="tool_d">
    <ul>
     <asp:Repeater ID="rptool" runat="server" EnableViewState="false">
         <ItemTemplate>
            <li><a href="#" style="background:url(../Public/Images/tool/<%#Eval("FieldValue") %>) no-repeat top center;" onclick="<%#Eval("Command") %>"><%#Eval("FieldText") %></a></li>
        </ItemTemplate>
     </asp:Repeater>
	</ul>
</div>
</div>
<div id="fcolor" class="fcolor" style="display:none;"></div>
<!--多窗口列表-->
<div id="mytitle" onclick="Sethidden1();">
<table style="border:0px;width:100%;height:100%" cellspacing="0" cellpadding="0"><tr>
<td class="FootC"><div id="WinFinfo"><div id="WinList"></div></div></td>
<td id="FScro" style="display:none;">
<div id="F1" onmousedown="ChangeWList('left')" onmouseup="ChangeWList('out')"><img src="../Public/Images/left.png"/></div>
<div id="F2" onmousedown="ChangeWList('right')" onmouseup="ChangeWList('out')"><img src="../Public/Images/right.png"/></div>
</td>
</tr></table>
</div>
<div id="WinPage"></div>
</div>

<!--加载等待窗口-->
<div id='Loading' style="position:absolute;z-index:1000;top:0px;left:0px;width:100%;height:100%;background:#fff;text-align:center"><img src='../Public/images/loading.gif' style='margin-top:150px'/></div>

<div id="divDialog">
    <div id="divTitle">
    	<div id="divIco"><div id="divTitleName"></div></div>
     	<div id="divClose" onclick="CloseDialog();">
     		<img alt="关闭" src="../Public/Images/close.gif" style="cursor: default;" title="关闭" />
     	</div>
     	<div style=" clear:both;"></div>
    </div>
	<iframe id="iframeDialog" name="iframeDialog" scrolling="no"  frameborder="0"></iframe>  
</div>
<div id="divBackground">
    <iframe height="100%" name="iframeBackground" src="about:blank" width="100%"></iframe>
</div>

<div id="divDialog1">
    <div id="divTitle1">
    <div style="" id="divIco1"><div id="divTitleName1"></div></div>
     	<div id="divClose1" onclick="CloseDialog1();">
     		<img alt="关闭" src="../Public/Images/close.gif" style="cursor: default;" title="关闭" />
     	</div>
     	<div style=" clear:both;"></div>
    </div>
    <iframe id="iframeDialog1" name="iframeDialog1" scrolling="no" frameborder="0"></iframe>  		
</div>
<div id="divBackground1">
    <iframe height="100%" name="iframeBackground" src="about:blank" width="100%"></iframe>
</div>

<div id="divDialog2">
    <div id="divTitle2">
    <div id="divIco2"><div id="divTitleName2"></div></div>
 	    <div id="divClose2" onclick="CloseDialog2();">
 		    <img alt="关闭" src="../Public/Images/close.gif" style="cursor: default;" title="关闭" />
 	    </div>
 	    <div style=" clear:both;"></div>
    </div>
    <iframe id="iframeDialog2" name="iframeDialog2" scrolling="no" frameborder="0"></iframe>  		
</div>
<div id="divBackground2">
    <iframe height="100%" name="iframeBackground" src="about:blank" width="100%"></iframe>
</div>

<div id="divDialog3">
    <div id="divTitle3">
    <div id="divIco3"><div id="divTitleName3"></div></div>
 	    <div id="divClose3" onclick="CloseDialog3();">
 		    <img alt="关闭" src="../Public/Images/close.gif" style="cursor: default;" title="关闭" />
 	    </div>
 	    <div style=" clear:both;"></div>
    </div>
    <iframe id="iframeDialog3" name="iframeDialog3" scrolling="no" frameborder="0"></iframe>  		
</div>
<div id="divBackground3">
    <iframe height="100%" name="iframeBackground" src="about:blank" width="100%"></iframe>
</div>

<div id="test">
    <img src="../Public/Images/load.gif" alt="loading" />
    <span style="color:#0000ff">正处理数据,请稍候...</span>
    <a id="btntest" href="#" style="padding-left:5px; color:#000;">取消</a>
</div>
</form>
</body>
</html>
<script language="javascript" type="text/javascript">
function RefreshOLData()
{
    document.getElementById("btnRefreshOnline").click();
}

</script>
