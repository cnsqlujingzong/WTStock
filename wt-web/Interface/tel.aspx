<%@ page language="C#"  CodeFile="tel.aspx.cs"     autoeventwireup="true" inherits="Interface_Tel" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>��������ӿ�</title>
    <link rel="Stylesheet" type="text/css" href="../Public/Style/tel.css" />
    <script language="javascript" type="text/javascript" src="../Public/Script/tel.js"></script>
</head>
<body style="overflow:hidden;">
    <form id="form1" runat="server">
    
    <div class="tl1">
    <div style="padding:5px 10px;">

    <div class="tl2">��������</div>
    <fieldset class="tl3">
    <legend>������Ϣ</legend>
    <table cellpadding="0" cellspacing="0" class="tb1">
    <tr><td>������룺</td>
        <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="in1 in2 pbb" Width="200"></asp:TextBox></td>
    </tr>
    </table>  
    <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
            <td>�ͻ����ƣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbCusName" runat="server" CssClass="in1 in2" Width="300"></asp:TextBox></td>
            <td align="right">�ͻ����</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbCusClass" runat="server"  CssClass="in1 in2"></asp:TextBox></td>
            </tr><tr>
            <td>��ϵ�绰��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbCusTel" runat="server"  CssClass="in1 in2" Width="300"></asp:TextBox></td>
            <td align="right">��ϵ�ˣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbLinkName" runat="server"  CssClass="in1 in2"></asp:TextBox></td>
            </tr><tr>
            <td align="right">��ַ��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server"  CssClass="in1 in2" Width="300"></asp:TextBox></td>
            <td align="right">���棺</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbFax" runat="server"  CssClass="in1 in2"></asp:TextBox>
                <asp:HiddenField ID="hfv" runat="server" />
                <asp:HiddenField ID="hfcusid" runat="server" />
                <span style=" display:none;">
                <asp:Button ID="btnslt" runat="server" Text="cus"  UseSubmitBehavior="false" OnClick="btnslt_Click" />
                </span>
                <asp:HiddenField ID="hfBranch" runat="server" />
            </td>
            </tr>
            <tr>
            <td align="right">��ע��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="in1 in2" Width="300"></asp:TextBox></td>
            <td align="right">�ͻ�����</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbArea" runat="server"  CssClass="in1 in2"></asp:TextBox>
            </td>
            </tr>
    </table>
    </fieldset>
    
    <fieldset style=" border: 1px #808080 solid; padding:10px">
    <legend>���ҵ��</legend>
    
    <div id="odiv1" style="margin-top:10px;">
    <div>
    <span class="uspan">��ʷ����</span>
    <span class="bspan" onclick="ChkPane('odiv2');">��������</span>
    </div>
    <div class="fdiv">
    <div class="sw">

    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView2_RowDataBound" EnableViewState="false">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="����״̬" DataField="curStatus" />
                <asp:BoundField HeaderText="���񵥺�" DataField="BillID" />
                <asp:BoundField HeaderText="�������" DataField="ServicesType" />
                <asp:BoundField HeaderText="������" DataField="Operator" />
                <asp:BoundField HeaderText="����ʱ��" DataField="Time_TakeOver" />
                <asp:BoundField HeaderText="����ʱ��" DataField="Speding" />
                <asp:BoundField HeaderText="����ʽ" DataField="TakeStyle" />
                <asp:BoundField HeaderText="����λ" DataField="TakeDept" />
                <asp:BoundField HeaderText="���񼶱�" DataField="_PRI" />
                <asp:BoundField HeaderText="����Ա" DataField="DisposalOper" />  
                <asp:BoundField HeaderText="�ͻ�����" DataField="CustomerName" />
                <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
                <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
                <asp:BoundField HeaderText="�����ͺ�" DataField="ProductModel" />
                <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
                <asp:BoundField HeaderText="���" DataField="ProductClass" />
                <asp:BoundField HeaderText="���к�1" DataField="ProductSN1" />
                <asp:BoundField HeaderText="���к�2" DataField="ProductSN2" />
                <asp:BoundField HeaderText="����" DataField="Fault" />
                <asp:BoundField HeaderText="�������" DataField="Warranty" />
                <asp:BoundField HeaderText="ԤԼʱ��" DataField="SubscribeTime" />
                <asp:BoundField HeaderText="Ԥ����" DataField="SubscribePrice" />
                <asp:BoundField HeaderText="Ԥ�շ�" DataField="PreCharge" />
                <asp:BoundField HeaderText="����" DataField="bRepair" />
            </Columns>
        </asp:GridView>
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td><webdiyer:aspnetpager id="jsPagerD" runat="server" ShowBoxThreshold="1" ShowInputBox="Never" Visible="false" /></td>
                <td style="padding-left:8px;"><asp:Label ID="lbPageD" runat="server" ToolTip="��ҳ��ʾ��"></asp:Label></td>
                <td style="padding-left:8px;"><asp:Label ID="lbCountD" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
            </tr>
        </table>
        <asp:HiddenField ID="hfRecIDD" runat="server" Value="-1" />
        
    </div>
    </div>
    </div>
    
    <div id="odiv2" style="display:none;margin-top:10px; ">
    <div>
    <span class="bspan" onclick="ChkPane('odiv1');">��ʷ����</span>
    <span class="uspan">��������</span>
    </div>
    <div class="fdiv">
    <div class="sdiv sw">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound" EnableViewState="false">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="�ͻ����" DataField="CustomerNO" />
                <asp:BoundField HeaderText="�ͻ�����" DataField="_Name" />
                <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
                <asp:BoundField HeaderText="��������" DataField="CusDept" />
                <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
                <asp:BoundField HeaderText="�ֻ�����" DataField="Tel2" />
                <asp:BoundField HeaderText="����" DataField="Fax" />
                <asp:BoundField HeaderText="�ʱ�" DataField="Zip" />
                <asp:BoundField HeaderText="��ַ" DataField="Adr" />
                <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
                <asp:BoundField HeaderText="���" DataField="ProductClass" />
                <asp:BoundField HeaderText="�ͺ�" DataField="ProductModel" />
                <asp:BoundField HeaderText="���к�1" DataField="ProductSN1" />
                <asp:BoundField HeaderText="���к�2" DataField="ProductSN2" />
                <asp:BoundField HeaderText="���" DataField="ProductAspect" />
                <asp:BoundField HeaderText="����ʱ��" DataField="BuyDate" />
                <asp:BoundField HeaderText="������" DataField="BuyFrom" />
                <asp:BoundField HeaderText="����Ʊ" DataField="BuyInvoice" />
                <asp:BoundField HeaderText="��װ����" DataField="InstallDate" />
                <asp:BoundField HeaderText="������" DataField="MaintenancePeriod" />
                <asp:BoundField HeaderText="�������" DataField="Warranty" />
                <asp:BoundField HeaderText="���ұ��޿�ʼ" DataField="WarrantyStart" />
                <asp:BoundField HeaderText="���ұ��޽���" DataField="WarrantyEnd" />
                <asp:BoundField HeaderText="ά�޴�" DataField="RepairTimes" />
                <asp:BoundField HeaderText="���ά��ʱ��" DataField="Repairlately" />
                <asp:BoundField HeaderText="ά�ޱ��޽���" DataField="RepairWarrantyEnd" />
                <asp:BoundField HeaderText="��ͬ���޿�ʼ" DataField="ContractWarrantyStart" />
                <asp:BoundField HeaderText="��ͬ���޽���" DataField="ContractWarrantyEnd" />
                <asp:BoundField HeaderText="ά�޺�ͬ���" DataField="ContractNO" />
            </Columns>
        </asp:GridView>
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td><webdiyer:aspnetpager id="jsPager" runat="server"  ShowBoxThreshold="1" CssClass="tdPage" ShowInputBox="Never" Visible="False" /></td>
                <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="��ҳ��ʾ��"></asp:Label></td>
                <td style="padding-left:8px;"><asp:Label ID="lbCount" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
            </tr>
        </table>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    
    </div>
    </div>
    </div>
    
    </fieldset>
    <div style=" margin-top:5px;">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:Button ID="btnref" runat="server" Text="ˢ��" CssClass="bt1"  UseSubmitBehavior="false" OnClick="btnref_Click" />
            </td>
            <td align="right">
                <input id="btnNew" type="button" value="��������" class="bt1" onclick="ChkBill();" <%=Btn %>/>
                <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="chkurl();" />
            </td>
        </tr>
    </table>
    
    </div>    
    </div>
    </div>
    
    
<div id="fcolor" class="fcolor" style="display:none;">Font</div>
 <div id="main">
 
    <div id="divDialog1" style="display: none; visibility: hidden; position: absolute; z-index:8997">
        <div id="divTitle1" style="cursor:default; display:block;">
        <div style="float:left;" id="divIco1"><div id="divTitleName1"></div></div>
         	<div id="divClose1" style="float: right;" onclick="CloseDialog1();">
         		<img alt="�ر�" src="../Public/Images/close.gif" style="margin:2px 2px 0 0; cursor: default;" title="�ر�" />
         	</div>
         	<div style=" clear:both;"></div>
        </div>
        <iframe id="iframeDialog1" name="iframeDialog1" scrolling="no" frameborder="0"></iframe>  		
    </div>
    <div id="divBackground1" style="position: absolute; z-index: 7996; visibility: hidden; display: none; top: 0px; left: 0px; width: 100%; height: 100%; filter: alpha(opacity=0);">
        <iframe height="100%" name="iframeBackground" src="about:blank" width="100%"></iframe>
    </div>
    <div id="divDialog2" style="display: none; visibility: hidden; position: absolute; z-index:8997">
        <div id="divTitle2" style="cursor:default; display:block;">
        <div style="float:left;" id="divIco2"><div id="divTitleName2"></div></div>
         	<div id="divClose2" style="float: right;" onclick="CloseDialog2();">
         		<img alt="�ر�" src="../Public/Images/close.gif" style="margin:2px 2px 0 0; cursor: default;" title="�ر�" />
         	</div>
         	<div style=" clear:both;"></div>
        </div>
        <iframe id="iframeDialog2" name="iframeDialog2" scrolling="no" frameborder="0"></iframe>  		
    </div>
    <div id="divBackground2" style="position: absolute; z-index: 7996; visibility: hidden; display: none; top: 0px; left: 0px; width: 100%; height: 100%; filter: alpha(opacity=0);">
        <iframe height="100%" name="iframeBackground" src="about:blank" width="100%"></iframe>
    </div>
	<div id="divDialog" style="display: none; visibility: hidden; position: absolute; z-index:6995">
        <div id="divTitle" style="cursor:default; display:block;">
        	<div style="float:left;" id="divIco"><div id="divTitleName"></div></div>
         	<div id="divClose" style="float: right;" onclick="CloseDialog();">
         		<img alt="�ر�" src="../Public/Images/close.gif" style="margin:2px 2px 0 0; cursor: default;" title="�ر�" />
         	</div>
         	<div style=" clear:both;"></div>
        </div>
		<iframe id="iframeDialog" name="iframeDialog" scrolling="no"  frameborder="0"></iframe>  
    </div>
    
    <div id="divBackground" style="position: absolute; z-index: 5994; visibility: hidden; display: none; top: 0px; left: 0px; width: 100%; height: 100%; filter: alpha(opacity=0);">
        <iframe height="100%" name="iframeBackground" src="about:blank" width="100%"></iframe>
    </div> 
    
        <div id="test" style="width:190px; position:absolute; top:13px; right:10px; display:none; z-index:9999; background:#e9e7e3; border:1px #16397f solid; padding:5px;">
                <img src="../Public/Images/load.gif" alt="loading" />
                <span style="color:#0000ff">����������,���Ժ�...</span>
                <a id="btntest" href="#" style="padding-left:5px; color:#000;">ȡ��</a>
    </div>
     
</div>

</form>
</body>
</html>
<script language="javascript" type="text/javascript">
window.onload=function() 
{ 
��var obj = document.getElementById("divTitleName");
  var target = document.getElementById("divDialog");
  drag(obj, target);
  var obj1 = document.getElementById("divTitleName1");
  var target1 = document.getElementById("divDialog1");
  drag(obj1, target1);
}

function ChkView(hid)
{
    var id=document.getElementById(hid).value.replace("d","");
    var branch=document.getElementById("hfBranch").value;
    if(hid=="hfRecID"){
    ShowDialog(750, 430, '../'+branch+'/Customer/DeviceMod.aspx?itel=1&id='+id, '��������');
    }else{
    ShowDialog(860,444, '../'+branch+'/Services/SerView.aspx?itel=1&id='+id, '����');
    }
}
function ChkBill()
{
    var cid=document.getElementById("hfcusid").value;
    var tel=document.getElementById("tbTel").value;
    var branch=document.getElementById("hfBranch").value;
    if(cid==""){
    ShowDialog(870,600, '../'+branch+'/Services/ServicesAdd.aspx?itel=1&tel='+escape(tel), '��������');
    }else{
    ShowDialog(870,600, '../'+branch+'/Services/ServicesAdd.aspx?itel=1&cusid='+cid, '��������');    
    }
}
function chkurl()
{
    location.href='../Interface/Tel.aspx#close';
}
</script>
