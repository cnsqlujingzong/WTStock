<%@ page language="C#"  CodeFile="main.aspx.cs"     autoeventwireup="true" inherits="Web_Main" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>���߱���ƽ̨-�ҵĿ���̨</title>
    <link rel="stylesheet" href="public/css/my.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div id="m_main">
		<div id="m_top">
			<div id="m_logo"><a href="Default.aspx"><asp:Image ID="imgLogo" runat="server" ImageUrl="~/Web/public/images/logo.jpg" ToolTip="���߱���ƽ̨" /></a></div>
			<div id="m_word">����λ�ã�<a href="Default.aspx" title="��ҳ">��ҳ</a><a href="Main.aspx" class="sp1" title="�ҵĿ���̨">�ҵĿ���̨</a><span class="sp1" id="spath">����</span></div>
			<div id="m_tright">
			<div id="m_menu">
				<ul>
				    <li class="li1"><a href="Report.aspx" target="subfrm" style="color:#04d;" title="��Ҫ����">��Ҫ����</a></li>
					<li><a href="ServicesList.aspx" target="subfrm" title="�ҵķ���">�ҵķ���</a></li>
					<li><a href="Device.aspx" target="subfrm" title="�ҵĻ�������">�ҵĻ�������</a></li>
					<li><a href="User.aspx" target="subfrm" title="�ҵ���Ϣ">�ҵ���Ϣ</a></li>
					<li><a href="Password.aspx" target="subfrm" title="�޸�����">�޸�����</a></li>
					<li><a href="#" class="a2" onclick="chkexit();" title="�˳�" style="color:#04d;">�˳�</a></li>
				</ul>
			</div>
			<div id="m_user">
				<span class="sp3">��Ա��:<span class="sp2"><%=Str_user%></span></span>
				<span style="display:none;"><asp:Button ID="btnExit" runat="server" Text="exit" OnClick="btnExit_Click" /></span>
			</div>
			</div>
			<div style=" clear:both;"></div>
		</div>
		<div id="m_center">
			<div id="m_left">
				<div class="menu" style="margin-top:0;">�ҵĿ���̨</div>
				<ul>
				    <li><a href="Report.aspx" target="subfrm" style="color:#04d;" title="��Ҫ����">��Ҫ����</a></li>
				    <li><a href="ReportList.aspx" target="subfrm" title="�ҵı��޵�">�ҵı��޵�</a></li>
				    <li style="display:none;"><a href="ServicesCall.aspx" target="subfrm" title="���޻ط�">���޻ط�</a></li>
					<li><a href="ServicesList.aspx" target="subfrm" title="�����б�">�����б�</a></li>
					<li><a href="Device.aspx" target="subfrm" title="�ҵĻ�������">�ҵĻ�������</a></li>
					<li style="display:none;"><a href="Repository.aspx" target="subfrm" title="֪ʶ��">֪ʶ��</a></li>
					<li><a href="User.aspx" target="subfrm" title="�ҵ���Ϣ">�ҵ���Ϣ</a></li>
					<li><a href="Password.aspx" target="subfrm" title="�޸�����">�޸�����</a></li>
				</ul>
					<div class="menu" style="margin-top:0;">�ɹ��µ�</div>
				<ul>	
					<li><a href="SellPlanAdd.aspx" target="subfrm" title="�½�����">�½�����</a></li>
					<li><a href="SchSellPlan.aspx" target="subfrm" title="�����б�">�����б�</a></li>
			    </ul>
			        <div class="menu" style="margin-top:0;">����/ȫ��ҵ��</div>
			    <ul>
					<li><a href="LeaseAdd.aspx" target="subfrm" title="�½�ҵ��">�½�ҵ��</a></li>
					<li><a href="SchLease.aspx" target="subfrm" title="ҵ���б�">ҵ���б�</a></li>
				</ul>
			</div>
			<div id="m_right"><iframe id="subfrm" name="subfrm" frameborder="0" height="100%" width="100%" scrolling="yes" style="overflow:auto;" src="Nav.aspx" ></iframe></div>
			<div style="clear:both;"></div>
		</div>
		<div id="m_foot">
			<ul>
                <li><asp:Label ID="lbcorp" runat="server"></asp:Label> @2009</li>
			</ul>
		</div>
	</div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="public/script/common.js"></script>
<script language="javascript" type="text/javascript">
function chkexit(){if(confirm("ȷ��Ҫ�˳���")){$("btnExit").click();}}
</script>
