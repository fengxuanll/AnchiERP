var GuidEmpty = "00000000-0000-0000-0000-000000000000";

(function ($) {
    var overrideAjax = function () {
        var rawAjax = $.ajax;
        $.ajax = function (options) {
            var rawSuccess = options.success;
            var dxOptions = {
                success: function (data, status, xhr) {
                    if (!data.Success) {
                        $.alert(data.Message, "error", "错误！");
                    }
                    if (data.Success && rawSuccess) {
                        rawSuccess(data.Message);
                    }
                },
                error: function (data, status, xhr) {
                    alert("ajax error:" + data.status);
                }
            };
            return rawAjax($.extend(options, dxOptions));
        };
    }
    overrideAjax();
})(jQuery);

jQuery.alert = function (text, type, title) {
    var icon = -1;
    switch (type) {
        case "success":
            icon = 1;
            break;
        case "error":
            icon = 2;
            break;
        case "warning":
            icon = 3;
            break;
    }
    layer.alert(text, { icon: icon, title: title || "提示" });
}

jQuery.msg = function (text, type) {
    var icon = -1;
    switch (type) {
        case "success":
            icon = 1;
            break;
        case "error":
            icon = 2;
            break;
        case "warning":
            icon = 3;
            break;
    }
    layer.msg(text, { icon: icon, time: 2000 });
}

// 只允许输入数字
function decimal(e, value) {
    var key;
    var keychar;
    if (window.event) {
        key = window.event.keyCode;
    }
    else if (e) {
        key = e.which;
    }
    else {
        return true;
    }
    keychar = String.fromCharCode(key);
    if (key == "8" || key == "9") {
        return true;
    }
    else if ((("0123456789").indexOf(keychar) > -1)) {
        return true;
    }
    else if (keychar == "." && (value == '' || value.indexOf(".") == -1)) {
        return true;
    } else {
        return false;
    }
}

// avalon 过滤器：显示时间的日期部分，最小时间不显示。
avalon.filters.showTimeDateFilter = function (time) {
    if (!time)
        return "";

    var newTime = avalon.filters.date(time, "yyyy-MM-dd");
    if (newTime <= "1900-01-01")
        return "";

    return newTime;
}

// avalon 过滤器：显示时间的日期时间部分，最小时间不显示。
avalon.filters.showDateTimeFilter = function (time) {
    if (!time)
        return "";

    var newTime = avalon.filters.date(time, "yyyy-MM-dd HH:mm:ss");
    if (newTime <= "1900-01-01")
        return "";

    return newTime;
}