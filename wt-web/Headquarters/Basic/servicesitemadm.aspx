<%@ page language="C#"  CodeFile="servicesitemadm.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Basic_ServicesItemAdm" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sa" style="width:586px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional" ChildrenAsTriggers="false">
    <ContentTemplate>
    
        <div class="fdiv">
        <div class="sdiv2" style="height:230px;">
        <asp:GridView ID="GridView1" runat="server" SkinID="gv4" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="序" />
                <asp:BoundField HeaderText="编号" DataField="ItemNO" />
                <asp:BoundField HeaderText="名称" DataField="_Name" />
                <asp:BoundField HeaderText="价格" DataField="Price" />
                <asp:BoundField HeaderText="保内价格" DataField="WarrantyPrice" />
                <asp:BoundField HeaderText="员工提成" DataField="TecDeduct" />
            </Columns>
        </asp:GridView>
        
        <table cellpadding="0" cellspacing="0" class="pages">
            <tr>
                <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" TabIndex="-1" /></td>
                <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="当页显示数"></asp:Label></td>
                <td style="padding-left:8px;"><asp:Label ID="lbCount" runat="server" ToolTip="总记录数"></asp:Label></td>
            </tr>
        </table>
        
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
                            <span style="display:none;">
                        <asp:Button ID="btnRef" runat="server" Text="刷新" CssClass="bt1" OnClick="btnRef_Click" UseSubmitBehavior="false"/></span>
        </div>
    </div>
    <div class="divh"></div>
    <div class="fdiv">
    <div class="sdiv">
    
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" class="tb4">
        <tr>
            <td class="blue" align="right">编号：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbItemID" runat="server" CssClass="pin"></asp:TextBox>
            </td>
            <td colspan="2" style="padding-left:5px;color:#ff0000;">
                <asp:CheckBox ID="cbsys" runat="server" Text="系统默认" Checked="true" onclick="ChkSysNO();" /><asp:HiddenField ID="hfTemp" runat="server" /></td>
        </tr>
        <tr>
            <td align="right" class="red">名称：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin"></asp:TextBox>
            </td>
            <td align="right">员工提成：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDeduct" runat="server" CssClass="pin" onblur="ChkMoney(this);"></asp:TextBox>
        </tr>
        <tr>
            <td align="right">价格：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbPrice" runat="server" CssClass="pin" onblur="ChkMoney(this);"></asp:TextBox>
            </td>
            <td align="right">保内价格：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbPricew" runat="server" CssClass="pin" onblur="ChkMoney(this);"></asp:TextBox>
                <span style="color:#666;">(*特约维修对厂结算价格)</span>
            </td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnRef" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
        
    </div>
    </div>
    
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <asp:Button ID="btnAdd" runat="server" Text="新建" CssClass="bt1" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click" UseSubmitBehavior="false" />
            <asp:Button ID="btnMod" runat="server" Text="修改" CssClass="bt1" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnMod_Click" UseSubmitBehavior="false" />
            <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="bt1" OnClientClick="if(ChkDel('服务项目')==false)return false;" OnClick="btnDel_Click" UseSubmitBehavior="false" />
            <input id="btnInto" type="button" value="导入" class="bt1" onclick="ChkInput()" />
        </td>
        <td align="right">
            <span style="display:none;">
            <asp:Button ID="btnShow" runat="server" Text="显示" CssClass="bt1" OnClick="btnShow_Click" UseSubmitBehavior="false"/>
            </span>
            <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog();"/> 
        </td>
    </tr>
    </table>
    
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="jsPager" EventName="PageChanged" />
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnMod" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnRef" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
    </div>
    </div>
    </div>    
    </form>
</body>
</html>

<script language="javascript" type="text/javascript" src="../../Public/Script/menu.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkID(id)
{
    ClrBaseID(id);
    $("btnShow").click();
}
function ChkSave()
{
    if(ChkSlt()!=false)
    {
        if($("btnMod").value=="保存")
        {
            if(Chk()==false)return false;
        }
    }else{return false;}
}

function ChkAdd()
{
    if($("btnAdd").value=="保存")
    {
        if(Chk()==false)return false;
    }
}

//
function ChkFocus()
{
    $("tbName").select();
}

function Chk()
{
    if(!$("cbsys").checked)
    {
        if(isNull($("tbItemID").value))
        {
            window.alert("操作失败！编号不能为空");
            $("tbItemID").focus();
            return false
        }
    }
    if(isNull($("tbName").value))
    {
        window.alert("操作失败！名称不能为空");
        $("tbName").focus();
        return false
    }
}
function ChkSysNO()
{
    if(!$("cbsys").checked)
    {
        $("tbItemID").disabled=false;
        $("tbItemID").focus();
    }else
    {
        $("tbItemID").disabled=true;
    }
}
function ChkMoney(obj)
{
    if(!isNull(obj.value))
    {
        if(!isMoney(obj.value))
        {
            alert("格式不正确，输入将被撤消");
            obj.value="";
            obj.focus();
            obj.select();
        }
    }
}
function ChkInput()
{
    parent.ShowDialog1(500,220,'Basic/InputServiceItem.aspx?iflag=1', '导入服务项目');
}
</script>
