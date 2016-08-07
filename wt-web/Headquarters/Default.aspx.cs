using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.IO;
using System.Text;
using wt.DAL;
using wt.Model;

public partial class Headquarters_Default : System.Web.UI.Page
{
    protected string[] module = new string[20];//
    protected string[] modulc = new string[20];//
    protected int[] modulh = new int[20];//
    protected int[] modulh_s = new int[50];//
    protected int[] modulh_h = new int[10];//
    protected int[] menu_s = new int[10];//
    protected string[] menu_h = new string[10];
    protected string[] menu = new string[300];

    //-------------------------------
    protected string[] moduln = new string[20];//
    protected int[] modulm = new int[20];//
    string _reg;
    string _menu;
    int toolheight = 85;
    bool showol = false;
    string strtitle = "总部平台";
    protected void Page_Load(object sender, EventArgs e)
    {
        /*if (!IsPostBack)
        {
            DALUserManage daluser = new DALUserManage();
            Session["OperCode"] = "A01F8FFBA4";
            Session["Session_wtUser"] = "闫明";
            Session["Session_wtUserID"] = "9";
            Session["Session_wtPur"] = "管理组";
            Session["Session_wtPurID"] = "3";
            daluser.UpdateCode(9, "A01F8FFBA4");
        }*/
        if (Session["Session_wtUser"] == null || Session["Session_wtUserID"] == null)
        {
            Response.Write("<Script>top.location.href = 'Tip.html';</Script>");
            Response.End();
        }
        if (!IsPostBack)
        {
            //开始生产菜单
            //------------------------------
            int pur_id = int.Parse((string)Session["Session_wtPurID"]);
            if (pur_id == 0)
            {
                modulh[0] = 298;
                modulh[1] = 106;
                modulh[2] = 106;
                modulh[3] = 192;
                modulh[4] = 150;
                modulh[5] = 213;
                modulh[6] = 128;
                modulh[7] = 85;
                modulh[8] = 212;
                modulh[9] = 63;
                modulh[10] = 189;
                modulh[11] = 424;
                modulh[12] = 169;
                modulh[13] = 85;
                modulh[14] = 127;

                //存在二级菜单的项
                modulh_s[0] = 233;
                modulh_s[1] = 254;
                modulh_s[2] = 275;
                modulh_s[3] = 63;
                modulh_s[4] = 0;
                modulh_s[5] = 20;
                modulh_s[6] = 82;
                modulh_s[7] = 105;
                modulh_s[8] = 80;
                modulh_s[9] = 20;
                modulh_s[10] = 0;
                modulh_s[11] = 20;
                modulh_s[12] = 40;
                modulh_s[13] = 60;
                modulh_s[14] = 0;
                modulh_s[15] = 100;
                modulh_s[16] = 120;
                modulh_s[17] = 140;
                modulh_s[18] = 160;
                modulh_s[19] = 246;
                //--------------
                int[] lst ={ 26, 86, 146, 206, 266, 326, 386, 446, 506, 561, 621, 681, 741, 801, 836 };
                for (int i = 0; i < lst.Length; i++)
                {
                    modulm[i] = lst[i];
                }
                //--------------
            }
            //------------------------------
            else
            {
                //------------------------------------------------------------15个菜单--------------------------------
                DataSet purset = DALCommon.aa_getright(pur_id);
                DataTable purmDt = purset.Tables[0];
                int purmCount = purmDt.Rows.Count;
                if (purmCount > 0)
                {
                    string module_pur = string.Empty;
                    for (int i = 1; i <= purmCount; i++)
                    {
                        module_pur = purmDt.Rows[i - 1]["pur"].ToString();
                        if (module_pur == "0")
                        {
                            module[i - 1] = "return false;";
                            modulc[i - 1] = "style=\"color:#aaa;\"";
                            moduln[i - 1] = "style=\"display:none;\"";
                        }

                        //----------
                        modulm[i - 1] = int.Parse(module_pur);
                        //----------
                    }

                    //---------
                    modulm[12] = 1;
                    modulm[13] = 1;
                    modulm[14] = 1;

                    int[] lst ={ 26, 86, 146, 206, 266, 326, 386, 446, 506, 561, 621, 681, 741, 801, 836 };
                    int u_lt = 0;
                    int fm = modulm[0];
                    for (int u = 0; u < modulm.Length; u++)
                    {
                        if (fm > 0)
                        {
                            if (modulm[u] > 0)
                            {
                                if (u > 13)
                                {
                                    modulm[u] = lst[u_lt] - 25;
                                }
                                else
                                {
                                    modulm[u] = lst[u_lt];
                                }
                                u_lt++;
                            }
                        }
                        else
                        {
                            if (modulm[u] > 0)
                            {
                                if (u > 13)
                                {
                                    modulm[u] = lst[u_lt] - 25;
                                }
                                else
                                {
                                    modulm[u] = lst[u_lt];
                                }
                                u_lt++;
                            }
                        }
                    }
                    //---------
                    modulh[0] = 298;
                    modulh[1] = 106;
                    modulh[2] = 106;
                    modulh[3] = 192;
                    modulh[4] = 150;
                    modulh[5] = 213;
                    modulh[6] = 128;
                    modulh[7] = 85;
                    modulh[8] = 212;
                    modulh[9] = 63;
                    modulh[10] = 189;
                    modulh[11] = 424;
                    modulh[12] = 169;
                    modulh[13] = 85;
                    modulh[14] = 127;

                    menu[205] = "style=\"display:none;\"";
                    modulh_s[0] = 233;
                    modulh_s[1] = 254;
                    modulh_s[2] = 275;
                    modulh_s[3] = 63;
                    modulh_s[4] = 0;
                    modulh_s[5] = 20;
                    modulh_s[6] = 82;
                    modulh_s[7] = 105;
                    modulh_s[8] = 80;
                    modulh_s[9] = 20;
                    modulh_s[10] = 0;
                    modulh_s[11] = 20;
                    modulh_s[12] = 40;
                    modulh_s[13] = 60;
                    modulh_s[14] = 0;
                    modulh_s[15] = 100;
                    modulh_s[16] = 120;
                    modulh_s[17] = 140;
                    modulh_s[18] = 160;
                    modulh_s[19] = 246;
                    //--------------------------------------
                }
            }
            //------------------------------

            hfServerDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
            hfUser.Value = (string)(Session["Session_wtUser"]);
            hfPurview.Value = (string)(Session["Session_wtPur"]);
            
            DALSysParm dalsysp = new DALSysParm();
            SysParmInfo syspinfo = dalsysp.GetSysParm();

            if (syspinfo != null)
            {
                strtitle = syspinfo.CorpName;

                if (syspinfo.SysName != string.Empty)
                    strtitle += "-" + syspinfo.SysName;

                this.Page.Title = strtitle;
            }
            if (syspinfo.bSim)
            {
                toolheight = 107;
                modulh[13] = 107;
                showol = true;
            }

            int iOperator = int.Parse((string)(Session["Session_wtUserID"]));
            rptool.DataSource = DALCommon.aa_gettoolbar(1, iOperator).Tables[0];
            rptool.DataBind();

            //-------------------------------------------此处开始进行程序更新--------------//

            /*** by coding
            DataTable dtdata = DALCommon.GetList("Version", "top 1 ID", " 1=1 order by RecID desc").Tables[0];
            if (dtdata.Rows.Count > 0)
            {
                string version = dtdata.Rows[0]["ID"].ToString();
                UpdateSoft(version);
            }
            else
                UpdateSoft("");
            **/
            //----------程序更新完成---------------//
            //初始登陆

            DALSysVali dalsysva = new DALSysVali();
            string item1 = wt.Library.FunLibrary.StrEncode(DateTime.Now.ToString("yyyy-MM-dd"));
            string item3 = "SRSSRHSIHSJRSIHSIJSIGSJTSIISTHSTISVGSVRSVHSFTSFFSFGSFTSFJSFHSFISGFSGXSHSSHS";//running
            dalsysva.StartParm(item1, item3);

            string corp = syspinfo.CorpName;
            string num = syspinfo.BranchNum.ToString();
            string web = syspinfo.bWeb.ToString();
            string regcode = dalsysva.GetValue("ITEM2");
            string regstr = corp + web + num;
            if (syspinfo.bSim)
                regstr = regstr + "并发";
            string regcode2 = wt.Library.FunLibrary.EncodeReg(regstr);

            //非注册用户
            if (regcode != regcode)//(regcode != regcode2)
            {
                //检测试用开始日期
                string b_time = dalsysva.GetValue("ITEM1");
                try
                {
                    string r_b_time = wt.Library.FunLibrary.StrDecode(b_time);
                    int u_day = DayTs(r_b_time);
                    if (u_day > 60000 || u_day < 0)
                    {
                        SetHf("1");//试用到期
                    }
                    else
                    {
                        this.Page.Title = this.Page.Title + "(已试用了" + Convert.ToString(u_day) + "天)";
                    }
                }
                catch { SetHf("2"); }//参数被修改出错

                //检测入库单
                DALStockIN dalstkin = new DALStockIN();
                string r_s_time = dalstkin.GetBillDate();
                if (r_s_time != string.Empty)
                {
                    if (DayTs(r_s_time) > 60)
                    {
                        SetHf("3");//入库单到期
                    }
                }

                //检测服务单
                DALServices dalser = new DALServices();
                string r_o_time = dalser.GetMakeTime();
                if (r_o_time != string.Empty)
                {
                    if (DayTs(r_o_time) > 60)
                    {
                        SetHf("4");//服务单到期
                    }
                }
            }

            //注册用户
            else
            {
                
                //====================
                int bcount;
                int.TryParse(DALCommon.TCount("UserManage", ""), out bcount);
                int inum;
                int.TryParse(num, out inum);
                if (!syspinfo.bSim && bcount > inum)
                {
                    dalsysva.Update("ITEM3", "SRFSRGSIXSIGSHGSIGSIRSITSTFSTGSVRSVGSVRSVISFSSFRSFGSFJSGSSFJSFISGXSGXSGJSHT");//locked
                }

                //检查DNS是否正常
                if (DateTime.Today >= DateTime.Parse("2012-06-20"))
                {
                    try
                    {
                        string uhost = Request.Url.Host;
                        System.Net.IPAddress[] laddressList = Dns.GetHostByName(uhost).AddressList;
                        System.Net.IPAddress[] addressList = Dns.GetHostByName("www.differsoft.com").AddressList;
                        if ((laddressList[0].ToString() == addressList[0].ToString()) && !uhost.Contains("vip.differsoft.com") && !uhost.Contains("demo.differsoft.com"))
                        {
                            //dalsysva.Update("ITEM3", "SRFSRGSIXSIGSHGSIGSIRSITSTFSTGSVRSVGSVRSVISFSSFRSFGSFJSGSSFJSFISGXSGXSGJSHT");//locked
                            //return;
                        }
                        string ip = addressList[0].ToString();
                        string[] ipsplit = ip.Split('.');
                        int dierduan = int.Parse(ipsplit[1]);
                        if (ip.StartsWith("127.") || ip.StartsWith("192.168.") || ip.StartsWith("10.") || (ip.StartsWith("172.") && dierduan >= 16 && dierduan <= 31))
                        {
                            dalsysva.Update("ITEM3", "SRFSRGSIXSIGSHGSIGSIRSITSTFSTGSVRSVGSVRSVISFSSFRSFGSFJSGSSFJSFISGXSGXSGJSHT");//locked
                            return;
                        }
                    }
                    catch { }
                }

                //====================
                try
                {
                    string url = "http://www.differsoft.com/kill_get.asp?id=8";
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    req.Method = "GET";
                    req.MaximumAutomaticRedirections = 3;
                    req.Timeout = 5000;
                    HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                    Stream resst = res.GetResponseStream();
                    StreamReader sr = new StreamReader(resst);
                    string content = sr.ReadToEnd();
                    sr.Dispose();
                    resst.Dispose();
                    if (content.Contains(regcode))
                    {
                        dalsysva.Update("ITEM3", "SRFSRGSIXSIGSHGSIGSIRSITSTFSTGSVRSVGSVRSVISFSSFRSFGSFJSGSSFJSFISGXSGXSGJSHT");//locked
                    }
                }
                catch
                {

                }

                //=========================

                string ec = dalsysva.GetValue("ITEM6").ToString().Trim();
                int iec = 0;
                try
                {
                    iec = int.Parse(wt.Library.FunLibrary.StrDecode(ec));
                    //if (iec > 10)
                    //{
                    //    dalsysva.Update("ITEM3", "SRFSRGSIXSIGSHGSIGSIRSITSTFSTGSVRSVGSVRSVISFSSFRSFGSFJSGSSFJSFISGXSGXSGJSHT");//locked
                    //}
                }
                catch
                {
                    //dalsysva.Update("ITEM3", "SRFSRGSIXSIGSHGSIGSIRSITSTFSTGSVRSVGSVRSVISFSSFRSFGSFJSGSSFJSFISGXSGXSGJSHT");//locked
                }
                if (dalsysva.GetValue("ITEM5") != DateTime.Now.ToString("yyyy-MM-dd")||iec>0)
                {
                    try
                    {
                        string tel = syspinfo.Tel;
                        string zip = syspinfo.Zip;
                        string adr = syspinfo.Adr;

                        string param = "id=8";
                        param += "&CustomerInfo=公司名:" + corp + "，电话:" + tel;
                        param += "，邮编:" + zip + "，地址:" + adr + "，注册用户数:" + num + "，实际用户数:" + bcount.ToString() + "注册码:" + regcode;
                        if (syspinfo.bSim)
                            param += "，并发";
                        byte[] postBytes = Encoding.GetEncoding("GB2312").GetBytes(param);

                        HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create("http://www.differsoft.com/kill_post.asp");
                        myRequest.Method = "POST";
                        myRequest.ContentType = "application/x-www-form-urlencoded;charset=gb2312";
                        myRequest.ContentLength = postBytes.Length;
                        Stream newStream = myRequest.GetRequestStream();
                        // Send the data.
                        newStream.Write(postBytes, 0, postBytes.Length);
                        newStream.Close();
                        // Get response
                        HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                        StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.GetEncoding("GB2312"));
                        string content = reader.ReadToEnd();
                        newStream.Dispose();
                        reader.Dispose();

                        if (content.ToLower() == "ok")
                        {
                            dalsysva.Update("ITEM5", DateTime.Now.ToString("yyyy-MM-dd"));
                            dalsysva.Update("ITEM6", wt.Library.FunLibrary.StrEncode("0"));
                        }
                        else
                        {
                            dalsysva.Update("ITEM6", wt.Library.FunLibrary.StrEncode((iec + 1).ToString()));
                        }
                    }
                    catch
                    {
                        dalsysva.Update("ITEM6", wt.Library.FunLibrary.StrEncode((iec + 1).ToString()));
                    }
                }

                //=========================
            }

            //并发验证在线开启
            DataTable dt = DALCommon.GetDataList("SysParm", "bSim", "ID=1 and bSim=1").Tables[0];
            if (dt.Rows.Count > 0)
            {
                btnRefreshOnline_Click(sender, e);
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="js"></param>
    /// <param name="css"></param>
    protected void SetGy(string js, string css)
    {
        for (int i = 1; i <= 13; i++)
        {
            module[i - 1] = js;
            modulc[i - 1] = css;
        }
    }
    /// <summary>
    /// 更新软件
    /// </summary>
    protected void UpdateSoft(string version)
    {
        string sql = string.Empty;
        int fail = 0;
        if (version == "10.1.20111208" || version == "")
        {
            //表更新
            sql = "if not exists(select * from syscolumns where id=object_id('Warranty') and name='bStopUse') begin ALTER TABLE Warranty ADD bStopUse bit DEFAULT 0 WITH VALUES end";
            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，表:Warranty，升级异常:" + ex.Message.ToString());
            }

            sql = string.Empty;
            sql = "if not exists(select * from syscolumns where id=object_id('Expense') and name='Accessory') begin ALTER TABLE Expense ADD Accessory varchar(100) DEFAULT '' WITH VALUES end";
            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，表:Expense，升级异常:" + ex.Message.ToString());
            }

            sql = string.Empty;
            sql = "if not exists(select * from syscolumns where id=object_id('SysParm') and name='bSerItem') begin ALTER TABLE SysParm ADD bSerItem bit DEFAULT 0 WITH VALUES end";
            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，表:SysParm，升级异常:" + ex.Message.ToString());
            }

            //视图更新
            sql = string.Empty;
            sql = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ks_device]') and OBJECTPROPERTY(id, N'IsView') = 1) drop view [dbo].[ks_device]";
            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，视图:ks_device，升级异常:" + ex.Message.ToString());
            }
            sql = string.Empty;
            sql = " CREATE VIEW dbo.ks_device ";
            sql += " AS ";
            sql += " SELECT a.[ID], a.CustomerID, a.LinkMan, a.CusDept, a.Tel, a.Tel2, a.Fax, a.Zip, a.Adr, ";
            sql += "      ISNULL(a.ProductClassID, - 1) AS ProductClassID, ISNULL(a.ProductBrandID, - 1) ";
            sql += "      AS ProductBrandID, ISNULL(a.ProductModelID, - 1) AS ProductModelID, a.ProductSN1, ";
            sql += "      a.ProductSN2, CONVERT(char(10), a.BuyDate, 120) AS BuyDate, a.BuyFrom, a.BuyInvoice, ";
            sql += "      CONVERT(char(10), a.InstallDate, 120) AS InstallDate, a.MaintenancePeriod, ";
            sql += "      ISNULL(a.WarrantyID, - 1) AS WarrantyID, CONVERT(char(10), a.WarrantyStart, 120) ";
            sql += "      AS WarrantyStart, CONVERT(char(10), a.WarrantyEnd, 120) AS WarrantyEnd, ";
            sql += "      a.RepairTimes, CONVERT(char(10), a.Repairlately, 120) AS Repairlately, ";
            sql += "      CONVERT(char(10), a.RepairWarrantyEnd, 120) AS RepairWarrantyEnd, ";
            sql += "      CONVERT(char(10), a.ContractWarrantyStart, 120) AS ContractWarrantyStart, ";
            sql += "      CONVERT(char(10), a.ContractWarrantyEnd, 120) AS ContractWarrantyEnd, ";
            sql += "      a.ContractNO, a.Remark, b.CustomerNO, b._Name, b.pyCode, b.DeptID, ";
            sql += "      g._Name AS Warranty, g.pyCode AS WarrantyCode, c._Name AS ProductClass, ";
            sql += "      c.pyCode AS ProductClassCode, e._Name AS ProductModel, ";
            sql += "      e.pyCode AS ProductModelCode, d._Name AS ProductBrand, ";
            sql += "      d.pyCode AS ProductBrandCode, ProductAspect,b.Area,a.DeviceNO,a.BuyPrice,Property=case when a.Property=2 then '自有机' else '客户机' end";
            sql += "      ,a.userdef1,a.userdef2,a.userdef3,a.userdef4,a.userdef5,b.ClassID,h._Name as ClassName,h._Level";
            sql += " FROM  dbo.DeviceList a LEFT OUTER JOIN";
            sql += "      dbo.CustomerList b ON a.CustomerID = b.[ID] LEFT OUTER JOIN";
            sql += "      dbo.ProductClass c ON a.ProductClassID = c.[ID] LEFT OUTER JOIN";
            sql += "      dbo.ProductBrand d ON a.ProductBrandID = d.[ID] LEFT OUTER JOIN";
            sql += "      dbo.ProductModel e ON a.ProductModelID = e.[ID] AND c.[ID] = e.ClassID AND ";
            sql += "      d.[ID] = e.BrandID LEFT OUTER JOIN";
            sql += "      dbo.Warranty g ON a.WarrantyID = g.[ID] LEFT OUTER JOIN";
            sql += "      dbo.CustomerClass h ON b.ClassID=h.[ID]";

            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，视图:ks_device，升级异常:" + ex.Message.ToString());
            }

            sql = string.Empty;

            sql = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ck_stockdept]') and OBJECTPROPERTY(id, N'IsView') = 1) drop view [dbo].[ck_stockdept]";
            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，视图:ck_stockdept，升级异常:" + ex.Message.ToString());
            }

            sql = string.Empty;

            sql += "CREATE VIEW dbo.ck_stockdept";
            sql += " AS ";
            sql += " SELECT a.[ID], a.DeptID, a.StockID, a.GoodsID, a.StockLocID, a.CheckCount, a.Remark, b.StockAdmID1 as StockAdmID1,b.StockAdmID2 as StockAdmID2,";
            sql += "	 CAST(a.Stock AS decimal(18,2)) AS Stock, CAST(a.CostPrice AS decimal(18,2)) AS CostPrice,";
            sql += "	CAST(a.upWarning AS decimal(18,2)) AS upWarning, CAST(a.downWarning AS decimal(18,2)) AS downWarning, ";
            sql += "      	b._Name AS StockName, c._Name AS StockLocName, b.bReject,Reject=case when bReject=0 then '良品' else '废品' end";
            sql += " FROM dbo.StockDept a LEFT OUTER JOIN";
            sql += "      dbo.StockList b ON a.StockID = b.[ID] LEFT OUTER JOIN";
            sql += "      dbo.StockLocation c ON a.StockLocID = c.[ID]";

            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，视图:ck_stockdept，升级异常:" + ex.Message.ToString());
            }

            sql = string.Empty;
            sql = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ck_stockin]') and OBJECTPROPERTY(id, N'IsView') = 1) drop view [dbo].[ck_stockin]";
            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，视图:ck_stockin，升级异常:" + ex.Message.ToString());
            }
            sql = string.Empty;
            sql += "CREATE VIEW dbo.ck_stockin";
            sql += " AS ";
            sql += " SELECT a.[ID], b._Name AS Dept,a.DeptID, a.BillID, CONVERT(char(10), a._Date, 120) AS _Date, ";
            sql += "      a.OperatorID, a.PersonID, a.ReasonID, a.Type, a.OperationID, ";
            sql += "      Status=CASE WHEN a.Status=1 THEN '待审核' ELSE '已审核' END, ";
            sql += "      CONVERT(char(10), a.ChkDate, 120) AS ChkDate, a.ChkOperatorID, a.Remark, c._Name AS Operator, ";
            sql += "      d._Name AS Person, f._Name AS Reason, e._Name AS ChkOperator, ";
            sql += "      f.pyCode AS ReasonCode,dbo.aa_gettotalprofit(a.[ID],1) as Total";
            sql += " FROM dbo.StockIN a LEFT OUTER JOIN";
            sql += "      dbo.BranchList b ON a.DeptID = b.[ID] LEFT OUTER JOIN";
            sql += "      dbo.StaffList c ON a.OperatorID = c.[ID] LEFT OUTER JOIN";
            sql += "      dbo.StaffList d ON a.PersonID = d.[ID] LEFT OUTER JOIN";
            sql += "      dbo.StaffList e ON a.ChkOperatorID = e.[ID] LEFT OUTER JOIN";
            sql += "      dbo.INStockReason f ON a.ReasonID = f.[ID]";

            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，视图:ck_stockin，升级异常:" + ex.Message.ToString());
            }

            sql = string.Empty;
            sql += "drop view [dbo].[ck_stockdepthb]";
            sql = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ck_stockdepthb]') and OBJECTPROPERTY(id, N'IsView') = 1) drop view [dbo].[ck_stockdepthb]";

            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，视图:ck_stockdepthb，升级异常:" + ex.Message.ToString());
            }

            sql = string.Empty;

            sql += "CREATE VIEW dbo.ck_stockdepthb";
            sql += " AS ";
            sql += " SELECT a.ID, a.DeptID, a.StockID, a.GoodsID, a.StockLocID, a.CheckCount, a.Remark, a.StockAdmID1,a.StockAdmID2,";
            sql += "      a.Stock, a.CostPrice, a.upWarning, a.downWarning, a.StockName, a.StockLocName, ";
            sql += "      a.bReject, b.GoodsNO, b._Name, b.Spec, b.ForProducts, b.Attr, b.MainTenancePeriod, ";
            sql += "      b.Valid, b.pyCode, b.CostMode, b.bStock, b.bIncrement, b.bStop, b.BarCode, ";
            sql += "      b.PriceDetail, b.PriceCost, b.PriceInner, b.PriceWholesale1, b.PriceWholesale2, ";
            sql += "      b.PriceWholesale3, b.ProductBrand, b.Unit, b.bBase, b.GoodsUnitID, ";
            sql += "      b.StockName AS FStockName, b.Provider, b.BrandCode, b.UnitCode, ";
            sql += "      b.SupplierCode,b.ClassName,a.Reject,b.ClassID,CAST(a.Stock*a.CostPrice AS decimal(18,2)) AS StockAmount,c._Name as Dept,b.userdef2,b.userdef3,b.userdef4,b.userdef5,b.userdef6,b.userdef1,b._Level";
            sql += " FROM dbo.ck_stockdept a LEFT OUTER JOIN";
            sql += "      dbo.ck_goods b ON a.GoodsID = b.ID left outer join";
            sql += "      dbo.BranchList c on a.DeptID=c.[ID]";

            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，视图:ck_stockdepthb，升级异常:" + ex.Message.ToString());
            }

            sql = string.Empty;
            sql = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xt_sysparm]') and OBJECTPROPERTY(id, N'IsView') = 1) drop view [dbo].[xt_sysparm]";
            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，视图:xt_sysparm，升级异常:" + ex.Message.ToString());
            }

            sql = string.Empty;

            sql = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ck_stocksn]') and OBJECTPROPERTY(id, N'IsView') = 1) drop view [dbo].[ck_stocksn]";
            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，视图:ck_stocksn，升级异常:" + ex.Message.ToString());
            }

            sql = string.Empty;

            sql += " CREATE VIEW dbo.ck_stocksn";
            sql += " AS";
            sql += " SELECT a.ID, a.StockINDeID, Status=case when a.Status=1 then '在库' else '离库' end, c.GoodsNO, c._Name, c.Spec, c.pyCode, ";
            sql += "       d._Name AS ProductBrand, c.MainTenancePeriod, a.SN, a.DeptID,m._Name as Dept,e.BillID,_Date=convert(char(10),e._Date,120),e.OperationID,e.Type,";
            sql += "       g.BillID as StockOUTNO,_OUTDate=convert(char(10),g._Date,120),g.OperationID as OUTOperationID,g.Type as OUTType,c.[ID] as GoodsID,";
            sql += "      n.BarCode, isnull(n.PriceDetail,0) as PriceDetail, isnull(n.PriceCost,0) as PriceCost, isnull(n.PriceInner,0) as PriceInner,isnull(n.PriceWholesale1,0) as PriceWholesale1, isnull(n.PriceWholesale2,0)as PriceWholesale2, isnull(n.PriceWholesale3,0) as PriceWholesale3,o._Name as Unit, n.[ID] AS GoodsUnitID, ";
            sql += "      h._Name as ClassName,c.BrandID,b.StockID,i._Name as StockName,d._Name as Brand,h._Level,c.ClassID,CAST(b.Price AS decimal(10, 2)) as  Price,CAST(j.CostPrice AS decimal(10, 2)) as  CostPrice, ";
            sql += "      k._Name AS StockLocName, i.bReject,Reject=case when i.bReject=0 then '良品' else '废品' end";
            sql += " FROM ";
            sql += "       dbo.StockSN a left outer join";
            sql += "       dbo.StockINDetail b ON a.StockINDeID = b.ID LEFT OUTER JOIN";
            sql += "       dbo.StockIN e  ON b.BillID=e.ID LEFT OUTER JOIN";
            sql += "       dbo.Goods c ON c.ID = b.GoodsID LEFT OUTER JOIN";
            sql += "       dbo.ProductBrand d ON c.BrandID = d.ID LEFT OUTER JOIN";
            sql += "       dbo.StockOUTDetail f ON a.StockOUTDeID=f.[ID] LEFT OUTER JOIN ";
            sql += "       dbo.StockOUT g ON f.BillID=g.[ID] LEFT OUTER JOIN ";
            sql += "       dbo.GoodsClass h ON c.ClassID=h.[ID] LEFT OUTER JOIN";
            sql += "       dbo.StockList i on b.StockID=i.[ID] left outer join";
            sql += "       dbo.StockDept j on b.StockID=j.StockID and b.GoodsID=j.GoodsID left outer join";
            sql += "       dbo.StockLocation k ON j.StockLocID = k.[ID] left outer join";
            sql += "       dbo.BranchList m on a.DeptID=m.[ID] Left OUTER JOIN";
            sql += "       dbo.GoodsUnit n ON c.[ID] = n.GoodsID AND n.bBase = 1  LEFT OUTER JOIN";
            sql += "       dbo.UnitList o ON n.UnitID = o.[ID]";
            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，视图:ck_stocksn，升级异常:" + ex.Message.ToString());
            }

            //存储过程更新
            sql = string.Empty;

            sql += "CREATE VIEW dbo.xt_sysparm";
            sql += " AS ";
            sql += " SELECT b.ID, b.CorpName, b.Tel, b.Adr, b.Zip, a.[SysName], a.BranchNum, a.AllocatePrice, ";
            sql += "      a.WarrantyCycle, a.CustomerShar, a.EmailServer, a.EmailLogName, a.EmailPwd, ";
            sql += "      a.EmailAdr, a.SmsCode, a.BackUpAdr, ISNULL(a.bWeb, 0) AS bWeb, ";
            sql += "      ISNULL(a.SndStyle, 1) AS SndStyle, a.UserName, a.UserPwd, isnull(a.RecDueDay,30) as RecDueDay, isnull(a.iRepair,7) as iRepair,";
            sql += "     isnull( a.bLoginDdl,0) as bLoginDdl,isnull( a.bValiCode,0) as bValiCode,isnull(a.bBln,0) as bBln,isnull(a.bRememberPassword,0) as bRememberPassword,";
            sql += "    isnull(a.bFinish,0) as bFinish, isnull(a.bFinish2,0) as bFinish2, isnull(a.ServicesDo,0) as ServicesDo,a.City, isnull(a.bTec,0) as bTec, isnull(a.bSerItem,0) as bSerItem";
            sql += " FROM dbo.SysParm a LEFT OUTER JOIN";
            sql += "      dbo.BranchList b ON a.DeptID = b.ID";

            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，视图:xt_sysparm，升级异常:" + ex.Message.ToString());
            }

            //存储过程更新
            sql = string.Empty;
            sql = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fw_qx]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) drop procedure [dbo].[fw_qx]";
            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，存储过程:fw_qx，升级异常:" + ex.Message.ToString());
            }
            sql = string.Empty;
            sql += "CREATE PROCEDURE fw_qx";
            sql += "(";
            sql += "	@iTbid	 		int,";
            sql += "	@iDeptid		int,";
            sql += "	@iOperator		int,";
            sql += "	@Reason		nvarchar(100),";
            sql += "	@strMsg	 	nvarchar(200) output	";
            sql += ")";
            sql += " as";
            sql += " set nocount on ";
            sql += "declare @strDate		nvarchar(50) ";
            sql += "set @strDate=convert(varchar(100),getdate(),23) ";
            sql += "if (select isnull(DisposalID,0) from ServicesList where [ID]=@iTbid)<>@iDeptid ";
            sql += "begin";
            sql += "	set @strMsg='操作失败！只能操作本部门单据！' ";
            sql += "	return -1 ";
            sql += "end ";
            sql += "if not exists (select * from ServicesList where [ID]=@iTbid and (curStatus='待处理' or curStatus='处理中')) ";
            sql += "begin ";
            sql += "	set @strMsg='操作失败！该服务单状态已变化，请刷新后操作！' ";
            sql += "	return -1 ";
            sql += "end ";
            sql += "update ServicesList ";
            sql += "set CancelReason=@Reason,Time_Start=getdate(),curStatus='待审核',StartOperatorID=@iOperator,Remark=isnull(Remark,'')+'取消时间:'+@strDate+'取消原因:'+@Reason ";
            sql += "where [ID]=@iTbid ";
            sql += "execute aa_insertlog 2,@iOperator,@iTbid,'取消工单' ";
            sql += "set @strMsg='操作成功！该服务单已【取消】！' ";
            sql += " return 0 ";

            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，存储过程:fw_qx，升级异常:" + ex.Message.ToString());
            }

            sql = string.Empty;
            sql = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ck_tl_fad]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) drop procedure [dbo].[ck_tl_fad]";
            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，存储过程:ck_tl_fad，升级异常:" + ex.Message.ToString());
            }
            sql = string.Empty;
            sql += " CREATE PROCEDURE ck_tl_fad";
            sql += " (";
            sql += " 	@iTbid			int,";
            sql += " 	@iOperator		int,";
            sql += " 	@strMsg		nvarchar(200) output,";
            sql += " 	@iFlag			int output";
            sql += " )";
            sql += " as";
            sql += " set nocount on";
            sql += " declare	@iStock		int,";
            sql += " 	@iGoods		int,";
            sql += " 	@iGoodsUnit		int,";
            sql += " 	@iError			int";
            sql += " declare @dCount		decimal(18,4),";
            sql += " 	@dPrice		decimal(18,4)";
            sql += " declare @strTmp		nvarchar(100),";
            sql += " 	@strBillid2		nvarchar(50),";
            sql += " 	@strBillid3		nvarchar(50),";
            sql += " 	@strStatus		nvarchar(50)";
            sql += " if not exists (select * from BroughtBack where [ID]=@iTbid and Status=2)";
            sql += " begin";
            sql += " 	set @strMsg='操作失败！只有已审核的退料单才能【反审核】！'";
            sql += " 	set @iFlag=-1";
            sql += " 	return -1";
            sql += " end";
            sql += " declare @DeptID	int,";
            sql += " 	 @Type		int";
            sql += " select @DeptID=isnull([DeptID],0),@Type=Type from BroughtBack where [ID]=@iTbid ";
            sql += " declare @CostMode 	int,";
            sql += " 	@CiteID	int";
            sql += " set @CostMode=1";
            sql += " declare @SN	varchar(5000)";
            sql += " declare @strsn	varchar(100)";
            sql += " declare @strgoodsno	varchar(100)";
            sql += " declare cur cursor local scroll for ";
            sql += " select StockID,GoodsID,UnitID,Qty,CostPrice,isnull(CiteID,0),SN from BroughtBackDetail a where a.[BillID]=@iTbid";
            sql += " open cur ";
            sql += " fetch next from cur into @iStock,@iGoods,@iGoodsUnit,@dCount,@dPrice,@CiteID,@SN";
            sql += " while @@fetch_status=0 ";
            sql += " begin";
            sql += " 	if(@Type=2)";
            sql += " 	begin";
            sql += " 		if(@CiteID>0)";
            sql += " 		begin";
            sql += " 			if not exists (select * from ServicesList a where (a.curStatus='待处理' or a.curStatus='处理中') and exists (select * from ServicesMaterial b where a.[ID]=b.BillID and b.[ID]=@CiteID))";
            sql += " 			begin";
            sql += " 				select @strBillid2=BillID,@strStatus=a.curStatus from ServicesList a where exists (select * from ServicesMaterial b where a.[ID]=b.BillID and b.[ID]=@CiteID)";
            sql += " 				set @strMsg='该退料单所对应的维修服务单号【'+@strBillid2+'】已转入【'+@strStatus+'】状态，不能【反审核】！'	";
            sql += " 				set @strBillid2=isnull(@strBillid2,'')";
            sql += " 				if @strBillid2<>''";
            sql += " 				begin";
            sql += " 				set @iFlag=-1";
            sql += " 				return -1";
            sql += " 				end";
            sql += " 			end";
            sql += " 			if @strBillid2<>''";
            sql += " 			update ServicesMaterial set LQty=isnull(LQty,0)+@dCount where [ID]=@CiteID";
            sql += " 		end";
            sql += " 	end";
            sql += " 	select  @dCount=@dCount*UnitRelation from GoodsUnit where [ID]=@iGoodsUnit";
            sql += " 	select @CostMode=[CostMode],@strgoodsno=GoodsNO from Goods where [ID]=@iGoods";
            sql += " 	execute ck_checkkc @DeptID,@iStock,@iGoods,@dCount,@strMsg output,@iError output";
            sql += " 	if @iError<>0";
            sql += " 	begin";
            sql += " 		close cur";
            sql += " 		deallocate cur";
            sql += " 		set @iFlag=-1";
            sql += " 		return -1	";
            sql += " 	end";
            sql += " 	execute ck_updatekc 1,@DeptID,@iStock,@iGoods,@dCount,0";
            sql += " 	if @CostMode=1";
            sql += " 	begin";
            sql += " 		execute ck_stockbatchaddu @DeptID,@iTbid,@iStock,@iGoods,@dCount,@dPrice,'员工退料',@strMsg output,@iError output";
            sql += " 		if @iError<>0";
            sql += " 		begin";
            sql += " 			close cur";
            sql += " 			deallocate cur";
            sql += " 			set @iFlag=-1";
            sql += " 			return -1	";
            sql += " 		end";
            sql += " 	end";
            sql += " 	if @SN<>''";
            sql += " 	begin";
            sql += " 		declare curd cursor local scroll for ";
            sql += " 			select F1 from dbo.f_splitstr(@SN,',')";
            sql += " 		open curd ";
            sql += " 		fetch next from curd into @strsn";
            sql += " 		while @@fetch_status=0 ";
            sql += " 		begin";
            sql += " 			if @strsn<>''";
            sql += " 			begin";
            sql += " 				if not exists (select 1 from StockSN where SN=@strsn and Status=1 and DeptID=@DeptID)";
            sql += " 				begin";
            sql += " 					set @strMsg='反审核失败！产品编号：'+@strgoodsno+' 序列号：'+@strsn+' 已出库，不能【反审核】！'";
            sql += " 					close curd";
            sql += " 					deallocate curd";
            sql += " 					close cur";
            sql += " 					deallocate cur";
            sql += " 					set @iFlag=-1";
            sql += " 					return -1";
            sql += " 				end";
            sql += " 			end";
            sql += " 			fetch next from curd into @strsn";
            sql += " 		end";
            sql += " 		close curd";
            sql += " 		deallocate curd";
            sql += " 	delete StockSN where SN=@strsn and Status=1 and DeptID=@DeptID";
            sql += " 	end";
            sql += " 	fetch next from cur into @iStock,@iGoods,@iGoodsUnit,@dCount,@dPrice,@CiteID,@SN";
            sql += " end";
            sql += " close cur";
            sql += " deallocate cur";
            sql += " update BroughtBack set ChkDate=null,ChkOperatorID=null,Status=1 where [ID]=@iTbid";
            sql += " select @strTmp=BillID from BroughtBack where [ID]=@iTbid";
            sql += " declare @iTbidin	int";
            sql += " select @iTbidin=[ID] from StockIN where OperationID=@strTmp";
            sql += " delete StockINDetail where BillID=@iTbidin";
            sql += " delete StockIN where [ID]=@iTbidin";
            sql += " set @strTmp='【反审核】退料单('+@strTmp+')'";
            sql += " execute aa_insertlog 1,@iOperator,0,@strTmp";
            sql += " set @strMsg='操作成功！该退料单已【反审核】！'";
            sql += " set @iFlag=0";
            sql += " return 0";

            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，存储过程:ck_tl_fad，升级异常:" + ex.Message.ToString());
            }

            sql = string.Empty;
            sql = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ck_ll_fad]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) drop procedure [dbo].[ck_ll_fad]";
            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，存储过程:ck_ll_fad，升级异常:" + ex.Message.ToString());
            }
            sql = string.Empty;
            sql += " CREATE PROCEDURE ck_ll_fad";
            sql += " (";
            sql += "     @iTbid		int,";
            sql += "     @iOperator	int,";
            sql += "     @strMsg	nvarchar(200) output,";
            sql += "     @iFlag		int	output";
            sql += " )";
            sql += " as";
            sql += " set nocount on";
            sql += " declare	@iStock		int,";
            sql += "     @iGoods		int,";
            sql += "     @iGoodsUnit		int,";
            sql += "     @iError			int,";
            sql += "     @iTmp			int";
            sql += " declare @dCount		decimal(18,4),";
            sql += "     @dPrice		decimal(18,4)";
            sql += " declare @strTmp		nvarchar(100),";
            sql += "     @strBillid2		nvarchar(50),";
            sql += "     @strStatus		nvarchar(50)";
            sql += " if not exists (select * from BroughtBack where [ID]=@iTbid and Status=2)";
            sql += " begin";
            sql += "     set @strMsg='操作失败！只有已审核的领料单才能【反审核】！'";
            sql += "     set @iFlag=-1";
            sql += "     return -1";
            sql += " end";
            sql += " declare @DeptID	int,";
            sql += "     @CiteID	int";
            sql += " select @DeptID=isnull([DeptID],0) from BroughtBack where [ID]=@iTbid ";
            sql += " declare @CostMode int";
            sql += " set @CostMode=1";
            sql += " declare @SN	varchar(5000)";
            sql += " declare @strsn	varchar(100)";
            sql += " declare @strgoodsno	varchar(100)";
            sql += " declare cur cursor local scroll for ";
            sql += " select StockID,GoodsID,UnitID,Qty,CostPrice,isnull(CiteID,0),SN from BroughtBackDetail a where a.[BillID]=@iTbid";
            sql += " open cur ";
            sql += " fetch next from cur into @iStock,@iGoods,@iGoodsUnit,@dCount,@dPrice,@CiteID,@SN";
            sql += " while @@fetch_status=0 ";
            sql += " begin";
            sql += "     if(@CiteID>0)";
            sql += "     begin";
            sql += "         if not exists (select * from ServicesList a where (a.curStatus='待处理' or a.curStatus='处理中') and exists (select * from ServicesMaterial b where a.[ID]=b.BillID and b.[ID]=@CiteID))";
            sql += "         begin";
            sql += "             select @strBillid2=isnull(BillID,''),@strStatus=a.curStatus from ServicesList a where exists (select * from ServicesMaterial b where a.[ID]=b.BillID and b.[ID]=@CiteID)";
            sql += "             set @strMsg='该领料单所对应的维修服务单号【'+@strBillid2+'】已转入【'+@strStatus+'】状态，不能【反审核】！'	";
            sql += "             set @strBillid2=isnull(@strBillid2,'')";
            sql += "             if @strBillid2<>''";
            sql += "             begin";
            sql += "             set @iFlag=-1";
            sql += "             return -1";
            sql += "             end";
            sql += "         end";
            sql += "         if @strBillid2<>''";
            sql += "         update ServicesMaterial set LQty=isnull(LQty,0)-@dCount where [ID]=@CiteID";
            sql += "     end";
            sql += "     select  @dCount=@dCount*UnitRelation from GoodsUnit where [ID]=@iGoodsUnit";
            sql += "     select @CostMode=[CostMode],@strgoodsno=GoodsNO from Goods where [ID]=@iGoods";
            sql += "     if not exists (select * from Stock where GoodsID=@iGoods and DeptID=@DeptID)	";
            sql += "     begin";
            sql += "         execute aa_getnewkey 'Stock',@iTmp output ";
            sql += "         insert into Stock ([ID],DeptID,GoodsID) values(@iTmp,@DeptID,@iGoods)";
            sql += "     end";
            sql += "     if not exists (select * from StockDept where StockID=@iStock and GoodsID=@iGoods and DeptID=@DeptID)	";
            sql += "     begin";
            sql += "         execute aa_getnewkey 'StockDept',@iTmp output ";
            sql += "         insert into StockDept ([ID],DeptID,StockID,GoodsID) values(@iTmp,@DeptID,@iStock,@iGoods)";
            sql += "     end";
            sql += "     execute ck_updatekc 0,@DeptID,@iStock,@iGoods,@dCount,@dPrice";
            sql += "     if @CostMode=1";
            sql += "     execute ck_stockbatchoutu @iTbid,@iStock,'员工领料'";
            sql += "     if @SN<>''";
            sql += "     begin";
            sql += "         declare curd cursor local scroll for ";
            sql += "             select F1 from dbo.f_splitstr(@SN,',')";
            sql += "         open curd ";
            sql += "         fetch next from curd into @strsn";
            sql += "         while @@fetch_status=0 ";
            sql += "         begin";
            sql += "             if @strsn<>''";
            sql += "             begin";
            sql += "                 if not exists (select 1 from StockSN where SN=@strsn and Status=2 and DeptID=@DeptID)";
            sql += "                 begin";
            sql += "                     set @strMsg='反审核失败！产品编号：'+@strgoodsno+' 序列号：'+@strsn+' 不存在或已入库，请修改！'";
            sql += "                     close curd";
            sql += "                     deallocate curd";
            sql += "                     close cur";
            sql += "                     deallocate cur";
            sql += "                     set @iFlag=-1";
            sql += "                     return -1";
            sql += "                 end";
            sql += "                 update StockSN set StockOUTDeID=null,Status=1 where SN=@strsn and Status=2 and DeptID=@DeptID";
            sql += "             end";
            sql += "             fetch next from curd into @strsn";
            sql += "         end";
            sql += "         close curd";
            sql += "         deallocate curd";
            sql += "     end";
            sql += "     fetch next from cur into @iStock,@iGoods,@iGoodsUnit,@dCount,@dPrice,@CiteID,@SN";
            sql += " end";
            sql += " close cur";
            sql += " deallocate cur";
            sql += " update BroughtBack set ChkDate=null,ChkOperatorID=null,Status=1 where [ID]=@iTbid";
            sql += " select @strTmp=BillID from BroughtBack where [ID]=@iTbid";
            sql += " declare @iTbidin	int";
            sql += " select @iTbidin=[ID] from StockOUT where OperationID=@strTmp";
            sql += " delete StockOUTDetail where BillID=@iTbidin";
            sql += " delete StockOUT where [ID]=@iTbidin";
            sql += " set @strTmp='【反审核】领料单('+@strTmp+')'";
            sql += " execute aa_insertlog 1,@iOperator,0,@strTmp";
            sql += " set @strMsg='操作成功！该领料单已【反审核】！'";
            sql += " set @iFlag=0";
            sql += " return 0";

            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，存储过程:ck_ll_fad，升级异常:" + ex.Message.ToString());
            }

            sql = string.Empty;
            sql = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fw_gd_wg]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) drop procedure [dbo].[fw_gd_wg]";
            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，存储过程:fw_gd_wg，升级异常:" + ex.Message.ToString());
            }
            sql = string.Empty;

            sql += " CREATE PROCEDURE fw_gd_wg";
            sql += " (";
            sql += "     @iTbid		int,";
            sql += "     @iOperator	int,";
            sql += "     @iPerson	int,";
            sql += "     @strOverTime	nvarchar(50),";
            sql += "     @TroubleReason	nvarchar(100),";
            sql += "     @TakeSteps		nvarchar(2000),";
            sql += "     @ArrTime		nvarchar(50),";
            sql += "     @iDays			int,";
            sql += "     @iHours		decimal(18,2),";
            sql += "     @strMsg	nvarchar(200) output";
            sql += "  )";
            sql += " as";
            sql += " set nocount on";
            sql += " if not exists (select * from ServicesList where [ID]=@iTbid and (curStatus='待处理' or curStatus='处理中'))";
            sql += " begin";
            sql += "     set @strMsg='操作失败！该服务单状态已变化，请刷新后操作'";
            sql += "     return -1";
            sql += " end";
            sql += "  declare @bBln	int,";
            sql += "      @bFinish	bit,";
            sql += "      @bFinish2	bit,";
            sql += "      @bTec		bit,";
            sql += "      @bSerItem	bit";
            sql += "  set @bBln=0";
            sql += "  set @bFinish=0";
            sql += " set @bFinish2=0";
            sql += "  set @bTec=0";
            sql += "  set @bSerItem=0";
            sql += "  select @bBln=isnull(a.bBln,0),@bFinish=isnull(a.bFinish,0),@bFinish2=isnull(a.bFinish2,0),@bTec= isnull(a.bTec,0),@bSerItem=isnull(a.bSerItem,0)  from SysParm a";
            sql += " if @bSerItem=1";
            sql += "  begin";
            sql += "     if not exists(select 1  from ServicesItem where [BillID]=@iTbid)";
            sql += "     begin";
            sql += "          set @strMsg='操作失败！该服务单必须添加服务项目才能完工！'";
            sql += "          return -1";
            sql += "      end";
            sql += "  end";
            sql += "  if @bFinish=1";
            sql += " begin";
            sql += "    if  exists(select bComplete  from ServicesItem where [BillID]=@iTbid and bComplete=0)";
            sql += "    begin";
            sql += "         set @strMsg='操作失败！该服务单存在未完工的服务项目，请确认完工后再操作！'";
            sql += "         return -1";
            sql += "     end";
            sql += "  end";
            sql += "  if @bFinish2=1";
            sql += " begin";
            sql += "     declare @dAmos1 	decimal(18,4),";
            sql += "         @dAmos2	decimal(18,4)";
            sql += "     select @dAmos1= sum(isnull(Price,0)) from ServicesItem where BillID=@iTbid";
            sql += "     select @dAmos2=sum(isnull(dAmount,0)) from ServiceOffer where BillID=@iTbid";
            sql += "     if  @dAmos1<>@dAmos2";
            sql += "     begin";
            sql += "         set @strMsg='操作失败！该服务单报价金额和服务项目金额不符合，请修改！'";
            sql += "         return -1";
            sql += "     end";
            sql += " end";
            sql += " if @bTec=0";
            sql += " begin";
            sql += "     if (select [DisposalOper] from ServicesList where [ID]=@iTbid)=''";
            sql += "     begin";
            sql += "         set @strMsg='操作失败！该服务单技术员为空，请修改！'";
            sql += "         return -1";
            sql += "     end";
            sql += "     if exists (select [Tec] from ServicesItem where [BillID]=@iTbid and isnull(Tec,'')='')";
            sql += "     begin";
            sql += "         set @strMsg='操作失败！该服务单服务项目中技术员为空，请修改！'";
            sql += "         return -1";
            sql += "     end";
            sql += " end";
            sql += " declare @strBillid	nvarchar(50)";
            sql += " declare @iDeptid	int";
            sql += " select @iDeptid=DisposalID from ServicesList where [ID]=@iTbid";
            sql += " if exists (select* from ServicesMaterial a left join Goods b on a.GoodsID=b.[ID]  where a.BillID=@iTbid and a.Qty<>a.LQty and a.OutSourcing=0)";
            sql += " begin";
            sql += "     select @strBillid=b.GoodsNO from ServicesMaterial a left join Goods b on a.GoodsID=b.[ID]  where a.BillID=@iTbid and a.Qty<>a.LQty";
            sql += "     set @strMsg='该服务单的维修使用配件【'+@strBillid+'】与领料数量不符，请先领料或退料！'";
            sql += "     return -1";
            sql += " end";
            sql += " declare @TotalCost	decimal(18,4)";
            sql += " set @TotalCost=0";
            sql += " declare @Amount1 decimal(18,4)";
            sql += " declare @Amount2 decimal(18,4),";
            sql += "     @Fee_Materail	decimal(18,4),";
            sql += "     @Fee_Labor	decimal(18,4)";
            sql += " select @Fee_Materail=sum(isnull(Total,0)) from ServicesMaterial where BillID=@iTbid and ChargeStyle='客付'";
            sql += " select @Fee_Labor=sum(isnull(Price,0)) from ServicesItem where BillID=@iTbid and ChargeStyle='客付'";
            sql += " update ServicesList set Fee_Materail=isnull(@Fee_Materail,0),Fee_Labor=isnull(@Fee_Labor,0) where [ID]=@iTbid";
            sql += " select @Amount1=0";
            sql += " select @Amount1=sum(isnull(Total,0)) from ServicesMaterial where BillID=@iTbid and ChargeStyle='厂付'	";
            sql += " select @Amount2=0";
            sql += " select @Amount2=sum(cast(isnull(Price,0) as decimal(10,2))) from ServicesItem where BillID=@iTbid and ChargeStyle='厂付'";
            sql += " if exists (select* from ServicesMaterial a left join Goods b on a.GoodsID=b.[ID]  where a.BillID=@iTbid)";
            sql += " begin";
            sql += " declare @iGoods	int,";
            sql += "     @iGoodsUnit	int";
            sql += " declare @dCount	decimal(18,4),";
            sql += "     @CostPrice	decimal(18,4)";
            sql += " declare @Attr	varchar(10),";
            sql += "     @PeriodEndDate	nvarchar(50)";
            sql += " set @Attr=''";
            sql += " declare cur cursor local scroll for ";
            sql += " select GoodsID,UnitID,Qty,isnull(CostPrice,0),PeriodEndDate from ServicesMaterial a where a.[BillID]=@iTbid";
            sql += " open cur ";
            sql += " fetch next from cur into @iGoods,@iGoodsUnit,@dCount,@CostPrice,@PeriodEndDate";
            sql += " while @@fetch_status=0 ";
            sql += " begin";
            sql += "     select @Attr=Attr from Goods where [ID]=@iGoods";
            sql += "     select  @dCount=@dCount*UnitRelation from GoodsUnit where [ID]=@iGoodsUnit";
            sql += "     set @TotalCost=@TotalCost+@dCount*@CostPrice";
            sql += "     if @Attr='耗材'";
            sql += "     begin";
            sql += "         set @PeriodEndDate=isnull(@PeriodEndDate,'')";
            sql += "         if @PeriodEndDate<>''";
            sql += "         begin";
            sql += "             declare @itrack	int";
            sql += "             execute aa_getnewkey 'ConsumablesTrack',@itrack output";
            sql += "             insert into ConsumablesTrack ([ID],DeptID,_Date,Type,BillID,CustomerID,CustomerName,LinkMan,Tel,OperatorID,WarringDate,Status,Remark)";
            sql += "              select @itrack,@iDeptid,getdate(),'服务单',a.BillID,a.CustomerID,a.CustomerName,a.LinkMan,a.Tel,@iPerson,@PeriodEndDate,1,'' from ServicesList a where [ID]=@iTbid ";
            sql += "         end";
            sql += "     end";
            sql += "     fetch next from cur into @iGoods,@iGoodsUnit,@dCount,@CostPrice,@PeriodEndDate";
            sql += " end";
            sql += " close cur";
            sql += " deallocate cur";
            sql += " end";
            sql += " declare @Amountx decimal(18,4)";
            sql += " set @Amountx=0";
            sql += " select @Amountx=sum(isnull(dAmount,0)) from ServiceOffer where BillID=@iTbid";
            sql += " if @Amountx>0";
            sql += " update ServicesList set Time_Over=@strOverTime,curStatus='待结算',SubscribePrice=@Amountx,MaterailCost=isnull(@TotalCost,0),WarrantyChargeValue=(isnull(@Amount1,0)+isnull(@Amount2,0)),ChargeValue=(isnull(Fee_Materail,0)+isnull(Fee_Labor,0)+isnull(Fee_Add,0)) where [ID]=@iTbid";
            sql += " else";
            sql += " update ServicesList set Time_Over=@strOverTime,curStatus='待结算',MaterailCost=isnull(@TotalCost,0),WarrantyChargeValue=(isnull(@Amount1,0)+isnull(@Amount2,0)),ChargeValue=(isnull(Fee_Materail,0)+isnull(Fee_Labor,0)+isnull(Fee_Add,0)) where [ID]=@iTbid";
            sql += " if(@bBln=1)";
            sql += " begin";
            sql += " declare @damount	decimal(18,4)";
            sql += " select @damount=ChargeValue from ServicesList where [ID]=@iTbid";
            sql += " if(@damount=0)";
            sql += " begin";
            sql += " declare @typeid		int,";
            sql += "     @warrantyid	int,";
            sql += "     @bcall		int,";
            sql += "     @iCustomerid	int";
            sql += " select @typeid=isnull(TypeID,0),@warrantyid=isnull(WarrantyID,0) from ServicesList where [ID]=@iTbid";
            sql += " set @bcall=0";
            sql += " select @bcall=isnull(bCall,0) from ServicesType where [ID]=@typeid";
            sql += " if @bcall=0";
            sql += " select @bcall=isnull(bCall,0) from Warranty where [ID]=@warrantyid";
            sql += " if @bcall=0";
            sql += " select @bcall=isnull(bCall,0) from CustomerList where [ID]=@iCustomerid";
            sql += " update ServicesList set curStatus='待审核',bCall=@bcall,Time_Payee=@strOverTime,PayeeOperID=@iOperator,Profit=0 where [ID]=@iTbid";
            sql += " execute fw_tc @iTbid";
            sql += " end";
            sql += " end";
            sql += " if @ArrTime=''";
            sql += " set @ArrTime=null";
            sql += " declare @iTmp	int";
            sql += " execute aa_getnewkey 'ServicesProcess',@iTmp output";
            sql += " insert into ServicesProcess([ID],[BillID],DoStyle,DeptID,iPerson,iOperator,_Date,Reason,TakeSteps,ArrivedTime,iDays,iHours) values(@iTmp,@iTbid,'完成关闭',@iDeptid,@iPerson,@iOperator,getdate(),@TroubleReason,@TakeSteps,@ArrTime,@iDays,@iHours)";
            sql += " execute aa_sndsms @iTbid,5,'工单完工'";
            sql += " execute aa_insertlog 2,@iPerson,@iTbid,'确认完工'";
            sql += " set @strMsg='操作成功！该服务单已确认完工！'";
            sql += " return 0";
            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，存储过程:fw_gd_wg，升级异常:" + ex.Message.ToString());
            }

            sql = string.Empty;
            sql = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fw_gd_dd]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) drop procedure [dbo].[fw_gd_dd]";
            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，存储过程:fw_gd_dd，升级异常:" + ex.Message.ToString());
            }
            sql = string.Empty;

            sql += " CREATE PROCEDURE fw_gd_dd";
            sql += " (";
            sql += "     @iFlag			int,";
            sql += "     @iTbid	 		int,";
            sql += "     @iDeptid		int,";
            sql += "     @iOperator		int,";
            sql += "     @iPerson		int,";
            sql += "     @Paramid		int,";
            sql += "     @Tec			nvarchar(100),";
            sql += "     @TroubleReason	nvarchar(100),";
            sql += "     @TakeSteps		nvarchar(2000),";
            sql += "     @ArrTime		nvarchar(50),";
            sql += "     @iDays			int,";
            sql += "     @iHours		decimal(18,2),";
            sql += "     @DoDept		nvarchar(100),";
            sql += "     @strMsg	 	nvarchar(200) output	";
            sql += " )";
            sql += " as";
            sql += " set nocount on";
            sql += " declare @strDate		nvarchar(50),";
            sql += "     @DoStyle		nvarchar(50)";
            sql += " set @strDate=getdate()";
            sql += " set @DoStyle=''";
            sql += " declare @strDoOperator 		nvarchar(50)";
            sql += " if (select isnull(DisposalID,0) from ServicesList where [ID]=@iTbid)<>@iDeptid";
            sql += " begin";
            sql += "     set @strMsg='操作失败！只能操作本部门单据！'";
            sql += "     return -1";
            sql += " end";
            sql += " if not exists (select * from ServicesList where [ID]=@iTbid and (curStatus='处理中' or curStatus='待处理'))";
            sql += " begin";
            sql += "     set @strMsg='操作失败！该服务单状态已变化，请刷新后操作！'";
            sql += "     return -1";
            sql += " end";
            sql += " declare @Event varchar(100)";
            sql += " select @Event=''";
            sql += " if @iFlag=1";
            sql += " begin";
            sql += "     update ServicesList";
            sql += "     set curStatus='送修',StartOperatorID=@iOperator,Time_Start=getdate(),RepairType=1,RepairCorpID=@Paramid,RepairStatus='待送修发货' where [ID]=@iTbid";
            sql += "     set @Event='升级派工(委外送修)'";
            sql += "     set @DoStyle='委外送修'";
            sql += " end";
            sql += " else";
            sql += " if @iFlag=2";
            sql += " begin";
            sql += "     update ServicesList";
            sql += "     set curStatus='送修',StartOperatorID=@iOperator,Time_Start=getdate(),RepairType=2,RepairCorpID=@Paramid,RepairStatus='待送修发货' where [ID]=@iTbid";
            sql += "     set @Event='升级派工(内部送修)'";
            sql += "     set @DoStyle='内部送修'";
            sql += " end";
            sql += " else";
            sql += " if @iFlag=3";
            sql += " begin";
            sql += "     update ServicesList";
            sql += "     set curStatus='待确认',DisposalID=@Paramid where [ID]=@iTbid";
            sql += "     if @iDeptid=1";
            sql += "     begin";
            sql += "         set @Event='升级派工(派给网点)'";
            sql += "         set @DoStyle='派给网点'";
            sql += "     end";
            sql += "     else";
            sql += "     begin";
            sql += "         set @Event='升级派工(送给总部)'";
            sql += "         set @DoStyle='送给总部'";
            sql += "     end";
            sql += "     execute aa_sndsms @iTbid,7,'派给网点通知客户'";
            sql += "     execute aa_sndsms @iTbid,8,'派给网点通知网点'";
            sql += " end";
            sql += " else";
            sql += " if @iFlag=4";
            sql += " begin";
            sql += "     update ServicesList";
            sql += "     set curStatus='处理中',StartOperatorID=@iOperator,Time_Start=getdate(),DisposalOper=@Tec where [ID]=@iTbid";
            sql += "     set @Event='升级派工(内部升级)'";
            sql += "     set @DoStyle='内部升级'";
            sql += "     set @strDoOperator=@Tec";
            sql += "     execute aa_sndsms @iTbid,1,'自修派工'";
            sql += "     execute aa_sndsms @iTbid,4,'派工通知客户'";
            sql += " end";
            sql += " if @ArrTime=''";
            sql += " set @ArrTime=null";
            sql += " declare @iTmp	int";
            sql += " execute aa_getnewkey 'ServicesProcess',@iTmp output";
            sql += " insert into ServicesProcess([ID],[BillID],DoStyle,DeptID,iPerson,iOperator,_Date,Reason,TakeSteps,ArrivedTime,iDays,iHours,DoDept,DoOperator) values(@iTmp,@iTbid,@DoStyle,@iDeptid,@iPerson,@iOperator,getdate(),@TroubleReason,@TakeSteps,@ArrTime,@iDays,@iHours,@DoDept,@strDoOperator)";
            sql += " execute aa_insertlog 2,@iPerson,@iTbid,@Event";
            sql += " return 0";

            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，存储过程:fw_gd_dd，升级异常:" + ex.Message.ToString());
            }

            sql = string.Empty;
            sql = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[aa_sndsms]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) drop procedure [dbo].[aa_sndsms]";
            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，存储过程:aa_sndsms，升级异常:" + ex.Message.ToString());
            }
            sql = string.Empty;
            sql += " CREATE PROCEDURE aa_sndsms";
            sql += " (";
            sql += "     @iTbid	 		int,";
            sql += "     @iFlag			int,";
            sql += "     @SndTiming		nvarchar(50)";
            sql += " )";
            sql += " as";
            sql += " set nocount on";
            sql += " declare @strSmsTmpName	nvarchar(50),";
            sql += "     @strTmpContent	nvarchar(1000)";
            sql += " declare @CusName		nvarchar(100),";
            sql += "     @strTel			nvarchar(50),";
            sql += "     @strAdr			nvarchar(200),";
            sql += "     @strLinkMan		nvarchar(50),";
            sql += "     @Brand			nvarchar(50),";
            sql += "     @Class			nvarchar(50),";
            sql += "     @Model		nvarchar(50),";
            sql += "     @Sn			nvarchar(50),";
            sql += "     @Fault			nvarchar(500),";
            sql += "     @SubscribePrice	decimal(18,2),";
            sql += "     @Warray		nvarchar(50),";
            sql += "     @strBuyDate		nvarchar(50),";
            sql += "     @DisOperator		nvarchar(50),";
            sql += "     @PostNo		nvarchar(50),";
            sql += "     @GoodsSummary	nvarchar(500),";
            sql += "     @PostStyle		nvarchar(50),";
            sql += "     @iDeptid		int,";
            sql += "     @TecTel			nvarchar(50),";
            sql += "     @BranchName		nvarchar(100),";
            sql += "     @BranchLinkMan		nvarchar(50),";
            sql += "     @BranchTel		nvarchar(50)";
            sql += " declare @strTel2	nvarchar(20)";
            sql += " if @iFlag=2";
            sql += " begin";
            sql += "     select @CusName=isnull(CorpName,''),@strTel=isnull(Tel,''),@strAdr=isnull(Adr,''),@strLinkMan=isnull(LinkMan,''),";
            sql += "     @GoodsSummary=isnull(Summary,''),@PostStyle=isnull(SndStyle,''),@PostNo=isnull(PostNO,'') from sf_rcvsnd where [ID]=@iTbid";
            sql += " end";
            sql += " else";
            sql += " begin";
            sql += "     select @iDeptid=DisposalID,@CusName=CustomerName,@strTel=Tel,@strAdr=Adr,@strLinkMan=LinkMan,@Brand=ProductBrand,@Class=ProductClass,@Model=ProductModel,@Sn=ProductSN1";
            sql += "     ,@Fault=Fault,@SubscribePrice=isnull(SubscribePrice,0),@Warray=Warranty,@strBuyDate=BuyDate,@DisOperator=DisposalOper,@PostNo=PostNO from fw_services where [ID]=@iTbid";
            sql += "     select @BranchName=_Name,@BranchLinkMan=LinkMan,@BranchTel=Tel from BranchList where [ID]=@iDeptid";
            sql += "     select @TecTel=Tel from StaffList a where a.DeptID=@iDeptid and a._Name in (select * from dbo.f_splitstr(@DisOperator,','))";
            sql += " end";
            sql += " set @strTmpContent=''";
            sql += " declare cur cursor local scroll for ";
            sql += " select SmsTmp from SmsStrategy a where a.SndTiming=@SndTiming";
            sql += " open cur ";
            sql += " fetch next from cur into @strSmsTmpName";
            sql += " while @@fetch_status=0 ";
            sql += " begin";
            sql += "     select @strTmpContent=Content from SmsTmp where Title=@strSmsTmpName";
            sql += "     set @strTmpContent=replace(@strTmpContent,'{客户名称}',isnull(@CusName,''))";
            sql += "     set @strTmpContent=replace(@strTmpContent,'{客户电话}',isnull(@strTel,''))";
            sql += "     set @strTmpContent=replace(@strTmpContent,'{客户地址}',isnull(@strAdr,''))";
            sql += "     set @strTmpContent=replace(@strTmpContent,'{联系人}',isnull(@strLinkMan,''))";
            sql += "     set @strTmpContent=replace(@strTmpContent,'{机器品牌}',isnull(@Brand,''))";
            sql += "     set @strTmpContent=replace(@strTmpContent,'{机器类别}',isnull(@Class,''))";
            sql += "     set @strTmpContent=replace(@strTmpContent,'{机器型号}',isnull(@Model,''))";
            sql += "     set @strTmpContent=replace(@strTmpContent,'{序列号}',isnull(@Sn,''))";
            sql += "     set @strTmpContent=replace(@strTmpContent,'{故障描述}',isnull(@Fault,''))";
            sql += "     set @strTmpContent=replace(@strTmpContent,'{预报价}',isnull(@SubscribePrice,0))";
            sql += "     set @strTmpContent=replace(@strTmpContent,'{保修情况}',isnull(@Warray,''))";
            sql += "     set @strTmpContent=replace(@strTmpContent,'{购买日期}',isnull(@strBuyDate,''))";
            sql += "     set @strTmpContent=replace(@strTmpContent,'{技术员}',isnull(@DisOperator,''))";
            sql += "     set @strTmpContent=replace(@strTmpContent,'{物流单号}',isnull(@PostNo,''))";
            sql += "     set @strTmpContent=replace(@strTmpContent,'{技术员电话}',isnull(@TecTel,''))";
            sql += "     set @strTmpContent=replace(@strTmpContent,'{网点名称}',isnull(@BranchName,''))";
            sql += "     set @strTmpContent=replace(@strTmpContent,'{网点联系人}',isnull(@BranchLinkMan,''))";
            sql += "     set @strTmpContent=replace(@strTmpContent,'{网点电话}',isnull(@BranchTel,''))";
            sql += "     if @iFlag=2";
            sql += "     begin";
            sql += "         set @strTmpContent=replace(@strTmpContent,'{货品摘要}',isnull(@GoodsSummary,''))";
            sql += "         set @strTmpContent=replace(@strTmpContent,'{货运方式}',isnull(@PostStyle,''))";
            sql += "     end";
            sql += "     if @strTmpContent<>''";
            sql += "     begin";
            sql += "     if @iFlag=0 or @iFlag=3 or  @iFlag=4 or  @iFlag=5 or  @iFlag=6 or  @iFlag=7";
            sql += "     begin";
            sql += "         declare curd cursor local scroll for ";
            sql += "         select F1 from dbo.f_splitstr(@strTel,',')";
            sql += "         open curd ";
            sql += "         fetch next from curd into @strTel2";
            sql += "         while @@fetch_status=0 ";
            sql += "         begin";
            sql += "         if dbo.aa_getmobile(@strTel2)<>''";
            sql += "         insert into SmsSnd(SndTo,Content,SDate,SFlag) values(@strTel2,@strTmpContent,getdate(),0)";
            sql += "         fetch next from curd into @strTel2";
            sql += "         end";
            sql += "         close curd";
            sql += "         deallocate curd";
            sql += "     end";
            sql += "     else if @iFlag=1";
            sql += "     begin";
            sql += "         declare @Tel	nvarchar(50)";
            sql += "         declare curs	cursor local scroll for";
            sql += "         select Tel from StaffList a where a.DeptID=@iDeptid and a._Name in (select * from dbo.f_splitstr(@DisOperator,','))";
            sql += "         open curs";
            sql += "         fetch next from curs into @Tel";
            sql += "         while @@fetch_status=0 ";
            sql += "         begin";
            sql += "             declare curd cursor local scroll for ";
            sql += "             select F1 from dbo.f_splitstr(@Tel,',')";
            sql += "             open curd ";
            sql += "             fetch next from curd into @strTel2";
            sql += "             while @@fetch_status=0 ";
            sql += "             begin";
            sql += "             if dbo.aa_getmobile(@strTel2)<>''";
            sql += "             begin";
            sql += "                 insert into SmsSnd(SndTo,Content,SDate,SFlag) values(@strTel2,@strTmpContent,getdate(),0)";
            sql += "             end";
            sql += "             fetch next from curd into @strTel2";
            sql += "             end";
            sql += "             close curd";
            sql += "             deallocate curd";
            sql += "         fetch next from curs into @Tel";
            sql += "         end";
            sql += "         close curs";
            sql += "         deallocate curs";
            sql += "     end";
            sql += "     else if @iFlag=2";
            sql += "     begin";
            sql += "         declare curd cursor local scroll for ";
            sql += "         select F1 from dbo.f_splitstr(@strTel,',')";
            sql += "         open curd ";
            sql += "         fetch next from curd into @strTel2";
            sql += "         while @@fetch_status=0 ";
            sql += "         begin";
            sql += "         if dbo.aa_getmobile(@strTel2)<>''";
            sql += "         insert into SmsSnd(SndTo,Content,SDate,SFlag) values(@strTel2,@strTmpContent,getdate(),0)";
            sql += "         fetch next from curd into @strTel2";
            sql += "         end";
            sql += "         close curd";
            sql += "         deallocate curd";
            sql += "     end";
            sql += " else if @iFlag=8";
            sql += " begin";
            sql += "     declare curd cursor local scroll for ";
            sql += "     select F1 from dbo.f_splitstr(@BranchTel,',')";
            sql += "     open curd ";
            sql += "     fetch next from curd into @strTel2";
            sql += "     while @@fetch_status=0 ";
            sql += "     begin";
            sql += "     if dbo.aa_getmobile(@strTel2)<>''";
            sql += "     insert into SmsSnd(SndTo,Content,SDate,SFlag) values(@strTel2,@strTmpContent,getdate(),0)";
            sql += "     fetch next from curd into @strTel2";
            sql += "     end";
            sql += "     close curd";
            sql += "     deallocate curd";
            sql += " end";
            sql += "     end";
            sql += "     fetch next from cur into @strSmsTmpName";
            sql += " end";
            sql += " close cur";
            sql += " deallocate cur";
            sql += " return 0";

            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，存储过程:aa_sndsms，升级异常:" + ex.Message.ToString());
            }

            sql = string.Empty;
            sql = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[jc_InputTrouble]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) drop procedure [dbo].[jc_InputTrouble]";
            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，存储过程:jc_InputTrouble，升级异常:" + ex.Message.ToString());
            }
            sql = string.Empty;

            sql += " CREATE PROCEDURE jc_InputTrouble";
            sql += " (";
            sql += "    @strProductClass	nvarchar(50),";
            sql += "     @strRepairClass		nvarchar(50),";
            sql += "     @strTroubleClass	nvarchar(50),";
            sql += "      @strTroubleNO		nvarchar(50),";
            sql += "     @strTroubleName		nvarchar(500),";
            sql += "      @strSummary1		nvarchar(500),";
            sql += "     @strSummary2		nvarchar(500),";
            sql += "     @strSummary3		nvarchar(500),";
            sql += "     @strSummary4		nvarchar(500),";
            sql += "      @strSummary5		nvarchar(500),";
            sql += "      @strMsg			nvarchar(200) output";
            sql += " )";
            sql += " as";
            sql += "  set nocount on";
            sql += " declare @ProductClassID	int,";
            sql += "     @RepairClassID	int,";
            sql += "     @TroubleClassID	int,";
            sql += "     @strCode 	nvarchar(50)";
            sql += "  if @strProductClass<>''";
            sql += "  begin";
            sql += "       if exists (select 1 from ProductClass where _Name=@strProductClass)";
            sql += "       begin";
            sql += "          select @ProductClassID=[ID]  from ProductClass  where _Name=@strProductClass";
            sql += "     end";
            sql += "      else";
            sql += "      begin";
            sql += "          execute aa_getnewkey 'ProductClass',@ProductClassID output ";
            sql += "          execute xt_getpy  @strProductClass,@strCode output	";
            sql += "          insert into ProductClass([ID],_Name,pyCode,Array) values(@ProductClassID,@strProductClass,@strCode,@ProductClassID)";
            sql += "     end";
            sql += " end";
            sql += "  else";
            sql += "  return -1";
            sql += "  if @strRepairClass<>''";
            sql += "  begin";
            sql += "      if exists (select 1 from RepairClass where _Name=@strRepairClass)";
            sql += "      begin";
            sql += "          select @RepairClassID=[ID]  from RepairClass  where _Name=@strRepairClass	";
            sql += "      end";
            sql += "      else";
            sql += "      begin";
            sql += "           execute aa_getnewkey  'RepairClass',@RepairClassID output ";
            sql += "          execute xt_getpy @strRepairClass,@strCode output	";
            sql += "          insert into RepairClass([ID],_Name,pyCode,Array) values(@RepairClassID,@strRepairClass,@strCode,0)";
            sql += "      end";
            sql += "  end";
            sql += "    else";
            sql += "    return -1";
            sql += "    if @strTroubleClass<>''";
            sql += "    begin";
            sql += "        if exists(select 1 from TroubleClass where _Name=@strTroubleClass)";
            sql += "            begin";
            sql += "                select @TroubleClassID=[ID] from TroubleClass where _Name=@strTroubleClass";
            sql += "             end";
            sql += "         else";
            sql += "            begin";
            sql += "                execute aa_getnewkey  'TroubleClass',@TroubleClassID output ";
            sql += "               declare @strNewCode	varchar(100)";
            sql += "               set @strNewCode=''";
            sql += "               execute aa_getnewtreecode 'TroubleClass',-1,@strNewCode output,@strMsg output";
            sql += "              insert into TroubleClass([ID],_Name, Father,_Level,Array)values(@TroubleClassID, @strTroubleClass,-1,@strNewCode,@TroubleClassID)	";
            sql += "           end";
            sql += "  end";
            sql += "   else";
            sql += "   return -1";
            sql += "    if @strTroubleName is null or @strTroubleName=''";
            sql += "   return -1";
            sql += "   if @strTroubleNO=''";
            sql += "   begin";
            sql += "       execute aa_createbillid 3,1,@strTroubleNO output	";
            sql += "    end";
            sql += "    else";
            sql += "    begin";
            sql += "        if exists(select 1 from TroubleList  where TroubleNO=@strTroubleNO)";
            sql += "        return -1";
            sql += "   end";
            sql += "   declare @TID int";
            sql += "   set @TID=null";
            sql += "   execute aa_getnewkey 'TroubleList',@TID output";
            sql += "   insert into TroubleList([ID],ProductClassID,RepairClassID,TroubleClassID,TroubleNO,Summary)values(@TID,@ProductClassID,@RepairClassID,@TroubleClassID,@strTroubleNO,@strTroubleName)";
            sql += "   declare @SID int";
            sql += "   set @SID=null";
            sql += "   if @strSummary1<>''";
            sql += "   begin";
            sql += "       execute aa_getnewkey 'TakeSteps',@SID output";
            sql += "       insert into TakeSteps([ID],TroubleID,Summary) values(@SID,@TID,@strSummary1)";
            sql += "   end";
            sql += "   if @strSummary2<>''";
            sql += "   begin";
            sql += "       execute aa_getnewkey 'TakeSteps',@SID output";
            sql += "      insert into TakeSteps([ID],TroubleID,Summary) values(@SID,@TID,@strSummary2)";
            sql += "   end";
            sql += "   if @strSummary3<>''";
            sql += "   begin";
            sql += "       execute aa_getnewkey 'TakeSteps',@SID output";
            sql += "      insert into TakeSteps([ID],TroubleID,Summary) values(@SID,@TID,@strSummary3)";
            sql += "   end";
            sql += "   if @strSummary4<>''";
            sql += "    begin";
            sql += "       execute aa_getnewkey 'TakeSteps',@SID output";
            sql += "       insert into TakeSteps([ID],TroubleID,Summary) values(@SID,@TID,@strSummary4)";
            sql += "   end";
            sql += "   if @strSummary5<>''";
            sql += "  begin";
            sql += "       execute aa_getnewkey 'TakeSteps',@SID output";
            sql += "       insert into TakeSteps([ID],TroubleID,Summary) values(@SID,@TID,@strSummary5)";
            sql += "    end";
            sql += "   return 0";

            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，存储过程:jc_InputTrouble，升级异常:" + ex.Message.ToString());
            }

            sql = string.Empty;
            sql = "if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ck_updatekc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) drop procedure [dbo].[ck_updatekc]";
            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，存储过程:ck_updatekc，升级异常:" + ex.Message.ToString());
            }

            sql = string.Empty;
            sql += " CREATE PROCEDURE ck_updatekc";
            sql += " (";
            sql += "     @iFlag		int,";
            sql += "     @DeptID	int,";
            sql += "     @iStock	int,";
            sql += "     @iGoods	int,";
            sql += "     @dCount	decimal(18,4),";
            sql += "     @dPrice	decimal(18,4)";
            sql += " )";
            sql += " as";
            sql += " declare	@dYCB		decimal(18,4),";
            sql += "     @dYSL		decimal(18,4),";
            sql += "     @dXCB		decimal(18,4)";
            sql += " declare @iError		int";
            sql += " declare @strSX		bit";
            sql += " set nocount on";
            sql += " set @dXCB=0";
            sql += " select @strSX=bReject from StockList where [ID]=@iStock";
            sql += " if @iFlag=0";
            sql += " begin";
            sql += "     if @strSX=0";
            sql += "     begin";
            sql += "         select @dYCB=isnull(CostPrice,0),@dYSL=isnull(Stock,0) from Stock where GoodsID=@iGoods and DeptID=@DeptID";
            sql += "             if (@dYCB*@dYSL+@dPrice*@dCount)>0 and (@dYSL+@dCount)!=0";
            sql += "             begin";
            sql += "                 set @dXCB=round((@dYCB*@dYSL+@dPrice*@dCount)/(@dYSL+@dCount),4)";
            sql += "                 update Stock set CostPrice=@dXCB where GoodsID=@iGoods and DeptID=@DeptID";
            sql += "             end";
            sql += "         update Stock set Stock=isnull(Stock,0)+@dCount where GoodsID=@iGoods and DeptID=@DeptID";
            sql += "         select @dYCB=isnull(CostPrice,0),@dYSL=isnull(Stock,0) from StockDept where GoodsID=@iGoods and DeptID=@DeptID and StockID=@iStock";
            sql += "              if (@dYCB*@dYSL+@dPrice*@dCount)>0 and (@dYSL+@dCount)!=0";
            sql += "              begin";
            sql += "                  set @dXCB=round((@dYCB*@dYSL+@dPrice*@dCount)/(@dYSL+@dCount),4)";
            sql += "                  update StockDept set CostPrice=@dXCB where GoodsID=@iGoods and DeptID=@DeptID and StockID=@iStock";
            sql += "              end";
            sql += "          update StockDept set Stock=isnull(Stock,0)+@dCount where GoodsID=@iGoods and DeptID=@DeptID and StockID=@iStock";
            sql += "      end";
            sql += "      else";
            sql += "      begin";
            sql += "          update Stock set Stockr=isnull(Stockr,0)+@dCount where GoodsID=@iGoods and DeptID=@DeptID";
            sql += "          update StockDept set Stock=isnull(Stock,0)+@dCount where GoodsID=@iGoods and StockID=@iStock and DeptID=@DeptID";
            sql += "      end	";
            sql += "  end";
            sql += "  else ";
            sql += "  begin";
            sql += "      if @strSX=0";
            sql += "      begin";
            sql += "          select @dYCB=isnull(CostPrice,0),@dYSL=isnull(Stock,0) from Stock where GoodsID=@iGoods and DeptID=@DeptID";
            sql += "              if (@dYCB*@dYSL-@dPrice*@dCount)>0 and (@dYSL-@dCount)!=0";
            sql += "              begin";
            sql += "                  set @dXCB=round((@dYCB*@dYSL-@dPrice*@dCount)/(@dYSL-@dCount),4)";
            sql += "                  update Stock set CostPrice=@dXCB where GoodsID=@iGoods and DeptID=@DeptID";
            sql += "              end";
            sql += "          update Stock set Stock=isnull(Stock,0)-@dCount where GoodsID=@iGoods and DeptID=@DeptID";
            sql += "          select @dYCB=isnull(CostPrice,0),@dYSL=isnull(Stock,0) from StockDept where GoodsID=@iGoods and DeptID=@DeptID and StockID=@iStock";
            sql += "               if (@dYCB*@dYSL-@dPrice*@dCount)>0 and (@dYSL-@dCount)!=0";
            sql += "               begin";
            sql += "                   set @dXCB=round((@dYCB*@dYSL-@dPrice*@dCount)/(@dYSL-@dCount),4)";
            sql += "                   update StockDept set CostPrice=@dXCB where GoodsID=@iGoods and DeptID=@DeptID and StockID=@iStock";
            sql += "               end";
            sql += "           update StockDept set Stock=isnull(Stock,0)-@dCount where GoodsID=@iGoods and DeptID=@DeptID and StockID=@iStock";
            sql += "       end";
            sql += "       else";
            sql += "       begin";
            sql += "           update Stock set Stockr=isnull(Stockr,0)-@dCount where GoodsID=@iGoods and DeptID=@DeptID";
            sql += "           update StockDept set Stock=isnull(Stock,0)-@dCount where GoodsID=@iGoods and StockID=@iStock and DeptID=@DeptID";
            sql += "       end";
            sql += "   end";

            try { DALCommon.Excu(sql); }
            catch (Exception ex)
            {
                fail++;
                wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，存储过程:ck_updatekc，升级异常:" + ex.Message.ToString());
            }
            if (fail == 0)
            {
                sql = string.Empty;
                sql = "insert into Version([ID],Tip) values('10.1.20111231','" + DateTime.Now.ToString() + "')";
                version = "10.1.20111231";
                try { DALCommon.Excu(sql); }
                catch (Exception ex)
                {
                    fail++;
                    wt.Library.OtherClass.AppendErrorLog("10.1.20111208-10.1.20111231，时间:" + DateTime.Now.ToString() + "，升级表:Version，升级异常:" + ex.Message.ToString());
                }
            }
            if (fail > 0)
                SetUpFail("10");//升级失败
        }

        if (version == "10.1.20111231" || version == "10.1.2011123101")
        {
            string newver = "10.1.20120206";
            string upsqlpath = Server.MapPath("~/updatesql/" + newver);
            if (!Directory.Exists(upsqlpath))
            {
                Directory.CreateDirectory(upsqlpath);
                WebClient client = new WebClient();
                try
                {
                    client.DownloadFile("http://www.differsoft.com/itcontrol/files/10.1.20120206/updatesql/10.1.20120206/20120206001.txt.rar", upsqlpath + "\\20120206001.txt");
                    client.DownloadFile("http://www.differsoft.com/itcontrol/files/10.1.20120206/updatesql/10.1.20120206/20120206002.txt.rar", upsqlpath + "\\20120206002.txt");
                    client.DownloadFile("http://www.differsoft.com/itcontrol/files/10.1.20120206/updatesql/10.1.20120206/20120206003.txt.rar", upsqlpath + "\\20120206003.txt");
                }
                catch (WebException ex)
                {

                }
            }
            if (UpdateVersion("10.1.20111231", newver,3))
                version = newver;
        }

        if (version == "10.1.20120206")
        {
            string newver = "10.1.20120302";
            if (UpdateVersion("10.1.20120206", newver, 3))
                version = newver;
        }
        if (version == "10.1.20120302")
        {
            string newver = "10.1.20120313";
            if (UpdateVersion("10.1.20120302", newver, 2))
                version = newver;
        }
        if (version == "10.1.20120313" || version == "10.1.20120406"|| version == "10.1.20120409")
        {
            string newver = "10.1.20120410";
            if (UpdateVersion("10.1.20120313", newver, 4))
                version = newver;
        }
        if (version == "10.1.20120410")
        {
            string newver = "10.1.20120411";
            if (UpdateVersion("10.1.20120410", newver, 2))
                version = newver;
        }
        if (version == "10.1.20120411")
        {
            string newver = "10.1.20120416";
            if (UpdateVersion("10.1.20120411", newver, 3))
                version = newver;
        }
        if (version == "10.1.20120416")
        {
            string newver = "10.1.20120420";
            if (UpdateVersion("10.1.20120416", newver, 2))
                version = newver;
        }
        if (version == "10.1.20120420")
        {
            string newver = "10.1.20120509";
            if (UpdateVersion("10.1.20120420", newver, 3))
                version = newver;
        }
        if (version == "10.1.20120509")
        {
            string newver = "10.1.20120522";
            if (UpdateVersion("10.1.20120509", newver, 3))
                version = newver;
        }
        if (version == "10.1.20120522")
        {
            string newver = "10.1.20120601";
            if (UpdateVersion("10.1.20120522", newver, 3))
                version = newver;
        }
        if (version == "10.1.20120601")
        {
            string newver = "10.1.20120608";
            if (UpdateVersion("10.1.20120601", newver, 3))
                version = newver;
        }
        if (version == "10.1.20120608")
        {
            string newver = "10.1.20120614";
            if (UpdateVersion("10.1.20120608", newver, 1))
                version = newver;
        }
        if (version == "10.1.20120614")
        {
            string newver = "10.1.20120716";
            if (UpdateVersion("10.1.20120614", newver, 3))
                version = newver;
        }
        if (version == "10.1.20120716")
        {
            string newver = "10.1.20120730";
            if (UpdateVersion("10.1.20120716", newver, 3))
                version = newver;
        }
        if (version == "10.1.20120730")
        {
            string newver = "10.1.20120813";
            if (UpdateVersion("10.1.20120730", newver, 3))
                version = newver;
        }
        if (version == "10.1.20120813")
        {
            string newver = "10.1.20120831";
            if (UpdateVersion("10.1.20120813", newver, 3))
                version = newver;
        }
        if (version == "10.1.20120831")
        {
            string newver = "10.1.20121008";
            if (UpdateVersion(version, newver, 3))
                version = newver;
        }
        if (version == "10.1.20121008")
        {
            string newver = "10.1.20121102";
            if (UpdateVersion(version, newver, 3))
                version = newver;
        }
        if (version == "10.1.20121102")
        {
            string newver = "10.1.20121205";
            if (UpdateVersion(version, newver, 3))
                version = newver;
        }
        if (version == "10.1.20121205")
        {
            string newver = "10.1.20130104";
            if (UpdateVersion(version, newver, 3))
                version = newver;
        }
    }

    /// <summary>
    /// SQL更新
    /// </summary>
    /// <param name="oldversion">原版本号</param>
    /// <param name="newversion">新版本号</param>
    /// <param name="filecount">SQL文件数量</param>
    /// <returns></returns>
    protected bool UpdateVersion(string oldversion, string newversion, int filecount)
    {
        int fail=0;
        string sql = string.Empty;
        string upsqlpath = Server.MapPath("~/updatesql/" + newversion);
        if (!Directory.Exists(upsqlpath))
        {
            fail++;
            wt.Library.OtherClass.AppendErrorLog(oldversion + "-" + newversion + "，时间:" + DateTime.Now.ToString() + "，文件目录不存在");
            SetUpFail("10");
            return false;
        }
        string[] filenames = Directory.GetFiles(upsqlpath);
        Array.Sort(filenames);
        if (filenames.Length != filecount)
        {
            fail++;
            wt.Library.OtherClass.AppendErrorLog(oldversion + "-" + newversion + "，时间:" + DateTime.Now.ToString() + "，文件数不符");
        }
        else
        {
            for (int i = 0; i < filecount; i++)
            {
                using (StreamReader sr = File.OpenText(filenames[i]))
                {
                    sql = sr.ReadToEnd();
                    string[] sqlstrs = sql.Split(new string[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);
                    for(int k=0;k<sqlstrs.Length;k++)
                        if (!sqlstrs[k].Trim().Equals(""))
                        {
                            try { DALCommon.Excu(sqlstrs[k]); }
                            catch (Exception ex)
                            {
                                fail++;
                                wt.Library.OtherClass.AppendErrorLog(oldversion + "-" + newversion + "，时间:" + DateTime.Now.ToString() + "，文件名：" + filenames[i] + "，升级异常:" + ex.Message.ToString());
                            }
                        }
                }
            }
            if (fail == 0)
            {
                //上传升级信息
                DALSysParm dalsysp = new DALSysParm();
                DALSysVali dalsysva = new DALSysVali();
                SysParmInfo syspinfo = dalsysp.GetSysParm();
                string corp = syspinfo.CorpName;
                string regcode = dalsysva.GetValue("ITEM2");
                string param = "id=8";
                param += "&CustomerInfo=" + corp + "&RegCode=" + regcode + "&OldVer=" + oldversion + "&NewVer=" + newversion;
                byte[] postBytes = Encoding.UTF8.GetBytes(param);
                try
                {
                    HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create("http://www.differsoft.com/default/getUpdate.ashx");
                    myRequest.Method = "POST";
                    myRequest.ContentType = "application/x-www-form-urlencoded;charset=utf8";
                    myRequest.ContentLength = postBytes.Length;
                    Stream newStream = myRequest.GetRequestStream();
                    // Send the data.
                    newStream.Write(postBytes, 0, postBytes.Length);
                    newStream.Close();
                }
                catch { }

                sql = string.Empty;
                sql = "insert into Version([ID],Tip) values('"+newversion+"','" + DateTime.Now.ToString() + "')";
                try { DALCommon.Excu(sql); }
                catch (Exception ex)
                {
                    fail++;
                    wt.Library.OtherClass.AppendErrorLog(oldversion + "-" + newversion + "，时间:" + DateTime.Now.ToString() + "，升级表:Version，升级异常:" + ex.Message.ToString());
                }

                Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                AppSettingsSection appSection = (AppSettingsSection)config.GetSection("appSettings");
                if (appSection.Settings["version"].Value != newversion)
                {
                    appSection.Settings["version"].Value = newversion;
                    config.Save();
                }
            }
        }
        if (fail > 0)
            return false;
        else
            return true;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="css"></param>
    protected void SetGp(string css)
    {
        for (int i = 1; i <= 200; i++)
        {
            menu[i - 1] = css;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    protected void SetHf(string str)
    {
        _reg = "ShowDialog(500, 170, 'Please.html', '需要注册');";
        hfAdmin.Value = str;
        _menu = "if(document.getElementById('hfAdmin').value!=''){return false;}";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    protected void SetUpFail(string str)
    {
        _reg = "ShowDialog(500, 170, 'UpdateFail.html', '升级失败');";
        hfAdmin.Value = str;
        _menu = "if(document.getElementById('hfAdmin').value!=''){return false;}";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    protected int DayTs(string time)
    {
        DateTime d1 = DateTime.Parse(time);
        DateTime d2 = DateTime.Now;
        TimeSpan ts = d2 - d1;
        return ts.Days;
    }
    /// <summary>
    /// 退出
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnExit_Click(object sender, EventArgs e)
    {
        //写退出日志
        int operatorid;
        int.TryParse((string)Session["Session_wtUserID"], out operatorid);
        DALUserManage dal = new DALUserManage();
        dal.Logout(operatorid);
       // wt.DB.DbHelperSQL.InsertErrorLogs(1, operatorid, 0, "退出系统");TODO

        Session.Remove("Session_wtUser");
        Session.Remove("Session_wtPur");
        Session.Remove("Session_wtUserID");
        Response.Write("<Script>top.location.href = '../Default.aspx';</Script>");
    }

    protected void btnRefreshOnline_Click(object sender, EventArgs e)
    {
        int iuser = int.Parse(Session["Session_wtUserID"].ToString());
        string OperCode = string.Empty;
        if (Session["OperCode"] == null)
        {
            Response.Redirect("Tip.html");
        }
        else
        {
            OperCode = Session["OperCode"].ToString().Trim();
            if (!OperCode.Equals(""))
            {
                DALUserManage dal = new DALUserManage();
                int rev = dal.RefreshOnline(iuser, OperCode);

                if(rev==1)
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "ftime", "setTimeout('document.getElementById(\"btnRefreshOnline\").click();',30000);", true);
                else
                    Response.Redirect("Tip.html");
            }else
                Response.Redirect("Tip.html");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    protected string _Reg { get { return _reg; } }
    /// <summary>
    /// 
    /// </summary>
    protected string _Menu { get { return _menu; } }

    protected string strTitle { get { return strtitle; } }

    protected int toolHeight { get { return toolheight; } }

    protected string showOL
    {
        get
        {
            if (showol)
                return "";
            else
                return "none";
        }
    }
}
