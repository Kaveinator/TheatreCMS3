let onLikeClickUrl = $("#OnLikeClick").val();
let onDisikeClickUrl = $("#OnDislikeClick").val();

function addLike(commentId) {
    {
        try {
            var htmlID = commentId + "likes";
            var progressBarId = "#" + commentId + "bar";
            var progressBarContainerId = "#" + commentId + "bar";
            var ratioId = "#" + commentId + "ratio";
            $.ajax({
                url: onLikeClickUrl,
                type: "POST",
                data: { id: commentId },
                success: function (likeResult) {
                    document.getElementById(htmlID).innerHTML = likeResult.Data;
                    $(ratioId).load(location.href + " " + ratioId);
                    $(progressBarId).load(location.href + " " + progressBarId);
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
            var htmlDislikeID = commentId + "dislikes";
            $.ajax({
                url: onDisikeClickUrl,
                type: "POST",
                data: { id: commentId },
                success: function (result) {
                    document.getElementById(htmlDislikeID).innerHTML = result.Data;
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

/**/