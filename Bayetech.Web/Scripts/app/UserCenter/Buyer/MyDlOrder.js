﻿//我的代练订单
jsconfig.baseArr.push('Scripts/app/UserCenter/Buyer/MyOrders');
define(jsconfig.baseArr, function (Vue,$,common,order) {
    var html =`<p>我的代练订单</p>`;

    var data = {

    }
    var components={
        name: "MyDlOrder",
        template: html,
        data: function () {
            return data;
        },
        created: function () {
           var aaaa = 1;
        },
        mounted:function(){
           var bbbb =1;
        },
        methods: {
        }
    };
    return components;
});