var $vm = avalon.define({
    $id: "UserList",
    List: [],
    Search: {
        TrueName: "",
        LoginName: ""
    },
    editUserFn: function (item) {
        layer.open({
            type: 2,
            maxmin: true,
            title: "修改用户信息",
            skin: 'layui-layer-rim',
            area: ['500px', '600px'],
            content: '/User/Edit/' + item.Id
        });
    },
    deleteUserFn: function (item) {
        deleteSelectedRowFn(item.Id);
    }
});

$(function () {
    refreshListFn();
});

function refreshListFn(pageIndex) {
    var postData = $vm.Search.$model;
    postData.PageIndex = pageIndex || 0;
    $.ajax({
        url: "/User/ListUser",
        type: "POST",
        data: postData,
        success: function (data) {
            var itemList = [];
            $.each(data.Data, function (i, item) {
                item.StatusName = item.Status == 1 ? "正常" : "停用";
                itemList.push(item);
            });

            $vm.List = itemList;
            laypage({
                cont: 'divPager', //容器。值支持id名、原生dom对象，jquery对象,
                curr: data.PageIndex + 1,
                pages: data.TotalPage, //总页数
                groups: 3, //连续分数数0
                skip: true, //不显示上一页
                jump: function (obj, first) {
                    if (!first) {
                        refreshListFn(obj.curr - 1);
                    }
                }
            });
        }
    });
}

function addUserFn() {
    layer.open({
        type: 2,
        maxmin: true,
        title: "新增用户",
        skin: 'layui-layer-rim', //加上边框
        area: ['500px', '600px'], //宽高
        content: '/User/Add'
    });
}

function deleteSelectedRowFn(Id) {
    var idArray = [];
    if (!Id) {
        var $checkList = $(".table tbody tr td input[type=checkbox]:checked");
        $.each($checkList, function ($index, item) {
            var $checkItem = $(item);
            idArray.push($checkItem.val());
        });
    } else {
        idArray.push(Id);
    }

    if (idArray.length == 0) {
        $.msg("请先选择需要删除的数据。", "error");
        return;
    }

    layer.confirm("是否确定删除？", function () {
        $.ajax({
            url: "/User/Delete",
            type: "POST",
            data: {
                Ids: idArray
            },
            success: function (data) {
                refreshListFn();
                $.msg("删除成功。", "success");
            }
        });
    });
}

function updateUserStatusFn(status) {
    var idArray = [];
    var $checkList = $(".table tbody tr td input[type=checkbox]:checked");
    $.each($checkList, function ($index, item) {
        var $checkItem = $(item);
        idArray.push($checkItem.val());
    });

    if (idArray.length == 0) {
        $.msg("请先选择需要操作的数据。", "error");
        return;
    }

    $.ajax({
        url: "/User/UpdateStatus",
        type: "POST",
        data: {
            IdList: idArray,
            Status: status
        },
        success: function (data) {
            $.msg("操作成功。", "success");
            refreshListFn();
        }
    });
}