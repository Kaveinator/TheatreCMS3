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

//end of create page

//Drop Down menu on Index Page 

//drop down menu features to be invisible until hovered over
$(document).ready(function () {
    // Initially hide the dropdown menu
    $(".dropdown-menu").hide();


    // Show the dropdown button when hovering over a table row
    $("tr").mouseenter(function () {
        $(this).find(".dropdown-toggle").css("visibility", "visible");
    }).mouseleave(function () {
        $(this).find(".dropdown-toggle").css("visibility", "hidden");
    });

    // Show the dropdown menu when the dropdown button is clicked
    $(".dropdown-toggle").click(function () {
        $(this).next(".dropdown-menu").toggle();
    });
});
 //end of drop down menu on Rental History Index
