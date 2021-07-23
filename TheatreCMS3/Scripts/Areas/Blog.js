
; (function ($) {
    function readURL(input) {
        var $prev = $('#BlogPhoto-Create--Input_Img');

        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $prev.attr('src', e.target.result);
            }

function addLike(commentId) {
    {
        try {
            var likesId = commentId + "likes";
            var progressBarId = commentId + "bar";
            var ratioId = "#" + commentId + "ratio";
            $.ajax({
                url: onLikeClickUrl,
                type: "POST",
                data: { id: commentId },
                success: function (result) {
                    document.getElementById(likesId).innerHTML = result.Data["likes"];
                    $(ratioId).load(location.href + " " + ratioId);
                    document.getElementById(progressBarId).style.width = result.Data["likeRatio"];
                },
                error: function (error) {
                    alert(error);
                }
            });
        }
        catch (e) {
            alert(e.message);
        }
    }
}

function addDislike(commentId) {
    {
        try {
            var dislikeId = commentId + "dislikes";
            var progressBarId = commentId + "bar";
            var ratioId = "#" + commentId + "ratio";
            $.ajax({
                url: onDisikeClickUrl,
                type: "POST",
                data: { id: commentId },
                success: function (result) {
                    document.getElementById(dislikeId).innerHTML = result.Data["dislikes"];
                    $(ratioId).load(location.href + " " + ratioId);
                    document.getElementById(progressBarId).style.width = result.Data["likeRatio"];
                },
                error: function (error) {
                    alert(error);
                }
            });
        }
        catch (e) {
            alert(e.message);
        }
    }
}

// Deletes Blog Author and hide's Modal, initiating shrinking animation.
function DeleteAuthors(id) {
    console.log("Hello");
    let myUrl = $("#deleteUrl").val();
    $.ajax({
        type: "POST",
        url: myUrl,
        data: { Id: id },
        success: function () {
            $("#blogAuthorContainer" + id).addClass("animate__zoomOut");
            $("#blogAuthorContainer" + id).hide(1500);
        },
        error: function () {
            console.log("Failure to delete Author")
        }
    });
}

    $('#inputFile').on('change', function () {
        readURL(this);
    });
})(jQuery);