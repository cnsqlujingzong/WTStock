<%@ page language="C#"  CodeFile="interface_print.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Print_interface_print" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>άͨ.NET-ITרҵ��</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <object id="obj1"
	  classid="clsid:7CCF05A5-B572-46B2-A6E6-7AF217823FCB"
	  codebase="./WTProj1.inf"
	  width="100%"
	  height="1010"
	  align="center"
	  hspace="0"
	  vspace="0">
	  <%=Url %>
	  <%=Parm %>
	  <%=Action %>
	  </object>
        

    </div>

    </form>
</body>
</html>

