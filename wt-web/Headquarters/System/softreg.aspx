<%@ page language="C#"  CodeFile="softreg.aspx.cs"     autoeventwireup="true" inherits="Headquarters_System_SoftReg" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sa" style="width:586px;">
    <div id="tdiv1">
        <div class="fdiv">
        <div class="sdiv" style="height:230px;background:#fff;">
        <div style="height:228px; overflow:auto;">
        <p style="font-size:14px;">��һ�������������ṩ�Ļ�ʽ��</p>
        <p>====================================================</p>
        
        <p><span>1�����ע�����</span><br />
           <span style="color:#4b4b4b; padding-left:20px;">��������ѯ��������ѯ���ش����̡�</span></p>
           
        <p><span>2��ΪʲôҪע��</span><br />
           <span style="color:#4b4b4b; padding-left:20px; line-height:150%;">����ע���Ƕ����ǹ�����֧�֣�Ҳ�����ǿ����Ķ�����ע�����Եõ���Ϊ�ܵ����ۺ����ע�������������κ����ơ�</span></p>
        
        <p><span>3�����ǿ��Խ��ܵĻ�ʽ</span><br /></p>
        <p style="line-height:150%;">   
            ����������һ��ͨ<br />
            ���������壬�ʺţ�6225 8857 1264 3923<br />
            �����У���������������<br /><br />
            
            ����������ĵ����ͨ��<br />
            ���������壬�ʺţ�1202020101016876557<br /><br />
            
            ��������������<br />
            ����������<br />
            ���ţ�4367 4215 4080 0070 331<br /><br />
            
            ��ũҵ����<br />
            ���������壬�ʺţ�95599 8032 00598 26216<br />
            �����У�������ũҵ����<br /><br />
            
            ��ͨ���ʾֵ��<br />
            ��ַ�������������������Ƽ�԰����·210�Ű��ɿƼ�԰6��¥��¥<br />
            �ʱࣺ310012<br />
            �տ��ˣ�����<br /><br />
            
            ����Ҳ����ͨ�����ǵĴ��������ע�ᣬΪ�˰�ȫ������ͨ���绰�����Ǻ˶Դ�������Ϣ��</p>
            
        <p><span>4����ϵ����</span><br /></p>
        <p style="line-height:150%;">
        �����ʼ���liuyi@differsoft.com �� huadog@yeah.net<br />
        �绰��0571-88223317��88223312��13157103546<br />    
        ��ҳ��http://www.differsoft.com<br />
        ��ϵ�ˣ�������  <br />
        </p>
           
        </div>
        </div>
        </div>
        
        <div class="divh"></div>
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right">
                <input id="btnStep2" type="button" value="��һ��:�ݽ��û���Ϣ" onclick="ChkPane('tdiv2');document.getElementById('tbName').select();"/>
            </td>
        </tr>
        </table>
        
    </div>
    
    <div id="tdiv2" style=" display:none;">
    
    <div style="font-size:14px; padding:5px">�ڶ������ݽ��û���Ϣ��ע����Ϣ�����ϵͳ��������Ϣһ�¡�</div>
    <div class="fdiv">
    <div class="sdiv" style="background:#ffffff;height:203px;">
        <div style="padding:5px 0px 0px 0px; height:200px;">
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td>��˾���ƣ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin" Width="200"></asp:TextBox>
                <span style="color:#ff0000">*</span>
                </td>
            </tr>
            <tr>
                <td>��ϵ�绰��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin" Width="200"></asp:TextBox>
                <span style="color:#ff0000">*</span>
                </td>
            </tr>
            <tr>
                <td>�������룺</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbZip" runat="server" CssClass="pin" Width="200"></asp:TextBox>
                <span style="color:#ff0000">*</span>
                </td>
            </tr>
            <tr>
                <td align="right">��ַ��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="200"></asp:TextBox>
                <span style="color:#ff0000">*</span>
                </td>
            </tr>
            <tr>
                <td align="right">
                <asp:DropDownList ID="ddlbSim" runat="server" CssClass="pindl" Width="60px">
                <asp:ListItem Value="0">�û���</asp:ListItem>
                <asp:ListItem Value="1">������</asp:ListItem>
                </asp:DropDownList>��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBranchNum" runat="server" CssClass="pin pbb" Width="200"></asp:TextBox>
                <span style="color:#ff0000">*</span>
                </td>
            </tr>
            <tr>
                <td align="right">Webģ�飺</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlWeb" runat="server" CssClass="pindl">
                        <asp:ListItem Value="0">δ����Webģ��</asp:ListItem>
                        <asp:ListItem Value="1">�ѹ���Webģ��</asp:ListItem>
                    </asp:DropDownList>
                <span style="color:#ff0000">*</span>
                </td>
            </tr>
        </table>
        </div> 
    </div>
    </div>
    
    <div class="divh"></div>
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td><asp:Button ID="btnSave" runat="server" Text="���ߵݽ�ע����Ϣ:" style="color:#ff0000" UseSubmitBehavior="false" OnClientClick="if(Chk('1')==false)return false;" OnClick="btnSave_Click" />
            </td>
            <td align="right">
                <input id="Button1" type="button" value="��һ��:���ע����" onclick="if(Chk('')!=false){ChkPane('tdiv3');}"/>
            </td>
        </tr>
        </table>
    </div>
   
    
    <div id="tdiv3" style=" display:none;">
    
    <div style="font-size:14px; padding:5px">
    <span style="color:#666">���ߵݽ�ע����Ϣ���û�������ֱ�ӻ��ע���롣</span>
    <asp:Button ID="btnGet" runat="server" Text="��˻��ע����:"  UseSubmitBehavior="false" OnClick="btnGet_Click" />
    </div>
    <div class="fdiv">
    <div class="sdiv" style="height:198px; background:#ffffff">
        <div style="height:195px;padding:5px 0px 0px 0px;">
        <table cellpadding="0" cellspacing="0" class="tb3" style="margin-top:10px;">
            <tr>
                <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                <ContentTemplate>
                    ����ע����:
                    <asp:TextBox ID="tbRegCode" runat="server" Width="250"></asp:TextBox>
                  </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnGet" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                </Triggers>
                </asp:UpdatePanel>   
                                 
                </td>
                <td>
                <asp:Button ID="btnFsh" runat="server" Text="���ע��:"  UseSubmitBehavior="false" OnClick="btnFsh_Click"/>
                <img src="../../Public/Images/ok.gif" alt="" />
                </td>
            </tr>
        </table>
    </div>
    </div>
    </div>
        
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td><input id="Button2" type="button" value="��һ��:�ݽ��û���Ϣ" onclick="ChkPane('tdiv2');document.getElementById('tbName').select();"/></td>
    </tr>
    </table>
    </div>
    
    </div>
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/menu.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function Chk(f)
{
    if(isNull($("tbName").value))
    {
        window.alert("����ʧ�ܣ���˾������Ϊ��");
        $("tbName").select();
        return false;
    }
    if(isNull($("tbTel").value))
    {
        window.alert("����ʧ�ܣ���ϵ�绰����Ϊ��");
        $("tbTel").select();
        return false;
    }
    if(isNull($("tbZip").value))
    {
        window.alert("����ʧ�ܣ��������벻��Ϊ��");
        $("tbZip").select();
        return false;
    }
    if(isNull($("tbAdr").value))
    {
        window.alert("����ʧ�ܣ���ַ����Ϊ��");
        $("tbAdr").select();
        return false;
    }
    
    if(isNull($("tbBranchNum").value))
    {
        window.alert("����ʧ�ܣ��û�������Ϊ��");
        $("tbBranchNum").select();
        return false;
    }
    if(!isNull($("tbBranchNum").value))
    {
        if(!isDigit($("tbBranchNum").value))
        {
            window.alert("�û�����ʽ����ȷ.");
            $("tbBranchNum").select();
            return false;
        }
    }
    if(f=="1"){
    return confirm("ȷ��Ҫ�ݽ�ע����Ϣ������Ѿ��ݽ������벻Ҫ�ظ��ݽ�");}
}

function ChkPane(mdiv)
{
    $(mdiv).style.display="block";
    for(var i=1;i<=3;i++)
    {
        if(("tdiv"+i)!=mdiv)
        {
            $("tdiv"+i).style.display="none";
        }
    }
}
</script>
