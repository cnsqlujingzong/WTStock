using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Coding.Stock.Common
{
   public class AppString
    {
           
       //销售订单操作人积分    
        public static readonly string SellPlanOpt = System.Configuration.ConfigurationManager.AppSettings["SellPlanOpt"];
        //销售订单客户所属人积分
        public static readonly string SellPlanOfSell = System.Configuration.ConfigurationManager.AppSettings["SellPlanOfSell"];
        //销售合同操作人积分
        public static readonly string SellOpt = System.Configuration.ConfigurationManager.AppSettings["SellOpt"];
        //销售合同客户所属人积分 
        public static readonly string SellOfSell = System.Configuration.ConfigurationManager.AppSettings["SellOfSell"];
        //服务单操作人积分 
        public static readonly string serOpt = System.Configuration.ConfigurationManager.AppSettings["serOpt"];
         //服务单技术积分 
        public static readonly string serSpc = System.Configuration.ConfigurationManager.AppSettings["serSpc"];
   
         //服务单 服务报价 
        public static readonly string ServiceOffer = System.Configuration.ConfigurationManager.AppSettings["ServiceOffer"];
         //服务单技术积分 
        public static readonly string serSpc2 = System.Configuration.ConfigurationManager.AppSettings["serSpc"];
   
   
   
   }
}
