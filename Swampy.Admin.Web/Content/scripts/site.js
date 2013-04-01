
/*$(document).ready(function () {
    $("span.field-validation-valid, span.field-validation-error").each(function () { });
    return $(this).addClass("help-inline");
});

$("form").submit(function () {
    if ($(this).valid()) {
        return $(this).find("div.control-group").each(function () {
            if ($(this).find("span.field-validation-error").length === 0) {
                return $(this).removeClass("error");
            }
        });
    } else {
        return $(this).find("div.control-group").each(function () {
            if ($(this).find("span.field-validation-error").length > 0) {
                return $(this).addClass("error");
            }
        });
    }
});

$("form").each(function () {
    return $(this).find("div.control-group").each(function () {
        if ($(this).find("span.field-validation-error").length > 0) {
            return $(this).addClass("error");
        }
    });
});*/


jQuery.validator.setDefaults({
    highlight: function (element, errorClass, validClass) {
        if (element.type === 'radio') {
            this.findByName(element.name).addClass(errorClass).removeClass(validClass);
        } else {
            $(element).addClass(errorClass).removeClass(validClass);
            $(element).closest('.control-group').removeClass('success').addClass('error');
        }
    },
    unhighlight: function (element, errorClass, validClass) {
        if (element.type === 'radio') {
            this.findByName(element.name).removeClass(errorClass).addClass(validClass);
        } else {
            $(element).removeClass(errorClass).addClass(validClass);
            $(element).closest('.control-group').removeClass('error').addClass('success');
        }
    }
});