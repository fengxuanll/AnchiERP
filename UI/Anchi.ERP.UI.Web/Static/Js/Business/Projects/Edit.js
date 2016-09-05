

function saveProjectFn() {
    if ($vm.Code.trim() == "") {
        parent.$.msg("请输入项目编码。", "error");
        return false;
    }
    if ($vm.Name.trim() == "") {
        parent.$.msg("请输入项目名称。", "error");
        return false;
    }
    if ($vm.UnitPrice.trim() == "") {
        parent.$.msg("请输入项目单价。", "error");
        return false;
    }

    $.ajax({
        url: "/Project/Edit",
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