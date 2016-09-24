var $vm = avalon.define({
    $id: "PurchaseOrderList",
    List: [],
    Search: {
        PurchaseById: "",
        Status: "",
        Supplier: "",
        SettlementStatus: "",
        TimeType: "",
        BeginTime: "",
        EndTime: ""
    }
});

function selectSearchBeginTimeFn() {
    $vm.Search.BeginTime = $(arguments[0].el).val();
}

function selectSearchEndTimeFn() {
    $vm.Search.EndTime = $(arguments[0].el).val();
}

$(function () {
    refreshListFn();
});

function refreshListFn(pageIndex) {
    var postData = $vm.Search.$model;
    postData.PageIndex = pageIndex || 0;
    postData[postData.TimeType] = {};
    postData[postData.TimeType].BeginTime = $vm.Search.BeginTime;
    postData[postData.TimeType].EndTime = $vm.Search.EndTime;
    $.ajax({
        url: "/Purchase/List",
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

function setArrivalFn() {
    var idList = getSelectedIdListFn();
    if (idList.length == 0) {
        $.msg("请选择需要设置已到货的采购单。", "error");
        return false;
    }

    $.ajax({
        url: "/Purchase/SetArrival",
        type: "POST",
        data: {
            idList: idList
        },
        success: function () {
            $.msg("设置已到货成功。", "success");
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

// 取消采购单
function cancelOrderFn() {
    var idList = getSelectedIdListFn();
    if (idList.length == 0) {
        $.msg("请选择需要取消的采购单。", "error");
        return false;
    }

    layer.confirm("是否确定需要取消选择的<span class='c-red'>" + idList.length + "</span>条采购单？", function () {
        $.ajax({
            url: "/Purchase/Cancel",
            type: "POST",
            data: {
                idList: idList
            },
            success: function () {
                $.msg("取消完成。", "success");
                refreshListFn();
            }
        });
    });
}