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
                    Ȩ��������
                </td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin" Width="200"></asp:TextBox></td>
                <td style="padding-left:5px;">
                    <span class="si2" >(Ĭ��û���κ�Ȩ�ޣ������Ը���Ȩ��������ѡ��Ӧ��Ȩ��)</span>
                </td>
            </tr>
        </table>
    </div>
    </div>
    <div class="divh"></div>
    <div id="mytabs">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">�ֿ����</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">�ɹ�/����</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">�������</span>
            <span id="tabs_r3"></span>
            <span id="tabs_l4"></span>
            <span id="tabs4" onclick="ChkTab('4');">����/ȫ��</span>
            <span id="tabs_r4"></span>
            <span id="tabs_l5"></span>
            <span id="tabs5" onclick="ChkTab('5');">�ͻ���ϵ</span>
            <span id="tabs_r5"></span>
            <span id="tabs_l6"></span>
            <span id="tabs6" onclick="ChkTab('6');">�ʿ����</span>
            <span id="tabs_r6"></span>
            <span id="tabs_l7"></span>
            <span id="tabs7" onclick="ChkTab('7');">�շ�����</span>
            <span id="tabs_r7"></span>
            <span id="tabs_l8"></span>
            <span id="tabs8" onclick="ChkTab('8');">�칫OA</span>
            <span id="tabs_r8"></span>
            <span id="tabs_l9"></span>
            <span id="tabs9" onclick="ChkTab('9');">�ڳ�¼��</span>
            <span id="tabs_r9"></span>
            <span id="tabs_l10"></span>
            <span id="tabs10" onclick="ChkTab('10');">ͳ�Ʒ���</span>
            <span id="tabs_r10"></span>
            <span id="tabs_l11"></span>
            <span id="tabs11" onclick="ChkTab('11');">��������</span>
            <span id="tabs_r11"></span>
     </div>
    <div id="info1" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="div1" class="divinfo" style="height:406px;">
        <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="ck_r1" runat="server" /> �༭��Ʒ����</td>
                <td><asp:CheckBox ID="ck_r2" runat="server" onclick="Chkpar(this,'ck_r3','ck_r4');" /> �����Ʒ</td>
                <td><asp:CheckBox ID="ck_r3" runat="server" onclick="Chkson(this,'ck_r2');" /> ��Ӳ�Ʒ</td>
                <td><asp:CheckBox ID="ck_r4" runat="server" onclick="Chkson(this,'ck_r2');"/> �༭��Ʒ</td>
                <td><asp:CheckBox ID="ck_r83" runat="server" onclick="Chkson(this,'ck_r2');"/> ������Ʒ</td>
                <td><asp:CheckBox ID="ck_r5" runat="server" /> �����ǰ���</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="ck_r6" runat="server" /> �����Ʒ���</td>
             <td><asp:CheckBox ID="ck_r69" runat="server" /> ����ֲֿ��</td>
                <td><asp:CheckBox ID="ck_r7" runat="server" onclick="Chkpar(this,'ck_r8','ck_r9');"/> ������к�</td>
                <td><asp:CheckBox ID="ck_r8" runat="server" onclick="Chkson(this,'ck_r7');"/> ���к����</td>
                <td><asp:CheckBox ID="ck_r9" runat="server" onclick="Chkson(this,'ck_r7');"/> ���кų���</td>
                <td><asp:CheckBox ID="ck_r10" runat="server" onclick="Chkson(this,'ck_r7');"/> ��ӡ���к�</td>

                
            </tr>  
            <tr>
                <td><asp:CheckBox ID="ck_r11" runat="server" /> �������</td>
                            <td><asp:CheckBox ID="ck_r12" runat="server" onclick="Chkpar(this,'ck_r15','ck_r16');"/> �����ⵥ</td>
                <td><asp:CheckBox ID="ck_r13" runat="server" onclick="Chkson(this,'ck_r12');"/> �����ⵥ</td>
                <td><asp:CheckBox ID="ck_r14" runat="server" onclick="Chkson(this,'ck_r12');"/> �������ⵥ</td>
                <td><asp:CheckBox ID="ck_r15" runat="server" onclick="Chkson(this,'ck_r12');"/> �༭��ⵥ</td>
                <td><asp:CheckBox ID="ck_r16" runat="server" onclick="Chkson(this,'ck_r12');"/> ɾ����ⵥ</td>

                
            </tr>
            <tr>
                <td><asp:CheckBox ID="ck_r17" runat="server" onclick="Chkson(this,'ck_r12');"/> ������ⵥ</td>
                            <td><asp:CheckBox ID="ck_r18" runat="server" onclick="Chkson(this,'ck_r12');"/> ��ӡ��ⵥ</td>
                <td><asp:CheckBox ID="ck_r19" runat="server" /> ��������</td>
                <td><asp:CheckBox ID="ck_r20" runat="server" onclick="Chkpar(this,'ck_r23','ck_r24');"/> ������ⵥ</td>
                <td><asp:CheckBox ID="ck_r21" runat="server" onclick="Chkson(this,'ck_r20');"/> ��˳��ⵥ</td>
                <td><asp:CheckBox ID="ck_r22" runat="server" onclick="Chkson(this,'ck_r20');"/> ����˳��ⵥ</td>

                
            </tr>
            <tr>
                <td><asp:CheckBox ID="ck_r23" runat="server" onclick="Chkson(this,'ck_r20');"/> �༭���ⵥ</td>
                <td><asp:CheckBox ID="ck_r24" runat="server" onclick="Chkson(this,'ck_r20');"/> ɾ�����ⵥ</td>
                <td><asp:CheckBox ID="ck_r25" runat="server" onclick="Chkson(this,'ck_r20');"/> �������ⵥ</td>
                <td><asp:CheckBox ID="ck_r26" runat="server" onclick="Chkson(this,'ck_r20');"/> ��ӡ���ⵥ</td>
                <td><asp:CheckBox ID="ck_r27" runat="server" /> ���˿���</td>
                <td><asp:CheckBox ID="ck_r28" runat="server" onclick="Chkpar(this,'ck_r31','ck_r32');"/> ������˵�</td>

                
            </tr>
            <tr>
                <td><asp:CheckBox ID="ck_r29" runat="server" onclick="Chkson(this,'ck_r28');" /> ������˵�</td>
                <td><asp:CheckBox ID="ck_r30" runat="server" onclick="Chkson(this,'ck_r28');" /> ��������˵�</td>
                <td><asp:CheckBox ID="ck_r31" runat="server" onclick="Chkson(this,'ck_r28');" /> �༭���˵�</td>
                <td><asp:CheckBox ID="ck_r32" runat="server" onclick="Chkson(this,'ck_r28');" /> ɾ�����˵�</td>
                <td><asp:CheckBox ID="ck_r33" runat="server" onclick="Chkson(this,'ck_r28');" /> �������˵�</td>
                <td><asp:CheckBox ID="ck_r34" runat="server" onclick="Chkson(this,'ck_r28');" /> ��ӡ���˵�</td>

                
            </tr>
            <tr>
                <td><asp:CheckBox ID="ck_r35" runat="server" /> ��������</td>
                <td><asp:CheckBox ID="ck_r36" runat="server" onclick="Chkpar(this,'ck_r37','ck_r43');"/> ���������</td>
                <td><asp:CheckBox ID="ck_r37" runat="server" onclick="Chkson(this,'ck_r36');"/> �༭������</td>
                <td><asp:CheckBox ID="ck_r38" runat="server" /> ��˵�����</td>
                <td><asp:CheckBox ID="ck_r39" runat="server" /> ���ص�����</td>
                <td><asp:CheckBox ID="ck_r40" runat="server" /> ��������</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="ck_r41" runat="server" /> ����ǩ��</td>
                <td><asp:CheckBox ID="ck_r42" runat="server" onclick="Chkson(this,'ck_r36');"/> ɾ��������</td>
                <td><asp:CheckBox ID="ck_r43" runat="server" onclick="Chkson(this,'ck_r36');"/> ����������</td>
                <td><asp:CheckBox ID="ck_r44" runat="server" onclick="Chkson(this,'ck_r36');"/> ��ӡ������</td>
                <td><asp:CheckBox ID="ck_r45" runat="server" /> ��װ����</td>
                <td><asp:CheckBox ID="ck_r46" runat="server" onclick="Chkpar(this,'ck_r49','ck_r49');"/> �����װ��</td>

                
            </tr>
            <tr>
                <td><asp:CheckBox ID="ck_r47" runat="server" onclick="Chkson(this,'ck_r46');"/> ��˲�װ��</td>
                            <td><asp:CheckBox ID="ck_r48" runat="server" onclick="Chkson(this,'ck_r46');"/> ����˲�װ��</td>
                <td><asp:CheckBox ID="ck_r49" runat="server" onclick="Chkson(this,'ck_r46');"/> �༭��װ��</td>
                <td><asp:CheckBox ID="ck_r50" runat="server" onclick="Chkson(this,'ck_r46');"/> ɾ����װ��</td>
                <td><asp:CheckBox ID="ck_r51" runat="server" onclick="Chkson(this,'ck_r46');"/> ������װ��</td>
                <td><asp:CheckBox ID="ck_r52" runat="server" onclick="Chkson(this,'ck_r46');"/> ��ӡ��װ��</td>

                
            </tr>
            <tr>
                <td><asp:CheckBox ID="ck_r53" runat="server" /> ���ۿ���</td>
                            <td><asp:CheckBox ID="ck_r54" runat="server" onclick="Chkpar(this,'ck_r57','ck_r58');"/> ������۵�</td>
                <td><asp:CheckBox ID="ck_r55" runat="server" onclick="Chkson(this,'ck_r54');"/> ��˵��۵�</td>
                <td><asp:CheckBox ID="ck_r56" runat="server" onclick="Chkson(this,'ck_r54');"/> ����˵��۵�</td>
                <td><asp:CheckBox ID="ck_r57" runat="server" onclick="Chkson(this,'ck_r54');"/> �༭���۵�</td>
                <td><asp:CheckBox ID="ck_r58" runat="server" onclick="Chkson(this,'ck_r54');"/> ɾ�����۵�</td>

                
            </tr>
            <tr>
                <td><asp:CheckBox ID="ck_r59" runat="server" onclick="Chkson(this,'ck_r54');"/> �������۵�</td>
                <td><asp:CheckBox ID="ck_r60" runat="server" onclick="Chkson(this,'ck_r54');"/> ��ӡ���۵�</td>
                <td><asp:CheckBox ID="ck_r61" runat="server" /> �̵㿪��</td>
                <td><asp:CheckBox ID="ck_r62" runat="server" onclick="Chkpar(this,'ck_r65','ck_r66');"/> ����̵㵥</td>
                <td><asp:CheckBox ID="ck_r63" runat="server" onclick="Chkson(this,'ck_r62');"/> ����̵㵥</td>
                <td><asp:CheckBox ID="ck_r64" runat="server" onclick="Chkson(this,'ck_r62');"/> ������̵㵥</td>

            </tr>
            <tr>
                <td><asp:CheckBox ID="ck_r65" runat="server" onclick="Chkson(this,'ck_r62');"/> �༭�̵㵥</td>
                <td><asp:CheckBox ID="ck_r66" runat="server" onclick="Chkson(this,'ck_r62');"/> ɾ���̵㵥</td>
                <td><asp:CheckBox ID="ck_r67" runat="server" onclick="Chkson(this,'ck_r62');"/> �����̵㵥</td>
                <td><asp:CheckBox ID="ck_r68" runat="server" onclick="Chkson(this,'ck_r62');"/> ��ӡ�̵㵥</td>
                <td><asp:CheckBox ID="ck_r70" runat="server"/> �������</td>
                 <td><asp:CheckBox ID="ck_r71" runat="server"/> �黹���</td>
                

            </tr>

            <tr>
                <td><asp:CheckBox ID="ck_r72" runat="server"/> �����ѯ</td>
                <td><asp:CheckBox ID="ck_r80" runat="server"/> �ڲ���������</td>
                <td><asp:CheckBox ID="ck_r73" runat="server" /> ����ڲ�������</td>
                <td><asp:CheckBox ID="ck_r74" runat="server" /> ����ڲ�������</td>
                <td><asp:CheckBox ID="ck_r75" runat="server" /> �����ڲ�������</td>
                <td><asp:CheckBox ID="ck_r76" runat="server" /> �༭�ڲ�������</td>
                
                

            </tr>
            <tr>
                <td><asp:CheckBox ID="ck_r77" runat="server" /> ɾ���ڲ�������</td>
               <td><asp:CheckBox ID="ck_r78" runat="server" /> �����ڲ�������</td>
               <td><asp:CheckBox ID="ck_r79" runat="server" /> ��ӡ�ڲ�������</td>
               <td colspan="2"><asp:CheckBox ID="ck_r81" runat="server" /> �ڲ���������ֹ�޸ļ۸�</td>
               <td ><asp:CheckBox ID="ck_r82" runat="server" /> �ֲֿ����Ա����</td>
                
                

            </tr>
            <tr>
                <td ><asp:CheckBox ID="ck_r84" runat="server" /> ���۳��������</td>
                <td ><asp:CheckBox ID="ck_r86" runat="server" /> �ɹ���������</td>
                <td ><asp:CheckBox ID="ck_r85" runat="server" /> ��ֹ�鿴����</td>
                <td colspan="2"><asp:CheckBox ID="cb_ck_all" runat="server" onclick="Chkcb(this,'ck_r',86);" /> <span style="color:#000000">ȫѡ</span></td>
            </tr>
        </table>
    </div>
    </div>
    
    <div id="info2" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="div2" class="divinfo" style="height:406px; padding-left:5px;">
    <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:760px;">
      <legend>�ɹ�</legend>
       <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="cg_r1" runat="server" /> �ɹ�����</td>
                <td><asp:CheckBox ID="cg_r2" runat="server" /> �˻�����</td>
                <td><asp:CheckBox ID="cg_r3" runat="server" onclick="Chkpar(this,'cg_r4','cg_r5');"/> ����ɹ���</td>
                <td><asp:CheckBox ID="cg_r4" runat="server" onclick="Chkson(this,'cg_r3');"/> �༭�ɹ���</td>
                <td><asp:CheckBox ID="cg_r5" runat="server" onclick="Chkson(this,'cg_r3');"/> ��˲ɹ���</td>
                <td><asp:CheckBox ID="cg_r6" runat="server" onclick="Chkson(this,'cg_r3');"/> ����˲ɹ���</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="cg_r7" runat="server" onclick="Chkson(this,'cg_r3');"/> ɾ���ɹ���</td>
                <td><asp:CheckBox ID="cg_r8" runat="server" onclick="Chkson(this,'cg_r3');"/> �����ɹ���</td>
                <td><asp:CheckBox ID="cg_r9" runat="server" onclick="Chkson(this,'cg_r3');"/> ��ӡ�ɹ���</td>
                <td><asp:CheckBox ID="cg_r10" runat="server" /> �ɹ�����</td>
                <td><asp:CheckBox ID="cg_r11" runat="server" onclick="Chkpar(this,'cg_r12','cg_r13');"/> ����ɹ�����</td>
                <td><asp:CheckBox ID="cg_r12" runat="server" onclick="Chkson(this,'cg_r11');"/> �༭�ɹ�����</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="cg_r13" runat="server" onclick="Chkson(this,'cg_r11');"/> ��˲ɹ�����</td>
                <td><asp:CheckBox ID="cg_r14" runat="server" onclick="Chkson(this,'cg_r11');"/> ����˲ɹ�����</td>
                <td><asp:CheckBox ID="cg_r15" runat="server" onclick="Chkson(this,'cg_r11');"/> ɾ���ɹ�����</td>
                <td><asp:CheckBox ID="cg_r16" runat="server" onclick="Chkson(this,'cg_r11');"/> �����ɹ�����</td>
                <td><asp:CheckBox ID="cg_r17" runat="server" onclick="Chkson(this,'cg_r11');"/> ��ӡ�ɹ�����</td>
                <td><asp:CheckBox ID="cg_r18" runat="server"/> ҵ��Ա���Ÿ���</td>
            </tr>
            <tr>
                <td colspan="7"><asp:CheckBox ID="cb_cg_all" runat="server" onclick="Chkcb(this,'cg_r',18);"  /> <span style="color:#000000">ȫѡ</span></td>
            </tr>  
     </table>
     </fieldset>
     <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:760px;">
      <legend>����</legend>
    <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="xs_r1" runat="server" /> ���ۿ���</td>
                <td><asp:CheckBox ID="xs_r2" runat="server" /> �˻�����</td>
                <td><asp:CheckBox ID="xs_r3" runat="server" onclick="Chkpar(this,'xs_r4','xs_r5');"/> ������۵�</td>
                <td><asp:CheckBox ID="xs_r4" runat="server" onclick="Chkson(this,'xs_r3');"/> �༭���۵�</td>
                <td><asp:CheckBox ID="xs_r5" runat="server" onclick="Chkson(this,'xs_r3');"/> ������۵�</td>
                <td><asp:CheckBox ID="xs_r6" runat="server" onclick="Chkson(this,'xs_r3');"/> ��������۵�</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="xs_r7" runat="server" onclick="Chkson(this,'xs_r3');"/> ɾ�����۵�</td>
                <td><asp:CheckBox ID="xs_r8" runat="server" onclick="Chkson(this,'xs_r3');"/> �������۵�</td>
                <td><asp:CheckBox ID="xs_r9" runat="server" onclick="Chkson(this,'xs_r3');"/> ��ӡ���۵�</td>
                <td><asp:CheckBox ID="xs_r10" runat="server" /> ���۶���</td>
                <td><asp:CheckBox ID="xs_r11" runat="server" onclick="Chkpar(this,'xs_r12','xs_r13');"/> ������۶���</td>
                <td><asp:CheckBox ID="xs_r12" runat="server" onclick="Chkson(this,'xs_r11');"/> �༭���۶���</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="xs_r13" runat="server" onclick="Chkson(this,'xs_r11');"/> ������۶���</td>
                <td><asp:CheckBox ID="xs_r14" runat="server" onclick="Chkson(this,'xs_r11');"/> ��������۶���</td>
                <td><asp:CheckBox ID="xs_r18" runat="server" onclick="Chkson(this,'xs_r11');"/> ��ֹ���۶���</td>
                <td><asp:CheckBox ID="xs_r15" runat="server" onclick="Chkson(this,'xs_r11');"/> ɾ�����۶���</td>
                <td><asp:CheckBox ID="xs_r16" runat="server" onclick="Chkson(this,'xs_r11');"/> �������۶���</td>
                <td><asp:CheckBox ID="xs_r17" runat="server" onclick="Chkson(this,'xs_r11');"/> ��ӡ���۶���</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="xs_r19" runat="server"/> ҵ��Ա���Ÿ���</td>
                <td><asp:CheckBox ID="xs_r20" runat="server"/> ҵ��Ա����</td>
            </tr>
            <tr>
                <td colspan="7"><asp:CheckBox ID="cb_xs_all" runat="server" onclick="Chkcb(this,'xs_r',20);"  /> <span style="color:#000000">ȫѡ</span></td>
            </tr>  
     </table>
     </fieldset>
    </div>
    </div>
    
    <div id="info3" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="div4" class="divinfo" style="height:406px;">
        <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="gd_r1" runat="server" /> �������</td>
                <td><asp:CheckBox ID="gd_r2" runat="server" /> �������</td>
                <td><asp:CheckBox ID="gd_r3" runat="server" /> ����ȡ��</td>
                <td><asp:CheckBox ID="gd_r4" runat="server" /> ����ȷ��</td>
                <td><asp:CheckBox ID="gd_r5" runat="server" /> ���޲���</td>
                <td><asp:CheckBox ID="gd_r6" runat="server" /> ��������</td>
                
            </tr>
            <tr>
                <td><asp:CheckBox ID="gd_r7" runat="server" /> ��������</td>
                <td><asp:CheckBox ID="gd_r8" runat="server" /> �༭����</td>
                <td><asp:CheckBox ID="gd_r9" runat="server" /> ά�޴���</td>
                <td><asp:CheckBox ID="gd_r22" runat="server" /> ���񱨼�</td>
                <td><asp:CheckBox ID="gd_r10" runat="server" /> ���޷���</td>
                <td><asp:CheckBox ID="gd_r11" runat="server" /> �ջ�����</td>
                
            </tr>
            <tr>
                <td><asp:CheckBox ID="gd_r12" runat="server" /> ��ʷ����</td>
                <td><asp:CheckBox ID="gd_r13" runat="server" /> �깤����</td>
                <td><asp:CheckBox ID="gd_r14" runat="server" /> ��˹ر�</td>
                <td><asp:CheckBox ID="gd_r34" runat="server" /> ��˹رղ���</td>
                <td><asp:CheckBox ID="gd_r21" runat="server" /> ����ط�</td>
                <td><asp:CheckBox ID="gd_r15" runat="server" /> ���񵥲�ѯ</td>
                
                
                
            </tr>
            <tr>
                <td><asp:CheckBox ID="gd_r16" runat="server" /> ɾ������</td>
                <td><asp:CheckBox ID="gd_r23" runat="server" /> ȡ������</td>
                <td><asp:CheckBox ID="gd_r17" runat="server" /> ��������</td>
                <td><asp:CheckBox ID="gd_r18" runat="server" /> ��ӡ����</td>

                <td><asp:CheckBox ID="gd_r19" runat="server" /> �깤���㲵��</td>
                <td><asp:CheckBox ID="gd_r20" runat="server" /> ����Ա����</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="gd_r36" runat="server" /> ����Ա���Ÿ���</td>
                <td><asp:CheckBox ID="gd_r24" runat="server" /> �������</td>
                <td><asp:CheckBox ID="gd_r25" runat="server"/> ҵ��Ա���Ÿ���</td>
                <td><asp:CheckBox ID="gd_r27" runat="server"/> �����˲��Ÿ���</td>
                <td><asp:CheckBox ID="gd_r26" runat="server"/> ��ֹ�޸���Ŀ���</td>
                <td><asp:CheckBox ID="gd_r28" runat="server"/> ��ֹ�ɸ�����</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="gd_r29" runat="server"/> ��ֹί������</td>
                <td><asp:CheckBox ID="gd_r30" runat="server"/> ��ֹ��ɹر�</td>
                <td><asp:CheckBox ID="gd_r31" runat="server"/> ��ֹ�鿴��Ŀ���</td>

                <td colspan="3"><asp:CheckBox ID="gd_r32" runat="server"/> ��ֹ�鿴�����շѽ�����</td>
                
            </tr>
            <tr>
                <td colspan="2"><asp:CheckBox ID="gd_r35" runat="server"/> ��ֹ�޸ķ�������ʱ��</td>
                <td colspan="2"><asp:CheckBox ID="gd_r33" runat="server"/> ��ֹ�鿴��˹ر������ϸ</td>
             </tr>
            <tr>
                <td colspan="7"><asp:CheckBox ID="cb_gd_all" runat="server" onclick="Chkcb(this,'gd_r',36);"  /> <span style="color:#000000">ȫѡ</span></td>
            </tr>  
     </table>
    
    </div>
    </div>
    
    <div id="info4" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="div6" class="divinfo" style="height:406px;">
        <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="zl_r1" runat="server" /> �½�ҵ��</td>
                <td><asp:CheckBox ID="zl_r21" runat="server" /> ���ҵ�����</td>
                <td><asp:CheckBox ID="zl_r22" runat="server" /> ���ҵ��</td>
                <td><asp:CheckBox ID="zl_r23" runat="server" /> �����ҵ��</td>
                <td><asp:CheckBox ID="zl_r2" runat="server" /> �������Ǽ�</td>
                <td><asp:CheckBox ID="zl_r3" runat="server" onclick="Chkson(this,'zl_r2');"/> ����Ǽ�</td>
                <td><asp:CheckBox ID="zl_r15" runat="server" /> �޸ĳ���</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="zl_r16" runat="server" /> ɾ������</td>
                <td><asp:CheckBox ID="zl_r4" runat="server" /> ���㿪��</td>
                <td><asp:CheckBox ID="zl_r5" runat="server"/> ����豸�˻�</td>
                <td><asp:CheckBox ID="zl_r6" runat="server" onclick="Chkson(this,'zl_r5');"/> �豸�˻�</td>
                <td><asp:CheckBox ID="zl_r7" runat="server" /> �����ͬ��Լ</td>
                <td><asp:CheckBox ID="zl_r8" runat="server" onclick="Chkson(this,'zl_r7');"/> ��ͬ��Լ</td>
                <td><asp:CheckBox ID="zl_r9" runat="server" onclick="Chkpar(this,'zl_r10','zl_r11');"/> ����������</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="zl_r10" runat="server" onclick="Chkson(this,'zl_r9');"/> �������</td>
                <td><asp:CheckBox ID="zl_r11" runat="server" onclick="Chkson(this,'zl_r9');"/> ����ȡ��</td>
                <td><asp:CheckBox ID="zl_r12" runat="server"/> ҵ���ѯ</td>
                <td><asp:CheckBox ID="zl_r13" runat="server"/> ����ҵ��</td>
                <td><asp:CheckBox ID="zl_r14" runat="server"/> �޸�ҵ��</td>
                <td><asp:CheckBox ID="zl_r17" runat="server"/> ��ӡҵ��</td>
                <td><asp:CheckBox ID="zl_r18" runat="server"/> ��ӡ���㵥</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="zl_r19" runat="server"/> ȡ��ҵ��</td>
                <td><asp:CheckBox ID="zl_r20" runat="server"/> ɾ��ҵ��</td>
                <td><asp:CheckBox ID="zl_r24" runat="server"/> ��������㵥</td>
                <td><asp:CheckBox ID="zl_r25" runat="server"/> ɾ�����㵥</td>
                <td><asp:CheckBox ID="zl_r26" runat="server"/> ҵ��Ա���Ÿ���</td>
                <td><asp:CheckBox ID="zl_r27" runat="server"/> �����ɵ�</td>
            </tr>
            <tr>
                <td colspan="7"><asp:CheckBox ID="cb_zl_all" runat="server" onclick="Chkcb(this,'zl_r',27);"  /> <span style="color:#000000">ȫѡ</span></td>
            </tr>   
     </table>
    </div>
    </div>

    <div id="info5" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="div8" class="divinfo" style="height:406px;">
        <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="kh_r1" runat="server" /> �༭�ͻ�����</td>
                <td><asp:CheckBox ID="kh_r19" runat="server" /> �༭��Ա����</td>
                <td><asp:CheckBox ID="kh_r2" runat="server" onclick="Chkpar(this,'kh_r3','kh_r4');"/> ����ͻ�</td>
                <td><asp:CheckBox ID="kh_r3" runat="server" onclick="Chkson(this,'kh_r2');"/> ��ӿͻ�</td>
                <td><asp:CheckBox ID="kh_r4" runat="server" onclick="Chkson(this,'kh_r2');"/> �༭�ͻ�</td>
                <td><asp:CheckBox ID="kh_r32" runat="server" onclick="Chkson(this,'kh_r2');"/> ���ɿͻ�</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="kh_r5" runat="server" onclick="Chkson(this,'kh_r2');"/> �����ͻ�</td>
                <td><asp:CheckBox ID="kh_r6" runat="server" onclick="Chkpar(this,'kh_r7','kh_r8');"/> �����������</td>
                <td><asp:CheckBox ID="kh_r7" runat="server" onclick="Chkson(this,'kh_r6');"/> ��ӻ�������</td>
                <td><asp:CheckBox ID="kh_r8" runat="server" onclick="Chkson(this,'kh_r6');"/> �༭��������</td>
                <td><asp:CheckBox ID="kh_r9" runat="server" onclick="Chkson(this,'kh_r6');"/> ������������</td>
                <td><asp:CheckBox ID="kh_r34" runat="server" onclick="Chkson(this,'kh_r6');"/> ������������Ա����</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="kh_r20" runat="server" /> ��������ͬ</td>
                <td><asp:CheckBox ID="kh_r21" runat="server" /> �½������ͬ</td>
                <td><asp:CheckBox ID="kh_r22" runat="server" /> �޸ķ����ͬ</td>
                <td><asp:CheckBox ID="kh_r23" runat="server" /> ɾ�������ͬ</td>
                <td><asp:CheckBox ID="kh_r24" runat="server" /> ��ֹ�����ͬ</td>
                <td><asp:CheckBox ID="kh_r10" runat="server" /> �����ɹ�</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="kh_r11" runat="server" /> �Ĳĸ���</td>
                <td><asp:CheckBox ID="kh_r12" runat="server" /> ���޻�Ա����</td>
                <td><asp:CheckBox ID="kh_r13" runat="server" onclick="Chkpar(this,'kh_r14','kh_r15');" /> �ͻ�����</td>
                <td><asp:CheckBox ID="kh_r14" runat="server" onclick="Chkson(this,'kh_r13');"/> �½�����</td>
                <td><asp:CheckBox ID="kh_r15" runat="server" onclick="Chkson(this,'kh_r13');"/> �޸ĸ���</td>
                <td><asp:CheckBox ID="kh_r16" runat="server" onclick="Chkson(this,'kh_r13');"/> ɾ������</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="kh_r17" runat="server" /> Ͷ�߹���</td>
                <td><asp:CheckBox ID="kh_r25" runat="server" onclick="Chkson(this,'kh_r17');"/> Ͷ������</td>
                <td><asp:CheckBox ID="kh_r26" runat="server" onclick="Chkson(this,'kh_r17');"/> �޸�Ͷ��</td>
                <td><asp:CheckBox ID="kh_r27" runat="server" onclick="Chkson(this,'kh_r17');"/> Ͷ�ߴ���</td>
                <td><asp:CheckBox ID="kh_r28" runat="server" onclick="Chkson(this,'kh_r17');"/> Ͷ��ȡ��</td>
                
                <td><asp:CheckBox ID="kh_r18" runat="server" /> �������</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="kh_r29" runat="server" /> ҵ��Ա����</td>
                <td><asp:CheckBox ID="kh_r30" runat="server" /> �����˸���</td>
                <td colspan="2"><asp:CheckBox ID="kh_r31" runat="server" /> ��ֹ�鿴���˸�����Ϣ</td>
                <td colspan="2"><asp:CheckBox ID="kh_r33" runat="server" /> ��ֹ��ʷ�����˲鿴</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="kh_r35" runat="server"/> ҵ��Ա���Ÿ���</td>
            </tr>
            <tr>
                <td colspan="7"><asp:CheckBox ID="cb_kh_all" runat="server" onclick="Chkcb(this,'kh_r',35);"  /> <span style="color:#000000">ȫѡ</span></td>
            </tr>
        </table>
    </div>
    </div>
    
    <div id="info6" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="div10" class="divinfo" style="height:406px;">
        <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="zk_r1" runat="server" /> ��Ӧ�տ�</td>
                <td><asp:CheckBox ID="zk_r2" runat="server" /> ��Ԥ�տ�</td>
                <td><asp:CheckBox ID="zk_r3" runat="server" /> �����տ�</td>
                <td><asp:CheckBox ID="zk_r4" runat="server" /> ��Ӧ����</td>
                <td><asp:CheckBox ID="zk_r5" runat="server" /> ��Ԥ����</td>
                <td><asp:CheckBox ID="zk_r6" runat="server" /> ��������</td>
                <td><asp:CheckBox ID="zk_r7" runat="server" /> ����ո���</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="zk_r8" runat="server" /> �༭�ո���</td>
                <td><asp:CheckBox ID="zk_r9" runat="server" /> ����ո���</td>
                <td><asp:CheckBox ID="zk_r10" runat="server" /> ������ո���</td>
                <td><asp:CheckBox ID="zk_r11" runat="server" /> �����ո���</td>
                <td><asp:CheckBox ID="zk_r12" runat="server" /> �����ո���</td>
                <td><asp:CheckBox ID="zk_r13" runat="server" /> ��ӡ�ո���</td>
                <td><asp:CheckBox ID="zk_r14" runat="server" /> ���Ӧ��Ӧ��</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="zk_r15" runat="server" /> �༭Ӧ��Ӧ��</td>
                <td><asp:CheckBox ID="zk_r16" runat="server" /> ����Ӧ��Ӧ��</td>
                <td><asp:CheckBox ID="zk_r17" runat="server" /> �ʻ�ת��</td>
                <td><asp:CheckBox ID="zk_r18" runat="server" /> �ʻ�����</td>
                <td><asp:CheckBox ID="zk_r19" runat="server" /> ��������</td>
                <td><asp:CheckBox ID="zk_r20" runat="server" /> �������</td>
                <td><asp:CheckBox ID="zk_r21" runat="server" /> �����</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="zk_r22" runat="server" /> ������ѯ</td>
                <td><asp:CheckBox ID="zk_r23" runat="server" /> �޸ı���</td>
                <td><asp:CheckBox ID="zk_r24" runat="server" /> ������ϸ</td>
            </tr>
            <tr>
                <td colspan="7"><asp:CheckBox ID="cb_zk_all" runat="server" onclick="Chkcb(this,'zk_r',24);"  /> <span style="color:#000000">ȫѡ</span></td>
            </tr>  
        </table>
    
    </div>
    </div>
    
    <div id="info7" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="div12" class="divinfo" style="height:406px;">
        <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="fh_r1" runat="server" /> �½�����</td>
                <td><asp:CheckBox ID="fh_r2" runat="server" /> ����ȷ��</td>
                <td><asp:CheckBox ID="fh_r3" runat="server" /> ǩ��ȷ��</td>
                <td><asp:CheckBox ID="fh_r4" runat="server" /> ��������ѯ</td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td colspan="7"><asp:CheckBox ID="cb_fh_all" runat="server" onclick="Chkcb(this,'fh_r',4);"  /> <span style="color:#000000">ȫѡ</span></td>
            </tr>
        </table>
    </div>
    </div>
    
    <div id="info8" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="div14" class="divinfo" style="height:406px;">
        <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="bg_r1" runat="server" /> �༭�ĵ�����</td>
                <td><asp:CheckBox ID="bg_r2" runat="server" onclick="Chkpar(this,'bg_r3','bg_r4');"/> ����ĵ�</td>
                <td><asp:CheckBox ID="bg_r3" runat="server" onclick="Chkson(this,'bg_r2');"/> �½��ĵ�</td>
                <td><asp:CheckBox ID="bg_r4" runat="server" onclick="Chkson(this,'bg_r2');"/> �༭�ĵ�</td>
                <td><asp:CheckBox ID="bg_r5" runat="server" onclick="Chkpar(this,'bg_r6','bg_r7');"/> �������</td>
                <td><asp:CheckBox ID="bg_r6" runat="server" onclick="Chkson(this,'bg_r5');"/> �½�����</td>
                <td><asp:CheckBox ID="bg_r7" runat="server" onclick="Chkson(this,'bg_r5');"/> �༭����</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="bg_r8" runat="server" /> վ���ż�</td>
                <td><asp:CheckBox ID="bg_r9" runat="server" /> �༭֪ʶ����</td>
                <td><asp:CheckBox ID="bg_r10" runat="server" onclick="Chkpar(this,'bg_r11','bg_r12');" /> ���֪ʶ</td>
                <td><asp:CheckBox ID="bg_r11" runat="server" onclick="Chkson(this,'bg_r10');" /> �½�֪ʶ</td>
                <td><asp:CheckBox ID="bg_r12" runat="server" onclick="Chkson(this,'bg_r10');" /> �༭֪ʶ</td>
                <td><asp:CheckBox ID="bg_r13" runat="server"/> ����ǩ��</td>
                <td><asp:CheckBox ID="bg_r14" runat="server"/> ȱ�����</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="bg_r15" runat="server"/> ���ڻ���</td>
                <td><asp:CheckBox ID="bg_r16" runat="server"/> ���뿼����ϸ</td>
                <td><asp:CheckBox ID="bg_r17" runat="server"/> ��������</td>
                <td><asp:CheckBox ID="bg_r18" runat="server"/> �޸Ŀ�������</td>
                
                <td><asp:CheckBox ID="bg_r19" runat="server"/> �������</td>
                <td><asp:CheckBox ID="bg_r20" runat="server"/> �½�����</td>
                <td><asp:CheckBox ID="bg_r21" runat="server"/> �༭����</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="bg_r22" runat="server"/> ɾ������</td>
                <td><asp:CheckBox ID="bg_r23" runat="server"/> ִ������</td>
                <td><asp:CheckBox ID="bg_r24" runat="server"/> ��������</td>
                <td colspan="2"><asp:CheckBox ID="bg_r25" runat="server"/> ֻ����ִ����ִ��</td>
                <td colspan="2"><asp:CheckBox ID="bg_r26" runat="server"/> ֻ������������</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="bg_r27" runat="server"/> Ա�������ϸ</td>
                <td><asp:CheckBox ID="bg_r28" runat="server"/> �쳣������ϸ</td>
                <td><asp:CheckBox ID="bg_r29" runat="server"/> Ա���¶�н��</td>
                <td><asp:CheckBox ID="bg_r30" runat="server"/> Ա����������</td>
                <td><asp:CheckBox ID="bg_r31" runat="server"/> ��Ϣ�������</td>
                <td><asp:CheckBox ID="bg_r32" runat="server"/> Ա����ɸ���</td>
            </tr>
            <tr>
                <td colspan="7"><asp:CheckBox ID="cb_bg_all" runat="server" onclick="Chkcb(this,'bg_r',32);"  /> <span style="color:#000000">ȫѡ</span></td>
            </tr>  
        </table> 
    
    </div>
    </div>
    
    <div id="info9" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="div16" class="divinfo" style="height:406px;">
      <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="qc_r1" runat="server" /> �ڳ���Ʒ���</td>
                <td><asp:CheckBox ID="qc_r2" runat="server" /> �ͻ��ڳ�Ӧ��Ӧ��</td>
                <td><asp:CheckBox ID="qc_r3" runat="server" /> �����ڳ�Ӧ��Ӧ��</td>
                <td><asp:CheckBox ID="qc_r4" runat="server" /> �����ڳ�Ӧ��Ӧ��</td>
                <td><asp:CheckBox ID="qc_r5" runat="server" /> �ڳ��ֽ�����</td>
            </tr>
            <tr>
                <td colspan="5"><asp:CheckBox ID="cb_qc_all" runat="server" onclick="Chkcb(this,'qc_r',5);"  /> <span style="color:#000000">ȫѡ</span></td>
            </tr>
      </table>
    </div>
    </div>
    
    <div id="info10" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="div18" class="divinfo" style="height:406px;">
        <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="tj_r1" runat="server" /> ��Ӫҵ����ܱ�</td>
                <td><asp:CheckBox ID="tj_r2" runat="server" /> ��Ӫҵ����ܱ�</td>
                <td><asp:CheckBox ID="tj_r3" runat="server" /> �ֿ��ձ���</td>
                <td><asp:CheckBox ID="tj_r4" runat="server" /> �ֿ���ܱ�</td>
                <td><asp:CheckBox ID="tj_r5" runat="server" /> ��Ʒ�����ܱ�</td>
                <td><asp:CheckBox ID="tj_r6" runat="server" /> �ֿ������ܱ�</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="tj_r7" runat="server" /> �����ϸ���ܱ�</td>
                <td><asp:CheckBox ID="tj_r8" runat="server" /> ��Ʒ������ܱ�</td>
                <td><asp:CheckBox ID="tj_r9" runat="server" /> �ֿ������ܱ�</td>
                <td><asp:CheckBox ID="tj_r10" runat="server" /> ������ϸ���ܱ�</td>
                <td><asp:CheckBox ID="tj_r11" runat="server" /> ��Ʒ���˻��ܱ�</td>
                <td><asp:CheckBox ID="tj_r12" runat="server" /> ���������˻��ܱ�</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="tj_r13" runat="server" /> �ɹ��ձ���</td>
                <td><asp:CheckBox ID="tj_r14" runat="server" /> ��Ʒ�ɹ����ܱ�</td>
                <td><asp:CheckBox ID="tj_r15" runat="server" /> ��Ӧ�̲ɹ����ܱ�</td>
                <td><asp:CheckBox ID="tj_r16" runat="server" /> �ɹ���ϸ���ܱ�</td>
                <td><asp:CheckBox ID="tj_r17" runat="server" /> ��Ʒ�˻����ܱ�</td>
                <td><asp:CheckBox ID="tj_r18" runat="server" /> ��Ӧ���˻����ܱ�</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="tj_r19" runat="server" /> �˻���ϸ���ܱ�</td>
                <td><asp:CheckBox ID="tj_r20" runat="server" /> �����ձ���</td>
                <td><asp:CheckBox ID="tj_r21" runat="server" /> �����±���</td>
                <td><asp:CheckBox ID="tj_r22" runat="server" /> ��Ʒ���ۻ��ܱ�</td>
                <td><asp:CheckBox ID="tj_r23" runat="server" /> �ͻ����ۻ��ܱ�</td>
                <td><asp:CheckBox ID="tj_r24" runat="server" /> ������ϸ���ܱ�</td>
                
            </tr>
            <tr>
                <td><asp:CheckBox ID="tj_r25" runat="server" /> ��Ʒ�˻����ܱ�</td>
                <td><asp:CheckBox ID="tj_r26" runat="server" /> �ͻ��˻����ܱ�</td>
                <td><asp:CheckBox ID="tj_r27" runat="server" /> �˻���ϸ���ܱ�</td>
                <td><asp:CheckBox ID="tj_r28" runat="server" /> �����ձ���</td>
                <td><asp:CheckBox ID="tj_r29" runat="server" /> �����±���</td>
                <td><asp:CheckBox ID="tj_r30" runat="server" /> ������ܱ�</td>
                
                
            </tr>
            <tr>
                <td><asp:CheckBox ID="tj_r31" runat="server" /> ������ϸ��</td>
                <td><asp:CheckBox ID="tj_r32" runat="server" /> ������Ŀ���ܱ�</td>
                <td><asp:CheckBox ID="tj_r33" runat="server" /> ������Ŀ��ϸ��</td>
                <td><asp:CheckBox ID="tj_r34" runat="server" /> ���񵥸���</td>
                <td><asp:CheckBox ID="tj_r35" runat="server" /> ���񵥷ֲ�</td>
                <td><asp:CheckBox ID="tj_r36" runat="server" /> ����Աҵ��</td>
                
            </tr>
            <tr>
                <td><asp:CheckBox ID="tj_r37" runat="server" /> ���ڵ�ͳ��</td>
                <td><asp:CheckBox ID="tj_r38" runat="server" /> ���񵥵�ͼ</td>
                <td><asp:CheckBox ID="tj_r65" runat="server" /> ���񱸼����ܱ�</td>
                <td><asp:CheckBox ID="tj_r39" runat="server" /> ��Ʒ�ֲ�ͼ��</td>
                <td><asp:CheckBox ID="tj_r40" runat="server" /> ���Ϸֲ�ͼ��</td>
                <td><asp:CheckBox ID="tj_r66" runat="server" /> �����ʩ�ֲ�</td>
                
            </tr>
            <tr>
                <td><asp:CheckBox ID="tj_r41" runat="server" /> ��֧�ձ���</td>
                <td><asp:CheckBox ID="tj_r42" runat="server" /> ��֧�±���</td>
                <td><asp:CheckBox ID="tj_r43" runat="server" /> �տ���ܱ�</td>
                <td><asp:CheckBox ID="tj_r44" runat="server" /> �տ��ϸ��</td>
                <td><asp:CheckBox ID="tj_r45" runat="server" /> ������ܱ�</td>
                <td><asp:CheckBox ID="tj_r46" runat="server" /> �����ϸ��</td>
                
                
            </tr>
            <tr>
                <td><asp:CheckBox ID="tj_r47" runat="server" /> Ӧ��Ӧ�����ܱ�</td>
                <td><asp:CheckBox ID="tj_r48" runat="server" /> Ӧ��Ӧ����ϸ��</td>
                <td><asp:CheckBox ID="tj_r49" runat="server" /> Ӧ��Ӧ�������</td>
                <td><asp:CheckBox ID="tj_r50" runat="server" /> Ӧ��Ӧ�����ʱ�</td>
                <td><asp:CheckBox ID="tj_r51" runat="server" /> ���㵥���ܱ�</td>
                <td><asp:CheckBox ID="tj_r52" runat="server" /> ���㵥��ϸ��</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="tj_r53" runat="server" /> �ͻ��������</td>
                <td><asp:CheckBox ID="tj_r54" runat="server" /> �ͻ���ֵ����</td>
                <td><asp:CheckBox ID="tj_r55" runat="server" /> ҵ�����Ʒ���</td>
                <td><asp:CheckBox ID="tj_r56" runat="server" /> �������ȷ���</td>
                <td><asp:CheckBox ID="tj_r57" runat="server" /> �տʽ����</td>
                <td><asp:CheckBox ID="tj_r58" runat="server" /> ȡ��ԭ�����</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="tj_r59" runat="server" /> ����������</td>
                <td><asp:CheckBox ID="tj_r60" runat="server" /> ����ʽ����</td>
                <td><asp:CheckBox ID="tj_r61" runat="server" /> �ͻ���Դ����</td>
                <td><asp:CheckBox ID="tj_r62" runat="server" /> �ͻ�������</td>
                <td><asp:CheckBox ID="tj_r63" runat="server" /> ���޻��ܱ�</td>
                <td><asp:CheckBox ID="tj_r64" runat="server" /> �ظ�ά����</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="tj_r67" runat="server" /> ά����ͬ��ʱ��</td>
                <td><asp:CheckBox ID="tj_r68" runat="server" /> ά��ά�޳ɱ�</td>
                <td><asp:CheckBox ID="tj_r69" runat="server" /> ά������ɱ�</td>
                <td><asp:CheckBox ID="tj_r70" runat="server" /> ����ɱ�</td>
            </tr>
            <tr>
                <td colspan="5"><asp:CheckBox ID="cb_tj_all" runat="server" onclick="Chkcb(this,'tj_r',70);"  /> <span style="color:#000000">ȫѡ</span></td>
            </tr>
      </table>
    
    </div>
    </div>
    
    <div id="info11" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="div20" class="divinfo" style="height:406px;">
        <table cellpadding="0" cellspacing="0" class="tb6">
            <tr>
                <td><asp:CheckBox ID="jc_r1" runat="server" /> �༭������Ϣ</td>
                <td><asp:CheckBox ID="jc_r2" runat="server" onclick="Chkpar(this,'jc_r3','jc_r4');"/> �������</td>
                <td><asp:CheckBox ID="jc_r3" runat="server" onclick="Chkson(this,'jc_r2');" /> �½�����</td>
                <td><asp:CheckBox ID="jc_r4" runat="server" onclick="Chkson(this,'jc_r2');"/> �༭����</td>
                <td><asp:CheckBox ID="jc_r5" runat="server" onclick="Chkpar(this,'jc_r6','jc_r7');" /> ���Ա��</td>
                <td><asp:CheckBox ID="jc_r6" runat="server" onclick="Chkson(this,'jc_r5');" /> �½�Ա��</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="jc_r7" runat="server" onclick="Chkson(this,'jc_r5');"/> �༭Ա��</td>
                <td><asp:CheckBox ID="jc_r8" runat="server" /> �༭�ֿ�Ŀ¼</td>
                
                <td><asp:CheckBox ID="jc_r31" runat="server" /> �༭���̷���</td>
                <td><asp:CheckBox ID="jc_r32" runat="server" onclick="Chkpar(this,'kh_r33','kh_r34');"/> �������</td>
                <td><asp:CheckBox ID="jc_r33" runat="server" onclick="Chkson(this,'kh_r32');"/> ��ӳ���</td>
                <td><asp:CheckBox ID="jc_r34" runat="server" onclick="Chkson(this,'kh_r32');"/> �༭����</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="jc_r35" runat="server" onclick="Chkson(this,'kh_r32');"/> ��������</td>
                <td><asp:CheckBox ID="jc_r9" runat="server" /> �༭����Ʒ��</td>
                <td><asp:CheckBox ID="jc_r10" runat="server" /> �༭�������</td>
                <td><asp:CheckBox ID="jc_r11" runat="server" /> �༭�����ͺ�</td>
                <td><asp:CheckBox ID="jc_r12" runat="server" /> �༭�������</td>
                <td><asp:CheckBox ID="jc_r13" runat="server" /> �༭�������</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="jc_r29" runat="server" /> �༭���񼶱�</td>
                <td><asp:CheckBox ID="jc_r30" runat="server" /> �༭������Ŀ</td>
                <td><asp:CheckBox ID="jc_r14" runat="server" /> �༭ά�����</td>
                <td><asp:CheckBox ID="jc_r15" runat="server" /> �༭���Ϸ���</td>
                <td><asp:CheckBox ID="jc_r16" runat="server" /> �༭����ԭ��</td>
                <td><asp:CheckBox ID="jc_r17" runat="server" /> �༭��������</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="jc_r18" runat="server" /> �༭������Ŀ</td>
                <td><asp:CheckBox ID="jc_r19" runat="server" /> �༭��Ʒȥ��</td>
                <td><asp:CheckBox ID="jc_r20" runat="server" /> �༭�ط�����</td>
                <td><asp:CheckBox ID="jc_r21" runat="server" /> �༭����������</td>
                <td><asp:CheckBox ID="jc_r22" runat="server" /> �༭���ڵ�����</td>
                <td><asp:CheckBox ID="jc_r23" runat="server" /> �༭��֧�ʻ�</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="jc_r24" runat="server" /> �༭��֧��Ŀ</td>
                <td><asp:CheckBox ID="jc_r25" runat="server" /> �༭������Ŀ</td>
                <td><asp:CheckBox ID="jc_r26" runat="server" /> �༭���˷�ʽ</td>
                <td><asp:CheckBox ID="jc_r27" runat="server" /> ��ֹ�鿴������</td>
                <td><asp:CheckBox ID="jc_r28" runat="server" /> ��ֹ�鿴��Ӧ��</td>
                <td><asp:CheckBox ID="jc_r36" runat="server" /> ��ֹ�鿴�ɱ�����</td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="jc_r37" runat="server" /> ������ͼ۳���</td>
            </tr>
            <tr>
                <td colspan="6"><asp:CheckBox ID="cb_jc_all" runat="server" onclick="Chkcb(this,'jc_r',37);"  /> <span style="color:#000000">ȫѡ</span></td>
            </tr>  
        </table>
    
    </div>
    </div>
    
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td></td>
        <td align="right">
            <asp:CheckBox ID="cb_all" runat="server" onclick="Chkcball(this);" /><span style="color:#0000ff">ȫѡ</span>
            <asp:Button ID="btnSave" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnSave_Click" />
            <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog();"/>
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
        window.alert("����ʧ�ܣ�Ȩ����������Ϊ��");
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
