$(document).ready(function () {
    $('#check-box input[type=checkbox]').change(function () {
        if ($(this).is(':checked')) {
            $('#label-id').text('Damages Incurred');
        } else {
            $('#label-id').text('Notes');
        }
    });
});

$(document).ready(function () {
    $('#check-box input[type=checkbox]').change(function () {
        console.log('Checkbox changed');
        if ($(this).is(':checked') {
            $('.fa-circle-check').show();
            $('.fa-circle-xmark').hide();
        } else {
            $('.fa-circle-check').hide();
            $('.fa-circle-xmark').show();
        }
    });
});