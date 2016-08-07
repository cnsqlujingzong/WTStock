using System;
using System.CodeDom.Compiler;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;

namespace PushMessage
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [GeneratedCode("System.Web.Services", "2.0.50727.5420")]
    [WebServiceBinding(Name = "MsgPushSoap", Namespace = "http://tempuri.org/")]
    public class MsgPush : SoapHttpClientProtocol
    {
        private SendOrPostCallback AddStateOperationCompleted;

        private SendOrPostCallback DelStateOperationCompleted;

        private SendOrPostCallback PushMessageOperationCompleted;

        public MsgPush()
        {
            string item = ConfigurationManager.AppSettings["PushMessage.msgpush"];
            if (item == null)
            {
                base.Url = "http://www.differsoft.com/api/msgpush.asmx";
            }
            else
            {
                base.Url = item;
            }
        }

        [SoapDocumentMethod("http://tempuri.org/AddState", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public int AddState(string StaffName, string UserID, string Channel, string CompanyName, int PhoneType, int StateType, int DeptID)
        {
            object[] staffName = new object[] { StaffName, UserID, Channel, CompanyName, PhoneType, StateType, DeptID };
            return (int)base.Invoke("AddState", staffName)[0];
        }

        public void AddStateAsync(string StaffName, string UserID, string Channel, string CompanyName, int PhoneType, int StateType, int DeptID)
        {
            this.AddStateAsync(StaffName, UserID, Channel, CompanyName, PhoneType, StateType, DeptID, null);
        }

        public void AddStateAsync(string StaffName, string UserID, string Channel, string CompanyName, int PhoneType, int StateType, int DeptID, object userState)
        {
            if (this.AddStateOperationCompleted == null)
            {
                this.AddStateOperationCompleted = new SendOrPostCallback(this.OnAddStateOperationCompleted);
            }
            object[] staffName = new object[] { StaffName, UserID, Channel, CompanyName, PhoneType, StateType, DeptID };
            base.InvokeAsync("AddState", staffName, this.AddStateOperationCompleted, userState);
        }

        public IAsyncResult BeginAddState(string StaffName, string UserID, string Channel, string CompanyName, int PhoneType, int StateType, int DeptID, AsyncCallback callback, object asyncState)
        {
            object[] staffName = new object[] { StaffName, UserID, Channel, CompanyName, PhoneType, StateType, DeptID };
            return base.BeginInvoke("AddState", staffName, callback, asyncState);
        }

        public IAsyncResult BeginDelState(string CompanyName, string UserID, string Channel, string StaffName, int StateType, int DeptID, AsyncCallback callback, object asyncState)
        {
            object[] companyName = new object[] { CompanyName, UserID, Channel, StaffName, StateType, DeptID };
            return base.BeginInvoke("DelState", companyName, callback, asyncState);
        }

        public IAsyncResult BeginPushMessage(string CompanyName, string StaffName, int StateType, int DeptID, AsyncCallback callback, object asyncState)
        {
            object[] companyName = new object[] { CompanyName, StaffName, StateType, DeptID };
            return base.BeginInvoke("PushMessage", companyName, callback, asyncState);
        }

        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }

        [SoapDocumentMethod("http://tempuri.org/DelState", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public int DelState(string CompanyName, string UserID, string Channel, string StaffName, int StateType, int DeptID)
        {
            object[] companyName = new object[] { CompanyName, UserID, Channel, StaffName, StateType, DeptID };
            return (int)base.Invoke("DelState", companyName)[0];
        }

        public void DelStateAsync(string CompanyName, string UserID, string Channel, string StaffName, int StateType, int DeptID)
        {
            this.DelStateAsync(CompanyName, UserID, Channel, StaffName, StateType, DeptID, null);
        }

        public void DelStateAsync(string CompanyName, string UserID, string Channel, string StaffName, int StateType, int DeptID, object userState)
        {
            if (this.DelStateOperationCompleted == null)
            {
                this.DelStateOperationCompleted = new SendOrPostCallback(this.OnDelStateOperationCompleted);
            }
            object[] companyName = new object[] { CompanyName, UserID, Channel, StaffName, StateType, DeptID };
            base.InvokeAsync("DelState", companyName, this.DelStateOperationCompleted, userState);
        }

        public int EndAddState(IAsyncResult asyncResult)
        {
            return (int)base.EndInvoke(asyncResult)[0];
        }

        public int EndDelState(IAsyncResult asyncResult)
        {
            return (int)base.EndInvoke(asyncResult)[0];
        }

        public string EndPushMessage(IAsyncResult asyncResult)
        {
            return (string)base.EndInvoke(asyncResult)[0];
        }

        private void OnAddStateOperationCompleted(object arg)
        {
            if (this.AddStateCompleted != null)
            {
                InvokeCompletedEventArgs invokeCompletedEventArg = (InvokeCompletedEventArgs)arg;
                this.AddStateCompleted(this, new AddStateCompletedEventArgs(invokeCompletedEventArg.Results, invokeCompletedEventArg.Error, invokeCompletedEventArg.Cancelled, invokeCompletedEventArg.UserState));
            }
        }

        private void OnDelStateOperationCompleted(object arg)
        {
            if (this.DelStateCompleted != null)
            {
                InvokeCompletedEventArgs invokeCompletedEventArg = (InvokeCompletedEventArgs)arg;
                this.DelStateCompleted(this, new DelStateCompletedEventArgs(invokeCompletedEventArg.Results, invokeCompletedEventArg.Error, invokeCompletedEventArg.Cancelled, invokeCompletedEventArg.UserState));
            }
        }

        private void OnPushMessageOperationCompleted(object arg)
        {
            if (this.PushMessageCompleted != null)
            {
                InvokeCompletedEventArgs invokeCompletedEventArg = (InvokeCompletedEventArgs)arg;
                this.PushMessageCompleted(this, new PushMessageCompletedEventArgs(invokeCompletedEventArg.Results, invokeCompletedEventArg.Error, invokeCompletedEventArg.Cancelled, invokeCompletedEventArg.UserState));
            }
        }

        [SoapDocumentMethod("http://tempuri.org/PushMessage", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public string PushMessage(string CompanyName, string StaffName, int StateType, int DeptID)
        {
            object[] companyName = new object[] { CompanyName, StaffName, StateType, DeptID };
            return (string)base.Invoke("PushMessage", companyName)[0];
        }

        public void PushMessageAsync(string CompanyName, string StaffName, int StateType, int DeptID)
        {
            this.PushMessageAsync(CompanyName, StaffName, StateType, DeptID, null);
        }

        public void PushMessageAsync(string CompanyName, string StaffName, int StateType, int DeptID, object userState)
        {
            if (this.PushMessageOperationCompleted == null)
            {
                this.PushMessageOperationCompleted = new SendOrPostCallback(this.OnPushMessageOperationCompleted);
            }
            object[] companyName = new object[] { CompanyName, StaffName, StateType, DeptID };
            base.InvokeAsync("PushMessage", companyName, this.PushMessageOperationCompleted, userState);
        }

        public event AddStateCompletedEventHandler AddStateCompleted;

        public event DelStateCompletedEventHandler DelStateCompleted;

        public event PushMessageCompletedEventHandler PushMessageCompleted;
    }
}