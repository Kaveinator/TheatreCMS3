
var myComment;

function addLike(commentId) {
    {
        try {
            $.ajax({
                url: '/Comments/GetAddLike',
                type: "POST",
                data: { id: commentId },
                success: function (result) {
                    $("div").find('span[class="blog-comments--like_count ' + commentId + '"]').text(result.Data.Likes);
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
            $.ajax({
                url: '/Comments/GetAddDislike',
                type: "POST",
                data: { id: commentId },
                success: function (result) {
                    $("div").find('span[class="blog-comments--dislike_count ' + commentId + '"]').text(result.Data.Dislikes);
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


function hideMyComment() {
    {
        try {
            $.ajax({
                url: '/Comments/DeleteComment',
                type: "POST",
                data: { id: myComment },
                success: function (result) {
                    hideComment();
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


function deleteCommentConfirmation(commentId) {
    $("body").find('div[class="blog-comments--delete_confirm_page"]').css("display", "block");
    myComment = commentId;
}

function hideConfirmation() {
    $("body").find('div[class="blog-comments--delete_confirm_page"]').css("display", "none");
}

function hideComment()
{
    successDeleteMessage();
    $("body").find('div[class="blog-comments--comment ' + myComment + '"]').css("display", "none");
    $("body").find('div[class="blog-comments--delete_confirm_page"]').css("display", "none");
}

function successDeleteMessage() {
    $("body").find('div[class="blog-comments--delete_success"]').css("display", "block");
    $("body").find('div[class="blog-comments--delete_success"]').delay(3000).fadeOut(1000);
}