<%@ page language="C#"  CodeFile="goodspriceadjust.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stock_GoodsPriceAdjust" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:456px;">
            <div class="divh"></div>
            <div id="cndiv" style="height:240px;width:454px;">
                <div class="fdivs" style="height:238px;width:452px;">
                    <div class="sdivs" style="height:236px;width:450px;background:#ffffff; margin-left:auto; margin-right:auto;">
                      <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <asp:GridView ID="gvgds" runat="server" AutoGenerateColumns="False" SkinID="gv3"  EnableViewState="False" OnRowDataBound="gvgds_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="Label1" runat="server" Text="�����"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="cb" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="ID" DataField="goodsadjustconfigid"/>
                    <asp:BoundField HeaderText="����۵ļ۸�" DataField="pricename1" />
                    <asp:BoundField HeaderText="ʹ�û�׼�۸�" DataField="pricename2" />
                    <asp:BoundField HeaderText="�����" DataField="separator" />
                    <asp:BoundField HeaderText="����ֵ" DataField="price" />
                    <asp:BoundField HeaderText="��ʽ" DataField="formula" />

                </Columns>
                </asp:GridView>
                <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
                <asp:HiddenField ID="hfcbID" runat="server" />
                <span style=" display:none;">
                   <asp:Button ID="Refresh" runat="server" Text="ˢ��" OnClick="Refresh_Click" />
                </span>
                </ContentTemplate>
                <Triggers>
                 <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
                 <asp:AsyncPostBackTrigger ControlID="btnStart" EventName="Click" />
                 </Triggers>
                </asp:UpdatePanel>
                
             </div>
             </div>
             </div>
             <div class="divh"></div>
             
             <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <input id="btnNew" type="button" value="�½�" class="bt1" runat="server"  onclick="parent.ShowDialog1(340, 125, 'Stock/GoodsPriceAdjustAdd.aspx', '�½��۸�');"/>
                        <input id="btnMod" type="button" value="�޸�" class="bt1" runat="server"  onclick="ChkModA(340, 125,'Stock/GoodsPriceAdjustUpdate.aspx','�޸�');"/>
                        <asp:Button ID="btnDel" runat="server" Text="ɾ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDelGds()==false) return false;" OnClick="btnDel_Click"/>
                    </td>
                    <td align="right">
                        <asp:Button ID="btnStart" runat="server" Text="��ʼ����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(CheckNull()==false) return false"  OnClick="btnStart_Click"  />
                        <input id="btnClose" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog();" />
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
<script language="javascript" type="text/javascript">
function ChkID(id)
{
    ClrID(id);
}
function ShowGds()
{
    ChkModA(340, 125,'Stock/GoodsPriceAdjustUpdate.aspx','�޸�');
}
function ChkDelGds()
{
    if(ChkSltValue()!=false)
    {
        return confirm("ȷ��Ҫɾ����");
    }
    else
    {
        return false;
    }
}
function CheckNull()
{
    if(isNull($("hfcbID").value))
    {
        window.alert("��ѡ��һ���¼��");
        return false
    }  
}

</script>
