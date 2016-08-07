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
                            <asp:TreeNode Text="Ա����λ" ToolTip="Ա����λ" Selected="True" Value="10"></asp:TreeNode>
                            <asp:TreeNode Text="����Ŀ¼" ToolTip="����Ŀ¼" Value="2"></asp:TreeNode>
                            <asp:TreeNode Text="�ͻ�״̬" ToolTip="�ͻ�״̬" Value="57"></asp:TreeNode>
                            <asp:TreeNode Text="�ͻ���Դ" ToolTip="�ͻ���Դ" Value="31"></asp:TreeNode>
                            <asp:TreeNode Text="���ٷ�ʽ" ToolTip="���ٷ�ʽ" Value="55"></asp:TreeNode>
                            <asp:TreeNode Text="�������" ToolTip="�������" Value="56"></asp:TreeNode>
                            <asp:TreeNode Text="����ԭ��" ToolTip="����ԭ��" Value="58"></asp:TreeNode>
                            <asp:TreeNode Text="��Ʒ���" ToolTip="��Ʒ���" Value="15"></asp:TreeNode>
                            <asp:TreeNode Text="�������" ToolTip="�������" Value="16"></asp:TreeNode>
                            <asp:TreeNode Text="����ʽ" ToolTip="����ʽ" Value="18"></asp:TreeNode>
                            <asp:TreeNode Text="ȡ��ԭ��" ToolTip="ȡ��ԭ��" Value="21"></asp:TreeNode>
                            <asp:TreeNode Text="�ط���ʽ" ToolTip="�ط���ʽ" Value="24"></asp:TreeNode>
                            <asp:TreeNode Text="��ͬ���" ToolTip="��ͬ���" Value="4"></asp:TreeNode>
                            <asp:TreeNode Text="���㷽ʽ" ToolTip="���㷽ʽ" Value="3"></asp:TreeNode>
                            <asp:TreeNode Text="��Ʊ���" ToolTip="��Ʊ���" Value="1"></asp:TreeNode>
                            <asp:TreeNode Text="���ԭ��" ToolTip="���ԭ��" Value="8"></asp:TreeNode>
                            <asp:TreeNode Text="����ԭ��" ToolTip="����ԭ��" Value="9"></asp:TreeNode>
                            <asp:TreeNode Text="������λ" ToolTip="������λ" Value="40"></asp:TreeNode>
                            <asp:TreeNode Text="��Ʒ��λ" ToolTip="��Ʒ��λ" Value="7"></asp:TreeNode>
                            <asp:TreeNode Text="����������" ToolTip="����������" Value="41"></asp:TreeNode>
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
                                <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="��ת:" /></td>
                                <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="��ҳ��ʾ��"></asp:Label></td>
                                <td style="padding-left:8px;"><asp:Label ID="lbCount" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
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
                                    <asp:Label ID="lbName" runat="server" Text=""></asp:Label>��</td>
                                <td colspan="3" style="padding-left:0px;">
                                <asp:TextBox ID="tbName" runat="server" CssClass="pin" Width="160"></asp:TextBox>
                                <asp:HiddenField ID="hfTemp" runat="server" />
                                <asp:HiddenField ID="hfTbName" runat="server" />
                                <asp:HiddenField ID="hfType" runat="server" />
                                </td>
                                <td>����</td>
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
                                  <asp:Button ID="btnAdd" runat="server" Text="�½�" CssClass="bt1" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click" UseSubmitBehavior="false" />
                                  <asp:Button ID="btnMod" runat="server" Text="�޸�" CssClass="bt1" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnMod_Click" UseSubmitBehavior="false" />
                                  <asp:Button ID="btnDel" runat="server" Text="ɾ��" CssClass="bt1" OnClientClick="if(ChkDel()==false)return false;" OnClick="btnDel_Click" UseSubmitBehavior="false" />
                                  <input id="btnInput" runat="server" type="button" class="bt1" value="����" onclick="ChkInput();" />
                                </td>
                                <td align="right" style="padding-right:10px;">
                                <span style="display:none;">
                                <asp:Button ID="btnShow" runat="server" Text="��ʾ" CssClass="bt1" OnClick="btnShow_Click" UseSubmitBehavior="false"/>
                                <asp:Button ID="btnRef" runat="server" Text="ˢ��" CssClass="bt1" OnClick="btnRef_Click" UseSubmitBehavior="false"/>
                                </span>
                                
                                    <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog();"/>
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
        if($("btnMod").value=="����")
        {
            if(isNull($("tbName").value))
            {
                window.alert("����ʧ�ܣ�"+document.getElementById("lbName").innerHTML+"����Ϊ��");
                $("tbName").focus();
                return false
            }
            if(!isNull($("tbArray").value))
            {
                if(!isDigit($("tbArray").value))
                {
                    window.alert("�������Ϊ����.");
                    $("tbArray").select();
                    return false
                }
            }
        }
    }else{return false;}
}

function ChkAdd()
{
    if($("btnAdd").value=="����")
    {
        if($("tbName").value=="")
        {
            window.alert("����ʧ�ܣ�"+document.getElementById("lbName").innerHTML+"����Ϊ��");
            $("tbName").focus();
            return false
        }
        if(!isNull($("tbArray").value))
        {
            if(!isDigit($("tbArray").value))
            {
                window.alert("�������Ϊ����.");
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
        return confirm("ȷ��Ҫɾ����["+document.getElementById("lbName").innerHTML+"]��");
    }else{return false;}
}

function ChkInput()
{
    parent.ShowDialog1(480, 193,'Basic/InputBase.aspx?str='+escape(document.getElementById("lbName").innerHTML), '���������Ϣ');
}
function ChkFocus()
{
    $("tbName").select();
}

</script>
