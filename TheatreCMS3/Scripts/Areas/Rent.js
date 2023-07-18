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

$('.dropdown').find('.dropdown-btn').hide();                      //hide the dropdown button on load

$(document).ready(function () {
    $('.rental-item').hover(
        function () {
            $(this).find('.dropdown-btn').show();                 //on hover show the dropdown button for that row
        },
        function () {
            $(this).find('.dropdown-btn').hide();                //on un-hover hide the dropdown button for that row
        }
    );
});