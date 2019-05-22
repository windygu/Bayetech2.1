﻿/// <reference path="app/ServiceCenter/sevicelogo.js" />
/// <reference path="app/ServiceCenter/sevicelogo.js" />
var webUrl = window.document.location.pathname.indexOf("Bayetech.Web") > -1 ? window.document.location.pathname.split("Bayetech.Web")[0] + "Bayetech.Web/" : "/";
var jsconfig = {
    baseUrl: webUrl,
    //urlArgs: 'v=' + (new Date()).getTime(),//清除缓存
    baseArr: ['vue', 'jquery', 'common'],
    paths: {
        'vue': 'Scripts/vue',
        'jquery': 'Scripts/jquery-2.2.2.min',
        'bootstrap': 'Scripts/bootstrap.min',
        'upload': 'Scripts/fileinput',
        'common': 'Scripts/common',
        'bootstrapValidator': 'Scripts/bootstrapValidator',
        'bootstrap-paginator': 'Scripts/bootstrap-paginator',
        'datepicker': 'Scripts/bootstrap-datepicker',
        'swiper': 'Scripts/swiper',
        'text': "Scripts/text",
        //'v-partner': "Scripts/app/Home/partner",
        "v-search": "Scripts/app/Search/Search",
        "search-dropdown": "Scripts/app/Search/search-dropdown",

        'helpLeft': 'Scripts/app/HelpCenter/left',
        'helpButtom': 'Scripts/app/HelpCenter/bottom',
        'SignLeftModule': 'Scripts/app/Sign/signLeft',
        'SignRightModule': 'Scripts/app/Sign/signRight',
        'index-notice': 'Scripts/app/Home/notice',
        'index-consult': 'Scripts/app/Home/consult',
        'index-convenience': 'Scripts/app/Home/convenience',
        'index-hotgamelist': 'Scripts/app/Home/hotgamelist',
        'index-banner': 'Scripts/app/Home/banner',
        'index-slidebox': 'Scripts/app/Home/slidebox',
        'index-adv01': 'Scripts/app/Home/adv01',
        'index-tabslist': 'Scripts/app/Home/tabslist',
        'index-gameranking': "Scripts/app/Home/gameranking",
        'index-adv': "Scripts/app/Home/adv",
        'index-mgamelist': "Scripts/app/Home/mgamelist",
        'index-nav': "Scripts/app/Home/nav",
        'ScreenBox': "Scripts/app/GoodList/ScreenBox",
        'GoodList': 'Scripts/app/GoodList/GoodList',
        'ScreenModel': 'Scripts/app/PointTrading/screen',
        "nav-dropdown": "Scripts/app/Home/nav-dropdown",
        'GoodInfo': 'Scripts/app/GoodInfo/GoodInfo',
        'GoodPics': 'Scripts/app/GoodInfo/GoodPics',
        'Nav': 'Scripts/app/GoodInfo/Nav',
        'OrderPay': 'Scripts/app/PlaceOrder/OrderPay',
        'SureBuy': 'Scripts/app/PlaceOrder/SureBuy',
        "v-search": "Scripts/app/Search/Search",
        "search-dropdown": "Scripts/app/Search/search-dropdown",
        "search-gamedropdown": "Scripts/app/Search/search-gamedropdown",
        'AccountOrder': 'Scripts/app/MakeGoodInfo/AccountOrder',
        'CashOrder': 'Scripts/app/MakeGoodInfo/CashOrder',
        'GoldOrder': 'Scripts/app/MakeGoodInfo/GoldOrder',
        'PersonalHead': "Scripts/app/PersonalCenter/head",
        'Pavigation': "Scripts/app/PersonalCenter/pavigationBar",
        'PwdRecoverTem': "Scripts/app/Login/PwdRecover/PwdRecoverTem",
        'PersonRight': "Scripts/app/PersonalCenter/righttop",
        'PersonButtom': "Scripts/app/PersonalCenter/rightbuttom",
        'Percontent': "Scripts/app/PersonalCenter/content",
        'ServiceLogo': "Scripts/app/ServiceCenter/sevicelogo",
        'ServiceNav': "Scripts/app/ServiceCenter/servicepavigation",
        'ServiceButtom': "Scripts/app/ServiceCenter/servicenew",
        'ServiceFoot': "Scripts/app/ServiceCenter/footeradvan",
        'ServiceCall': "Scripts/app/ServiceCenter/ServiceColl",
        'ServicePusht': "Scripts/app/ServiceCenter/servicepusht",
        'ServiceInfa': "Scripts/app/ServiceCenter/serviceinfo",
        'VueRouter': 'Scripts/vue-router.min',
        'game-list': 'Scripts/app/Game/List',
        'API': 'Scripts/app/API/All',
		//代练
        'InfoList': 'Scripts/app/DLService/InfoList',
        'DLList': 'Scripts/app/DLService/DLLists/DLList',
        'DLNavBar': 'Scripts/app/DLService/DLLists/NavBar',
        'DLDetail': 'Scripts/app/DLService/DLDetail/DLDetail',
        'DLBuyNow': 'Scripts/app/DLService/DLBuyNow/DLBuyNow',
    	//资讯中心
		
		
         //Shared模块
        'v-header': 'Scripts/app/Shared/header',
        'v-footer': 'Scripts/app/Shared/footer',
        "v-nav": 'Scripts/app/Shared/nav',
        'v-tab': "Scripts/app/Shared/tab",
        'v-menu': "Scripts/app/Shared/menu",
        "nav-top": "Scripts/app/Shared/nav-top",
        'footer-server': 'Scripts/app/Shared/footer-server',
        'DynamicInput': 'Scripts/app/Shared/dynamicInput',
        'FileUpload': 'Scripts/app/Shared/FileUpload', 

        //Shared模块

    },
    map: { 
        '*': {
            'css': 'Scripts/css.min'
        }
    },
    shim: {
        'bootstrap': {
            deps: ['jquery', 'css!../Content/bootstrap/bootstrap.min'],
            exports: 'aaaa'
        },
        'bootstrapValidator': {
            deps: ['bootstrap'],
            exports: 'validate'
        },
        'bootstrap-paginator':{
            deps: ['bootstrap'],
            exports: 'paginator'
        },
        'datepicker': {
        	deps: [ 'bootstrap'],
        	exports: 'datepicker'
        },
        'swiper': {
            deps: ['bootstrap', 'css!../Content/swiper/swiper.min'],
            exports: 'Swiper',
        },
        'uploadPackage': {
            deps: ['jquery', 'bootstrap','css!../Content/fileupload/fileinput','upload'],
            exports:'upload'
        }
    }
};
require.config(jsconfig);

var config={
    siteName: "游戏联盟",
    baseUrl: webUrl,
    location: window.location.href||'', 
    width: document.documentElement.clientWidth>0?document.documentElement.clientWidth:document.body.clientWidth,
    height: document.documentElement.clientHeight>0?document.documentElement.clientHeight:document.body.clientHeight,
};


//var RouterConfig = {};

//RouterConfig.Shared = {
//    'v-header': 'Scripts/app/Shared/header',
//    'v-footer': 'Scripts/app/Shared/footer',
//    "v-nav": 'Scripts/app/Shared/nav',
//    'v-tab': "Scripts/app/Shared/tab",
//    'v-menu': "Scripts/app/Shared/menu",
//    "nav-top": "Scripts/app/Shared/nav-top",
//    'footer-server': 'Scripts/app/Shared/footer-server',
//    'footer-nav': 'Scripts/app/Shared/footer-nav',
//    'DynamicInput': 'Scripts/app/Shared/dynamicInput',
//    'FileUpload': 'Scripts/app/Shared/FileUpload',
//}