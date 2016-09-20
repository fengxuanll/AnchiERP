function saveProductFn() {
    if ($vm.Code.trim() == "") {
        parent.$.msg("请输入配件编码。", "error");
        return false;
    }
    if ($vm.Name.trim() == "") {
        parent.$.msg("请输入配件名称。", "error");
        return false;
    }

    $.ajax({
        url: "/Product/Edit",
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