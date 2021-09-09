// Put JavaScript and JQuery for Rent area here

//Rental History Index Section
$("#RentalHistoryIndex").ready(() => {
	//When the mouse pointer enters any row, make the vertical ellipsis menu on that row visible
	$(".row").on("mouseenter", function () {
		$(this).find(".menu button").removeClass("invisible")
	})

	//When the mouse pointer leaves any row, make the vertical ellipsis menu on that row invisible
	//And, if the dropdown menu is open, close it.
	$(".row").on("mouseleave", function () {
		if ($(this).find(".menu").hasClass("show")) {
			$(this).find('.menu button').dropdown('toggle')
		}
		$(this).find(".menu button").addClass("invisible")
	})
})
//End Rental History Index Section

//Rental History Create and Edit Section
$("#RentalHistoryForm").ready(() => {
	//Somehow an ID can be ready if it doesn't even exist on the page...
	//This code leaves the function so an error doesn't occur on the index page.
	if (!$("#RentalHistoryForm").length) { return }

	//Function to change the Damages Incurred label based on the value of the Rental Damaged checkbox.
	var setDamagesIncurredLabel = () => {
		const damaged = $("#RentalDamaged")[0].checked
		$("#DamagesIncurred").parent().find("label").text(damaged ? "Damages Incurred" : "Notes")
	}

	//Set the label of the Rental Damaged checkbox
	$("#RentalDamaged").parent().parent().find("label").text("Damaged?")

	//Create an onchange event for the Rental Damaged checkbox
	$("#RentalDamaged").change(function () { setDamagesIncurredLabel() })

	setDamagesIncurredLabel()
})
//End Rental History Section
