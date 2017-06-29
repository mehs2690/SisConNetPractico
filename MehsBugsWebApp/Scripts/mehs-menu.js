function GetMenuByUser() {
    var modelo = new MEHS.Models.modAjax();
    modelo.sUrl = MEHS.Urls.APIUserMehs + MEHS.EndPoints.Menu;
    modelo.AjType = true;
    modelo.CallerType = 'PATCH';
    modelo.fnBeforeSend = $.noop;
    modelo.fnSucces = function (data, textStatus, jqXHR) {
        console.log(data);
    };
    modelo.fnError = $.noop;
    modelo.crossDomain = true;
    modelo.dataType = 'jsonp';
    modelo.objModelo = null;

    var ajaxCall = new MEHS.FrontEnd.Common.CallWithAjax();
    ajaxCall.Call(modelo);

}

$(document).ready(function () {
    var trigger = $('.hamburger'),
                overlay = $('.overlay'),
                isClosed = false;

    trigger.click(function () {
        hamburger_cross();
    });

    function hamburger_cross() {

        if (isClosed == true) {
            overlay.hide();
            trigger.removeClass('is-open');
            trigger.addClass('is-closed');
            isClosed = false;
        } else {
            overlay.show();
            trigger.removeClass('is-closed');
            trigger.addClass('is-open');
            isClosed = true;
        }
    }

    $('[data-toggle="offcanvas"]').click(function () {
        $('#wrapper').toggleClass('toggled');
    });

    GetMenuByUser();
});