$(document).ready(function () {


});



function loadEditPopup(linkId, containerDiv) {
    $.get(linkId)
        .success(function (data) {
            var formId = $(data).closest('div').attr('id');
            $(containerDiv).html(data);
            $('#' + formId).modal('show');

        })
        .fail(function (jqXHR, textStatus, errorThrown) {

        });
}