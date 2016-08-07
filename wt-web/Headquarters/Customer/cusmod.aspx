<%@ page language="C#"  CodeFile="cusmod.aspx.cs"     autoeventwireup="true" inherits="CusMod" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
    <style type="text/css">
        .auto-style1 {
            height: 28px;
        }
        #tab5 td {
        padding:5px;
        }
    </style>
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
                <td class="blue">客户名称：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin" Width="220"></asp:TextBox></td>
                <td class="blue">客户编号：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbCusNO" runat="server" CssClass="pin" Enabled="false"></asp:TextBox></td>
                <td class="sysred" style="padding-left:5px;">
                    <asp:CheckBox ID="cbsys" runat="server" Text="系统默认" Checked="true" onclick="ChkSysNO();" /></td>
            </tr>
         </table>
        <div class="divh"></div>
        <div id="mytabs">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">基本信息</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">联系人组</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">自定义</span>
            <span id="tabs_r3"></span>
            <span id="tabs_l4"></span>
            <span id="tabs4" onclick="ChkTab('4');" >组织架构</span>
            <span id="tabs_r4"></span>
            <span id="tabs_l5"></span>
            <span id="tabs5" onclick="ChkTab('5');" >结算方式</span>
            <span id="tabs_r5"></span>
        </div>
            <div id="info1" style="padding:3px 0px 0px 3px; overflow:hidden;">
        <div id="divinfo1" class="divinfo" style="height:305px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                       <td>客户类别：</td>
                        <td style="padding-left:0px;">
                            <div class="isinDiv">
                            <input type="text" id="tbCusClass" runat="server" class="pin pinin" readonly="readonly" />
                                <select id="slCusClass" runat="server" onchange="getclassvalue('tbCusClass',this.options[this.selectedIndex].text);" class="pininsl">
                                </select>
                            </div>
                         </td>
                         <td align="right">客户状态：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="pindl">
                            </asp:DropDownList>
                        </td>
                        <td>介绍人：<asp:TextBox ID="txtjieshao" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">联系人：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right">联系电话：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td align="right">手机号码：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbTel2" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right">传真：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbFax" runat="server" CssClass="pin"></asp:TextBox></td>
                          <td></td>
                    </tr>
                    <tr>
                        <td align="right">邮编：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbZip" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right">Email：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbEmail" runat="server" CssClass="pin"></asp:TextBox>
                        </td>
                          <td></td>
                    </tr>
                    <tr>
                        <td align="right">QQ/MSN：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbQQ" runat="server" CssClass="pin"></asp:TextBox>
                        </td>
                        <td align="right">客户来源：</td>
                        <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlFrom" runat="server" CssClass="pindl" onchange="NewFrom();">
                            </asp:DropDownList></td>
                          <td></td>
                    </tr>
                    <tr>
                        <td align="right">客户区域：</td>
                        <td style="padding-left:0px;">
                        <div class="isinDiv">
                        <asp:TextBox ID="tbArea" runat="server" CssClass="pin pinin"></asp:TextBox>
                        <asp:DropDownList ID="ddlArea" runat="server" CssClass="pininsl" onchange="document.getElementById('tbArea').value=this.options[this.selectedIndex].text;NewArea('1');">
                        </asp:DropDownList>
                        </div>
                        </td>
                        <td align="right">地图坐标：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbCoordinates" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td style="padding:0px;"><input id="btnSlt" type="button" value="" onclick="SltCoor();" class="bview"/></td>
                          <td></td>
                    </tr>
                    <tr>
                        <td align="right">业务员：</td>
                        <td style="padding-left:0px;"><asp:DropDownList ID="ddlSeller" runat="server" CssClass="pindl">
                            </asp:DropDownList>
                        </td>
                        <td align="right">会员级别：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlMember" runat="server" CssClass="pindl">
                            </asp:DropDownList>
                        </td>
                          <td></td>
                    </tr>
                    <tr>
                        <td align="right">帐户：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbAccount" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right">关联网点：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl">
                            </asp:DropDownList>
                        </td>
                          <td></td>
                    </tr>
                    <tr>
                        <td>归属网点：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlDeptID" runat="server" CssClass="pindl">
                            </asp:DropDownList>
                        </td>
                        <td colspan="2"><font size ="8" color="red" >(*客户登记网点)</font></td>
                        
                        <td>
                            信誉额度：<asp:TextBox ID="tb_xyed" runat="server" Width="70px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">地址：</td>
                        <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
                        <td style="padding-left:15px;">
                            <asp:CheckBox ID="cbCall" runat="server" /> 回访
                             <asp:CheckBox ID="cbTrack" runat="server" /> 跟踪
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
                        <td style="padding-left:15px;">
                             <asp:CheckBox ID="cbStop" runat="server" /> <span class="sysred">停用</span>
                             <asp:CheckBox ID="cbUpdate" runat="server" />统一信息
                             <asp:HiddenField ID="hfTemp" runat="server" />
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
                            <asp:BoundField HeaderText="姓名" DataField="姓名" />
                            <asp:BoundField HeaderText="部门" DataField="部门" />
                            <asp:BoundField HeaderText="性别" DataField="性别" />
                            <asp:BoundField HeaderText="职位" DataField="职位" />
                            <asp:BoundField HeaderText="办公电话" DataField="办公电话" />
                            <asp:BoundField HeaderText="宅电" DataField="宅电" />
                            <asp:BoundField HeaderText="移动电话" DataField="移动电话" />
                              <asp:BoundField HeaderText="个人手机" DataField="个人手机" />
                              <asp:BoundField HeaderText="第二手机" DataField="第二手机" />
                               <asp:BoundField HeaderText="QQ" DataField="QQ" />
                              <asp:BoundField HeaderText="微信" DataField="微信" />
                            <asp:BoundField HeaderText="传真" DataField="传真" />
                            <asp:BoundField HeaderText="Email" DataField="Email" />
                            <asp:BoundField HeaderText="生日" DataField="生日" DataFormatString="{0:yyyy-MM-dd}"/>
                            <asp:BoundField HeaderText="地址" DataField="地址" />
                            <asp:BoundField HeaderText="个人地址" DataField="个人地址" />
                            <asp:BoundField HeaderText="备注" DataField="备注" />
                        </Columns>
                    </asp:GridView>
                    <asp:HiddenField ID="hfdellist1" runat="server" />
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
                    <input id="btnNewLinkMan" type="button" value="新建" class="bt1" onclick="parent.ShowDialog<%=Str_D %>(460, 350, 'Customer/CusLinkManAdd.aspx?f=<%=Str_F %>&cid=<%=Cid %>', '新建联系人');"/>
                    <input id="btnEditLinkMan" type="button" value="修改" class="bt1" onclick="ModLinkMan(460, 350,'Customer/CusLinkManMod.aspx','修改联系人');"/>
                    <asp:Button ID="btnDelLink" runat="server" Text="删除" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnDelLink_Click" />
                    </td>
                    </tr>
              </table>
              </div>
            </div>
            <div id="info3" style="padding:3px 0px 0px 3px; overflow:hidden;">
            <div id="div2" class="divinfo" style="height:282px;">
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td align="right" class="auto-style1"><asp:Label ID="lbuserdef1" runat="server" Text="客户自定义1"></asp:Label>：</td>
                        <td style="padding-left:0px;" class="auto-style1"><asp:TextBox ID="tbuserdef1" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right"><asp:Label ID="lbuserdef2" runat="server" Text="客户自定义2"></asp:Label>：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef2" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right"><asp:Label ID="lbuserdef3" runat="server" Text="客户自定义3"></asp:Label>：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef3" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right"><asp:Label ID="lbuserdef4" runat="server" Text="客户自定义4"></asp:Label>：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef4" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right"><asp:Label ID="lbuserdef5" runat="server" Text="客户自定义5"></asp:Label>：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef5" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right"><asp:Label ID="lbuserdef6" runat="server" Text="客户自定义6"></asp:Label>：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef6" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
            </div>
               <div id="info4" >
                   <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                       <ContentTemplate>                    
                    <div style="height:330px;">
                        <div style="float:left;min-width:200px">
                              <span style="font-size:16px;font-weight:600">组织结构</span>
                            <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" ShowLines="True">
                                <SelectedNodeStyle BackColor="Blue" ForeColor="White" />
                              </asp:TreeView>
                        </div>
                        <div style="float:left;padding-left:20px;">
                            <span style="font-size:16px;font-weight:600">添加职务</span>
                               <p>所属上级：<asp:Label ID="lb_parentNode" runat="server" Text="">                                
                               </asp:Label><asp:Button ID="btnDelNode" runat="server" OnClientClick="javascript:return confirm('确认要删除？')" Text="删除节点" OnClick="btnDelNode_Click" /></p>

                                 <p>职务：<asp:TextBox ID="tb_zhiwu" runat="server"></asp:TextBox></p>
                                 <p>姓名：<asp:TextBox ID="tb_renming" runat="server"></asp:TextBox></p>
                            <p>
                                <asp:Button ID="btnAddNode" runat="server" Text="添加职务" OnClick="btnAddNode_Click" /></p>
                            <span style="font-size:16px;font-weight:600">修改职务</span>
                             <p>职务：<asp:TextBox ID="tb_ezhiwu" runat="server"></asp:TextBox></p>
                                 <p>姓名：<asp:TextBox ID="tb_erenming" runat="server"></asp:TextBox></p>
                            <p><asp:Button ID="btnEditNode" runat="server" Text="修改职务" OnClick="btnEditNode_Click" /></p>
                        </div>
                        <div style="clear:both"></div>
                    </div>
                     </ContentTemplate>
                       <Triggers>
                           <asp:AsyncPostBackTrigger ControlID="btnAddNode" EventName="Click" />
                               <asp:AsyncPostBackTrigger ControlID="btnDelNode" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="btnEditNode" EventName="Click" />
<%--                           <asp:AsyncPostBackTrigger ControlID="TreeView1" EventName="SelectedNodeChanged" />--%>
                       </Triggers>
                   </asp:UpdatePanel>

                  </div>
             <div id="info5">
               <div>
                   <table cellpadding="0" cellspacing="0" border="1" id="tab5">
                       <tr>
                           <td>客户的情况说明</td>
                           <td>
                               <asp:TextBox ID="tb_cus_info" runat="server" Width="250"></asp:TextBox></td>
                   
                       </tr>
                             <tr>
                           <td>客户主要结算方式</td>
                           <td>
                               <asp:TextBox ID="tb_cus_paytype" runat="server" Width="250"></asp:TextBox></td>
                      
                       </tr>
                             <tr>
                           <td>结算周期</td>
                           <td>
                               <asp:TextBox ID="tb_cus_date" runat="server" Width="250"></asp:TextBox></td>
                       
                       </tr>
                             <tr>
                           <td>验收方式</td>
                           <td>
                               <asp:TextBox ID="tb_cus_ver" runat="server" Width="250"></asp:TextBox></td>
                     
                       </tr>
                       <tr>
                           <td>是否贴息</td>
                           <td>
                               <asp:TextBox ID="tb_cus_tiexi" runat="server" Width="250"></asp:TextBox></td>
                      
                       </tr>
                       <tr>
                           <td>发票先开还是后开</td>
                           <td>
                               <asp:TextBox ID="tb_cus_piao" runat="server" Width="250"></asp:TextBox></td>
                     
                       </tr>
                       <tr>
                           <td>人员变动是否频繁</td>
                           <td>
                               <asp:TextBox ID="tb_cus_ren" runat="server" Width="250"></asp:TextBox></td>
                      
                       </tr>
                   </table>
               </div>
                  </div>
<%--            <div id="info4" style="padding:3px 0px 0px 3px; overflow:hidden;"><h3>组织架构</h3></div>
            <div id="info5" style="padding:3px 0px 0px 3px; overflow:hidden;"><h3>结算方式</h3></div>--%>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="padding-left:5px;color:#0000ff">
                     <asp:HiddenField ID="hfArea" runat="server" />
                     <asp:HiddenField ID="hfCusFrom" runat="server" />
                   <span style="display:none;">
                        <asp:Button ID="btnRef" runat="server" Text="Ref" OnClick="btnRef_Click" />
                        <asp:Button ID="btnRefFrom" runat="server" Text="RefFrom" OnClick="btnRefFrom_Click" />
                   </span>
                </td>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
                    <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog<%=Str_F %>();"/>
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
var tabnum=6;
var isfocus=1;
var processtip=1;
function ChkID(id)
{
    ClrID(id);
    $("btnShowLinkMan").click();
}

function ChkAdd()
{
    if(isNull($("tbName").value))
    {
        window.alert("操作失败！客户名称不能为空");
        $("tbName").focus();
        return false
    }
    if(!$("cbsys").checked)
    {
        if(isNull($("tbCusNO").value))
        {
            window.alert("操作失败！客户编号不能为空");
            $("tbCusNO").focus();
            return false
        }
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

//-----------其他信息----------------//
//修改
function ModLinkMan(w,h,url,title)
{
    if(ChkSlt()!=false)
    {
        var str=document.getElementById("hfLinkMan").value;
        parent.ShowDialog<%=Str_D %>(w,h,url+"?str="+escape(str)+"&f=<%=Str_F %>&cid=<%=Cid %>",title);
    }
}
function SltCoor()
{
    var str=$("tbArea").value;
    parent.ShowDialog<%=Str_D %>(800,520,"../Headquarters/Customer/SltCoor.aspx"+"?str="+escape(str)+"&f=<%=Str_F %>",'选择坐标');
}
//--------End----------------//
</script>
