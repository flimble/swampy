/*var getrows;

$(document).ready(function () {
    var searchtext;
    $('.search-query').keyup(function () { });
    searchtext = this.value;
    if (searchtext.length >= 4) {
        return getrows(searchtext);
    } else {
        return $('tr').show();
    }
});

getrows = function (searchword) {
    var tableRow;
    tableRow = $("td").filter(function () {
        return $(this).text().toLowerCase().indexOf(searchword.toLowerCase()) >= 0;
    }).closest("tr");
    $('tr').hide();
    tableRow.show();
    return $('th').closest('tr').show();
};*/

$(document).ready(function () {   

    $('#save-configurationitem').click(function() {
        $(this).postForm();
    });
});