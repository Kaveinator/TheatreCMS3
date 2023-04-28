////$(document).ready(function () {

////    $(('#RentalDamaged')).click(function () {

////        alert('You clicked!');

////    });

////});

function Damaged() {
    if ($('#RentalDamaged').is(':checked')) {
        $('.rental_history-create--damagesincurred').html('Damages Incurred');
    } else {
        $('.rental_history-create--damagesincurred').html('Notes');
    }
}

