MEHS.Models.modAjax = function () {
    this.sUrl = '';
    this.headers = new Object();
    this.objModelo = new Object();
    this.objParametro = new Object();
    this.dataType = 'json';
    this.contentType = 'application/json;charset=utf-8';
    this.fnBeforeSend = $.noop;
    this.fnSucces = $.noop;
    this.fnError = $.noop;
    this.AjType = false;
    this.CallerType = '';
    this.crossDomain = false;
}

MEHS.Models.modValidateForm = function () {
    this.idForm = '';
    this.rules = new Object();
    this.highlight = $.noop;
    this.success = $.noop;
    this.submitHandler = $.noop;
}