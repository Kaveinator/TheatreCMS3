function myFunction() {
    // Get the checkbox
    var checkbox = document.getElementById("RentalDamaged");
    // Get the output text
    var text = document.getElementById("rental_history-edit--alert");
    if (checkbox.checked == true) {
        text.innerHTML = "DamageIncurred"
    } if (checkbox.checked != true) { text.innerHTML = "Notes" } 
} 