
//Logic for the checkbox in Create and Edit for RentalHistory. If the Rental Damaged checkbox is clicked, the label 
//for the Notes section is changed to "Damages Incurred" and vice versa.

$("#RentalDamaged").click(function () {
    if (this.checked) {
        document.getElementById("SpotTheChange").innerHTML = "Damages Incurred";
    }
    else {
        document.getElementById("SpotTheChange").innerHTML = "Notes";
    }
});

