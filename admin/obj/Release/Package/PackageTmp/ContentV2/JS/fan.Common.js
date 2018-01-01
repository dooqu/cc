$(document).ready(function () {

    //当前屏幕分变率
    var screenWidth = window.screen.width;
    if (screenWidth <= 1024) {
        $(".body_oms_new").css("background-position", "left top");
        $(".body_oms_new").css("background-position", "-400px top");
    }

    $(".body_oms_index").height(document.body.clientHeight);
    $(".span_select").hover(function () { $(this).attr("class", "span_select_hover"); }, function () { $(this).attr("class", "span_select"); });
    $(".span_select2").hover(function () { $(this).attr("class", "span_select2_hover"); }, function () { $(this).attr("class", "span_select2"); });
    $(".span_select").html("<<选择");
    $(".btn_submit_search").val("查 询");
    $(".span_clear").hover(function () { $(this).attr("class", "span_clear_hover"); }, function () { $(this).attr("class", "span_clear"); });
    if ($(".tr_page_title").length == 1) {
        $(".tabel_list_top").css("margin-top", "20px;");
    }
    $(".td_page_01").css("width", $(".table_page").width() - 50);
    $(".table_info").css("width", $(".div_info_title").width());
    CommonHoverEvent();
    //全选
    $("[name=chk_ALL]").click(function () {
        $($(this).parent().parent().parent()).find("[name=chk_Data]").attr("checked", this.checked);
    });
    //最新tab通用样式
    $(".div_tab_left,.div_tab_left_a").click(function () {
        if ($(this).attr("class") == "div_tab_left_a") {
            return;
        }
        $($(this).parent().find(".div_tab_left_a")).attr("class", "div_tab_left");
        $($(this).parent().find(".div_tab_right_a")).attr("class", "div_tab_right");
        $(this).attr("class", "div_tab_left_a");
        $(this).next().attr("class", "div_tab_right_a");
    });

    //动态控制内容页的高度    
    if ($(".div_page_content").height() < $('.div_main_right', parent.document).height() - 84) {
        $(".div_page_content").height($('.div_main_right', parent.document).height() - 84);
    }
    //动态控制table_info 的样式 （去掉最后一列的右边线）
    $(".table_info tr").each(function (i, tr) {
        $(tr).find("td").each(function (j, td) {
            if (j == parseInt($(tr).find("td").length) - 1) {
                $(td).css("border-right", "0px");
            }
        });
    });
    $(".tr_list_common td").each(function (i, td) {
        if ($(td).css("text-align") != "center") {
            $(td).css("padding-left", "5px");
        }
    });
    $(".table_info").css("width", $(".div_info_title").width());
    $(".div_joblist_01").hover(function () { $(this).attr("class", "div_joblist_01_a"); }, function () { $(this).attr("class", "div_joblist_01"); });
    //动态控制通用表格的样式
    $(".table_right_list tr").each(function (i, tr) {
        if ($(tr).attr("class") != "tr_list_title_01") {
            $(tr).attr("class", "tr_list_title_02");
        }
        $(tr).find("td").each(function (j, td) {
            if (j == $(tr).find("td").length - 1) {
                $(td).css("border-right", "0px");
            }
        });
    });
    $(".table_right_list tr").click(function () {
        if ($(this).attr("class") == "tr_list_title_01") {
            return;
        }
        $(".tr_list_title_03").attr("class", "tr_list_title_02");
        $(this).attr("class", "tr_list_title_03");
    });
    //动态控制自定义查询项显示与隐藏
    $("[name=custom_search]").click(function () {
        if ($(this).next().is(":hidden")) {
            $(this).next().show();
            $(this).html("收起自定义查询");
            $(this).attr("class", "div_custom_search_01_2");
        }
        else {
            $(this).next().hide();
            $(this).html("展开自定义查询");
            $(this).attr("class", "div_custom_search_01");
        }
    });
    //动态为拉选项添加title
    $("select>option").each(function (i, o) {
        //$(o).hover(function () {
        $(o).attr("title", $(o).html());
        //});
    });

    //按钮样式控制
    $(".btnTool").click(function () {
        $(this).addClass("btnToolSelect").siblings()
        $(".btnTool").not($(this)).removeClass("btnToolSelect");
    });
});
; (function ($) {
    $.fn.toObject = function () {
        var list = $(this).serializeArray();
        var obj = {};
        $.each(list, function (index, item) {
            obj[item.name] = item.value;
        });
        return obj;
    }
}(jQuery));
/*
* 功能：取得某一个月的最大天数
* 日期：2013-4-3
*/
; (function ($) {
    $.fn.setLastDate = function () {
        $(this).change(function () {
            var v = $(this).val();
            if (v != "") {
                var r = /^(\d{4})-(\d{2})-(\d{2})$/;
                if (!r.test(v)) {
                    $(this).val("");
                }
                var lastDay = GetLastDay(v.split("-")[0], v.split("-")[1]);
                $(this).val(v.split("-")[0] + "-" + v.split("-")[1] + "-" + lastDay);
            }
        });
    }
}(jQuery));
/*
* 功能：浮点型输入限制
* 日期：2013-4-3
*/
; (function ($) {
    $.fn.decimalFormat = function () {
        $(this).keyup(function () {
            var reg = /^[-0-9.]{1,20}$/;
            if (!reg.test($(this).val())) {
                $(this).val("0.00");
            }
        });
    }
}(jQuery));
/*
* 功能：整型输入限制
* 日期：2013-4-3
*/
; (function ($) {
    $.fn.intFormat = function () {
        $(this).keyup(function () {
            var reg = /^[0-9]{1,20}$/;
            if (!reg.test($(this).val())) {
                $(this).val("0");
            }
        });
    }
}(jQuery));
/*
* 功能：输入提示 [time] 几秒之后隐藏提示信息 默认3秒
* 日期：2013-4-3
*/
; (function ($) {
    $.fn.inputTip = function (msg, time) {
        var controlId = $(this).attr("id")
        if (time == undefined || time == "" || time == 0 || parseInt(time) == 0) {
            time = 3;
        }
        var tips_Id = 'div_tips_' + controlId;
        $($("body").find("#" + tips_Id)).remove();
        var showLeft = true;
        if ($("#" + controlId).offset().left + 200 > document.body.clientWidth) {
            showLeft = false;
        }
        var content = "<div class=\"" + (showLeft ? "div_input_tip_01" : "div_input_tip_02") + "\" id='" + tips_Id + "'>" + msg + "</div>";
        $("body").append(content);
        if (showLeft) {
            $("#" + tips_Id).css({ left: $("#" + controlId).offset().left, top: $("#" + controlId).offset().top + $("#" + controlId).height() + 5 });
        }
        else {
            $("#" + tips_Id).css({ left: $("#" + controlId).offset().left - 190 + $("#" + controlId).width() / 2, top: $("#" + controlId).offset().top + $("#" + controlId).height() + 5 });
        }
        var oldColor = $(this).css("border-top-color");
        if ($(this).attr("type") != "button" && $(this).attr("type") != "radio" && $(this).attr("type") != "checkbox") {
            $(this).css("border", "1px solid #EB5439");
        }
        $(this).focus();
        //设置到达某时间点关闭提示信息
        setTimeout(function () {
            $($("body").find("#" + tips_Id)).remove();
            if ($("#" + controlId).attr("type") != "button" && $("#" + controlId).attr("type") != "radio" && $("#" + controlId).attr("type") != "checkbox") {
                $("#" + controlId).css("border", "1px solid " + oldColor);
            }
        }, time * 1000);
        //点击关闭提示信息
        $("#" + tips_Id).click(function () {
            $($("body").find("#" + tips_Id)).remove();
            if ($("#" + controlId).attr("type") != "button" && $("#" + controlId).attr("type") != "radio" && $("#" + controlId).attr("type") != "checkbox") {
                $("#" + controlId).css("border", "1px solid " + oldColor);
            }
        });
    }
}(jQuery));
/*
* 功能：输入提示 [time] 几秒之后隐藏提示信息 默认3秒（供委托使用）
* 日期：2013-4-3
*/
; (function ($) {
    $.fn.inputTipByConsign = function (msg, time) {
        var controlId = $(this).attr("id")
        if (time == undefined || time == "" || time == 0 || parseInt(time) == 0) {
            time = 3;
        }
        var tips_Id = 'div_tips_' + controlId;
        $($("body").find("#" + tips_Id)).remove();
        var showLeft = true;
        if ($("#" + controlId).offset().left + 200 > document.body.clientWidth) {
            showLeft = false;
        }
        var content = "<div class=\"" + (showLeft ? "div_input_tip_01" : "div_input_tip_02") + "\" id='" + tips_Id + "'>" + msg + "</div>";
        $("body").append(content);
        if (showLeft) {
            $("#" + tips_Id).css({ left: $("#" + controlId).offset().left, top: $("#" + controlId).offset().top + $("#" + controlId).height() + 5 });
        }
        else {
            $("#" + tips_Id).css({ left: $("#" + controlId).offset().left - 190 + $("#" + controlId).width() / 2, top: $("#" + controlId).offset().top + $("#" + controlId).height() + 5 });
        }
        var oldColor = $(this).css("border-top-color");
        if ($(this).attr("type") != "button" && $(this).attr("type") != "radio" && $(this).attr("type") != "checkbox") {
            $(this).css("border", "1px solid #EB5439");
        }
        //设置到达某时间点关闭提示信息
        setTimeout(function () {
            $($("body").find("#" + tips_Id)).remove();
            if ($("#" + controlId).attr("type") != "button" && $("#" + controlId).attr("type") != "radio" && $("#" + controlId).attr("type") != "checkbox") {
                $("#" + controlId).css("border", "1px solid " + oldColor);
            }
        }, time * 1000);
        //点击关闭提示信息
        $("#" + tips_Id).click(function () {
            $($("body").find("#" + tips_Id)).remove();
            if ($("#" + controlId).attr("type") != "button" && $("#" + controlId).attr("type") != "radio" && $("#" + controlId).attr("type") != "checkbox") {
                $("#" + controlId).css("border", "1px solid " + oldColor);
            }
        });
    }
}(jQuery));
/*
* 功能：取得某一个月的最大天数
* 日期：2013-4-3
*/
function GetLastDay(year, month) {
    var new_year = year;    //取当前的年份         
    var new_month = month++;//取下一个月的第一天，方便计算（最后一天不固定）         
    if (month > 12)            //如果当前大于12月，则年份转到下一年         
    {
        new_month -= 12;        //月份减         
        new_year++;            //年份增         
    }
    var new_date = new Date(new_year, new_month, 1);                //取当年当月中的第一天         
    return (new Date(new_date.getTime() - 1000 * 60 * 60 * 24)).getDate();//获取当月最后一天日期         
}
/*
* 功能：结果与操作提示 [type] 1 info,2 wraning,3 error,4 success,5 confirm
* 日期：2013-5-6
*/
; (function ($) {
    $.fn.showTip = function (type, title, msg, fun, top) {
        var closeBG = true;
        if ($("#documentBG").html() == null) { ShowDocumentBG(); }
        var info = "";
        info += " <div class=\"div_showTip\">";
        info += "      <div class=\"div_showTip_01\">";
        info += "          <div class=\"div_showTip_title\">" + title + "</div>";
        info += "          <div class=\"div_showTip_close\" title=\"关闭\" id='div_close_tip'></div>";
        info += "      </div>";
        if (type == "1" || type == "info") {
            info += "      <div class=\"div_showTip_info\">" + msg + "</div>";
        }
        else if (type == "2" || type == "wraning") {
            info += "      <div class=\"div_showTip_wraning\">" + msg + "</div>";
        }
        else if (type == "3" || type == "error") {
            info += "      <div class=\"div_showTip_error\">" + msg + "</div>";
        }
        else if (type == "4" || type == "success") {
            info += "      <div class=\"div_showTip_success\">" + msg + "</div>";
        }
        else if (type == "5" || type == "confirm") {
            info += "      <div class=\"div_showTip_confirm\">" + msg + "</div>";
        }
        info += "      <div class=\"div_showTip_bottom\">";
        info += "          <input type=\"button\" class=\"btn_ok\" title=\"确定\" id='btn_Tip_OK' />";
        if (type == "5" || type == "confirm") {
            info += "          <input type=\"button\" class=\"bnt_cancel\" title=\"取消\" id='btn_close_tip' />";
        }
        info += "      </div>";
        info += "  </div>";
        $("body").append(info);
        $(".div_showTip_close").hover(function () { $(this).attr("class", "div_showTip_close_hover"); }, function () { $(this).attr("class", "div_showTip_close"); });
        if (top == null || top == "" || top == 0 || top == undefined || top == true) {
            top = 170 + $(window).scrollTop();
        }
        $(".div_showTip").animate({ left: (document.body.clientWidth - $(".div_showTip").width()) / 2, top: top }, { duration: 0, queue: false });
        $("#btn_Tip_OK").click(function () {
            $($("body").find(".div_showTip")).remove();
            if (closeBG) {
                CloseDocumentBG();
            }
            if (fun != undefined && fun != null && fun != "") {
                fun();
            }
        });
        $("#div_close_tip,#btn_close_tip").click(function () {
            $($("body").find(".div_showTip")).remove();
            if (closeBG) {
                CloseDocumentBG();
            }
        });
    }
}(jQuery));
/*
* 功能:遮住系统界面
* 日期:2012-7-31
*/
function ShowDocumentBG() {
    if ($("#documentBG").html() != "") {
        var showHeight = document.body.clientHeight;
        if (showHeight < document.documentElement.clientHeight) {
            showHeight = document.documentElement.clientHeight + 20;
        }
        var info = "<div id='documentBG' style='background:#000;position:absolute;opacity:0.3;filter:alpha(opacity=30);z-index:280;width:" + (parseInt(document.body.clientWidth)) + "px;height:" + (parseInt(showHeight) - 20) + "px;left:0px;top:0px;'></div>";
        $("body").append(info);
    }
    else {
        $("#documentBG").show();
    }
}
/*
* 功能：显示汇总数据
* 日期：2013-4-3
*/
; (function ($) {
    $.fn.showNum = function (num) {
        var id = $(this).attr("id");
        id = "div_num_" + id;
        $("#" + id).remove();
        var info = '<div class="div_num_tip" id="' + id + '">';
        info += ' <div class="div_num_tip_02">' + num + '</div>';
        info += ' <div class="div_num_tip_03"></div>';
        info += '</div>';
        $("body").append(info);
        $("#" + id).css({ left: $(this).offset().left + $(this).width() + 5, top: $(this).offset().top - 10 });
        $("#" + id).show();
    }
}(jQuery));

/*
* 功能：显示文本信息
* 日期：2013-4-3
*/
; (function ($) {
    $.fn.showText = function () {
        $("#div_show_text").remove();
        $(this).hover(function () {
            var info = '<div class="div_show_all_info" id="div_show_text">&nbsp;' + $(this).attr("text") + '&nbsp;</div>';
            $("body").append(info);
            $("#div_show_text").css({ left: ($(this).offset().left + ($(this).width() / 2) - ($("#div_show_text").width() / 2)), top: $(this).offset().top - $("#div_show_text").height() - 5 });
            $("#div_show_text").show();

        }, function () {
            $("#div_show_text").remove();
        });
    }
}(jQuery));

/*
* 功能:清除遮住系统界面DIV
* 日期:2013-5-6
*/
function CloseDocumentBG() {
    $($("body").find("#documentBG")).remove();
}
/*
* 功能:设置数据列表中“无效”关键字颜色
* 日期:2013-5-6
*/
function ListDataStaus(obj) {
    if (obj == "无效") {
        return "<span style='color:red'>无效</span>";
    }
    return obj;
}

/*
* 功能:清除元素上面的值
* 日期:2013-5-6
*/
function ClearValue(el) {
    var mirror = $(el).clone();
    mirror.val("");
    $(el).after(mirror);
    $(el).remove();
}

/*
* 功能:取得文件上传元素的Name
* 日期:2013-5-6
*/
function Attachment_GetFileInputName(target) {
    var name = $(target).attr("name");
    if (name && name.length > 2 && name.substr(0, 2) == "__") {
        name = name.substring(2);
    }
    return name;
}

/*
* 功能:多文件上传添加行
* 日期:2013-5-6
*/
function Attachment_AddRow(el) {
    var tr = $(el).parent().parent();
    var href = tr.find(":file").val();
    if (!href) {
        alert("请选择文件!");
        return;
    }
    var fileName = href.substring(href.lastIndexOf("\\") + 1);
    var row = tr.clone();
    row.find(":file").val("");

    var file = tr.find(":file");
    var name = Attachment_GetFileInputName(file);
    file.attr("name", name);
    tr.find(".attachment_btn_del").show().end()
       .find(".attachment_btn_add").hide().end()
       .find(":file").hide().end()
       .find(".attachment_file_link").html(fileName).show().attr("href", href);

    $(row).insertBefore(tr);
    $(tr).parent().parent().append(tr);
}

/*
* 功能:多文件上传移除文件项
* 日期:2013-5-6
*/
function Attachment_Remove(el) {
    var tr = $(el).parent().parent().remove();
}

/*
* 功能:检测文件上传
* 日期:2013-5-6
*/
function Attachment_CheckFile(target) {     
    var fileName = target.value;
    var allowExt = $("[name='" + Attachment_GetFileInputName(target) + ".FileExt']").val();
    var ext, idx;
    if (fileName != '') {
        idx = fileName.lastIndexOf(".");
        if (idx != -1) {
            ext = fileName.substr(idx + 1).toLowerCase();
            var extlist = allowExt.split('|');
            var isValid = false;

            //2017-4-14  wfb 解决IE8下 自定义indexOf方法 导致遍历数组 多出indexOf 索引
            for (i = 0; i < extlist.length; i++) {
                if (extlist[i].toLowerCase() == ext) {
                    isValid = true;
                    break;
                }
            }
            //for (var i in extlist) {
            //    if (extlist[i].toLowerCase() == ext) {
            //        isValid = true;
            //        break;
            //    }
            //}
            if (!isValid) {
                alert("请上传以下文件类型:" + allowExt);
                ClearValue(target);
            }
        } else {
            alert("请上传以下文件类型:" + allowExt);
            ClearValue(target);
        }
    }
}

/* 功能：对Date的扩展，将 Date 转化为指定格式的String 
*  日期:2013-5-28
*  参数说明：
*  月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
*  年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
*  例子： 
*  (new Date()).format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423 
*  (new Date()).format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18 
*/
Date.prototype.format = function (fmt) {
    var o = {
        "M+": this.getMonth() + 1,                 //月份 
        "d+": this.getDate(),                    //日 
        "h+": this.getHours(),                   //小时 
        "m+": this.getMinutes(),                 //分 
        "s+": this.getSeconds(),                 //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds()             //毫秒 
    };
    if (/(y+)/.test(fmt))
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}

/*
* 功能:对字符串的日期时行格式化
* 日期:2013-5-28
*/
function dateFormatter(data) {

    if (/\/Date\(-?\d+\)\//.test(data)) {
        var date = eval("new " + data.replace('/', '').replace('/', ''));
        return date ? date.format("yyyy-MM-dd") : "";
    }
    else {
        return '';
    }
}
/*
* 功能:对字符串的日期时间进行格式化
* 日期:2014-11-25
*/
function datetimeFormatter(data) {
    if (/\/Date\(-?\d+\)\//.test(data)) {
        var date = eval("new " + (data + '').replace('/', '').replace('/', ''));
        return date ? date.format("yyyy-MM-dd hh:mm:ss") : "";
    }
    else {
        return '';
    }
}
function datetimeFormatter1(data) {
    if (/\/Date\(-?\d+\)\//.test(data)) {
        var date = eval("new " + (data + '').replace('/', '').replace('/', ''));
        return date ? date.format("yyyy-MM-dd HH:mm:ss") : "";
    }
    else {
        return '';
    }
}

/*
* 功能:对字符串的日期时间进行格式化到月份
* 日期:2014-11-25
*/
function datetimeFormatterDay(data) {
    if (/\/Date\(-?\d+\)\//.test(data)) {
        var date = eval("new " + (data + '').replace('/', '').replace('/', ''));
        return date ? date.format("yyyy-MM-dd") : "";
    }
    else {
        return '';
    }
}


String.prototype.format = function (args) {
    var result = this;
    if (arguments.length > 0) {
        if (arguments.length == 1 && typeof (args) == "object") {
            for (var key in args) {
                if (args[key] != undefined) {
                    var reg = new RegExp("({" + key + "})", "g");
                    result = result.replace(reg, args[key]);
                }
            }
        }
        else {
            for (var i = 0; i < arguments.length; i++) {
                if (arguments[i] != undefined) {
                    var reg = new RegExp("({[" + i + "]})", "g");
                    result = result.replace(reg, arguments[i]);
                }
            }
        }
    }
    return result;
}
/*
* 功能：元素移动事件
* 日期：2013-4-3
*/
; (function ($) {
    $.fn.hoverEvent = function () {
        var cls = $(this).attr("class");
        $(this).hover(function () { $(this).attr("class", cls + "_hover"); }, function () { $(this).attr("class", cls); });
    }
}(jQuery));
function CommonHoverEvent() {
    //右边列表添加按钮
    $(".div_list_add").hoverEvent();
    $(".div_list_edit").hoverEvent();
    $(".div_list_edit2").hoverEvent();
    $(".div_list_del").hoverEvent();
    $(".div_list_show").hoverEvent();
    $(".div_list_set").hoverEvent();
    $(".div_list_set2").hoverEvent();
    $(".div_list_power").hoverEvent();
    $(".div_list_start").hoverEvent();
    $(".div_list_stop").hoverEvent();
    $(".div_list_lock").hoverEvent();
    $(".div_list_search").hoverEvent();
    $(".btn_select").hoverEvent();
    $(".div_list_upload").hoverEvent();
    $(".div_list_download").hoverEvent();
    $(".div_list_bu").hoverEvent();
    $(".div_list_bu2").hoverEvent();
    $(".div_list_refresh").hoverEvent();
    $(".div_common_detail").attr("title", "查看详细");
    $(".div_common_detail").hoverEvent();
    $(".btn_add_01").hoverEvent();
    $(".btn_del").hoverEvent();
    $(".btn_next").hoverEvent();
    $(".btn_new_back").hoverEvent();
    $(".btn_import2").hoverEvent();
    $(".btn_cancel_new").hoverEvent();
    $(".span_link2").hoverEvent();
    $(".btn_import3").hoverEvent();
    $(".btn_export3").hoverEvent();
    $(".btn_list_add").hoverEvent();
    $(".btn_list_del").hoverEvent();
    $(".btn_ok_new").hoverEvent();
    $(".btn_add_02").hoverEvent();
    $(".btn_del_02").hoverEvent();
    $(".btn_export_02").hoverEvent();
    $(".btn_common_back").hoverEvent();
    $(".btn_new_save").hoverEvent();
    $(".div_list_print").hoverEvent();
    $(".div_list_export").hoverEvent();
    $(".div_list_time").hoverEvent();
    $(".div_list_time").hoverEvent();
    $(".div_list_import").hoverEvent();
    $(".div_list_unlock").hoverEvent();
    $(".div_list_copy").hoverEvent();
    $(".div_list_return").hoverEvent();
    $(".div_list_fj").hoverEvent();
    $(".div_float_operator").hoverEvent();
    $(".div_model_exit").hoverEvent();
    $(".div_oms_content_logo").hoverEvent();
    $(".span_detail_link").hoverEvent();

    //系统左侧菜单
    $("[name=menu]").hover(function () {
        if ($(this).attr("class").indexOf("_a") == -1) {
            $(this).attr("class", $(this).attr("class") + "_hover");
        }
    }, function () {
        if ($(this).attr("class").indexOf("_a") == -1) {
            $(this).attr("class", $(this).attr("class").replace("_hover", ""));
        }
    });
    $("[name=menu]").click(function () {
        if ($(this).attr("class").indexOf("_a") == -1) {
            $("[name=menu]").each(function (i, div) {
                $(div).attr("class", $(div).attr("class").replace("_a", ""));
            });
            $(this).attr("class", $(this).attr("class").replace("_hover", "") + "_a");
        }
    });

    //最新tab通用样式（01）
    $(".div_oms_tab_item_left,.div_oms_tab_item_left_a").click(function () {
        if ($(this).attr("class") == "div_oms_tab_item_left_a") {
            return;
        }
        $($(this).parent().find(".div_oms_tab_item_left_a")).attr("class", "div_oms_tab_item_left");
        $($(this).parent().find(".div_oms_tab_item_right_a")).attr("class", "div_oms_tab_item_right");
        $(this).attr("class", "div_oms_tab_item_left_a");
        $(this).next().attr("class", "div_oms_tab_item_right_a");
    });
    $(".div_oms_tab_item_left,.div_oms_tab_item_left_a").hover(function () {
        if ($(this).attr("class") == "div_oms_tab_item_left_a") {
            return;
        }
        $(this).attr("class", "div_oms_tab_item_left_hover");

    }, function () {
        if ($(this).attr("class") == "div_oms_tab_item_left_a") {
            return;
        }
        $(this).attr("class", "div_oms_tab_item_left");
    });

    //最新tab通用样式（01）
    $(".div_oms_tab_item_left,.div_oms_tab_item_left_a").click(function () {
        if ($(this).attr("class") == "div_oms_tab_item_left_a") {
            return;
        }
        $($(this).parent().find(".div_oms_tab_item_left_a")).attr("class", "div_oms_tab_item_left");
        $($(this).parent().find(".div_oms_tab_item_right_a")).attr("class", "div_oms_tab_item_right");
        $(this).attr("class", "div_oms_tab_item_left_a");
        $(this).next().attr("class", "div_oms_tab_item_right_a");
    });
    $(".div_oms_tab_item_left,.div_oms_tab_item_left_a").hover(function () {
        if ($(this).attr("class") == "div_oms_tab_item_left_a") {
            return;
        }
        $(this).attr("class", "div_oms_tab_item_left_hover");

    }, function () {
        if ($(this).attr("class") == "div_oms_tab_item_left_a") {
            return;
        }
        $(this).attr("class", "div_oms_tab_item_left");
    });
    //最新tab通用样式（02）
    $(".div_oms_tab_item_left2,.div_oms_tab_item_left2_a").click(function () {
        if ($(this).attr("class") == "div_oms_tab_item_left2_a") {
            return;
        }
        $($(this).parent().find(".div_oms_tab_item_left2_a")).attr("class", "div_oms_tab_item_left2");
        $($(this).parent().find(".div_oms_tab_item_right2_a")).attr("class", "div_oms_tab_item_right2");
        $(this).attr("class", "div_oms_tab_item_left2_a");
        $(this).next().attr("class", "div_oms_tab_item_right2_a");
    });
    $(".div_oms_tab_item_left2,.div_oms_tab_item_left2_a").hover(function () {
        if ($(this).attr("class") == "div_oms_tab_item_left2_a") {
            return;
        }
        $(this).attr("class", "div_oms_tab_item_left2_hover");

    }, function () {
        if ($(this).attr("class") == "div_oms_tab_item_left2_a") {
            return;
        }
        $(this).attr("class", "div_oms_tab_item_left2");
    });

    //设置列表操作按钮样式
    $(".div_oms_list_operator>input[type='button']").each(function (i, btn) {
        if ($(btn).attr("class") != "btn_data_search") {
            $("." + $(btn).attr("class")).hoverEvent();
        }
        $("." + $(btn).attr("class")).hover(function () {
            var text = $(btn).attr("text");
            text = text == "" || text == null ? "请为该按钮添加text属性" : text;
            if ($(this).attr("class") == "btn_data_search_a") {
                text = "取消搜索";
            }
            var info = '<div class="div_list_operator_tip">' + text + '</div>';
            $("body").append(info);
            $(".div_list_operator_tip").css({ left: $(this).offset().left - ($(".div_list_operator_tip").width() / 2) + 8, top: $(this).offset().top - $(".div_list_operator_tip").height() - 6 });
            $(".div_list_operator_tip").show();
            //查询做特殊处理
            if ($(this).attr("class") == "btn_data_search") {
                $(this).attr("class", "btn_data_search_hover");
            }
        }, function () {
            $(".div_list_operator_tip").remove();
            //查询做特殊处理
            if ($(this).attr("class") == "btn_data_search_hover") {
                $(this).attr("class", "btn_data_search");
            }
        });
    });
    //设置列表查询按钮的样式
    $(".btn_data_search").click(function () {
        if ($(this).attr("class") != "btn_data_search_a") {
            $(this).attr("class", "btn_data_search_a");
        }
        else {
            $(this).attr("class", "btn_data_search");
            $(".div_data_search").hide();
        }
    });

    //设置详细页面操作按钮的样式
    $(".div_detail_bottom>input").each(function (i, btn) {
        $("." + $(btn).attr("class")).hoverEvent();
    });
    //只变换包含btn_detail 的按钮
    $(".div_info_bottom>input[class*='btn_detail']").each(function (i, btn) {
        $("." + $(btn).attr("class")).hoverEvent();
    });
    $(".div_data_search_bottom>input").each(function (i, btn) {
        $("." + $(btn).attr("class")).hoverEvent();
    });

    //设置日期控件 与 文本框的绑定
    $(".txt_date,.txt_date2").each(function (i, txt) {
        $(txt).attr("readonly", false);
        $(txt).attr("text", "日期格式为：yyyy-MM-dd");
        $(txt).attr("maxlength", "10");
        $(txt).attr("maxlength", "10");
        $(txt).removeAttr("onfocus");
        $(txt).showText();
        $(txt).blur(function () {
            var reg = /^(?:(?!0000)[0-9]{4}-(?:(?:0[1-9]|1[0-2])-(?:0[1-9]|1[0-9]|2[0-8])|(?:0[13-9]|1[0-2])-(?:29|30)|(?:0[13578]|1[02])-31)|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)-02-29)$/;
            if (!$(this).val().match(reg)) {
                $(this).val("");
            }
        });
    });

}

/*
* 功能：日期格式化
*/
function parseISO8601(dateStringInRange) {
    var isoExp = /^\s*(\d{4})-(\d\d)-(\d\d)\s*$/,
        date = new Date(NaN), month,
        parts = isoExp.exec(dateStringInRange);
    if (parts) {
        month = +parts[2];
        date.setFullYear(parts[1], month - 1, parts[3]);
        if (month != date.getMonth() + 1) {
            date.setTime(NaN);
        }
    }
    return date;
};
/*
* 功能：添加Cookie
* 日期：2014-1-16
*/
function setCookie(name, value) {
    delCookie(name);
    var Days = 30;
    var exp = new Date();
    exp.setTime(exp.getTime() + Days * 24 * 60 * 60 * 1000);
    document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString() + ";path=/";
}
/*
* 功能：读取Cookie
* 日期：2014-1-16
*/
function getCookie(name) {
    var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
    if (arr = document.cookie.match(reg)) {
        return (arr[2]);
    }
    else {
        return null;
    }
}
/*
* 功能：删除Cookie
* 日期：2014-1-16
*/
function delCookie(name) {
    var exp = new Date();
    exp.setTime(exp.getTime() - 1);
    var cval = getCookie(name);
    if (cval != null) {
        document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString() + ";path=/";
    }
}

/*
* 功能：禁用backspace键的后退功能，但是可以删除文本内容
* 日期：2014-10-13
*/
document.onkeydown = check;
function check(e) {
    var code;
    if (!e) var e = window.event;
    if (e.keyCode) code = e.keyCode;
    else if (e.which) code = e.which;
    if (((event.keyCode == 8) &&                                                    //BackSpace 
         ((event.srcElement.type != "text" &&
         event.srcElement.type != "textarea" &&
         event.srcElement.type != "password") ||
         event.srcElement.readOnly == true)) ||
        ((event.ctrlKey) && ((event.keyCode == 78) || (event.keyCode == 82))) ||    //CtrlN,CtrlR 
        (event.keyCode == 116)) {                                                   //F5 
        event.keyCode = 0;
        event.returnValue = false;
        return false;
    }
    else {
        return true;
    }
}
