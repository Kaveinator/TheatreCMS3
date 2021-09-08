function clickAddLike(commentId) {
    {
        try {
            
            $.ajax({
                url: '/Comments/GetAddLike',
                type: "POST",
                data: { id: commentId },
                success: function (result) {
                    $("#likeValue").text("Current Likes: " + result.Data);          
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
function clickAddDislike(commentId) {
    {
        try {

            $.ajax({
                url: '/Comments/GetAddDislike',
                type: "POST",
                data: { id: commentId },
                success: function (result) {
                    $("#dislikeValue").text("Current Dislikes: " + result.Data);
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