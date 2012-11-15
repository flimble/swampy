$(document).ready -> 
	$('.search-query').keyup ->
		searchtext = this.value		

		if searchtext.length >= 4
			getrows(searchtext) 
		else
			$('tr').show()
			



	getrows = (searchword) ->
		tableRow = $("td").filter(->
			return $(this).text().toLowerCase().indexOf(searchword.toLowerCase()) >= 0
			).closest("tr")

		$('tr').hide()

		tableRow.show()
		$('th').closest('tr').show()
			
		
		



		
		
