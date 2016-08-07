<%@ page language="C#"  CodeFile="customer.aspx.cs"     autoeventwireup="true" inherits="Interface_Customer" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../Public/Style/sub.css" />
    <link rel="Stylesheet" type="text/css" href="../Public/Style/page.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
    <ContentTemplate>
    <div class="fdiv">
        <div class="sdiv sw sw1" style="height:400px; padding:0px;">
        <asp:GridView ID="GridView1" runat="server" SkinID="gv3" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" Width="100%" EnableViewState="false">
            <Columns>           
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="客户编号" DataField="CustomerNO" />
                <asp:BoundField HeaderText="客户名称" DataField="_Name" />
                <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
                <asp:BoundField HeaderText="电话" DataField="Tel" />
                <asp:BoundField HeaderText="电话2" DataField="Tel2" />
                <asp:BoundField HeaderText="地址" DataField="Adr" />
                <asp:BoundField HeaderText="邮编" DataField="Zip" />
                <asp:BoundField HeaderText="传真" DataField="Fax" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="地域" DataField="Area" />
                <asp:BoundField HeaderText="登记部门" DataField="DeptID" />
                <asp:BoundField HeaderText="首拼音" DataField="pyCode" />
                
            </Columns>
        </asp:GridView>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
                    <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server"></asp:Label></td>
                    <td style="padding-left:8px;"><asp:Label ID="lbCount" runat="server"></asp:Label></td>
                </tr>
            </table>
            <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
            <asp:HiddenField ID="hfID" runat="server" Value="" />
        </div>
    </div>
    
    </ContentTemplate>
    </asp:UpdatePanel>  

    <div style="margin-top:5px;">
    
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td><span class="si2">双击客户记录进行选择</span></td>
            </tr>
        </table>      
          
    </div>  
      
    </form>
</body>
</html>

<script language="javascript" type="text/javascript" src="../Public/Script/menu.js"></script>
<script language="javascript" type="text/javascript" src="../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript">
function ChkID(id)
{
    ClrID(id);
}
function ChkValue(id)
{
    $("hfID").value=id;
}
function ChkPass()
{
    parent.document.getElementById("hfcusid").value=document.getElementById("hfID").value;
    parent.document.getElementById("btnslt").click();
    parent.CloseDialog();
}
</script>
