/* Rental History Create Page js */

document.addEventListener("DOMContentLoaded", function () {
    /*adding variables to shorthand writing out syntax throughout code*/
    var checkbox = document.getElementById("RentalDamaged");
    var notesLabel = document.getElementById("notes");
    var damageIncurredLabel = document.getElementById("damage-incurred");

    // Hiding "Damages Incurred" label and only show "Notes"
    damageIncurredLabel.style.display = "none";

    // Listen for changes in the checkbox for label switch in text field
    checkbox.addEventListener("change", function () {
        if (this.checked) {
            // Checkbox is checked, show "Damages Incurred" label and hide "Notes" label
            damageIncurredLabel.style.display = "block";
            notesLabel.style.display = "none";
        } else {
            // Checkbox is unchecked, show "Notes" label and hide "Damages Incurred" label
            damageIncurredLabel.style.display = "none";
            notesLabel.style.display = "block";
        }
    });
});

