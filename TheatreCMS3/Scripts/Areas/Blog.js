////$(document).ready(function () {
////    $('#deleteBtn').click(function (e) {
////        e.preventDefault();
////        if (confirm("Are you sure you want to delete this image?")) {
////            $.ajax({
////                url: 'Blog/BlogPhotos/Delete/' + blogPhotoId,
////                type: 'POST',
////                success: function (result) {
////                    var ignoreSelection = $(".ignoreSelection-" + blogPhotoId);
////                    ignoreSelection.hide();
////                },
////                error: function (err) {
////                    console.log(err);
////                }
////            });
////        }
////    });
////});

$(document).ready(function () {
    console.log("Document is ready!");
    $('.deleteItem').click(function (e) {
        e.preventDefault();
        var iDToDelete = $(this).data('path');
        console.log("ID to delete = " + iDToDelete);
        myFunction(iDToDelete);
    }); 
});

function myFunction(x) {
    console.log("Second function triggered! Parameter is: " + x);
    $('.deleteBtn').click(function (e) {
        e.preventDefault();
        console.log("deleteBtn clicked!");
        $.ajax({
            type: 'POST',
            url: 'BlogPhotos/DeleteJson/' + x,
            dataType: "text",
            success: function (result) {
                var hidden = $('.hidden-' + x);
                hidden.hide();
            },
            error: function (err) {
                console.log(err);
            }
        });
    });
};