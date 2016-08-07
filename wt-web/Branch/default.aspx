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
��var obj = document.getElementById("divTitleName");
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
  AddWin('YWDH','ҵ�񵼺�','Mynavigation/all.html',0,0,1,0,0);
  ChangeWin();
}
    
var fmenu=false;
function ChkExit()
{
    if(confirm("ȷ��Ҫ�˳�����ϵͳ��"))
    {
        document.getElementById("btnExit").click();
    }
}

function ChkClose()
{
    event.returnValue="";
}
/*-----�˵�����-----------*/
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
        <li <%=moduln[0] %>><a href="#" onclick="<%=module[0] %>ClickSetmenu('<%=modulm[0] %>','<%=modulh[0] %>','menu_s_1');" onmouseover="<%=module[0] %>Setmenu('<%=modulm[0] %>','<%=modulh[0] %>','menu_s_1');">�ֿ����</a></li><li <%=moduln[1] %>><a href="#" onclick="<%=module[1] %>ClickSetmenu('<%=modulm[1] %>','<%=modulh[1] %>','menu_s_15');" onmouseover="<%=module[1] %>Setmenu('<%=modulm[1] %>','<%=modulh[1] %>','menu_s_15');">�ɹ�����</a></li><li <%=moduln[2] %>><a href="#" onclick="<%=module[2] %>ClickSetmenu('<%=modulm[2] %>','<%=modulh[2] %>','menu_s_2');" onmouseover="<%=module[2] %>Setmenu('<%=modulm[2] %>','<%=modulh[2] %>','menu_s_2');">���۹���</a></li><li <%=moduln[3] %>><a href="#" onclick="<%=module[3] %>ClickSetmenu('<%=modulm[3] %>','<%=modulh[3] %>','menu_s_3');" onmouseover="<%=module[3] %>Setmenu('<%=modulm[3] %>','<%=modulh[3] %>','menu_s_3');">�������</a></li><li <%=moduln[4] %>><a style="line-height:23px;" href="#" onclick="<%=module[4] %>ClickSetmenu('<%=modulm[4] %>','<%=modulh[4] %>','menu_s_4');" onmouseover="<%=module[4] %>Setmenu('<%=modulm[4] %>','<%=modulh[4] %>','menu_s_4');">����/ȫ��</a></li><li <%=moduln[5] %>><a href="#" onclick="<%=module[5] %>ClickSetmenu('<%=modulm[5] %>','<%=modulh[5] %>','menu_s_5');" onmouseover="<%=module[5] %>Setmenu('<%=modulm[5] %>','<%=modulh[5] %>','menu_s_5');">�ͻ���ϵ</a></li><li <%=moduln[6] %>><a href="#" onclick="<%=module[6] %>ClickSetmenu('<%=modulm[6] %>','<%=modulh[6] %>','menu_s_6');" onmouseover="<%=module[6] %>Setmenu('<%=modulm[6] %>','<%=modulh[6] %>','menu_s_6');">�ʿ����</a></li><li <%=moduln[7] %>><a href="#" onclick="<%=module[7] %>ClickSetmenu('<%=modulm[7] %>','<%=modulh[7] %>','menu_s_7');" onmouseover="<%=module[7] %>Setmenu('<%=modulm[7] %>','<%=modulh[7] %>','menu_s_7');">�շ�����</a></li><li <%=moduln[8] %>><a href="#" onclick="<%=module[8] %>ClickSetmenu('<%=modulm[8] %>','<%=modulh[8] %>','menu_s_8');" onmouseover="<%=module[8] %>Setmenu('<%=modulm[8] %>','<%=modulh[8] %>','menu_s_8');" style="width:55px; line-height:23px;">�칫OA</a></li><li <%=moduln[9] %>><a href="#" onclick="<%=module[9] %>ClickSetmenu('<%=modulm[9] %>','<%=modulh[9] %>','menu_s_9');" onmouseover="<%=module[9] %>Setmenu('<%=modulm[9] %>','<%=modulh[9] %>','menu_s_9');">�ڳ�¼��</a></li><li <%=moduln[10] %>><a href="#" onclick="<%=module[10] %>ClickSetmenu('<%=modulm[10] %>','<%=modulh[10] %>','menu_s_10');" onmouseover="<%=module[10] %>Setmenu('<%=modulm[10] %>','<%=modulh[10] %>','menu_s_10');">ͳ�Ʒ���</a></li><li <%=moduln[11] %>><a href="#" onclick="<%=module[11] %>ClickSetmenu('<%=modulm[11] %>','<%=modulh[11] %>','menu_s_11');" onmouseover="<%=module[11] %>Setmenu('<%=modulm[11] %>','<%=modulh[11] %>','menu_s_11');">��������</a></li><li><a href="#" onclick="ClickSetmenu('<%=modulm[12] %>','<%=modulh[12] %>','menu_s_12');" onmouseover="Setmenu('<%=modulm[12] %>','<%=modulh[12] %>','menu_s_12');">ϵͳά��</a></li><li><a href="#" onclick="ClickSetmenu('<%=modulm[13] %>','<%=modulh[13] %>','menu_s_13');" onmouseover="Setmenu('<%=modulm[13] %>','<%=modulh[13] %>','menu_s_13');" style="width:35px;">����</a></li><li><a href="#" onclick="ClickSetmenu('<%=modulm[14] %>','<%=modulh[14] %>','menu_s_14');" onmouseover="Setmenu('<%=modulm[14] %>','<%=modulh[14] %>','menu_s_14');" style="width:35px;">����</a></li><li><a href ="http://www.18bg.com" target ="_blank">18�ư칫</a></li>
    </ul>
    
    <div id="menu_s_1" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:252px;width:162px;" frameborder="0"></iframe>
         <div id="menu_s_1s" class="KsMenu2">
            <a href="#" onclick="SetFrame('dqkc','Stock/StockAdm.aspx','��ǰ���');">��ǰ���</a>
            <a href="#" onclick="SetFrame('fpkc','Stock/StockrAdm.aspx','��Ʒ���');">��Ʒ���</a>
            <a href="#" onclick="SetFrame('fckc','Stock/DeptStock.aspx','�ֲֿ��');">�ֲֿ��</a>
            <a href="#" onclick="SetFrame('xlhk','Stock/SNAdm.aspx','���кſ�');">���кſ�</a>
            <div class="KsLine"></div>
            <a href="#" onclick="SetFrame('qtrk','Stock/StockIn.aspx','�������');">�������</a>			
            <a href="#" onclick="SetFrame('qtck','Stock/StockOut.aspx','��������');">��������</a>
            <a href="#" onclick="SetFrame('llkd','Stock/BroughtBack.aspx','���˿���');" onmouseover="Sethiddensub('menu_s_sub_20');" >���˿���</a>
            <div class="KsLine"></div>
            <a href="#" id="row21" onmouseover="Sethiddensub('menu_s_sub_19');Setmenu_sub('150','158','menu_s_sub_20');">�ڲ�����</a>
            <a href="#" id="row20" onmouseover="Sethiddensub('menu_s_sub_20');Setmenu_sub('170','158','menu_s_sub_19');">�������</a>
            <div class="KsLine"></div>
            <a href="#" id="row1" onmouseover="Setmenu_sub('192','158','menu_s_sub_1');Sethiddensub('menu_s_sub_19');">�������</a>
			<a href="#" id="row2" onmouseover="Setmenu_sub('213','158','menu_s_sub_2');">�ֿ�ҵ��</a>
			<a href="#" id="row3" onmouseover="Setmenu_sub('234','158','menu_s_sub_3');">���ݲ�ѯ</a>
		</div>
        <div id="menu_s_sub_19" class="KsMenu" style="height:84px;z-index:9999;">
		    <iframe style="position: absolute;z-index: -2;height:80px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
                <a href="#" onclick="SetFrame('dbsq','Stock/AllocateApp.aspx','��������');">��������</a>
                <a href="#" onclick="SetFrame('dbsh','Stock/AllocateAppChk.aspx','�������');">�������</a>
                <a href="#" onclick="SetFrame('dbfh','Stock/AllocateRec.aspx','��������');">��������</a>
                <a href="#" onclick="SetFrame('dbqs','Stock/AllocateSigned.aspx','����ǩ��');">����ǩ��</a>
		    </div>
		</div>
		<div id="menu_s_sub_20" class="KsMenu" style="height:63px;z-index:9999;">
		    <iframe style="position: absolute;z-index: -2;height:60px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" onclick="SetFrame('nbdbsq','Stock/AllocateAdd.aspx','�ڲ���������');">�ڲ���������</a>
                <a href="#" onclick="SetFrame('nbdbcksh','Stock/InnerOutChk.aspx','�ڲ������������');">�ڲ������������</a>
                <a href="#" onclick="SetFrame('nbdbrksh','Stock/InnerInChk.aspx','�ڲ�����������');">�ڲ�����������</a>
		    </div>
		</div>
		<div id="menu_s_sub_1" class="KsMenu" style="height:42px;z-index:9999;">
		    <iframe style="position: absolute;z-index: -2;height:40px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" onclick="SetFrame('jckd','Stock/LendingAdd.aspx','�������');">�������</a>
                <a href="#" onclick="SetFrame('jccx','Stock/SchLendingReturn.aspx','�����ѯ');">�����ѯ</a>
		    </div>
		</div>
		<div id="menu_s_sub_2" class="KsMenu" style="height:63px;z-index:9999;">
		    <iframe style="position: absolute;z-index: -2;height:60px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" onclick="SetFrame('cxzz','Stock/DisBiling.aspx','��װ����');">��װ����</a>
                <a href="#" onclick="SetFrame('tjkd','Stock/Regulate.aspx','���ۿ���');">���ۿ���</a>
                <a href="#" onclick="SetFrame('pdkd','Stock/StockCheck.aspx','�̵㿪��');">�̵㿪��</a>
		    </div>
		</div>
		<div id="menu_s_sub_3" class="KsMenu" style="height:168px;z-index:9999;">
		    <iframe style="position: absolute;z-index: -2;height:160px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" onclick="SetFrame('rkdcx','Stock/SchStockIn.aspx','��ⵥ��ѯ');">��ⵥ��ѯ</a>
		        <a href="#" onclick="SetFrame('ckdcx','Stock/SchStockOut.aspx','���ⵥ��ѯ');">���ⵥ��ѯ</a>
				<a href="#" onclick="SetFrame('ltdcx','Stock/SchBroughtBack.aspx','���˵���ѯ');">���˵���ѯ</a>
				<a href="#" onclick="SetFrame('dbdcx','Stock/SchInnerAllocate.aspx','�ڲ���������ѯ');">�ڲ���������ѯ</a>
				<a href="#" onclick="SetFrame('dbdcx','Stock/SchAllocate.aspx','�����������ѯ');">�����������ѯ</a>
				<a href="#" onclick="SetFrame('czdcx','Stock/SchDisBiling.aspx','��װ����ѯ');">��װ����ѯ</a>
				<a href="#" onclick="SetFrame('tjdcx','Stock/SchRegulate.aspx','���۵���ѯ');">���۵���ѯ</a>
				<a href="#" onclick="SetFrame('pddcx','Stock/SchStockCheck.aspx','�̵㵥��ѯ');">�̵㵥��ѯ</a>
			</div>
		</div>
    </div>
    <div id="menu_s_15" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:105px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_15s" class="KsMenu2">
			<a href="#" <%=menu[28] %> onclick="SetFrame('cgkd','Purchase/PurchaseAdd.aspx', '�ɹ�����');">�ɹ�����</a>
			<a href="#" <%=menu[29] %> onclick="SetFrame('cgth','Purchase/PurReturn.aspx', '�ɹ��˻�');">�ɹ��˻�</a>
			<a href="#" <%=menu[30] %> onclick="SetFrame('cgdcx','Purchase/SchPurchase.aspx','�ɹ�����ѯ');">�ɹ�����ѯ</a>
			<div class="KsLine"></div>
            <a href="#" <%=menu[31] %> onclick="SetFrame('cgdd','Purchase/PurPlanAdd.aspx', '�ɹ�����');">�ɹ�����</a>
			<a href="#" <%=menu[32] %> onclick="SetFrame('cgddcx','Purchase/SchPurPlan.aspx','�ɹ�������ѯ');">�ɹ�������ѯ</a>
		</div>
    </div>
    <div id="menu_s_2" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:106px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_2s" class="KsMenu2">
			<a href="#" onclick="SetFrame('xskd','Sell/SellAdd.aspx', '���ۿ���');">���ۿ���</a>
			<a href="#" onclick="SetFrame('xsth','Sell/SellReturn.aspx', '�����˻�');">�����˻�</a>
			<a href="#" onclick="SetFrame('xsdcx','Sell/SchSell.aspx','���۵���ѯ');">���۵���ѯ</a>
			<div class="KsLine"></div>
            <a href="#" onclick="SetFrame('xsdd','Sell/SellPlanAdd.aspx', '���۶���');">���۶���</a>
			<a href="#" onclick="SetFrame('xsddcx','Sell/SchSellPlan.aspx','���۶�����ѯ');">���۶�����ѯ</a>
		</div>
    </div>
    
    <div id="menu_s_3" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:129px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_3s" class="KsMenu2">
            <a href="#" onclick="SetFrame('sqqr','Services/ServicesNet.aspx','�������');">�������</a>
            <a href="#" onclick="SetFrame('sqqr','Services/ServicesConf.aspx','����ȷ��');">����ȷ��</a>
			<div class="KsLine"></div>
			<a href="#" onclick="SetFrame('fwzx','Services/ServicesAllot.aspx','��������')" onmouseover="Sethiddensub('menu_s_sub_4');">��������</a>
            <div class="KsLine"></div>
            <a href="#" id="row4" onmouseover="Setmenu_sub('42','158','menu_s_sub_4');">���޹���</a>
			<a href="#" onclick="SetFrame('wgjs','Services/ServicesBln.aspx','�깤����');" onmouseover="Sethiddensub('menu_s_sub_4');">�깤����</a>
            <div class="KsLine"></div>
            <a href="#" onclick="SetFrame('fwdcx','Services/SchServices.aspx','���񵥲�ѯ');">���񵥲�ѯ</a>
            <a href="#" onclick="SetFrame('xxfwdcx','Services/SchFullServices.aspx','��ϸ����');">��ϸ����</a>
	    </div>
	    <div id="menu_s_sub_4" class="KsMenu" style="height:63px;z-index:9999;">
		    <iframe style="position: absolute;z-index: -2;height:63px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" onclick="SetFrame('sxfh','Services/ServicesSnd.aspx','���޷���');">���޷���</a>
		        <a href="#" onclick="SetFrame('shjs','Services/ServicesRcv.aspx','�ջ�����');">�ջ�����</a>
		        <a href="#" onclick="SetFrame('lssx','Services/HistorySnd.aspx','��ʷ����');">��ʷ����</a>
	        </div>
        </div>
    </div>
    <div id="menu_s_4" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:150px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_4s" class="KsMenu2">
			<a href="#" onclick="SetFrame('xjyw','Lease/LeaseAdd.aspx', '�½�ҵ��');">�½�ҵ��</a>
			<a href="#" onclick="SetFrame('ywsh','Lease/LeaseChk.aspx', 'ҵ�����');">ҵ�����</a>
			<div class="KsLine"></div>			
			<a href="#" onclick="SetFrame('cbdd','Lease/MeterReading.aspx', '����Ǽ�');">����Ǽ�</a>
			<a href="#" onclick="SetFrame('sbgh','Lease/ChangeMachine.aspx', '�豸�˻�');">�豸�˻�</a>
			<a href="#" onclick="SetFrame('htjy','Lease/Release.aspx', '��ͬ��Լ');">��ͬ��Լ</a>
			<div class="KsLine"></div>
			<a href="#" onclick="SetFrame('jssh','Lease/Settlement.aspx', '�������');">�������</a>
			<div class="KsLine"></div>
			<a href="#" onclick="SetFrame('ywcx','Lease/SchLease.aspx','ҵ���ѯ');">ҵ���ѯ</a>
		</div>
    </div>
    <div id="menu_s_5" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:148px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_5s" class="KsMenu2">
			<a href="#" onclick="SetFrame('khda','Customer/CusListAdm.aspx','�ͻ�����');">�ͻ�����</a>
			<a href="#" onclick="SetFrame('jqda','Customer/DeviceListAdm.aspx','��������');">��������</a>
			<div class="KsLine"></div>
			<a href="#" onclick="SetFrame('fwht','Customer/MaintenanceContract.aspx','�����ͬ');">�����ͬ</a>
			<a href="#" onclick="SetFrame('bypg','Customer/MaintenanceAllot.aspx','�����ɹ�');">�����ɹ�</a>
			<a href="#" onclick="SetFrame('khgz','Customer/CustomerTrack.aspx','�ͻ�����');">�ͻ�����</a>
			<a href="#" onclick="SetFrame('hcgz','Customer/ConsumablesTrack.aspx','�Ĳĸ���');">�Ĳĸ���</a>
			<a href="#" onclick="SetFrame('tscl','Customer/ComplaintAdm.aspx','Ͷ�߹���');">Ͷ�߹���</a>
		</div>
    </div>
    
    <div id="menu_s_6" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:128px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_6s" class="KsMenu2">
            <a href="#" id="row5" onmouseover="Setmenu_sub('0','158','menu_s_sub_5');">�տ��</a>
            <a href="#" id="row6" onmouseover="Setmenu_sub('20','158','menu_s_sub_6');">�����</a>
            <a href="#" onclick="SetFrame('sfkcx','Financial/IncomeAdm.aspx','�ո����ѯ');" onmouseover="Sethiddensub('menu_s_sub_6');">�ո����ѯ</a>
            <div class="KsLine"></div>
            <a href="#" onclick="SetFrame('ysyf','Financial/ArrearageAdm.aspx','Ӧ��Ӧ��');" onmouseover="Sethiddensub('menu_s_sub_7');">Ӧ��Ӧ��</a>
            <div class="KsLine"></div>
            <a href="#" id="row7"  onmouseover="Setmenu_sub('84','158','menu_s_sub_7');">�ֽ�����</a>
            <a href="#" id="row8" onmouseover="Sethiddensub('menu_s_sub_7');Setmenu_sub('105','158','menu_s_sub_8');">���ñ���</a>
		</div>
		<div id="menu_s_sub_5" class="KsMenu" style="height:63px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:60px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
	            <a href="#" onclick="SetFrame('sysk','Financial/IncomeAdd.aspx', '��Ӧ�տ�');">��Ӧ�տ�</a>
	            <a href="#" onclick="SetFrame('sysk2','Financial/AdvanceInAdd.aspx', '��Ԥ�տ�');">��Ԥ�տ�</a>
	            <a href="#" onclick="SetFrame('qtsk','Financial/OtherInAdd.aspx', '�����տ�');">�����տ�</a>
            </div>
        </div>
        <div id="menu_s_sub_6" class="KsMenu" style="height:63px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:60px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
	            <a href="#" onclick="SetFrame('fyfk','Financial/PaymentAdd.aspx','��Ӧ����');">��Ӧ����</a>
	            <a href="#" onclick="SetFrame('fyfk2','Financial/AdvancePayAdd.aspx','��Ԥ����');">��Ԥ����</a>
	            <a href="#" onclick="SetFrame('qtfk','Financial/OtherPayAdd.aspx','��������');">��������</a>
            </div>
        </div>
        <div id="menu_s_sub_7" class="KsMenu" style="height:42px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:40px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
                <a href="#" onclick="SetFrame('zhzz','Financial/Transfer.aspx','�ʻ�ת��');">�ʻ�ת��</a>
	            <a href="#" onclick="SetFrame('zhhz','Financial/IncomeBank.aspx','�ʻ�����');">�ʻ�����</a>
            </div>
        </div>
        
        <div id="menu_s_sub_8" class="KsMenu" style="height:106px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:80px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
                <a href="#" onclick="SetFrame('bxsq','Financial/Expense.aspx','��������');">��������</a>
	            <a href="#" onclick="SetFrame('zgsh','Financial/ChkExpense.aspx','�������');">�������</a>
	            <a href="#" onclick="SetFrame('kxff','Financial/PayExpense.aspx','�����');">�����</a>
	            <div class="KsLine"></div>
	            <a href="#" onclick="SetFrame('bxcx','Financial/SchExpense.aspx','������ѯ');">������ѯ</a>
	            <a href="#" onclick="SetFrame('bxcxmx','Financial/SchFullExpense.aspx','������ϸ');">������ϸ</a>
            </div>
        </div>
    </div>
    
    <div id="menu_s_7" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:80px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_7s" class="KsMenu2">
			<a href="#" onclick="SetFrame('xjfh','Receive/SndNew.aspx', '�½�����');">�½�����</a>
			<a href="#" onclick="SetFrame('fhqr','Receive/SndSure.aspx','����ȷ��');">����ȷ��</a>
			<a href="#" onclick="SetFrame('qsqr','Receive/SndSign.aspx','ǩ��ȷ��');">ǩ��ȷ��</a>
			<div class="KsLine"></div>
			<a href="#" onclick="SetFrame('fhcx','Receive/SndSch.aspx','�շ���ѯ');">�շ���ѯ</a>
		</div>
    </div>

     <div id="menu_s_8" class="KsMenu">
       <iframe style="position: absolute;z-index: -2;height:210px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_8s" class="KsMenu2">
			<a href="#" onclick="SetFrame('wdgl','Office/DocAdm.aspx','�ĵ�����');">�ĵ�����</a>
			<a href="#" onclick="SetFrame('gggl','Office/AnnunciateAdm.aspx','�������');">�������</a>
			<a href="#" onclick="SetFrame('zsgl','Repository/RepositoryAdm.aspx','֪ʶ����');">֪ʶ����</a>
			<a href="#" onclick="SetFrame('xxfk','Office/FeedBackadm.aspx','��Ϣ����');">��Ϣ����</a>
			<a href="#" onclick="SetFrame('znxj','Office/MailAdm.aspx','վ���ż�');" class="iline" onmouseover="Sethiddensub('menu_s_sub_9');">վ���ż�</a>
			<div class="KsLine"></div>
			<a href="#" id="row9" onmouseover="Setmenu_sub('84','158','menu_s_sub_9');">���ڹ���</a>
			<a href="#" onclick="SetFrame('rwgl','Office/TaskAdm.aspx','�������');" onmouseover="Sethiddensub('menu_s_sub_9');">�������</a>
			<div class="KsLine"></div>
			<a href="#" onclick="SetFrame('ggtcmx','Office/TecDeduct.aspx','Ա�������ϸ');">Ա�������ϸ</a>
			<a href="#" onclick="SetFrame('yckqmx','Office/AttendanceDe.aspx','�쳣������ϸ');">�쳣������ϸ</a>
			<a href="#" onclick="SetFrame('ygydxz','Office/TecWage.aspx','Ա���¶�н��');">Ա���¶�н��</a>
			<a href="#" onclick="SetFrame('ygrgzhz','Office/TecDayWork.aspx','Ա����������');">Ա����������</a>
		</div>
	    <div id="menu_s_sub_9" class="KsMenu" style="height:84px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:80px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
                <a href="#" onclick="ShowDialog(400, 150, 'Office/Absence.aspx', '����ǩ��');">����ǩ��</a>
	            <a href="#" onclick="SetFrame('qqsh','Office/ChkAttendance.aspx','ȱ�����');">ȱ�����</a>
	            <a href="#" onclick="SetFrame('kqhz','Office/Attendance.aspx','���ڻ���');">���ڻ���</a>
	            <a href="#" onclick="ShowDialog(600, 380, 'Office/AbsenceSet.aspx', '��������');">��������</a>
            </div>
        </div>
    </div>
    
    <div id="menu_s_9" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:60px;width:162px;" frameborder="0"></iframe>
         <div id="menu_s_9s" class="KsMenu2">
			<a href="#" onclick="SetFrame('qckc','BeginAccount/BeginStock.aspx','�ڳ���Ʒ���');" onmouseover="Sethiddensub('menu_s_sub_10');">�ڳ���Ʒ���</a>
			<a href="#" id="row10" onmouseover="Setmenu_sub('20','158','menu_s_sub_10');">�ڳ�Ӧ��Ӧ��</a>
			<a href="#" onclick="SetFrame('qcxjyh','BeginAccount/BeginCash.aspx','�ڳ��ֽ�����');" onmouseover="Sethiddensub('menu_s_sub_10');">�ڳ��ֽ�����</a>
		</div>
	    <div id="menu_s_sub_10" class="KsMenu" style="height:63px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:60px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" onclick="SetFrame('khqcysyf','BeginAccount/CusBeginArr.aspx','�ͻ��ڳ�Ӧ��Ӧ��');">�ͻ��ڳ�Ӧ��Ӧ��</a>
		        <a href="#" onclick="SetFrame('csqcysyf','BeginAccount/SupBeginArr.aspx','�����ڳ�Ӧ��Ӧ��');">�����ڳ�Ӧ��Ӧ��</a>
		        <a href="#" onclick="SetFrame('wdqcysyf','BeginAccount/BraBeginArr.aspx','�����ڳ�Ӧ��Ӧ��');">�����ڳ�Ӧ��Ӧ��</a>
	        </div>
        </div>
    </div>
    
    <div id="menu_s_10" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:168px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_10s" class="KsMenu2">
            <a href="#" id="row11" onmouseover="Setmenu_sub('0','158','menu_s_sub_11');">�ۺ�ҵ�񱨱�</a>
            <a href="#" id="row12" onmouseover="Setmenu_sub('20','158','menu_s_sub_12');">�ֿ�ҵ�񱨱�</a>
       <!--     <a href="#" id="row22" onmouseover="Setmenu_sub('20','158','menu_s_sub_19')">�ɹ�ҵ�񱨱�</a>  -->
            <a href="#" id="row14" onmouseover="Setmenu_sub('41','158','menu_s_sub_13');">����ҵ�񱨱�</a>
            <a href="#" id="row15" onmouseover="Setmenu_sub('0','158','menu_s_sub_14');">����ҵ�񱨱�</a>
            <a href="#" id="row16" onmouseover="Setmenu_sub('83','158','menu_s_sub_15');">����/ȫ������</a>
            <a href="#" id="row17" onmouseover="Setmenu_sub('104','158','menu_s_sub_16');">�ͻ���ϵ����</a>
            <a href="#" id="row18" onmouseover="Setmenu_sub('125','158','menu_s_sub_17');">�ʿ�ҵ�񱨱�</a>
            <a href="#" id="row19" onmouseover="Setmenu_sub('146','158','menu_s_sub_18');">�����ھ򱨱�</a>
		</div>
        <div id="menu_s_sub_11" class="KsMenu" style="height:42px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:40px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" onclick="SetFrame('ryyehzb','Stat/StDaySeller.aspx','��Ӫҵ����ܱ�');">��Ӫҵ����ܱ�</a>
		        <a href="#" onclick="SetFrame('yyyehzb','Stat/StMonthSeller.aspx','��Ӫҵ����ܱ�');">��Ӫҵ����ܱ�</a>
	        </div>
        </div>
        <div id="menu_s_sub_12" class="KsMenu" style="height:210px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:200px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" onclick="SetFrame('ckrbb','Stat/StStockDay.aspx','�ֿ��ձ���');">�ֿ��ձ���</a>
		        <a href="#" onclick="SetFrame('ckhzb','Stat/StStock.aspx','�ֿ���ܱ�');">�ֿ���ܱ�</a>
		        <a href="#" onclick="SetFrame('cprkhzb','Stat/StStockINg.aspx','��Ʒ�����ܱ�');">��Ʒ�����ܱ�</a>
		        <a href="#" onclick="SetFrame('ckrkhzb','Stat/StStockINs.aspx','�ֿ������ܱ�');">�ֿ������ܱ�</a>
		        <a href="#" onclick="SetFrame('rkmxhzb','Stat/StStockINDe.aspx','�����ϸ���ܱ�');">�����ϸ���ܱ�</a>
		        <a href="#" onclick="SetFrame('cpckhzb','Stat/StStockOUTg.aspx','��Ʒ������ܱ�');">��Ʒ������ܱ�</a>
		        <a href="#" onclick="SetFrame('ckckhzb','Stat/StStockOUTs.aspx','�ֿ������ܱ�');">�ֿ������ܱ�</a>
		        <a href="#" onclick="SetFrame('ckmxhzb','Stat/StStockOUTDe.aspx','������ϸ���ܱ�');">������ϸ���ܱ�</a>
		        <a href="#" onclick="SetFrame('cplthzb','Stat/StBroughtBack.aspx','��Ʒ���˻��ܱ�');">��Ʒ���˻��ܱ�</a>
		        <a href="#" onclick="SetFrame('sqrkthzb','Stat/StBroughtBacka.aspx','���������˻��ܱ�');">���������˻��ܱ�</a>
	        </div>
        </div>
        <div id="menu_s_sub_13" class="KsMenu" style="height:170px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:160px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
	            <a href="#" onclick="SetFrame('xsrbb','Stat/StSellDay.aspx','�����ձ���');">�����ձ���</a>
	            <a href="#" onclick="SetFrame('xsybb','Stat/StSellMonth.aspx','�����±���');">�����±���</a>
		        <div class="KsLine"></div>
		        <a href="#" onclick="SetFrame('cpxshzb','Stat/StSellg.aspx','��Ʒ���ۻ��ܱ�');">��Ʒ���ۻ��ܱ�</a>
	            <a href="#" onclick="SetFrame('khxshzb','Stat/StSellc.aspx','�ͻ����ۻ��ܱ�');">�ͻ����ۻ��ܱ�</a>
	            <a href="#" onclick="SetFrame('xsmxhzb','Stat/StSellDe.aspx','������ϸ���ܱ�');">������ϸ���ܱ�</a>
	            <div class="KsLine"></div>
	            <a href="#" onclick="SetFrame('cpthhzb2','Stat/StSellReturng.aspx','��Ʒ�˻����ܱ�');">��Ʒ�˻����ܱ�</a>
	            <a href="#" onclick="SetFrame('khthhzb','Stat/StSellReturnc.aspx','�ͻ��˻����ܱ�');">�ͻ��˻����ܱ�</a>
	            <a href="#" onclick="SetFrame('thmxhzb2','Stat/StSellReturnDe.aspx','�˻���ϸ���ܱ�');">�˻���ϸ���ܱ�</a>
	       </div>
        </div>
        <div id="menu_s_sub_14" class="KsMenu" style="height:573px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:530px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
	            <a href="#" onclick="SetFrame('fwrbb','Stat/StServiceDay.aspx','�����ձ���');">�����ձ���</a>
		        <a href="#" onclick="SetFrame('fwybb','Stat/StServiceMon.aspx','�����±���');">�����±���</a>
	            <div class="KsLine"></div>
	            <a href="#" onclick="SetFrame('fwhzb','Stat/StServicec.aspx','������ܱ�');">������ܱ�</a>
		        <a href="#" onclick="SetFrame('fwmxb','Stat/StServiceDe.aspx','������ϸ��');">������ϸ��</a>
		        <div class="KsLine"></div>
		        <a href="#" onclick="SetFrame('fwxmhzb','Stat/StSerItem.aspx','������Ŀ���ܱ�');">������Ŀ���ܱ�</a>
		        <a href="#" onclick="SetFrame('fuxmmxb','Stat/StSerItemDe.aspx','������Ŀ��ϸ��');">������Ŀ��ϸ��</a>
	            <div class="KsLine"></div>
	            <a href="#" onclick="SetFrame('fwdgl','Stat/StBillView.aspx','���񵥸���');">���񵥸���</a>
		        <a href="#" onclick="SetFrame('fwdfb','Stat/StBillFrom.aspx','���񵥷ֲ�');">���񵥷ֲ�</a>
		        <a href="#" onclick="SetFrame('jsyyj','Stat/StTechnician.aspx','����Աҵ��');">����Աҵ��</a>
		        <a href="#" onclick="SetFrame('jsygzrz','Stat/StDateSer.aspx','����Ա������־');">����Ա������־</a>
		        <a href="#" onclick="SetFrame('cqdtj','Stat/StExtServices.aspx','���ڵ�ͳ��');">���ڵ�ͳ��</a>
		        <a href="#" onclick="SetFrame('fwddt','Stat/StSerMap.aspx','���񵥵�ͼ');">���񵥵�ͼ</a>
		        <a href="#" onclick="SetFrame('fuxmmxb','Stat/StSerMaterial.aspx','���񱸼����ܱ�');">���񱸼����ܱ�</a>
		        <a href="#" onclick="SetFrame('bjmxhzb','Stat/MaterialDe.aspx','������ϸ���ܱ�');">������ϸ���ܱ�</a>
		        <a href="#" onclick="SetFrame('bjltmxb','Stat/StSerBroughtBack.aspx','����������ϸ��');">����������ϸ��</a>
		        <a href="#" onclick="SetFrame('bjltmxbpm','Stat/MaterialDeByGoods.aspx','����(�ֿ�)���ܱ�');">����(�ֿ�)���ܱ�</a>
		        <a href="#" onclick="SetFrame('bjltmxbywy','Stat/MaterialDeByAppOperator.aspx','����(������)���ܱ�');">����(������)���ܱ�</a>
		        <div class="KsLine"></div>
		        <a href="#" onclick="SetFrame('fwhtxsb','Stat/stSerContract.aspx','ά����ͬ��ʱ��');">ά����ͬ��ʱ��</a>
		        <a href="#" onclick="SetFrame('wbjqwxcb','Stat/StSerWarranty.aspx','ά�����ڻ���ά�޳ɱ�');">ά�����ڻ���ά�޳ɱ�</a>
		        <a href="#" onclick="SetFrame('wbwjqwxcb','Stat/StSerOutWarranty.aspx','ά���������ά�޳ɱ�');">ά���������ά�޳ɱ�</a>
		        <a href="#" onclick="SetFrame('fwcb','Stat/StSerCosts.aspx','����ɱ�');">����ɱ�</a>
		        <div class="KsLine"></div>
		        <a href="#" onclick="SetFrame('xpfbtb','Stat/StRepairDis.aspx','��Ʒ�ֲ�ͼ��');">��Ʒ�ֲ�ͼ��</a>
		        <a href="#" onclick="SetFrame('gzfbtb','Stat/StFaultDis.aspx','���Ϸֲ�ͼ��');">���Ϸֲ�ͼ��</a>
		        <a href="#" onclick="SetFrame('gztjb','Stat/stSerTakeSteps.aspx','����ͳ�Ʊ�');">����ͳ�Ʊ�</a>
		        <a href="#" onclick="SetFrame('clcsfbtb','Stat/StTakeStepsDis.aspx','�����ʩ�ֲ�ͼ');">�����ʩ�ֲ�ͼ</a>
		        <div class="KsLine"></div>
		        <a href="#" <%=menu[151] %> onclick="SetFrame('jsyfxhzb','Stat/StTecbRepair.aspx','����Ա���޻��ܱ�');">����Ա���޻��ܱ�</a>
		        <a href="#" <%=menu[151] %> onclick="SetFrame('jsycfwxl','Stat/StTecRepairRate.aspx','����Ա�ظ�ά����');">����Ա�ظ�ά����</a>
	        </div>
        </div>
        <div id="menu_s_sub_15" class="KsMenu" style="height:42px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:40px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" onclick="SetFrame('jsdhzb','Stat/StLeaseCharge.aspx','���㵥���ܱ�');">���㵥���ܱ�</a>
		        <a href="#" onclick="SetFrame('jsdmxb','Stat/StLeaseChargeDe.aspx','���㵥��ϸ��');">���㵥��ϸ��</a>
	        </div>
        </div>
        <div id="menu_s_sub_16" class="KsMenu" style="height:63px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:60px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
	            <a href="#" onclick="SetFrame('khzzqk','Stat/StCustomerAdd.aspx','�ͻ��������');">�ͻ��������</a>
	            <a href="#" onclick="SetFrame('khjzph','Stat/StCusValueList.aspx','�ͻ���ֵ����');">�ͻ���ֵ����</a>
	            <a href="#" <%=menu[159] %> onclick="SetFrame('khgzhz','Stat/StCusTrack.aspx','�ͻ����ٻ���');">�ͻ����ٻ���</a>
	        </div>
        </div>
        <div id="menu_s_sub_17" class="KsMenu" style="height:257px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:210px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" onclick="SetFrame('szrbb','Stat/StDayInTo.aspx','��֧�ձ���');">��֧�ձ���</a>
		        <a href="#" onclick="SetFrame('szybb','Stat/StMonthInTo.aspx','��֧�±���');">��֧�±���</a>
		        <div class="KsLine"></div>
		        <a href="#" onclick="SetFrame('skdhzb','Stat/StIncome.aspx','�տ���ܱ�');">�տ���ܱ�</a>
		        <a href="#" onclick="SetFrame('skdmxb','Stat/StIncomeDe.aspx','�տ��ϸ��');">�տ��ϸ��</a>
		        <div class="KsLine"></div>
		        <a href="#" onclick="SetFrame('fkdhzb','Stat/StPay.aspx','������ܱ�');">������ܱ�</a>
		        <a href="#" onclick="SetFrame('fkdmxb','Stat/StPayDe.aspx','�����ϸ��');">�����ϸ��</a>
		        <div class="KsLine"></div>
		        <a href="#" onclick="SetFrame('ysyfhzb','Stat/StArr.aspx','Ӧ��Ӧ�����ܱ�');">Ӧ��Ӧ�����ܱ�</a>
		        <a href="#" onclick="SetFrame('ysyfmxb','Stat/StArrDe.aspx','Ӧ��Ӧ����ϸ��');">Ӧ��Ӧ����ϸ��</a>
		        <a href="#" onclick="SetFrame('ysyfzlb','Stat/StArrAge.aspx','Ӧ��Ӧ�������');">Ӧ��Ӧ�������</a>
		        <a href="#" onclick="SetFrame('ysyfhzb','Stat/StArrCanl.aspx','Ӧ��Ӧ�����ʱ�');">Ӧ��Ӧ�����˱�</a>
		        <div class="KsLine"></div>
		        <a href="#" onclick="SetFrame('bxhzb','Stat/ExpenseDe.aspx','�������ܱ�');">�������ܱ�</a>
		        <a href="#" onclick="SetFrame('bxmxb','Stat/ExpenseDetail.aspx','������ϸ��');">������ϸ��</a>
		        <div class="KsLine"></div>
	        </div>
        </div>
        <div id="menu_s_sub_18" class="KsMenu" style="height:168px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:160px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" onclick="SetFrame('ywqsfx','Stat/AnCurrent.aspx','ҵ�����Ʒ���');">ҵ�����Ʒ���</a>
		        <a href="#" onclick="SetFrame('gzjdfx','Stat/AnProgress.aspx','�������ȷ���');">�������ȷ���</a>
		        <a href="#" onclick="SetFrame('skfsfx','Stat/AnIncomeType.aspx','�տʽ����');">�տʽ����</a>
		        <a href="#" onclick="SetFrame('qxyyfx','Stat/AnCancelReason.aspx','ȡ��ԭ�����');">ȡ��ԭ�����</a>
		        <a href="#" onclick="SetFrame('fwlbfx','Stat/AnOperationType.aspx','����������');">����������</a>
		        <a href="#" onclick="SetFrame('slfsfx','Stat/AnTakeType.aspx','����ʽ����');">����ʽ����</a>
		        <a href="#" onclick="SetFrame('khlyfx','Stat/AnSatisCusFrom.aspx','�ͻ���Դ����');">�ͻ���Դ����</a>
		        <a href="#" onclick="SetFrame('khlbfx','Stat/AnSatisCusClass.aspx','�ͻ�������');">�ͻ�������</a>
	        </div>
        </div>
    </div>
    <div id="menu_s_11" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:190px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_11s" class="KsMenu2">
			<a href="#" onclick="ShowDialog(600, 380, 'Basic/StaffDeptAdm.aspx', 'Ա������');">Ա������</a>
			<a href="#" onclick="SetFrame('ygml','Basic/StaffAdm.aspx','Ա��Ŀ¼');">Ա��Ŀ¼</a>
			<a href="#" onclick="SetFrame('ckml','Basic/StockListAdm.aspx','�ֿ�Ŀ¼');">�ֿ�Ŀ¼</a>
			<a href="#" onclick="ShowDialog(600, 380, 'Basic/StockLocAdm.aspx','��λĿ¼');">��λĿ¼</a>
			<a href="#" onclick="ShowDialog(600, 380, 'Basic/DeviceConfItem.aspx', '����������');">����������</a>
			<a href="#" onclick="SetFrame('wlcs','Basic/SupplierAdm.aspx','��������');">��������</a>
			<div class="KsLine"></div>
			<a href="#" onclick="ShowDialog(600, 380, 'Basic/AccountAdm.aspx', '��֧�ʻ�');">��֧�ʻ�</a>
			<a href="#" onclick="ShowDialog(600, 380, 'Basic/ChargeItemAdm.aspx', '��֧��Ŀ');">��֧��Ŀ</a>
			<a href="#" onclick="ShowDialog(600, 380, 'Basic/ExpenseItemAdm.aspx', '������Ŀ');">������Ŀ</a>
			<a href="#" onclick="ShowDialog(600, 380, 'Basic/ShippingStyleAdm.aspx', '���˷�ʽ');">���˷�ʽ</a>
		</div>
    </div>    
    
    <div id="menu_s_12" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:<%=sysHeight %>px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_12s" class="KsMenu2">
			<a href="#" style="display:<%=showNO %>" onclick="ShowDialog(620,200,'System/NOList.aspx','�������');">�������</a>
			<a href="#" <%=menu[205] %> onclick="SetFrame('qxgl','System/RightAdm.aspx','Ȩ�޹���');">Ȩ�޹���</a>
			<a href="#" <%=menu[205] %> onclick="SetFrame('yhgl','System/UserManage.aspx','�û�����');">�û�����</a>
			<a href="#" onclick="ShowDialog(600, 190, 'System/UserPwd.aspx', '�޸�����');">�޸�����</a>
			<div class="KsLine"></div>
			<a href="#" onclick="ChkExit();">�˳�ϵͳ</a>
		</div>
    </div>
    
    <div id="menu_s_13" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:85px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_13s" class="KsMenu2">
			<a href="#" <%=menu[205] %> onclick="ShowDialog(800,520,'Tool/Layout.aspx','��񲼾�');">��񲼾�</a>
			<a href="#" onclick="ShowDialog(640, 480, 'Tool/ToolBar.aspx', '����������');">����������</a>
			<div class="KsLine"></div>
			<a href="#" onclick="ShowDialog(600, 350, 'Tool/SmsAdm.aspx','���Ͷ���');">���Ͷ���</a>
			<a href="#" onclick="ShowDialog(600, 310, 'Tool/Printtmp.aspx', '��ӡģ��');">��ӡģ��</a>
			<div style="display:<%=showOL %>" class="KsLine"></div>
			<a href="#" style="display:<%=showOL %>" onclick="ShowDialog(600, 310, 'Tool/OnlineList.aspx', '�����û�');">�����û�</a>
		</div>
    </div>
    
    <div id="menu_s_14"  class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:85px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_14s" class="KsMenu2">
			<a onclick="Sethidden1();" href="http://www.differsoft.com" target="_blank">�ٷ���վ</a>
			<a onclick="Sethidden1();" href="http://bbs.differsoft.com/" target="_blank">�������</a>
			<a onclick="Sethidden1();" href="http://www.differsoft.com/production/files/Prodoc/WTnet_IT_Help.mht" target="_blank">���߰���</a>
			<div class="KsLine"></div>
			<a onclick="ShowDialog(500, 228, '../Headquarters/About.aspx', '����');" href="#">����</a>
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
<!--�ര���б�-->
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
<!--���صȴ�����-->
<div id='Loading' style="position:absolute;z-index:1000;top:0px;left:0px;width:100%;height:100%;background:#fff;text-align:center"><img src='../Public/images/loading.gif' style='margin-top:150px'></div>

<div id="divDialog">
    <div id="divTitle">
    	<div id="divIco"><div id="divTitleName"></div></div>
     	<div id="divClose" onclick="CloseDialog();">
     		<img alt="�ر�" src="../Public/Images/close.gif" style="cursor: default;" title="�ر�" />
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
     		<img alt="�ر�" src="../Public/Images/close.gif" style="cursor: default;" title="�ر�" />
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
 		    <img alt="�ر�" src="../Public/Images/close.gif" style="cursor: default;" title="�ر�" />
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
 		    <img alt="�ر�" src="../Public/Images/close.gif" style="cursor: default;" title="�ر�" />
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
    <span style="color:#0000ff">����������,���Ժ�...</span>
    <a id="btntest" href="#" style="padding-left:5px; color:#000;">ȡ��</a>
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
