var prm = null;
window.onload = function(){
    //加载用户和页面信息
    if(typeof(noOpen)!="undefined"){Chkset();}
    if(typeof(ctlname)!="undefined"){ChkSetSelect(ctlname);}
    //加载标签
    if(typeof(tabnum)!="undefined"){StartTab(tabnum);}
    if(typeof(tabnum2)!="undefined"){StartTab2(tabnum2);}
    //加载提示
    if(typeof(processtip)!="undefined"){SetPrm(prm);}
    //加载焦点
    if(typeof(isfocus)!="undefined")
    {
        if(isfocus==1)
                ChkSetFocus('tbName');
        else
        if(isfocus==2)
           ChkSetFocus('tbCon');
    }
}

function SetPrm()
{
	prm = Sys.WebForms.PageRequestManager.getInstance();
	if (Sys && Sys.WebForms && Sys.WebForms.PageRequestManager)
	{
	    prm = Sys.WebForms.PageRequestManager.getInstance();
	}
	
	if (prm)
	{
	    prm.add_initializeRequest(InitializeRequest);
        prm.add_endRequest(EndRequest);
	}
}

function InitializeRequest(sender, args) {

    if (prm.get_isInAsyncPostBack()) {

        args.set_cancel(true);
    }
    postBackElement = args.get_postBackElement();
    parent.document.getElementById("test").style.display = "block";                
    parent.document.getElementById("btntest").onclick = CancelAsyncPostBack;
    //parent.document.getElementById("divBackground").style.display = "block";
}

function EndRequest(sender, args) 
{
    parent.document.getElementById("test").style.display = "none";
   // parent.document.getElementById("divBackground").style.display = "none";
}

function EndRequest2() 
{
    parent.document.getElementById("test").style.display = "none";
   // parent.document.getElementById("divBackground").style.display = "none";
}

function CancelAsyncPostBack() {

    if (prm.get_isInAsyncPostBack()) 
    {
        prm.abortPostBack();
    }
}