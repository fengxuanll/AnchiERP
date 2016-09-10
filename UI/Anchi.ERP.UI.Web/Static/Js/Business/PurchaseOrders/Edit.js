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