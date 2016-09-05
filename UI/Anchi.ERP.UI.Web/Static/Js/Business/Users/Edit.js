function saveUserFn() {
    if ($vm.TrueName.trim() == "") {
        parent.$.msg("请输入用户姓名。", "error");
        return false;
    }
    if ($vm.LoginName.trim() == "") {
        parent.$.msg("请输入登录名。", "error");
        return false;
    }

    $.ajax({
        url: "/User/Edit",
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