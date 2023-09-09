// Functions to hide BlogPhotos on Index page once deleted

$(document).ready(function () {
    $('.deleteItem').click(function (e) {
        e.preventDefault();
        var iDToDelete = $(this).data('path');
        myFunction(iDToDelete);
    }); 
});

function myFunction(x) {
    $('.deleteBtn').click(function (e) {
        e.preventDefault();
        $.ajax({
            type: 'POST',
            url: 'BlogPhotos/DeleteJson/' + x,
            dataType: "text",
            success: function (result) {
                var hidden = $('.hidden-' + x);
                hidden.hide();
                document.getElementById("deleteDisplaySuccess").innerHTML = "The blog photo was deleted successfully";
                $('.deleteDisplaySuccess').show();
                setTimeout(function () {
                    $('#deleteDisplaySuccess').fadeOut('fast');
                }, 3000);
            },
            error: function (err) {
                document.getElementById("deleteDisplayFailure").innerHTML = "The blog photo could not be deleted";
                $('.deleteDisplayFailure').show();
                console.log(err);
                setTimeout(function () {
                    $('#deleteDisplayFailure').fadeOut('fast');
                }, 3000);
            }
        });
    });
};