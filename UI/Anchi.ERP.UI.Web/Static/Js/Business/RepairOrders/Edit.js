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
            $("#EditRepairOrder")[0].reset();
            $.msg('添加成功。', "success");
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
            $vm.CustomerId = data.Customer.Id;
            $vm.CustomerName = data.Customer.Name;
            $vm.RepairOn = data.RepairOn;
            $vm.ReceptionById = data.ReceptionById;
            $vm.Remark = data.Remark;
            $.each(data.ItemList, function (i, item) {
                $vm.ItemList.push({
                    ProjectId: item.Id,
                    EmployeeId: item.EmployeeId,
                    Code: item.Code,
                    Name: item.Name,
                    UnitPrice: item.UnitPrice,
                    Quantity: item.Quantity
                });
            });
            $.each(data.ProductList, function (i, item) {
                $vm.ProductList.push({
                    ProductId: item.Id,
                    Code: item.Code,
                    Name: item.Name,
                    UnitPrice: item.UnitPrice,
                    Quantity: item.Quantity
                });
            });
        }
    });
}