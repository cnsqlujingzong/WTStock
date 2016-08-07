function doFresh(str)
{
    $("btnfresh").click();
    $("span_info").innerHTML=str;
    $("span_info").style.display="inline";
}
function doFreshC(str)
{
    $("btnfreshc").click();
    $("span_info").innerHTML=str;
    $("span_info").style.display="inline";
}
function cInfo()
{
    $("span_info").innerHTML="";
    $("span_info").style.display="none";
}
function setid(id)
{
    $("hfrecid").value=id;
}
function jcrm(str)
{
    if(confirm("确定要"+str+"吗?"))
    {
        $("btndel").click();
    }
}
function chkcrm(str)
{
    if($("hfreclist").value!="")
    {
        return confirm("确定要"+str+"吗?");
    }else{return false;}
}
function jcrmb(str,btn)
{
    if(confirm("确定要"+str+"吗?"))
    {
        $(btn).click();
    }
}
function allcb()
{
    $("hfreclist").value="";
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
                $("hfreclist").value=$("hfreclist").value+"^"+tr+"^";
                $(tr).style.backgroundColor="#ffffd1";}
            }
            else
            {
                chkother[i].checked=false;
                if(tr!=""){
                $("hfreclist").value=$("hfreclist").value.replace("^"+tr+"^","");
                $(tr).style.backgroundColor="";}
            }
        }
    }
}
function allcbslt(bool)
{
   $("cball").checked=bool;
   allcb();
}
function cbone(obj)
{
    var tr=obj.id;
    tr=tr.replace("cb","");
    if(obj.checked)
    {
        $("hfreclist").value=$("hfreclist").value+"^"+tr+"^";
        $(tr).style.backgroundColor="#ffffd1";
    }else
    {
        $("hfreclist").value=$("hfreclist").value.replace("^"+tr+"^","");
        $(tr).style.backgroundColor="";
    }
}