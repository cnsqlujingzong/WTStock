<%@ page language="C#"  CodeFile="cusmerge.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Customer_CusMerge" theme="Themes" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>合并客户</title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div class="main">
    <div class="maincon">
        <div id="sad" style="width:486px;">
        <div class="fdivs">
    <div class="sdivs" style="padding:3px 0 3px 0px;width:482px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
        <td align="right">客户名称：</td>
        <td style="padding-left:0px;">
        <div class="isinDiv">
            <asp:TextBox ID="tbCusName" runat="server" CssClass="pin2 pinin"></asp:TextBox>
            <asp:DropDownList ID="ddlCusName" runat="server" CssClass="pininsl2" onchange="document.getElementById('tbCusName').value=this.options[this.selectedIndex].text">
            </asp:DropDownList>
        </div>
        </td>
        </tr>
        <tr>
        <td align="right">联系人：</td>
        <td style="padding-left:0px;">
        <div class="isinDiv">
            <asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin2 pinin"></asp:TextBox>
            <asp:DropDownList ID="ddlLinkMan" runat="server" CssClass="pininsl2" onchange="document.getElementById('tbLinkMan').value=this.options[this.selectedIndex].text">
            </asp:DropDownList>
        </div>
        </td>
        </tr>
        <tr>
        <td align="right">联系电话：</td>
        <td style="padding-left:0px;">
        <div class="isinDiv">
            <asp:TextBox ID="tbLinkTel" runat="server" CssClass="pin2 pinin"></asp:TextBox>
            <asp:DropDownList ID="ddlLinkTel" runat="server" CssClass="pininsl2" onchange="document.getElementById('tbLinkTel').value=this.options[this.selectedIndex].text">
            </asp:DropDownList>
        </div>
        </td>
        </tr>
        <tr>
        <td align="right">联系地址：</td>
        <td style="padding-left:0px;">
        <div class="isinDiv">
            <asp:TextBox ID="tbAdr" runat="server" CssClass="pin2 pinin"></asp:TextBox>
            <asp:DropDownList ID="ddlAdr" runat="server" CssClass="pininsl2" onchange="document.getElementById('tbAdr').value=this.options[this.selectedIndex].text">
            </asp:DropDownList>
        </div>
        </td>
        </tr>
        <tr>
        <td align="right">备注：</td>
        <td style="padding-left:0px;">
        <div class="isinDiv">
            <asp:TextBox ID="tbRemark" runat="server" CssClass="pin2 pinin"></asp:TextBox>
            <asp:DropDownList ID="ddlRemark" runat="server" CssClass="pininsl2" onchange="document.getElementById('tbRemark').value=this.options[this.selectedIndex].text">
            </asp:DropDownList>
        </div>
        </td>
        </tr>
        </table>
        </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
        <div class="divh"></div>
        <div id="cndiv" style="height:144px;">
            <div class="fdivs" style="height:142px;">
                <div class="sdivs" style="height:140px;background:#ffffff;width:482px;">
                <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound">
                <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:TemplateField>
                <HeaderTemplate>
                选择
                </HeaderTemplate>
                <ItemTemplate>
                <input type="radio" name="slt" id="rd<%#Eval("ID") %>" onclick="chgslt('<%#Eval("ID") %>');" />
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="客户名称" DataField="_Name" />
                <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
                <asp:BoundField HeaderText="电话" DataField="Tel" />
                <asp:BoundField HeaderText="地址" DataField="Adr" />
                <asp:BoundField HeaderText="备注" DataField="Remark" />
                </Columns>
                </asp:GridView>
                </div>
            </div>
        </div>
        <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="color:Gray">请选择要合并成哪个客户!
                    <asp:HiddenField ID="hfID" runat="server" /></td>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="确定" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
                    <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog('1');"/>
                </td>
            </tr>
            </table>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
function chgslt(rid)
{
    var cusname=document.getElementById(rid).cells[1].innerHTML.replace("&nbsp;","");
    var linkman=document.getElementById(rid).cells[2].innerHTML.replace("&nbsp;","");
    var linktel=document.getElementById(rid).cells[3].innerHTML.replace("&nbsp;","");
    var adr=document.getElementById(rid).cells[4].innerHTML.replace("&nbsp;","");
    var remark=document.getElementById(rid).cells[5].innerHTML.replace("&nbsp;","");
    document.getElementById("tbCusName").value=cusname;
    document.getElementById("tbLinkMan").value=linkman;
    document.getElementById("tbLinkTel").value=linktel;
    document.getElementById("tbAdr").value=adr;
    document.getElementById("tbRemark").value=remark;
    document.getElementById("hfID").value=rid;
}
function ChkAdd()
{
    if(document.getElementById("tbCusName").value.replace(/(^\s*)|(\s*$)/g,"")=="")
    {
        alert("客户名称不能为空！");
        document.getElementById("tbCusName").focus();
        return false;
    }
    return true;
}
</script>
