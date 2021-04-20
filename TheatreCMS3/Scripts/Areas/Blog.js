
//Add like 
$(document).ready(function () {
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
    // Add dislike
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

    $(".trashcan").click(function () {
        $(".deleteConfirmed").attr('data-CommentPath', $(this).attr("data-CommentPath"));
        $(".deleteConfirmed").attr('data-CommentId', $(this).attr("data-CommentId"));
    });

    //Confirm delete

    $(".deleteConfirmed").click(function () {
        console.log('clicked');
        var id = $(this).attr("data-CommentId");
        var path = $(this).attr("data-CommentPath");
        $.ajax({
            type: "POST",
            url: path,
            data: JSON.stringify({ "id": id }),
            success: function (result) {
                console.log(result);
                $("#deleteModal").modal('hide');
                $(".commentCard[data-commentId=" + id + "]").animate({ height: "0px" }, 1000, function () { $(this).remove(); });
                $(".successBadge").fadeIn(100).delay(3000).fadeOut(500);

            }
        });
    })

    //New Comment Button
    $(".newCommentBtn").click(function () {
        var message = $("#commentMessage").val();
        var path = $(this).attr("data-CommentPath");
        $.ajax({
            type: "POST",
            url: path,
            data: {message: message},
            success: function (result) {
                console.log(result);
                $("#commentMessage").val(null);
            },
            error: function (request, status, error) {
                serviceError();
            }
        });
    });

    $(".cancelCommentBtn").click(function () {
        $("#commentMessage").val(null);
    });
});