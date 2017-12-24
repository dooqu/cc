/* jquery.easydrag */
(function (a) { var d = false, b = null, h = {}, g = {}, e = {}, k, l, j, i, c = {}, f = false; a.getMousePosition = function (a) { var b = 0, c = 0; if (!a) var a = window.event; if (a.pageX || a.pageY) { b = a.pageX; c = a.pageY } else if (a.clientX || a.clientY) { b = a.clientX + document.body.scrollLeft + document.documentElement.scrollLeft; c = a.clientY + document.body.scrollTop + document.documentElement.scrollTop } return { x: b, y: c } }; a.updatePosition = function (f) { var c = a.getMousePosition(f), d = c.x - k, e = c.y - l; a(b).css("top", j + e); a(b).css("left", i + d) }; a(document).mousemove(function (e) { if (d && c[b.id] != "false") { a.updatePosition(e); g[b.id] != undefined && g[b.id](e, b); return false } }); a(document).mouseup(function (a) { if (d && c[b.id] != "false") { d = false; h[b.id] != undefined && h[b.id](a, b); return false } }); a.fn.ondrag = function (a) { return this.each(function () { g[this.id] = a }) }; a.fn.ondrop = function (a) { return this.each(function () { h[this.id] = a }) }; a.fn.dragOff = function () { return this.each(function () { c[this.id] = "off" }) }; a.fn.dragOn = function () { return this.each(function () { c[this.id] = "on" }) }; a.fn.setHandler = function (b) { return this.each(function () { var d = this; e[this.id] = true; a(d).css("cursor", ""); c[d.id] = "handler"; a("#" + b).css("cursor", "move"); a("#" + b).mousedown(function (b) { f = true; a(d).trigger("mousedown", b) }); a("#" + b).mouseup(function () { f = false }) }) }; a.fn.easydrag = function (g) { return this.each(function () { if (undefined == this.id || !this.id.length) this.id = "easydrag" + (new Date).getTime(); e[this.id] = g ? true : false; c[this.id] = "on"; a(this).css("cursor", "move"); a(this).mousedown(function (h) { if (c[this.id] == "off" || c[this.id] == "handler" && !f) return e[this.id]; a(this).css("position", "absolute"); a(this).css("z-index", parseInt(205)); d = true; b = this; var g = a.getMousePosition(h); k = g.x; l = g.y; j = this.offsetTop; i = this.offsetLeft; a.updatePosition(h); return e[this.id] }) }) } })(jQuery)
/*
* 功能：以弹出的方式打开新页面
* 日期：2013-4-3
*/
; (function ($) {
    $.fn.showDialog = function (url, width, height, title, showDialogByParent)
    {
        var showWidth = document.body.clientWidth - 20;
        var showHeight = document.body.clientHeight;
        if (showHeight < document.documentElement.clientHeight)
        {
            showHeight = document.documentElement.clientHeight + 20;
        }
        //一个页面同时弹出多个dialog
        var showMoreDialog = showDialogByParent == true &&  parseInt($($('body', parent.document)).find(".div_bg_dialog").length) > 0 ? true : false;        
        if (showMoreDialog == true)
        {
            showHeight = parent.document.body.clientHeight;
            if (showHeight < parent.document.documentElement.clientHeight)
            {
                showHeight = parent.document.documentElement.clientHeight + 20;
                showWidth = parent.document.body.clientWidth - 20;
            }
        }       

        //取得随机数
        var d = new Date();
        var dStr = d.getYear() + "_" + d.getMonth() + "_" + d.getDate() + "_" + d.getHours() + "_" + d.getMinutes() + "_" + d.getSeconds() + "_" + d.getMilliseconds() + "_" + Math.random();
        dStr = dStr.replace(/\./g, "").replace(/\_/g, "");

        var div_bg_dialog_Id = "BG_" + dStr;
        var div_dialog_Id = "DIALOG_" + dStr;
        var div_dialog_t_Id = "TITLE_" + dStr;
        var div_dialog_close_Id = "CLOSE_" + dStr;         
        var parNew = "";        
        var bgZindex = 5;
        var dialogZindex = 6;
        if (showMoreDialog)
        {
            bgZindex = parseInt($($($('body', parent.document)).find(".div_bg_dialog")).css("z-index")) + 4;
            dialogZindex = parseInt($($($('body', parent.document)).find(".div_bg_dialog")).css("z-index")) + 6;
        }
        var frmId = "frm_dialog_" + div_dialog_Id;
        var info = "<div id='" + div_bg_dialog_Id + "' class='div_bg_dialog' style='background:#000;position:absolute;opacity:0.4;filter:alpha(opacity=40);z-index:" + bgZindex + ";width:" + showWidth + "px;height:" + (parseInt(showHeight) - 20) + "px;left:0px;top:0px;'></div>";
        info += "<div class=\"div_dialog\" id=\"" + div_dialog_Id + "\" style='width:" + width + "px;height:" + height + "px;left:0px;top:0px;z-index:" + dialogZindex + ";'>";        
        info += "     <div class=\"div_dialog_title\" id=\"" + div_dialog_t_Id + "\">";
        info += "         <div class=\"div_dialog_t_cotent\" id=\"div_t_" + div_dialog_Id + "\">"
        info += "           <div class='div_dialog_t_text'>" + title + "</div>";
        info += "         <div class=\"div_dialog_close\" title=\"关闭\" id='" + div_dialog_close_Id + "'></div>";
        info += "      </div>";        
        info += "      <div class=\"div_dialog_t_close\"></div><div class='div_clear'></div>";
        info += "    </div>";
        info += "    <div class=\"div_dialog_content\" style='height:" + (height - 33) + "px;'><iframe frameborder=\"0\" framespacing=\"0\" id=\"" + frmId + "\" width=\"100%\" height=\"100%\"></iframe></div>";
        info += "    <div class='div_dialog_b_l' id='div_dialog_b_l_" + div_dialog_Id + "' style='width:" + (parseInt(width) - 17) + "px'></div><div class='div_dialog_b_r'></div>";
        info += "    <div class='div_clear'></div>";
        info += "</div>";        
        if (showMoreDialog)
        {
            $('body', parent.document).append(info);
        }
        else 
        {
            $("body").append(info);
        }
        $("#div_t_" + div_dialog_Id).width(parseInt($("#" + div_dialog_Id).width()) - 7);       
        if (showMoreDialog)
        {
            $($($('body', parent.document)).find(".div_dialog_close")).hover(function () { $(this).attr("class", "div_dialog_close_hover"); }, function () { $(this).attr("class", "div_dialog_close"); });
            $('body', parent.document).find("#" + div_dialog_Id).easydrag();
            $('body', parent.document).find("#" + div_dialog_Id).setHandler(div_dialog_t_Id);
            var mTop = 50 + $(window).scrollTop();
            $($($('body', parent.document)).find("#" + div_dialog_Id)).css({ left: (parent.document.body.clientWidth - width) / 2, top: mTop });
            $($($('body', parent.document)).find("#" + div_dialog_Id)).show(200, function ()
            {
                $($($('body', parent.document)).find("#" + frmId)).attr("src", url + "" + (url.indexOf("?") == -1 ? "?" : "&") + "dialog_Id=" + div_dialog_Id);
            });
            //关闭弹出页面
            $($($('body', parent.document)).find("#" + div_dialog_close_Id)).click(function ()
            {
                $($($('body', parent.document)).find("#" + div_dialog_Id)).hide(500, function ()
                {
                    //移除iframe
                    $($($('body', parent.document)).find("#frm_dialog_" + div_dialog_Id)).remove();
                    //移除弹出框
                    $($($('body', parent.document)).find("#" + div_dialog_Id)).remove();
                });
                $($($('body', parent.document)).find("#" + div_bg_dialog_Id)).hide(100, function ()
                {
                    $($($('body', parent.document)).find("#" + div_bg_dialog_Id)).remove();
                });
            });
        }
        else
        {
            $(".div_dialog_close").hover(function () { $(this).attr("class", "div_dialog_close_hover"); }, function () { $(this).attr("class", "div_dialog_close"); });
            $("#" + div_dialog_Id).easydrag();
            $("#" + div_dialog_Id).setHandler(div_dialog_t_Id);
            var mTop = 50 + $(window).scrollTop();
            $("#" + div_dialog_Id).css({ left: (document.body.clientWidth - width) / 2, top: mTop });
            $("#" + div_dialog_Id).show(200, function ()
            {
                $("#" + frmId).attr("src", url + "" + (url.indexOf("?") == -1 ? "?" : "&") + "dialog_Id=" + div_dialog_Id);
            });
            //关闭弹出页面
            $("#" + div_dialog_close_Id).click(function () {
                $("#" + div_dialog_Id).hide(500, function ()
                {
                    //移除iframe
                    $($("body").find("#frm_dialog_" + div_dialog_Id)).remove();
                    //移除弹出框
                    $($("body").find("#" + div_dialog_Id)).remove();
                });
                $("#" + div_bg_dialog_Id).hide(100, function () {
                    $($("body").find("#" + div_bg_dialog_Id)).remove();
                });
            });
        }
    }
}(jQuery));
/*
* 功能：以弹出的方式打开新页面
* 日期：2013-4-3
*/
; (function ($)
{
    $.fn.closeDialog = function (div_dialog_Id)
    {
        parent.CloseDialogByPage(div_dialog_Id);
    }
}(jQuery));
/*
* 功能：向每个页面追加关闭弹出框函数
* 日期：2013-4-3
*/
function CloseDialogByPage(div_dialog_Id)
{    
    var div_bg_dialog_Id = "BG_" + div_dialog_Id.split("_")[1];
    $("#" + div_dialog_Id).hide(500, function ()
    {
        //移除iframe
        $("#frm_dialog_" + div_dialog_Id).remove();
        //移除弹出框
        $("#" + div_dialog_Id).remove();
    });
    $("#" + div_bg_dialog_Id).hide(100, function ()
    {
        $("#" + div_bg_dialog_Id).remove();
    });
}

/*
* 功能：弹出对话框, 内容为文本
*/
;(function ($) {
    $.fn.showTextDialog = function (content, width, height, title) {
        var showWidth = document.body.clientWidth - 20;
        var showHeight = document.body.clientHeight;
        if (showHeight < document.documentElement.clientHeight) {
            showHeight = document.documentElement.clientHeight + 20;
        }


        //取得随机数
        var d = new Date();
        var dStr = d.getYear() + "_" + d.getMonth() + "_" + d.getDate() + "_" + d.getHours() + "_" + d.getMinutes() + "_" + d.getSeconds() + "_" + d.getMilliseconds() + "_" + Math.random();
        dStr = dStr.replace(/\./g, "").replace(/\_/g, "");

        var div_bg_dialog_Id = "BG_" + dStr;
        var div_dialog_Id = "DIALOG_" + dStr;
        var div_dialog_t_Id = "TITLE_" + dStr;
        var div_dialog_close_Id = "CLOSE_" + dStr;
        var parNew = "";
        var bgZindex = 5;
        var dialogZindex = 6;

        var frmId = "frm_dialog_" + div_dialog_Id;
        var info = "<div id='" + div_bg_dialog_Id + "' class='div_bg_dialog' style='background:#000;position:absolute;opacity:0.4;filter:alpha(opacity=40);z-index:" + bgZindex + ";width:" + showWidth + "px;height:" + (parseInt(showHeight) - 20) + "px;left:0px;top:0px;'></div>";
        info += "<div class=\"div_dialog\" id=\"" + div_dialog_Id + "\" style='width:" + width + "px;height:" + height + "px;left:0px;top:0px;z-index:" + dialogZindex + ";'>";
        info += "     <div class=\"div_dialog_title\" id=\"" + div_dialog_t_Id + "\">";
        info += "         <div class=\"div_dialog_t_cotent\" id=\"div_t_" + div_dialog_Id + "\">"
        info += "           <div class='div_dialog_t_text'>" + title + "</div>";
        info += "         <div class=\"div_dialog_close\" title=\"关闭\" id='" + div_dialog_close_Id + "'></div>";
        info += "      </div>";
        info += "      <div class=\"div_dialog_t_close\"></div><div class='div_clear'></div>";
        info += "    </div>";
        info += "    <div class=\"div_dialog_content\" style='height:" + (height - 33) + "px; overflow:scroll;'>";
        info += "<style>div_dialog_content a,div,p,span,h1,h2,h3,h4,h5{margin:0;}</style>";
        info += content;//"    <iframe frameborder=\"0\" framespacing=\"0\" id=\"" + frmId + "\" width=\"100%\" height=\"100%\"></iframe>";
        info += "    </div>";
        info += "    <div class='div_dialog_b_l' id='div_dialog_b_l_" + div_dialog_Id + "' style='width:" + (parseInt(width) - 17) + "px'></div><div class='div_dialog_b_r'></div>";
        info += "    <div class='div_clear'></div>";
        info += "</div>";

        $("body").append(info);

        $("#div_t_" + div_dialog_Id).width(parseInt($("#" + div_dialog_Id).width()) - 7);

        $(".div_dialog_close").hover(function () { $(this).attr("class", "div_dialog_close_hover"); }, function () { $(this).attr("class", "div_dialog_close"); });
        $("#" + div_dialog_Id).easydrag();
        $("#" + div_dialog_Id).setHandler(div_dialog_t_Id);
        var mTop = 50 + $(window).scrollTop();
        $("#" + div_dialog_Id).css({ left: (document.body.clientWidth - width) / 2, top: mTop });
        $("#" + div_dialog_Id).show(200, function () {
            //$("#" + frmId).attr("src", url + "" + (url.indexOf("?") == -1 ? "?" : "&") + "dialog_Id=" + div_dialog_Id);
        });
        //关闭弹出页面
        $("#" + div_dialog_close_Id).click(function () {
            $("#" + div_dialog_Id).hide(500, function () {
                //移除iframe
                $($("body").find("#frm_dialog_" + div_dialog_Id)).remove();
                //移除弹出框
                $($("body").find("#" + div_dialog_Id)).remove();
            });
            $("#" + div_bg_dialog_Id).hide(100, function () {
                $($("body").find("#" + div_bg_dialog_Id)).remove();
            });
        });

    }
}(jQuery));
; (function ($) {
    $.fn.closeTextDialog = function (div_dialog_Id) {
        CloseDialogByPage(div_dialog_Id);
    }
}(jQuery));