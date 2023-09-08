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
    $('.deleteItem').click(function () {
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
            url: 'DeleteJson/' + x,
            dataType: "text",
            success: function (result) {
                console.log(result + " has been deleted");
                var ignoreSelection = $(".ignoreSelection-" + x);
                ignoreSelection.hide();
            },
            error: function (err) {
                console.log(err);
            }
        });
    });
};