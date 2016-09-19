var $vm = avalon.define({
    $id: "ProductList",
    List: [],
    Search: {
        Code: "",
        Name: ""
    },
    editProductFn: function (item) {
        layer.open({
            type: 2,
            maxmin: true,
            title: "修改配件信息",
            skin: 'layui-layer-rim',
            area: ['500px', '530px'],
            content: '/Product/Edit/' + item.Id
        });
    }
});

$(function () {
    refreshListFn();
});

function refreshListFn(pageIndex) {
    var postData = $vm.Search.$model;
    postData.PageIndex = pageIndex || 0;
    $.ajax({
        url: "/Product/WarningList",
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