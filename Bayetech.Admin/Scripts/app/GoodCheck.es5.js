﻿//import commonCompnent from './common.js';

//var _url = "/api/Test/GoodCheck";
//const aa = 1;
//let aaaa = 2;

//var aaa = commonCompnent;
//commonCompnent.postWebJson(_url,null,function(){
//});

//当前执行的函数
"use strict";

(function () {

    var vmData = {
        BaseUrl: common.GetBaseUrl() + "Good/GoodInfo.html?GoodNo=",
        BaseTarget: "_blank",
        keyword: "",
        GoodInfoArray: [],
        ListObj: [{
            GoodNo: "",
            GoodFirstPicture: "",
            aurl: "",
            GoodTitle: "",
            GroupName: "",
            ServerName: "",
            GoodPrice: ""
        }],
        SearchParam: {
            Param: eval('(' + localStorage.SearchParam + ')'),
            Pagination: { //分页对象
                rows: 10, //每页行数，
                page: 1, //当前页码
                order: "GoodNo", //排序字段
                sord: "asc", //排序类型
                records: 10, //总记录数
                total: 10 //总页数。
            }
        }
    };

    var vm = new Vue({
        el: "#CommForm",
        data: vmData,
        created: function created() {},
        methods: {
            findList: function findList() {
                //获取商品的简要列表
                var self = this;
                common.postWebJson(GoodListUrl, self.SearchParam, function (data) {
                    if (data.result) {
                        self.GoodInfoArray = data.content.datas;
                    }
                });
            }
        }
    });
})();

