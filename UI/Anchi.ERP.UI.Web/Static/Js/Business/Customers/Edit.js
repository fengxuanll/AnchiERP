function saveCustomerFn() {
    if ($vm.Name.trim() == "") {
        parent.$.msg("请输入客户姓名。", "error");
        return false;
    }
    if ($vm.CarNumber.trim() == "") {
        parent.$.msg("请输入车牌号。", "error");
        return false;
    }

    $.ajax({
        url: "/Customer/Edit",
        type: "POST",
        data: $vm.$model,
        success: function () {
            parent.$.msg('保存成功。', "success");
            parent.refreshListFn();
            layer_close();
        }
    });
    return false;
}