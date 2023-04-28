$('#RentalDamaged').click(function () {

    if ($('#RentalDamaged').is(':checked')) {
        $('.rental_history-create--damagesincurred').html('Damages Incurred');
    } else {
        $('.rental_history-create--damagesincurred').html('Notes');
    }
});