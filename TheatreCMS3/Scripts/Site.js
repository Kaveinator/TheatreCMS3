//Rental History Section
$("#RentalHistoryForm").ready(() => {
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
});
//End Rental History Section
