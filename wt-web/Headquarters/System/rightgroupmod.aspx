<%@ page language="C#"  CodeFile="rightgroupmod.aspx.cs"     autoeventwireup="true" inherits="Headquarters_System_RightGroupMod" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sa22" style="width:786px;">
    <div class="fdiv">
    <div class="sdiv">
         <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
                <td><img src="../../Public/Images/dmemp.gif" alt="pic" /></td>
                <td style="padding-left:5px;">
                    权限组名：
                </td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin" Width="200"></asp:TextBox></td>
                <td style="padding-left:5px;">
                    <span class="si2" >(默认没有任何权限，您可以根据权限组名勾选相应的权限)</span>
                </td>
            </tr>
        </table>
    </div>
    </div>
    <div class="divh"></div>
    <div id="mytabs">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">仓库管理</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">采购/销售</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">服务管理</span>
            <span id="tabs_r3"></span>
            <span id="tabs_l4"></span>
            <span id="tabs4" onclick="ChkTab('4');">租赁/全保</span>
            <span id="tabs_r4"></span>
            <span id="tabs_l5"></span>
            <span id="tabs5" onclick="ChkTab('5');">客户关系</span>
            <span id="tabs_r5"></span>
            <span id="tabs_l6"></span>
            <span id="tabs6" onclick="ChkTab('6');">帐款管理</span>
            <span id="tabs_r6"></span>
            <span id="tabs_l7"></span>
            <span id="tabs7" onclick="ChkTab('7');">收发管理</span>
            <span id="tabs_r7"></span>
            <span id="tabs_l8"></span>
            <span id="tabs8" onclick="ChkTab('8');">办公OA</span>
            <span id="tabs_r8"></span>
            <span id="tabs_l9"></span>
            <span id="tabs9" onclick="ChkTab('9');">期初录入</span>
            <span id="tabs_r9"></span>
            <span id="tabs_l10"></span>
            <span id="tabs10" onclick="ChkTab('10');">统计分析</span>
            <span id="tabs_r10"></span>
            <span id="tabs_l11"></span>
            <span id="tabs11" onclick="ChkTab('11');">基础数据</span>
            <span id="tabs_r11"></span>
     </div>
    <div id="info1" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="div1" class="divinfo" style="height:406px;">
        <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="ck_r1" runat="server" /> 编辑产品分类</td>
                <td><asp:CheckBox ID="ck_r2" runat="server" onclick="Chkpar(this,'ck_r3','ck_r4');" /> 浏览产品</td>
                <td><asp:CheckBox ID="ck_r3" runat="server" onclick="Chkson(this,'ck_r2');" /> 添加产品</td>
                <td><asp:CheckBox ID="ck_r4" runat="server" onclick="Chkson(this,'ck_r2');"/> 编辑产品</td>
                <td><asp:CheckBox ID="ck_r83" runat="server" onclick="Chkson(this,'ck_r2');"/> 导出产品</td>
                <td><asp:CheckBox ID="ck_r5" runat="server" /> 浏览当前库存</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="ck_r6" runat="server" /> 浏览废品库存</td>
             <td><asp:CheckBox ID="ck_r69" runat="server" /> 浏览分仓库存</td>
                <td><asp:CheckBox ID="ck_r7" runat="server" onclick="Chkpar(this,'ck_r8','ck_r9');"/> 浏览序列号</td>
                <td><asp:CheckBox ID="ck_r8" runat="server" onclick="Chkson(this,'ck_r7');"/> 序列号入库</td>
                <td><asp:CheckBox ID="ck_r9" runat="server" onclick="Chkson(this,'ck_r7');"/> 序列号出库</td>
                <td><asp:CheckBox ID="ck_r10" runat="server" onclick="Chkson(this,'ck_r7');"/> 打印序列号</td>

                
            </tr>  
            <tr>
                <td><asp:CheckBox ID="ck_r11" runat="server" /> 其他入库</td>
                            <td><asp:CheckBox ID="ck_r12" runat="server" onclick="Chkpar(this,'ck_r15','ck_r16');"/> 浏览入库单</td>
                <td><asp:CheckBox ID="ck_r13" runat="server" onclick="Chkson(this,'ck_r12');"/> 审核入库单</td>
                <td><asp:CheckBox ID="ck_r14" runat="server" onclick="Chkson(this,'ck_r12');"/> 反审核入库单</td>
                <td><asp:CheckBox ID="ck_r15" runat="server" onclick="Chkson(this,'ck_r12');"/> 编辑入库单</td>
                <td><asp:CheckBox ID="ck_r16" runat="server" onclick="Chkson(this,'ck_r12');"/> 删除入库单</td>

                
            </tr>
            <tr>
                <td><asp:CheckBox ID="ck_r17" runat="server" onclick="Chkson(this,'ck_r12');"/> 导出入库单</td>
                            <td><asp:CheckBox ID="ck_r18" runat="server" onclick="Chkson(this,'ck_r12');"/> 打印入库单</td>
                <td><asp:CheckBox ID="ck_r19" runat="server" /> 其他出库</td>
                <td><asp:CheckBox ID="ck_r20" runat="server" onclick="Chkpar(this,'ck_r23','ck_r24');"/> 浏览出库单</td>
                <td><asp:CheckBox ID="ck_r21" runat="server" onclick="Chkson(this,'ck_r20');"/> 审核出库单</td>
                <td><asp:CheckBox ID="ck_r22" runat="server" onclick="Chkson(this,'ck_r20');"/> 反审核出库单</td>

                
            </tr>
            <tr>
                <td><asp:CheckBox ID="ck_r23" runat="server" onclick="Chkson(this,'ck_r20');"/> 编辑出库单</td>
                <td><asp:CheckBox ID="ck_r24" runat="server" onclick="Chkson(this,'ck_r20');"/> 删除出库单</td>
                <td><asp:CheckBox ID="ck_r25" runat="server" onclick="Chkson(this,'ck_r20');"/> 导出出库单</td>
                <td><asp:CheckBox ID="ck_r26" runat="server" onclick="Chkson(this,'ck_r20');"/> 打印出库单</td>
                <td><asp:CheckBox ID="ck_r27" runat="server" /> 领退开单</td>
                <td><asp:CheckBox ID="ck_r28" runat="server" onclick="Chkpar(this,'ck_r31','ck_r32');"/> 浏览领退单</td>

                
            </tr>
            <tr>
                <td><asp:CheckBox ID="ck_r29" runat="server" onclick="Chkson(this,'ck_r28');" /> 审核领退单</td>
                <td><asp:CheckBox ID="ck_r30" runat="server" onclick="Chkson(this,'ck_r28');" /> 反审核领退单</td>
                <td><asp:CheckBox ID="ck_r31" runat="server" onclick="Chkson(this,'ck_r28');" /> 编辑领退单</td>
                <td><asp:CheckBox ID="ck_r32" runat="server" onclick="Chkson(this,'ck_r28');" /> 删除领退单</td>
                <td><asp:CheckBox ID="ck_r33" runat="server" onclick="Chkson(this,'ck_r28');" /> 导出领退单</td>
                <td><asp:CheckBox ID="ck_r34" runat="server" onclick="Chkson(this,'ck_r28');" /> 打印领退单</td>

                
            </tr>
            <tr>
                <td><asp:CheckBox ID="ck_r35" runat="server" /> 调拨申请</td>
                <td><asp:CheckBox ID="ck_r36" runat="server" onclick="Chkpar(this,'ck_r37','ck_r43');"/> 浏览调拨单</td>
                <td><asp:CheckBox ID="ck_r37" runat="server" onclick="Chkson(this,'ck_r36');"/> 编辑调拨单</td>
                <td><asp:CheckBox ID="ck_r38" runat="server" /> 审核调拨单</td>
                <td><asp:CheckBox ID="ck_r39" runat="server" /> 驳回调拨单</td>
                <td><asp:CheckBox ID="ck_r40" runat="server" /> 调拨发货</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="ck_r41" runat="server" /> 调拨签收</td>
                <td><asp:CheckBox ID="ck_r42" runat="server" onclick="Chkson(this,'ck_r36');"/> 删除调拨单</td>
                <td><asp:CheckBox ID="ck_r43" runat="server" onclick="Chkson(this,'ck_r36');"/> 导出调拨单</td>
                <td><asp:CheckBox ID="ck_r44" runat="server" onclick="Chkson(this,'ck_r36');"/> 打印调拨单</td>
                <td><asp:CheckBox ID="ck_r45" runat="server" /> 拆装开单</td>
                <td><asp:CheckBox ID="ck_r46" runat="server" onclick="Chkpar(this,'ck_r49','ck_r49');"/> 浏览拆装单</td>

                
            </tr>
            <tr>
                <td><asp:CheckBox ID="ck_r47" runat="server" onclick="Chkson(this,'ck_r46');"/> 审核拆装单</td>
                            <td><asp:CheckBox ID="ck_r48" runat="server" onclick="Chkson(this,'ck_r46');"/> 反审核拆装单</td>
                <td><asp:CheckBox ID="ck_r49" runat="server" onclick="Chkson(this,'ck_r46');"/> 编辑拆装单</td>
                <td><asp:CheckBox ID="ck_r50" runat="server" onclick="Chkson(this,'ck_r46');"/> 删除拆装单</td>
                <td><asp:CheckBox ID="ck_r51" runat="server" onclick="Chkson(this,'ck_r46');"/> 导出拆装单</td>
                <td><asp:CheckBox ID="ck_r52" runat="server" onclick="Chkson(this,'ck_r46');"/> 打印拆装单</td>

                
            </tr>
            <tr>
                <td><asp:CheckBox ID="ck_r53" runat="server" /> 调价开单</td>
                            <td><asp:CheckBox ID="ck_r54" runat="server" onclick="Chkpar(this,'ck_r57','ck_r58');"/> 浏览调价单</td>
                <td><asp:CheckBox ID="ck_r55" runat="server" onclick="Chkson(this,'ck_r54');"/> 审核调价单</td>
                <td><asp:CheckBox ID="ck_r56" runat="server" onclick="Chkson(this,'ck_r54');"/> 反审核调价单</td>
                <td><asp:CheckBox ID="ck_r57" runat="server" onclick="Chkson(this,'ck_r54');"/> 编辑调价单</td>
                <td><asp:CheckBox ID="ck_r58" runat="server" onclick="Chkson(this,'ck_r54');"/> 删除调价单</td>

                
            </tr>
            <tr>
                <td><asp:CheckBox ID="ck_r59" runat="server" onclick="Chkson(this,'ck_r54');"/> 导出调价单</td>
                <td><asp:CheckBox ID="ck_r60" runat="server" onclick="Chkson(this,'ck_r54');"/> 打印调价单</td>
                <td><asp:CheckBox ID="ck_r61" runat="server" /> 盘点开单</td>
                <td><asp:CheckBox ID="ck_r62" runat="server" onclick="Chkpar(this,'ck_r65','ck_r66');"/> 浏览盘点单</td>
                <td><asp:CheckBox ID="ck_r63" runat="server" onclick="Chkson(this,'ck_r62');"/> 审核盘点单</td>
                <td><asp:CheckBox ID="ck_r64" runat="server" onclick="Chkson(this,'ck_r62');"/> 反审核盘点单</td>

            </tr>
            <tr>
                <td><asp:CheckBox ID="ck_r65" runat="server" onclick="Chkson(this,'ck_r62');"/> 编辑盘点单</td>
                <td><asp:CheckBox ID="ck_r66" runat="server" onclick="Chkson(this,'ck_r62');"/> 删除盘点单</td>
                <td><asp:CheckBox ID="ck_r67" runat="server" onclick="Chkson(this,'ck_r62');"/> 导出盘点单</td>
                <td><asp:CheckBox ID="ck_r68" runat="server" onclick="Chkson(this,'ck_r62');"/> 打印盘点单</td>
                <td><asp:CheckBox ID="ck_r70" runat="server"/> 借出开单</td>
                 <td><asp:CheckBox ID="ck_r71" runat="server"/> 归还审核</td>
                

            </tr>

            <tr>
                <td><asp:CheckBox ID="ck_r72" runat="server"/> 借出查询</td>
                <td><asp:CheckBox ID="ck_r80" runat="server"/> 内部调拨开单</td>
                <td><asp:CheckBox ID="ck_r73" runat="server" /> 浏览内部调拨单</td>
                <td><asp:CheckBox ID="ck_r74" runat="server" /> 审核内部调拨单</td>
                <td><asp:CheckBox ID="ck_r75" runat="server" /> 反审内部调拨单</td>
                <td><asp:CheckBox ID="ck_r76" runat="server" /> 编辑内部调拨单</td>
                
                

            </tr>
            <tr>
                <td><asp:CheckBox ID="ck_r77" runat="server" /> 删除内部调拨单</td>
               <td><asp:CheckBox ID="ck_r78" runat="server" /> 导出内部调拨单</td>
               <td><asp:CheckBox ID="ck_r79" runat="server" /> 打印内部调拨单</td>
               <td colspan="2"><asp:CheckBox ID="ck_r81" runat="server" /> 内部调拨单禁止修改价格</td>
               <td ><asp:CheckBox ID="ck_r82" runat="server" /> 分仓库管理员隔离</td>
                
                

            </tr>
            <tr>
                <td ><asp:CheckBox ID="ck_r84" runat="server" /> 销售出库需审核</td>
                <td ><asp:CheckBox ID="ck_r86" runat="server" /> 采购入库需审核</td>
                <td ><asp:CheckBox ID="ck_r85" runat="server" /> 禁止查看入库价</td>
                <td colspan="2"><asp:CheckBox ID="cb_ck_all" runat="server" onclick="Chkcb(this,'ck_r',86);" /> <span style="color:#000000">全选</span></td>
            </tr>
        </table>
    </div>
    </div>
    
    <div id="info2" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="div2" class="divinfo" style="height:406px; padding-left:5px;">
    <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:760px;">
      <legend>采购</legend>
       <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="cg_r1" runat="server" /> 采购开单</td>
                <td><asp:CheckBox ID="cg_r2" runat="server" /> 退货开单</td>
                <td><asp:CheckBox ID="cg_r3" runat="server" onclick="Chkpar(this,'cg_r4','cg_r5');"/> 浏览采购单</td>
                <td><asp:CheckBox ID="cg_r4" runat="server" onclick="Chkson(this,'cg_r3');"/> 编辑采购单</td>
                <td><asp:CheckBox ID="cg_r5" runat="server" onclick="Chkson(this,'cg_r3');"/> 审核采购单</td>
                <td><asp:CheckBox ID="cg_r6" runat="server" onclick="Chkson(this,'cg_r3');"/> 反审核采购单</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="cg_r7" runat="server" onclick="Chkson(this,'cg_r3');"/> 删除采购单</td>
                <td><asp:CheckBox ID="cg_r8" runat="server" onclick="Chkson(this,'cg_r3');"/> 导出采购单</td>
                <td><asp:CheckBox ID="cg_r9" runat="server" onclick="Chkson(this,'cg_r3');"/> 打印采购单</td>
                <td><asp:CheckBox ID="cg_r10" runat="server" /> 采购订单</td>
                <td><asp:CheckBox ID="cg_r11" runat="server" onclick="Chkpar(this,'cg_r12','cg_r13');"/> 浏览采购订单</td>
                <td><asp:CheckBox ID="cg_r12" runat="server" onclick="Chkson(this,'cg_r11');"/> 编辑采购订单</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="cg_r13" runat="server" onclick="Chkson(this,'cg_r11');"/> 审核采购订单</td>
                <td><asp:CheckBox ID="cg_r14" runat="server" onclick="Chkson(this,'cg_r11');"/> 反审核采购订单</td>
                <td><asp:CheckBox ID="cg_r15" runat="server" onclick="Chkson(this,'cg_r11');"/> 删除采购订单</td>
                <td><asp:CheckBox ID="cg_r16" runat="server" onclick="Chkson(this,'cg_r11');"/> 导出采购订单</td>
                <td><asp:CheckBox ID="cg_r17" runat="server" onclick="Chkson(this,'cg_r11');"/> 打印采购订单</td>
                <td><asp:CheckBox ID="cg_r18" runat="server"/> 业务员部门隔离</td>
            </tr>
            <tr>
                <td colspan="7"><asp:CheckBox ID="cb_cg_all" runat="server" onclick="Chkcb(this,'cg_r',18);"  /> <span style="color:#000000">全选</span></td>
            </tr>  
     </table>
     </fieldset>
     <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:760px;">
      <legend>销售</legend>
    <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="xs_r1" runat="server" /> 销售开单</td>
                <td><asp:CheckBox ID="xs_r2" runat="server" /> 退货开单</td>
                <td><asp:CheckBox ID="xs_r3" runat="server" onclick="Chkpar(this,'xs_r4','xs_r5');"/> 浏览销售单</td>
                <td><asp:CheckBox ID="xs_r4" runat="server" onclick="Chkson(this,'xs_r3');"/> 编辑销售单</td>
                <td><asp:CheckBox ID="xs_r5" runat="server" onclick="Chkson(this,'xs_r3');"/> 审核销售单</td>
                <td><asp:CheckBox ID="xs_r6" runat="server" onclick="Chkson(this,'xs_r3');"/> 反审核销售单</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="xs_r7" runat="server" onclick="Chkson(this,'xs_r3');"/> 删除销售单</td>
                <td><asp:CheckBox ID="xs_r8" runat="server" onclick="Chkson(this,'xs_r3');"/> 导出销售单</td>
                <td><asp:CheckBox ID="xs_r9" runat="server" onclick="Chkson(this,'xs_r3');"/> 打印销售单</td>
                <td><asp:CheckBox ID="xs_r10" runat="server" /> 销售订单</td>
                <td><asp:CheckBox ID="xs_r11" runat="server" onclick="Chkpar(this,'xs_r12','xs_r13');"/> 浏览销售订单</td>
                <td><asp:CheckBox ID="xs_r12" runat="server" onclick="Chkson(this,'xs_r11');"/> 编辑销售订单</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="xs_r13" runat="server" onclick="Chkson(this,'xs_r11');"/> 审核销售订单</td>
                <td><asp:CheckBox ID="xs_r14" runat="server" onclick="Chkson(this,'xs_r11');"/> 反审核销售订单</td>
                <td><asp:CheckBox ID="xs_r18" runat="server" onclick="Chkson(this,'xs_r11');"/> 终止销售订单</td>
                <td><asp:CheckBox ID="xs_r15" runat="server" onclick="Chkson(this,'xs_r11');"/> 删除销售订单</td>
                <td><asp:CheckBox ID="xs_r16" runat="server" onclick="Chkson(this,'xs_r11');"/> 导出销售订单</td>
                <td><asp:CheckBox ID="xs_r17" runat="server" onclick="Chkson(this,'xs_r11');"/> 打印销售订单</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="xs_r19" runat="server"/> 业务员部门隔离</td>
                <td><asp:CheckBox ID="xs_r20" runat="server"/> 业务员隔离</td>
            </tr>
            <tr>
                <td colspan="7"><asp:CheckBox ID="cb_xs_all" runat="server" onclick="Chkcb(this,'xs_r',20);"  /> <span style="color:#000000">全选</span></td>
            </tr>  
     </table>
     </fieldset>
    </div>
    </div>
    
    <div id="info3" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="div4" class="divinfo" style="height:406px;">
        <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="gd_r1" runat="server" /> 浏览服务单</td>
                <td><asp:CheckBox ID="gd_r2" runat="server" /> 报修审核</td>
                <td><asp:CheckBox ID="gd_r3" runat="server" /> 报修取消</td>
                <td><asp:CheckBox ID="gd_r4" runat="server" /> 送修确认</td>
                <td><asp:CheckBox ID="gd_r5" runat="server" /> 送修驳回</td>
                <td><asp:CheckBox ID="gd_r6" runat="server" /> 服务受理</td>
                
            </tr>
            <tr>
                <td><asp:CheckBox ID="gd_r7" runat="server" /> 服务中心</td>
                <td><asp:CheckBox ID="gd_r8" runat="server" /> 编辑服务单</td>
                <td><asp:CheckBox ID="gd_r9" runat="server" /> 维修处理</td>
                <td><asp:CheckBox ID="gd_r22" runat="server" /> 服务报价</td>
                <td><asp:CheckBox ID="gd_r10" runat="server" /> 送修发货</td>
                <td><asp:CheckBox ID="gd_r11" runat="server" /> 收货结算</td>
                
            </tr>
            <tr>
                <td><asp:CheckBox ID="gd_r12" runat="server" /> 历史送修</td>
                <td><asp:CheckBox ID="gd_r13" runat="server" /> 完工结算</td>
                <td><asp:CheckBox ID="gd_r14" runat="server" /> 审核关闭</td>
                <td><asp:CheckBox ID="gd_r34" runat="server" /> 审核关闭驳回</td>
                <td><asp:CheckBox ID="gd_r21" runat="server" /> 服务回访</td>
                <td><asp:CheckBox ID="gd_r15" runat="server" /> 服务单查询</td>
                
                
                
            </tr>
            <tr>
                <td><asp:CheckBox ID="gd_r16" runat="server" /> 删除服务单</td>
                <td><asp:CheckBox ID="gd_r23" runat="server" /> 取消服务单</td>
                <td><asp:CheckBox ID="gd_r17" runat="server" /> 导出服务单</td>
                <td><asp:CheckBox ID="gd_r18" runat="server" /> 打印服务单</td>

                <td><asp:CheckBox ID="gd_r19" runat="server" /> 完工结算驳回</td>
                <td><asp:CheckBox ID="gd_r20" runat="server" /> 技术员隔离</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="gd_r36" runat="server" /> 技术员部门隔离</td>
                <td><asp:CheckBox ID="gd_r24" runat="server" /> 区域隔离</td>
                <td><asp:CheckBox ID="gd_r25" runat="server"/> 业务员部门隔离</td>
                <td><asp:CheckBox ID="gd_r27" runat="server"/> 受理人部门隔离</td>
                <td><asp:CheckBox ID="gd_r26" runat="server"/> 禁止修改项目提成</td>
                <td><asp:CheckBox ID="gd_r28" runat="server"/> 禁止派给网点</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="gd_r29" runat="server"/> 禁止委外送修</td>
                <td><asp:CheckBox ID="gd_r30" runat="server"/> 禁止完成关闭</td>
                <td><asp:CheckBox ID="gd_r31" runat="server"/> 禁止查看项目金额</td>

                <td colspan="3"><asp:CheckBox ID="gd_r32" runat="server"/> 禁止查看服务单收费结算金额</td>
                
            </tr>
            <tr>
                <td colspan="2"><asp:CheckBox ID="gd_r35" runat="server"/> 禁止修改服务单受理时间</td>
                <td colspan="2"><asp:CheckBox ID="gd_r33" runat="server"/> 禁止查看审核关闭提成明细</td>
             </tr>
            <tr>
                <td colspan="7"><asp:CheckBox ID="cb_gd_all" runat="server" onclick="Chkcb(this,'gd_r',36);"  /> <span style="color:#000000">全选</span></td>
            </tr>  
     </table>
    
    </div>
    </div>
    
    <div id="info4" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="div6" class="divinfo" style="height:406px;">
        <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="zl_r1" runat="server" /> 新建业务</td>
                <td><asp:CheckBox ID="zl_r21" runat="server" /> 浏览业务审核</td>
                <td><asp:CheckBox ID="zl_r22" runat="server" /> 审核业务单</td>
                <td><asp:CheckBox ID="zl_r23" runat="server" /> 反审核业务单</td>
                <td><asp:CheckBox ID="zl_r2" runat="server" /> 浏览抄表登记</td>
                <td><asp:CheckBox ID="zl_r3" runat="server" onclick="Chkson(this,'zl_r2');"/> 抄表登记</td>
                <td><asp:CheckBox ID="zl_r15" runat="server" /> 修改抄表</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="zl_r16" runat="server" /> 删除抄表</td>
                <td><asp:CheckBox ID="zl_r4" runat="server" /> 结算开单</td>
                <td><asp:CheckBox ID="zl_r5" runat="server"/> 浏览设备退换</td>
                <td><asp:CheckBox ID="zl_r6" runat="server" onclick="Chkson(this,'zl_r5');"/> 设备退换</td>
                <td><asp:CheckBox ID="zl_r7" runat="server" /> 浏览合同解约</td>
                <td><asp:CheckBox ID="zl_r8" runat="server" onclick="Chkson(this,'zl_r7');"/> 合同解约</td>
                <td><asp:CheckBox ID="zl_r9" runat="server" onclick="Chkpar(this,'zl_r10','zl_r11');"/> 浏览结算审核</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="zl_r10" runat="server" onclick="Chkson(this,'zl_r9');"/> 结算审核</td>
                <td><asp:CheckBox ID="zl_r11" runat="server" onclick="Chkson(this,'zl_r9');"/> 结算取消</td>
                <td><asp:CheckBox ID="zl_r12" runat="server"/> 业务查询</td>
                <td><asp:CheckBox ID="zl_r13" runat="server"/> 导出业务单</td>
                <td><asp:CheckBox ID="zl_r14" runat="server"/> 修改业务单</td>
                <td><asp:CheckBox ID="zl_r17" runat="server"/> 打印业务单</td>
                <td><asp:CheckBox ID="zl_r18" runat="server"/> 打印结算单</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="zl_r19" runat="server"/> 取消业务单</td>
                <td><asp:CheckBox ID="zl_r20" runat="server"/> 删除业务单</td>
                <td><asp:CheckBox ID="zl_r24" runat="server"/> 反结算结算单</td>
                <td><asp:CheckBox ID="zl_r25" runat="server"/> 删除结算单</td>
                <td><asp:CheckBox ID="zl_r26" runat="server"/> 业务员部门隔离</td>
                <td><asp:CheckBox ID="zl_r27" runat="server"/> 租赁派单</td>
            </tr>
            <tr>
                <td colspan="7"><asp:CheckBox ID="cb_zl_all" runat="server" onclick="Chkcb(this,'zl_r',27);"  /> <span style="color:#000000">全选</span></td>
            </tr>   
     </table>
    </div>
    </div>

    <div id="info5" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="div8" class="divinfo" style="height:406px;">
        <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="kh_r1" runat="server" /> 编辑客户分类</td>
                <td><asp:CheckBox ID="kh_r19" runat="server" /> 编辑会员级别</td>
                <td><asp:CheckBox ID="kh_r2" runat="server" onclick="Chkpar(this,'kh_r3','kh_r4');"/> 浏览客户</td>
                <td><asp:CheckBox ID="kh_r3" runat="server" onclick="Chkson(this,'kh_r2');"/> 添加客户</td>
                <td><asp:CheckBox ID="kh_r4" runat="server" onclick="Chkson(this,'kh_r2');"/> 编辑客户</td>
                <td><asp:CheckBox ID="kh_r32" runat="server" onclick="Chkson(this,'kh_r2');"/> 分派客户</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="kh_r5" runat="server" onclick="Chkson(this,'kh_r2');"/> 导出客户</td>
                <td><asp:CheckBox ID="kh_r6" runat="server" onclick="Chkpar(this,'kh_r7','kh_r8');"/> 浏览机器档案</td>
                <td><asp:CheckBox ID="kh_r7" runat="server" onclick="Chkson(this,'kh_r6');"/> 添加机器档案</td>
                <td><asp:CheckBox ID="kh_r8" runat="server" onclick="Chkson(this,'kh_r6');"/> 编辑机器档案</td>
                <td><asp:CheckBox ID="kh_r9" runat="server" onclick="Chkson(this,'kh_r6');"/> 导出机器档案</td>
                <td><asp:CheckBox ID="kh_r34" runat="server" onclick="Chkson(this,'kh_r6');"/> 机器档案技术员隔离</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="kh_r20" runat="server" /> 浏览服务合同</td>
                <td><asp:CheckBox ID="kh_r21" runat="server" /> 新建服务合同</td>
                <td><asp:CheckBox ID="kh_r22" runat="server" /> 修改服务合同</td>
                <td><asp:CheckBox ID="kh_r23" runat="server" /> 删除服务合同</td>
                <td><asp:CheckBox ID="kh_r24" runat="server" /> 终止服务合同</td>
                <td><asp:CheckBox ID="kh_r10" runat="server" /> 保养派工</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="kh_r11" runat="server" /> 耗材跟踪</td>
                <td><asp:CheckBox ID="kh_r12" runat="server" /> 报修会员管理</td>
                <td><asp:CheckBox ID="kh_r13" runat="server" onclick="Chkpar(this,'kh_r14','kh_r15');" /> 客户跟踪</td>
                <td><asp:CheckBox ID="kh_r14" runat="server" onclick="Chkson(this,'kh_r13');"/> 新建跟踪</td>
                <td><asp:CheckBox ID="kh_r15" runat="server" onclick="Chkson(this,'kh_r13');"/> 修改跟踪</td>
                <td><asp:CheckBox ID="kh_r16" runat="server" onclick="Chkson(this,'kh_r13');"/> 删除跟踪</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="kh_r17" runat="server" /> 投诉管理</td>
                <td><asp:CheckBox ID="kh_r25" runat="server" onclick="Chkson(this,'kh_r17');"/> 投诉受理</td>
                <td><asp:CheckBox ID="kh_r26" runat="server" onclick="Chkson(this,'kh_r17');"/> 修改投诉</td>
                <td><asp:CheckBox ID="kh_r27" runat="server" onclick="Chkson(this,'kh_r17');"/> 投诉处理</td>
                <td><asp:CheckBox ID="kh_r28" runat="server" onclick="Chkson(this,'kh_r17');"/> 投诉取消</td>
                
                <td><asp:CheckBox ID="kh_r18" runat="server" /> 区域隔离</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="kh_r29" runat="server" /> 业务员隔离</td>
                <td><asp:CheckBox ID="kh_r30" runat="server" /> 跟踪人隔离</td>
                <td colspan="2"><asp:CheckBox ID="kh_r31" runat="server" /> 禁止查看他人跟踪信息</td>
                <td colspan="2"><asp:CheckBox ID="kh_r33" runat="server" /> 禁止历史跟踪人查看</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="kh_r35" runat="server"/> 业务员部门隔离</td>
            </tr>
            <tr>
                <td colspan="7"><asp:CheckBox ID="cb_kh_all" runat="server" onclick="Chkcb(this,'kh_r',35);"  /> <span style="color:#000000">全选</span></td>
            </tr>
        </table>
    </div>
    </div>
    
    <div id="info6" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="div10" class="divinfo" style="height:406px;">
        <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="zk_r1" runat="server" /> 收应收款</td>
                <td><asp:CheckBox ID="zk_r2" runat="server" /> 收预收款</td>
                <td><asp:CheckBox ID="zk_r3" runat="server" /> 其他收款</td>
                <td><asp:CheckBox ID="zk_r4" runat="server" /> 付应付款</td>
                <td><asp:CheckBox ID="zk_r5" runat="server" /> 付预付款</td>
                <td><asp:CheckBox ID="zk_r6" runat="server" /> 其他付款</td>
                <td><asp:CheckBox ID="zk_r7" runat="server" /> 浏览收付款</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="zk_r8" runat="server" /> 编辑收付款</td>
                <td><asp:CheckBox ID="zk_r9" runat="server" /> 审核收付款</td>
                <td><asp:CheckBox ID="zk_r10" runat="server" /> 反审核收付款</td>
                <td><asp:CheckBox ID="zk_r11" runat="server" /> 作废收付款</td>
                <td><asp:CheckBox ID="zk_r12" runat="server" /> 导出收付款</td>
                <td><asp:CheckBox ID="zk_r13" runat="server" /> 打印收付款</td>
                <td><asp:CheckBox ID="zk_r14" runat="server" /> 浏览应收应付</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="zk_r15" runat="server" /> 编辑应收应付</td>
                <td><asp:CheckBox ID="zk_r16" runat="server" /> 导出应收应付</td>
                <td><asp:CheckBox ID="zk_r17" runat="server" /> 帐户转账</td>
                <td><asp:CheckBox ID="zk_r18" runat="server" /> 帐户汇总</td>
                <td><asp:CheckBox ID="zk_r19" runat="server" /> 报销申请</td>
                <td><asp:CheckBox ID="zk_r20" runat="server" /> 主管审核</td>
                <td><asp:CheckBox ID="zk_r21" runat="server" /> 款项发放</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="zk_r22" runat="server" /> 报销查询</td>
                <td><asp:CheckBox ID="zk_r23" runat="server" /> 修改报销</td>
                <td><asp:CheckBox ID="zk_r24" runat="server" /> 报销明细</td>
            </tr>
            <tr>
                <td colspan="7"><asp:CheckBox ID="cb_zk_all" runat="server" onclick="Chkcb(this,'zk_r',24);"  /> <span style="color:#000000">全选</span></td>
            </tr>  
        </table>
    
    </div>
    </div>
    
    <div id="info7" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="div12" class="divinfo" style="height:406px;">
        <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="fh_r1" runat="server" /> 新建发货</td>
                <td><asp:CheckBox ID="fh_r2" runat="server" /> 发货确认</td>
                <td><asp:CheckBox ID="fh_r3" runat="server" /> 签收确认</td>
                <td><asp:CheckBox ID="fh_r4" runat="server" /> 发货单查询</td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td colspan="7"><asp:CheckBox ID="cb_fh_all" runat="server" onclick="Chkcb(this,'fh_r',4);"  /> <span style="color:#000000">全选</span></td>
            </tr>
        </table>
    </div>
    </div>
    
    <div id="info8" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="div14" class="divinfo" style="height:406px;">
        <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="bg_r1" runat="server" /> 编辑文档分类</td>
                <td><asp:CheckBox ID="bg_r2" runat="server" onclick="Chkpar(this,'bg_r3','bg_r4');"/> 浏览文档</td>
                <td><asp:CheckBox ID="bg_r3" runat="server" onclick="Chkson(this,'bg_r2');"/> 新建文档</td>
                <td><asp:CheckBox ID="bg_r4" runat="server" onclick="Chkson(this,'bg_r2');"/> 编辑文档</td>
                <td><asp:CheckBox ID="bg_r5" runat="server" onclick="Chkpar(this,'bg_r6','bg_r7');"/> 浏览公告</td>
                <td><asp:CheckBox ID="bg_r6" runat="server" onclick="Chkson(this,'bg_r5');"/> 新建公告</td>
                <td><asp:CheckBox ID="bg_r7" runat="server" onclick="Chkson(this,'bg_r5');"/> 编辑公告</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="bg_r8" runat="server" /> 站内信件</td>
                <td><asp:CheckBox ID="bg_r9" runat="server" /> 编辑知识分类</td>
                <td><asp:CheckBox ID="bg_r10" runat="server" onclick="Chkpar(this,'bg_r11','bg_r12');" /> 浏览知识</td>
                <td><asp:CheckBox ID="bg_r11" runat="server" onclick="Chkson(this,'bg_r10');" /> 新建知识</td>
                <td><asp:CheckBox ID="bg_r12" runat="server" onclick="Chkson(this,'bg_r10');" /> 编辑知识</td>
                <td><asp:CheckBox ID="bg_r13" runat="server"/> 考勤签到</td>
                <td><asp:CheckBox ID="bg_r14" runat="server"/> 缺勤审核</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="bg_r15" runat="server"/> 考勤汇总</td>
                <td><asp:CheckBox ID="bg_r16" runat="server"/> 导入考勤明细</td>
                <td><asp:CheckBox ID="bg_r17" runat="server"/> 考勤设置</td>
                <td><asp:CheckBox ID="bg_r18" runat="server"/> 修改考勤密码</td>
                
                <td><asp:CheckBox ID="bg_r19" runat="server"/> 任务管理</td>
                <td><asp:CheckBox ID="bg_r20" runat="server"/> 新建任务</td>
                <td><asp:CheckBox ID="bg_r21" runat="server"/> 编辑任务</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="bg_r22" runat="server"/> 删除任务</td>
                <td><asp:CheckBox ID="bg_r23" runat="server"/> 执行任务</td>
                <td><asp:CheckBox ID="bg_r24" runat="server"/> 评价任务</td>
                <td colspan="2"><asp:CheckBox ID="bg_r25" runat="server"/> 只允许执行人执行</td>
                <td colspan="2"><asp:CheckBox ID="bg_r26" runat="server"/> 只允许创建人评价</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="bg_r27" runat="server"/> 员工提成明细</td>
                <td><asp:CheckBox ID="bg_r28" runat="server"/> 异常考勤明细</td>
                <td><asp:CheckBox ID="bg_r29" runat="server"/> 员工月度薪资</td>
                <td><asp:CheckBox ID="bg_r30" runat="server"/> 员工工作汇总</td>
                <td><asp:CheckBox ID="bg_r31" runat="server"/> 信息反馈审核</td>
                <td><asp:CheckBox ID="bg_r32" runat="server"/> 员工提成隔离</td>
            </tr>
            <tr>
                <td colspan="7"><asp:CheckBox ID="cb_bg_all" runat="server" onclick="Chkcb(this,'bg_r',32);"  /> <span style="color:#000000">全选</span></td>
            </tr>  
        </table> 
    
    </div>
    </div>
    
    <div id="info9" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="div16" class="divinfo" style="height:406px;">
      <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="qc_r1" runat="server" /> 期初产品库存</td>
                <td><asp:CheckBox ID="qc_r2" runat="server" /> 客户期初应收应付</td>
                <td><asp:CheckBox ID="qc_r3" runat="server" /> 厂商期初应收应付</td>
                <td><asp:CheckBox ID="qc_r4" runat="server" /> 网点期初应收应付</td>
                <td><asp:CheckBox ID="qc_r5" runat="server" /> 期初现金银行</td>
            </tr>
            <tr>
                <td colspan="5"><asp:CheckBox ID="cb_qc_all" runat="server" onclick="Chkcb(this,'qc_r',5);"  /> <span style="color:#000000">全选</span></td>
            </tr>
      </table>
    </div>
    </div>
    
    <div id="info10" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="div18" class="divinfo" style="height:406px;">
        <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="tj_r1" runat="server" /> 日营业额汇总表</td>
                <td><asp:CheckBox ID="tj_r2" runat="server" /> 月营业额汇总表</td>
                <td><asp:CheckBox ID="tj_r3" runat="server" /> 仓库日报表</td>
                <td><asp:CheckBox ID="tj_r4" runat="server" /> 仓库汇总表</td>
                <td><asp:CheckBox ID="tj_r5" runat="server" /> 产品入库汇总表</td>
                <td><asp:CheckBox ID="tj_r6" runat="server" /> 仓库入库汇总表</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="tj_r7" runat="server" /> 入库明细汇总表</td>
                <td><asp:CheckBox ID="tj_r8" runat="server" /> 产品出库汇总表</td>
                <td><asp:CheckBox ID="tj_r9" runat="server" /> 仓库出库汇总表</td>
                <td><asp:CheckBox ID="tj_r10" runat="server" /> 出库明细汇总表</td>
                <td><asp:CheckBox ID="tj_r11" runat="server" /> 产品领退汇总表</td>
                <td><asp:CheckBox ID="tj_r12" runat="server" /> 申请人领退汇总表</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="tj_r13" runat="server" /> 采购日报表</td>
                <td><asp:CheckBox ID="tj_r14" runat="server" /> 产品采购汇总表</td>
                <td><asp:CheckBox ID="tj_r15" runat="server" /> 供应商采购汇总表</td>
                <td><asp:CheckBox ID="tj_r16" runat="server" /> 采购明细汇总表</td>
                <td><asp:CheckBox ID="tj_r17" runat="server" /> 产品退货汇总表</td>
                <td><asp:CheckBox ID="tj_r18" runat="server" /> 供应商退货汇总表</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="tj_r19" runat="server" /> 退货明细汇总表</td>
                <td><asp:CheckBox ID="tj_r20" runat="server" /> 销售日报表</td>
                <td><asp:CheckBox ID="tj_r21" runat="server" /> 销售月报表</td>
                <td><asp:CheckBox ID="tj_r22" runat="server" /> 产品销售汇总表</td>
                <td><asp:CheckBox ID="tj_r23" runat="server" /> 客户销售汇总表</td>
                <td><asp:CheckBox ID="tj_r24" runat="server" /> 销售明细汇总表</td>
                
            </tr>
            <tr>
                <td><asp:CheckBox ID="tj_r25" runat="server" /> 产品退货汇总表</td>
                <td><asp:CheckBox ID="tj_r26" runat="server" /> 客户退货汇总表</td>
                <td><asp:CheckBox ID="tj_r27" runat="server" /> 退货明细汇总表</td>
                <td><asp:CheckBox ID="tj_r28" runat="server" /> 服务日报表</td>
                <td><asp:CheckBox ID="tj_r29" runat="server" /> 服务月报表</td>
                <td><asp:CheckBox ID="tj_r30" runat="server" /> 服务汇总表</td>
                
                
            </tr>
            <tr>
                <td><asp:CheckBox ID="tj_r31" runat="server" /> 服务明细表</td>
                <td><asp:CheckBox ID="tj_r32" runat="server" /> 服务项目汇总表</td>
                <td><asp:CheckBox ID="tj_r33" runat="server" /> 服务项目明细表</td>
                <td><asp:CheckBox ID="tj_r34" runat="server" /> 服务单概览</td>
                <td><asp:CheckBox ID="tj_r35" runat="server" /> 服务单分布</td>
                <td><asp:CheckBox ID="tj_r36" runat="server" /> 技术员业绩</td>
                
            </tr>
            <tr>
                <td><asp:CheckBox ID="tj_r37" runat="server" /> 超期单统计</td>
                <td><asp:CheckBox ID="tj_r38" runat="server" /> 服务单地图</td>
                <td><asp:CheckBox ID="tj_r65" runat="server" /> 服务备件汇总表</td>
                <td><asp:CheckBox ID="tj_r39" runat="server" /> 修品分布图表</td>
                <td><asp:CheckBox ID="tj_r40" runat="server" /> 故障分布图表</td>
                <td><asp:CheckBox ID="tj_r66" runat="server" /> 处理措施分布</td>
                
            </tr>
            <tr>
                <td><asp:CheckBox ID="tj_r41" runat="server" /> 收支日报表</td>
                <td><asp:CheckBox ID="tj_r42" runat="server" /> 收支月报表</td>
                <td><asp:CheckBox ID="tj_r43" runat="server" /> 收款单汇总表</td>
                <td><asp:CheckBox ID="tj_r44" runat="server" /> 收款单明细表</td>
                <td><asp:CheckBox ID="tj_r45" runat="server" /> 付款单汇总表</td>
                <td><asp:CheckBox ID="tj_r46" runat="server" /> 付款单明细表</td>
                
                
            </tr>
            <tr>
                <td><asp:CheckBox ID="tj_r47" runat="server" /> 应收应付汇总表</td>
                <td><asp:CheckBox ID="tj_r48" runat="server" /> 应收应付明细表</td>
                <td><asp:CheckBox ID="tj_r49" runat="server" /> 应收应付帐龄表</td>
                <td><asp:CheckBox ID="tj_r50" runat="server" /> 应收应付坏帐表</td>
                <td><asp:CheckBox ID="tj_r51" runat="server" /> 结算单汇总表</td>
                <td><asp:CheckBox ID="tj_r52" runat="server" /> 结算单明细表</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="tj_r53" runat="server" /> 客户增长情况</td>
                <td><asp:CheckBox ID="tj_r54" runat="server" /> 客户价值排行</td>
                <td><asp:CheckBox ID="tj_r55" runat="server" /> 业务趋势分析</td>
                <td><asp:CheckBox ID="tj_r56" runat="server" /> 工作进度分析</td>
                <td><asp:CheckBox ID="tj_r57" runat="server" /> 收款方式分析</td>
                <td><asp:CheckBox ID="tj_r58" runat="server" /> 取消原因分析</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="tj_r59" runat="server" /> 服务类别分析</td>
                <td><asp:CheckBox ID="tj_r60" runat="server" /> 受理方式分析</td>
                <td><asp:CheckBox ID="tj_r61" runat="server" /> 客户来源分析</td>
                <td><asp:CheckBox ID="tj_r62" runat="server" /> 客户类别分析</td>
                <td><asp:CheckBox ID="tj_r63" runat="server" /> 返修汇总表</td>
                <td><asp:CheckBox ID="tj_r64" runat="server" /> 重复维修率</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="tj_r67" runat="server" /> 维保合同序时簿</td>
                <td><asp:CheckBox ID="tj_r68" runat="server" /> 维保维修成本</td>
                <td><asp:CheckBox ID="tj_r69" runat="server" /> 维保期外成本</td>
                <td><asp:CheckBox ID="tj_r70" runat="server" /> 服务成本</td>
            </tr>
            <tr>
                <td colspan="5"><asp:CheckBox ID="cb_tj_all" runat="server" onclick="Chkcb(this,'tj_r',70);"  /> <span style="color:#000000">全选</span></td>
            </tr>
      </table>
    
    </div>
    </div>
    
    <div id="info11" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="div20" class="divinfo" style="height:406px;">
        <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="jc_r1" runat="server" /> 编辑基础信息</td>
                <td><asp:CheckBox ID="jc_r2" runat="server" onclick="Chkpar(this,'jc_r3','jc_r4');"/> 浏览网点</td>
                <td><asp:CheckBox ID="jc_r3" runat="server" onclick="Chkson(this,'jc_r2');" /> 新建网点</td>
                <td><asp:CheckBox ID="jc_r4" runat="server" onclick="Chkson(this,'jc_r2');"/> 编辑网点</td>
                <td><asp:CheckBox ID="jc_r5" runat="server" onclick="Chkpar(this,'jc_r6','jc_r7');" /> 浏览员工</td>
                <td><asp:CheckBox ID="jc_r6" runat="server" onclick="Chkson(this,'jc_r5');" /> 新建员工</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="jc_r7" runat="server" onclick="Chkson(this,'jc_r5');"/> 编辑员工</td>
                <td><asp:CheckBox ID="jc_r8" runat="server" /> 编辑仓库目录</td>
                
                <td><asp:CheckBox ID="jc_r31" runat="server" /> 编辑厂商分类</td>
                <td><asp:CheckBox ID="jc_r32" runat="server" onclick="Chkpar(this,'kh_r33','kh_r34');"/> 浏览厂商</td>
                <td><asp:CheckBox ID="jc_r33" runat="server" onclick="Chkson(this,'kh_r32');"/> 添加厂商</td>
                <td><asp:CheckBox ID="jc_r34" runat="server" onclick="Chkson(this,'kh_r32');"/> 编辑厂商</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="jc_r35" runat="server" onclick="Chkson(this,'kh_r32');"/> 导出厂商</td>
                <td><asp:CheckBox ID="jc_r9" runat="server" /> 编辑机器品牌</td>
                <td><asp:CheckBox ID="jc_r10" runat="server" /> 编辑机器类别</td>
                <td><asp:CheckBox ID="jc_r11" runat="server" /> 编辑机器型号</td>
                <td><asp:CheckBox ID="jc_r12" runat="server" /> 编辑服务类别</td>
                <td><asp:CheckBox ID="jc_r13" runat="server" /> 编辑保修情况</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="jc_r29" runat="server" /> 编辑服务级别</td>
                <td><asp:CheckBox ID="jc_r30" runat="server" /> 编辑报价项目</td>
                <td><asp:CheckBox ID="jc_r14" runat="server" /> 编辑维修类别</td>
                <td><asp:CheckBox ID="jc_r15" runat="server" /> 编辑故障分类</td>
                <td><asp:CheckBox ID="jc_r16" runat="server" /> 编辑故障原因</td>
                <td><asp:CheckBox ID="jc_r17" runat="server" /> 编辑常见故障</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="jc_r18" runat="server" /> 编辑服务项目</td>
                <td><asp:CheckBox ID="jc_r19" runat="server" /> 编辑物品去向</td>
                <td><asp:CheckBox ID="jc_r20" runat="server" /> 编辑回访内容</td>
                <td><asp:CheckBox ID="jc_r21" runat="server" /> 编辑机器配置项</td>
                <td><asp:CheckBox ID="jc_r22" runat="server" /> 编辑超期单设置</td>
                <td><asp:CheckBox ID="jc_r23" runat="server" /> 编辑收支帐户</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="jc_r24" runat="server" /> 编辑收支项目</td>
                <td><asp:CheckBox ID="jc_r25" runat="server" /> 编辑报销项目</td>
                <td><asp:CheckBox ID="jc_r26" runat="server" /> 编辑货运方式</td>
                <td><asp:CheckBox ID="jc_r27" runat="server" /> 禁止查看进货价</td>
                <td><asp:CheckBox ID="jc_r28" runat="server" /> 禁止查看供应商</td>
                <td><asp:CheckBox ID="jc_r36" runat="server" /> 禁止查看成本均价</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="jc_r37" runat="server" /> 允许最低价出库</td>
            </tr>
            <tr>
                <td colspan="6"><asp:CheckBox ID="cb_jc_all" runat="server" onclick="Chkcb(this,'jc_r',37);"  /> <span style="color:#000000">全选</span></td>
            </tr>  
        </table>
    
    </div>
    </div>
    
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td></td>
        <td align="right">
            <asp:CheckBox ID="cb_all" runat="server" onclick="Chkcball(this);" /><span style="color:#0000ff">全选</span>
            <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnSave_Click" />
            <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog();"/>
        </td>
    </tr>
    </table>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    
    </div>
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var tabnum=12;

function ChkSave()
{
    if(isNull($("tbName").value))
    {
        window.alert("操作失败！权限组名不能为空");
        $("tbName").focus();
        return false
    }
}

function Chkcb(obj,id,num)
{
    if(obj.checked)
    {
        for(var i=1;i<=num;i++)
        {
            $(id+i).checked=true;
        }
    }
    else
    {
        for(var i=1;i<=num;i++)
        {
            $(id+i).checked=false;
        }
    }
}

function Chkson(obj,id)
{
    if(obj.checked)
    {
        $(id).checked=true;
    }
}

function Chkpar(obj,id1,id2)
{
    if(id2=="")
    {
        if($(id1).checked)
        {
            obj.checked=true;
        }
    }
    else
    {
        if($(id1).checked||$(id2).checked)
        {
            obj.checked=true;
        }
    }
}

function Chkcball(obj)
{
    if(obj.checked)
    {
        for(var i=1;i<=86;i++)
        {
            $("ck_r"+i).checked=true;
        }
        for(var i=1;i<=18;i++)
        {
            $("cg_r"+i).checked=true;
        }
        for(var i=1;i<=20;i++)
        {
            $("xs_r"+i).checked=true;
        }
        for(var i=1;i<=36;i++)
        {
            $("gd_r"+i).checked=true;
        }
        for(var i=1;i<=27;i++)
        {
            $("zl_r"+i).checked=true;
        }
        for(var i=1;i<=35;i++)
        {
            $("kh_r"+i).checked=true;
        }
        for(var i=1;i<=24;i++)
        {
            $("zk_r"+i).checked=true;
        } 
        for(var i=1;i<=32;i++)
        {
            $("bg_r"+i).checked=true;
        }
        for(var i=1;i<=4;i++)
        {
            $("fh_r"+i).checked=true;
        }
        for(var i=1;i<=5;i++)
        {
            $("qc_r"+i).checked=true;
        }
        for(var i=1;i<=70;i++)
        {
            $("tj_r"+i).checked=true;
        }
        for(var i=1;i<=37;i++)
        {
            $("jc_r"+i).checked=true;
        }
    }
    else
    {
        for(var i=1;i<=86;i++)
        {
            $("ck_r"+i).checked=false;
        }
        for(var i=1;i<=18;i++)
        {
            $("cg_r"+i).checked=false;
        }
        for(var i=1;i<=20;i++)
        {
            $("xs_r"+i).checked=false;
        }
        for(var i=1;i<=36;i++)
        {
            $("gd_r"+i).checked=false;
        }
        for(var i=1;i<=27;i++)
        {
            $("zl_r"+i).checked=false;
        }
        for(var i=1;i<=35;i++)
        {
            $("kh_r"+i).checked=false;
        }
        for(var i=1;i<=24;i++)
        {
            $("zk_r"+i).checked=false;
        } 
        for(var i=1;i<=32;i++)
        {
            $("bg_r"+i).checked=false;
        }
        for(var i=1;i<=4;i++)
        {
            $("fh_r"+i).checked=false;
        }
        for(var i=1;i<=5;i++)
        {
            $("qc_r"+i).checked=false;
        }
        for(var i=1;i<=70;i++)
        {
            $("tj_r"+i).checked=false;
        }
        for(var i=1;i<=37;i++)
        {
            $("jc_r"+i).checked=false;
        }
    }
}
</script>
