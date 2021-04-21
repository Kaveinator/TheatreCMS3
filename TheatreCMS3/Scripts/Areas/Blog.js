$(document).ready(function () {

    // Add Like
    $(".likeBtn").click(function () {
        console.log("like clicked");
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

    // Add Dislike
    $(".dislikeBtn").click(function () {
        console.log("dislike clicked");
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

    

    // Delete
    $(".trashcan").click(function () {
        console.log('trashcan clicked');
        $(".deleteConfirmed").attr('data-CommentPath', $(this).attr("data-CommentPath"));
        $(".deleteConfirmed").attr('data-CommentId', $(this).attr("data-CommentId"));
    });

    // Confirm Delete

    $(".deleteConfirmed").click(function () {
        console.log('deleteConfirmed clicked');
        var id = $(this).attr("data-CommentId");
        var path = $(this).attr("data-CommentPath");
        $.ajax({
            type: "POST",
            url: path,
            data: JSON.stringify({ "id": id }),
            success: function (result) {
                //console.log(result);
                console.log(id);
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
        //Sends input text to Create method in controller which creates a new comment in the Db with
        //text input as comment Message
        $.ajax({
            type: "POST",
            url: path,
            data: { message: message },
            success: function (result) {
                //Replace input text with placeholder text
                $("#commentMessage").val(null);
                var jQueryResult = $(result);
                console.log(result)
                jQueryResult.find('.trashcan').click(function () {
                    console.log('test');
                    $(".deleteConfirmed").attr('data-CommentPath', $(this).attr("data-CommentPath"));
                    $(".deleteConfirmed").attr('data-CommentId', $(this).attr("data-CommentId"));
                });
                $(".newComment").prepend(jQueryResult);
            },
            error: function (request, status, error) {
                serviceError();
            }
        });
    });


    // Cancel comment Button

    $(".cancelCommentBtn").click(function () {
        $("#commentMessage").val(null);
    });

    // Reply button 
    // Displays the comment form below the comment who's reply button the user clicked

    $(".replyBtn").click(function () {
        var id = $(this).attr("data-CommentId");
        console.log('reply clicked');
        $(".hiddenComment[data-commentId=" + id + "]").fadeIn(100);
    });

    //Cancel Reply Button
    $('.cancelReplyBtn').click(function () {
        console.log('cancel reply button clicked');
        var id = $(this).attr("data-CommentId");
        $(".hiddenComment[data-commentId=" + id + "]").fadeOut(100);
    });

    
});