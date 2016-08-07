<%@ page language="C#"  CodeFile="SerAttachs.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Services_SerAttachs" theme="Themes" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
            <div class="sdiv" style="height:185px;background:white;overflow:auto;padding:0;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
                    <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:TemplateField>
                    <HeaderTemplate>
                    ��������
                    </HeaderTemplate>
                    <ItemTemplate>
                    <a href='<%#Eval("FilePath") %><%#Eval("FileName") %>' target="_blank"><%#Eval("FileName") %></a>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                    <HeaderTemplate>
                    ɾ��
                    </HeaderTemplate>
                    <ItemTemplate>
                    <a href="javascript:void(0);" onclick="ChkID('<%#Eval("ID") %>','<%#Eval("FilePath") %><%#Eval("FileName") %>')">ɾ��</a>
                    </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                    </asp:GridView>
                    
                <asp:HiddenField ID="hfAttachs" runat="server"/>
                <asp:HiddenField ID="hfRecID" runat="server"/>
                <asp:HiddenField ID="hfDelFile" runat="server"/>
                </ContentTemplate>
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnRfrh" EventName="Click" />
                </Triggers>
                </asp:UpdatePanel>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="right" style="display:none;">
                    <asp:Button ID="btnRfrh" runat="server" Text="ˢ��" OnClick="btnRfrh_Click" />
                    <asp:Button ID="btnDel" runat="server" Text="ɾ��" OnClick="btnDel_Click" />
                </td>
                <td align="right">
                    <input type="button" id="btnAddAttach" onclick="AddAttach()" value="���Ӹ���" runat="server" class="bt1"/>
                    <asp:Button ID="btnAdd" runat="server" Text="ȷ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnAdd_Click"/>
                    <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog1();"/>
                </td>
            </tr>
            </table>
         </div>
        </div>
        </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="Javascript" type="text/javascript">
function ChkID(id,filepath)
{
    $("hfRecID").value=id;
    $("hfDelFile").value=filepath;
    $("btnDel").click();
}
function AddAttach()
{
    parent.ShowDialog2(450, 93,"../Headquarters/Services/serAttachsAdd.aspx?f=2&fid=iframeDialog1&t=<%=aType %>&bid=<%=Str_bid %>","��Ӹ���");
}
function UploadedAttach(aid)
{
    $("hfAttachs").value=$("hfAttachs").value+aid+',';
}
function Rf()
{
    $("btnRfrh").click();
}
</script>
