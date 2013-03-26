$(document).ready(function () {
  
    $('#endpoints').dataTable({
        "sDom": "<'row'<'span8'l><'span8'f>r>t<'row'<'span8'i><'span8'p>>",

        "bPaginate": false,
        "bLengthChange": false,
        "bFilter": true,
        "bSort": true,
        "bInfo": false,
        "bAutoWidth": false,
        "oLanguage": { "sSearch": "" }
    });

    $.extend($.fn.dataTableExt.oStdClasses, {
        "sSortAsc": "header headerSortDown",
        "sSortDesc": "header headerSortUp",
        "sSortable": "header"
    });

    $('.dataTables_filter input').attr("placeholder", "Filter");
    $('.dataTables_filter input').addClass("search-query");
    
});