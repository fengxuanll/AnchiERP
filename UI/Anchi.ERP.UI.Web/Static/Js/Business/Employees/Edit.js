function saveEmployeeFn() {
    if ($vm.Code.trim() == "") {
        parent.$.msg("请输入员工编码。", "error");
        return false;
    }
    if ($vm.Name.trim() == "") {
        parent.$.msg("请输入员工姓名。", "error");
        return false;
    }

    $.ajax({
        url: "/Employee/Edit",
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