﻿$(document).ready(function () {
    
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

$('.dropdown').find('.dropdown-btn').hide();

$(document).ready(function () {
    $('tr').hover(
        function () {
            $(this).find('.dropdown-btn').show();
        },
        function () {
            $(this).find('.dropdown-btn').hide();
        }
    );
});