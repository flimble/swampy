###
  Site-wide coffee/javascript file. 
###


$(document).ready -> 
	$("span.field-validation-valid, span.field-validation-error").each ->
		$(this).addClass "help-inline"	



	$("form").submit ->
		if $(this).valid()
			$(this).find("div.control-group").each ->
				$(this).removeClass "error"  if $(this).find("span.field-validation-error").length is 0

		else
			$(this).find("div.control-group").each ->
				$(this).addClass "error"  if $(this).find("span.field-validation-error").length > 0



	$("form").each ->
		$(this).find("div.control-group").each ->
			$(this).addClass "error"  if $(this).find("span.field-validation-error").length > 0



