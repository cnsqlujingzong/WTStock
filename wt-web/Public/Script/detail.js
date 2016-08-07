
function ChkClean()
{
    return confirm("确认要清空明细数据吗？"); 
}

//乘法函数，用来得到精确的乘法结果
//说明：javascript的乘法结果会有误差，在两个浮点数相乘的时候会比较明显。这个函数返回较为精确的乘法结果。
//调用：accMul(arg1,arg2)
//返回值：arg1乘以arg2的精确结果
function accMul3(arg1,arg2,arg3)
{
     var m=0,s1=arg1.toString(),s2=arg2.toString(),s3=arg3.toString();
     try{m+=s1.split(".")[1].length}catch(e){}
     try{m+=s2.split(".")[1].length}catch(e){}
     try{m+=s3.split(".")[1].length}catch(e){}
     return Number(s1.replace(".",""))*Number(s2.replace(".",""))*Number(s3.replace(".",""))/Math.pow(10,m)
}

function accMul2(arg1,arg2)
{
     var m=0,s1=arg1.toString(),s2=arg2.toString();
     try{m+=s1.split(".")[1].length}catch(e){}
     try{m+=s2.split(".")[1].length}catch(e){}
     return Number(s1.replace(".",""))*Number(s2.replace(".",""))/Math.pow(10,m)
}
//除法函数，用来得到精确的除法结果
// 说明：javascript的除法结果会有误差，在两个浮点数相除的时候会比较明显。这个函数返回较为精确的除法结果。
//调用：accDiv(arg1,arg2)
//返回值：arg1除以arg2的精确结果
function accDiv(arg1, arg2)
{
    var t1 = 0, t2 = 0, r1, r2;
    try { t1 = arg1.toString().split(".")[1].length } catch (e) { }
    try { t2 = arg2.toString().split(".")[1].length } catch (e) { }
    with (Math) {
        r1 = Number(arg1.toString().replace(".", ""))
        r2 = Number(arg2.toString().replace(".", ""))
        return (r1 / r2) * pow(10, t2 - t1);
    }
}
 
//乘法函数，用来得到精确的乘法结果
//说明：javascript的乘法结果会有误差，在两个浮点数相乘的时候会比较明显。这个函数返回较为精确的乘法结果。
//调用：accMul(arg1,arg2)
//返回值：arg1乘以 arg2的精确结果
function accMul(arg1, arg2)
{
    var m = 0, s1 = arg1.toString(), s2 = arg2.toString();
    try { m += s1.split(".")[1].length } catch (e) { }
    try { m += s2.split(".")[1].length } catch (e) { }
    return Number(s1.replace(".", "")) * Number(s2.replace(".", "")) / Math.pow(10, m)
}

//加法函数，用来得到精确的加法结果
//说明：javascript的加法结果会有误差，在两个浮点数相加的时候会比较明显。这个函数返回较为精确的加法结果。
//调用：accAdd(arg1,arg2)
// 返回值：arg1加上arg2的精确结果
function accAdd(arg1, arg2)
{
    var r1, r2, m, c;
    try { r1 = arg1.toString().split(".")[1].length } catch (e) { r1 = 0 }
    try { r2 = arg2.toString().split(".")[1].length } catch (e) { r2 = 0 }
    c = Math.abs(r1 - r2);
    m = Math.pow(10, Math.max(r1, r2))
    if (c > 0) {
        var cm = Math.pow(10, c);
        if (r1 > r2) {
            arg1 = Number(arg1.toString().replace(".", ""));
            arg2 = Number(arg2.toString().replace(".", "")) * cm;
        }
        else {
            arg1 = Number(arg1.toString().replace(".", "")) * cm;
            arg2 = Number(arg2.toString().replace(".", ""));
        }
    }
    else {
        arg1 = Number(arg1.toString().replace(".", ""));
        arg2 = Number(arg2.toString().replace(".", ""));
    }
    return (arg1 + arg2) / m
}
 
//减法函数，用来得到精确的减法结果
//说明：javascript的减法结果会有误差，在两个浮点数相减的时候会比较明显。这个函数返回较为精确的减法结果。
//调用：accSub(arg1,arg2)
// 返回值：arg1加上arg2的精确结果
function accSub(arg1,arg2)
{
　　 var r1,r2,m,n;
　　 try{r1=arg1.toString().split(".")[1].length}catch(e){r1=0}
　　 try{r2=arg2.toString().split(".")[1].length}catch(e){r2=0}
　　 m=Math.pow(10,Math.max(r1,r2));
　　 //last modify by deeka
　　 //动态控制精度长度
　　 n=(r1>=r2)?r1:r2;
　　 return ((arg1*m-arg2*m)/m).toFixed(n);
}

function cc(s)
{
    if(/[^0-9\.]/.test(s)) return "invalid value";
    s=s.replace(/^(\d*)$/,"$1.");
    s=(s+"00").replace(/(\d*\.\d\d)\d*/,"$1");
    s=s.replace(/,(\d\d)$/,".$1");
    return s.replace(/^\./,"0.");
}

//检查输入
function ValidateNum(obj,p,t,iflag,r,ra,ga)
{
    if(isNull(obj.value))
    {
        obj.value=obj.getAttribute("oldNum");
    }
    
    if(isMoney(obj.value))
    {
        var a=accMul2(parseFloat($(p).value),parseFloat(obj.value));
        $(t).innerHTML=cc(a.toString());
        
        var b=accSub(accAdd(parseFloat($("tbAmount").value),a),$(t).getAttribute("oldNum"));
        $("tbAmount").value=cc(b.toString());
        if(iflag==1)
        {
            var x=accMul2(parseFloat($(r).value),parseFloat(a));
            $(ra).innerHTML=cc(x.toString());
            var gax=accAdd(parseFloat(a),parseFloat(x));
            $(ga).innerHTML=cc(gax.toString());
            
            var j=accSub(accAdd(parseFloat($("tbGoodsAmount").value),gax),$(ga).getAttribute("oldNum"));
            $("tbInCash").value=$("tbGoodsAmount").value=cc(j.toString());
            
            $(r).setAttribute("oldNum",$(r).innerHTML);
            $(ra).setAttribute("oldNum",$(ra).innerHTML);
            $(ga).setAttribute("oldNum",$(ga).innerHTML);
        }
        else
        if(iflag==2)
        {
            var x=accMul2(parseFloat($(r).value),parseFloat(a));
            $(ra).innerHTML=cc(x.toString());
            var gax=accAdd(parseFloat(a),parseFloat(x));
            $(ga).innerHTML=cc(gax.toString());
            
            var j=accSub(accAdd(parseFloat($("tbGoodsAmount").value),gax),$(ga).getAttribute("oldNum"));
            $("tbGoodsAmount").value=cc(j.toString());
            $(r).setAttribute("oldNum",$(r).innerHTML);
            $(ra).setAttribute("oldNum",$(ra).innerHTML);
            $(ga).setAttribute("oldNum",$(ga).innerHTML);
        }
        
        var q=accSub(accAdd(parseFloat($("tbAQty").value),parseFloat(obj.value)),$(obj).getAttribute("oldNum"));
        $("tbAQty").value=cc(q.toString());
        
        $(t).setAttribute("oldNum",$(t).innerHTML);
        obj.setAttribute("oldNum",obj.value);
   }
    else
    {
        window.alert("格式不正确！必须是数字");
        obj.value=obj.getAttribute("oldNum");
        obj.select();
        return false;
    }
}

function ValidateMoney(obj,n,t,iflag,r,ra,ga)
{
    if(isNull(obj.value))
    {
        obj.value=obj.getAttribute("oldNum");
    }
    
    if(isMoney(obj.value))
    {
        var a=accMul2(parseFloat($(n).value),parseFloat(obj.value))
        $(t).innerHTML=cc(a.toString());
        
        var b=accSub(accAdd(parseFloat($("tbAmount").value),a),$(t).getAttribute("oldNum"));
        $("tbAmount").value=cc(b.toString());
        if(iflag==1)
        {
            var x=accMul2(parseFloat($(r).value),parseFloat(a));
            $(ra).innerHTML=cc(x.toString());
            var gax=accAdd(parseFloat(a),parseFloat(x));
            $(ga).innerHTML=cc(gax.toString());
            
            var j=accSub(accAdd(parseFloat($("tbGoodsAmount").value),gax),$(ga).getAttribute("oldNum"));
            $("tbInCash").value=$("tbGoodsAmount").value=cc(j.toString());
            $(r).setAttribute("oldNum",$(r).innerHTML);
            $(ra).setAttribute("oldNum",$(ra).innerHTML);
            $(ga).setAttribute("oldNum",$(ga).innerHTML);
        }
        else
        if(iflag==2)
        {
            var x=accMul2(parseFloat($(r).value),parseFloat(a));
            $(ra).innerHTML=cc(x.toString());
            var gax=accAdd(parseFloat(a),parseFloat(x));
            $(ga).innerHTML=cc(gax.toString());
            
            var j=accSub(accAdd(parseFloat($("tbGoodsAmount").value),gax),$(ga).getAttribute("oldNum"));
            $("tbGoodsAmount").value=cc(j.toString());
            $(r).setAttribute("oldNum",$(r).innerHTML);
            $(ra).setAttribute("oldNum",$(ra).innerHTML);
            $(ga).setAttribute("oldNum",$(ga).innerHTML);
        }
        
        $(t).setAttribute("oldNum",$(t).innerHTML);
        obj.setAttribute("oldNum",obj.value);
   }
    else
    {
        window.alert("格式不正确！必须是金额");
        obj.value=obj.getAttribute("oldNum");
        obj.select();
        return false;
    }
}

function ValidateRate(obj,n,t,iflag,r,ra,ga)
{
    if(isNull(obj.value))
    {
        obj.value=obj.getAttribute("oldNum");
    }
    
    if(isMoney(obj.value))
    {
        var a=accMul2(parseFloat($(n).value),parseFloat($(r).value))
        $(t).innerHTML=cc(a.toString());
        
        var b=accSub(accAdd(parseFloat($("tbAmount").value),a),$(t).getAttribute("oldNum"));
        $("tbAmount").value=cc(b.toString());
        if(iflag==1)
        {
            var x=accMul2(parseFloat(obj.value),parseFloat(a));
            $(ra).innerHTML=cc(x.toString());
            var gax=accAdd(parseFloat(a),parseFloat(x));
            $(ga).innerHTML=cc(gax.toString());
            
            var j=accSub(accAdd(parseFloat($("tbGoodsAmount").value),gax),$(ga).getAttribute("oldNum"));
            $("tbInCash").value=$("tbGoodsAmount").value=cc(j.toString());
            $(r).setAttribute("oldNum",$(r).innerHTML);
            $(ra).setAttribute("oldNum",$(ra).innerHTML);
            $(ga).setAttribute("oldNum",$(ga).innerHTML);
        }
        else
        if(iflag==2)
        {
            var x=accMul2(parseFloat(obj.value),parseFloat(a));
            $(ra).innerHTML=cc(x.toString());
            var gax=accAdd(parseFloat(a),parseFloat(x));
            $(ga).innerHTML=cc(gax.toString());
            
            var j=accSub(accAdd(parseFloat($("tbGoodsAmount").value),gax),$(ga).getAttribute("oldNum"));
            $("tbGoodsAmount").value=cc(j.toString());
            $(r).setAttribute("oldNum",$(r).innerHTML);
            $(ra).setAttribute("oldNum",$(ra).innerHTML);
            $(ga).setAttribute("oldNum",$(ga).innerHTML);
        }
        
        $(t).setAttribute("oldNum",$(t).innerHTML);
        obj.setAttribute("oldNum",obj.value);
   }
    else
    {
        window.alert("格式不正确！");
        obj.value=obj.getAttribute("oldNum");
        obj.select();
        return false;
    }
}

function ChkAmount(obj,t,q,iflag,ga)
{
    var b=accSub(parseFloat($("tbAmount").value),parseFloat($(t).innerHTML));
    var c=accSub(parseFloat($("tbAQty").value),parseFloat($(q).value));
    $("tbAmount").value=cc(b.toString());
    if(iflag==1)
        {
            var x=accSub(parseFloat($("tbGoodsAmount").value),parseFloat($(ga).innerHTML));
            $("tbInCash").value=$("tbGoodsAmount").value=cc(x.toString());
        }
        else
        {
            if(iflag==2)
            {
                var x=accSub(parseFloat($("tbGoodsAmount").value),parseFloat($(ga).innerHTML));
                $("tbGoodsAmount").value=cc(x.toString());
            }
        }
    $("tbAQty").value=cc(c.toString());
}

//检查输入
function ValidateNumsm(obj,p,tax,taxmoney,t)
{
    if(isNull(obj.value))
    {
        obj.value=obj.getAttribute("oldNum");
    }
    
    if(isMoney(obj.value))
    {
        var a=accMul2(parseFloat($(p).value),parseFloat(obj.value));
        var taxamount=accMul2(parseFloat($(tax).value),a);
        var tt=a+taxamount;
        $(t).innerHTML=cc(tt.toString());
        $(taxmoney).innerHTML=taxamount;
       
        $(t).setAttribute("oldNum",$(t).innerHTML);
        obj.setAttribute("oldNum",obj.value);
   }
    else
    {
        window.alert("格式不正确！必须是数字");
        obj.value=obj.getAttribute("oldNum");
        obj.select();
        return false;
    }
}

function ValidateMoneysm(obj,n,tax,taxmoney,t)
{
    if(isNull(obj.value))
    {
        obj.value=obj.getAttribute("oldNum");
    }
    if(isMoney(obj.value))
    {
        var a=accMul2(parseFloat($(n).value),parseFloat(obj.value))
        var taxamount=accMul2(parseFloat($(tax).value),a);
        var tt=a+taxamount;
        $(t).innerHTML=cc(tt.toString());
        $(taxmoney).innerHTML=taxamount;
        
        $(t).setAttribute("oldNum",$(t).innerHTML);
        obj.setAttribute("oldNum",obj.value);
   }
    else
    {
        window.alert("格式不正确！必须是金额");
        obj.value=obj.getAttribute("oldNum");
        obj.select();
        return false;
    }
}

function ValidateTaxsm(obj,n,p,taxmoney,t)
{
    if(isNull(obj.value))
    {
        obj.value=obj.getAttribute("oldNum");
    }
    if(isMoney(obj.value))
    {
        var a=accMul2(parseFloat($(p).value),parseFloat($(n).value))
        var taxamount=accMul2(parseFloat(obj.value),a);
        var tt=a+taxamount;
        $(t).innerHTML=cc(tt.toString());
        $(taxmoney).innerHTML=taxamount;
        
        $(t).setAttribute("oldNum",$(t).innerHTML);
        obj.setAttribute("oldNum",obj.value);
   }
    else
    {
        window.alert("格式不正确！必须是数字");
        obj.value=obj.getAttribute("oldNum");
        obj.select();
        return false;
    }
}

function ValidateNuma(obj)
{
    if(isNull(obj.value))
    {
        obj.value=obj.getAttribute("oldNum");
    }
    
    if(isMoney(obj.value))
    {
        var q=accSub(accAdd(parseFloat($("tbAQty").value),parseFloat(obj.value)),$(obj).getAttribute("oldNum"));
        $("tbAQty").value=cc(q.toString());
        obj.setAttribute("oldNum",obj.value);
    }
    else
    {
        window.alert("格式不正确！必须是数字");
        obj.value=obj.getAttribute("oldNum");
        obj.select();
        return false;
    }
}
function ChkAmounta(obj,q)
{
    var c=accSub(parseFloat($("tbAQty").value),parseFloat($(q).value));
    $("tbAQty").value=cc(c.toString());
}
function ChkAmounts(obj,q)
{
    var c=accSub(parseFloat($("tbAmount").value),parseFloat($(q).value));
    $("tbAmount").value=cc(c.toString());
}
function ValidateNumd(obj,p,t)
{
    if(isNull(obj.value))
    {
        obj.value=obj.getAttribute("oldNum");
    }
    
    if(isMoney(obj.value))
    {
        var a=accMul2(parseFloat($(p).value),parseFloat(obj.value))
        $(t).innerHTML=cc(a.toString());
        
        var b=accSub(accAdd(parseFloat($("tbAmount").value),a),$(t).getAttribute("oldNum"));
        $("tbAmount").value=cc(b.toString());
        
        $(t).setAttribute("oldNum",$(t).innerHTML);
        obj.setAttribute("oldNum",obj.value);
   }
    else
    {
        window.alert("格式不正确！必须是数字");
        obj.value=obj.getAttribute("oldNum");
        obj.select();
        return false;
    }
}

function chkAccount()
{
    var ddlgradelevel=$("ddlAccount");
    for(var i=0;i<ddlgradelevel.options.length;i++)
    {
        if(ddlgradelevel.options[i].text=="")
        {
            ddlgradelevel.options[i].selected=true;
        }
    }
}

function chkPay()
{
    if($("ddlAccount").value=="-1")
        $('cbPay').checked=true;
    else
        $('cbPay').checked=false;
}

function ValiSFK()
{
    if(!isMoney($("tbRecMoney").value))
    {
        window.alert("格式不正确！必须是金额");
        $("tbRecMoney").select();
        return false;
    }
    
    if(!isMoney($("tbPreMoney").value))
    {
        window.alert("格式不正确！必须是金额");
        $("tbPreMoney").select();
        return false;
    }
    if(!isMoney($("tbRealMoney").value))
    {
        window.alert("格式不正确！必须是金额");
        $("tbRealMoney").select();
        return false;
    }
    
    var c=accSub(parseFloat($("tbRecMoney").value),parseFloat($("tbPreMoney").value));
    $("tbRealMoney").value=c.toString();
}

function ValiSFKA()
{
    if(!isMoney($("tbRecMoney").value))
    {
        window.alert("格式不正确！必须是金额");
        $("tbRecMoney").select();
        return false;
    }
    
    if(!isMoney($("tbPreMoney").value))
    {
        window.alert("格式不正确！必须是金额");
        $("tbPreMoney").select();
        return false;
    }
    if(!isMoney($("tbRealMoney").value))
    {
        window.alert("格式不正确！必须是金额");
        $("tbRealMoney").select();
        return false;
    }
    
    var c=accAdd(parseFloat($("tbRealMoney").value),parseFloat($("tbPreMoney").value));
    $("tbRecMoney").value=c.toString();
}

//检查销售管理输入
function ValidateNumsel(obj,p,d,t,r,ra,ga)
{
    if(isNull(obj.value))
    {
        obj.value=obj.getAttribute("oldNum");
    }
    
    if(isMoney(obj.value))
    {
        var a=accMul3(parseFloat($(p).value),parseFloat(obj.value),parseFloat($(d).value));
        $(t).innerHTML=cc(a.toString());
        
        var b=accSub(accAdd(parseFloat($("tbAmount").value),a),$(t).getAttribute("oldNum"));
        $("tbAmount").value=cc(b.toString());
        
        var x = accMul2(1, parseFloat(a));
            //accMul2(parseFloat($(r).value), parseFloat(a));
        $(ra).innerHTML=cc(x.toString());
        var gax=accAdd(parseFloat(a),parseFloat(x));
        $(ga).innerHTML=cc(gax.toString());
        //by coding
        var se = $("ddl_branchFax").value;
        var lv = 1;
        var j;
        if (se != "") {
            lv = parseFloat(se.split("-")[1]) + 1;

        }
        j = b ;
     //bu coding   var j=accSub(accAdd(parseFloat($("tbGoodsAmount").value),gax),$(ga).getAttribute("oldNum"));
        $("tbInCash").value=$("tbGoodsAmount").value=cc(j.toString());
        
        var q=accSub(accAdd(parseFloat($("tbAQty").value),parseFloat(obj.value)),$(obj).getAttribute("oldNum"));
        $("tbAQty").value=cc(q.toString());
        
        $(t).setAttribute("oldNum",$(t).innerHTML);
        obj.setAttribute("oldNum",obj.value);
        $(r).setAttribute("oldNum",$(r).innerHTML);
        $(ra).setAttribute("oldNum",$(ra).innerHTML);
        $(ga).setAttribute("oldNum",$(ga).innerHTML);
   }
    else
    {
        window.alert("格式不正确！必须是数字");
        obj.value=obj.getAttribute("oldNum");
        obj.select();
        return false;
    }
}

function ValidateMoneysel(obj,n,d,t,r,ra,ga)
{
    if(isNull(obj.value))
    {
        obj.value=obj.getAttribute("oldNum");
    }
    
    if(isMoney(obj.value))
    {
        var a=accMul3(parseFloat($(n).value),parseFloat(obj.value),parseFloat($(d).value));
        $(t).innerHTML=cc(a.toString());
        
        var b=accSub(accAdd(parseFloat($("tbAmount").value),a),$(t).getAttribute("oldNum"));
        $("tbAmount").value=cc(b.toString());
        var x = accMul2(1, parseFloat(a));
            //accMul2(parseFloat($(r).value), parseFloat(a));
        $(ra).innerHTML=cc(x.toString());
        var gax=accAdd(parseFloat(a),parseFloat(x));
        $(ga).innerHTML=cc(gax.toString());
        //by coding
        var se = $("ddl_branchFax").value;
        var lv = 1;
        var j;
        if (se != "") {
            lv = parseFloat(se.split("-")[1]) + 1;

        }
        j = b;
     //by coding   var j=accSub(accAdd(parseFloat($("tbGoodsAmount").value),gax),$(ga).getAttribute("oldNum"));
        $("tbInCash").value=$("tbGoodsAmount").value=cc(j.toString());
        
        $(t).setAttribute("oldNum",$(t).innerHTML);
        obj.setAttribute("oldNum",obj.value);
      //  $(r).setAttribute("oldNum",$(r).innerHTML);
        $(ra).setAttribute("oldNum",$(ra).innerHTML);
        $(ga).setAttribute("oldNum",$(ga).innerHTML);
   }
    else
    {
        window.alert("格式不正确！必须是金额");
        obj.value=obj.getAttribute("oldNum");
        obj.select();
        return false;
    }
}

function ChkAmountsel(obj,t,q,r,ra,ga)
{
    var b=accSub(parseFloat($("tbAmount").value),parseFloat($(t).innerHTML));
    $("tbAmount").value=cc(b.toString());
    var x=accSub(parseFloat($("tbGoodsAmount").value),parseFloat($(ga).innerHTML));
    $("tbInCash").value=$("tbGoodsAmount").value=cc(x.toString());
    var c=accSub(parseFloat($("tbAQty").value),parseFloat($(q).value));
    $("tbAQty").value=cc(c.toString());
}
function ValidateRatesel(obj,n,d,t,r,ra,ga)
{
    if(isNull(obj.value))
    {
        obj.value=obj.getAttribute("oldNum");
    }
    
    if(isMoney(obj.value))
    {
        var a=accMul3(parseFloat($(n).value),parseFloat($(d).value),parseFloat($(r).value))
        $(t).innerHTML=cc(a.toString());
        
        var b=accSub(accAdd(parseFloat($("tbAmount").value),a),$(t).getAttribute("oldNum"));
        $("tbAmount").value=cc(b.toString());
        
        var x=accMul2(parseFloat(obj.value),parseFloat(a));
        $(ra).innerHTML=cc(x.toString());
        var gax=accAdd(parseFloat(a),parseFloat(x));
        $(ga).innerHTML=cc(gax.toString());
            
        var j=accSub(accAdd(parseFloat($("tbGoodsAmount").value),gax),$(ga).getAttribute("oldNum"));
        $("tbInCash").value=$("tbGoodsAmount").value=cc(j.toString());
        
        $(r).setAttribute("oldNum",$(r).innerHTML);
        $(ra).setAttribute("oldNum",$(ra).innerHTML);
        $(ga).setAttribute("oldNum",$(ga).innerHTML);
        
        $(t).setAttribute("oldNum",$(t).innerHTML);
        obj.setAttribute("oldNum",obj.value);
   }
    else
    {
        window.alert("格式不正确！");
        obj.value=obj.getAttribute("oldNum");
        obj.select();
        return false;
    }
}
//销售订单用的
function ValidateNumselp(obj,p,d,t,r,ra,ga)
{
    if(isNull(obj.value))
    {
        obj.value=obj.getAttribute("oldNum");
    }
    
    if(isMoney(obj.value))
    {
        var a=accMul3(parseFloat($(p).value),parseFloat(obj.value),parseFloat($(d).value));
        $(t).innerHTML=cc(a.toString());
        
        var b=accSub(accAdd(parseFloat($("tbAmount").value),a),$(t).getAttribute("oldNum"));
        $("tbAmount").value=cc(b.toString());
        
        var x = accMul2(1, parseFloat(a));
        //accMul2(parseFloat($(r).value),parseFloat(a));
        $(ra).innerHTML=cc(x.toString());
        var gax=accAdd(parseFloat(a),parseFloat(x));
        $(ga).innerHTML=cc(gax.toString());
         
        //by coding
        var se = $("ddl_branchFax").value;
        var lv = 1;
        var j;
        if (se != "") {
            lv = parseFloat(se.split("-")[1]) + 1;
         
        }
        j =b ;
       // by coding   var j=accSub(accAdd(parseFloat($("tbGoodsAmount").value),gax),$(ga).getAttribute("oldNum"));
        $("tbGoodsAmount").value=cc(j.toString());
        
        var q=accSub(accAdd(parseFloat($("tbAQty").value),parseFloat(obj.value)),$(obj).getAttribute("oldNum"));
        $("tbAQty").value=cc(q.toString());
        
        $(t).setAttribute("oldNum",$(t).innerHTML);
        obj.setAttribute("oldNum",obj.value);
        $(r).setAttribute("oldNum",$(r).innerHTML);
        $(ra).setAttribute("oldNum",$(ra).innerHTML);
        $(ga).setAttribute("oldNum",$(ga).innerHTML);
   }
    else
    {
        window.alert("格式不正确！必须是数字");
        obj.value=obj.getAttribute("oldNum");
        obj.select();
        return false;
    }
}

function ValidateMoneyselp(obj,n,d,t,r,ra,ga)
{
    if(isNull(obj.value))
    {
        obj.value=obj.getAttribute("oldNum");
    }
    
    if(isMoney(obj.value))
    {
        var a=accMul3(parseFloat($(n).value),parseFloat(obj.value),parseFloat($(d).value));
        $(t).innerHTML=cc(a.toString());
        
        var b=accSub(accAdd(parseFloat($("tbAmount").value),a),$(t).getAttribute("oldNum"));
        $("tbAmount").value=cc(b.toString());
        var x = accMul2(1, parseFloat(a));
            //accMul2(parseFloat($(r).value), parseFloat(a));
        $(ra).innerHTML=cc(x.toString());
        var gax=accAdd(parseFloat(a),parseFloat(x));
        $(ga).innerHTML=cc(gax.toString());
        //by coding
        var se = $("ddl_branchFax").value;
        var lv = 1;
        var j;
        if (se != "") {
            lv = parseFloat(se.split("-")[1]) + 1;
       
        }
        j = b ;
      //by coding  var j=accSub(accAdd(parseFloat($("tbGoodsAmount").value),gax),$(ga).getAttribute("oldNum"));
        $("tbGoodsAmount").value=cc(j.toString());
        
        $(t).setAttribute("oldNum",$(t).innerHTML);
        obj.setAttribute("oldNum",obj.value);
        //$(r).setAttribute("oldNum",$(r).innerHTML);
        $(ra).setAttribute("oldNum",$(ra).innerHTML);
        $(ga).setAttribute("oldNum",$(ga).innerHTML);
   }
    else
    {
        window.alert("格式不正确！必须是金额");
        obj.value=obj.getAttribute("oldNum");
        obj.select();
        return false;
    }
}

function ChkAmountselp(obj,t,q,r,ra,ga)
{
    var b=accSub(parseFloat($("tbAmount").value),parseFloat($(t).innerHTML));
    $("tbAmount").value=cc(b.toString());
    var x=accSub(parseFloat($("tbGoodsAmount").value),parseFloat($(ga).innerHTML));
    $("tbGoodsAmount").value=cc(x.toString());
    var c=accSub(parseFloat($("tbAQty").value),parseFloat($(q).value));
    $("tbAQty").value=cc(c.toString());
}

function ValidateRateselp(obj,n,d,t,r,ra,ga)
{
    if(isNull(obj.value))
    {
        obj.value=obj.getAttribute("oldNum");
    }
    
    if(isMoney(obj.value))
    {
        var a=accMul3(parseFloat($(n).value),parseFloat($(d).value),parseFloat($(r).value))
        $(t).innerHTML=cc(a.toString());
        
        var b=accSub(accAdd(parseFloat($("tbAmount").value),a),$(t).getAttribute("oldNum"));
        $("tbAmount").value=cc(b.toString());
        
        var x=accMul2(parseFloat(obj.value),parseFloat(a));
        $(ra).innerHTML=cc(x.toString());
        var gax=accAdd(parseFloat(a),parseFloat(x));
        $(ga).innerHTML=cc(gax.toString());
            
        var j=accSub(accAdd(parseFloat($("tbGoodsAmount").value),gax),$(ga).getAttribute("oldNum"));
        $("tbGoodsAmount").value=cc(j.toString());
        
        $(r).setAttribute("oldNum",$(r).innerHTML);
        $(ra).setAttribute("oldNum",$(ra).innerHTML);
        $(ga).setAttribute("oldNum",$(ga).innerHTML);
        
        $(t).setAttribute("oldNum",$(t).innerHTML);
        obj.setAttribute("oldNum",obj.value);
   }
    else
    {
        window.alert("格式不正确！");
        obj.value=obj.getAttribute("oldNum");
        obj.select();
        return false;
    }
}

//销售订单截至

function ChkFeeAdd(obj,t,x)
{
    if(isNull(obj.value))
    {
        obj.value=obj.getAttribute("oldNum");
    }
    
    if(isMoney(obj.value))
    {
        var a=accSub(accAdd(parseFloat($(t).innerHTML),parseFloat(obj.value)),$(obj).getAttribute("oldNum"));
        $(t).innerHTML=cc(a.toString());
        
        var b=accSub(accAdd(parseFloat($("tbAmount").value),parseFloat(obj.value)),$(obj).getAttribute("oldNum"));
        $("tbRealMoney").value=$("tbAmount").value=cc(b.toString());
        
        $(t).setAttribute("oldNum",$(t).innerHTML);
        obj.setAttribute("oldNum",obj.value);
   }
    else
    {
        window.alert("格式不正确！必须是金额");
        obj.value=obj.getAttribute("oldNum");
        obj.select();
        return false;
    }
}

function ChkPreMoney(obj,t,x)
{
    if(isNull(obj.value))
    {
        obj.value=obj.getAttribute("oldNum");
    }
    if(isMoney(obj.value))
    {
        if(parseFloat(obj.value)>parseFloat($(t).innerHTML))
        {
            window.alert("优惠金额不能大于应收金额");
            obj.value=obj.getAttribute("oldNum");
            obj.select();
            return;
        }
        
        var b=accSub(accAdd(parseFloat($("tbPreMoney").value),parseFloat(obj.value)),$(obj).getAttribute("oldNum"));
        $("tbPreMoney").value=cc(b.toString());
        
        b=accSub(parseFloat($("tbAmount").value),parseFloat($("tbPreMoney").value));
        $("tbRealMoney").value=cc(b.toString());

        $(t).setAttribute("oldNum",$(t).innerHTML);
        obj.setAttribute("oldNum",obj.value);
   }
    else
    {
        window.alert("格式不正确！必须是金额");
        obj.value=obj.getAttribute("oldNum");
        obj.select();
        return false;
    }
}

function ChkChargeValue(obj,t,p)
{
    if(isNull(obj.value))
    {
        obj.value=obj.getAttribute("oldNum");
    }
    if(isMoney(obj.value))
    {
        var xd=accSub(parseFloat($(t).innerHTML),parseFloat($(p).value));
        if(parseFloat(obj.value)>xd)
        {
            window.alert("现结金额不能大于实收金额");
            obj.value=obj.getAttribute("oldNum");
            obj.select();
            return;
        }
        
        var b=accSub(accAdd(parseFloat($("tbChargeMoney").value),parseFloat(obj.value)),$(obj).getAttribute("oldNum"));
        $("tbChargeMoney").value=cc(b.toString());

        obj.setAttribute("oldNum",obj.value);
    }else
    {
        window.alert("格式不正确！必须是金额");
        obj.value=obj.getAttribute("oldNum");
        obj.select();
        return false;
    }
}

function ChkPBrand()
{
    var bnull=true;
    var ddlgradelevel=$("ddlBrand");
    if(!isNull($("tbBrand").value))
    {
        if($("tbBrand").value!=ddlgradelevel.options[ddlgradelevel.selectedIndex].text)
        {
            for(var i=0;i<ddlgradelevel.options.length;i++)
            {
                if(ddlgradelevel.options[i].value!="0")
                {
                    if(ddlgradelevel.options[i].text==$("tbBrand").value)
                    {
                        ddlgradelevel.options[i].selected=true;
                        bnull=false;
                        break;
                    }
                }else{$("tbBrand").value="";}
            }
            
            if(bnull)
            {
                for(var i=0;i<ddlgradelevel.options.length;i++)
                {
                    if(ddlgradelevel.options[i].text=="")
                    {
                        ddlgradelevel.options[i].selected=true;
                    }
                }
                $("tbBrand").value="";
            }
        }
    }else
    {
            for(var i=0;i<ddlgradelevel.options.length;i++)
            {
                if(ddlgradelevel.options[i].text=="")
                {
                    ddlgradelevel.options[i].selected=true;
                }
            }
    }
    
}


function ChkPClass()
{
    var bnull=true;
    var ddlgradelevel=$("ddlClass");
    if(!isNull($("tbClass").value))
    {
        if($("tbClass").value!=ddlgradelevel.options[ddlgradelevel.selectedIndex].text)
        {
            for(var i=0;i<ddlgradelevel.options.length;i++)
            {
                if(ddlgradelevel.options[i].value!="0")
                {
                    if(ddlgradelevel.options[i].text==$("tbClass").value)
                    {
                        ddlgradelevel.options[i].selected=true;
                        bnull=false;
                        break;
                    }
                }else{$("tbClass").value="";}
            }
            
            if(bnull)
            {
                for(var i=0;i<ddlgradelevel.options.length;i++)
                {
                    if(ddlgradelevel.options[i].text=="")
                    {
                        ddlgradelevel.options[i].selected=true;
                    }
                }
                $("tbClass").value="";
            }
        }
    }else
    {
            for(var i=0;i<ddlgradelevel.options.length;i++)
            {
                if(ddlgradelevel.options[i].text=="")
                {
                    ddlgradelevel.options[i].selected=true;
                }
            }
    }
}

function ChkPModel()
{
    var bnull=true;
     var ddlgradelevel=$("ddlModel");
    if(!isNull($("tbModel").value))
    {
        if($("tbModel").value!=ddlgradelevel.options[ddlgradelevel.selectedIndex].text)
        {
            for(var i=0;i<ddlgradelevel.options.length;i++)
            {
                if(ddlgradelevel.options[i].value!="0")
                {
                    if(ddlgradelevel.options[i].text==$("tbModel").value)
                    {
                        ddlgradelevel.options[i].selected=true;
                        bnull=false;
                        break;
                    }
                }else{$("tbModel").value="";}
            }
            
            if(bnull)
            {
                for(var i=0;i<ddlgradelevel.options.length;i++)
                {
                    if(ddlgradelevel.options[i].text=="")
                    {
                        ddlgradelevel.options[i].selected=true;
                    }
                }
                $("tbModel").value="";
             }
        }
    }else
    {
            for(var i=0;i<ddlgradelevel.options.length;i++)
            {
                if(ddlgradelevel.options[i].text=="")
                {
                    ddlgradelevel.options[i].selected=true;
                }
            }
    }
}


//检查输入
function ValiNum(obj,p,t)
{
    if(isNull(obj.value))
    {
        obj.value=obj.getAttribute("oldNum");
    }
    
    if(isMoney(obj.value))
    {
        var a=accMul2(parseFloat(p),parseFloat(obj.value));
        $(t).innerHTML=cc(a.toString());
        
        $(t).setAttribute("oldNum",$(t).innerHTML);
        obj.setAttribute("oldNum",obj.value);
   }
    else
    {
        window.alert("格式不正确！必须是数字");
        obj.value=obj.getAttribute("oldNum");
        obj.select();
        return false;
    }
}

function ValiMoney(obj,n,t)
{
    if(isNull(obj.value))
    {
        obj.value=obj.getAttribute("oldNum");
    }
    
    if(isMoney(obj.value))
    {
        var a=accMul2(parseFloat($(n).value),parseFloat(obj.value));
        $(t).innerHTML=cc(a.toString());
        
        $(t).setAttribute("oldNum",$(t).innerHTML);
        obj.setAttribute("oldNum",obj.value);
   }
    else
    {
        window.alert("格式不正确！必须是金额");
        obj.value=obj.getAttribute("oldNum");
        obj.select();
        return false;
    }
}
