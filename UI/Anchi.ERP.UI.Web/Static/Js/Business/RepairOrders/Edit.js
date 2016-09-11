function selectRepairOnFn() {
    $vm.RepairOn = $("#txtRepairOn").val();
}

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
        url: "/Repair/Edit",
        type: "POST",
        data: postData,
        success: function (data) {
            if ($vm.Id == GuidEmpty) {
                $("#EditRepairOrder")[0].reset();
                $vm.ItemList.removeAll();
                $vm.ProductList.removeAll();
            }
            $.msg('保存成功。', "success");
        }
    });
}

function initRepairOrderFn(Id) {
    $.ajax({
        url: "/Repair/GetEditModel",
        type: "POST",
        data: {
            Id: Id
        },
        success: function (data) {
            if (!data)
                return;

            $vm.Id = data.Id;
            $vm.Amount = data.Amount;
            $vm.CustomerId = data.Customer.Id;
            $vm.CustomerName = data.Customer.Name;
            $vm.RepairOn = data.RepairOn;
            $vm.ReceptionById = data.ReceptionById;
            $vm.Remark = data.Remark;
            $.each(data.ItemList, function (i, item) {
                $vm.ItemList.push({
                    Id: item.Id,
                    ProjectId: item.ProjectId,
                    EmployeeId: item.EmployeeId,
                    Code: item.Project ? item.Project.Code : "未知",
                    Name: item.Project ? item.Project.Name : "未知",
                    UnitPrice: item.UnitPrice,
                    Quantity: item.Quantity
                });
            });
            $.each(data.ProductList, function (i, item) {
                $vm.ProductList.push({
                    Id: item.Id,
                    ProductId: item.ProductId,
                    Code: item.Product ? item.Product.Code : "未知",
                    Name: item.Product ? item.Product.Name : "未知",
                    UnitPrice: item.UnitPrice,
                    Quantity: item.Quantity
                });
            });
        }
    });
}

// 设置已完工
function setCompletedFn() {
    $.ajax({
        url: "/Repair/Complete",
        type: "POST",
        data: {
            idList: [$vm.Id]
        },
        success: function () {
            $.msg("设置已完工成功。", "success");
        }
    });
}

// 显示结算窗口
function showSettlementFn() {
    layer.open({
        type: 2,
        maxmin: true,
        title: "维修单结算",
        skin: 'layui-layer-rim',
        area: ['500px', '400px'],
        content: '/Repair/Settlement/' + $vm.Id
    });
}