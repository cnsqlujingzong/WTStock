<%@ page language="C#"  CodeFile="inputdevconf.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Customer_InputDevConf" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sa" style="width:466px;">
        <div class="fdiv">
            <div class="sdiv">
            <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td align="right">���ϴ�Excel�ļ���</td>
                    <td style="padding-left:0px;">
                    <a href="#" onclick="ChkUpload();" style="color:#0000ff;">����ϴ�</a>
                    <asp:HiddenField ID="hfPath" runat="server" />
                    <span style="display:none;">
                        <asp:Button ID="btnUp" runat="server" Text="up" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnUp_Click" /></span>
                    </td>
                </tr>
                <tr>
                    <td align="right">��ѡ��Excel������</td>
                    <td style="padding-left:0px;">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        <asp:DropDownList ID="ddlTableName" runat="server" CssClass="pindl" AutoPostBack="True" OnSelectedIndexChanged="ddlTableName_SelectedIndexChanged">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnUp" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            </div>
            </div>
            <div class="divh"></div>
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
               <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                       <td align="right">���ƣ�</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddl1" runat="server" CssClass="pindl">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">������</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddl2" runat="server" CssClass="pindl">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">���кţ�</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddl3" runat="server" CssClass="pindl">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">�����ڣ�</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddl4" runat="server" CssClass="pindl">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">�������ڣ�</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddl5" runat="server" CssClass="pindl">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">��ֹ���ڣ�</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddl6" runat="server" CssClass="pindl">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">��ע��</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddl7" runat="server" CssClass="pindl">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                 </table>
               </ContentTemplate>
               <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="ddlTableName" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="ȷ��" CssClass="bt1" OnClientClick="if(ChkAdd()==false) return;" UseSubmitBehavior="false" OnClick="btnAdd_Click"/>
                    <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog();"/>
                </td>
            </tr>
            </table>
         </div>
        </div>
        </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
var processtip=1;

function ChkAdd()
{
    if($("ddlTableName").value=="")
    {
        alert("��ѡ��Excel����");
        $("ddlTableName").focus();
        return false;
    }
    
    if($("ddl1").value=="")
    {
        alert("��ѡ������");
        $("ddl1").focus();
        return false;
    }
}
function ChkUpload()
{
    parent.ShowDialog1(600, 380, 'System/UpLoadExcel.aspx', '�ϴ�Excel');
}
</script>