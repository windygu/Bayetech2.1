//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bayetech.Core.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_WorkFlow_Notify
    {
        public string WNT_ID { get; set; }
        public string WFM_ID { get; set; }
        public string Receiver { get; set; }
        public string ReceiverName { get; set; }
        public string Executor { get; set; }
        public string ExecutorName { get; set; }
        public string Sender { get; set; }
        public string SenderName { get; set; }
        public System.DateTime ReceiveTime { get; set; }
        public Nullable<int> Transact_Type { get; set; }
        public long Transact_Role { get; set; }
        public int IsShow { get; set; }
        public Nullable<int> IsTempSave { get; set; }
        public string CurWEBIP { get; set; }
        public Nullable<bool> Showinmail { get; set; }
        public Nullable<bool> IsNew { get; set; }
        public int TempSaveCount { get; set; }
        public System.DateTime dRecordCreationDate { get; set; }
        public string sRecordCreator { get; set; }
        public string sRecordVersion { get; set; }
        public int Disp_ID { get; set; }
        public int DelayLimit { get; set; }
        public string RoleCode { get; set; }
    }
}