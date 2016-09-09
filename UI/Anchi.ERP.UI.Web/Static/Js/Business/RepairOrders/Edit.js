var $vm = avalon.define({
    $id: "EditRepairOrder",
    CustomerName: "",
    CustomerId: "",
    RepairOn: "",
    ReceptionById: "",
    Remark: "",
    ItemList: [],
    ProductList: [],
    TotalProjectAmount: function () {
        var total = 0;
        $.each($vm.ItemList, function (i, item) {
            total += (item.UnitPrice * item.Quantity);
        });
        return total;
    },
    TotalProductAmount: function () {
        var total = 0;
        $.each($vm.ProductList, function (i, item) {
            total += (item.UnitPrice * item.Quantity);
        });
        return total;
    }
});

$(function () {
    laydate({
        elem: '#txtRepairOn',
        istoday: true,
        choose: function (datas) { //选择日期完毕的回调
            $vm.RepairOn = datas;
        }
    });
});

function showSelectProjectFn() {
    layer.open({
        type: 2,
        maxmin: true,
        title: "选择维修项目",
        skin: 'layui-layer-rim',
        area: ['600px', '500px'],
        content: '/Project/SelectRepairProject'
    });
}

function addRepairProjectFn(item) {
    $vm.ItemList.push({
        ProjectId: item.Id,
        EmployeeId: "",
        Code: item.Code,
        Name: item.Name,
        UnitPrice: item.UnitPrice,
        Quantity: 1
    });
}

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

function addRepairProductFn(item) {
    $vm.ProductList.push({
        ProductId: item.Id,
        Code: item.Code,
        Name: item.Name,
        UnitPrice: item.SalePrice,
        Quantity: 1
    });
}

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

function selectCustomerFn(item) {
    $vm.CustomerId = item.Id;
    $vm.CustomerName = item.Name;
}

function saveRepairOrderFn() {
    var postData = $vm.$model;
    $.ajax({
        url: "/Repair/Add",
        type: "POST",
        data: postData,
        success: function (data) {
            $("#EditRepairOrder")[0].reset();
            $.msg('添加成功。', "success");
        }
    });
}