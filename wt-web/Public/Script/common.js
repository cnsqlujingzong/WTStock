document.onkeydown=function()
{
    if(event.keyCode==13 && event.srcElement.type!="button" && event.srcElement.type!="submit" && event.srcElement.type!="image" && event.srcElement.type!="reset" && event.srcElement.type!="textarea" && event.srcElement.type!="")
    {
        event.keyCode=9;
    }
    if(event.keyCode==27)   
    {
        try{parent.CloseDialog();}catch(e){}
    }
}

function $() 
{ 
    var elements = new Array(); 
    for (var i = 0; i < arguments.length; i++) 
    { 
        var element = arguments[i]; 
        if (typeof element == 'string') 
            element = document.getElementById(element); 
        if(arguments.length == 1) 
            return element; 
        elements.push(element); 
    } 
    return elements; 
}

//校验是否为空
function isNull(s) 
{ 
var patrn=/^\s*$/;
if(!patrn.exec(s)) return false;
return true;
} 

function EnterTextBoxSch(event, obj)
{
    if(event.keyCode == 13&&!isNull(obj.value))
    {
        if(!isNull(obj.value))
        {
            $("btnSch").click();
        }
    }
}

//标记颜色
function ClrID(id)
{
    var obj = document.getElementById(id);
    if(obj!=null){
    var oldObj = document.getElementById(document.getElementById("hfRecID").value);
    if(oldObj)
    {
        if(oldObj == obj)
        {
            if(obj.oldBackgroundColor == null || obj.oldBackgroundColor == undefined) 
            {
                obj.oldBackgroundColor = obj.style.backgroundColor;
                obj.oldColor = obj.style.color;
            }
            obj.style.backgroundColor="#0054E3";
            obj.style.color="#fff";
            return;
        }
        oldObj.style.backgroundColor = oldObj.oldBackgroundColor;
        oldObj.style.color = oldObj.oldColor;
    }
        
    // 把原先的颜色保存在自己的属性中316AC5
    obj.oldBackgroundColor = obj.style.backgroundColor;
    obj.oldColor = obj.style.color;
    
    obj.style.backgroundColor="#0054E3";
    obj.style.color="#fff";
    document.getElementById("hfRecID").value = id;
    }
}

//表头排序
function HeaderOrder(id,headername)
{
    if(document.getElementById("hfOrder").value=="Desc"||document.getElementById("hfOrder").value=="")
       document.getElementById("hfOrder").value="Asc";
    else
       document.getElementById("hfOrder").value="Desc";
        
       document.getElementById("hfOrderName").value = id;
       document.getElementById("hfOrderTitle").value = headername;        
       document.getElementById("btnOrder").click();
}

//标记表头排序颜色
function ClrHeaderOrder(id)
{
    //标记第一列的颜色
    var objh = document.getElementById(id);
    if(objh!=null){
    var oldObjh = document.getElementById(document.getElementById("hfOrderName").value);
    if(oldObjh)
    {
        if(oldObjh == objh)
        {
            if(objh.oldBackgroundColor == null || objh.oldBackgroundColor == undefined) 
            {
                objh.oldBackgroundColor = objh.style.backgroundColor;
                objh.oldColor = objh.style.color;
            }
            objh.style.backgroundColor="#D2D2C2";
            objh.style.color="#000000";
            
        }
        oldObjh.style.backgroundColor = oldObjh.oldBackgroundColor;
        oldObjh.style.color = oldObjh.oldColor;
    }
    
    // 把原先的颜色保存在自己的属性中
    objh.oldBackgroundColor = objh.style.backgroundColor;
    objh.oldColor = objh.style.color;
    objh.style.backgroundColor="#D2D2C2";
    objh.style.color="#000000";
    
    if(document.getElementById("hfOrder").value=="Desc")
       objh.innerHTML=document.getElementById("hfOrderTitle").value+"&nbsp;<img src='../../Public/Images/arrowdown.gif' />";
    else
       objh.innerHTML=document.getElementById("hfOrderTitle").value+"&nbsp;<img src='../../Public/Images/arrowup.gif' />";
    }
}

//标记基础信息颜色
function ClrBaseID(id)
{
    //标记第一列的颜色
    var objt = document.getElementById("t"+id);
    if(objt!=null){
    var oldObjt = document.getElementById("t"+document.getElementById("hfRecID").value);
    if(oldObjt)
    {
        if(oldObjt == objt)
        {
            if(objt.oldBackgroundColor == null || objt.oldBackgroundColor == undefined) 
            {
                objt.oldBackgroundColor = objt.style.backgroundColor;
                objt.oldColor = objt.style.color;
            }
            objt.style.backgroundColor="#D2D2C2";
            objt.style.color="#000000";
        }
        oldObjt.style.backgroundColor = oldObjt.oldBackgroundColor;
        oldObjt.style.color = oldObjt.oldColor;
    }
        
    // 把原先的颜色保存在自己的属性中
    objt.oldBackgroundColor = objt.style.backgroundColor;
    objt.oldColor = objt.style.color;
    objt.style.backgroundColor="#D2D2C2";
    objt.style.color="#000000";
    }
    
    //标记行的颜色
    var obj = document.getElementById(id);
    if(obj!=null){
    var oldObj = document.getElementById(document.getElementById("hfRecID").value);
    if(oldObj)
    {
        if(oldObj == obj)
        {
            if(obj.oldBackgroundColor == null || obj.oldBackgroundColor == undefined) 
            {
                obj.oldBackgroundColor = obj.style.backgroundColor;
                obj.oldColor = obj.style.color;
            }
            obj.style.backgroundColor="#0054E3";
            obj.style.color="#fff";
            return;
        }
        oldObj.style.backgroundColor = oldObj.oldBackgroundColor;
        oldObj.style.color = oldObj.oldColor;
    }
        
    // 把原先的颜色保存在自己的属性中
    obj.oldBackgroundColor = obj.style.backgroundColor;
    obj.oldColor = obj.style.color;
        
    obj.style.backgroundColor="#0054E3";
    obj.style.color="#fff";
    document.getElementById("hfRecID").value = id;
    }
}

//标记颜色
function ClrID2(id)
{
    //标记第一列的颜色
    var objt = document.getElementById("t"+id);
    if(objt!=null){
    var oldObjt = document.getElementById("t"+document.getElementById("hfRecID2").value);
    if(oldObjt)
    {
        if(oldObjt == objt)
        {
            if(objt.oldBackgroundColor == null || objt.oldBackgroundColor == undefined) 
            {
                objt.oldBackgroundColor = objt.style.backgroundColor;
                objt.oldColor = objt.style.color;
            }
            objt.style.backgroundColor="#D2D2C2";
            objt.style.color="#000000";
        }
        oldObjt.style.backgroundColor = oldObjt.oldBackgroundColor;
        oldObjt.style.color = oldObjt.oldColor;
    }
        
    // 把原先的颜色保存在自己的属性中
    objt.oldBackgroundColor = objt.style.backgroundColor;
    objt.oldColor = objt.style.color;
    objt.style.backgroundColor="#D2D2C2";
    objt.style.color="#000000";
    }
    
    //标记行的颜色
    var obj = document.getElementById(id);
    if(obj!=null){
    var oldObj = document.getElementById(document.getElementById("hfRecID2").value);
    if(oldObj)
    {
        if(oldObj == obj)
        {
            if(obj.oldBackgroundColor == null || obj.oldBackgroundColor == undefined) 
            {
                obj.oldBackgroundColor = obj.style.backgroundColor;
                obj.oldColor = obj.style.color;
            }
            obj.style.backgroundColor="#0054E3";
            obj.style.color="#fff";
            return;
        }
        oldObj.style.backgroundColor = oldObj.oldBackgroundColor;
        oldObj.style.color = oldObj.oldColor;
    }

    // 把原先的颜色保存在自己的属性中
    obj.oldBackgroundColor = obj.style.backgroundColor;
    obj.oldColor = obj.style.color;
        
    obj.style.backgroundColor="#0054E3";
    obj.style.color="#fff";
    document.getElementById("hfRecID2").value = id;
    }
}

//标记颜色
function ClrID3(id)
{
    var obj = document.getElementById(id);
    if(obj!=null){
    var oldObj = document.getElementById(document.getElementById("hfRecID3").value);
    if(oldObj)
    {
        if(oldObj == obj)
        {
            if(obj.oldBackgroundColor == null || obj.oldBackgroundColor == undefined) 
            {
                obj.oldBackgroundColor = obj.style.backgroundColor;
                obj.oldColor = obj.style.color;
            }
            obj.style.backgroundColor="#0054E3";
            obj.style.color="#fff";
            return;
        }
        oldObj.style.backgroundColor = oldObj.oldBackgroundColor;
        oldObj.style.color = oldObj.oldColor;
    }
        
    // 把原先的颜色保存在自己的属性中
    obj.oldBackgroundColor = obj.style.backgroundColor;
    obj.oldColor = obj.style.color;
        
    obj.style.backgroundColor="#0054E3";
    obj.style.color="#fff";
    document.getElementById("hfRecID3").value = id;
    }
}

//标记基础信息颜色
function ClrBaseID3(id)
{
    //标记第一列的颜色
    var objt = document.getElementById("t"+id);
    if(objt!=null){
    var oldObjt = document.getElementById("t"+document.getElementById("hfRecID3").value);
    if(oldObjt)
    {
        if(oldObjt == objt)
        {
            if(objt.oldBackgroundColor == null || objt.oldBackgroundColor == undefined) 
            {
                objt.oldBackgroundColor = objt.style.backgroundColor;
                objt.oldColor = objt.style.color;
            }
            objt.style.backgroundColor="#D2D2C2";
            objt.style.color="#000000";
        }
        oldObjt.style.backgroundColor = oldObjt.oldBackgroundColor;
        oldObjt.style.color = oldObjt.oldColor;
    }
        
    // 把原先的颜色保存在自己的属性中
    objt.oldBackgroundColor = objt.style.backgroundColor;
    objt.oldColor = objt.style.color;
    objt.style.backgroundColor="#D2D2C2";
    objt.style.color="#000000";
    }
    
    //标记行的颜色
    var obj = document.getElementById(id);
    if(obj!=null){
    var oldObj = document.getElementById(document.getElementById("hfRecID3").value);
    if(oldObj)
    {
        if(oldObj == obj)
        {
            if(obj.oldBackgroundColor == null || obj.oldBackgroundColor == undefined) 
            {
                obj.oldBackgroundColor = obj.style.backgroundColor;
                obj.oldColor = obj.style.color;
            }
            obj.style.backgroundColor="#316AC5";
            obj.style.color="#fff";
            return;
        }
        oldObj.style.backgroundColor = oldObj.oldBackgroundColor;
        oldObj.style.color = oldObj.oldColor;
    }
        
    // 把原先的颜色保存在自己的属性中
    obj.oldBackgroundColor = obj.style.backgroundColor;
    obj.oldColor = obj.style.color;
        
    obj.style.backgroundColor="#316AC5";
    obj.style.color="#fff";
    document.getElementById("hfRecID3").value = id;
    }
}

//获取列ID
function ClrID4(id)
{
    var obj = document.getElementById(id);
    if(obj!=null){
    document.getElementById("hfRecID").value = id;
    }
}
//全部选中和全部取消选中
function allcb()
{
    $("hfreclist").value=$("hfreclist").value;
    var chkall= $("cball");
    var chkother= document.getElementsByTagName("input");
    var tr="";
    for (var i=0;i<chkother.length;i++)
    {
        if( chkother[i].type=='checkbox')
        {
            if(chkother[i].id!="cball"&&chkother[i].id!="undefinded" )
            {
                tr=chkother[i].id;
                tr=tr.replace("cb","");
            }
            if(chkall.checked==true)
            {
                chkother[i].checked=true;
                if(tr!=""){
                $("hfreclist").value=$("hfreclist").value+tr+",";
                $(tr).style.backgroundColor="#D6F1F8";}
            }
            else
            {
                chkother[i].checked=false;
                if(tr!=""){
                $("hfreclist").value=$("hfreclist").value.replace(tr+",","");
                $(tr).style.backgroundColor="";}
            }
        }
    }
    
    if($("hfRecID").value!="-1")
        ChkID($("hfRecID").value);
}

//全部选中和全部取消选中
function SltAllValue()
{
    $("hfcbID").value=$("hfcbID").value;
    var chkall= $("cball");
    var chkother= document.getElementsByTagName("input");
    var tr="";
    for (var i=0;i<chkother.length;i++)
    {
        if( chkother[i].type=='checkbox'&&(/\d+/).test(chkother[i].id))
        {
            if(chkother[i].id!="cball"&&chkother[i].id!="undefinded")
            {
                tr=chkother[i].id;
                tr=tr.replace("cb","");
            }
            if(chkall.checked==true)
            {
                chkother[i].checked=true;
                if(tr!=""){
                $("hfcbID").value=$("hfcbID").value+tr+",";
                }
            }
            else
            {
                chkother[i].checked=false;
                if(tr!=""){
                var strids=","+$("hfcbID").value.replace(/(^[,\s]*)|([,\s]*$)/g,"")+",";
                $("hfcbID").value=strids.replace(","+tr+",",",").replace(/(^[,\s]*)/g,"");
                }
            }
        }
    }
}
function SltValue(i,cb)
{
   if($(cb).checked)
    {
        $("hfcbID").value=$("hfcbID").value+i+",";
    }else
    {
        var strids=","+$("hfcbID").value.replace(/(^[,\s]*)|([,\s]*$)/g,"")+",";
        $("hfcbID").value=strids.replace(","+i+",",",").replace(/(^[,\s]*)/g,"");
    }
}

function SltVisitValue(i,m,rd)
{
    $("hfrdID").value=$("hfrdID").value+"|"+m+","+i;
}

function ChkSltValue()
{
    if(isNull($("hfcbID").value)&&$("hfRecID").value=="-1")
    {
        alert("请勾选记录后操作！");
        return false
    }
}
//单个选中
function cbone(obj)
{
    var tr=obj.id;
    tr=tr.replace("cb","");
    if(obj.checked)
    {
        $("hfreclist").value=$("hfreclist").value+tr+",";
        $(tr).style.backgroundColor="#D6F1F8";
    }else
    {
        $("hfreclist").value=$("hfreclist").value.replace(tr+",","");
        $(tr).style.backgroundColor="";
    }
}

//是否选择一条
function ChkSlt()
{
    if(document.getElementById("hfRecID").value=="-1")
    {
        window.alert("请选择一条记录后操作！");
        return false;
    }
}

//是否选择一条2
function ChkSlt2()
{
    if(document.getElementById("hfRecID2").value=="-1")
    {
        window.alert("请选择一条记录后操作！");
        return false;
    }
}

//是否选择一条3
function ChkSlt3()
{
    if(document.getElementById("hfRecID3").value=="-1")
    {
        window.alert("请选择一条记录后操作！");
        return false;
    }
}

//绘制div宽高
function Chkwh()
{
    var h1=document.body.clientHeight-54;//表格高度
    var w1=window.screen.availWidth;//屏幕可用工作区宽度
    var h2=153;//固定占用高度
    var w2=4;//滑条宽度
    $("cndiv").style.height=h1+"px";
    $("cndiv").style.width=w1-w2+"px";
}

//绘制div宽高
function Chkwhmap()
{
    var h1=document.body.clientHeight-54;//表格高度
    var w1=window.screen.availWidth;//屏幕可用工作区宽度
    var w2=4;//滑条宽度
    $("cndiv").style.height=h1+"px";
    $("cndiv").style.width=w1-w2+"px";
    
    $("divmap").style.height=h1+"px";
    $("divmap").style.width=w1-w2+"px";
}

function Chkwhv()
{
    var h1=document.body.clientHeight-54;//表格高度
    var w1=window.screen.availWidth;//屏幕可用工作区宽度
    var h2=153;//固定占用高度
    var w2=312;//滑条宽度
    $("cndiv").style.height=h1+"px";
    $("cndiv").style.width=w1-w2+"px";
    $("lncn").style.height=h1+"px";
    $("divright").style.height=h1+"px";
    $("divright").style.width="295px";
}
function Chkwhv2()
{
    var h1=document.body.clientHeight-54;//表格高度
    var w1=window.screen.availWidth;//屏幕可用工作区宽度
    var h2=150;//固定占用高度
    var w2=312;//滑条宽度
    $("cndiv").style.height=h1+"px";
    $("cndiv").style.width=w1-w2+"px";
    $("divtop").style.height=h1-h2+"px";
    $("divtop").style.width=w1-w2+"px";
    $("divbottom").style.height="150px";
    $("divbottom").style.width=w1-w2+"px";
    $("lncn").style.height=h1+"px";
    $("divright").style.height=h1+"px";
    $("divright").style.width="297px";
}
//绘制div宽高
function Chkwh2()
{
    var h1=document.body.clientHeight-224;//表格高度
    var w1=window.screen.availWidth;//屏幕可用工作区宽度
    var w2=4;//滑条宽度
    $("cndiv").style.height=h1+"px";
    $("cndiv").style.width=w1-w2+"px";
    $("cnbut").style.height="170px";
    $("cnbut").style.width=w1-w2+"px";
}

//绘制div宽高
function Chkwh3()
{
    var h1=document.body.clientHeight-54;//表格高度
    var w1=window.screen.availWidth;//屏幕可用工作区宽度
    var h2=150;//固定占用高度
    var w2=20+158;//滑条宽度
    $("lndiv").style.height=h1+"px";
    $("lncn").style.height=h1+"px";
    $("cndiv").style.height=h1+"px";
    $("cndiv").style.width=w1-w2+"px";
}

//绘制div宽高
function Chkwhcus()
{
    var h1=document.body.clientHeight-54;//表格高度
    var w1=window.screen.availWidth;//屏幕可用工作区宽度
    var h2=h1-200;//固定占用高度
    var w2=20+168;//滑条宽度
    $("lndiv").style.height=h1+"px";
    $("lncn").style.height=h1+"px";
    $("cndiv").style.height=h2+"px";
    $("cndiv").style.width=w1-w2+"px";
    $("cnbut").style.height="200px";
    $("cnbut").style.width=w1-w2+"px";
}

//绘制div宽高
function Chkwh4()
{
    var h1=document.body.clientHeight-54;//表格高度
    var w1=window.screen.availWidth;//屏幕可用工作区宽度
    var h2=153;//固定占用高度
    var w2=158+250+5;//滑条宽度
    $("lndiv").style.height=h1+"px";
    $("lncn").style.height=h1+"px";
    $("lncn2").style.height=h1+"px";
    $("cndivs").style.height=h1+"px";
    $("cndiv").style.height=h1+"px";
    $("cndiv").style.width=w1-w2+"px";
}

function Chkwh5()
{
    var h1=document.body.clientHeight-204;//表格高度
    var h2=h1-2;
    var h3=h1-4;
    $("cndiv").style.height=h1+"px";
    $("sdiv").style.height=h2+"px";
    $("fdiv").style.height=h3+"px";
    var w1=window.screen.availWidth;//屏幕可用工作区宽度
    $("cndiv").style.width=w1-4+"px";
    $("sdiv").style.width=w1-6+"px";
    $("fdiv").style.width=w1-8+"px";
}
function Chkwh6()
{
    var h1=document.body.clientHeight-73;//表格高度
    var w1=window.screen.availWidth;//屏幕可用工作区宽度
    var w2=14;//滑条宽度
    $("cndiv").style.height=h1+"px";
    $("cndiv").style.width=w1-w2+"px";
}
function Chkwh7()
{
    var h1=document.body.clientHeight-294;//表格高度
    var w1=window.screen.availWidth;//屏幕可用工作区宽度
    var w2=10;//滑条宽度
    $("cndiv2").style.height=h1+"px";
    $("cndiv2").style.width=w1-w2+"px";
}

//绘制div宽高
function Chkwhs()
{
    var h1=document.body.clientHeight-254;//表格高度
    var w1=window.screen.availWidth;//屏幕可用工作区宽度
    var w2=4;//滑条宽度
    $("cndiv").style.height=h1+"px";
    $("cndiv").style.width=w1-w2+"px";
    $("cnbut").style.height="200px";
    $("cnbut").style.width=w1-w2+"px";
}

function Chkwhser()
{
    var h1=document.body.clientHeight-164;//表格高度
    var w1=window.screen.availWidth;//屏幕可用工作区宽度
    var w2=10;//滑条宽度
    var w3=12;
    $("cndiv").style.height=h1+"px";
    $("cndiv").style.width=w1-w2+"px";
    var h2=h1-178;
    var h3=h1-150;
    var h4=h1-147;
    var w4=14;
    $("divconf").style.height=h2+"px";
//    $("divconf").style.width=w1-w4+"px";
//    $("mytabs").style.width=w1-w3+"px";
    $("info1").style.height=h3+"px";
   // $("divinfo1").style.height=h4+"px";
//    $("info1").style.width=w1-w3+"px";
    $("info2").style.height=h4+"px";
    $("info3").style.height=h3+"px";
//    $("info2").style.width=w1-w3+"px";
}

//绘制div宽高
function Chkwhser2()
{
    var h1=document.body.clientHeight-54;//表格高度
    var w1=window.screen.availWidth;//屏幕可用工作区宽度
    var h2=h1-200;//固定占用高度
    var w2=20+158;//滑条宽度
    $("lndiv").style.height=h1+"px";
    $("lncn").style.height=h1+"px";
    $("cndiv").style.height=h2+"px";
    $("cndiv").style.width=w1-w2+"px";
    $("divlbut").style.width=w1-w2+"px";
    $("divlbutcon").style.width=w1-w2-2+"px";
    $("divlbutdo").style.width=w1-w2-2+"px";
}

function Chkwh8()
{
    var h1=document.body.clientHeight-169;//表格高度
    var h2=h1-2;
    var h3=h1-4;
    $("cndiv").style.height=h1+"px";
    $("sdiv").style.height=h2+"px";
    $("fdiv").style.height=h3+"px";
    var w1=window.screen.availWidth;//屏幕可用工作区宽度
    $("cndiv").style.width=w1-4+"px";
    $("sdiv").style.width=w1-6+"px";
    $("fdiv").style.width=w1-8+"px";
}
function Chkwh9()
{
    var h1=document.body.clientHeight-139;//表格高度
    var h2=h1-2;
    var h3=h1-4;
    $("cndiv").style.height=h1+"px";
    $("sdiv").style.height=h2+"px";
    $("fdiv").style.height=h3+"px";
    var w1=window.screen.availWidth;//屏幕可用工作区宽度
    $("cndiv").style.width=w1-4+"px";
    $("sdiv").style.width=w1-6+"px";
    $("fdiv").style.width=w1-8+"px";
}
function Chkwh10(hspan)
{
    var hv=234;
    if(hspan!=null)hv=hspan
    var h1=document.body.clientHeight-hv;//表格高度
    var h2=h1-2;
    var h3=h1-4;
    $("cndiv").style.height=h1+"px";
    $("sdiv").style.height=h2+"px";
    $("fdiv").style.height=h3+"px";
    var w1=window.screen.availWidth;//屏幕可用工作区宽度
    $("cndiv").style.width=w1-4+"px";
    $("sdiv").style.width=w1-6+"px";
    $("fdiv").style.width=w1-8+"px";
}
function Chkwh10a(hspan)
{
    var hv=264;
    if(hspan!=null)hv=hspan
    var h1=document.body.clientHeight-hv;//表格高度
    var h2=h1-2;
    var h3=h1-4;
    $("cndiv").style.height=h1+"px";
    $("sdiv").style.height=h2+"px";
    $("fdiv").style.height=h3+"px";
    var w1=window.screen.availWidth;//屏幕可用工作区宽度
    $("cndiv").style.width=w1-4+"px";
    $("sdiv").style.width=w1-6+"px";
    $("fdiv").style.width=w1-8+"px";
}
function Chkwh11()
{
    var h1=document.body.clientHeight-319;//表格高度
    var h2=h1-2;
    var h3=h1-4;
    $("cndiv").style.height=h1+"px";
    $("sdiv").style.height=h2+"px";
    $("fdiv").style.height=h3+"px";
    var w1=window.screen.availWidth;//屏幕可用工作区宽度
    $("cndiv").style.width=w1-4+"px";
    $("sdiv").style.width=w1-6+"px";
    $("fdiv").style.width=w1-8+"px";
}

//绘制div宽高
function Chkwh12()
{
    var h1=document.body.clientHeight-284;//表格高度
    var w1=window.screen.availWidth;//屏幕可用工作区宽度
    var w2=20;//滑条宽度
    $("cndiv").style.height=h1+"px";
    $("cndiv").style.width=w1-w2+"px";
    $("cnbut").style.height="230px";
    $("cnbut").style.width=w1-w2+"px";
}
function Chkwhtj()
{
    var h1=document.body.clientHeight-54;//表格高度
    var w1=window.screen.availWidth;//屏幕可用工作区宽度
    var h2=153;//固定占用高度
    var w2=312;//滑条宽度
    $("cndiv").style.height=h1+"px";
    $("cndiv").style.width="297px";
    $("divright").style.height=h1+"px";
    $("divright").style.width=w1-w2+"px";
}
//修改
function ChkMod(w,h,url,title)
{
    if(ChkSlt()!=false)
    {
        var id=document.getElementById("hfRecID").value;
        if(url.indexOf('?')!=-1){url+="&id="+id}else{url+="?id="+id;}
        parent.ShowDialog(w,h,url,title);
    }
}
function ChkModA(w,h,url,title)
{
    if(ChkSlt()!=false)
    {
        var id=document.getElementById("hfRecID").value;
        if(url.indexOf('?')!=-1){url+="&id="+id}else{url+="?id="+id;}
        parent.ShowDialog1(w,h,url,title);
    }
}
//修改2
function ChkMod2(w,h,url,title)
{
    if(ChkSlt2()!=false)
    {
        var id=document.getElementById("hfRecID2").value;
        if(url.indexOf('?')!=-1){url+="&id="+id}else{url+="?id="+id;}
        parent.ShowDialog(w,h,url,title);
    }
}

//修改3
function ChkMod3(w,h,url,title)
{
    if(ChkSlt3()!=false)
    {
        var id=document.getElementById("hfRecID3").value;
        if(url.indexOf('?')!=-1){url+="&id="+id}else{url+="?id="+id;}
        parent.ShowDialog(w,h,url,title);
    }
}
//双击修改
function ModClick()
{
    document.getElementById("btnMod").click();
}

//删除
function ChkDel(str)
{
    if(ChkSlt()!=false)
    {
        return confirm("确认要删除该["+str+"]吗？");
    }else{return false;}
}
//确认操作
function ChkConf(str)
{
    if(ChkSlt()!=false)
    {
        return confirm("确认要"+str+"吗？");
    }else{return false;}
}
//删除2
function ChkDel2(str)
{
    if(ChkSlt2()!=false)
    {
        return confirm("确认要删除该["+str+"]吗？");
    }else{return false;}
}
//确认操作
function ChkConf2(str)
{
    if(ChkSlt2()!=false)
    {
        return confirm("确认要"+str+"吗？");
    }else{return false;}
}
//删除3
function ChkDel3(str)
{
    if(ChkSlt3()!=false)
    {
        return confirm("确认要删除该["+str+"]吗？");
    }else{return false;}
}

function ChkSch()
{
    if(isNull($("tbCon").value))
    {
         window.alert("请输入查询内容！");
        $("tbCon").focus();
        return false
    }
}
//导出Excel
function ChkToExcel()
{
    if($("hfTbTitle").value=="")
    {
        window.alert("操作失败！没有要导出的数据");
        return false;
    }
    if(parseFloat($("lbCount").innerHTML)>60000)
    {
        window.alert("操作失败！最多只能导出60000条数据。请分类查询后导出");
        return false;
    }
    
    if(parseFloat($("lbCount").innerHTML)>10000)
    {
        if(confirm("导出数据过多，可能需要更长的时间。确定要导出吗？"))
        {
            parent.document.getElementById("test").style.display = "block";
            return true;
        }
        else{return false;}
    }
}

//打印
function ChkPrint(name)
{
    var id;
    if($("hfPrintID")==null)
    {
        id=$("hfRecID").value;
    }
    else
    {
        id=$("hfPrintID").value;
    }
    
    if(id=="")
    {
        window.alert("请先保存后再打印...!");
        return false;
    }
    
    if(id=="-1")
    {
        window.alert("请先选择一条记录后再打印...!");
        return false;
    }
        
    else
    {
        var w=(window.screen.width-750)/2;
        var num=Math.round(Math.random()*10000);
        window.open("../../Headquarters/Print/interface_print.aspx?type=Print&obj="+name+"&id="+id+"&a="+num,"","width=750,height=580,toolbar=no,left="+w+",top=20,location=no,directories=yes,status=yes,menubar=yes,resizable=yes,scrollbars=yes");
    }
}

function ChkPrintChoise()
{
    if(ChkSlt()!=false)
    {
        var id=id=$("hfRecID").value;
        parent.ShowDialog(380,100, 'Services/PrintBill.aspx?id='+id, '打印选择');   
    }
}

//打印
function ChkPrint2(name)
{
    var id;
    if($("hfPrintID2")==null)
    {
        id=$("hfRecID2").value.replace("j","");
    }
    else
    {
        id=$("hfPrintID2").value.replace("j","");
    }
    
    if(id=="-1")
    {
        window.alert("请先选择一条记录后再打印...!");
        return false;
    }
    else
    {
        var w=(window.screen.width-750)/2;
        var num=Math.round(Math.random()*10000);
        window.open("../../Headquarters/Print/interface_print.aspx?type=Print&obj="+name+"&id="+id+"&a="+num,"","width=750,height=580,toolbar=no,left="+w+",top=20,location=no,directories=yes,status=yes,menubar=yes,resizable=yes,scrollbars=yes");
    }
}
//焦点
function ChkSetFocus(name)
{
    $(name).focus();
}

//选中
function ChkSetSelect(name)
{
    $(name).select();
}

function getclassvalue(name,value)
{
    var strvalue;
    if (value != null)
    {
        strvalue=value.replace("│", "").replace("│", "").replace("├", "").replace(" ","").replace(" ","");
    }
    else { strvalue=""; }
    
    $(name).value=strvalue;
}
//截断字符
function subStr(str,len)
{
	var strlength=0;
	var newstr = "";
	for (var i=0;i<str.length;i++)
	{
		if(str.charCodeAt(i)>=1000)
			strlength += 2;
		else
			strlength += 1;
		if(strlength > len)
		{
			newstr += "...";
			break;
		}
		else
		{
			newstr += str.substr(i,1);
		}
	}
	return newstr;
}

function NewStock(flag)
{
    if($("ddlStock").value=="0")
    {
        for(var i=0;i<$("ddlStock").options.length;i++)
        {
            if($("ddlStock").options[i].text=="")
            {
                $("ddlStock").options[i].selected=true;
            }
        }
        if(flag=="2")
            parent.ShowDialog2(500, 270, 'Basic/StockListAdd.aspx?f=2', '新建仓库');
        else
            parent.ShowDialog1(500, 270, 'Basic/StockListAdd.aspx?f=1', '新建仓库');
    }
}

function NewArea(flag)
{
    if($("ddlArea").value=="0")
    {
        for(var i=0;i<$("ddlArea").options.length;i++)
        {
            if($("ddlArea").options[i].text=="")
            {
                $("ddlArea").options[i].selected=true;
            }
        }
        
        $("tbArea").value="";
        if(flag=="2")
            parent.ShowDialog2(300, 93, 'Basic/AreaAdd.aspx?f=2', '新建区域');
        else
        if(flag=="3")
            parent.ShowDialog1(300, 93, 'Basic/AreaAdd.aspx?f=1&fid='+parent.$("hfActiveWin").value, '新建区域');
        else
            parent.ShowDialog1(300, 93, 'Basic/AreaAdd.aspx?f=1', '新建区域');
    }
}

function NewAreas(flag)
{
    if($("ddlArea").value=="0")
    {
        for(var i=0;i<$("ddlArea").options.length;i++)
        {
            if($("ddlArea").options[i].text=="")
            {
                $("ddlArea").options[i].selected=true;
            }
        }
        
        $("tbArea").value="";
        parent.ShowDialog1(300, 93, 'Basic/AreaAdd.aspx?f=1&fid='+parent.$("hfActiveWin").value, '新建区域');
    }
}

function NewFrom(flag)
{
    if($("ddlFrom").value=="0")
    {
        for(var i=0;i<$("ddlFrom").options.length;i++)
        {
            if($("ddlFrom").options[i].text=="")
            {
                $("ddlFrom").options[i].selected=true;
            }
        }
        if(flag=="2")
            parent.ShowDialog2(300, 93, 'Basic/FromAdd.aspx?f=2', '新建来源');
        else
            parent.ShowDialog1(300, 93, 'Basic/FromAdd.aspx?f=1', '新建来源');
    }
}

function NewQuarters(flag)
{
    if($("ddlQus").value=="0")
    {
        for(var i=0;i<$("ddlQus").options.length;i++)
        {
            if($("ddlQus").options[i].text=="")
            {
                $("ddlQus").options[i].selected=true;
            }
        }
        if(flag=="2")
            parent.ShowDialog2(300, 93, 'Basic/QuartersAdd.aspx?f=2', '新建岗位');
        else
            parent.ShowDialog1(300, 93, 'Basic/QuartersAdd.aspx?f=1', '新建岗位');
    }
}

function NewProductBrand(flag)
{
    if($("ddlBrand").value=="0")
    {
        for(var i=0;i<$("ddlBrand").options.length;i++)
        {
            if($("ddlBrand").options[i].text=="")
            {
                $("ddlBrand").options[i].selected=true;
            }
        }
        if(flag=="2")
            parent.ShowDialog2(300, 93, 'Basic/ProductBrandAdd.aspx?f=2', '新建品牌');
        else
        if(flag=="3")
            parent.ShowDialog1(300, 93, 'Basic/ProductBrandAdd.aspx?f=1&fid='+parent.$("hfActiveWin").value, '新建品牌');
        else
            parent.ShowDialog1(300, 93, 'Basic/ProductBrandAdd.aspx?f=1', '新建品牌');
    }
}

function NewProductBrands(flag)
{
    if($("ddlBrand").value=="0")
    {
        for(var i=0;i<$("ddlBrand").options.length;i++)
        {
            if($("ddlBrand").options[i].text=="")
            {
                $("ddlBrand").options[i].selected=true;
            }
        }
       
       $("tbBrand").value="";
       if(flag=="1")
       parent.ShowDialog1(300, 93, 'Basic/ProductBrandAdd.aspx?f=1', '新建品牌');
       else
       parent.ShowDialog1(300, 93, 'Basic/ProductBrandAdd.aspx?f=1&fid='+parent.$("hfActiveWin").value, '新建品牌');
    }
}


function NewProductClass(flag)
{
    if($("ddlClass").value=="0")
    {
        for(var i=0;i<$("ddlClass").options.length;i++)
        {
            if($("ddlClass").options[i].text=="")
            {
                $("ddlClass").options[i].selected=true;
            }
        }
        if(flag=="2")
            parent.ShowDialog2(300, 93, 'Basic/ProductClassAdd.aspx?f=2', '新建类别');
        else
        if(flag=="3")
            parent.ShowDialog1(300, 93, 'Basic/ProductClassAdd.aspx?f=1&fid='+parent.$("hfActiveWin").value, '新建类别');
        else
            parent.ShowDialog1(300, 93, 'Basic/ProductClassAdd.aspx?f=1', '新建类别');
    }
}

function NewProductClasss(flag)
{
    if($("ddlClass").value=="0")
    {
        for(var i=0;i<$("ddlClass").options.length;i++)
        {
            if($("ddlClass").options[i].text=="")
            {
                $("ddlClass").options[i].selected=true;
            }
        }
      $("tbClass").value="";
      if(flag=="1")
       parent.ShowDialog1(300, 93, 'Basic/ProductClassAdd.aspx?f=1', '新建类别');
       else
      parent.ShowDialog1(300, 93, 'Basic/ProductClassAdd.aspx?f=1&fid='+parent.$("hfActiveWin").value, '新建类别');
    }
}
function NewProductModel(flag)
{
    if($("ddlModel").value=="0")
    {
        for(var i=0;i<$("ddlModel").options.length;i++)
        {
            if($("ddlModel").options[i].text=="")
            {
                $("ddlModel").options[i].selected=true;
            }
        }
        if(flag=="2")
            parent.ShowDialog2(300, 93, 'Basic/ProductModelAdd.aspx?f=2&gbid='+$("ddlBrand").value+'&gcid='+$("ddlClass").value, '新建型号');
        else
            parent.ShowDialog1(300, 93, 'Basic/ProductModelAdd.aspx?f=1&gbid='+$("ddlBrand").value+'&gcid='+$("ddlClass").value, '新建型号');
    }
}

function NewProductModels(flag)
{
    if($("ddlModel").value=="0")
    {
        for(var i=0;i<$("ddlModel").options.length;i++)
        {
            if($("ddlModel").options[i].text=="")
            {
                $("ddlModel").options[i].selected=true;
            }
        }
        
      $("tbModel").value="";
      if(flag=="1")
        parent.ShowDialog1(460, 118, 'Basic/ProductModelAdd.aspx?f=1&gbid='+$("ddlBrand").value+'&gcid='+$("ddlClass").value, '新建型号');
       else
      parent.ShowDialog1(460, 118, 'Basic/ProductModelAdd.aspx?f=1&fid='+parent.$("hfActiveWin").value+'&gbid='+$("ddlBrand").value+'&gcid='+$("ddlClass").value, '新建型号');
    }
}

function NewProductAspect(flag)
{
    if($("ddlAspect").value=="0")
    {
        for(var i=0;i<$("ddlAspect").options.length;i++)
        {
            if($("ddlAspect").options[i].text=="")
            {
                $("ddlAspect").options[i].selected=true;
            }
        }
        if(flag=="2")
            parent.ShowDialog2(300, 93, 'Basic/ProductAspectAdd.aspx?f=2', '新建外观');
        else
            parent.ShowDialog1(300, 93, 'Basic/ProductAspectAdd.aspx?f=1', '新建外观');
    }
}

function NewRepStatus(flag)
{
    if($("ddlRepStatus").value=="0")
    {
        for(var i=0;i<$("ddlRepStatus").options.length;i++)
        {
            if($("ddlRepStatus").options[i].text=="")
            {
                $("ddlRepStatus").options[i].selected=true;
            }
        }
        if(flag=="2")
            parent.ShowDialog2(300, 93, 'Basic/ProductRepStatusAdd.aspx?f=2', '新建保修情况');
        else
        if(flag=="3")
            parent.ShowDialog1(300, 93, 'Basic/ProductRepStatusAdd.aspx?f=1&fid='+parent.$("hfActiveWin").value, '新建保修情况');
        else
            parent.ShowDialog1(300, 93, 'Basic/ProductRepStatusAdd.aspx?f=1', '新建保修情况');
    }
}

function NewRepairClass(flag)
{
    if($("ddlRepair").value=="0")
    {
        for(var i=0;i<$("ddlRepair").options.length;i++)
        {
            if($("ddlRepair").options[i].text=="")
            {
                $("ddlRepair").options[i].selected=true;
            }
        }
        if(flag=="2")
            parent.ShowDialog2(300, 93, 'Basic/RepairClassAdd.aspx?f=2', '新建类别');
        else
            parent.ShowDialog1(300, 93, 'Basic/RepairClassAdd.aspx?f=1', '新建类别');
    }
}

function NewStockLoc(flag)
{
    if($("ddlStockLoc").value=="0")
    {
        for(var i=0;i<$("ddlStockLoc").options.length;i++)
        {
            if($("ddlStockLoc").options[i].text=="")
            {
                $("ddlStockLoc").options[i].selected=true;
            }
        }
        if(flag=="2")
            parent.ShowDialog2(300, 93, 'Basic/StockLocAdd.aspx?f=2', '新建仓位');
        else
            parent.ShowDialog1(300, 93, 'Basic/StockLocAdd.aspx?f=1', '新建仓位');
    }
}

function NewUnit(flag)
{
    if($("ddlUnit").value=="0")
    {
        for(var i=0;i<$("ddlUnit").options.length;i++)
        {
            if($("ddlUnit").options[i].text=="")
            {
                $("ddlUnit").options[i].selected=true;
            }
        }
        if(flag=="2")
            parent.ShowDialog2(300, 93, 'Basic/UnitAdd.aspx?f=2', '新建单位');
        else
            parent.ShowDialog1(300, 93, 'Basic/UnitAdd.aspx?f=1', '新建单位');
    }
}

function NewSupplier(flag)
{
    if($("ddlProvider").value=="0")
    {
        for(var i=0;i<$("ddlProvider").options.length;i++)
        {
            if($("ddlProvider").options[i].text=="")
            {
                $("ddlProvider").options[i].selected=true;
            }
        }
        if(flag=="2")
            parent.ShowDialog2(540, 290, 'Basic/SupplierAdd.aspx?f=2', '新建厂商');
        else
        if(flag=="3")
            parent.ShowDialog1(540, 290, 'Basic/SupplierAdd.aspx?f=1&fid='+parent.$("hfActiveWin").value, '新建厂商');
        else
            parent.ShowDialog1(540, 290, 'Basic/SupplierAdd.aspx?f=1', '新建厂商');
    }
}

function ShowTA(id)
{
    parent.ShowDialog(470, 360,'Services/ShowTA.aspx?id='+id, '处理措施/结果');
}