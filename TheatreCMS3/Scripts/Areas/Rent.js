// Rental History Create

$('#RentalDamaged').click(function () {
    
    if (this.checked) {
        document.getElementById("Rental_History-Create--Switch").innerHTML = "Damages";
    }
    else {
        document.getElementById("Rental_History-Create--Switch").innerHTML = "Notes";
    }
});