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
                $(".likes[data-CommentId="+id+"]").html(result);
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
                $(".dislikes[data-CommentId=" + id + "]").html(result);
            }
        });
    });

});