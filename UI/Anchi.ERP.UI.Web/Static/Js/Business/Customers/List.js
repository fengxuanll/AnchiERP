var $vm = avalon.define({
    $id: "CustomerList",
    List: [],
    Search: {
        Name: "",
        CarNumber: ""
    },
    editCustomerFn: function (item) {
        layer.open({
            type: 2,
            maxmin: true,
            title: "修改客户信息",
            skin: 'layui-layer-rim',
            area: ['500px', '440px'],
            content: '/Customer/Edit/' + item.Id
        });
    },
    deleteCustomerFn: function (item) {
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
        url: "/Customer/List",
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

function addCustomerFn() {
    layer.open({
        type: 2,
        maxmin: true,
        title: "新增客户",
        skin: 'layui-layer-rim', //加上边框
        area: ['500px', '440px'],
        content: '/Customer/Add'
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
            url: "/Customer/Delete",
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