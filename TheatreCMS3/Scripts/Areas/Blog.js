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
        var thisPage = $(".commentList").attr("data-CommentPath");
        //Sends input text to Create method in controller which creates a new comment in the Db with
        //text input as comment Message
        $.ajax({
            type: "POST",
            url: path,
            data: {message: message},
            success: function (result) {
                //Replace input text with placeholder text
                $("#commentMessage").val(null);                        
            },
            error: function (request, status, error) {
                serviceError();
            }
        });
        //Trying to make another ajax function that updates the list of comments without re-loading the page
        $.ajax({
            type: "GET",
            url: thisPage,
            success: function (data) {
                console.log(data);
                console.log('success');
            }
        });
    });

    // Cancel comment Button

    $(".cancelCommentBtn").click(function () {
        $("#commentMessage").val(null);
    });

    // Reply button 
    //Trying to make it display the comment form below the comment who's reply button the user clicked
    //So far can only get it to display the hidden form under every comment, or only under the comment 
    //at the bottom

    $(".replyBtn").click(function () {
        var id = $(this).attr("data-CommentId")
        console.log('clicked');
        $(".hiddenComment[data-commentId=" + id + "]").toggle();
    });

});