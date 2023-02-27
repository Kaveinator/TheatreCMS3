$(document).ready(function () {
    // When checkbox is checked, show damages incurred section instead
    $('#damaged-checkbox').change(function () {
        if ($(this).is(':checked')) {
            $('#damages-incurred').show();
            $('#notes').hide();
        }
        else {
            $('#damages-incurred').hide();
            $('#notes').show();
        }                            
    });
});