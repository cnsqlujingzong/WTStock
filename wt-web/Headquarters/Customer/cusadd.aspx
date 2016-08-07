<%@ page language="C#"  CodeFile="cusadd.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Customer_CusAdd" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sad" style="width:586px;">
         <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td class="blue">�ͻ����ƣ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin" Width="220"></asp:TextBox></td>
                <td class="blue">�ͻ���ţ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbCusNO" runat="server" CssClass="pin" Enabled="false"></asp:TextBox></td>
                <td class="sysred" style="padding-left:5px;">
                    <asp:CheckBox ID="cbsys" runat="server" Text="ϵͳĬ��" Checked="true" onclick="ChkSysNO();" /></td>
            </tr>
         </table>
        <div class="divh"></div>
        <div id="mytabs">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">������Ϣ</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">��ϵ����</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">�Զ���</span>
            <span id="tabs_r3"></span>

       
        </div>
        <div id="info1" style="padding:3px 0px 0px 3px; overflow:hidden;">
        <div id="divinfo1" class="divinfo" style="height:282px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                       <td>�ͻ����</td>
                        <td style="padding-left:0px;">
                            <div class="isinDiv">
                            <input type="text" id="tbCusClass" runat="server" class="pin pinin" readonly="readonly" />
                                <select id="slCusClass" runat="server" onchange="getclassvalue('tbCusClass',this.options[this.selectedIndex].text);" class="pininsl">
                                </select>
                            </div>
                         </td>
                         <td align="right">�ͻ�״̬��</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="pindl">
                            </asp:DropDownList>
                        </td>
                       <td>�����ˣ�<asp:TextBox ID="txtjieshao" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">��ϵ�ˣ�</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td>��ϵ�绰��</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">�ֻ����룺</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbTel2" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right">���棺</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbFax" runat="server" CssClass="pin"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">�ʱࣺ</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbZip" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right">Email��</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbEmail" runat="server" CssClass="pin"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">QQ/MSN��</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbQQ" runat="server" CssClass="pin"></asp:TextBox>
                        </td>
                        <td align="right">�ͻ���Դ��</td>
                        <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlFrom" runat="server" CssClass="pindl" onchange="NewFrom();">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right">�ͻ�����</td>
                        <td style="padding-left:0px;">
                        <div class="isinDiv">
                        <asp:TextBox ID="tbArea" runat="server" CssClass="pin pinin"></asp:TextBox>
                        <asp:DropDownList ID="ddlArea" runat="server" CssClass="pininsl" onchange="document.getElementById('tbArea').value=this.options[this.selectedIndex].text;NewArea('1');">
                        </asp:DropDownList>
                        </div>
                        </td>
                        <td align="right">��ͼ���꣺</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbCoordinates" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td style="padding:0px;"><input id="btnSlt" type="button" value="" onclick="SltCoor();" class="bview"/></td>
                    </tr>
                    <tr>
                        <td align="right">ҵ��Ա��</td>
                        <td style="padding-left:0px;"><asp:DropDownList ID="ddlSeller" runat="server" CssClass="pindl">
                            </asp:DropDownList>
                        </td>
                        <td align="right">��Ա����</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlMember" runat="server" CssClass="pindl">
                            </asp:DropDownList>
                        </td>
                        
                    </tr>
                    <tr>
                        <td align="right">�ʻ���</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbAccount" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right">�������㣺</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl">
                            </asp:DropDownList>
                        </td>
                        <td>
                            ������ȣ�<asp:TextBox ID="tbPosition" runat="server" Width="70px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">��ַ��</td>
                        <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
                        <td style="padding-left:15px;">
                            <asp:CheckBox ID="cbCall" runat="server" Checked="true" /> �ط�
                             <asp:CheckBox ID="cbTrack" runat="server" Checked="true"/> ����
                        </td>
                    </tr>
                    <tr>
                        <td align="right">��ע��</td>
                        <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
                        <td style="padding-left:15px;">
                             <asp:CheckBox ID="cbStop" runat="server" /> <span class="sysred">ͣ�ñ�־</span>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnRef" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnRefFrom" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
            </div>
            </div>
            <div id="info2">
                <div class="divcon" style="height:261px;">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" SkinID="gv4" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="����" DataField="����" />
                            <asp:BoundField HeaderText="����" DataField="����" />
                            <asp:BoundField HeaderText="�Ա�" DataField="�Ա�" />
                            <asp:BoundField HeaderText="ְλ" DataField="ְλ" />
                            <asp:BoundField HeaderText="�칫�绰" DataField="�칫�绰" />
                            <asp:BoundField HeaderText="լ��" DataField="լ��" />
                            <asp:BoundField HeaderText="�ƶ��绰" DataField="�ƶ��绰" />
                            <asp:BoundField HeaderText="����" DataField="����" />
                            <asp:BoundField HeaderText="Email" DataField="Email" />
                            <asp:BoundField HeaderText="����" DataField="����" />
                            <asp:BoundField HeaderText="��ַ" DataField="��ַ" />
                            <asp:BoundField HeaderText="��ע" DataField="��ע" />
                        </Columns>
                    </asp:GridView>
                    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
                    <asp:HiddenField ID="hfLinkMan" runat="server" Value="-1" />
              </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnDelLink" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnAddLinkMan" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnModLinkMan" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnShowLinkMan" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                </Triggers>
              </asp:UpdatePanel>
              </div>
              <div class="fbombtn">
              <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                    <td style="padding-left:0px;">
                    <input id="btnNewLinkMan" type="button" value="�½�" class="bt1" onclick="if(strtel!=''&&'<%=Str_D %>'=='3') return false;parent.ShowDialog<%=Str_D %>(460, 360, '../Headquarters/Customer/CusLinkManAdd.aspx?f=<%=Str_F %>'+strtel, '�½���ϵ��');"/>
                    <input id="btnEditLinkMan" type="button" value="�޸�" class="bt1" onclick="if(strtel!=''&&'<%=Str_D %>'=='3') return false;ModLinkMan(460, 363,'../Headquarters/Customer/CusLinkManMod.aspx','�޸���ϵ��');"/>
                    <asp:Button ID="btnDelLink" runat="server" Text="ɾ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnDelLink_Click" />
                    </td>
                    </tr>
              </table>
              </div>
            </div>
            <div id="info3" style="padding:3px 0px 0px 3px; overflow:hidden;">
            <div id="div2" class="divinfo" style="height:282px;">
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td align="right"><asp:Label ID="lbuserdef1" runat="server" Text="�ͻ��Զ���1"></asp:Label>��</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef1" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right"><asp:Label ID="lbuserdef2" runat="server" Text="�ͻ��Զ���2"></asp:Label>��</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef2" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right"><asp:Label ID="lbuserdef3" runat="server" Text="�ͻ��Զ���3"></asp:Label>��</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef3" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right"><asp:Label ID="lbuserdef4" runat="server" Text="�ͻ��Զ���4"></asp:Label>��</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef4" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right"><asp:Label ID="lbuserdef5" runat="server" Text="�ͻ��Զ���5"></asp:Label>��</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef5" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right"><asp:Label ID="lbuserdef6" runat="server" Text="�ͻ��Զ���6"></asp:Label>��</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef6" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="padding-left:5px;color:#0000ff">
                <asp:CheckBox ID="cbClose" runat="server" Text="�����رմ���" Checked="true" />
                     <asp:HiddenField ID="hfArea" runat="server" />
                     <asp:HiddenField ID="hfCusFrom" runat="server" />
                   <span style="display:none;">
                        <asp:Button ID="btnRef" runat="server" Text="Ref" OnClick="btnRef_Click" />
                        <asp:Button ID="btnRefFrom" runat="server" Text="RefFrom" OnClick="btnRefFrom_Click" />
                   </span>
                </td>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
                    <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog<%=Str_F %>('1');"/>
                </td>
            </tr>
            </table>
         </div>
        </div>
        </div>
         <span style="display:none;">
               <asp:Button ID="btnAddLinkMan" runat="server" Text="AddLinkMan" OnClick="btnAddLinkMan_Click" />
               <asp:Button ID="btnModLinkMan" runat="server" Text="ModLinkMan" OnClick="btnModLinkMan_Click" />
               <asp:Button ID="btnShowLinkMan" runat="server" Text="ShowLinkMan" OnClick="btnShowLinkMan_Click" />
         </span>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var tabnum=4;
var isfocus=1;
var processtip=1;
var strtel="";
var uri=location.href;
if(uri.indexOf("itel=1")>0)
    strtel="&itel=1";
function ChkID(id)
{
    ClrID(id);
    $("btnShowLinkMan").click();
}

function ChkAdd()
{
    if(isNull($("tbName").value))
    {
        window.alert("����ʧ�ܣ��ͻ����Ʋ���Ϊ��");
        $("tbName").focus();
        return false
    }
    if(!$("cbsys").checked)
    {
        if(isNull($("tbCusNO").value))
        {
            window.alert("����ʧ�ܣ��ͻ���Ų���Ϊ��");
            $("tbCusNO").focus();
            return false
        }
    }
    if($("ddlSeller").value=="-1")
    {
        window.alert("����ʧ�ܣ�ҵ��Ա����Ϊ��");
        $("ddlSeller").focus();
        return false
    }
}


function ChkSysNO()
{
    if(!$("cbsys").checked)
    {
        $("tbCusNO").disabled=false;
        $("tbCusNO").focus();
    }else
    {
        $("tbCusNO").disabled=true;
    }
}

//-----------������Ϣ----------------//
//�޸�
function ModLinkMan(w,h,url,title)
{
    if(ChkSlt()!=false)
    {
        var str=document.getElementById("hfLinkMan").value;
        parent.ShowDialog<%=Str_D %>(w,h,url+"?str="+escape(str)+"&f=<%=Str_F %>"+strtel,title);
    }
}
function SltCoor()
{
    if(strtel!=""&&"<%=Str_D %>"=="3")
        return false;
    var str=$("tbArea").value;
    parent.ShowDialog<%=Str_D %>(800,520,"../Headquarters/Customer/SltCoor.aspx"+"?str="+escape(str)+"&f=<%=Str_F %>"+strtel,'ѡ������');
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
//--------End----------------//
</script>
