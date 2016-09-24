var $vm = avalon.define({
    $id: "ProductRecordList",
    List: [],
    Search: {
        Type: "",
        Code: "",
        Name: "",
        RecordOn: {
            BeginTime: "",
            EndTime: ""
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
        url: "/Product/RecordList",
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

function selectSearchBeginTimeFn() {
    $vm.Search.RecordOn.BeginTime = $(arguments[0].el).val();
}

function selectSearchEndTimeFn() {
    $vm.Search.RecordOn.EndTime = $(arguments[0].el).val();
}