"use strict";

var MEHS = MEHS || { FrontEnd: { Common: {} }, Models: {}, Login: {}, Urls: {}, EndPoints: {}, Home: {}, Seguridad: {}, Constantes: {} };

jQuery.extend(jQuery.validator.messages, {
    required: "El campo es requerido",
    remote: "favor de reparar el campo",
    email: "Ingresa una direccón de correo válida",
    url: "ingresa una url válida",
    date: "ingresa un formato de fecha válido",
    dateISO: "ingresa un formato de fecha válido (ISO).",
    number: "ingresa un número válido",
    digits: "ingresa sólo dígitos",
    creditcard: "ingresa un número de tarjeta válido",
    equalTo: "ingresar el mismo valor de nuevo",
    accept: "ingresa archivos con los formatos (extensiones) válidos",
    maxlength: jQuery.validator.format("ingresa no más de {0} caracteres."),
    minlength: jQuery.validator.format("ingresa no menos de {0} caracteres."),
    rangelength: jQuery.validator.format("ingresa un valor entre {0} y {1} caracteres de longitud."),
    range: jQuery.validator.format("ingresa un valor entr {0} y {1}."),
    max: jQuery.validator.format("ingresa una valor menor que o igual a {0}."),
    min: jQuery.validator.format("ingresa un valor mayor o igual a {0}.")
});

$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};

MEHS.Urls = {
    APIUserMehs: 'http://localhost:53075/',
    APIBugMehs: 'http://localhost:53184/',
    FcBaseHome: '../../Views/Home/',
    FcHomePage: '../../Views/Home/Inicio.html'
};

MEHS.EndPoints = {
    Bugs: 'api/v1/bug/bugs',
    Notifications: 'api/v1/bug/notification',
    Users: 'api/v1/usr/user',
    Menu: 'api/v1/usr/menu',
    Application: 'api/v1/usr/app',
    UserCatalog: 'api/v1/usr/usertype'
};

MEHS.FrontEnd.Common.CallWithAjax = function () {
    this.Call = function (modAjax) {
        try {

            var objeto = (modAjax.objModelo === null) ? '' : JSON.stringify(modAjax.objModelo);
            console.debug(modAjax);
            $.support.cors = true;
            $.ajax({
                url: modAjax.sUrl,
                async: modAjax.AjType,
                crossDomain: modAjax.crossDomain,
                datatype: modAjax.dataType,
                contentType: modAjax.contentType,
                data: objeto,
                type: modAjax.CallerType,
                beforeSend: modAjax.fnBeforeSend,
                success: modAjax.fnSucces,
                error: modAjax.fnError
            });

        } catch (e) {
            console.error(e.message);
        }
    };
};

MEHS.FrontEnd.Common.ValidateFormAction = function () {
    /// <summary>
    /// Función que valida los campos de un formulario
    /// </summary>
    /// <param name="modValidateForm" type="type">modelo de tipo FridhaCode.Models.modVlaidateForm</param>
    this.Validate = function (modValidateForm) {
        /// <summary>
        /// Ejecuta la validación de un formulario
        /// </summary>
        try {
            debugger
            $(modValidateForm.idForm).validate({
                rules: modValidateForm.rules,
                highlight: modValidateForm.highlight,
                success: modValidateForm.success,
                submitHandler: modValidateForm.submitHandler
            });
        } catch (e) {
            console.error(e.message);
        }
    }
}