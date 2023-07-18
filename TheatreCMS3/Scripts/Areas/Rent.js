$(document).ready(function () {
    
    if ($('.check-box').is(':checked')) {
        $('.label-id').text('Damages Incurred');
    } else {
        $('.label-id').text('Notes');
    }

    $('.check-box').change(function () {
        console.log('Hello');
        if ($(this).is(':checked')) {
            $('.label-id').text('Damages Incurred');
        } else {
            $('.label-id').text('Notes');
        }
    });
});

$(document).ready(function () {
    if ($('.rental-item').is(':hover')) {
        $('.rental-dropdown').show;
    }
});