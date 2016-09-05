var $vm = avalon.define({
    $id: "SupplierList",
    List: [],
    editSupplierFn: function (item) {
        layer.open({
            type: 2,
            maxmin: true,
            title: "修改配件信息",
            skin: 'layui-layer-rim',
            area: ['500px', '500px'],
            content: '/Supplier/Edit/' + item.Id
        });
    },
    deleteSupplierFn: function (item) {
        deleteSelectedRowFn(item.Id);
    }
});

$(function () {
    refreshListFn();
});

function refreshListFn(pageIndex) {
    $.ajax({
        url: "/Supplier/List",
        type: "POST",
        data: {
            PageIndex: pageIndex || 0
        },
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

function addSupplierFn() {
    layer.open({
        type: 2,
        maxmin: true,
        title: "新增供应商",
        skin: 'layui-layer-rim', //加上边框
        area: ['500px', '500px'], //宽高
        content: '/Supplier/Add'
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
            url: "/Supplier/Delete",
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