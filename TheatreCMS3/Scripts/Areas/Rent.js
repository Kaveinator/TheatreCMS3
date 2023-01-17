$("#RentalDamaged").click(function () {
    if (this.checked) {
        document.getElementById("SpotTheChange").innerHTML = "Damages Incurred";
    }
    else {
        document.getElementById("SpotTheChange").innerHTML = "Notes";
    }
});

