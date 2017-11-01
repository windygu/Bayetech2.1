﻿//模块之间的操作
require(['vue', 'jquery', 'common', 'v-header', 'v-footer', 'footer-server', 'footer-nav', 'indexTab', 'convenience', 'hotgamelist', 'banner-box', 'tabsList-box', 'c-tab', "v-gameranking", 'index-adv', 'mgame-list', 'partner', 'index-nav'], function (Vue, $, common, head, footer, footerserver, footernav, indexTab, convenience, hotgamelist, bannerBox, tabsListbox, ctab, vgameranking, indexadv, mgamelist, partner, indexnav) {
    debugger;
    new Vue({
        el: '#app',
        data() {
            return {
                tab1: indexTab,
                tab2: vgameranking,
            }
        },
        created: function () {

        },
        components: {
            "v-header": head,
            "v-footer": footer,
            "footer-server": footerserver,
            "footer-nav": footernav,
            "convenience": convenience,
            "hot-game-list": hotgamelist,
            "banner-box": bannerBox,
            "tabslist-box": tabsListbox,
            "c-tab": ctab,
            "index-adv": indexadv,
            "mgame-list": mgamelist,
            "partner": partner,
            "index-nav":indexnav,
        }
    });

});