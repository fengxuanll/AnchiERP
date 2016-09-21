var $vm = avalon.define({
    $id: "FinanceOrderList",
    List: [],
    Search: {
        Type: "",
        CreatedOn: {
            BeginTime: "",
            EndTime: ""
        }
    },
    GetRelationHrefFn: function (item) {
        switch (item.Type) {
            case 10:    // 维修收款
                return "/Repair/Edit/" + item.RelationId;
            case 11:    // 销售收款
                return "/Sale/Edit/" + item.RelationId;
            case 20:    // 采购付款
                return "/Purchase/Edit/" + item.RelationId;
            default:
                return "javascript;";
        }
    }
});

$(function () {
    refreshListFn();
});

function refreshListFn(pageIndex) {
    var postData = $vm.Search.$model;
    postData.PageIndex = pageIndex || 0;
    $.ajax({
        url: "/Finance/List",
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

function selectCreatedOnBeginFn() {
    $vm.Search.CreatedOn.BeginTime = $(arguments[0].el).val();
}

function selectCreatedOnEndFn() {
    $vm.Search.CreatedOn.EndTime = $(arguments[0].el).val();
}