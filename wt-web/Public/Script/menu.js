//document.oncontextmenu = function() {event.returnValue = false;}
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

function DrawInfo(title)
{
    var time=document.getElementById("hfServerDate").value;
    var user=document.getElementById("hfUser").value;
    var pur=document.getElementById("hfPurview").value;
    var str='<ul style="padding-left:0px;">';
        str+='<li class="li1">系统时间:'+time+'</li>';
        str+='<li class="li2">当前用户:'+user+'</li>';
        str+='<li class="li3">权限:'+pur+'</li>';
        str+='<li class="li4">当前页面:'+title+'</li>';
        str+='</ul>';
    return str;
}

/*-----菜单设置-----------*/

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

/*----------------*/
/*
	功    能: 多窗口功能实现
	创建时间: 2010-8-29
	创 建 人: 闫明
*/
function S(Divid,Ty){$(Divid).scrollTop=Ty}
function C(Divid,Css){$(Divid).className=Css}
//判断浏览器类型
function IsIe(){
if (window.navigator.userAgent.indexOf("MSIE")>=1)
return true;
else
return false;
}

if(!IsIe())
{
    //若不是IE重写insertAdjacentElement方法兼容ff浏览器
    HTMLElement.prototype.insertAdjacentElement=function(where,parsedNode)
    {
        switch(where)
        {
            case "beforeBegin":
                this.parentNode.insertBefore(parsedNode,this);
                break;
            case "afterBegin":
                this.insertBefore(parsedNode,this.firstChild);
                break;
            case "beforeEnd":
                this.appendChild(parsedNode);
                break;
            case "afterEnd":
                if(this.nextSibling)
                    this.parentNode.insertBefore(parsedNode,this.nextSibling);
                else
                    this.parentNode.appendChild(parsedNode);
                break;
        }
    }
 }

//改变窗口显示
function ChangeWin(){
var W=document.documentElement.clientWidth-50;
$("WinFinfo").style.width=W+"px";
ChangeWList("");
}
var CWlistTimer;
function ChangeWList(Ctype){
if(Ctype==""){
	var N=this.winlist.length;
	$("WinList").style.width=120*N+"px";
	$("WinFinfo").scrollLeft=$("WinFinfo").scrollWidth;
	if($("WinFinfo").clientWidth<$("WinFinfo").scrollWidth){$("FScro").style.display=""}else{$("FScro").style.display="none"}
	}
if(Ctype=="left"){
	$("WinFinfo").scrollLeft=$("WinFinfo").scrollLeft-5;
	CWlistTimer=window.setTimeout("ChangeWList('left')",10);
	}
if(Ctype=="right"){
	$("WinFinfo").scrollLeft=$("WinFinfo").scrollLeft+5;
	CWlistTimer=window.setTimeout("ChangeWList('right')",10)
	}
if(Ctype=="out"){clearTimeout(CWlistTimer)}
}

//------------创建新窗口-------------//
//Aid -- 唯一ID,不要与其它窗口相同,可以是任意字母数字等
//Atitle -- 窗口标题
//Aurl -- 当后面的 Atype=0 或 1时,这个为URL
//Aw -- 窗口内容区宽度
//Ah -- 窗口内容区高度
//Atype -- 可选 0,1,2
//         为0: ajax方式载入Aurl文件的内容
//         为1: 框架显示Aurl页面
//         为2: 插入Aurl文本到窗口内容区
//Abut -- 可选 0,1
//        为1: 窗口不可改变大小,无最大化状态
//BDlg  --窗口类型 0一般窗口，其他为模态窗口 若为0参数Aw,Ah,Abut都不起作用
this.winlist = new Array();                 //窗口列表
var AddTopZindex=1,AddTopOn=null;
var TopH=89; //窗口离上面的距离
function AddWin(Aid,Atitle,Aurl,Aw,Ah,Atype,Abut,BDlg){
if(this.winlist.length>16)
{
    window.alert("打开窗口数已超过最大限制，请先关闭窗后操作！");
    return;
}
var Cid="New"+Aid;
for(var i=0;i<this.winlist.length;i++)
{
    if(this.winlist[i] == Cid)
    {
        if(Cid=="Newcgkd"&&Aurl.indexOf("sellid")>0)
        {
            document.getElementById(Cid+"_FCon").src=Aurl;
            AddTop(Cid);
            Sethidden1();
            return;
        }
        {
            AddTop(Cid);
            Sethidden1();
            return;
        }
    }
}
var Acon="";
if(Atype==1){Acon="<IFRAME style='width:100%;height:100%;' id='"+Cid+"_FCon' name='"+Cid+"_FCon' src='"+Aurl+"' frameBorder='0' onclick='Sethidden1();'></IFRAME>";Aurl=""}
else if(Atype==2){Acon=Aurl;Aurl=""}

AddTopZindex++;
var oDiv=document.createElement("div");
oDiv.id=Cid;
oDiv.className="WinCss";
oDiv.style.zIndex=AddTopZindex;

var Html="";
if(BDlg==0)
{
    var oDiv2=document.createElement("div");
    var CidF=Cid+"_Foot";
    oDiv2.id=CidF
    oDiv2.className="WinCss_Foot";
    if(Cid=="NewYWDH")
    oDiv2.innerHTML="<div id='"+CidF+"But'></div><div id='"+CidF+"Menu'><span id='"+CidF+"Left' class='Tab_ActiveLeftBorder'></span><span id='"+CidF+"Middle' onclick=\"AddTop('"+Cid+"');\" class='Tab_ActiveMiddle'>"+Atitle+"</span><span id='"+CidF+"Close' class='Tab_ActiveMiddleClose'></span><span id='"+CidF+"Border' class='Tab_ActiveRightBorder'></span></div>";
    else
    oDiv2.innerHTML="<div id='"+CidF+"But'></div><div id='"+CidF+"Menu'><span id='"+CidF+"Left' class='Tab_ActiveLeftBorder'></span><span id='"+CidF+"Middle' onclick=\"AddTop('"+Cid+"');\" class='Tab_ActiveMiddle'>"+Atitle+"</span><span id='"+CidF+"Close' class='Tab_ActiveMiddleClose'><img src=\"../Public/Images/Tab/TabClose_Normal.png\" onMouseOver=\"this.src='../Public/Images/Tab/TabClose_Hover.png'\" onMouseDown=\"this.src='../Public/Images/Tab/TabClose_Down.png'\" onMouseOut=\"this.src='../Public/Images/Tab/TabClose_Normal.png'\" border= \"0 \" style=\"margin:5px 0px 0 0; cursor: default;\" onclick=\"AddClose('"+Cid+"',0);\"/></span><span id='"+CidF+"Border' class='Tab_ActiveRightBorder'></span></div>";
    $("WinList").appendChild(oDiv2);
    
    this.winlist[this.winlist.length] = Cid;                //往列表内添加窗体对象
    if(AddTopOn!=null)
    {
        $(AddTopOn+"_FootLeft").className="Tab_InactiveLeftBorder";
        $(AddTopOn+"_FootMiddle").className="Tab_InactiveMiddle";
        $(AddTopOn+"_FootClose").className="Tab_InactiveMiddleClose";
        $(AddTopOn+"_FootClose").innerHTML="";
        $(AddTopOn+"_FootBorder").className="Tab_InactiveRightBorder";
    }
    AddTopOn=Cid;
    
    oDiv.style.width=document.documentElement.clientWidth+"px";
    oDiv.style.height=document.documentElement.clientHeight-TopH+"px";
    oDiv.style.left="0px";
    oDiv.style.top=TopH+"px";
    Html="<div id='"+Cid+"_Con' class='WinCon2'>"+Acon+"</div>";
}
document.getElementById("hfActiveWinID").value=Cid;
document.getElementById("hfActiveWin").value=Cid+"_FCon";
oDiv.innerHTML=Html;
$("WinPage").appendChild(oDiv);
ChangeWList("");
Sethidden1();
}

//关闭
function AddClose(Cid,CType){
if(CType==0)
{
    //开始移除窗体和标题
    
    $("WinList").removeChild($(Cid+"_Foot"));
    $("WinPage").removeChild($(Cid));
    
    if(Cid == null)return;
    var temparr = new Array();
    for(var i=0;i<this.winlist.length;i++)
    {
	    if(this.winlist[i] != Cid)
		    temparr[temparr.length] = this.winlist[i];
    }
    this.winlist = temparr;
    var zMax=1;
    for(var i=0;i<temparr.length;i++)
    {
       if($(temparr[i].toString()).style.zIndex>zMax)
       {
            zMax=$(temparr[i].toString()).style.zIndex;
            AddTopOn=temparr[i].toString();
       }
    }
    document.getElementById("hfActiveWinID").value=AddTopOn;
    document.getElementById("hfActiveWin").value=AddTopOn+"_FCon";
    var CidF=AddTopOn+"_Foot";
    $(CidF+"Left").className='Tab_ActiveLeftBorder';
    $(CidF+"Middle").className='Tab_ActiveMiddle';
    $(CidF+"Close").className='Tab_ActiveMiddleClose';
    if(AddTopOn=="NewYWDH")
        $(CidF+"Close").innerHTML='';
    else
    {
        $(CidF+"Close").innerHTML="<img src=\"../Public/Images/Tab/TabClose_Normal.png\" onMouseOver=\"this.src='../Public/Images/Tab/TabClose_Hover.png'\" onMouseDown=\"this.src='../Public/Images/Tab/TabClose_Down.png'\" onMouseOut=\"this.src='../Public/Images/Tab/TabClose_Normal.png'\" border= \"0 \" style=\"margin:5px 0px 0 0; cursor: default;\" onclick=\"AddClose('"+AddTopOn+"',0);\"/>";
        RefrhClr();
    }
    $(CidF+"Border").className='Tab_ActiveRightBorder';
    var fid=window.frames[document.getElementById("hfActiveWin").value];
    if(fid!=null)
    {
        fid.focus();
    }
}
ChangeWList("");
}

//窗口置顶
function AddTop(Cid){
if(Cid==AddTopOn)return;
AddTopZindex++
$(Cid).style.zIndex=AddTopZindex;
var CidF=Cid+"_Foot";
currentwin=AddTopOn+"_Foot";
AddTopOn=Cid;
if(currentwin!=null)
{
    $(currentwin+"Left").className="Tab_InactiveLeftBorder";
    $(currentwin+"Middle").className="Tab_InactiveMiddle";
    $(currentwin+"Close").className="Tab_InactiveMiddleClose";
    $(currentwin+"Close").innerHTML="";
    $(currentwin+"Border").className="Tab_InactiveRightBorder";
}
$(CidF+"Left").className='Tab_ActiveLeftBorder';
$(CidF+"Middle").className='Tab_ActiveMiddle';
$(CidF+"Close").className='Tab_ActiveMiddleClose';
if(Cid=="NewYWDH")
    $(CidF+"Close").innerHTML='';
else
    {
        $(CidF+"Close").innerHTML="<img src=\"../Public/Images/Tab/TabClose_Normal.png\" onMouseOver=\"this.src='../Public/Images/Tab/TabClose_Hover.png'\" onMouseDown=\"this.src='../Public/Images/Tab/TabClose_Down.png'\" onMouseOut=\"this.src='../Public/Images/Tab/TabClose_Normal.png'\" border= \"0 \" style=\"margin:5px 0px 0 0; cursor: default;\" onclick=\"AddClose('"+Cid+"',0);\"/>";
    }
$(CidF+"Border").className='Tab_ActiveRightBorder';
document.getElementById("hfActiveWinID").value=Cid;
document.getElementById("hfActiveWin").value=Cid+"_FCon";
RefrhClr();
}

/*刷新窗口数据
获取iframe对象 兼容ff
document.getElementById("iframeMailContent").contentWindow.document.body.innerHTML=""; 
*/
//关闭窗口
function CloseWin()
{
    AddClose(document.getElementById("hfActiveWinID").value,0);
}
//刷新
function Refresh()
{
    var fid=window.frames[document.getElementById("hfActiveWin").value];
    if(fid!=null)
    {
        var btnfsh=fid.document.getElementById("btnFsh");
        if(btnfsh!=null)
            btnfsh.click();
    }
}

//查询
function RefreshSch()
{
    var fid=window.frames[document.getElementById("hfActiveWin").value];
    if(fid!=null)
    {
        var btnsch=fid.document.getElementById("btnSch");
        if(btnsch!=null)
            btnsch.click();
    }
}
//高级查询
function RefreshSchH(parm)
{
    var fid=window.frames[document.getElementById("hfActiveWin").value];
    if(fid!=null)
    {
        var btnsch=fid.document.getElementById("btnSchH");
        var hfparm=fid.document.getElementById("hfParm");
        if(btnsch!=null&&hfparm!=null)
           {
             hfparm.value=parm;
             btnsch.click();
           }
     }
}
//保留选中刷新
function RefrhClr()
{
    var fid=window.frames[document.getElementById("hfActiveWin").value];
    if(fid!=null)
    {
        var btnclr=fid.document.getElementById("btnClr");
        if(btnclr!=null)
            btnclr.click();
    }
}

function RefrhDetail()
{
    var fid=window.frames[document.getElementById("hfActiveWin").value];
    if(fid!=null)
    {
        var btnclr=fid.document.getElementById("btnShow");
        if(btnclr!=null)
            btnclr.click();
    }
}