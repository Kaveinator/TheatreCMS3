$(document).ready(function () {
    $('#check-box').change(function () {
        if ($(this).is(':checked')) {
            $('#label-id').text('Damages Incurred');
        } else {
            $('#label-id').text('Notes');
        }
    });
});


$('.dropdown').find('.dropdown-toggle').hide();

$(document).ready(function () {
    $('td').hover(
        function () {
            $(this).find('.dropdown-toggle').show();
        },
        function () {
            $(this).find('.dropdown-toggle').hide();
        }
    );
});