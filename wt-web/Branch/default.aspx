<%@ page language="C#"  CodeFile="default.aspx.cs"     autoeventwireup="true" inherits="Branch_Default" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title><%=strTitle %></title>
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
}
    
var fmenu=false;
function ChkExit()
{
    if(confirm("确认要退出网点系统吗？"))
    {
        document.getElementById("btnExit").click();
    }
}

function ChkClose()
{
    event.returnValue="";
}
/*-----菜单设置-----------*/
function ClickSetmenu(mleft,mheight,id)
{
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
        i++
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
</script>
</head>
<body style="overflow:hidden" scroll="no" onresize="ChangeWin()">
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
        </asp:UpdatePanel></span>
<div id="dtop">
<div id="menu">
    <ul id="menu_par">
        <li id="sptitle"></li>
        <li <%=moduln[0] %>><a href="#" onclick="<%=module[0] %>ClickSetmenu('<%=modulm[0] %>','<%=modulh[0] %>','menu_s_1');" onmouseover="<%=module[0] %>Setmenu('<%=modulm[0] %>','<%=modulh[0] %>','menu_s_1');">仓库管理</a></li><li <%=moduln[1] %>><a href="#" onclick="<%=module[1] %>ClickSetmenu('<%=modulm[1] %>','<%=modulh[1] %>','menu_s_15');" onmouseover="<%=module[1] %>Setmenu('<%=modulm[1] %>','<%=modulh[1] %>','menu_s_15');">采购管理</a></li><li <%=moduln[2] %>><a href="#" onclick="<%=module[2] %>ClickSetmenu('<%=modulm[2] %>','<%=modulh[2] %>','menu_s_2');" onmouseover="<%=module[2] %>Setmenu('<%=modulm[2] %>','<%=modulh[2] %>','menu_s_2');">销售管理</a></li><li <%=moduln[3] %>><a href="#" onclick="<%=module[3] %>ClickSetmenu('<%=modulm[3] %>','<%=modulh[3] %>','menu_s_3');" onmouseover="<%=module[3] %>Setmenu('<%=modulm[3] %>','<%=modulh[3] %>','menu_s_3');">服务管理</a></li><li <%=moduln[4] %>><a style="line-height:23px;" href="#" onclick="<%=module[4] %>ClickSetmenu('<%=modulm[4] %>','<%=modulh[4] %>','menu_s_4');" onmouseover="<%=module[4] %>Setmenu('<%=modulm[4] %>','<%=modulh[4] %>','menu_s_4');">租赁/全保</a></li><li <%=moduln[5] %>><a href="#" onclick="<%=module[5] %>ClickSetmenu('<%=modulm[5] %>','<%=modulh[5] %>','menu_s_5');" onmouseover="<%=module[5] %>Setmenu('<%=modulm[5] %>','<%=modulh[5] %>','menu_s_5');">客户关系</a></li><li <%=moduln[6] %>><a href="#" onclick="<%=module[6] %>ClickSetmenu('<%=modulm[6] %>','<%=modulh[6] %>','menu_s_6');" onmouseover="<%=module[6] %>Setmenu('<%=modulm[6] %>','<%=modulh[6] %>','menu_s_6');">帐款管理</a></li><li <%=moduln[7] %>><a href="#" onclick="<%=module[7] %>ClickSetmenu('<%=modulm[7] %>','<%=modulh[7] %>','menu_s_7');" onmouseover="<%=module[7] %>Setmenu('<%=modulm[7] %>','<%=modulh[7] %>','menu_s_7');">收发管理</a></li><li <%=moduln[8] %>><a href="#" onclick="<%=module[8] %>ClickSetmenu('<%=modulm[8] %>','<%=modulh[8] %>','menu_s_8');" onmouseover="<%=module[8] %>Setmenu('<%=modulm[8] %>','<%=modulh[8] %>','menu_s_8');" style="width:55px; line-height:23px;">办公OA</a></li><li <%=moduln[9] %>><a href="#" onclick="<%=module[9] %>ClickSetmenu('<%=modulm[9] %>','<%=modulh[9] %>','menu_s_9');" onmouseover="<%=module[9] %>Setmenu('<%=modulm[9] %>','<%=modulh[9] %>','menu_s_9');">期初录入</a></li><li <%=moduln[10] %>><a href="#" onclick="<%=module[10] %>ClickSetmenu('<%=modulm[10] %>','<%=modulh[10] %>','menu_s_10');" onmouseover="<%=module[10] %>Setmenu('<%=modulm[10] %>','<%=modulh[10] %>','menu_s_10');">统计分析</a></li><li <%=moduln[11] %>><a href="#" onclick="<%=module[11] %>ClickSetmenu('<%=modulm[11] %>','<%=modulh[11] %>','menu_s_11');" onmouseover="<%=module[11] %>Setmenu('<%=modulm[11] %>','<%=modulh[11] %>','menu_s_11');">基础数据</a></li><li><a href="#" onclick="ClickSetmenu('<%=modulm[12] %>','<%=modulh[12] %>','menu_s_12');" onmouseover="Setmenu('<%=modulm[12] %>','<%=modulh[12] %>','menu_s_12');">系统维护</a></li><li><a href="#" onclick="ClickSetmenu('<%=modulm[13] %>','<%=modulh[13] %>','menu_s_13');" onmouseover="Setmenu('<%=modulm[13] %>','<%=modulh[13] %>','menu_s_13');" style="width:35px;">工具</a></li><li><a href="#" onclick="ClickSetmenu('<%=modulm[14] %>','<%=modulh[14] %>','menu_s_14');" onmouseover="Setmenu('<%=modulm[14] %>','<%=modulh[14] %>','menu_s_14');" style="width:35px;">帮助</a></li><li><a href ="http://www.18bg.com" target ="_blank">18云办公</a></li>
    </ul>
    
    <div id="menu_s_1" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:252px;width:162px;" frameborder="0"></iframe>
         <div id="menu_s_1s" class="KsMenu2">
            <a href="#" onclick="SetFrame('dqkc','Stock/StockAdm.aspx','当前库存');">当前库存</a>
            <a href="#" onclick="SetFrame('fpkc','Stock/StockrAdm.aspx','废品库存');">废品库存</a>
            <a href="#" onclick="SetFrame('fckc','Stock/DeptStock.aspx','分仓库存');">分仓库存</a>
            <a href="#" onclick="SetFrame('xlhk','Stock/SNAdm.aspx','序列号库');">序列号库</a>
            <div class="KsLine"></div>
            <a href="#" onclick="SetFrame('qtrk','Stock/StockIn.aspx','其他入库');">其他入库</a>			
            <a href="#" onclick="SetFrame('qtck','Stock/StockOut.aspx','其他出库');">其他出库</a>
            <a href="#" onclick="SetFrame('llkd','Stock/BroughtBack.aspx','领退开单');" onmouseover="Sethiddensub('menu_s_sub_20');" >领退开单</a>
            <div class="KsLine"></div>
            <a href="#" id="row21" onmouseover="Sethiddensub('menu_s_sub_19');Setmenu_sub('150','158','menu_s_sub_20');">内部调拨</a>
            <a href="#" id="row20" onmouseover="Sethiddensub('menu_s_sub_20');Setmenu_sub('170','158','menu_s_sub_19');">网点调拨</a>
            <div class="KsLine"></div>
            <a href="#" id="row1" onmouseover="Setmenu_sub('192','158','menu_s_sub_1');Sethiddensub('menu_s_sub_19');">借出管理</a>
			<a href="#" id="row2" onmouseover="Setmenu_sub('213','158','menu_s_sub_2');">仓库业务</a>
			<a href="#" id="row3" onmouseover="Setmenu_sub('234','158','menu_s_sub_3');">单据查询</a>
		</div>
        <div id="menu_s_sub_19" class="KsMenu" style="height:84px;z-index:9999;">
		    <iframe style="position: absolute;z-index: -2;height:80px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
                <a href="#" onclick="SetFrame('dbsq','Stock/AllocateApp.aspx','调拨申请');">调拨申请</a>
                <a href="#" onclick="SetFrame('dbsh','Stock/AllocateAppChk.aspx','调拨审核');">调拨审核</a>
                <a href="#" onclick="SetFrame('dbfh','Stock/AllocateRec.aspx','调拨发货');">调拨发货</a>
                <a href="#" onclick="SetFrame('dbqs','Stock/AllocateSigned.aspx','调拨签收');">调拨签收</a>
		    </div>
		</div>
		<div id="menu_s_sub_20" class="KsMenu" style="height:63px;z-index:9999;">
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
		        <a href="#" onclick="SetFrame('jckd','Stock/LendingAdd.aspx','借出开单');">借出开单</a>
                <a href="#" onclick="SetFrame('jccx','Stock/SchLendingReturn.aspx','借出查询');">借出查询</a>
		    </div>
		</div>
		<div id="menu_s_sub_2" class="KsMenu" style="height:63px;z-index:9999;">
		    <iframe style="position: absolute;z-index: -2;height:60px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" onclick="SetFrame('cxzz','Stock/DisBiling.aspx','拆装开单');">拆装开单</a>
                <a href="#" onclick="SetFrame('tjkd','Stock/Regulate.aspx','调价开单');">调价开单</a>
                <a href="#" onclick="SetFrame('pdkd','Stock/StockCheck.aspx','盘点开单');">盘点开单</a>
		    </div>
		</div>
		<div id="menu_s_sub_3" class="KsMenu" style="height:168px;z-index:9999;">
		    <iframe style="position: absolute;z-index: -2;height:160px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" onclick="SetFrame('rkdcx','Stock/SchStockIn.aspx','入库单查询');">入库单查询</a>
		        <a href="#" onclick="SetFrame('ckdcx','Stock/SchStockOut.aspx','出库单查询');">出库单查询</a>
				<a href="#" onclick="SetFrame('ltdcx','Stock/SchBroughtBack.aspx','领退单查询');">领退单查询</a>
				<a href="#" onclick="SetFrame('dbdcx','Stock/SchInnerAllocate.aspx','内部调拨单查询');">内部调拨单查询</a>
				<a href="#" onclick="SetFrame('dbdcx','Stock/SchAllocate.aspx','网点调拨单查询');">网点调拨单查询</a>
				<a href="#" onclick="SetFrame('czdcx','Stock/SchDisBiling.aspx','拆装单查询');">拆装单查询</a>
				<a href="#" onclick="SetFrame('tjdcx','Stock/SchRegulate.aspx','调价单查询');">调价单查询</a>
				<a href="#" onclick="SetFrame('pddcx','Stock/SchStockCheck.aspx','盘点单查询');">盘点单查询</a>
			</div>
		</div>
    </div>
    <div id="menu_s_15" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:105px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_15s" class="KsMenu2">
			<a href="#" <%=menu[28] %> onclick="SetFrame('cgkd','Purchase/PurchaseAdd.aspx', '采购开单');">采购开单</a>
			<a href="#" <%=menu[29] %> onclick="SetFrame('cgth','Purchase/PurReturn.aspx', '采购退货');">采购退货</a>
			<a href="#" <%=menu[30] %> onclick="SetFrame('cgdcx','Purchase/SchPurchase.aspx','采购单查询');">采购单查询</a>
			<div class="KsLine"></div>
            <a href="#" <%=menu[31] %> onclick="SetFrame('cgdd','Purchase/PurPlanAdd.aspx', '采购订单');">采购订单</a>
			<a href="#" <%=menu[32] %> onclick="SetFrame('cgddcx','Purchase/SchPurPlan.aspx','采购订单查询');">采购订单查询</a>
		</div>
    </div>
    <div id="menu_s_2" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:106px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_2s" class="KsMenu2">
			<a href="#" onclick="SetFrame('xskd','Sell/SellAdd.aspx', '销售开单');">销售开单</a>
			<a href="#" onclick="SetFrame('xsth','Sell/SellReturn.aspx', '销售退货');">销售退货</a>
			<a href="#" onclick="SetFrame('xsdcx','Sell/SchSell.aspx','销售单查询');">销售单查询</a>
			<div class="KsLine"></div>
            <a href="#" onclick="SetFrame('xsdd','Sell/SellPlanAdd.aspx', '销售订单');">销售订单</a>
			<a href="#" onclick="SetFrame('xsddcx','Sell/SchSellPlan.aspx','销售订单查询');">销售订单查询</a>
		</div>
    </div>
    
    <div id="menu_s_3" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:129px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_3s" class="KsMenu2">
            <a href="#" onclick="SetFrame('sqqr','Services/ServicesNet.aspx','报修审核');">报修审核</a>
            <a href="#" onclick="SetFrame('sqqr','Services/ServicesConf.aspx','送修确认');">送修确认</a>
			<div class="KsLine"></div>
			<a href="#" onclick="SetFrame('fwzx','Services/ServicesAllot.aspx','服务中心')" onmouseover="Sethiddensub('menu_s_sub_4');">服务中心</a>
            <div class="KsLine"></div>
            <a href="#" id="row4" onmouseover="Setmenu_sub('42','158','menu_s_sub_4');">送修管理</a>
			<a href="#" onclick="SetFrame('wgjs','Services/ServicesBln.aspx','完工结算');" onmouseover="Sethiddensub('menu_s_sub_4');">完工结算</a>
            <div class="KsLine"></div>
            <a href="#" onclick="SetFrame('fwdcx','Services/SchServices.aspx','服务单查询');">服务单查询</a>
            <a href="#" onclick="SetFrame('xxfwdcx','Services/SchFullServices.aspx','详细服务单');">详细服务单</a>
	    </div>
	    <div id="menu_s_sub_4" class="KsMenu" style="height:63px;z-index:9999;">
		    <iframe style="position: absolute;z-index: -2;height:63px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" onclick="SetFrame('sxfh','Services/ServicesSnd.aspx','送修发货');">送修发货</a>
		        <a href="#" onclick="SetFrame('shjs','Services/ServicesRcv.aspx','收货结算');">收货结算</a>
		        <a href="#" onclick="SetFrame('lssx','Services/HistorySnd.aspx','历史送修');">历史送修</a>
	        </div>
        </div>
    </div>
    <div id="menu_s_4" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:150px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_4s" class="KsMenu2">
			<a href="#" onclick="SetFrame('xjyw','Lease/LeaseAdd.aspx', '新建业务');">新建业务</a>
			<a href="#" onclick="SetFrame('ywsh','Lease/LeaseChk.aspx', '业务审核');">业务审核</a>
			<div class="KsLine"></div>			
			<a href="#" onclick="SetFrame('cbdd','Lease/MeterReading.aspx', '抄表登记');">抄表登记</a>
			<a href="#" onclick="SetFrame('sbgh','Lease/ChangeMachine.aspx', '设备退换');">设备退换</a>
			<a href="#" onclick="SetFrame('htjy','Lease/Release.aspx', '合同解约');">合同解约</a>
			<div class="KsLine"></div>
			<a href="#" onclick="SetFrame('jssh','Lease/Settlement.aspx', '结算审核');">结算审核</a>
			<div class="KsLine"></div>
			<a href="#" onclick="SetFrame('ywcx','Lease/SchLease.aspx','业务查询');">业务查询</a>
		</div>
    </div>
    <div id="menu_s_5" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:148px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_5s" class="KsMenu2">
			<a href="#" onclick="SetFrame('khda','Customer/CusListAdm.aspx','客户档案');">客户档案</a>
			<a href="#" onclick="SetFrame('jqda','Customer/DeviceListAdm.aspx','机器档案');">机器档案</a>
			<div class="KsLine"></div>
			<a href="#" onclick="SetFrame('fwht','Customer/MaintenanceContract.aspx','服务合同');">服务合同</a>
			<a href="#" onclick="SetFrame('bypg','Customer/MaintenanceAllot.aspx','保养派工');">保养派工</a>
			<a href="#" onclick="SetFrame('khgz','Customer/CustomerTrack.aspx','客户跟踪');">客户跟踪</a>
			<a href="#" onclick="SetFrame('hcgz','Customer/ConsumablesTrack.aspx','耗材跟踪');">耗材跟踪</a>
			<a href="#" onclick="SetFrame('tscl','Customer/ComplaintAdm.aspx','投诉管理');">投诉管理</a>
		</div>
    </div>
    
    <div id="menu_s_6" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:128px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_6s" class="KsMenu2">
            <a href="#" id="row5" onmouseover="Setmenu_sub('0','158','menu_s_sub_5');">收款开单</a>
            <a href="#" id="row6" onmouseover="Setmenu_sub('20','158','menu_s_sub_6');">付款开单</a>
            <a href="#" onclick="SetFrame('sfkcx','Financial/IncomeAdm.aspx','收付款查询');" onmouseover="Sethiddensub('menu_s_sub_6');">收付款查询</a>
            <div class="KsLine"></div>
            <a href="#" onclick="SetFrame('ysyf','Financial/ArrearageAdm.aspx','应收应付');" onmouseover="Sethiddensub('menu_s_sub_7');">应收应付</a>
            <div class="KsLine"></div>
            <a href="#" id="row7"  onmouseover="Setmenu_sub('84','158','menu_s_sub_7');">现金银行</a>
            <a href="#" id="row8" onmouseover="Sethiddensub('menu_s_sub_7');Setmenu_sub('105','158','menu_s_sub_8');">费用报销</a>
		</div>
		<div id="menu_s_sub_5" class="KsMenu" style="height:63px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:60px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
	            <a href="#" onclick="SetFrame('sysk','Financial/IncomeAdd.aspx', '收应收款');">收应收款</a>
	            <a href="#" onclick="SetFrame('sysk2','Financial/AdvanceInAdd.aspx', '收预收款');">收预收款</a>
	            <a href="#" onclick="SetFrame('qtsk','Financial/OtherInAdd.aspx', '其他收款');">其他收款</a>
            </div>
        </div>
        <div id="menu_s_sub_6" class="KsMenu" style="height:63px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:60px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
	            <a href="#" onclick="SetFrame('fyfk','Financial/PaymentAdd.aspx','付应付款');">付应付款</a>
	            <a href="#" onclick="SetFrame('fyfk2','Financial/AdvancePayAdd.aspx','付预付款');">付预付款</a>
	            <a href="#" onclick="SetFrame('qtfk','Financial/OtherPayAdd.aspx','其他付款');">其他付款</a>
            </div>
        </div>
        <div id="menu_s_sub_7" class="KsMenu" style="height:42px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:40px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
                <a href="#" onclick="SetFrame('zhzz','Financial/Transfer.aspx','帐户转账');">帐户转账</a>
	            <a href="#" onclick="SetFrame('zhhz','Financial/IncomeBank.aspx','帐户汇总');">帐户汇总</a>
            </div>
        </div>
        
        <div id="menu_s_sub_8" class="KsMenu" style="height:106px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:80px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
                <a href="#" onclick="SetFrame('bxsq','Financial/Expense.aspx','报销申请');">报销申请</a>
	            <a href="#" onclick="SetFrame('zgsh','Financial/ChkExpense.aspx','主管审核');">主管审核</a>
	            <a href="#" onclick="SetFrame('kxff','Financial/PayExpense.aspx','款项发放');">款项发放</a>
	            <div class="KsLine"></div>
	            <a href="#" onclick="SetFrame('bxcx','Financial/SchExpense.aspx','报销查询');">报销查询</a>
	            <a href="#" onclick="SetFrame('bxcxmx','Financial/SchFullExpense.aspx','报销明细');">报销明细</a>
            </div>
        </div>
    </div>
    
    <div id="menu_s_7" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:80px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_7s" class="KsMenu2">
			<a href="#" onclick="SetFrame('xjfh','Receive/SndNew.aspx', '新建发货');">新建发货</a>
			<a href="#" onclick="SetFrame('fhqr','Receive/SndSure.aspx','发货确认');">发货确认</a>
			<a href="#" onclick="SetFrame('qsqr','Receive/SndSign.aspx','签收确认');">签收确认</a>
			<div class="KsLine"></div>
			<a href="#" onclick="SetFrame('fhcx','Receive/SndSch.aspx','收发查询');">收发查询</a>
		</div>
    </div>

     <div id="menu_s_8" class="KsMenu">
       <iframe style="position: absolute;z-index: -2;height:210px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_8s" class="KsMenu2">
			<a href="#" onclick="SetFrame('wdgl','Office/DocAdm.aspx','文档管理');">文档管理</a>
			<a href="#" onclick="SetFrame('gggl','Office/AnnunciateAdm.aspx','公告管理');">公告管理</a>
			<a href="#" onclick="SetFrame('zsgl','Repository/RepositoryAdm.aspx','知识管理');">知识管理</a>
			<a href="#" onclick="SetFrame('xxfk','Office/FeedBackadm.aspx','信息反馈');">信息反馈</a>
			<a href="#" onclick="SetFrame('znxj','Office/MailAdm.aspx','站内信件');" class="iline" onmouseover="Sethiddensub('menu_s_sub_9');">站内信件</a>
			<div class="KsLine"></div>
			<a href="#" id="row9" onmouseover="Setmenu_sub('84','158','menu_s_sub_9');">考勤管理</a>
			<a href="#" onclick="SetFrame('rwgl','Office/TaskAdm.aspx','任务管理');" onmouseover="Sethiddensub('menu_s_sub_9');">任务管理</a>
			<div class="KsLine"></div>
			<a href="#" onclick="SetFrame('ggtcmx','Office/TecDeduct.aspx','员工提成明细');">员工提成明细</a>
			<a href="#" onclick="SetFrame('yckqmx','Office/AttendanceDe.aspx','异常考勤明细');">异常考勤明细</a>
			<a href="#" onclick="SetFrame('ygydxz','Office/TecWage.aspx','员工月度薪资');">员工月度薪资</a>
			<a href="#" onclick="SetFrame('ygrgzhz','Office/TecDayWork.aspx','员工工作汇总');">员工工作汇总</a>
		</div>
	    <div id="menu_s_sub_9" class="KsMenu" style="height:84px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:80px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
                <a href="#" onclick="ShowDialog(400, 150, 'Office/Absence.aspx', '考勤签到');">考勤签到</a>
	            <a href="#" onclick="SetFrame('qqsh','Office/ChkAttendance.aspx','缺勤审核');">缺勤审核</a>
	            <a href="#" onclick="SetFrame('kqhz','Office/Attendance.aspx','考勤汇总');">考勤汇总</a>
	            <a href="#" onclick="ShowDialog(600, 380, 'Office/AbsenceSet.aspx', '考勤设置');">考勤设置</a>
            </div>
        </div>
    </div>
    
    <div id="menu_s_9" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:60px;width:162px;" frameborder="0"></iframe>
         <div id="menu_s_9s" class="KsMenu2">
			<a href="#" onclick="SetFrame('qckc','BeginAccount/BeginStock.aspx','期初产品库存');" onmouseover="Sethiddensub('menu_s_sub_10');">期初产品库存</a>
			<a href="#" id="row10" onmouseover="Setmenu_sub('20','158','menu_s_sub_10');">期初应收应付</a>
			<a href="#" onclick="SetFrame('qcxjyh','BeginAccount/BeginCash.aspx','期初现金银行');" onmouseover="Sethiddensub('menu_s_sub_10');">期初现金银行</a>
		</div>
	    <div id="menu_s_sub_10" class="KsMenu" style="height:63px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:60px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" onclick="SetFrame('khqcysyf','BeginAccount/CusBeginArr.aspx','客户期初应收应付');">客户期初应收应付</a>
		        <a href="#" onclick="SetFrame('csqcysyf','BeginAccount/SupBeginArr.aspx','厂商期初应收应付');">厂商期初应收应付</a>
		        <a href="#" onclick="SetFrame('wdqcysyf','BeginAccount/BraBeginArr.aspx','网点期初应收应付');">网点期初应收应付</a>
	        </div>
        </div>
    </div>
    
    <div id="menu_s_10" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:168px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_10s" class="KsMenu2">
            <a href="#" id="row11" onmouseover="Setmenu_sub('0','158','menu_s_sub_11');">综合业务报表</a>
            <a href="#" id="row12" onmouseover="Setmenu_sub('20','158','menu_s_sub_12');">仓库业务报表</a>
       <!--     <a href="#" id="row22" onmouseover="Setmenu_sub('20','158','menu_s_sub_19')">采购业务报表</a>  -->
            <a href="#" id="row14" onmouseover="Setmenu_sub('41','158','menu_s_sub_13');">销售业务报表</a>
            <a href="#" id="row15" onmouseover="Setmenu_sub('0','158','menu_s_sub_14');">服务业务报表</a>
            <a href="#" id="row16" onmouseover="Setmenu_sub('83','158','menu_s_sub_15');">租赁/全保报表</a>
            <a href="#" id="row17" onmouseover="Setmenu_sub('104','158','menu_s_sub_16');">客户关系报表</a>
            <a href="#" id="row18" onmouseover="Setmenu_sub('125','158','menu_s_sub_17');">帐款业务报表</a>
            <a href="#" id="row19" onmouseover="Setmenu_sub('146','158','menu_s_sub_18');">数据挖掘报表</a>
		</div>
        <div id="menu_s_sub_11" class="KsMenu" style="height:42px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:40px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" onclick="SetFrame('ryyehzb','Stat/StDaySeller.aspx','日营业额汇总表');">日营业额汇总表</a>
		        <a href="#" onclick="SetFrame('yyyehzb','Stat/StMonthSeller.aspx','月营业额汇总表');">月营业额汇总表</a>
	        </div>
        </div>
        <div id="menu_s_sub_12" class="KsMenu" style="height:210px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:200px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" onclick="SetFrame('ckrbb','Stat/StStockDay.aspx','仓库日报表');">仓库日报表</a>
		        <a href="#" onclick="SetFrame('ckhzb','Stat/StStock.aspx','仓库汇总表');">仓库汇总表</a>
		        <a href="#" onclick="SetFrame('cprkhzb','Stat/StStockINg.aspx','产品入库汇总表');">产品入库汇总表</a>
		        <a href="#" onclick="SetFrame('ckrkhzb','Stat/StStockINs.aspx','仓库入库汇总表');">仓库入库汇总表</a>
		        <a href="#" onclick="SetFrame('rkmxhzb','Stat/StStockINDe.aspx','入库明细汇总表');">入库明细汇总表</a>
		        <a href="#" onclick="SetFrame('cpckhzb','Stat/StStockOUTg.aspx','产品出库汇总表');">产品出库汇总表</a>
		        <a href="#" onclick="SetFrame('ckckhzb','Stat/StStockOUTs.aspx','仓库出库汇总表');">仓库出库汇总表</a>
		        <a href="#" onclick="SetFrame('ckmxhzb','Stat/StStockOUTDe.aspx','出库明细汇总表');">出库明细汇总表</a>
		        <a href="#" onclick="SetFrame('cplthzb','Stat/StBroughtBack.aspx','产品领退汇总表');">产品领退汇总表</a>
		        <a href="#" onclick="SetFrame('sqrkthzb','Stat/StBroughtBacka.aspx','申请人领退汇总表');">申请人领退汇总表</a>
	        </div>
        </div>
        <div id="menu_s_sub_13" class="KsMenu" style="height:170px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:160px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
	            <a href="#" onclick="SetFrame('xsrbb','Stat/StSellDay.aspx','销售日报表');">销售日报表</a>
	            <a href="#" onclick="SetFrame('xsybb','Stat/StSellMonth.aspx','销售月报表');">销售月报表</a>
		        <div class="KsLine"></div>
		        <a href="#" onclick="SetFrame('cpxshzb','Stat/StSellg.aspx','产品销售汇总表');">产品销售汇总表</a>
	            <a href="#" onclick="SetFrame('khxshzb','Stat/StSellc.aspx','客户销售汇总表');">客户销售汇总表</a>
	            <a href="#" onclick="SetFrame('xsmxhzb','Stat/StSellDe.aspx','销售明细汇总表');">销售明细汇总表</a>
	            <div class="KsLine"></div>
	            <a href="#" onclick="SetFrame('cpthhzb2','Stat/StSellReturng.aspx','产品退货汇总表');">产品退货汇总表</a>
	            <a href="#" onclick="SetFrame('khthhzb','Stat/StSellReturnc.aspx','客户退货汇总表');">客户退货汇总表</a>
	            <a href="#" onclick="SetFrame('thmxhzb2','Stat/StSellReturnDe.aspx','退货明细汇总表');">退货明细汇总表</a>
	       </div>
        </div>
        <div id="menu_s_sub_14" class="KsMenu" style="height:573px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:530px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
	            <a href="#" onclick="SetFrame('fwrbb','Stat/StServiceDay.aspx','服务日报表');">服务日报表</a>
		        <a href="#" onclick="SetFrame('fwybb','Stat/StServiceMon.aspx','服务月报表');">服务月报表</a>
	            <div class="KsLine"></div>
	            <a href="#" onclick="SetFrame('fwhzb','Stat/StServicec.aspx','服务汇总表');">服务汇总表</a>
		        <a href="#" onclick="SetFrame('fwmxb','Stat/StServiceDe.aspx','服务明细表');">服务明细表</a>
		        <div class="KsLine"></div>
		        <a href="#" onclick="SetFrame('fwxmhzb','Stat/StSerItem.aspx','服务项目汇总表');">服务项目汇总表</a>
		        <a href="#" onclick="SetFrame('fuxmmxb','Stat/StSerItemDe.aspx','服务项目明细表');">服务项目明细表</a>
	            <div class="KsLine"></div>
	            <a href="#" onclick="SetFrame('fwdgl','Stat/StBillView.aspx','服务单概览');">服务单概览</a>
		        <a href="#" onclick="SetFrame('fwdfb','Stat/StBillFrom.aspx','服务单分布');">服务单分布</a>
		        <a href="#" onclick="SetFrame('jsyyj','Stat/StTechnician.aspx','技术员业绩');">技术员业绩</a>
		        <a href="#" onclick="SetFrame('jsygzrz','Stat/StDateSer.aspx','技术员工作日志');">技术员工作日志</a>
		        <a href="#" onclick="SetFrame('cqdtj','Stat/StExtServices.aspx','超期单统计');">超期单统计</a>
		        <a href="#" onclick="SetFrame('fwddt','Stat/StSerMap.aspx','服务单地图');">服务单地图</a>
		        <a href="#" onclick="SetFrame('fuxmmxb','Stat/StSerMaterial.aspx','服务备件汇总表');">服务备件汇总表</a>
		        <a href="#" onclick="SetFrame('bjmxhzb','Stat/MaterialDe.aspx','备件明细汇总表');">备件明细汇总表</a>
		        <a href="#" onclick="SetFrame('bjltmxb','Stat/StSerBroughtBack.aspx','备件领退明细表');">备件领退明细表</a>
		        <a href="#" onclick="SetFrame('bjltmxbpm','Stat/MaterialDeByGoods.aspx','备件(仓库)汇总表');">备件(仓库)汇总表</a>
		        <a href="#" onclick="SetFrame('bjltmxbywy','Stat/MaterialDeByAppOperator.aspx','备件(领料人)汇总表');">备件(领料人)汇总表</a>
		        <div class="KsLine"></div>
		        <a href="#" onclick="SetFrame('fwhtxsb','Stat/stSerContract.aspx','维保合同序时簿');">维保合同序时簿</a>
		        <a href="#" onclick="SetFrame('wbjqwxcb','Stat/StSerWarranty.aspx','维保期内机器维修成本');">维保期内机器维修成本</a>
		        <a href="#" onclick="SetFrame('wbwjqwxcb','Stat/StSerOutWarranty.aspx','维保期外机器维修成本');">维保期外机器维修成本</a>
		        <a href="#" onclick="SetFrame('fwcb','Stat/StSerCosts.aspx','服务成本');">服务成本</a>
		        <div class="KsLine"></div>
		        <a href="#" onclick="SetFrame('xpfbtb','Stat/StRepairDis.aspx','修品分布图表');">修品分布图表</a>
		        <a href="#" onclick="SetFrame('gzfbtb','Stat/StFaultDis.aspx','故障分布图表');">故障分布图表</a>
		        <a href="#" onclick="SetFrame('gztjb','Stat/stSerTakeSteps.aspx','故障统计表');">故障统计表</a>
		        <a href="#" onclick="SetFrame('clcsfbtb','Stat/StTakeStepsDis.aspx','处理措施分布图');">处理措施分布图</a>
		        <div class="KsLine"></div>
		        <a href="#" <%=menu[151] %> onclick="SetFrame('jsyfxhzb','Stat/StTecbRepair.aspx','技术员返修汇总表');">技术员返修汇总表</a>
		        <a href="#" <%=menu[151] %> onclick="SetFrame('jsycfwxl','Stat/StTecRepairRate.aspx','技术员重复维修率');">技术员重复维修率</a>
	        </div>
        </div>
        <div id="menu_s_sub_15" class="KsMenu" style="height:42px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:40px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" onclick="SetFrame('jsdhzb','Stat/StLeaseCharge.aspx','结算单汇总表');">结算单汇总表</a>
		        <a href="#" onclick="SetFrame('jsdmxb','Stat/StLeaseChargeDe.aspx','结算单明细表');">结算单明细表</a>
	        </div>
        </div>
        <div id="menu_s_sub_16" class="KsMenu" style="height:63px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:60px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
	            <a href="#" onclick="SetFrame('khzzqk','Stat/StCustomerAdd.aspx','客户增长情况');">客户增长情况</a>
	            <a href="#" onclick="SetFrame('khjzph','Stat/StCusValueList.aspx','客户价值排行');">客户价值排行</a>
	            <a href="#" <%=menu[159] %> onclick="SetFrame('khgzhz','Stat/StCusTrack.aspx','客户跟踪汇总');">客户跟踪汇总</a>
	        </div>
        </div>
        <div id="menu_s_sub_17" class="KsMenu" style="height:257px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:210px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" onclick="SetFrame('szrbb','Stat/StDayInTo.aspx','收支日报表');">收支日报表</a>
		        <a href="#" onclick="SetFrame('szybb','Stat/StMonthInTo.aspx','收支月报表');">收支月报表</a>
		        <div class="KsLine"></div>
		        <a href="#" onclick="SetFrame('skdhzb','Stat/StIncome.aspx','收款单汇总表');">收款单汇总表</a>
		        <a href="#" onclick="SetFrame('skdmxb','Stat/StIncomeDe.aspx','收款单明细表');">收款单明细表</a>
		        <div class="KsLine"></div>
		        <a href="#" onclick="SetFrame('fkdhzb','Stat/StPay.aspx','付款单汇总表');">付款单汇总表</a>
		        <a href="#" onclick="SetFrame('fkdmxb','Stat/StPayDe.aspx','付款单明细表');">付款单明细表</a>
		        <div class="KsLine"></div>
		        <a href="#" onclick="SetFrame('ysyfhzb','Stat/StArr.aspx','应收应付汇总表');">应收应付汇总表</a>
		        <a href="#" onclick="SetFrame('ysyfmxb','Stat/StArrDe.aspx','应收应付明细表');">应收应付明细表</a>
		        <a href="#" onclick="SetFrame('ysyfzlb','Stat/StArrAge.aspx','应收应付帐龄表');">应收应付账龄表</a>
		        <a href="#" onclick="SetFrame('ysyfhzb','Stat/StArrCanl.aspx','应收应付坏帐表');">应收应付坏账表</a>
		        <div class="KsLine"></div>
		        <a href="#" onclick="SetFrame('bxhzb','Stat/ExpenseDe.aspx','报销汇总表');">报销汇总表</a>
		        <a href="#" onclick="SetFrame('bxmxb','Stat/ExpenseDetail.aspx','报销明细表');">报销明细表</a>
		        <div class="KsLine"></div>
	        </div>
        </div>
        <div id="menu_s_sub_18" class="KsMenu" style="height:168px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:160px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" onclick="SetFrame('ywqsfx','Stat/AnCurrent.aspx','业务趋势分析');">业务趋势分析</a>
		        <a href="#" onclick="SetFrame('gzjdfx','Stat/AnProgress.aspx','工作进度分析');">工作进度分析</a>
		        <a href="#" onclick="SetFrame('skfsfx','Stat/AnIncomeType.aspx','收款方式分析');">收款方式分析</a>
		        <a href="#" onclick="SetFrame('qxyyfx','Stat/AnCancelReason.aspx','取消原因分析');">取消原因分析</a>
		        <a href="#" onclick="SetFrame('fwlbfx','Stat/AnOperationType.aspx','服务类别分析');">服务类别分析</a>
		        <a href="#" onclick="SetFrame('slfsfx','Stat/AnTakeType.aspx','受理方式分析');">受理方式分析</a>
		        <a href="#" onclick="SetFrame('khlyfx','Stat/AnSatisCusFrom.aspx','客户来源分析');">客户来源分析</a>
		        <a href="#" onclick="SetFrame('khlbfx','Stat/AnSatisCusClass.aspx','客户类别分析');">客户类别分析</a>
	        </div>
        </div>
    </div>
    <div id="menu_s_11" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:190px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_11s" class="KsMenu2">
			<a href="#" onclick="ShowDialog(600, 380, 'Basic/StaffDeptAdm.aspx', '员工部门');">员工部门</a>
			<a href="#" onclick="SetFrame('ygml','Basic/StaffAdm.aspx','员工目录');">员工目录</a>
			<a href="#" onclick="SetFrame('ckml','Basic/StockListAdm.aspx','仓库目录');">仓库目录</a>
			<a href="#" onclick="ShowDialog(600, 380, 'Basic/StockLocAdm.aspx','仓位目录');">仓位目录</a>
			<a href="#" onclick="ShowDialog(600, 380, 'Basic/DeviceConfItem.aspx', '机器配置项');">机器配置项</a>
			<a href="#" onclick="SetFrame('wlcs','Basic/SupplierAdm.aspx','往来厂商');">往来厂商</a>
			<div class="KsLine"></div>
			<a href="#" onclick="ShowDialog(600, 380, 'Basic/AccountAdm.aspx', '收支帐户');">收支帐户</a>
			<a href="#" onclick="ShowDialog(600, 380, 'Basic/ChargeItemAdm.aspx', '收支项目');">收支项目</a>
			<a href="#" onclick="ShowDialog(600, 380, 'Basic/ExpenseItemAdm.aspx', '报销项目');">报销项目</a>
			<a href="#" onclick="ShowDialog(600, 380, 'Basic/ShippingStyleAdm.aspx', '货运方式');">货运方式</a>
		</div>
    </div>    
    
    <div id="menu_s_12" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:<%=sysHeight %>px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_12s" class="KsMenu2">
			<a href="#" style="display:<%=showNO %>" onclick="ShowDialog(620,200,'System/NOList.aspx','编号设置');">编号设置</a>
			<a href="#" <%=menu[205] %> onclick="SetFrame('qxgl','System/RightAdm.aspx','权限管理');">权限管理</a>
			<a href="#" <%=menu[205] %> onclick="SetFrame('yhgl','System/UserManage.aspx','用户管理');">用户管理</a>
			<a href="#" onclick="ShowDialog(600, 190, 'System/UserPwd.aspx', '修改密码');">修改密码</a>
			<div class="KsLine"></div>
			<a href="#" onclick="ChkExit();">退出系统</a>
		</div>
    </div>
    
    <div id="menu_s_13" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:85px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_13s" class="KsMenu2">
			<a href="#" <%=menu[205] %> onclick="ShowDialog(800,520,'Tool/Layout.aspx','表格布局');">表格布局</a>
			<a href="#" onclick="ShowDialog(640, 480, 'Tool/ToolBar.aspx', '工具栏定义');">工具栏定义</a>
			<div class="KsLine"></div>
			<a href="#" onclick="ShowDialog(600, 350, 'Tool/SmsAdm.aspx','发送短信');">发送短信</a>
			<a href="#" onclick="ShowDialog(600, 310, 'Tool/Printtmp.aspx', '打印模板');">打印模板</a>
			<div style="display:<%=showOL %>" class="KsLine"></div>
			<a href="#" style="display:<%=showOL %>" onclick="ShowDialog(600, 310, 'Tool/OnlineList.aspx', '在线用户');">在线用户</a>
		</div>
    </div>
    
    <div id="menu_s_14"  class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:85px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_14s" class="KsMenu2">
			<a onclick="Sethidden1();" href="http://www.differsoft.com" target="_blank">官方网站</a>
			<a onclick="Sethidden1();" href="http://bbs.differsoft.com/" target="_blank">意见反馈</a>
			<a onclick="Sethidden1();" href="http://www.differsoft.com/production/files/Prodoc/WTnet_IT_Help.mht" target="_blank">在线帮助</a>
			<div class="KsLine"></div>
			<a onclick="ShowDialog(500, 228, '../Headquarters/About.aspx', '关于');" href="#">关于</a>
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
<div id="F1" onmousedown="ChangeWList('left')" onmouseup="ChangeWList('out')"><img src="../Public/Images/left.png"></div>
<div id="F2" onmousedown="ChangeWList('right')" onmouseup="ChangeWList('out')"><img src="../Public/Images/right.png"></div>
</td>
</tr></table>
</div>
<div id="WinPage"></div>
</div>
<!--加载等待窗口-->
<div id='Loading' style="position:absolute;z-index:1000;top:0px;left:0px;width:100%;height:100%;background:#fff;text-align:center"><img src='../Public/images/loading.gif' style='margin-top:150px'></div>

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
