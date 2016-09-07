var $vm = avalon.define({
    $id: "EditRepairOrder",
    CustomerName: "",
    CustomerId: "",
    RepairOn: "",
    ReceptionById: "",
    TotalProjectAmount: 0,
    TotalProductAmount: 0,
    Remark: "",
    ItemList: [],
    ProductList: []
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
    $vm.ItemList.push(item);
}

function removeRepairProjectFn(item) {
    $vm.ItemList.remove(item);
}

function showSelectProductFn() {
    layer.open({
        type: 2,
        maxmin: true,
        title: "选择配件",
        skin: 'layui-layer-rim',
        area: ['600px', '500px'],
        content: '/Project/SelectRepairProject'
    });
}

function addRepairProductFn() {
    $vm.ProductList.push(item);
}

function removeRepairProductFn(item) {
    $vm.ProductList.remove(item);
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