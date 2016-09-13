var $vm = avalon.define({
    $id: "SaleOrderList",
    List: []
});

$(function () {
    refreshListFn();
});

function refreshListFn(pageIndex) {
    $.ajax({
        url: "/Sale/List",
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

// 设置已完工
function setOutboundFn() {
    var idList = getSelectedIdListFn();
    if (idList.length == 0) {
        $.msg("请选择需要设置已出库的维修单。", "error");
        return false;
    }

    $.ajax({
        url: "/Sale/Outbound",
        type: "POST",
        data: {
            idList: idList
        },
        success: function () {
            $.msg("设置已出库成功。", "success");
            refreshListFn();
        }
    });
}

// 获取全选数据
function getSelectedIdListFn() {
    var idArray = [];
    var $checkList = $(".table tbody tr td input[type=checkbox]:checked");
    $.each($checkList, function ($index, item) {
        var $checkItem = $(item);
        idArray.push($checkItem.val());
    });

    return idArray;
}