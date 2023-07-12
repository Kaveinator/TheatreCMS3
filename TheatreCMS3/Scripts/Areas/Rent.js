$(document).ready(function () {
    $('#check-box input[type=checkbox]').change(function () {
        if ($(this).is(':checked')) {
            $('#label-id').text('Damages Incurred');
        } else {
            $('#label-id').text('Notes');
        }
    });
});