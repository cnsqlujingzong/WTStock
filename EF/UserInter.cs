using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using wt.DAL;
using Maticsoft.DBUtility;
namespace Coding.Stock.Common
{
   public class UserInter
    {
       /// <summary>
       /// 获取用户积分
       /// </summary>
       /// <param name="uid"></param>
       /// <param name="uname"></param>
       public static int GetUserInter(string uid,string uname,string type)
       {
           string strWhere = "";
           if(type=="month")
           {
               strWhere="  and  datediff(month,_Date,getdate())=0 ";
           }else
               if (type == "week")
               {
                   strWhere = "  and  datediff(week,_Date,getdate())=0 ";
               }
              
           int totle=0;
          //获取销售订单积分  操作人是uid 
           object osellPlanOpt = DbHelperSQL.GetSingle("select count(*) from SellPlan where [OperatorID]=" + uid +strWhere);// and [Status]=3
          if (osellPlanOpt != null)
          {
              totle += Convert.ToInt32(osellPlanOpt) * Convert.ToInt32(AppString.SellPlanOpt);
          }
          //获取销售订单积分  客户所属是uid 
          object osellPlanOf = DbHelperSQL.GetSingle("select count(*) from SellPlan where CustomerID in (select id from CustomerList where SellerID=" + uid + "  )  "+strWhere);//  [Status]=3 and
          if (osellPlanOf != null)
          {
              totle += Convert.ToInt32(osellPlanOf) * Convert.ToInt32(AppString.SellPlanOfSell);
          }
           //获取销售单积分
          object osellOpt = DbHelperSQL.GetSingle("select count(*) from Sell where OperatorID =" + uid+strWhere);//" and [Status]=2 "
          if (osellOpt != null)
          {
              totle += Convert.ToInt32(osellOpt) * Convert.ToInt32(AppString.SellOpt);
          }
          //获取销售单积分  客户所属是uid 
          object osellOf = DbHelperSQL.GetSingle("select count(*) from Sell where CustomerID in (select id from CustomerList where SellerID=" + uid+ " ) "+strWhere+"");//  [Status]=2 and
          if (osellOf != null)
          {
              totle += Convert.ToInt32(osellOf) * Convert.ToInt32(AppString.SellOfSell);
          }

          //服务单 ServiceOffer
          object ServiceOffer = DbHelperSQL.GetSingle("select count(*) from ServiceOffer where sellerID=" + uid);
          if (ServiceOffer != null)
          {
              totle += Convert.ToInt32(ServiceOffer) * Convert.ToInt32(AppString.ServiceOffer);
          }

           if(type=="month")
           {
               strWhere = "  and  datediff(month,Time_Make,getdate())=0 ";
           }else
               if (type == "week")
               {
                   strWhere = "  and  datediff(week,Time_Make,getdate())=0 ";
               }
           
           //服务单积分 操作人
           object serOpt = DbHelperSQL.GetSingle("select count(*) from ServicesList where OperatorID=" + uid + strWhere);
          if (serOpt != null)
          {
              totle += Convert.ToInt32(serOpt) * Convert.ToInt32(AppString.serOpt);
          }
          //服务单 技术人
          object serSpc = DbHelperSQL.GetSingle("select count(*) from ServicesList where DisposalOper='" + uname +"'"+ strWhere);
          if (serSpc != null)
          {
              totle += Convert.ToInt32(serSpc) * Convert.ToInt32(AppString.serSpc);
          }
         
          //服务单 附件、耗材
           /**
          object ServiceMaterial = DbHelperSQL.GetSingle("select count(*) from ServicesMaterial where BillID in () " + uid);
          if (ServiceOffer != null)
          {
              totle += Convert.ToInt32(ServiceOffer) * Convert.ToInt32(AppString.ServiceOffer);
          }**/
          return totle;
       }
       public static int GetTop(string uid, string uname, string type)
       {
          DataTable dt =DbHelperSQL.Query("select * from  [jc_staff] ").Tables[0];
         //select * from jc_staff
          List<orderInt> list = new List<orderInt>();
          int fen=0;
          orderInt o;
          for (int i = 0; i < dt.Rows.Count; i++)
          {
              o= new orderInt();
              o.uname = dt.Rows[i]["_Name"].ToString();
              o.uid = dt.Rows[i]["id"].ToString();
              o.uinter = UserInter.GetUserInter(o.uid, o.uname, type);
              list.Add(o);            
          }
          list = list.OrderByDescending(m => m.uinter).ToList() ;
         int r=  list.FindIndex(m=>m.uid==uid)+1;
         return r;
       }
    }
   public class orderInt 
   {
       public string uname { get; set; }
       public string uid { get; set; }
       public int  uinter { get; set; }
   }
}
