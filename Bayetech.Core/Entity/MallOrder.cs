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
    
    public partial class MallOrder
    {
        public long OrderId { get; set; }
        public string OrderNo { get; set; }
        public Nullable<int> OrderLineNum { get; set; }
        public Nullable<decimal> OrderPrice { get; set; }
        public Nullable<int> OrderNumber { get; set; }
        public Nullable<decimal> OrderAmount { get; set; }
        public Nullable<decimal> OrderDiscount { get; set; }
        public string OrderDiscountName { get; set; }
        public Nullable<byte> OrderStatus { get; set; }
        public Nullable<System.DateTime> OrderUpdateTime { get; set; }
        public string GoodNo { get; set; }
        public string ServiceId { get; set; }
        public Nullable<long> ServiceQQ { get; set; }
        public string BuyerId { get; set; }
        public Nullable<long> BuyerPhone { get; set; }
        public Nullable<long> BuyerQQ { get; set; }
        public Nullable<int> InternalTypeId { get; set; }
        public string GoodType { get; set; }
        public Nullable<System.DateTime> OrderCreatTime { get; set; }
        public string PromoNum { get; set; }
        public string Editor { get; set; }
        public string RefundReason { get; set; }
        public string Remark { get; set; }
        public string ReceiveRole { get; set; }
    }
}
