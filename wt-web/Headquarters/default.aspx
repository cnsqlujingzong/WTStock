<%@ page language="C#"  CodeFile="default.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Default" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title><%=strTitle %>�ܲ�ƽ̨</title>
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
    if(confirm("ȷ��Ҫ�˳��ܲ�ϵͳ��"))
    {
        document.getElementById("btnExit").click();
    }
}

function ChkClose()
{
    event.returnValue="";
}
/*-----�˵�����-----------*/
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
  AddWin('YWDH','ҵ�񵼺�','Mynavigation/all.html',0,0,1,0,0);
  ChangeWin();
��<%=_Reg%>
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
        <li <%=moduln[0] %>><a href="#" onclick="<%=module[0] %>ClickSetmenu('<%=modulm[0] %>','<%=modulh[0] %>','menu_s_1');" onmouseover="<%=module[0] %>Setmenu('<%=modulm[0] %>','<%=modulh[0] %>','menu_s_1');">�ֿ����</a></li><li <%=moduln[1] %>><a href="#" onclick="<%=module[1] %>ClickSetmenu('<%=modulm[1] %>','<%=modulh[1] %>','menu_s_2');" onmouseover="<%=module[1] %>Setmenu('<%=modulm[1] %>','<%=modulh[1] %>','menu_s_2');">�ɹ�����</a></li><li <%=moduln[2] %>><a href="#" onclick="<%=module[2] %>ClickSetmenu('<%=modulm[2] %>','<%=modulh[2] %>','menu_s_3');" onmouseover="<%=module[2] %>Setmenu('<%=modulm[2] %>','<%=modulh[2] %>','menu_s_3');">���۹���</a></li><li <%=moduln[3] %>><a href="#" onclick="<%=module[3] %>ClickSetmenu('<%=modulm[3] %>','<%=modulh[3] %>','menu_s_4');" onmouseover="<%=module[3] %>Setmenu('<%=modulm[3] %>','<%=modulh[3] %>','menu_s_4');">�������</a></li><li <%=moduln[4] %>><a style="line-height:23px;" href="#" onclick="<%=module[4] %>ClickSetmenu('<%=modulm[4] %>','<%=modulh[4] %>','menu_s_5');" onmouseover="<%=module[4] %>Setmenu('<%=modulm[4] %>','<%=modulh[4] %>','menu_s_5');">����/ȫ��</a></li><li <%=moduln[5] %>><a href="#" onclick="<%=module[5] %>ClickSetmenu('<%=modulm[5] %>','<%=modulh[5] %>','menu_s_6');" onmouseover="<%=module[5] %>Setmenu('<%=modulm[5] %>','<%=modulh[5] %>','menu_s_6');">�ͻ���ϵ</a></li><li <%=moduln[6] %>><a href="#" onclick="<%=module[6] %>ClickSetmenu('<%=modulm[6] %>','<%=modulh[6] %>','menu_s_7');" onmouseover="<%=module[6] %>Setmenu('<%=modulm[6] %>','<%=modulh[6] %>','menu_s_7');">�ʿ����</a></li><li <%=moduln[7] %>><a href="#" onclick="<%=module[7] %>ClickSetmenu('<%=modulm[7] %>','<%=modulh[7] %>','menu_s_8');" onmouseover="<%=module[7] %>Setmenu('<%=modulm[7] %>','<%=modulh[7] %>','menu_s_8');">�շ�����</a></li><li <%=moduln[8] %>><a href="#" onclick="<%=module[8] %>ClickSetmenu('<%=modulm[8] %>','<%=modulh[8] %>','menu_s_9');" onmouseover="<%=module[8] %>Setmenu('<%=modulm[8] %>','<%=modulh[8] %>','menu_s_9');" style="width:55px; line-height:23px;">�칫OA</a></li><li <%=moduln[9] %>><a href="#" onclick="<%=module[9] %>ClickSetmenu('<%=modulm[9] %>','<%=modulh[9] %>','menu_s_10');" onmouseover="<%=module[9] %>Setmenu('<%=modulm[9] %>','<%=modulh[9] %>','menu_s_10');">�ڳ�¼��</a></li><li <%=moduln[10] %>><a href="#" onclick="<%=module[10] %>ClickSetmenu('<%=modulm[10] %>','<%=modulh[10] %>','menu_s_11');" onmouseover="<%=module[10] %>Setmenu('<%=modulm[10] %>','<%=modulh[10] %>','menu_s_11');">ͳ�Ʒ���</a></li><li <%=moduln[11] %>><a href="#" onclick="<%=module[11] %>ClickSetmenu('<%=modulm[11] %>','<%=modulh[11] %>','menu_s_12');" onmouseover="<%=module[11] %>Setmenu('<%=modulm[11] %>','<%=modulh[11] %>','menu_s_12');">��������</a></li><li><a href="#" onclick="ClickSetmenu('<%=modulm[12] %>','<%=modulh[12] %>','menu_s_13');" onmouseover="Setmenu('<%=modulm[12] %>','<%=modulh[12] %>','menu_s_13');">ϵͳά��</a></li><li><a href="#" onclick="ClickSetmenu('<%=modulm[13] %>','<%=modulh[13] %>','menu_s_14');" onmouseover="Setmenu('<%=modulm[13] %>','<%=modulh[13] %>','menu_s_14');" style="width:35px;">����</a></li>
<%--        <li><a href="#" onclick="ClickSetmenu('<%=modulm[14] %>','<%=modulh[14] %>','menu_s_15');" onmouseover="Setmenu('<%=modulm[14] %>','<%=modulh[14] %>','menu_s_15');" style="width:35px;">����</a></li>--%>
 <%--       <li><a href ="http://www.18bg.com" target ="_blank">18�ư칫</a></li>--%>
    </ul>
    
    <div id="menu_s_1" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:298px;width:162px;" frameborder="0"></iframe>
         <div id="menu_s_1s" class="KsMenu2">
            <a href="#" <%=menu[0] %> onclick="ShowDialog(600, 380, 'Stock/GoodsClassAdm.aspx', '��Ʒ����');">��Ʒ����</a>
            <a href="#" <%=menu[1] %> onclick="SetFrame('cpml','Stock/GoodsAdm.aspx','��ƷĿ¼');">��ƷĿ¼</a>
            <div class="KsLine"></div>
            <a href="#" <%=menu[2] %> onclick="SetFrame('dqkc','Stock/StockAdm.aspx','��ǰ���');">��ǰ���</a>
            <a href="#" <%=menu[3] %> onclick="SetFrame('fpkc','Stock/StockrAdm.aspx','��Ʒ���');">��Ʒ���</a>
            <a href="#" <%=menu[4] %> onclick="SetFrame('fckc','Stock/DeptStock.aspx','�ֲֿ��');">�ֲֿ��</a>
            <a href="#" <%=menu[5] %> onclick="SetFrame('xlhk','Stock/SNAdm.aspx','���кſ�');">���кſ�</a>
            <div class="KsLine"></div>
            <a href="#" <%=menu[6] %> onclick="SetFrame('qtrk','Stock/StockIn.aspx','�������');">�������</a>			
            <a href="#" <%=menu[7] %> onclick="SetFrame('qtck','Stock/StockOut.aspx','��������');">��������</a>
            <a href="#" <%=menu[8] %> onclick="SetFrame('llkd','Stock/BroughtBack.aspx','���˿���');" onmouseover="Sethiddensub('menu_s_sub_22');">���˿���</a>
            <div class="KsLine"></div>
            <a href="#" id="row22" onmouseover="Sethiddensub('menu_s_sub_21');Setmenu_sub('190','158','menu_s_sub_22');">�ڲ�����</a>
            <a href="#" id="row21" onmouseover="Sethiddensub('menu_s_sub_22');Setmenu_sub('211','158','menu_s_sub_21');">�������</a>
            <div class="KsLine"></div>
            <a href="#" <%=menu[13] %> id="row1" onmouseover="Setmenu_sub('<%=modulh_s[0] %>','158','menu_s_sub_1');">�������</a>
			<a href="#" <%=menu[14] %> id="row2" onmouseover="Setmenu_sub('<%=modulh_s[1] %>','158','menu_s_sub_2');">�ֿ�ҵ��</a>
			<a href="#" <%=menu[15] %> id="row3" onmouseover="Setmenu_sub('<%=modulh_s[2] %>','158','menu_s_sub_3');">���ݲ�ѯ</a>
		</div>
		<div id="menu_s_sub_21" class="KsMenu" style="height:84px;z-index:9999;">
		    <iframe style="position: absolute;z-index: -2;height:80px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" <%=menu[9] %>  onclick="SetFrame('dbsq','Stock/AllocateApp.aspx','��������');">��������</a>
                <a href="#" <%=menu[10] %> onclick="SetFrame('dbsh','Stock/AllocateAppChk.aspx','�������');">�������</a>
                <a href="#" <%=menu[11] %> onclick="SetFrame('dbfh','Stock/AllocateRec.aspx','��������');">��������</a>
                <a href="#" <%=menu[12] %> onclick="SetFrame('dbqs','Stock/AllocateSigned.aspx','����ǩ��');" onmouseover="Sethiddensub('menu_s_sub_1');">����ǩ��</a>
		    </div>
		</div>
		<div id="menu_s_sub_22" class="KsMenu" style="height:63px;z-index:9999;">
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
		        <a href="#" <%=menu[16] %> onclick="SetFrame('jckd','Stock/LendingAdd.aspx','�������');">�������</a>
                <a href="#" <%=menu[17] %> onclick="SetFrame('jccx','Stock/SchLendingReturn.aspx','�����ѯ');">�����ѯ</a>
		    </div>
		</div>
		
		<div id="menu_s_sub_2" class="KsMenu" style="height:63px;z-index:9999;">
		    <iframe style="position: absolute;z-index: -2;height:60px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" <%=menu[18] %> onclick="SetFrame('cxzz','Stock/DisBiling.aspx','��װ����');">��װ����</a>
                <a href="#" <%=menu[19] %> onclick="SetFrame('tjkd','Stock/Regulate.aspx','���ۿ���');">���ۿ���</a>
                <a href="#" <%=menu[20] %> onclick="SetFrame('pdkd','Stock/StockCheck.aspx','�̵㿪��');">�̵㿪��</a>
		    </div>
		</div>
		<div id="menu_s_sub_3" class="KsMenu" style="height:168px;z-index:9999;">
		    <iframe style="position: absolute;z-index: -2;height:160px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" <%=menu[21] %> onclick="SetFrame('rkdcx','Stock/SchStockIn.aspx','��ⵥ��ѯ');">��ⵥ��ѯ</a>
		        <a href="#" <%=menu[22] %> onclick="SetFrame('ckdcx','Stock/SchStockOut.aspx','���ⵥ��ѯ');">���ⵥ��ѯ</a>
				<a href="#" <%=menu[23] %> onclick="SetFrame('ltdcx','Stock/SchBroughtBack.aspx','���˵���ѯ');">���˵���ѯ</a>
				<a href="#" <%=menu[24] %> onclick="SetFrame('nbdbdcx','Stock/SchInnerAllocate.aspx','�ڲ���������ѯ');">�ڲ���������ѯ</a>
				<a href="#" <%=menu[24] %> onclick="SetFrame('dbdcx','Stock/SchAllocate.aspx','�����������ѯ');">�����������ѯ</a>
				<a href="#" <%=menu[25] %> onclick="SetFrame('czdcx','Stock/SchDisBiling.aspx','��װ����ѯ');">��װ����ѯ</a>
				<a href="#" <%=menu[26] %> onclick="SetFrame('tjdcx','Stock/SchRegulate.aspx','���۵���ѯ');">���۵���ѯ</a>
				<a href="#" <%=menu[27] %> onclick="SetFrame('pddcx','Stock/SchStockCheck.aspx','�̵㵥��ѯ');">�̵㵥��ѯ</a>
			</div>
		</div>
    </div>
     <div id="menu_s_2" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:105px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_2s" class="KsMenu2">
			<a href="#" <%=menu[28] %> onclick="SetFrame('cgkd','Purchase/PurchaseAdd.aspx', '�ɹ�����');">�ɹ�����</a>
			<a href="#" <%=menu[29] %> onclick="SetFrame('cgth','Purchase/PurReturn.aspx', '�ɹ��˻�');">�ɹ��˻�</a>
			<a href="#" <%=menu[30] %> onclick="SetFrame('cgdcx','Purchase/SchPurchase.aspx','�ɹ�����ѯ');">�ɹ�����ѯ</a>
			<div class="KsLine"></div>
            <a href="#" <%=menu[31] %> onclick="SetFrame('cgdd','Purchase/PurPlanAdd.aspx', '�ɹ�����');">�ɹ�����</a>
			<a href="#" <%=menu[32] %> onclick="SetFrame('cgddcx','Purchase/SchPurPlan.aspx','�ɹ�������ѯ');">�ɹ�������ѯ</a>
		</div>
    </div>
    
    <div id="menu_s_3" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:105px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_3s" class="KsMenu2">
			<a href="#" <%=menu[33] %> onclick="SetFrame('xskd','Sell/SellAdd.aspx', '���ۿ���');">���ۿ���</a>
			<a href="#" <%=menu[34] %> onclick="SetFrame('xsth','Sell/SellReturn.aspx', '�����˻�');">�����˻�</a>
			<a href="#" <%=menu[35] %> onclick="SetFrame('xsdcx','Sell/SchSell.aspx','���۵���ѯ');">���۵���ѯ</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[36] %> onclick="SetFrame('xsdd','Sell/SellPlanAdd.aspx', '���۶���');">���۶���</a>
			<a href="#" <%=menu[37] %> onclick="SetFrame('xsddcx','Sell/SchSellPlan.aspx','���۶�����ѯ');">���۶�����ѯ</a>
		</div>
    </div>
    
    <div id="menu_s_4" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:191px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_4s" class="KsMenu2">
            <a href="#" <%=menu[38] %> onclick="SetFrame('bxsh','Services/ServicesNet.aspx', '�������');">�������</a>
            <a href="#" <%=menu[39] %> onclick="SetFrame('sqqr','Services/ServicesConf.aspx','����ȷ��');">����ȷ��</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[40] %> onclick="SetFrame('fwzx','Services/ServicesAllot.aspx','��������')" onmouseover="Sethiddensub('menu_s_sub_4');">��������</a>
            <div class="KsLine"></div>
            <a href="#" <%=menu[41] %> id="row4" onmouseover="Setmenu_sub('<%=modulh_s[3] %>','158','menu_s_sub_4');">���޹���</a>
			<a href="#" <%=menu[42] %> onclick="SetFrame('wgjs','Services/ServicesBln.aspx','�깤����');" onmouseover="Sethiddensub('menu_s_sub_4');">�깤����</a>
			<a href="#" <%=menu[43] %> onclick="SetFrame('shgb','Services/ServicesOver.aspx','��˹ر�');">��˹ر�</a>
            <a href="#" <%=menu[44] %> onclick="SetFrame('fwhf','Services/ServicesCall.aspx','����ط�');">����ط�</a>
            <div class="KsLine"></div>
            <a href="#" <%=menu[45] %> onclick="SetFrame('fwdcx','Services/SchServices.aspx','���񵥲�ѯ');">���񵥲�ѯ</a>
            <a href="#" <%=menu[45] %> onclick="SetFrame('xxfwdcx','Services/SchFullServices.aspx','��ϸ����');">��ϸ����</a>
	    </div>
	    <div id="menu_s_sub_4" class="KsMenu" style="height:63px;z-index:9999;">
		    <iframe style="position: absolute;z-index: -2;height:60px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" <%=menu[46] %> onclick="SetFrame('sxfh','Services/ServicesSnd.aspx','���޷���');">���޷���</a>
		        <a href="#" <%=menu[47] %> onclick="SetFrame('shjs','Services/ServicesRcv.aspx','�ջ�����');">�ջ�����</a>
		        <a href="#" <%=menu[48] %> onclick="SetFrame('lssx','Services/HistorySnd.aspx','��ʷ����');">��ʷ����</a>
	        </div>
        </div>
    </div>
     <div id="menu_s_5" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:150px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_5s" class="KsMenu2">
			<a href="#" <%=menu[49] %> onclick="SetFrame('xjyw','Lease/LeaseAdd.aspx', '�½�ҵ��');">�½�ҵ��</a>
			<a href="#" <%=menu[49] %> onclick="SetFrame('ywsh','Lease/LeaseChk.aspx', 'ҵ�����');">ҵ�����</a>
			<div class="KsLine"></div>			
			<a href="#" <%=menu[50] %> onclick="SetFrame('cbdd','Lease/MeterReading.aspx', '����Ǽ�');">����Ǽ�</a>
			<a href="#" <%=menu[51] %> onclick="SetFrame('sbgh','Lease/ChangeMachine.aspx', '�豸�˻�');">�豸�˻�</a>
			<a href="#" <%=menu[52] %> onclick="SetFrame('htjy','Lease/Release.aspx', '��ͬ��Լ');">��ͬ��Լ</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[53] %> onclick="SetFrame('jssh','Lease/Settlement.aspx', '�������');">�������</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[54] %> onclick="SetFrame('ywcx','Lease/SchLease.aspx','ҵ���ѯ');">ҵ���ѯ</a>
		</div>
    </div>
    <div id="menu_s_6" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:213px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_6s" class="KsMenu2">
            <a href="#" <%=menu[55] %> onclick="ShowDialog(600, 380, 'Customer/CusClassAdm.aspx', '�ͻ�����');">�ͻ�����</a>
			<a href="#" <%=menu[56] %> onclick="ShowDialog(600, 380, 'Customer/MembersAdm.aspx', '��Ա����');">��Ա����</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[57] %> onclick="SetFrame('khda','Customer/CusListAdm.aspx','�ͻ�����');">�ͻ�����</a>
			<a href="#" <%=menu[58] %> onclick="SetFrame('jqda','Customer/DeviceListAdm.aspx','��������');">��������</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[59] %> onclick="SetFrame('fwht','Customer/MaintenanceContract.aspx','�����ͬ');">�����ͬ</a>
			<a href="#" <%=menu[60] %> onclick="SetFrame('bypg','Customer/MaintenanceAllot.aspx','�����ɹ�');">�����ɹ�</a>
			<a href="#" <%=menu[61] %> onclick="SetFrame('khgz','Customer/CustomerTrack.aspx','�ͻ�����');">�ͻ�����</a>
			<a href="#" <%=menu[62] %> onclick="SetFrame('hcgz','Customer/ConsumablesTrack.aspx','�Ĳĸ���');">�Ĳĸ���</a>
			<a href="#" <%=menu[63] %> onclick="SetFrame('tscl','Customer/ComplaintAdm.aspx','Ͷ�߹���');">Ͷ�߹���</a>
		    <div class="KsLine"></div>
		    <a href="#" <%=menu[64] %> onclick="SetFrame('bxhygl','Customer/AssAdm.aspx','���޻�Ա����');">���޻�Ա����</a>
		</div>
    </div>
    
    <div id="menu_s_7" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:128px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_7s" class="KsMenu2">
            <a href="#" <%=menu[65] %> id="row5" onmouseover="Setmenu_sub('<%=modulh_s[4] %>','158','menu_s_sub_5');">�տ��</a>
            <a href="#" <%=menu[66] %> id="row6" onmouseover="Setmenu_sub('<%=modulh_s[5] %>','158','menu_s_sub_6');">�����</a>
            <a href="#" <%=menu[67] %> onclick="SetFrame('sfkcx','Financial/IncomeAdm.aspx','�ո����ѯ');" onmouseover="Sethiddensub('menu_s_sub_6');">�ո����ѯ</a>
            <div class="KsLine"></div>
            <a href="#" <%=menu[68] %> onclick="SetFrame('ysyf','Financial/ArrearageAdm.aspx','Ӧ��Ӧ��');" onmouseover="Sethiddensub('menu_s_sub_7');">Ӧ��Ӧ��</a>
            <div class="KsLine"></div>
            <a href="#" <%=menu[69] %> id="row7"  onmouseover="Setmenu_sub('<%=modulh_s[6] %>','158','menu_s_sub_7');">�ֽ�����</a>
            <a href="#" <%=menu[70] %> id="row8" onmouseover="Sethiddensub('menu_s_sub_7');Setmenu_sub('<%=modulh_s[7] %>','158','menu_s_sub_8');">���ñ���</a>
		</div>
		<div id="menu_s_sub_5" class="KsMenu" style="height:63px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:60px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
	            <a href="#" <%=menu[71] %> onclick="SetFrame('sysk','Financial/IncomeAdd.aspx', '��Ӧ�տ�');">��Ӧ�տ�</a>
	            <a href="#" <%=menu[72] %> onclick="SetFrame('sysk2','Financial/AdvanceInAdd.aspx', '��Ԥ�տ�');">��Ԥ�տ�</a>
	            <a href="#" <%=menu[73] %> onclick="SetFrame('qtsk','Financial/OtherInAdd.aspx', '�����տ�');">�����տ�</a>
            </div>
        </div>
        <div id="menu_s_sub_6" class="KsMenu" style="height:63px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:60px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
	            <a href="#" <%=menu[74] %> onclick="SetFrame('fyfk','Financial/PaymentAdd.aspx','��Ӧ����');">��Ӧ����</a>
	            <a href="#" <%=menu[75] %> onclick="SetFrame('fyfk2','Financial/AdvancePayAdd.aspx','��Ԥ����');">��Ԥ����</a>
	            <a href="#" <%=menu[76] %> onclick="SetFrame('qtfk','Financial/OtherPayAdd.aspx','��������');">��������</a>
            </div>
        </div>
        <div id="menu_s_sub_7" class="KsMenu" style="height:42px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:40px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
                <a href="#" <%=menu[77] %> onclick="SetFrame('zhzz','Financial/Transfer.aspx','�ʻ�ת��');">�ʻ�ת��</a>
	            <a href="#" <%=menu[78] %> onclick="SetFrame('zhhz','Financial/IncomeBank.aspx','�ʻ�����');">�ʻ�����</a>
            </div>
        </div>
        
        <div id="menu_s_sub_8" class="KsMenu" style="height:106px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:100px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
                <a href="#" <%=menu[79] %> onclick="SetFrame('bxsq','Financial/Expense.aspx','��������');">��������</a>
	            <a href="#" <%=menu[80] %> onclick="SetFrame('zgsh','Financial/ChkExpense.aspx','�������');">�������</a>
	            <a href="#" <%=menu[81] %> onclick="SetFrame('kxff','Financial/PayExpense.aspx','�����');">�����</a>
	            <div class="KsLine"></div>
	            <a href="#" <%=menu[82] %> onclick="SetFrame('bxcx','Financial/SchExpense.aspx','������ѯ');">������ѯ</a>
	            <a href="#" <%=menu[82] %> onclick="SetFrame('bxmxd','Financial/SchFullExpense.aspx','������ϸ');">������ϸ</a>
            </div>
        </div>
    </div>
    
    <div id="menu_s_8" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:80px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_8s" class="KsMenu2">
			<a href="#" <%=menu[83] %> onclick="SetFrame('xjfh','Receive/SndNew.aspx', '�½�����');">�½�����</a>
			<a href="#" <%=menu[84] %> onclick="SetFrame('fhqr','Receive/SndSure.aspx','����ȷ��');">����ȷ��</a>
			<a href="#" <%=menu[85] %> onclick="SetFrame('qsqr','Receive/SndSign.aspx','ǩ��ȷ��');">ǩ��ȷ��</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[86] %> class="isch" onclick="SetFrame('fhcx','Receive/SndSch.aspx','�շ���ѯ');">�շ���ѯ</a>
		</div>
    </div>

     <div id="menu_s_9" class="KsMenu">
       <iframe style="position: absolute;z-index: -2;height:210px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_9s" class="KsMenu2">
			<a href="#" <%=menu[87] %> onclick="SetFrame('wdgl','Office/DocAdm.aspx','�ĵ�����');">�ĵ�����</a>
			<a href="#" <%=menu[88] %> onclick="SetFrame('gggl','Office/AnnunciateAdm.aspx','�������');">�������</a>
			<a href="#" <%=menu[89] %> onclick="SetFrame('zsgl','Repository/RepositoryAdm.aspx','֪ʶ����');">֪ʶ����</a>
			<a href="#" <%=menu[90] %> onclick="SetFrame('znxj','Office/MailAdm.aspx','վ���ż�');" class="iline" onmouseover="Sethiddensub('menu_s_sub_9');">վ���ż�</a>
			<a href="#" <%=menu[89] %> onclick="SetFrame('xxfk','Office/FeedBackadm.aspx','��Ϣ����');" onmouseover="Sethiddensub('menu_s_sub_23');">��Ϣ����</a>
			<a href="#" <%=menu[89] %> id="row23" onmouseover="Setmenu_sub('103','158','menu_s_sub_23');">��ͬ����</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[91] %> id="row9" onmouseover="Setmenu_sub('<%=modulh_s[8] %>','158','menu_s_sub_9');">���ڹ���</a>
			<a href="#" <%=menu[92] %> onclick="SetFrame('rwgl','Office/TaskAdm.aspx','�������');" onmouseover="Sethiddensub('menu_s_sub_9');">�������</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[93] %> onclick="SetFrame('ggtcmx','Office/TecDeduct.aspx','Ա�������ϸ');">Ա�������ϸ</a>
			<a href="#" <%=menu[94] %> onclick="SetFrame('yckqmx','Office/AttendanceDe.aspx','�쳣������ϸ');">�쳣������ϸ</a>
			<a href="#" <%=menu[95] %> onclick="SetFrame('ygydxz','Office/TecWage.aspx','Ա���¶�н��');">Ա���¶�н��</a>
			<a href="#" <%=menu[96] %> onclick="SetFrame('ygrgzhz','Office/TecDayWork.aspx','Ա����������');">Ա����������</a>
		</div>
	    <div id="menu_s_sub_9" class="KsMenu" style="height:84px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:80px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
                <a href="#" <%=menu[97] %> onclick="ShowDialog(400, 150, 'Office/Absence.aspx', '����ǩ��');">����ǩ��</a>
	            <a href="#" <%=menu[98] %> onclick="SetFrame('qqsh','Office/ChkAttendance.aspx','ȱ�����');">ȱ�����</a>
	            <a href="#" <%=menu[99] %> onclick="SetFrame('kqhz','Office/Attendance.aspx','���ڻ���');">���ڻ���</a>
	            <a href="#" <%=menu[100] %> onclick="ShowDialog(600, 380, 'Office/AbsenceSet.aspx', '��������');">��������</a>
            </div>
        </div>
        <div id="menu_s_sub_23" class="KsMenu" style="height:21px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:21px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2" style="width:140px">
                <a href="#" onclick="SetFrame('xshegl', 'Office/SalesContract.aspx', '���ۺ�ͬ');">���ۺ�ͬ����</a>
            </div>
        </div>
    </div>

    <div id="menu_s_10" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:60px;width:162px;" frameborder="0"></iframe>
         <div id="menu_s_10s" class="KsMenu2">
			<a href="#" <%=menu[101] %> onclick="SetFrame('qckc','BeginAccount/BeginStock.aspx','�ڳ���Ʒ���');" onmouseover="Sethiddensub('menu_s_sub_10');">�ڳ���Ʒ���</a>
			<a href="#" <%=menu[102] %> id="row10" onmouseover="Setmenu_sub('<%=modulh_s[9] %>','158','menu_s_sub_10');">�ڳ�Ӧ��Ӧ��</a>
			<a href="#" <%=menu[103] %> onclick="SetFrame('qcxjyh','BeginAccount/BeginCash.aspx','�ڳ��ֽ�����');" onmouseover="Sethiddensub('menu_s_sub_10');">�ڳ��ֽ�����</a>
		</div>
	    <div id="menu_s_sub_10" class="KsMenu" style="height:63px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:60px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" <%=menu[104] %> onclick="SetFrame('khqcysyf','BeginAccount/CusBeginArr.aspx','�ͻ��ڳ�Ӧ��Ӧ��');">�ͻ��ڳ�Ӧ��Ӧ��</a>
		        <a href="#" <%=menu[105] %> onclick="SetFrame('csqcysyf','BeginAccount/SupBeginArr.aspx','�����ڳ�Ӧ��Ӧ��');">�����ڳ�Ӧ��Ӧ��</a>
		        <a href="#" <%=menu[106] %> onclick="SetFrame('wdqcysyf','BeginAccount/BraBeginArr.aspx','�����ڳ�Ӧ��Ӧ��');">�����ڳ�Ӧ��Ӧ��</a>
	        </div>
        </div>
    </div>
    
    <div id="menu_s_11" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:185px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_11s" class="KsMenu2">
            <a href="#" <%=menu[107] %> id="row11" onmouseover="Setmenu_sub('<%=modulh_s[10] %>','158','menu_s_sub_11');">�ۺ�ҵ�񱨱�</a>
            <a href="#" <%=menu[108] %> id="row12" onmouseover="Setmenu_sub('<%=modulh_s[11] %>','158','menu_s_sub_12');">�ֿ�ҵ�񱨱�</a>
            <a href="#" <%=menu[109] %> id="row13" onmouseover="Setmenu_sub('<%=modulh_s[12] %>','158','menu_s_sub_13');">�ɹ�ҵ�񱨱�</a>
            <a href="#" <%=menu[110] %> id="row14" onmouseover="Setmenu_sub('<%=modulh_s[13] %>','158','menu_s_sub_14');">����ҵ�񱨱�</a>
            <a href="#" <%=menu[111] %> id="row15" onmouseover="Setmenu_sub('<%=modulh_s[14] %>','158','menu_s_sub_15');">����ҵ�񱨱�</a>
            <a href="#" <%=menu[112] %> id="row16" onmouseover="Setmenu_sub('<%=modulh_s[15] %>','158','menu_s_sub_16');">����/ȫ������</a>
            <a href="#" <%=menu[113] %> id="row17" onmouseover="Setmenu_sub('<%=modulh_s[16] %>','158','menu_s_sub_17');">�ͻ���ϵ����</a>
            <a href="#" <%=menu[114] %> id="row18" onmouseover="Setmenu_sub('<%=modulh_s[17] %>','158','menu_s_sub_18');">�ʿ�ҵ�񱨱�</a>
            <a href="#" <%=menu[115] %> id="row19" onmouseover="Setmenu_sub('<%=modulh_s[18] %>','158','menu_s_sub_19');">�����ھ򱨱�</a>
		</div>
		<div id="menu_s_sub_11" class="KsMenu" style="height:42px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:40px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" <%=menu[116] %> onclick="SetFrame('ryyehzb','Stat/StDaySeller.aspx','��Ӫҵ����ܱ�');">��Ӫҵ����ܱ�</a>
		        <a href="#" <%=menu[117] %> onclick="SetFrame('yyyehzb','Stat/StMonthSeller.aspx','��Ӫҵ����ܱ�');">��Ӫҵ����ܱ�</a>
	        </div>
        </div>
        <div id="menu_s_sub_12" class="KsMenu" style="height:210px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:200px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" <%=menu[118] %> onclick="SetFrame('ckrbb','Stat/StStockDay.aspx','�ֿ��ձ���');">�ֿ��ձ���</a>
		        <a href="#" <%=menu[119] %> onclick="SetFrame('ckhzb','Stat/StStock.aspx','�ֿ���ܱ�');">�ֿ���ܱ�</a>
		        <a href="#" <%=menu[120] %> onclick="SetFrame('cprkhzb','Stat/StStockINg.aspx','��Ʒ�����ܱ�');">��Ʒ�����ܱ�</a>
		        <a href="#" <%=menu[121] %> onclick="SetFrame('ckrkhzb','Stat/StStockINs.aspx','�ֿ������ܱ�');">�ֿ������ܱ�</a>
		        <a href="#" <%=menu[122] %> onclick="SetFrame('rkmxhzb','Stat/StStockINDe.aspx','�����ϸ���ܱ�');">�����ϸ���ܱ�</a>
		        <a href="#" <%=menu[123] %> onclick="SetFrame('cpckhzb','Stat/StStockOUTg.aspx','��Ʒ������ܱ�');">��Ʒ������ܱ�</a>
		        <a href="#" <%=menu[124] %> onclick="SetFrame('ckckhzb','Stat/StStockOUTs.aspx','�ֿ������ܱ�');">�ֿ������ܱ�</a>
		        <a href="#" <%=menu[125] %> onclick="SetFrame('ckmxhzb','Stat/StStockOUTDe.aspx','������ϸ���ܱ�');">������ϸ���ܱ�</a>
		        <a href="#" <%=menu[126] %> onclick="SetFrame('cplthzb','Stat/StBroughtBack.aspx','��Ʒ���˻��ܱ�');">��Ʒ���˻��ܱ�</a>
		        <a href="#" <%=menu[127] %> onclick="SetFrame('sqrkthzb','Stat/StBroughtBacka.aspx','���������˻��ܱ�');">���������˻��ܱ�</a>
	        </div>
        </div>
        <div id="menu_s_sub_13" class="KsMenu" style="height:148px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:140px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" <%=menu[128] %> onclick="SetFrame('cgrbb','Stat/StPurchaseDay.aspx','�ɹ��ձ���');">�ɹ��ձ���</a>
		        <a href="#" <%=menu[129] %> onclick="SetFrame('cpcghzb','Stat/StPurchaseg.aspx','��Ʒ�ɹ����ܱ�');">��Ʒ�ɹ����ܱ�</a>
	            <a href="#" <%=menu[130] %> onclick="SetFrame('gyscghzb','Stat/StPurchasep.aspx','��Ӧ�̲ɹ����ܱ�');">��Ӧ�̲ɹ����ܱ�</a>
	            <a href="#" <%=menu[131] %> onclick="SetFrame('cgmxhzb','Stat/StPurchaseDe.aspx','�ɹ���ϸ���ܱ�');">�ɹ���ϸ���ܱ�</a>
	            <div class="KsLine"></div>
	            <a href="#" <%=menu[132] %> onclick="SetFrame('cpthhzb','Stat/StPurReturng.aspx','��Ʒ�˻����ܱ�');">��Ʒ�˻����ܱ�</a>
	            <a href="#" <%=menu[133] %> onclick="SetFrame('gysthhzb','Stat/StPurReturnp.aspx','��Ӧ���˻����ܱ�');">��Ӧ���˻����ܱ�</a>
	            <a href="#" <%=menu[134] %> onclick="SetFrame('thmxb','Stat/StPurReturnDe.aspx','�˻���ϸ���ܱ�');">�˻���ϸ���ܱ�</a>
	        </div>
        </div>
        <div id="menu_s_sub_14" class="KsMenu" style="height:170px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:160px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
	            <a href="#" <%=menu[135] %> onclick="SetFrame('xsrbb','Stat/StSellDay.aspx','�����ձ���');">�����ձ���</a>
	            <a href="#" <%=menu[136] %> onclick="SetFrame('xsybb','Stat/StSellMonth.aspx','�����±���');">�����±���</a>
		        <div class="KsLine"></div>
		        <a href="#" <%=menu[137] %> onclick="SetFrame('cpxshzb','Stat/StSellg.aspx','��Ʒ���ۻ��ܱ�');">��Ʒ���ۻ��ܱ�</a>
	            <a href="#" <%=menu[138] %> onclick="SetFrame('khxshzb','Stat/StSellc.aspx','�ͻ����ۻ��ܱ�');">�ͻ����ۻ��ܱ�</a>
	            <a href="#" <%=menu[139] %> onclick="SetFrame('xsmxhzb','Stat/StSellDe.aspx','������ϸ���ܱ�');">������ϸ���ܱ�</a>
	            <div class="KsLine"></div>
	            <a href="#" <%=menu[140] %> onclick="SetFrame('cpthhzb2','Stat/StSellReturng.aspx','��Ʒ�˻����ܱ�');">��Ʒ�˻����ܱ�</a>
	            <a href="#" <%=menu[141] %> onclick="SetFrame('khthhzb','Stat/StSellReturnc.aspx','�ͻ��˻����ܱ�');">�ͻ��˻����ܱ�</a>
	            <a href="#" <%=menu[142] %> onclick="SetFrame('thmxhzb2','Stat/StSellReturnDe.aspx','�˻���ϸ���ܱ�');">�˻���ϸ���ܱ�</a>
	       </div>
        </div>
        <div id="menu_s_sub_15" class="KsMenu" style="height:615px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:550px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
	            <a href="#" <%=menu[143] %> onclick="SetFrame('fwrbb','Stat/StServiceDay.aspx','�����ձ���');">�����ձ���</a>
		        <a href="#" <%=menu[144] %> onclick="SetFrame('fwybb','Stat/StServiceMon.aspx','�����±���');">�����±���</a>
	            <div class="KsLine"></div>
	            <a href="#" <%=menu[145] %> onclick="SetFrame('fwhzb','Stat/StServicec.aspx','������ܱ�');">������ܱ�</a>
		        <a href="#" <%=menu[146] %> onclick="SetFrame('fwmxb','Stat/StServiceDe.aspx','������ϸ��');">������ϸ��</a>
		        <div class="KsLine"></div>
		        <a href="#" <%=menu[147] %> onclick="SetFrame('fwxmhzb','Stat/StSerItem.aspx','������Ŀ���ܱ�');">������Ŀ���ܱ�</a>
		        <a href="#" <%=menu[148] %> onclick="SetFrame('fuxmmxb','Stat/StSerItemDe.aspx','������Ŀ��ϸ��');">������Ŀ��ϸ��</a>
	            <div class="KsLine"></div>
	            <a href="#" <%=menu[149] %> onclick="SetFrame('fwdgl','Stat/StBillView.aspx','���񵥸���');">���񵥸���</a>
		        <a href="#" <%=menu[150] %> onclick="SetFrame('fwdfb','Stat/StBillFrom.aspx','���񵥷ֲ�');">���񵥷ֲ�</a>
		        <a href="#" <%=menu[151] %> onclick="SetFrame('jsyyj','Stat/StTechnician.aspx','����Աҵ��');">����Աҵ��</a>
		        <a href="#" <%=menu[151] %> onclick="SetFrame('jsygzrz','Stat/StDateSer.aspx','����Ա������־');">����Ա������־</a>
		        <a href="#" <%=menu[152] %> onclick="SetFrame('cqdtj','Stat/StExtServices.aspx','���ڵ�ͳ��');">���ڵ�ͳ��</a>
		        <a href="#" <%=menu[153] %> onclick="SetFrame('fwddt','Stat/StSerMap.aspx','���񵥵�ͼ');">���񵥵�ͼ</a>
		        <a href="#" onclick="SetFrame('fubjhzb','Stat/StSerMaterial.aspx','���񱸼����ܱ�');">���񱸼����ܱ�</a>
		        <a href="#" onclick="SetFrame('bjmxhzb','Stat/MaterialDe.aspx','������ϸ���ܱ�');">������ϸ���ܱ�</a>
		        <a href="#" onclick="SetFrame('bjltmxb','Stat/StSerBroughtBack.aspx','����������ϸ��');">����������ϸ��</a>
		        <a href="#" onclick="SetFrame('bjltmxbpm','Stat/MaterialDeByGoods.aspx','����(�ֿ�)���ܱ�');">����(�ֿ�)���ܱ�</a>
		        <a href="#" onclick="SetFrame('bjltmxbywy','Stat/MaterialDeByAppOperator.aspx','����(������)���ܱ�');">����(������)���ܱ�</a>
		        <a href="#" <%=menu[151] %> onclick="SetFrame('jsyhf','Stat/TecDeduct.aspx','�ط�ͳ��');">�ط�ͳ��</a>
		        <a href="#" onclick="SetFrame('hfmxb','Stat/StSeeBackDe.aspx','�ط���ϸ��');">�ط���ϸ��</a>
		        <div class="KsLine"></div>
		        <a href="#" onclick="SetFrame('fwhtxsb','Stat/stSerContract.aspx','ά����ͬ��ʱ��');">ά����ͬ��ʱ��</a>
		        <a href="#" onclick="SetFrame('wbjqwxcb','Stat/StSerWarranty.aspx','ά�����ڻ���ά�޳ɱ�');">ά�����ڻ���ά�޳ɱ�</a>
		        <a href="#" onclick="SetFrame('wbwjqwxcb','Stat/StSerOutWarranty.aspx','ά���������ά�޳ɱ�');">ά���������ά�޳ɱ�</a>
		        <a href="#" onclick="SetFrame('fwcb','Stat/StSerCosts.aspx','����ɱ�');">����ɱ�</a>
		        <div class="KsLine"></div>
		        <a href="#" <%=menu[154] %> onclick="SetFrame('xpfbtb','Stat/StRepairDis.aspx','��Ʒ�ֲ�ͼ��');">��Ʒ�ֲ�ͼ��</a>
		        <a href="#" <%=menu[155] %> onclick="SetFrame('gzfbtb','Stat/StFaultDis.aspx','���Ϸֲ�ͼ��');">���Ϸֲ�ͼ��</a>
		        <a href="#" <%=menu[155] %> onclick="SetFrame('gztjb','Stat/stSerTakeSteps.aspx','����ͳ�Ʊ�');">����ͳ�Ʊ�</a>
		        <a href="#" <%=menu[155] %> onclick="SetFrame('clcsfbtb','Stat/StTakeStepsDis.aspx','�����ʩ�ֲ�ͼ');">�����ʩ�ֲ�ͼ</a>
		        <div class="KsLine"></div>
		        <a href="#" <%=menu[151] %> onclick="SetFrame('jsyfxhzb','Stat/StTecbRepair.aspx','����Ա���޻��ܱ�');">����Ա���޻��ܱ�</a>
		        <a href="#" <%=menu[151] %> onclick="SetFrame('jsycfwxl','Stat/StTecRepairRate.aspx','����Ա�ظ�ά����');">����Ա�ظ�ά����</a>
	        </div>
        </div>
        <div id="menu_s_sub_16" class="KsMenu" style="height:42px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:40px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" <%=menu[156] %> onclick="SetFrame('jsdhzb','Stat/StLeaseCharge.aspx','���㵥���ܱ�');">���㵥���ܱ�</a>
		        <a href="#" <%=menu[157] %> onclick="SetFrame('jsdmxb','Stat/StLeaseChargeDe.aspx','���㵥��ϸ��');">���㵥��ϸ��</a>
	        </div>
        </div>
        <div id="menu_s_sub_17" class="KsMenu" style="height:63px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:60px;width:150px;" frameborder="0"></iframe>
            <div class="KsMenu2">
	            <a href="#" <%=menu[158] %> onclick="SetFrame('khzzqk','Stat/StCustomerAdd.aspx','�ͻ��������');">�ͻ��������</a>
	            <a href="#" <%=menu[159] %> onclick="SetFrame('khjzph','Stat/StCusValueList.aspx','�ͻ���ֵ����');">�ͻ���ֵ����</a>
	            <a href="#" <%=menu[159] %> onclick="SetFrame('khgzhz','Stat/StCusTrack.aspx','�ͻ����ٻ���');">�ͻ����ٻ���</a>
	        </div>
        </div>
        <div id="menu_s_sub_18" class="KsMenu" style="height:256px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:250px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" <%=menu[160] %> onclick="SetFrame('szrbb','Stat/StDayInTo.aspx','��֧�ձ���');">��֧�ձ���</a>
		        <a href="#" <%=menu[161] %> onclick="SetFrame('szybb','Stat/StMonthInTo.aspx','��֧�±���');">��֧�±���</a>
		        <div class="KsLine"></div>
		        <a href="#" <%=menu[162] %> onclick="SetFrame('skdhzb','Stat/StIncome.aspx','�տ���ܱ�');">�տ���ܱ�</a>
		        <a href="#" <%=menu[163] %> onclick="SetFrame('skdmxb','Stat/StIncomeDe.aspx','�տ��ϸ��');">�տ��ϸ��</a>
		        <div class="KsLine"></div>
		        <a href="#" <%=menu[164] %> onclick="SetFrame('fkdhzb','Stat/StPay.aspx','������ܱ�');">������ܱ�</a>
		        <a href="#" <%=menu[165] %> onclick="SetFrame('fkdmxb','Stat/StPayDe.aspx','�����ϸ��');">�����ϸ��</a>
		        <div class="KsLine"></div>
		        <a href="#" <%=menu[166] %> onclick="SetFrame('ysyfhzb','Stat/StArr.aspx','Ӧ��Ӧ�����ܱ�');">Ӧ��Ӧ�����ܱ�</a>
		        <a href="#" <%=menu[167] %> onclick="SetFrame('ysyfmxb','Stat/StArrDe.aspx','Ӧ��Ӧ����ϸ��');">Ӧ��Ӧ����ϸ��</a>
		        <a href="#" <%=menu[168] %> onclick="SetFrame('ysyfzlb','Stat/StArrAge.aspx','Ӧ��Ӧ�������');">Ӧ��Ӧ�������</a>
		        <a href="#" <%=menu[169] %> onclick="SetFrame('ysyfhzb','Stat/StArrCanl.aspx','Ӧ��Ӧ�����˱�');">Ӧ��Ӧ�����˱�</a>
		        <div class="KsLine"></div>
		        <a href="#" <%=menu[169] %> onclick="SetFrame('bxhzb','Stat/ExpenseDe.aspx','�������ܱ�');">�������ܱ�</a>
		        <a href="#" <%=menu[169] %> onclick="SetFrame('bxmxb','Stat/ExpenseDetail.aspx','������ϸ��');">������ϸ��</a>
	        </div>
        </div>
        <div id="menu_s_sub_19" class="KsMenu" style="height:168px;z-index:9999;">
	        <iframe style="position: absolute;z-index: -2;height:160px;width:162px;" frameborder="0"></iframe>
            <div class="KsMenu2">
		        <a href="#" <%=menu[170] %> onclick="SetFrame('ywqsfx','Stat/AnCurrent.aspx','ҵ�����Ʒ���');">ҵ�����Ʒ���</a>
		        <a href="#" <%=menu[171] %> onclick="SetFrame('gzjdfx','Stat/AnProgress.aspx','�������ȷ���');">�������ȷ���</a>
		        <a href="#" <%=menu[172] %> onclick="SetFrame('skfsfx','Stat/AnIncomeType.aspx','�տʽ����');">�տʽ����</a>
		        <a href="#" <%=menu[173] %> onclick="SetFrame('qxyyfx','Stat/AnCancelReason.aspx','ȡ��ԭ�����');">ȡ��ԭ�����</a>
		        <a href="#" <%=menu[174] %> onclick="SetFrame('fwlbfx','Stat/AnOperationType.aspx','����������');">����������</a>
		        <a href="#" <%=menu[175] %> onclick="SetFrame('slfsfx','Stat/AnTakeType.aspx','����ʽ����');">����ʽ����</a>
		        <a href="#" <%=menu[176] %> onclick="SetFrame('khlyfx','Stat/AnSatisCusFrom.aspx','�ͻ���Դ����');">�ͻ���Դ����</a>
		        <a href="#" <%=menu[177] %> onclick="SetFrame('khlbfx','Stat/AnSatisCusClass.aspx','�ͻ�������');">�ͻ�������</a>
	        </div>
        </div>
    </div>
    
    <div id="menu_s_12" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:421px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_12s" class="KsMenu2" style="height:421px;">
            <a href="#" <%=menu[178] %> onclick="ShowDialog(660, 400, 'Basic/BaseInfo.aspx', '������Ϣ');">������Ϣ</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[179] %> onclick="SetFrame('wdml','Basic/BranchAdm.aspx','����Ŀ¼');">����Ŀ¼</a>
			<a href="#" <%=menu[180] %> onclick="ShowDialog(600, 380, 'Basic/StaffDeptAdm.aspx', 'Ա������');">Ա������</a>
			<a href="#" <%=menu[180] %> onclick="SetFrame('ygml','Basic/StaffAdm.aspx','Ա��Ŀ¼');">Ա��Ŀ¼</a>
			<a href="#" <%=menu[181] %> onclick="SetFrame('ckml','Basic/StockListAdm.aspx','�ֿ�Ŀ¼');">�ֿ�Ŀ¼</a>
			<a href="#" <%=menu[182] %> onclick="ShowDialog(600, 380, 'Basic/SupplierClassAdm.aspx', '���̷���');">���̷���</a>
			<a href="#" <%=menu[183] %> onclick="SetFrame('wlcs','Basic/SupplierAdm.aspx','��������');">��������</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[184] %> onclick="ShowDialog(600, 380, 'Basic/ProductBrandAdm.aspx', '����Ʒ��');">����Ʒ��</a>
		    <a href="#" <%=menu[185] %> onclick="ShowDialog(600, 380, 'Basic/ProductClassAdm.aspx', '�������');">�������</a>
		    <a href="#" <%=menu[186] %> onclick="ShowDialog(600, 380, 'Basic/ProductModelAdm.aspx', '�����ͺ�');">�����ͺ�</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[187] %> onclick="ShowDialog(600, 380, 'Basic/RepairClassAdm.aspx', 'ά�����');">ά�����</a>
	        <a href="#" <%=menu[188] %> onclick="ShowDialog(600, 380, 'Basic/TroubleClassAdm.aspx', '���Ϸ���');">���Ϸ���</a>
	        <a href="#" <%=menu[189] %> onclick="ShowDialog(600, 380, 'Basic/TroubleReasonAdm.aspx', '����ԭ��');">����ԭ��</a>
	        <a href="#" <%=menu[190] %> onclick="SetFrame('cjgz','Basic/TroubleListAdm.aspx','��������');" onmouseover="Sethiddensub('menu_s_sub_20');">��������</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[191] %> id="row20" onmouseover="Setmenu_sub('<%=modulh_s[19] %>','158','menu_s_sub_20');">������Ϣ</a>
			<a href="#" <%=menu[192] %> onclick="ShowDialog(600, 380, 'Basic/DeviceConfItem.aspx', '����������');" onmouseover="Sethiddensub('menu_s_sub_20');">����������</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[193] %> onclick="ShowDialog(600, 380, 'Basic/AccountAdm.aspx', '��֧�ʻ�');">��֧�ʻ�</a>
			<a href="#" <%=menu[194] %> onclick="ShowDialog(600, 380, 'Basic/ChargeItemAdm.aspx', '��֧��Ŀ');">��֧��Ŀ</a>
			<a href="#" <%=menu[195] %> onclick="ShowDialog(600, 380, 'Basic/ExpenseItemAdm.aspx', '������Ŀ');">������Ŀ</a>
			<a href="#" <%=menu[196] %> onclick="ShowDialog(600, 380, 'Basic/ShippingStyleAdm.aspx', '���˷�ʽ');">���˷�ʽ</a>
		</div>
		<div id="menu_s_sub_20" class="KsMenu" style="height:169px;z-index:9999;">
	    <iframe style="position: absolute;z-index: -2;height:160px;width:162px;" frameborder="0"></iframe>
        <div class="KsMenu2">
		    <a href="#" <%=menu[197] %> onclick="ShowDialog(600, 380, 'Basic/ServicesTypeAdm.aspx', '�������');">�������</a>
	        <a href="#" <%=menu[198] %> onclick="ShowDialog(600, 380, 'Basic/WarrantyAdm.aspx', '�������');">�������</a>
	        <a href="#" <%=menu[199] %> onclick="ShowDialog(600, 380, 'Basic/ServiceLevel.aspx', '���񼶱�');">���񼶱�</a>
	        <div class="KsLine"></div>
	        <a href="#" <%=menu[200] %> onclick="ShowDialog(600, 380, 'Basic/ServicesItemAdm.aspx', '������Ŀ');">������Ŀ</a>
            <a href="#" <%=menu[201] %> onclick="ShowDialog(600, 380, 'Basic/OfferItemAdm.aspx', '������Ŀ');">������Ŀ</a>
            <a href="#" <%=menu[202] %> onclick="ShowDialog(600, 380, 'Basic/GoodsGone.aspx', '��Ʒȥ��');">��Ʒȥ��</a>
            <a href="#" <%=menu[203] %> onclick="SetFrame('hfnr','Basic/VisitContent.aspx', '�ط�����');">�ط�����</a>
            <a href="#" <%=menu[204] %> onclick="ShowDialog(600, 380, 'Basic/ExtendedSet.aspx', '���ڵ�����');">���ڵ�����</a>
	    </div>
    </div>
    </div>
    
    <div id="menu_s_13" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:165px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_13s" class="KsMenu2">
			<a href="#" <%=menu[205] %> onclick="ShowDialog(600, 190, 'System/Starting.aspx', 'ϵͳ��ʼ��');" >ϵͳ��ʼ��</a>
			<a href="#" <%=menu[205] %> onclick="ShowDialog(620, 456, 'System/Setting.aspx', 'ϵͳ����');">ϵͳ����</a>
			<a href="#" <%=menu[205] %> onclick="ShowDialog(650, 143, 'System/BackupPlan.aspx', '���ݼƻ�');" >���ݼƻ�</a>
			<a href="#" <%=menu[205] %> onclick="SetFrame('xtrz','System/SysLog.aspx','ϵͳ��־');">ϵͳ��־</a>
			<div class="KsLine"></div>
			<a href="#" <%=menu[205] %> onclick="SetFrame('qxgl','System/RightAdm.aspx','Ȩ�޹���');">Ȩ�޹���</a>
			<a href="#" <%=menu[205] %> onclick="SetFrame('yygl','System/UserManage.aspx','�û�����');">�û�����</a>
			<a href="#" onclick="ShowDialog(600, 190, 'System/UserPwd.aspx', '�޸�����');">�޸�����</a>
			<a href="#" onclick="ChkExit();">�˳�ϵͳ</a>
		</div>
    </div>
    
    <div id="menu_s_14" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:<%=toolHeight %>px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_15s" class="KsMenu2" >
			<a href="#" <%=menu[205] %> onclick="ShowDialog(800,520,'Tool/Layout.aspx','��񲼾�');">��񲼾�</a>
			<a href="#" onclick="ShowDialog(640, 480, 'Tool/ToolBar.aspx', '����������');">����������</a>
			<div class="KsLine"></div>
			<a href="#" onclick="ShowDialog(600, 350, 'Tool/SmsAdm.aspx','����ģ��');">����ģ��</a>
			<a href="#" onclick="ShowDialog(600, 310, 'Tool/Printtmp.aspx', '��ӡģ��');">��ӡģ��</a>
			<div class="KsLine"></div>
			<a href="#"  onclick="ShowDialog(600, 310, 'Tool/OnlineList.aspx', '�����û�');">�����û�</a>
	  <a <%=menu[205] %> href="#" onclick="ShowDialog(800, 500, 'CDIY/UserInter.aspx', 'Ա�����');">Ա�����</a>
		 <a <%=menu[205] %> href="../CodingPages/Cd_ProType/ProTypeList.aspx" target="_blank">��Ʒ�ֿ�</a>
            	</div>
    </div>
    
    <div id="menu_s_15" class="KsMenu">
        <iframe style="position: absolute;z-index: -2;height:125px;width:162px;" frameborder="0"></iframe>
        <div id="menu_s_14s" class="KsMenu2">
			<%--<a onclick="Sethidden1();" href="http://www.differsoft.com" target="_blank">�ٷ���վ</a>
			<a onclick="Sethidden1();" href="http://bbs.differsoft.com/" target="_blank">�������</a>
			<a onclick="Sethidden1();" href="http://www.differsoft.com/production/files/Prodoc/WTnet_IT_Help.mht" target="_blank">���߰���</a>--%>
			<div class="KsLine"></div>
			<%--<a <%=menu[205] %> href="#" onclick="ShowDialog(500, 208, 'System/Update.aspx', '��������');">��������</a>
			<a href="#" <%=menu[205] %> onclick="ShowDialog(600, 290, 'System/SoftReg.aspx', 'ע��');" >���ע��</a>
			<a onclick="ShowDialog(500, 228, 'About.aspx', '����');" href="#">����</a>--%>
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
<div id="F1" onmousedown="ChangeWList('left')" onmouseup="ChangeWList('out')"><img src="../Public/Images/left.png"/></div>
<div id="F2" onmousedown="ChangeWList('right')" onmouseup="ChangeWList('out')"><img src="../Public/Images/right.png"/></div>
</td>
</tr></table>
</div>
<div id="WinPage"></div>
</div>

<!--���صȴ�����-->
<div id='Loading' style="position:absolute;z-index:1000;top:0px;left:0px;width:100%;height:100%;background:#fff;text-align:center"><img src='../Public/images/loading.gif' style='margin-top:150px'/></div>

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
