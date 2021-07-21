let onLikeClickUrl = $("#OnLikeClick").val();
let onDisikeClickUrl = $("#OnDislikeClick").val();

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

