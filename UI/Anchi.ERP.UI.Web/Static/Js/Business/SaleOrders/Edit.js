/// <reference path="../../Common.js" />
function saveSaleOrderFn() {
    var postData = $vm.$model;
    $.ajax({
        url: "/Sale/Save",
        type: "POST",
        data: postData,
        success: function () {
            if ($vm.Id == GuidEmpty) {
                $("#fromSaleOrder")[0].reset();
                $vm.ProductList.removeAll();
            }
            $.msg("保存成功。", "success");
        }
    });
}

// 设置已出库
function setOutboundFn() {
    $.ajax({
    	url:"/Sale/Outbound",
    	type:"POST",
    	data: {
    		idList:[$vm.Id]
    	},
    	success: function() {
    		$.msg("出库成功。"， “success”);
    	}
    });
}

// 显示结算窗口
function showSettlementFn() {
	layer.open({
        type: 2,
        title: "维修单结算",
        skin: 'layui-layer-rim',
        area: ['500px', '400px'],
        content: '/Sale/Settlement/' + $vm.Id
    });	
}

// 显示选择客户窗体
function showSelectCustomerFn() {
    layer.open({
        type: 2,
        maxmin: true,
        title: "选择客户",
        skin: 'layui-layer-rim',
        area: ['600px', '500px'],
        content: '/Customer/SelectCustomer'
    });
}

// 选择客户
function selectCustomerFn(item) {
    $vm.CustomerId = item.Id;
    $vm.CustomerName = item.Name;
}

// 显示选择配件窗体
function showSelectProductFn() {
    layer.open({
        type: 2,
        maxmin: true,
        title: "选择配件",
        skin: 'layui-layer-rim',
        area: ['600px', '500px'],
        content: '/Product/SelectRepairProduct'
    });
}

// 选择配件
function addRepairProductFn(item) {
    $vm.ProductList.push({
        ProductId: item.Id,
        Code: item.Code,
        Name: item.Name,
        UnitPrice: item.SalePrice,
        Quantity: 1
    });
}