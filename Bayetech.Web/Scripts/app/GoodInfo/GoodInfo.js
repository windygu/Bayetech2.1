﻿//注册模块
define(jsconfig.baseArr, function (Vue, $, common) {
    //Api
    //var _DealCheckUrl = "/api/DealCheck/GetCheckInfo"; //查找当前页面的数据
    var _GetGoodInfoUrl = "/api/GoodInfo/GetGoodInfo";

    //模板
    var goodInfoHtml=`
        <div class="w1190 dnfbuess">
        <div class ="info-pic">
                <div class="picFocus">
                    <ul>
                        <li>
                            <img src="../../Content/Images/b123f30809434931a6e623fad7b166cf.png" width="338" height="338" />
                        </li>
                    </ul>
                </div>
                <div class="good-id">
                    <!--<p class ="bianhao">编号：<span>{{GoodNo}}</span></p>-->
                    <p class ="riqi">日期：<span>{{AddTime.split('T')[0]}}</span></p>
                    <div class="sharep">
                        <div class="bdsharebuttonbox bdshare-button-style0-16" data-tag="share_1">
                            <a class="bds_more" data-cmd="more">分享</a>
                        </div>
                    </div>
                </div>
            </div>

            <div class ="info-good">
                <h3 class ="title">{{GoodTitle}}</h3>

                <!--<div class="package-price">
                    <div class="price-con">
                        <h3>
                            <p class ="nowprice">价格: <span><em>￥</em>{{GoodPrice}}</span></p>
                            <p class ="wantprice"><em class ="tags icon-jgxs"></em><a href="wantPriceUrl">我要议价</a></p>
                        </h3>
                    </div>
                    <h4>
                        安全等级：<em :class ="level"></em>
                        <span class="deal-num">{{HistoryAccount == '0'?'此账号首次在游戏联盟出售': '此账号有'+HistoryAccount+'次交易记录'}}</span>
                    </h4>
                </div>
                <div class ="game-ensure" >
                    <p class ="type">类型：<span>{{GoodTypeName}}</span></p>
                    <p class ="type">区服：<span>{{GroupName}}/{{ServerName}}</span></p>
                </div>
                <div class="role-info">
                    <ul>
                        <li v-for="item in mallGoodInfo"><span>{{item.DescriptionName}}：</span><em>{{item.DescriptionValue}}</em></li>
                    </ul>
                </div>-->

				<ul class="pro_property">
					<li class="pro_other pro_other_price clearfix">
						<span>商品价格：</span>
						<em>¥{{GoodPrice}}</em>
					</li>
					<li class="pro_other clearfix">
						<span>安全等级：</span><em :class ="level"></em>
						<span class="deal-num">{{HistoryAccount == '0'?'此账号首次在游戏联盟出售': '此账号有'+HistoryAccount+'次交易记录'}}</span>
					</li>
					<li class="pro_other clearfix">
						<span>商品类型：</span>
						<em class="" style="width: 140px; overflow: hidden; height: 20px;">{{GoodTypeName}}</em>
						<span>浏览次数：</span>
						<em class="">5555</em>
					</li>
					<li class="pro_other clearfix">
						<span>商品编号：</span>
						<em class="">{{GoodNo}}</em>
						<!--<a href="javascript:void();" onclick="copyToClip('ID20180201000040-43574')">【复制编号】</a>-->
					</li>
					<li class="pro_other clearfix">
						<span>游戏区服：</span>
						<em title="地下城与勇士/广西区/广西1区" class="fcolor_b">地下城与勇士/{{GroupName}}/{{ServerName}}</em>
					</li>
					<!--<li class="pro_other pro_more clearfix">
						<span>商品库存：</span><em>1</em>
						<span>剩余天数：</span><em>9天</em>
						<span>方便交易：</span><em>全天</em>
					</li>-->
					<li class="gline"></li>
					<!--<li class="pro_other">
						<div class="clearfix">
							<span>诚信保障：</span>
							<div class="p_dzs clearfix" style="float: left;"><em class="tipso_style" data-tipso="UU898帐号交易"><img src="//s.img898.com/www/png/files/zhangicon.png" alt="账号商品">账号商品</em><em class="tipso_style" data-tipso="卖家保证资料真实，买不到就赔钱"><img src="//s.img898.com/www/png/images/zlbz.png" alt="资料保真">资料保真</em><em class="tipso_style" data-tipso="如有找回，全额赔付"><img src="//s.img898.com/www/png/images/zhbp.png" alt="找回包赔">找回包赔</em></div>
						</div>
					</li>-->
				</ul>

                <div class="detail_ico">
                    <label>服务：</label>
                    <a href="javascript:void(0)" class="curr"><i class="tags icon-wl"></i></a>
                    <a href="javascript:void(0)"><i class="tags icon-zhyz"></i></a>
                    <a href="javascript:void(0)"><i class="tags icon-zhbp"></i></a>
                    <a href="javascript:void(0)"><i class="tags icon-jgxs"></i></a>
                    <div class="ico_text">
                        <p><i class="tags icon-ptdf"></i>寄售商品：货在游戏联盟，款到立即发货。</p>
                        <p style="display: none;"><i class ="tags icon-zhyz"></i>此帐号注册资料已通过游戏联盟验证。</p>
                        <p style="display: none;"><i class ="tags icon-zhbp"></i>找回包赔：如交易成功后您购买的商品三个月内出现被卖家找回，游戏联盟将负责损失赔偿</p>
                        <p style="display: none;"><i class="tags icon-jgxs"></i>价格协商：此商品可以联系客服进行议价</p>
                    </div>
                </div>

                <div class="rent-btn">
                    <a href="#" @click = "BuyNow(GoodNo)">立即购买</a>
                </div>
            </div>

            <div class ="seller-info" style="height: 500px;">
                <div class ="sellhead">
                    <img src="../../Content/NewImages/10.jpg" />
                </div>
                <div class ="sellstar">
                    <p>卖家信誉：<a href="http://www.7881.com/helpcenter/36057564234053938.html" target="_blank">
                            <em class ="startall"></em>
                            <em class ="startall"></em>
                            <em class ="startall"></em>
                            <em class ="startall"></em>
                        </a>
                    </p>
                </div>
                <div class ="selldata">
                    <p>成交订单：<span>{{TotalNum}}笔</span></p>
                    <p>取消订单：<span>{{CancelNum}}笔</span></p>
                    <p>成交概率：<span>{{(parseFloat((TotalNum-CancelNum) /TotalNum*100)).toFixed(2)}}%  </span></p>
                </div>
                </div>
            </div>
        `

    //定义数据
    var data = {
        BaseUrl: common.GetBaseUrl() + "PlaceOrder/PlaceOrder.html?GoodNo=",
        AddTime: "",
        GoodNo: "",
        GoodTitle: "",
        GoodPrice: 280,
        GoodTypeName: "",
        GroupName: "",
        ServerName: "",
        TotalNum: "",
        CancelNum: "",
        wantPriceUrl: "http://search.7881.com/201612376390646.html#",
        level: "stars-box",
        HistoryAccount: "此账号首次在就游戏联盟出售",
        mallGoodInfo: [
            { DescriptionName: "", DescriptionValue: "" }
        ]
    }

    var goodInfoComponent = {//全局注册
        template: goodInfoHtml,
        data() {
            return data;
        },
        created() {
            this.GetGoodInfo(common.GetUrlParam("","GoodNo"));//获取商品信息。
        },
        methods: {
            GetGoodInfo(goodno) {
                var _self = this;
                common.getWebJson(_GetGoodInfoUrl, { goodNo: goodno }, function (data) {
                    if (data.result) {
                        _self.AddTime = data.content.AddTime;
                        _self.GoodNo = data.content.GoodNo;
                        _self.GoodTitle = data.content.GoodTitle;
                        _self.GoodPrice = data.content.GoodPrice;
                        _self.GroupName = data.content.GroupName;
                        _self.ServerName = data.content.ServerName;
                        _self.HistoryAccount = data.content.HistoryAccount;
                        _self.GoodTypeName = data.content.GoodTypeName;
                        _self.TotalNum = data.content.TotalNum;
                        _self.CancelNum = data.content.CancelNum;
                        _self.$data.mallGoodInfo = data.content.mallGoodInfo;

                        _self.$root.$emit('GoodInfoHere', data);//触发事件并传播
                    } 
                });
            },
            GetNavBar() {
                common.getWebJson(_GetNavBarUrl, { accountName: this.$props.value.Iphone }, function (data) {
                    if (data == false) {
                        this.data = data.content;
                    }
                });
            },
            BuyNow(GoodNo) {//立即购买
                window.open(this.BaseUrl + GoodNo);
            }
        }
    }

    return goodInfoComponent;
})