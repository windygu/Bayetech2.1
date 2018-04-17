﻿var dlmodule = ['vue', 'jquery', 'common', 'nav-top','v-search','DLNavBar','DLList','css!../Content/bootstrap/font-awesome.min', 'css!../Content/bootstrap/bootstrap.min','css!../../Content/common','css!../Content/dailian'];

require(dlmodule, function (Vue, $, common, navt, search,dlnavbar,dllist) {
	var data = {};

	var vm = new Vue({
		el: '#VueApp',
		data: function () {
			return data;
		},
		methods: {

		},
		components: {
			'nav-top': navt,
			'v-search': search,
			'dlnavbar': dlnavbar,
            'dllist':dllist
		}

	});
		
})