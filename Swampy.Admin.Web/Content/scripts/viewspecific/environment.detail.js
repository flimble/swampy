$(document).ready(function () {

    //alert('in document ready');
    
    $('#myId-1').live('click',function (e) {


        e.preventDefault();

        $(this).postForm({ useAnchorHrefAsTarget: true});
    });

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