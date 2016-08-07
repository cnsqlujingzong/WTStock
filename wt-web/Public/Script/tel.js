function ChkPane(mdiv)
{
    document.getElementById(mdiv).style.display="block";
    for(var i=1;i<=2;i++)
    {
        if(("odiv"+i)!=mdiv)
        {
            document.getElementById("odiv"+i).style.display="none";
        }
    }
}

//标记颜色
function ClrID(id,hid)
{
    var obj = document.getElementById(id);
    if(obj!=null){
    var oldObj = document.getElementById(document.getElementById(hid).value);
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
    document.getElementById(hid).value = id;
    }
}

// JScript 文件
function ShowDialog(nWidth, nHeight, strUrl, strTitleName)
{
    var mydiv=document.getElementById("fcolor");
    var nHeight=nHeight;
    var scolor=getCurrentStyle(mydiv, "backgroundColor", "background-color");
    /*ie6*/
	if(scolor=="#0000ff")
	{
        nHeight=nHeight-10;
	}/*ie7*/
	else if(scolor=="#ff0000")
	{
	    nHeight=nHeight+10;
	    document.getElementById("iframeDialog").style.height = nHeight-21+"px";
	}/*firefox*/
	else if(scolor=="rgb(0, 255, 0)")
	{
	    nHeight=nHeight+10;
	    document.getElementById("iframeDialog").style.height = nHeight-21+"px";
	}
	else
	{
	    nHeight=nHeight+10;
	    document.getElementById("iframeDialog").style.height = nHeight-21+"px";
	}
	  
	document.getElementById("divDialog").style.display = "block";
	document.getElementById("divDialog").style.visibility = "visible";
	document.getElementById("divDialog").style.top = (window.screen.height/2-nHeight/2)/2-43+"px";
	document.getElementById("divDialog").style.left = "60px";
	document.getElementById("divDialog").style.width = nWidth+"px";
	document.getElementById("divDialog").style.height = nHeight+"px";
	var num=Math.round(Math.random()*10000);
	if(strUrl.indexOf('?')!=-1){strUrl+="&a="+num}else{strUrl+="?a="+num;}
	document.getElementById("iframeDialog").src="about:blank";
	document.getElementById("iframeDialog").src = strUrl;
	document.getElementById("divTitleName").innerHTML = strTitleName;
	document.getElementById("divTitleName").style.width = nWidth-50+"px";
	document.getElementById("divBackground").style.width = "100%";
	document.getElementById("divBackground").style.height = "100%";
	document.getElementById("divBackground").style.display = "block";
	document.getElementById("divBackground").style.visibility = "visible";
	document.getElementById("divBackground").style.top = "0px";
	document.getElementById("divBackground").style.left = "0px";	
}

function CloseDialog()
{
	document.getElementById("divDialog").style.display = "none";
	document.getElementById("divDialog").style.visibility = "hidden";
	document.getElementById("iframeDialog").src = "about:blank";
	document.getElementById("divTitleName").innerHTML = "无标题";
	document.getElementById("divBackground").style.display = "none";
	document.getElementById("divBackground").style.visibility = "hidden";
}
  
function ShowDialog1(nWidth, nHeight, strUrl, strTitleName)
{
    var mydiv=document.getElementById("fcolor");
    var nHeight=nHeight;
    var scolor=getCurrentStyle(mydiv, "backgroundColor", "background-color");
    /*ie6*/
	if(scolor=="#0000ff")
	{
        nHeight=nHeight-10;
	}/*ie7*/
	else if(scolor=="#ff0000")
	{
	    nHeight=nHeight+10;
	    document.getElementById("iframeDialog1").style.height = nHeight-21+"px";
	}/*firefox*/
	else if(scolor=="rgb(0, 255, 0)")
	{
	    nHeight=nHeight+10;
	    document.getElementById("iframeDialog1").style.height = nHeight-21+"px";
	}else
	{
	    nHeight=nHeight+10;
	    document.getElementById("iframeDialog1").style.height = nHeight-21+"px";
	}
	document.getElementById("divDialog1").style.display = "block";
	document.getElementById("divDialog1").style.visibility = "visible";
	document.getElementById("divDialog1").style.top = (window.screen.height/2-nHeight/2)/2-43+"px";
	document.getElementById("divDialog1").style.left = (window.screen.width/2-nWidth/2-12)+"px";
	document.getElementById("divDialog1").style.width = nWidth+"px";
	document.getElementById("divDialog1").style.height = nHeight+"px";
	var num=Math.round(Math.random()*10000);
	if(strUrl.indexOf('?')!=-1){strUrl+="&a="+num}else{strUrl+="?a="+num;}
	document.getElementById("iframeDialog1").src="about:blank";
	document.getElementById("iframeDialog1").src = strUrl;
	document.getElementById("divTitleName1").innerHTML = strTitleName;
	document.getElementById("divTitleName1").style.width = nWidth-50+"px";
			
	document.getElementById("divBackground1").style.width = "100%";
	document.getElementById("divBackground1").style.height = "100%";
	document.getElementById("divBackground1").style.display = "block";
	document.getElementById("divBackground1").style.visibility = "visible";
	document.getElementById("divBackground1").style.top = "0px";
	document.getElementById("divBackground1").style.left = "0px";
}

function CloseDialog1()
{
	document.getElementById("divDialog1").style.display = "none";
	document.getElementById("divDialog1").style.visibility = "hidden";
	document.getElementById("iframeDialog1").src = "about:blank";
	document.getElementById("divTitleName1").innerHTML = "无标题";			
	document.getElementById("divBackground1").style.display = "none";
	document.getElementById("divBackground1").style.visibility = "hidden";
}
function ShowDialog2(nWidth, nHeight, strUrl, strTitleName)
{
    var mydiv=document.getElementById("fcolor");
    var nHeight=nHeight;
    var scolor=getCurrentStyle(mydiv, "backgroundColor", "background-color");
    /*ie6*/
	if(scolor=="#0000ff")
	{
        nHeight=nHeight-10;
	}/*ie7*/
	else if(scolor=="#ff0000")
	{
	    nHeight=nHeight+10;
	    document.getElementById("iframeDialog2").style.height = nHeight-21+"px";
	}/*firefox*/
	else if(scolor=="rgb(0, 255, 0)")
	{
	    nHeight=nHeight+10;
	    document.getElementById("iframeDialog2").style.height = nHeight-21+"px";
	}else
	{
	    nHeight=nHeight+10;
	    document.getElementById("iframeDialog2").style.height = nHeight-21+"px";
	}
	document.getElementById("divDialog2").style.display = "block";
	document.getElementById("divDialog2").style.visibility = "visible";
	document.getElementById("divDialog2").style.top = (window.screen.height/2-nHeight/2)/2-43+"px";
	document.getElementById("divDialog2").style.left = (window.screen.width/2-nWidth/2-12)+"px";
	document.getElementById("divDialog2").style.width = nWidth+"px";
	document.getElementById("divDialog2").style.height = nHeight+"px";
	var num=Math.round(Math.random()*10000);
	if(strUrl.indexOf('?')!=-1){strUrl+="&a="+num}else{strUrl+="?a="+num;}
	document.getElementById("iframeDialog2").src="about:blank";
	document.getElementById("iframeDialog2").src = strUrl;
	document.getElementById("divTitleName2").innerHTML = strTitleName;
	document.getElementById("divTitleName2").style.width = nWidth-50+"px";
			
	document.getElementById("divBackground2").style.width = "100%";
	document.getElementById("divBackground2").style.height = "100%";
	document.getElementById("divBackground2").style.display = "block";
	document.getElementById("divBackground2").style.visibility = "visible";
	document.getElementById("divBackground2").style.top = "0px";
	document.getElementById("divBackground2").style.left = "0px";
}

function CloseDialog2()
{
	document.getElementById("divDialog2").style.display = "none";
	document.getElementById("divDialog2").style.visibility = "hidden";
	document.getElementById("iframeDialog2").src = "about:blank";
	document.getElementById("divTitleName2").innerHTML = "无标题";			
	document.getElementById("divBackground2").style.display = "none";
	document.getElementById("divBackground2").style.visibility = "hidden";
}
//拖动事件
function drag(obj,target)
    {
	    obj.onmousedown=function(a)
	    {
	        obj.style.cursor = "default";
		    var d=document;if(!a)a=window.event;
		    var x=a.layerX?a.layerX:a.offsetX,y=a.layerY?a.layerY:a.offsetY;

		    if(obj.setCapture)
			    obj.setCapture();
		    else if(window.captureEvents)
			    window.captureEvents(Event.MOUSEMOVE|Event.MOUSEUP);

		    d.onmousemove=function(a)
		    {
			    if(!a)a=window.event;
			    if(!a.pageX)a.pageX=a.clientX;
			    if(!a.pageY)a.pageY=a.clientY;
			    
			    var tx=a.pageX-x,ty=a.pageY-y;
			    
			    if(tx > window.document.body.offsetWidth - target.offsetWidth)
			    {
			        tx = window.document.body.offsetWidth - target.offsetWidth;
			    }
			    if (tx < 0)
			    {
			        tx = 0;
			    }

			    if(ty > window.document.body.offsetHeight - target.offsetHeight)
			    {
			        ty = window.document.body.offsetHeight - target.offsetHeight;
			    }
			    if(ty < 0)
			    {
			        ty = 0;
			    }
			    target.style.left=tx;//+px
			    target.style.top=ty;
		    };

		    d.onmouseup=function()
		    {
		        obj.style.cursor = "default";
			    if(obj.releaseCapture)
				    obj.releaseCapture();
			    else if(window.captureEvents)
				    window.captureEvents(Event.MOUSEMOVE|Event.MOUSEUP);
			    d.onmousemove=null;
			    d.onmouseup=null;
		    };
	    };
}

/**/

/**/
function getCurrentStyle(obj, cssproperty, csspropertyNS){   
    if(obj.style[cssproperty]){   
        return obj.style[cssproperty];   
    }   
    if (obj.currentStyle) {// IE5+   
        return obj.currentStyle[cssproperty];   
    }else if (document.defaultView.getComputedStyle(obj, null)) {// FF/Mozilla   
        var currentStyle = document.defaultView.getComputedStyle(obj, null);   
        var value = currentStyle.getPropertyValue(csspropertyNS);   
        if(!value){//try this method   
            value = currentStyle[cssproperty];   
        }   
        return value;   
    }else if (window.getComputedStyle) {// NS6+   
        var currentStyle = window.getComputedStyle(obj, "");   
        return currentStyle.getPropertyValue(csspropertyNS);   
    }   
}

