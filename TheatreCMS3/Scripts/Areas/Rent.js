// Get the id of the rental checkbox \\
let rentalCheckbox = $('#RentalDamaged');

// Added an id the HTMl and grabbing it here with jQuery \\
let rentalCheckLabel = $('#rental-text-label')

// Add an event listener to the rental checkbox \\
$(rentalCheckbox).on('click', function () {
    // If the rental checkbox is checked, set the text value of the the label to 'Notes' \\
    if (rentalCheckbox.is(':checked')) {
        $('#RentalDamaged').val(true);
        rentalCheckLabel.text('Notes');
    }
    else {
        // If the rental checkbox is not checked, set the text value of the the label to 'Damages Incurred' \\
        $('#RentalDamaged').val(false);
         rentalCheckLabel.text('Damages Incurred');
    }
});