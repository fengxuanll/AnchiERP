function selectPurchaseOnFn() {
    $vm.PurchaseOn = $("#txtPurchaseOn").val();
}

function savePurchaseOrderFn() {
    var postData = $vm.$model;
    $.ajax({
        url: "/Purchase/Save",
        type: "POST",
        data: postData,
        success: function () {
            if ($vm.Id == GuidEmpty) {
                $("#fromPurchaseOrder")[0].reset();
                $vm.ProductList.removeAll();
            }
            $.msg("保存成功。", "success");
        }
    });
}

function showSelectSupplierFn() {
    layer.open({
        type: 2,
        maxmin: true,
        title: "选择供应商",
        skin: 'layui-layer-rim',
        area: ['600px', '500px'],
        content: '/Supplier/SelectSupplier'
    });
}

function selectSupplierFn(item) {
    $vm.SupplierId = item.Id;
    $vm.SupplierName = item.Name;
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

function initPurchaseOrderFn(Id) {
    $.ajax({
        url: "/Purchase/GetEditModel",
        type: "POST",
        data: {
            Id: Id
        },
        success: function (data) {
            $vm.SupplierId = data.SupplierId;
            $vm.SupplierName = data.Supplier ? data.Supplier.Name : "";
            $vm.PurchaseOn = data.PurchaseOn;
            $vm.PurchaseById = data.PurchaseById;
            $vm.Amount = data.Amount;
            $vm.Remark = data.Remark;

            $.each(data.ProductList, function (i, item) {
                $vm.ProductList.push({
                    Id: item.Id,
                    ProductId: item.ProductId,
                    Code: item.Product ? item.Product.Code : "",
                    Name: item.Product ? item.Product.Name : "",
                    UnitPrice: item.UnitPrice,
                    Quantity: item.Quantity
                });
            });
        }
    });
}

function setArrivalFn() {
    $.ajax({
        url: "/Purchase/SetArrival",
        type: "POST",
        data: {
            idList: [$vm.Id]
        },
        success: function (data) {
            $.msg("设置全部到货成功。", "success");
            location.reload();
        }
    });
}

function showSettlementFn() {
    layer.open({
        type: 2,
        maxmin: true,
        title: "采购单结算",
        skin: 'layui-layer-rim',
        area: ['500px', '400px'],
        content: '/Purchase/Settlement/' + $vm.Id
    });
}