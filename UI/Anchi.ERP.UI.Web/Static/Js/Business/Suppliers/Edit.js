function saveSupplierFn() {
    if ($vm.CompanyName.trim() == "") {
        parent.$.msg("请输入供应商名称。", "error");
        return false;
    }
    if ($vm.Contact.trim() == "") {
        parent.$.msg("请输入供应商联系人。", "error");
        return false;
    }
    if ($vm.Tel.trim() == "") {
        parent.$.msg("请输入供应商联系电话。", "error");
        return false;
    }

    $.ajax({
        url: "/Supplier/Edit",
        type: "POST",
        data: $vm.$model,
        success: function () {
            parent.$.msg('保存成功。', "success");
            parent.refreshListFn();
            parent.layer.close(parent.layer.getFrameIndex(window.name));
        }
    });
    return false;
}