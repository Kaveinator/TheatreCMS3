
//function readURL(input) {
//    if (input.files && input.files[0]) {
//        var reader = new FileReader();

//        reader.onload = function (e) {
//            $('#BlogPhoto-Create--Input_Img').attr('src', e.target.result);
//        }

//        reader.readAsDataURL(input.files[0]);
//    }
//}

//$("#inputFile").change(function () {
//    readURL(this);
//});

; (function ($) {
    function readURL(input) {
        var $prev = $('#BlogPhoto-Create--Input_Img');

        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $prev.attr('src', e.target.result);
            }

            reader.readAsDataURL(input.files[0]);

            $prev.show();
        } else {
            $prev.hide();
        }
    }

    $('#inputFile').on('change', function () {
        readURL(this);
    });
})(jQuery);