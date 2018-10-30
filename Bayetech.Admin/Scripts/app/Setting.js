﻿import Vue from '../vue.js'
import comCompnent from '../common.js'
import componentTable from '../components/table-Process.vue'
let vmData = {
    GetSettingUrl: "/api/Setting/GetSettings",
    tools: {
        _comCompnent: comCompnent,
        _componentTable: componentTable
    },
    Types:[],//父级列表select绑定
    ListObj: [
        {
            Id: "",
            key: "",
            Value: "",
            ParentId: "",
            CreateTime: "",//排序
            IsDelete: "",//是否被删除
            Remark:""
        }
    ],
    SearchParam: {
        Param: {//查询条件的参数
            Id: "",
            key: "",
            Value: "",
            ParentId: "",
            CreateTime: "",//排序
            IsDelete: "",//是否被删除
            Remark: ""
        },
        Pagination: {//分页对象
            rows: 10,//每页行数，
            page: 1,//当前页码
            order: "IsHot",//排序字段
            sord: "asc",//排序类型
            records: 10,//总记录数
            total: 10//总页数。
        }
    }
};

new Vue({
    el: '#app',
    data: vmData,
    created() {
        var self = this;
        self.GetParentSettings();
    },
    methods: {
        findList(parentId) {//获取Setting内容
            var self = this;
            self.SearchParam.Param.ParentId = parentId;
            self.tools._comCompnent.getWebJson(self.GetSettingList, self.SearchParam, function (data) {
                $("#QueryList").Btns("reset");
                if (data.result) {
                    self.SearchParam.Pagination = data.content.pagination;
                    self.tools._comCompnent.SetPagination($('#paginator-test'),
                        self.SearchParam, self.findList);
                }
            },function () {
                $("#QueryList").Btns("reset");
            });
        },
        GetParentSettings() {//获取一级下拉类型
            var self = this;
            self.tools._comCompnent.getWebJson(self.GetSettingUrl, {id:0}, function (data) {
                self.Types = data.content;
            });
        },
        TurnToPage(page) {
            var self = this;
            self.SearchParam.Pagination.rows = page;
            self.findList();
        }
    },
    components: {
        comtable: componentTable
    }
});


