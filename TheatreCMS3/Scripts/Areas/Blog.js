

$(document).ready(function () {
    console.log("loaded");
    $(".likeBtn").click(function () {
        console.log("clicked");
        var id = $(this).attr("data-CommentId");
        var path = $(this).attr("data-CommentPath");
        $.ajax({
            type: "POST",
            url: path,
            data: JSON.stringify({ "id": id }),
            success: function (result) {
                $(".likes[data-CommentId=" + id + "]").html(result.like);
                $(".progress-bar[data-CommentId=" + id + "]").css('width', result.ratio + '%');
                $(".like-ratio[data-CommentId=" + id + "]").html(result.ratio + '% likes');
            }
        });
    });

    $(".dislikeBtn").click(function () {
        console.log("clicked");
        var id = $(this).attr("data-CommentId");
        var path = $(this).attr("data-CommentPath");
        $.ajax({
            type: "POST",
            url: path,
            data: JSON.stringify({ "id": id }),
            success: function (result) {
                $(".dislikes[data-CommentId=" + id + "]").html(result.dislike);
                $(".progress-bar[data-CommentId=" + id + "]").css('width', result.ratio + '%');
                $(".like-ratio[data-CommentId=" + id + "]").html(result.ratio + '% likes');
            }
        });
    });

});