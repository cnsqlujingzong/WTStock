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
		            <li class="texts">����</li>
		            <li class="text">
		              <a href="#d" onclick="parent.parent.SetFrame('bxsh','Services/ServicesNet.aspx', '�������');">�������<asp:Label ID="lbt1" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#d" onclick="parent.parent.SetFrame('sxqr','Services/ServicesConf.aspx','����ȷ��');">����ȷ��</a><asp:Label ID="Label2"  runat="server" Text="(0)" CssClass="red"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#d" onclick="parent.parent.SetFrame('dclgd','Services/ServicesAllot.aspx?iflag=1','��������-������')">������<asp:Label ID="lbt3" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#d" onclick="parent.parent.SetFrame('clzgd','Services/ServicesAllot.aspx?iflag=2','��������-������')">������<asp:Label ID="lbt4" runat="server" Text="(0)" CssClass="red"></asp:Label></a><br />
		              <a href="#d" onclick="parent.parent.SetFrame('sxfh','Services/ServicesSnd.aspx','���޷���');">�����޷���<asp:Label ID="lbt5" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#d" onclick="parent.parent.SetFrame('shjs','Services/ServicesRcv.aspx','�ջ�����');">���ջ�����<asp:Label ID="lbt6" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#d" onclick="parent.parent.SetFrame('wgjs','Services/ServicesBln.aspx','�깤����');">������<asp:Label ID="lbt7" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#d" onclick="parent.parent.SetFrame('fwhf','Services/ServicesCall.aspx','����ط�');">���ط�<asp:Label ID="lbt8" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#d" onclick="parent.parent.SetFrame('sggb','Services/ServicesOver.aspx','��˹ر�');"> �����<asp:Label ID="lbt9" runat="server" Text="(0)" CssClass="red"></asp:Label></a>
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
		            <li class="texts">�ֿ�</li>
		            <li class="text">
		              <a href="#gy" onclick="parent.parent.ShowDialog(920,520, 'System/StockH.aspx', '���ڿ�澯��');">���ڿ�澯��<asp:Label ID="lbt10" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#dy" onclick="parent.parent.ShowDialog(920,520, 'System/StockB.aspx', '���ڿ�澯��');">���ڿ�澯��<asp:Label ID="lbt11" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#jd" onclick="parent.parent.ShowDialog(920,520, 'System/WillExpireGoods.aspx', '��Ҫ���ڵ���Ʒ');">��Ҫ���ڵ���Ʒ<asp:Label ID="lbt12" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#yd" onclick="parent.parent.ShowDialog(920,520, 'System/ExpireGoods.aspx', '�ѵ��ڵ���Ʒ');">�ѵ��ڵ���Ʒ<asp:Label ID="lbt13" runat="server" Text="(0)" CssClass="red"></asp:Label></a><br />
		              <a href="#dd" onclick="parent.parent.SetFrame('dbsh','Stock/AllocateAppChk.aspx','�������');">�������<asp:Label ID="lbt14" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#ddd" onclick="parent.parent.SetFrame('dbfh','Stock/AllocateRec.aspx','��������');">��������<asp:Label ID="lbt15" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#dd" onclick="parent.parent.SetFrame('dbqs','Stock/AllocateSigned.aspx','����ǩ��');">����ǩ��<asp:Label ID="lbt16" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#dd" onclick="parent.parent.SetFrame('bbhsq','Stock/SchAllocate.aspx?iflag=1','�����صĵ�������');">�����صĵ�������<asp:Label ID="lbt17" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#dd" onclick="parent.parent.SetFrame('qdqjc','Stock/SchLendingReturn.aspx?iflag=1','�����ڽ��');">�����ڽ��<asp:Label ID="lbt18" runat="server" Text="(0)" CssClass="red"></asp:Label></a>
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
		            <li class="texts">�ʿ�</li>
		            <li class="text">
		              <a href="#gy" onclick="parent.parent.SetFrame('dqysh','Financial/ArrearageTX.aspx?iflag=1','����Ӧ�տ�');">����Ӧ�տ�<asp:Label ID="lbt19" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#dy" onclick="parent.parent.SetFrame('dqyfk','Financial/ArrearageTX.aspx?iflag=2','����Ӧ����');">����Ӧ����<asp:Label ID="lbt20" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#jd" onclick="parent.parent.SetFrame('jdqysk','Financial/ArrearageTX.aspx?iflag=3','��Ҫ���ڵ�Ӧ�տ�');">��Ҫ���ڵ�Ӧ�տ�<asp:Label ID="lbt21" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#yd" onclick="parent.parent.SetFrame('jdqyfk','Financial/ArrearageTX.aspx?iflag=4','��Ҫ���ڵ�Ӧ����');">��Ҫ���ڵ�Ӧ����<asp:Label ID="lbt22" runat="server" Text="(0)" CssClass="red"></asp:Label></a>
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
		            <li class="texts">��������</li>
		            <li class="text">
		              <a href="#sd" onclick="parent.parent.SetFrame('znxj','Office/MailAdm.aspx','վ���ż�');">�����ռ����ﻹ��δ���ż�<asp:Label ID="lbt23" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#d" onclick="parent.parent.SetFrame('wyclfwd','Services/ServicesAllot.aspx?iflag=3','��Ҫ����ķ���');">��Ҫ����ķ���<asp:Label ID="lbt24" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#dds" onclick="parent.parent.SetFrame('nygzdkh','Customer/CustomerTrack.aspx?iFlag=1','��Ҫ���ٵĿͻ�');">��Ҫ���ٵĿͻ�<asp:Label ID="lbt25" runat="server" Text="(0)" CssClass="red"></asp:Label></a>
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
		            <li class="texts">����</li>
		            <li class="text">
		              <a href="#cb" onclick="parent.parent.ShowDialog(920,520, 'System/DeviceWExpire.aspx', '���ұ��޵��ڻ���');">���ұ��޵��ڻ���<asp:Label ID="lbt26" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#wb" onclick="parent.parent.ShowDialog(920,520, 'System/DeviceSExpire.aspx?iflag=1', 'ά�ޱ��޵��ڻ���');">ά�ޱ��޵��ڻ���<asp:Label ID="lbt27" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#jdby" onclick="parent.parent.ShowDialog(920,520, 'System/DeviceSExpire.aspx?iflag=2', 'ά�ޱ��޽����ڻ���');">ά�ޱ��޽����ڻ���<asp:Label ID="lbt28" runat="server" Text="(0)" CssClass="red"></asp:Label></a><br />
		              <a href="#jdby" onclick="parent.parent.SetFrame('jydqdbyjh','Customer/MaintenanceAllot.aspx?iflag=1','��Ҫ���ڵı����ƻ�');">��Ҫ���ڵı����ƻ�<asp:Label ID="lbt29" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#cb" onclick="parent.parent.SetFrame('jydqdfwht','Customer/ContractTX.aspx', '��Ҫ���ڵķ����ͬ');">��Ҫ���ڵķ����ͬ<asp:Label ID="lbt30" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#wb" onclick="parent.parent.SetFrame('jydqdzlqb','Lease/LeaseTX.aspx?iflag=1','��Ҫ���ڵ�����/ȫ��');">��Ҫ���ڵ�����/ȫ��<asp:Label ID="lbt31" runat="server" Text="(0)" CssClass="red"></asp:Label></a><br />
		              <a href="#jdgz" onclick="parent.parent.SetFrame('jydqdhcgz','Customer/ConsumablesTrack.aspx?iflag=1','��Ҫ���ڵĺĲĸ���');">��Ҫ���ڵĺĲĸ���<asp:Label ID="lbt32" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#cq" onclick="parent.parent.ShowDialog(920,520, 'System/ExtendedServices.aspx', '���ڵ�');">���ڵ�<asp:Label ID="lbt33" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#cqd" onclick="parent.parent.ShowDialog(920,520, 'System/Reminder.aspx', '�ߵ�');">�ߵ�<asp:Label ID="lbt41" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;
		              <a href="#ysr" onclick="parent.parent.ShowDialog(920,520, 'System/StaffBirthDay.aspx', '����Ա������');">����Ա������<asp:Label ID="lbt34" runat="server" Text="(0)" CssClass="red"></asp:Label></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		              <a href="#ksr" onclick="parent.parent.ShowDialog(920,520, 'System/CusBirthDay.aspx', '���տͻ�����');">���տͻ�����<asp:Label ID="lbt35" runat="server" Text="(0)" CssClass="red"></asp:Label></a>
		              </li>
		            </ul>
		            </td>
                  </tr>
                </table>
                </div>
            </div>
                <div  class="leftc" style="width:200px;left:750px;">
                    <h4>���»��֣�<span><asp:Label ID="lb_in_mon" runat="server" Text=""></asp:Label></span></h4>
                     <h4>���ܻ��֣�<span><asp:Label ID="lb_in_week" runat="server" Text=""></asp:Label></span></h4>
                     <h4>��������<span><asp:Label ID="lb_o_mon" runat="server" Text=""></asp:Label></span></h4>
                    <h4>��������<span><asp:Label ID="lb_o_week" runat="server" Text=""></asp:Label></span></h4>
                </div>
            <asp:Button ID="btnRefresh" runat="server" Text="ˢ��" OnClick="btnRefresh_Click" style="display:none;" />
            <div class="rightc" id="nav_right">
                 <ul>
                    <li class="li_div"><a href="http://www.differsoft.com/production/files/Prodoc/WTnet_IT_Help_DOC.doc" target="_blank">�����ĵ�����</a></li>
                    <li class="li_div"><a href="http://www.differsoft.com/Tools/WT(IT)Print.rar" target="_blank">��ӡ�������</a></li>
                </ul>
                <%=Str_Content %>
            </div>
        </div>
    </div>
    <div id="winpop">
    <div class="title"><span class="stitle">ϵͳ����</span><span class="close" onclick="tips_pop()"><img alt="�ر�" src="../../Public/Images/close.gif" style="cursor: default;" title="�ر�" /></span></div>
        <div class="con">
            <ul>
            <li><a href="#dd" onclick="parent.parent.SetFrame('wyclfwd','Services/ServicesAllot.aspx?iflag=3','��������-Ҫ����ķ���');">��Ҫ����ķ���<asp:Label ID="lbt36" runat="server" Text="(0)" CssClass="red"></asp:Label></a></li>
            <li><a href="#dd" onclick="parent.parent.SetFrame('jydqdbyjh','Customer/MaintenanceAllot.aspx?iflag=1','��Ҫ���ڵı����ƻ�');">��Ҫ���ڵı����ƻ�<asp:Label ID="lbt37" runat="server" Text="(0)" CssClass="red"></asp:Label></a></li>
            <li><a href="#dd" onclick="parent.parent.SetFrame('jtyzcgzdkh','Customer/CustomerTrack.aspx?iFlag=2','����Ҫ�ٴθ��ٵĿͻ�');">����Ҫ�ٴθ��ٵĿͻ�<asp:Label ID="lbt38" runat="server" Text="(0)" CssClass="red"></asp:Label></a></li>
            <li><a href="#dd" onclick="parent.parent.SetFrame('jydqjsdzlqb','Lease/MeterReading.aspx?iFlag=2','�����ڽ��������/ȫ��');">��Ҫ���ڽ��������/ȫ��<asp:Label ID="lbt40" runat="server" Text="(0)" CssClass="red"></asp:Label></a></li>
            <li><a href="#cqd" onclick="parent.parent.ShowDialog(920,520, 'System/ExtendedServices.aspx', '���ڵ�');">���ڵ�<asp:Label ID="lbt39" runat="server" Text="(0)" CssClass="red"></asp:Label></a></li>
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
        var popH = parseInt(MsgPop.style.height);//������ĸ߶�ת��Ϊ����
        if (popH == 0) {
            MsgPop.style.display = "block";//��ʾ���صĴ���
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
                MsgPop.style.display = "none";  //����DIV
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