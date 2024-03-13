$(document).ready(function () {
    // Attach change event handler to the checkbox
    $('#rentalDamagedCheckbox').change(function () {
        // Check if checkbox is checked
        if ($(this).is(':checked')) {
            // If checked, change the label text to "Notes"
            $('label[for="DamagesIncurred"]').text('Notes');
        } else {
            // If not checked, restore the label text to 'Damages Incurred'
            $('label[for="DamagesIncurred"]').text('Damages Incurred');
        }
    });
});