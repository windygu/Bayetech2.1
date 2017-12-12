﻿//筛选栏位
define(jsconfig.baseArr, function (Vue, $, common) {

    var html=`
            <div class ="screen-box">
                <div class ="screen-tit">
                    <div class ="l"><b>商品筛选</b><span>共找到<em>579</em>个商品</span></div>
                    <div class ="r">
                        <a href="http://www.7881.com/release-G10-0-100003-1-1.html" class ="sell-a"><em><img src="http://pic.7881.com/7881-2016/images/list/sell-icon.png" width="16" height="16" alt="" /></em>我要出售</a>

                        <a href="http://www.7881.com/procurement-complete-G10-0-0-100003.html" class ="dealfin-a"><em><img src="http://pic.7881.com/7881-2016/images/list/dealfin-icon.png" width="16" height="16" alt="" /></em>交易完成</a>
                    </div>
                </div>
                <div class ="screen-item-box">
                    <div class ="screen-item">
                        <div class ="sl-head"><span title="所在区">所在区</span>：</div>
                        <div class ="sl-body clearfix">
                            <ul class ="clearfix">

                                <li v-for="item in Gourps">
                                    <a href="javascript:void(0)" :title="item.Name">
                                        <span class ="check-icon"></span>
                                        <span class ="text" :value="item.Name" :Id="item.Id" @click="GetSearchAgain">{{item.Name}}</span>
                                    </a>
                                </li>

                            </ul>
                        </div>
                        <div class ="sl-foot">
                            <div class ="sl-foot-function clearfix">

                                <a class ="" href="javascript:void(0);"><span>更多</span><i></i></a>
                            </div>
                            <div class ="sl-foot-btns">
                                <a class ="btn-qx" href="javascript:void(0);">取消</a>
                                <a class ="btn-tj" href="javascript:void(0);">提交</a>
                            </div>
                        </div>
                    </div>
                    <div class ="screen-item">
                        <div class ="sl-head"><span title="性别">性别</span>：</div>
                        <div class ="sl-body clearfix">
                            <ul class ="clearfix">
                                <li>
                                    <a href="javascript:void(0)" title="男">
                                        <span class ="check-icon"></span>
                                        <span class ="text" value="男" unFixKey="50233">男</span>
                                    </a>
                                </li>
                                <li>
                                    <a href="javascript:void(0)" title="女">
                                        <span class ="check-icon"></span>
                                        <span class ="text" value="女" unFixKey="50233">女</span>
                                    </a>
                                </li>
                            </ul>
                        </div>
                        <div class ="sl-foot">
                            <div class ="sl-foot-function clearfix">

                                <a class ="sl-more more-ac" href="javascript:void(0);"><span>更多</span><i></i></a>
                            </div>
                            <div class ="sl-foot-btns">
                                <a class ="btn-qx" href="javascript:void(0);">取消</a>
                                <a class ="btn-tj" href="javascript:void(0);">提交</a>
                            </div>
                        </div>
                    </div>
                    <div class ="screen-item">
                        <div class ="sl-head"><span title="职业">职业</span>：</div>
                        <div class ="sl-body clearfix">
                            <ul class ="clearfix">

                                <li v-for="item in Professions">
                                    <a href="javascript:void(0)" :title="item.ProfessionName">
                                        <span class ="check-icon"></span>
                                        <span class ="text" :value="item.ProfessionName"  @click="GetSearchAgain" :key="item.ProfessionId">{{item.ProfessionName}}</span>
                                    </a>
                                </li>

                            </ul>
                        </div>
                        <div class ="sl-foot">
                            <div class ="sl-foot-function clearfix">
                                <a class ="" href="javascript:void(0);"><span>更多</span><i></i></a>
                            </div>
                            <div class ="sl-foot-btns">s
                                <a class ="btn-qx" href="javascript:void(0);">取消</a>
                                <a class ="btn-tj" href="javascript:void(0);">提交</a>
                            </div>
                        </div>
                    </div>
                </div>
             </div>
           `
    //Api
    var GoodListUrl="/api/GoodInfo/GetList"; //查询列表
    var GroupUrl="/api/GoodInfo/GetGoupNames" //获取所有的服务器名称
    var ProfessionUrl="/api/GoodInfo/GetProfessions"

    var data={
        Gourps: [],
        Severs: [],
        Professions: [],
    };

    var ScreenCompnent={
        template: html,
        data() {
            return data;
        },
        created(){
            var self=this;
            self.GetGroups(1, "Group");
            self.GetProfessions(1);
        },
        methods: {
            GetGroups(gameId, type) {
                var self=this;
                var param = {GameId:gameId,type:type};
                common.getWebJson(GroupUrl, param, function (data) {
                    type=="Group"?self.Gourps=data.content:self.Severs=data.content;
                });
            },
            GetProfessions(gameId) {
                var self=this;
                var param={ GameId: gameId };
                common.getWebJson(ProfessionUrl, param, function (data) {
                    self.Professions=data.content;
                });
            },
            GetSearchAgain() {//条件增加重新搜索
                var self=this;
                var param=common.GetUrlParam();
                common.postWebJson(GoodListUrl, JSON.stringify(param), function (data) {
                    if (data.result) {
                        
                    }
                });
            }
        }
    };

    return ScreenCompnent;
})
