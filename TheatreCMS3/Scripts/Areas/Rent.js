/***Rental History Create/Edit Page js***/
document.addEventListener("DOMContentLoaded", function () {
    // Adding variables to shorthand writing out syntax throughout code
    var checkbox = document.getElementById("RentalDamaged");
    var notesLabel = document.getElementById("notes");
    var damageIncurredLabel = document.getElementById("damage-incurred");

    // Function to update label visibility based on checkbox state
    function updateLabelVisibility() {
        if (checkbox.checked) {
            // Checkbox is checked, show "Damages Incurred" label and hide "Notes" label
            damageIncurredLabel.style.display = "block";
            notesLabel.style.display = "none";
        } else {
            // Checkbox is unchecked, show "Notes" label and hide "Damages Incurred" label
            damageIncurredLabel.style.display = "none";
            notesLabel.style.display = "block";
        }
    }
        // calling function to keep lable change when checkbox is checked
        updateLabelVisibility();
        // Event listener to handle checkbox change
        checkbox.addEventListener("change", updateLabelVisibility);
});
//***end of create/edit page***

//***sorting feature on Index Page***//

var originalOrder = $('.table tbody tr').slice(1).get().slice();

function sortRentalHistories(sortBy) {
    // Get all rows except the first one (header row)
    var rows = $('.table tbody tr').slice(1).get();

    // Sort the rows based on the selected option
    rows.sort(function (a, b) {
        var aValue, bValue;
        switch (sortBy) {
            case 'none':
                // Revert to the original order of table before sorting
                rows = originalOrder.slice();
                return originalOrder;
            case 'damaged':
                aValue = $(a).find('.icon-cell .fa-circle-xmark').length; // Check if damaged icon exists
                bValue = $(b).find('.icon-cell .fa-circle-xmark').length;
                return bValue - aValue;
            case 'undamaged':
                aValue = $(a).find('.icon-cell .fa-circle-check').length; // Check if undamaged icon exists
                bValue = $(b).find('.icon-cell .fa-circle-check').length;
                return bValue - aValue;
            case 'az':
                aValue = $(a).find('.rental-cell').text().trim();
                bValue = $(b).find('.rental-cell').text().trim();
                return aValue.localeCompare(bValue);
            case 'za':
                aValue = $(a).find('.rental-cell').text().trim();
                bValue = $(b).find('.rental-cell').text().trim();
                return bValue.localeCompare(aValue);
        }
    });

    // Re-add sorted rows to the table body b/c they kept disappearing 
    $.each(rows, function (index, row) {
        $('.table tbody').append(row);
    });
}

// Attach event listener to the dropdown menu
$('#sortSelect').change(function () {
    var sortBy = $(this).val();
    sortRentalHistories(sortBy);
});









//***Drop Down menu on Rental Index Page ***

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

