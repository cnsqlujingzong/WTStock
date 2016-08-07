/*
	��    ��: �ര�ڹ���ʵ��
	����ʱ��: 2010-8-29
	�� �� ��: ����
*/

//�ж��Ƿ���IE
function isIE(){
if (window.navigator.userAgent.indexOf("MSIE")>=1)
return true;
else
return false;
}

if(!isIE())
{
    //������IE��дinsertAdjacentElement��������ff�����
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
 
function mywin()
{
    var titlelist = document.getElementById("titlelist");
    var mytitle = document.getElementById("mytitle");
    
	this.winlist = new Array();                 //�����б�
	this.maxWins = 100;				            //��󴰿���
	this.tagTitleWidth=0;
	this.indentWidth = 0;			            //��ǩ�������
	this.currentwin = null;                     //��ǰ�����
	this.addwin = addwin;                       //�½����ڷ���
	this.removewin = removewin;                 //�Ƴ�����
	this.removeall = removeall;                 //�Ƴ����д���
	this.activewin = activewin;                 //�����
	this.container = container;
	this.padLeft = padLeft;					    // ���������Ե�ľ���
	this.padRight = padRight;				    // �������ұ�Ե�ľ���
	this.scrollWidth = scrollWidth;

    this.winactiveleft=new Array();
    this.winactivemiddle=new Array();
    this.winactivemiddleclose=new Array();
    this.winactiveright=new Array();
    
    //��ⴰ���Ƿ��Ѵ���
	function container(url,title)
	{
		for(var i=0;i<this.winlist.length;i++)
		{
			if(this.winlist[i].title == title &&this.winlist[i].url == url)
			{
				return i;
			}
		}
		return -1;
	}
	
	function activewin(oEl,con)                 //�����
	{
		if(oEl == null){
			this.currentwin = null;
			return
		}
		var tempzindex = this.currentwin.style.zIndex;
		this.currentwin.wintitle.style.zIndex = this.currentwin.index;
		this.currentwin.style.display = "none";
		this.currentwin.winactiveleft.className='Tab_InactiveLeft';
		this.currentwin.winactivemiddle.className='Tab_InactiveMiddle';
		this.currentwin.winactivemiddleclose.className='Tab_InactiveMiddleClose';
		this.currentwin.winactivemiddleclose.innerHTML='';
		this.currentwin.winactiveright.className='Tab_InactiveRight';
		
		oEl.wintitle.style.zIndex = tempzindex;
		oEl.style.display = "";
		oEl.winactiveleft.className='Tab_ActiveLeftBorder';
		oEl.winactivemiddle.className='Tab_ActiveMiddle';
		oEl.winactivemiddleclose.className='Tab_ActiveMiddleClose';
		
		if(con==1)
		    oEl.winactivemiddleclose.innerHTML='';
		else
		    oEl.winactivemiddleclose.innerHTML="<img src=\"../Public/Images/Tab/TabClose_Normal.png\" onMouseOver=\"this.src='../Public/Images/Tab/TabClose_Hover.png'\" onMouseDown=\"this.src='../Public/Images/Tab/TabClose_Down.png'\" onMouseOut=\"this.src='../Public/Images/Tab/TabClose_Normal.png'\" border= \"0 \" style=\"margin:5px 0px 0 0; cursor: default;\" onclick=\"win.removewin(win.currentwin)\"/>";
		    
		oEl.winactiveright.className='Tab_ActiveRightBorder';

		this.currentwin = oEl;

		//���������ʾ������
		var mleft = parseInt(titlelist.style.marginLeft);
		if (isNaN(mleft))
			mleft = 0;
		var padleft = this.padLeft(oEl);
		var padright = this.padRight(oEl);
		var clientwidth = titlelist.parentNode.clientWidth
		if(padleft + mleft > clientwidth)
		{
			titlelist.style.marginLeft = clientwidth - padleft;			
		}
		if(padright < clientwidth && mleft < 0)
		{
			mleft = clientwidth - this.scrollWidth();
			if(mleft>0)
				mleft = 0;
			titlelist.style.marginLeft = mleft;
		}
		if(padleft + mleft < this.tagTitleWidth)
		{
			titlelist.style.marginLeft = - (padleft - this.tagTitleWidth);
		}
	}

    //��Ӵ���
	function addwin(url,title)
	{
		var con = this.container(url,title); //��ⴰ���Ƿ���ڣ������ڼ���
		if(con>-1)
		{
			this.activewin(this.winlist[con],con+1);//�����
			return;
		}
		
		if(this.winlist.length >= this.maxWins)
		{
			this.removewin(this.winlist[1]);		//������󴰿������ƺ�,�ȹر����ȿ��Ĵ���
		}
		
		//�������
	    var	oDIV = window.document.createElement("table");
		this.winlist[this.winlist.length] = oDIV;                //���б�����Ӵ������
		oDIV.url = url;
		oDIV.title = title;
		oDIV.index = this.winlist.length;
		oDIV.className = "wintable";
		oDIV.width = "100%";
		oDIV.height = document.body.clientHeight-47;
		oDIV.cellSpacing=0;
		oDIV.cellPadding=0;
		//oDIV.onclick = new Function("Sethidden1()"); //�˴ε����û��ִ�д���
		var newrow=oDIV.insertRow(-1).insertCell(-1);
		newrow.vAlign='top';
		newrow.innerHTML = "<iframe src='"+url+"?a="+oDIV.index+"' scrolling='no' id='tab_win"+oDIV.index+"' name='tab_win"+oDIV.index+"' width='100%' height='100%' style=\"z-index:-9999\" frameborder='0'></iframe>";

        //��ʼ�������
        //�������������ǩ
        
        var wTitle=window.document.createElement("span");
        oDIV.wintitle = wTitle;//������Ҫ����Ϊɾ�����ڵ�����
        titlelist.insertAdjacentElement("beforeEnd" , wTitle);
        oDIV.style.zIndex = this.maxWins+1;
        
        var Tab_ActiveLeftBorder=window.document.createElement("span");
        Tab_ActiveLeftBorder.className ='Tab_ActiveLeftBorder';
		Tab_ActiveLeftBorder.style.zIndex = this.maxWins+1;
		oDIV.winactiveleft=Tab_ActiveLeftBorder;
        wTitle.insertAdjacentElement("beforeEnd" , Tab_ActiveLeftBorder);
        
		var oTitle = window.document.createElement("span");
		oTitle.className ='Tab_ActiveMiddle';
		oTitle.title = title;
		oTitle.innerHTML= title == null ? "δ֪" : title;
		oTitle.win=oDIV;
        oTitle.onclick = new Function("win.activewin(this.win,"+oDIV.index+")");
		    
		oTitle.style.zIndex = this.maxWins+1;
		oDIV.winactivemiddle=oTitle;
		wTitle.insertAdjacentElement("beforeEnd" , oTitle);

        var Tab_ActiveMiddleClose=window.document.createElement("span");
        Tab_ActiveMiddleClose.className='Tab_ActiveMiddleClose';
        
        //���Ϊ�������ڲ���ʾ�رհ�ť
        if(oDIV.index==1)
		    Tab_ActiveMiddleClose.innerHTML='';
		 else
		    Tab_ActiveMiddleClose.innerHTML="<img src=\"../Public/Images/Tab/TabClose_Normal.png\" onMouseOver=\"this.src='../Public/Images/Tab/TabClose_Hover.png'\" onMouseDown=\"this.src='../Public/Images/Tab/TabClose_Down.png'\" onMouseOut=\"this.src='../Public/Images/Tab/TabClose_Normal.png'\" border= \"0 \" style=\"margin:5px 0px 0 0; cursor: default;\" onclick=\"win.removewin(win.currentwin)\"/>";
		    
        Tab_ActiveMiddleClose.style.zIndex = this.maxWins+1;
        oDIV.winactivemiddleclose=Tab_ActiveMiddleClose;
        wTitle.insertAdjacentElement("beforeEnd" , Tab_ActiveMiddleClose);

        var Tab_ActiveRightBorder=window.document.createElement("span");
        Tab_ActiveRightBorder.className='Tab_ActiveRightBorder';
        
        Tab_ActiveRightBorder.style.zIndex = this.maxWins+1;
        oDIV.winactiveright=Tab_ActiveRightBorder;
        wTitle.insertAdjacentElement("beforeEnd" , Tab_ActiveRightBorder);
        //end
		
		var scrollwidth = this.scrollWidth();
		if(scrollwidth > titlelist.parentNode.clientWidth)
		{
			titlelist.style.marginLeft = titlelist.parentNode.clientWidth - scrollwidth;
		}
		mytitle.insertAdjacentElement("afterEnd" , oDIV);
		
		if(this.currentwin != null) {
		    this.currentwin.style.display = "none";
			this.currentwin.wintitle.style.zIndex = this.currentwin.index;
		    this.currentwin.winactiveleft.className='Tab_InactiveLeft';
		    this.currentwin.winactivemiddle.className='Tab_InactiveMiddle';
		    this.currentwin.winactivemiddleclose.className='Tab_InactiveMiddleClose';
		    this.currentwin.winactivemiddleclose.innerHTML='';
		    this.currentwin.winactiveright.className='Tab_InactiveRight';
		}
		
		this.currentwin = oDIV;
		
		//alert(document.body.clientHeight);
		document.getElementById("tab_win"+oDIV.index).style.height=document.body.clientHeight-47;
        document.getElementById("hfActiveWin").value="tab_win"+oDIV.index;
        
		return oDIV;
	}

    function removewin(obj)        //�Ƴ�����
	{
		if(obj == null)return;
		var temparr = new Array();
		var afterwin = false;
		for(var i=0;i<this.winlist.length;i++)
		{
			if(afterwin) this.winlist[i].wintitle.style.left =  this.winlist[i].wintitle.style.pixelLeft + this.indentWidth;
			if(this.winlist[i] != obj)
				temparr[temparr.length] = this.winlist[i];
			else
				afterwin = true;
		}
		this.winlist = temparr;
		if(this.currentwin == obj){
			this.activewin(this.winlist[this.winlist.length-1],this.winlist.length);
		}
		
		//��ʼ�Ƴ�����ͱ���
		var new_win=obj;
		var new_winlist=obj.wintitle;
        try {
        var tmp = new_win.parentNode;
        var tmptitle= new_winlist.parentNode;
        // Ϊ����ie��firefox�¶�������ʹ��,��Ҫ����һ����������,��ȡ��һ��ĸ����,Ȼ��remove.
        tmp.removeChild(new_win);
        tmptitle.removeChild(new_winlist);
        } catch(e) {}
	}

	function removeall()        //�Ƴ����д���
	{
		var wincount = this.winlist.length;
		for(var i=wincount-1;i>=0;i--)
			this.removewin(this.winlist[i]);
	}
	
	function padLeft(oEl)
	{
		var padleft = oEl.index * this.tagTitleWidth - this.indentWidth*(oEl.index-1);
		return padleft;
	}

	function padRight(oEl)
	{
		var count = (this.winlist.length - oEl.index) + 1;
		var padright = this.tagTitleWidth * count - this.indentWidth*(count-1);
		return padright;
	}
	
	function scrollWidth()
	{
		var n = this.winlist.length;
		var scrollwidth = this.tagTitleWidth*n - this.indentWidth*(n-1);
		return scrollwidth;
	}
}

function tabScroll(direction)
{
	tabScrollStop();
	direction == "right" ? tabMoveRight() : tabMoveLeft();
}

function tabMoveRight()
{
	tabMove("right",8);
	timer=setTimeout(tabMoveRight,10);
}

function tabMoveLeft()
{
	tabMove("left",8);
	timer=setTimeout(tabMoveLeft,10);
}

function tabScrollStop()
{
	clearTimeout(timer);
	timer = null;
}

function tabMove(direction,speed)
{
	var mleft = parseInt(titlelist.style.marginLeft);
	if (isNaN(mleft))
		mleft = 0;
	if(direction=="right")
	{
		if(titlelist.parentNode.clientWidth >= titlelist.parentNode.scrollWidth)
		{
			tabScrollStop();
			return;
		}
		else
		{
			titlelist.style.marginLeft = mleft - speed;
		}
	}
	else
	{
		if(mleft + speed >=0)
		{
			titlelist.style.marginLeft = 0;
			tabScrollStop();
			return;
		}
		else
		{
			titlelist.style.marginLeft = mleft + speed;
		}
	}
}

var timer = null;
var win = null;
var wins = new Array();

function init()
{
	win =  new mywin();                        //�½�����
}

function AddWin(Url,Title)
{
	wins[wins.length] = win.addwin(Url, Title);                        //��Ӵ��壻
}