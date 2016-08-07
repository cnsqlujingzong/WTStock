using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BussModule.Biz.Model;
namespace Biz.DAO
{
    public class TaskBuss
    {
        /// <summary>
        /// 获得UserID 任务列表
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public List<Task> GetTaskList(string userID)
        {
            if (!string.IsNullOrEmpty(userID))
            {
                List<Task> list = new List<Task>();
                DataTable dt = DBUtility.DbHelperSQL.Query(string.Format("select * from TaskList where ExerID={0}", userID)).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Task t = new Task();
                        if (dt.Rows[i]["ID"] != null && !string.IsNullOrEmpty(dt.Rows[i]["ID"].ToString()))
                        {
                            t.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                        }
                        if (dt.Rows[i]["DeptID"] != null && !string.IsNullOrEmpty(dt.Rows[i]["DeptID"].ToString()))
                        {
                            t.DeptID = int.Parse(dt.Rows[i]["DeptID"].ToString());
                        }
                        if (dt.Rows[i]["_Date"] != null && !string.IsNullOrEmpty(dt.Rows[i]["_Date"].ToString()))
                        {
                            t._Date = Convert.ToDateTime(dt.Rows[i]["_Date"]);
                        }
                        if (dt.Rows[i]["OperatorID"] != null && !string.IsNullOrEmpty(dt.Rows[i]["OperatorID"].ToString()))
                        {
                            t.OperatorID = int.Parse(dt.Rows[i]["OperatorID"].ToString());
                        }
                        if (dt.Rows[i]["ExeDate"] != null && !string.IsNullOrEmpty(dt.Rows[i]["ExeDate"].ToString()))
                        {
                            t.ExeDate = Convert.ToDateTime(dt.Rows[i]["ExeDate"]);
                        }
                        if (dt.Rows[i]["ExerID"] != null && !string.IsNullOrEmpty(dt.Rows[i]["ExerID"].ToString()))
                        {
                            t.ExerID = int.Parse(dt.Rows[i]["ExerID"].ToString());
                        }
                        t.Status = dt.Rows[i]["Status"] == null ? "" : dt.Rows[i]["Status"].ToString();
                        t.Summary = dt.Rows[i]["Summary"] == null ? "" : dt.Rows[i]["Summary"].ToString();
                        t.CompleteRate = dt.Rows[i]["CompleteRate"] == null ? "" : dt.Rows[i]["CompleteRate"].ToString();
                        t.TaskRemark = dt.Rows[i]["TaskRemark"] == null ? "" : dt.Rows[i]["TaskRemark"].ToString();
                        t.executeRemark = dt.Rows[i]["executeRemark"] == null ? "" : dt.Rows[i]["executeRemark"].ToString();
                        t.Remark = dt.Rows[i]["Remark"] == null ? "" : dt.Rows[i]["Remark"].ToString();
                        if (dt.Rows[i]["Score"] != null && !string.IsNullOrEmpty(dt.Rows[i]["Score"].ToString()))
                        {
                            t.Score = int.Parse(dt.Rows[i]["Score"].ToString());
                        }
                        list.Add(t);
                    }
                    return list;
                }
            }
                return null;
  
        }
        /// <summary>
        /// 获得UserID根据微信账号
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public UserInfo GetUserByWinxin(string weixin)
        {
            if (!string.IsNullOrEmpty(weixin))
            {
                DataTable dt= DBUtility.DbHelperSQL.Query(string.Format("select top 1 * from StaffList where Specialty='{0}'", weixin)).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return DataRowToModel(dt.Rows[0]);
                }
                else {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UserInfo DataRowToModel(DataRow row)
        {
            UserInfo model = new UserInfo();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["DeptID"] != null && row["DeptID"].ToString() != "")
                {
                    model.DeptID = int.Parse(row["DeptID"].ToString());
                }
              
                if (row["_Name"] != null)
                {
                    model._Name = row["_Name"].ToString();
                }
                if (row["Specialty"] != null)
                {
                    model.Specialty = row["Specialty"].ToString();
                }
                if (row["School"] != null)
                {
                    model.School = row["School"].ToString();
                }
             
            }
            return model;
        }
    }
}