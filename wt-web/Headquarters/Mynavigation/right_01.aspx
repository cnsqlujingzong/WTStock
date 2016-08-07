<%@ page language="C#"  CodeFile="right_01.aspx.cs"     autoeventwireup="true" inherits="right_01" enableEventValidation="false" %>
<html>
<head runat="server">
    <title></title>
    <link href="css.css" rel="stylesheet" type="text/css" />
</head>
<body onclick="parent.parent.Sethidden1();" style="overflow:hidden;">
    <form id="form1" runat="server" style="height:100%;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="main" runat="server">
        <ContentTemplate>
        <div id="top">
            <div class="left">
            </div>
            <div class="lefts" style="background: url(images/R-top_01.jpg) no-repeat"></div>
            <div class="right">
            </div>
        </div>
        <div id="content" style="overflow:auto;">
            <div id="divc">
            <div class="leftc">
                <div id="div_noice">
                <table border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td height="25" colspan="2">&nbsp;</td>
                    </tr>
                  <tr>
                    <td width="40" align="left" valign="top"><img src="images/XTTX_1.jpg" width="34" height="37" /></td>
                    <td align="left">
		            <ul>
		            <li class="texts">服务单</li>
		            <li class="text">
		              <a href="#d" onclick="parent.parent.SetFrame('bxsh','Services/ServicesNet.aspx', '报修审核');">报修审核<asp:Label ID="lbt1" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#d" onclick="parent.parent.SetFrame('sxqr','Services/ServicesConf.aspx','送修确认');">送修确认</a><asp:Label ID="Label2"  runat="server" Text="(0)" CssClass="red"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#d" onclick="parent.parent.SetFrame('dclgd','Services/ServicesAllot.aspx?iflag=1','服务中心-待处理')">待处理<asp:Label ID="lbt3" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#d" onclick="parent.parent.SetFrame('clzgd','Services/ServicesAllot.aspx?iflag=2','服务中心-处理中')">处理中<asp:Label ID="lbt4" runat="server" Text="(0)" CssClass="red"></asp:Label></a><br />
		              <a href="#d" onclick="parent.parent.SetFrame('sxfh','Services/ServicesSnd.aspx','送修发货');">待送修发货<asp:Label ID="lbt5" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#d" onclick="parent.parent.SetFrame('shjs','Services/ServicesRcv.aspx','收货结算');">待收货结算<asp:Label ID="lbt6" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#d" onclick="parent.parent.SetFrame('wgjs','Services/ServicesBln.aspx','完工结算');">待结算<asp:Label ID="lbt7" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#d" onclick="parent.parent.SetFrame('fwhf','Services/ServicesCall.aspx','服务回访');">待回访<asp:Label ID="lbt8" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#d" onclick="parent.parent.SetFrame('sggb','Services/ServicesOver.aspx','审核关闭');"> 待审核<asp:Label ID="lbt9" runat="server" Text="(0)" CssClass="red"></asp:Label></a>
		              </li>
		            </ul>
		            </td>
                  </tr>
                </table>
                <div style="height:15px; font-size:0px;"></div>
                <table border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="40" align="left" valign="top"><img src="images/XTTX_2.jpg" width="34" height="37" /></td>
                    <td align="left">
		            <ul>
		            <li class="texts">仓库</li>
		            <li class="text">
		              <a href="#gy" onclick="parent.parent.ShowDialog(920,520, 'System/StockH.aspx', '高于库存警戒');">高于库存警戒<asp:Label ID="lbt10" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#dy" onclick="parent.parent.ShowDialog(920,520, 'System/StockB.aspx', '低于库存警戒');">低于库存警戒<asp:Label ID="lbt11" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#jd" onclick="parent.parent.ShowDialog(920,520, 'System/WillExpireGoods.aspx', '将要到期的商品');">将要到期的商品<asp:Label ID="lbt12" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#yd" onclick="parent.parent.ShowDialog(920,520, 'System/ExpireGoods.aspx', '已到期的商品');">已到期的商品<asp:Label ID="lbt13" runat="server" Text="(0)" CssClass="red"></asp:Label></a><br />
		              <a href="#dd" onclick="parent.parent.SetFrame('dbsh','Stock/AllocateAppChk.aspx','调拨审核');">调拨审核<asp:Label ID="lbt14" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#ddd" onclick="parent.parent.SetFrame('dbfh','Stock/AllocateRec.aspx','调拨发货');">调拨发货<asp:Label ID="lbt15" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#dd" onclick="parent.parent.SetFrame('dbqs','Stock/AllocateSigned.aspx','调拨签收');">调拨签收<asp:Label ID="lbt16" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#dd" onclick="parent.parent.SetFrame('bbhsq','Stock/SchAllocate.aspx?iflag=1','被驳回的调拨申请');">被驳回的调拨申请<asp:Label ID="lbt17" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#dd" onclick="parent.parent.SetFrame('qdqjc','Stock/SchLendingReturn.aspx?iflag=1','将到期借出');">将到期借出<asp:Label ID="lbt18" runat="server" Text="(0)" CssClass="red"></asp:Label></a>
		              </li>
		            </ul>
		            </td>
                  </tr>
                </table>
                <div style="height:15px; font-size:0px;"></div>
                <table border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="40" align="left" valign="top"><img src="images/XTTX_5.jpg" width="34" height="37" /></td>
                    <td align="left">
		            <ul>
		            <li class="texts">帐款</li>
		            <li class="text">
		              <a href="#gy" onclick="parent.parent.SetFrame('dqysh','Financial/ArrearageTX.aspx?iflag=1','到期应收款');">到期应收款<asp:Label ID="lbt19" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#dy" onclick="parent.parent.SetFrame('dqyfk','Financial/ArrearageTX.aspx?iflag=2','到期应付款');">到期应付款<asp:Label ID="lbt20" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#jd" onclick="parent.parent.SetFrame('jdqysk','Financial/ArrearageTX.aspx?iflag=3','将要到期的应收款');">将要到期的应收款<asp:Label ID="lbt21" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#yd" onclick="parent.parent.SetFrame('jdqyfk','Financial/ArrearageTX.aspx?iflag=4','将要到期的应付款');">将要到期的应付款<asp:Label ID="lbt22" runat="server" Text="(0)" CssClass="red"></asp:Label></a>
		              </li>
		            </ul>
		            </td>
                  </tr>
                </table>
                <div style="height:15px; font-size:0px;"></div>
                <table border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="40" align="left" valign="top"><img src="images/XTTX_3.jpg" width="34" height="37" /></td>
                    <td align="left">
		            <ul>
		            <li class="texts">个人提醒</li>
		            <li class="text">
		              <a href="#sd" onclick="parent.parent.SetFrame('znxj','Office/MailAdm.aspx','站内信件');">您的收件箱里还有未读信件<asp:Label ID="lbt23" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#d" onclick="parent.parent.SetFrame('wyclfwd','Services/ServicesAllot.aspx?iflag=3','我要处理的服务单');">您要处理的服务单<asp:Label ID="lbt24" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#dds" onclick="parent.parent.SetFrame('nygzdkh','Customer/CustomerTrack.aspx?iFlag=1','我要跟踪的客户');">您要跟踪的客户<asp:Label ID="lbt25" runat="server" Text="(0)" CssClass="red"></asp:Label></a>
		              </li>
		            </ul>
		            </td>
                  </tr>
                </table>
                <div style="height:15px; font-size:0px;"></div>
                <table border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td width="40" align="left" valign="top"><img src="images/XTTX_4.jpg" width="34" height="37" /></td>
                    <td align="left">
		            <ul>
		            <li class="texts">其他</li>
		            <li class="text">
		              <a href="#cb" onclick="parent.parent.ShowDialog(920,520, 'System/DeviceWExpire.aspx', '厂家保修到期机器');">厂家保修到期机器<asp:Label ID="lbt26" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#wb" onclick="parent.parent.ShowDialog(920,520, 'System/DeviceSExpire.aspx?iflag=1', '维修保修到期机器');">维修保修到期机器<asp:Label ID="lbt27" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#jdby" onclick="parent.parent.ShowDialog(920,520, 'System/DeviceSExpire.aspx?iflag=2', '维修保修将到期机器');">维修保修将到期机器<asp:Label ID="lbt28" runat="server" Text="(0)" CssClass="red"></asp:Label></a><br />
		              <a href="#jdby" onclick="parent.parent.SetFrame('jydqdbyjh','Customer/MaintenanceAllot.aspx?iflag=1','将要到期的保养计划');">将要到期的保养计划<asp:Label ID="lbt29" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#cb" onclick="parent.parent.SetFrame('jydqdfwht','Customer/ContractTX.aspx', '将要到期的服务合同');">将要到期的服务合同<asp:Label ID="lbt30" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#wb" onclick="parent.parent.SetFrame('jydqdzlqb','Lease/LeaseTX.aspx?iflag=1','将要到期的租赁/全保');">将要到期的租赁/全保<asp:Label ID="lbt31" runat="server" Text="(0)" CssClass="red"></asp:Label></a><br />
		              <a href="#jdgz" onclick="parent.parent.SetFrame('jydqdhcgz','Customer/ConsumablesTrack.aspx?iflag=1','将要到期的耗材跟踪');">将要到期的耗材跟踪<asp:Label ID="lbt32" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#cq" onclick="parent.parent.ShowDialog(920,520, 'System/ExtendedServices.aspx', '超期单');">超期单<asp:Label ID="lbt33" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#cqd" onclick="parent.parent.ShowDialog(920,520, 'System/Reminder.aspx', '催单');">催单<asp:Label ID="lbt41" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;
		              <a href="#ysr" onclick="parent.parent.ShowDialog(920,520, 'System/StaffBirthDay.aspx', '今日员工生日');">今日员工生日<asp:Label ID="lbt34" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#ksr" onclick="parent.parent.ShowDialog(920,520, 'System/CusBirthDay.aspx', '今日客户生日');">今日客户生日<asp:Label ID="lbt35" runat="server" Text="(0)" CssClass="red"></asp:Label></a>
		              </li>
		            </ul>
		            </td>
                  </tr>
                </table>
                </div>
            </div>
                <div  class="leftc" style="width:200px;left:750px;">
                    <h4>本月积分：<span><asp:Label ID="lb_in_mon" runat="server" Text=""></asp:Label></span></h4>
                     <h4>本周积分：<span><asp:Label ID="lb_in_week" runat="server" Text=""></asp:Label></span></h4>
                     <h4>周排名：<span><asp:Label ID="lb_o_mon" runat="server" Text=""></asp:Label></span></h4>
                    <h4>月排名：<span><asp:Label ID="lb_o_week" runat="server" Text=""></asp:Label></span></h4>
                </div>
            <asp:Button ID="btnRefresh" runat="server" Text="刷新" OnClick="btnRefresh_Click" style="display:none;" />
            <div class="rightc" id="nav_right">
                 <ul>
                    <li class="li_div"><a href="http://www.differsoft.com/production/files/Prodoc/WTnet_IT_Help_DOC.doc" target="_blank">帮助文档下载</a></li>
                    <li class="li_div"><a href="http://www.differsoft.com/Tools/WT(IT)Print.rar" target="_blank">打印插件下载</a></li>
                </ul>
                <%=Str_Content %>
            </div>
        </div>
    </div>
    <div id="winpop">
    <div class="title"><span class="stitle">系统提醒</span><span class="close" onclick="tips_pop()"><img alt="关闭" src="../../Public/Images/close.gif" style="cursor: default;" title="关闭" /></span></div>
        <div class="con">
            <ul>
            <li><a href="#dd" onclick="parent.parent.SetFrame('wyclfwd','Services/ServicesAllot.aspx?iflag=3','服务中心-要处理的服务单');">您要处理的服务单<asp:Label ID="lbt36" runat="server" Text="(0)" CssClass="red"></asp:Label></a></li>
            <li><a href="#dd" onclick="parent.parent.SetFrame('jydqdbyjh','Customer/MaintenanceAllot.aspx?iflag=1','将要到期的保养计划');">将要到期的保养计划<asp:Label ID="lbt37" runat="server" Text="(0)" CssClass="red"></asp:Label></a></li>
            <li><a href="#dd" onclick="parent.parent.SetFrame('jtyzcgzdkh','Customer/CustomerTrack.aspx?iFlag=2','今天要再次跟踪的客户');">今天要再次跟踪的客户<asp:Label ID="lbt38" runat="server" Text="(0)" CssClass="red"></asp:Label></a></li>
            <li><a href="#dd" onclick="parent.parent.SetFrame('jydqjsdzlqb','Lease/MeterReading.aspx?iFlag=2','将到期结算的租赁/全保');">将要到期结算的租赁/全保<asp:Label ID="lbt40" runat="server" Text="(0)" CssClass="red"></asp:Label></a></li>
            <li><a href="#cqd" onclick="parent.parent.ShowDialog(920,520, 'System/ExtendedServices.aspx', '超期单');">超期单<asp:Label ID="lbt39" runat="server" Text="(0)" CssClass="red"></asp:Label></a></li>
            </ul>
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">

    function tips_pop() {
        var MsgPop = document.getElementById("winpop");
        var popH = parseInt(MsgPop.style.height);//将对象的高度转化为数字
        if (popH == 0) {
            MsgPop.style.display = "block";//显示隐藏的窗口
            show = setInterval("changeH('up')", 2);
        }
        else {
            hide = setInterval("changeH('down')", 2);
        }
    }

    function changeH(str) {
        var MsgPop = document.getElementById("winpop");
        var popH = parseInt(MsgPop.style.height);
        if (str == "up") {
            if (popH <= 180) {
                MsgPop.style.height = (popH + 4).toString() + "px";
            }
            else {
                clearInterval(show);
            }
        }
        if (str == "down") {
            if (popH >= 4) {
                MsgPop.style.height = (popH - 4).toString() + "px";
            }
            else {
                clearInterval(hide);
                MsgPop.style.display = "none";  //隐藏DIV
            }
        }
    }

    function RefreshData() {
        document.getElementById("btnRefresh").click();
    }
    window.onload = function () {
        document.getElementById('winpop').style.height = '0px';
        tips_pop();
    }
    var ph = document.body.clientHeight;
    if (ph < 450)
        document.getElementById("divc").style.height = 450 + "px";
    else
        document.getElementById("divc").style.height = (ph - 30) + "px";
    document.getElementById("content").style.height = (ph - 30) + "px";
    var pw = document.body.clientWidth;
    if (pw < 900)
        document.getElementById("divc").style.width = 900 + "px";
    else
        document.getElementById("divc").style.width = pw + "px";
    document.getElementById("content").style.width = pw + "px";
</script>