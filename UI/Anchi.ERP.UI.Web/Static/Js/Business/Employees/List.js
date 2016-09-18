var $vm = avalon.define({
    $id: "EmployeeList",
    List: [],
    Search: {
        Status: "",
        Code: "",
        Name: "",
        EntryOn: ""
    },
    editEmployeeFn: function (item) {
        layer.open({
            type: 2,
            maxmin: true,
            title: "修改员工信息",
            skin: 'layui-layer-rim',
            area: ['500px', '520px'],
            content: '/Employee/Edit/' + item.Id
        });
    },
    deleteEmployeeFn: function (item) {
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
        url: "/Employee/List",
        type: "POST",
        data: postData,
        success: function (data) {
            $vm.List = data.Data;
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

function addEmployeeFn() {
    layer.open({
        type: 2,
        maxmin: true,
        title: "新增员工",
        skin: 'layui-layer-rim', //加上边框
        area: ['500px', '520px'], //宽高
        content: '/Employee/Add'
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
            url: "/Employee/Delete",
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

// 启用员工
function enableEmployeeFn() {
    var idArray = [];
    var $checkList = $(".table tbody tr td input[type=checkbox]:checked");
    $.each($checkList, function ($index, item) {
        var $checkItem = $(item);
        idArray.push($checkItem.val());
    });

    $.ajax({
        url: "/Employee/Enable",
        type: "POST",
        data: {
            idList: idArray
        },
        success: function (data) {
            refreshListFn();
            $.msg("启用成功。", "success");
        }
    });
}

// 停用员工
function disableEmployeeFn() {
    var idArray = [];
    var $checkList = $(".table tbody tr td input[type=checkbox]:checked");
    $.each($checkList, function ($index, item) {
        var $checkItem = $(item);
        idArray.push($checkItem.val());
    });

    $.ajax({
        url: "/Employee/Disable",
        type: "POST",
        data: {
            idList: idArray
        },
        success: function (data) {
            refreshListFn();
            $.msg("停用成功。", "success");
        }
    });
}