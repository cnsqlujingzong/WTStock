<%@ page language="C#"  CodeFile="main.aspx.cs"     autoeventwireup="true" inherits="Web_Main" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>在线报修平台-我的控制台</title>
    <link rel="stylesheet" href="public/css/my.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div id="m_main">
		<div id="m_top">
			<div id="m_logo"><a href="Default.aspx"><asp:Image ID="imgLogo" runat="server" ImageUrl="~/Web/public/images/logo.jpg" ToolTip="在线报修平台" /></a></div>
			<div id="m_word">您的位置：<a href="Default.aspx" title="首页">首页</a><a href="Main.aspx" class="sp1" title="我的控制台">我的控制台</a><span class="sp1" id="spath">管理</span></div>
			<div id="m_tright">
			<div id="m_menu">
				<ul>
				    <li class="li1"><a href="Report.aspx" target="subfrm" style="color:#04d;" title="我要报修">我要报修</a></li>
					<li><a href="ServicesList.aspx" target="subfrm" title="我的服务单">我的服务单</a></li>
					<li><a href="Device.aspx" target="subfrm" title="我的机器档案">我的机器档案</a></li>
					<li><a href="User.aspx" target="subfrm" title="我的信息">我的信息</a></li>
					<li><a href="Password.aspx" target="subfrm" title="修改密码">修改密码</a></li>
					<li><a href="#" class="a2" onclick="chkexit();" title="退出" style="color:#04d;">退出</a></li>
				</ul>
			</div>
			<div id="m_user">
				<span class="sp3">会员名:<span class="sp2"><%=Str_user%></span></span>
				<span style="display:none;"><asp:Button ID="btnExit" runat="server" Text="exit" OnClick="btnExit_Click" /></span>
			</div>
			</div>
			<div style=" clear:both;"></div>
		</div>
		<div id="m_center">
			<div id="m_left">
				<div class="menu" style="margin-top:0;">我的控制台</div>
				<ul>
				    <li><a href="Report.aspx" target="subfrm" style="color:#04d;" title="我要报修">我要报修</a></li>
				    <li><a href="ReportList.aspx" target="subfrm" title="我的报修单">我的报修单</a></li>
				    <li style="display:none;"><a href="ServicesCall.aspx" target="subfrm" title="报修回访">报修回访</a></li>
					<li><a href="ServicesList.aspx" target="subfrm" title="服务单列表">服务单列表</a></li>
					<li><a href="Device.aspx" target="subfrm" title="我的机器档案">我的机器档案</a></li>
					<li style="display:none;"><a href="Repository.aspx" target="subfrm" title="知识库">知识库</a></li>
					<li><a href="User.aspx" target="subfrm" title="我的信息">我的信息</a></li>
					<li><a href="Password.aspx" target="subfrm" title="修改密码">修改密码</a></li>
				</ul>
					<div class="menu" style="margin-top:0;">采购下单</div>
				<ul>	
					<li><a href="SellPlanAdd.aspx" target="subfrm" title="新建订单">新建订单</a></li>
					<li><a href="SchSellPlan.aspx" target="subfrm" title="订单列表">订单列表</a></li>
			    </ul>
			        <div class="menu" style="margin-top:0;">租赁/全保业务</div>
			    <ul>
					<li><a href="LeaseAdd.aspx" target="subfrm" title="新建业务">新建业务</a></li>
					<li><a href="SchLease.aspx" target="subfrm" title="业务单列表">业务单列表</a></li>
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
function chkexit(){if(confirm("确定要退出吗？")){$("btnExit").click();}}
</script>
