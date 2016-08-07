<%@ page language="C#"  CodeFile="baseinfo.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Basic_BaseInfo" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sd" style="width:646px;">
        <div class="fdiv">
        <div class="sdiv" style="padding:0px; overflow:auto; height:370px; border-top:none;">
           <table cellpadding="0" cellspacing="0" height="100%" width="100%" >
            <tr>
                <td width="150" style="background:#ffffff;" valign="top">
                <div style="height:370px; overflow:auto;">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
                    <ContentTemplate>
                    <asp:TreeView ID="tvBaseInfo" runat="server" ShowLines="True" ExpandDepth="1" OnSelectedNodeChanged="tvBaseInfo_SelectedNodeChanged">
                        <Nodes>
                            <asp:TreeNode Text="员工岗位" ToolTip="员工岗位" Selected="True" Value="10"></asp:TreeNode>
                            <asp:TreeNode Text="区域目录" ToolTip="区域目录" Value="2"></asp:TreeNode>
                            <asp:TreeNode Text="客户状态" ToolTip="客户状态" Value="57"></asp:TreeNode>
                            <asp:TreeNode Text="客户来源" ToolTip="客户来源" Value="31"></asp:TreeNode>
                            <asp:TreeNode Text="跟踪方式" ToolTip="跟踪方式" Value="55"></asp:TreeNode>
                            <asp:TreeNode Text="跟踪类别" ToolTip="跟踪类别" Value="56"></asp:TreeNode>
                            <asp:TreeNode Text="分派原因" ToolTip="分派原因" Value="58"></asp:TreeNode>
                            <asp:TreeNode Text="物品外观" ToolTip="物品外观" Value="15"></asp:TreeNode>
                            <asp:TreeNode Text="随机附件" ToolTip="随机附件" Value="16"></asp:TreeNode>
                            <asp:TreeNode Text="受理方式" ToolTip="受理方式" Value="18"></asp:TreeNode>
                            <asp:TreeNode Text="取消原因" ToolTip="取消原因" Value="21"></asp:TreeNode>
                            <asp:TreeNode Text="回访形式" ToolTip="回访形式" Value="24"></asp:TreeNode>
                            <asp:TreeNode Text="合同类别" ToolTip="合同类别" Value="4"></asp:TreeNode>
                            <asp:TreeNode Text="结算方式" ToolTip="结算方式" Value="3"></asp:TreeNode>
                            <asp:TreeNode Text="发票类别" ToolTip="发票类别" Value="1"></asp:TreeNode>
                            <asp:TreeNode Text="入库原因" ToolTip="入库原因" Value="8"></asp:TreeNode>
                            <asp:TreeNode Text="出库原因" ToolTip="出库原因" Value="9"></asp:TreeNode>
                            <asp:TreeNode Text="计量单位" ToolTip="计量单位" Value="40"></asp:TreeNode>
                            <asp:TreeNode Text="货品仓位" ToolTip="货品仓位" Value="7"></asp:TreeNode>
                            <asp:TreeNode Text="计数器类型" ToolTip="计数器类型" Value="41"></asp:TreeNode>
                        </Nodes>
                        <SelectedNodeStyle BackColor="#7D8ABE" BorderColor="White" HorizontalPadding="5px" />
                        <NodeStyle ImageUrl="~/Public/Images/folderclose.gif" HorizontalPadding="5px"  />
                    </asp:TreeView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="tvBaseInfo" EventName="SelectedNodeChanged" />
                    </Triggers>
                    </asp:UpdatePanel>
                    </div>
                </td>
                <td width="10" style=" background:#808080;">
                </td>
                <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
                    <ContentTemplate>
                     <div style="height:285px; background:#ffffff; overflow:auto;">
                            <asp:GridView ID="GridView1" runat="server" SkinID="gv4" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" Width="70%">
                            <Columns>
                            </Columns>
                        </asp:GridView>
                        
                        <table cellpadding="0" cellspacing="0" class="pages">
                            <tr>
                                <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
                                <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="当页显示数"></asp:Label></td>
                                <td style="padding-left:8px;"><asp:Label ID="lbCount" runat="server" ToolTip="总记录数"></asp:Label></td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
                    </div>
                    <div class="fdiv" style="border-right:none;border-left:none;">
                    <div class="sdiv" style="border-right:none;border-left:none; height:35px; line-height:35px;">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                        <ContentTemplate>
                        <table cellpadding="0" cellspacing="0" class="tb1">
                            <tr>
                                <td>
                                    <asp:Label ID="lbName" runat="server" Text=""></asp:Label>：</td>
                                <td colspan="3" style="padding-left:0px;">
                                <asp:TextBox ID="tbName" runat="server" CssClass="pin" Width="160"></asp:TextBox>
                                <asp:HiddenField ID="hfTemp" runat="server" />
                                <asp:HiddenField ID="hfTbName" runat="server" />
                                <asp:HiddenField ID="hfType" runat="server" />
                                </td>
                                <td>排序：</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbArray" runat="server" CssClass="pin" Width="60"></asp:TextBox></td>
                            </tr>
                        </table>
                      </ContentTemplate>
                         <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                        </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    </div>
                    <div class="divh"></div>
                    <div class="fdiv" style="border:none;">
                    <div class="sdiv" style="border:none;">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td style="padding-left:5px;">
                                  <asp:Button ID="btnAdd" runat="server" Text="新建" CssClass="bt1" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click" UseSubmitBehavior="false" />
                                  <asp:Button ID="btnMod" runat="server" Text="修改" CssClass="bt1" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnMod_Click" UseSubmitBehavior="false" />
                                  <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="bt1" OnClientClick="if(ChkDel()==false)return false;" OnClick="btnDel_Click" UseSubmitBehavior="false" />
                                  <input id="btnInput" runat="server" type="button" class="bt1" value="导入" onclick="ChkInput();" />
                                </td>
                                <td align="right" style="padding-right:10px;">
                                <span style="display:none;">
                                <asp:Button ID="btnShow" runat="server" Text="显示" CssClass="bt1" OnClick="btnShow_Click" UseSubmitBehavior="false"/>
                                <asp:Button ID="btnRef" runat="server" Text="刷新" CssClass="bt1" OnClick="btnRef_Click" UseSubmitBehavior="false"/>
                                </span>
                                
                                    <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog();"/>
                                </td>
                            </tr>
                         </table>
                    </div>
                    </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="jsPager" EventName="PageChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnMod" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnRef" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="tvBaseInfo" EventName="SelectedNodeChanged" />
                    </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
           </table>
        </div>
        </div>
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
            if(isNull($("tbName").value))
            {
                window.alert("操作失败！"+document.getElementById("lbName").innerHTML+"不能为空");
                $("tbName").focus();
                return false
            }
            if(!isNull($("tbArray").value))
            {
                if(!isDigit($("tbArray").value))
                {
                    window.alert("排序必须为数字.");
                    $("tbArray").select();
                    return false
                }
            }
        }
    }else{return false;}
}

function ChkAdd()
{
    if($("btnAdd").value=="保存")
    {
        if($("tbName").value=="")
        {
            window.alert("操作失败！"+document.getElementById("lbName").innerHTML+"不能为空");
            $("tbName").focus();
            return false
        }
        if(!isNull($("tbArray").value))
        {
            if(!isDigit($("tbArray").value))
            {
                window.alert("排序必须为数字.");
                $("tbArray").select();
                return false
            }
        }
    }
}

function ChkDel()
{
    if(ChkSlt()!=false)
    {
        return confirm("确认要删除该["+document.getElementById("lbName").innerHTML+"]吗？");
    }else{return false;}
}

function ChkInput()
{
    parent.ShowDialog1(480, 193,'Basic/InputBase.aspx?str='+escape(document.getElementById("lbName").innerHTML), '导入基础信息');
}
function ChkFocus()
{
    $("tbName").select();
}

</script>
