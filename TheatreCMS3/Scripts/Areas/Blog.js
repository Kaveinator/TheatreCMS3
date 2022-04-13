

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