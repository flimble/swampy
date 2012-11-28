(function() {

  $(document).ready(function() {
    var getrows;
    $('.search-query').keyup(function() {
      var searchtext;
      searchtext = this.value;
      if (searchtext.length >= 4) {
        return getrows(searchtext);
      } else {
        return $('tr').show();
      }
    });
    return getrows = function(searchword) {
      var tableRow;
      tableRow = $("td").filter(function() {
        return $(this).text().toLowerCase().indexOf(searchword.toLowerCase()) >= 0;
      }).closest("tr");
      $('tr').hide();
      tableRow.show();
      return $('th').closest('tr').show();
    };
  });

}).call(this);
