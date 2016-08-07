<%@ page language="C#"  CodeFile="deviceadd.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Lease_DeviceAdd" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:686px;">
    
    <div class="fdivs" style="width:684px;">
    <div class="sdivs" style="width:682px;">
    <div class="divh"></div>
      <table cellpadding="0" cellspacing="0" class="tb5">
            <tr>
                <td>�ͻ����ƣ�</td>
                <td style="padding:0px;" colspan="3">
                    <asp:TextBox ID="tbCusName" runat="server" CssClass="pinb" Width="343" ReadOnly="true"></asp:TextBox>
                </td>
                <td>��ͬ��ţ�</td>
                <td style="padding:0px;">
                    <asp:TextBox ID="tbAutoNO" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>��ʼ���ڣ�</td>
                <td style="padding:0px;">
                    <asp:TextBox ID="tbStartDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td>��ֹ���ڣ�</td>
                <td style="padding:0px;">
                    <asp:TextBox ID="tbEndDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td align="right">�������ڣ�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbChargeCycle" runat="server" CssClass="pin"></asp:TextBox>
                    <span class="red">��</span>
                </td>
            </tr>
            <tr>
                <td>�������⣺</td>
                <td style="padding:0px;">
                    <asp:TextBox ID="tbRent" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td style="padding-left:0px;" align="right">
                    <a href="#" onclick="ChkUpload();">�ϴ�����</a>
                    <asp:HiddenField ID="hfPath" runat="server" />
                    <span style="display:none;">
                    <asp:DropDownList ID="ddlStock" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlBrand" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlClass" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlModel" runat="server">
                    </asp:DropDownList>
                    </span>
                </td>
                <td style="padding-left:0px;" colspan="4">
                    <div id="dUpload" runat="server"></div>
                </td>
            </tr>
       </table>
       <div class="divh"></div>
    </div>
    </div>
      
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <div class="divh"></div>
        <div class="fdivs" style="width:684px; height:255px;">
        <div class="sdivs" style="width:682px; height:253px; overflow:auto; background:#ffffff;">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound" OnRowDeleting="gvdata_RowDeleting">
                        <Columns>
                        <asp:BoundField HeaderText="��" />
                        <asp:TemplateField HeaderText="�ֿ�">
                            <ItemTemplate>
                                <asp:TextBox ID="tbStock" runat="server" Text='<%# Eval("Stock") %>' style="display:none;"></asp:TextBox>
                                <asp:DropDownList ID="ddlStock" runat="server" CssClass="pindl" Width="80">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="���޻���" DataField="GoodsNO" />
                        <asp:TemplateField HeaderText="����">
                            <ItemTemplate>
                                <asp:TextBox ID="tbCount" runat="server" CssClass="pin" Width="80" Text='<%# Eval("iCount") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�������">
                            <ItemTemplate>
                                <asp:TextBox ID="tbPrice" runat="server" CssClass="pin" Width="80" Text='<%# Eval("dPrice") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���">
                            <ItemTemplate>
                                <asp:Label ID="tbTotal" runat="server" CssClass="pin" Width="80" Text='<%# Eval("dTotal") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�������">
                            <ItemTemplate>
                                <asp:TextBox ID="tbDeviceNO" runat="server" CssClass="pin" Width="80" Text='<%# Eval("DeviceNO") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="����Ʒ��">
                            <ItemTemplate>
                                <asp:TextBox ID="tbBrand" runat="server" Text='<%# Eval("Brand") %>' style="display:none;"></asp:TextBox>
                                <asp:DropDownList ID="ddlBrand" runat="server" CssClass="pindl" Width="80">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���">
                            <ItemTemplate>
                                <asp:TextBox ID="tbClass" runat="server" Text='<%# Eval("Class") %>' style="display:none;"></asp:TextBox>
                                <asp:DropDownList ID="ddlClass" runat="server" CssClass="pindl" Width="80">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�ͺ�">
                            <ItemTemplate>
                                <asp:TextBox ID="tbModel" runat="server" Text='<%# Eval("Model") %>' style="display:none;"></asp:TextBox>
                                <asp:DropDownList ID="ddlModel" runat="server" CssClass="pindl" Width="120">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���к�">
                            <ItemTemplate>
                                <asp:TextBox ID="tbSN1" runat="server" CssClass="pin" Width="80" Text='<%# Eval("SN1") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���к�2">
                            <ItemTemplate>
                                <asp:TextBox ID="tbSN2" runat="server" CssClass="pin" Width="80" Text='<%# Eval("SN2") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="������">
                            <ItemTemplate>
                                <asp:TextBox ID="tbstrQty" runat="server" style="display:none;" Text='<%# Eval("strQty") %>'></asp:TextBox>
                                <asp:HyperLink ID="hlstrQty" runat="server" NavigateUrl="#d" ToolTip="�༭������">�༭������</asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="��ע">
                            <ItemTemplate>
                                <asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Text='<%# Eval("Remark") %>' Width="160"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ɾ��">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="ɾ��" style="color:#0000ff;"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:HiddenField ID="hfreclist" runat="server" />
                    <asp:HiddenField ID="hfSltID" runat="server" />
                    
                     <span style="display:none;">
                         <asp:Button ID="btnId" runat="server" Text="..." OnClick="btnId_Click" />
                         <asp:Button ID="btnSure" runat="server" Text="..." OnClick="btnSure_Click" />
                         <asp:Button ID="btnsngetgds" runat="server" Text="..." OnClick="btnsngetgds_Click" />
                     </span>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
                </Triggers>
             </asp:UpdatePanel>
        </div>
        </div>
      </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
      <div class="divh"></div>
      <div class="tdiv">
        <table cellpadding="0" cellspacing="0" class="tb4">
            <tr>
                <td style="padding-left:15px;">
                    <asp:DropDownList ID="ddlSchFld" runat="server" CssClass="pindl" Width="70">
                        <asp:ListItem Value="SN">�����к�</asp:ListItem>
                        <asp:ListItem Value="BarCode">������</asp:ListItem>
                        <asp:ListItem Value="GoodsNO">�����</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td><asp:TextBox ID="tbCon" runat="server" CssClass="pin" onkeydown="EnterTextBox(event, this);" ToolTip="������ɺ�س����"></asp:TextBox></td>
                <td><input id="tbSltGoods" type="button" value="ѡ���Ʒ" class="bt1" onclick="parent.ShowDialog1(800, 520, 'Stock/SltGoods.aspx', 'ѡ���Ʒ');" /></td>
                <td><input id="btnSltSN" type="button" value="ѡ��SN" class="bt1" onclick="parent.ShowDialog1(800, 520, 'Stock/SltSN.aspx?fid=iframeDialog&iflag=1', 'ѡ�����к�');" /></td>
            </tr>
        </table>
      </div>
      <div class="divh"></div>
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:Label ID="lbMod" runat="server" Text=""></asp:Label>
            </td>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" Text="ȷ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
                <asp:Button ID="btnClean" runat="server" Text="���" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkClean()==false)return false;" OnClick="btnClean_Click"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/detailslt.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">

function ChkAdd()
{
    if(isNull($("tbStartDate").value))
    {
        window.alert("����ʧ�ܣ���ʼ���ڲ���Ϊ��");
        $("tbStartDate").focus();
        return false
    }
    
    if(isNull($("tbEndDate").value))
    {
        window.alert("����ʧ�ܣ���ֹ���ڲ���Ϊ��");
        $("tbEndDate").focus();
        return false
    }
    if(isNull($("tbRent").value))
    {
        window.alert("����ʧ�ܣ��������ⲻ��Ϊ��");
        $("tbRent").focus();
        return false
    }
    if(!isMoney($("tbRent").value))
    {
        window.alert("���������ʽ����ȷ");
        $("tbRent").focus();
        return false
    }
}

function EnterTextBox(event, obj)
{
    if(event.keyCode == 13&&!isNull(obj.value))
    {
        if(!isNull(obj.value))
        {
            $("btnSure").click();
        }
    }
}
function EditQty(tbqty)
{
    parent.ShowDialog1(600, 380, 'Lease/EditQty.aspx?tbqty='+tbqty+'&ff=1&qtyvalue='+escape($(tbqty).value), '�༭������');
}
function ChkUpload()
{   
    if($("dUpload").innerHTML=="")
    {
        parent.ShowDialog1(600, 380, 'Lease/UpLoad.aspx', '�ϴ���ͬ����');
    }
    else
    {
        if(confirm("�Ѿ�����һ�������������ϴ����滻�ø������Ƿ������"))
        {
            parent.ShowDialog1(600, 380, 'Lease/UpLoad.aspx', '�ϴ���ͬ����');
        }
    }
}
function calcAmountByPrice(obj,tbcount,lbrent)
{
    var price = parseFloat(obj.value);
    var count = parseInt(document.getElementById(tbcount).value);
    
    if(obj.value !="" && document.getElementById(tbcount).value != "")
    {
        document.getElementById(lbrent).innerHTML = price * count;
    }
}
function calcAmountByCount(obj,tbprice,lbrent)
{
    var price = parseFloat(document.getElementById(tbprice).value);
    var count = parseInt(obj.value);
    
    if(obj.value !="" && document.getElementById(tbprice).value != "")
    {
        document.getElementById(lbrent).innerHTML = price * count;
    }
}
function Caculate()
{
    var tb=$("gvdata");
    var summoney=0;
    for(i=1;i<tb.rows.length;i++)
    {
        var total=tb.rows[i].cells[5].getElementsByTagName("span")[0].innerHTML;
        if(!isNaN(total))
        {
            summoney+=parseFloat(total);
        }
    }
    var begin = $("tbRent").value;
    if(parseFloat(begin)!=NaN)
    {
        $("tbRent").value=summoney+parseFloat(begin);
    }
}
</script>
