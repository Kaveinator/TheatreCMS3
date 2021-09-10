function clickAddLike(commentId) {
    {
        try {
            $.ajax({
                url: '/Comments/GetAddLike',
                type: "POST",
                data: { id: commentId },
                success: function (result) {
                    $("div").find('p[id="likeValue ' + commentId + '"]').text("Current Likes: " + result.Data.Likes);
                    getRatioComment(commentId);
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
                    $("div").find('p[id="dislikeValue ' + commentId + '"]').text("Current Dislikes: " + result.Data.DisLikes);
                    getRatioComment(commentId);
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
function getRatioComment(commentId) {
    {
        try {

            $.ajax({
                url: '/Comments/GetLikeRatio',
                type: "POST",
                data: { id: commentId },
                success: function (result) {
                    // progress bar
                    // like bar
                    var likeBar = "progbarLike " + commentId;
                    var progbarLike = document.getElementById(likeBar);
                    progbarLike.style.width = result.Data.LikeRatio + "%";
                    // dislike bar
                    var dislikeBar = "progbarDislike " + commentId;
                    var progbarDislike = document.getElementById(dislikeBar);
                    progbarDislike.style.width = result.Data.DislikeRatio + "%";
                    // Remove Add like span likevalue%
                    var likeBarInsideID = "progbarLikeInside " + commentId;
                    var progLikeSpan = document.getElementById(likeBarInsideID);                    
                    progLikeSpan.remove();
                    var spanLikeJson = "spanLikeJson " + commentId;
                    addSpanLike = document.getElementById(spanLikeJson)
                    var likeValuePercent = parseInt(result.Data.LikeRatio);
                    $('<span id="progbarLikeInside '+commentId+'">' + likeValuePercent + '%</span>').prependTo(addSpanLike);                    
                    // indide dislike span value %
                    var dislikeBarInsideID = "progbarDislikeInside " + commentId;
                    var progDislikeSpan = document.getElementById(dislikeBarInsideID);
                    progDislikeSpan.remove();
                    var spanDislikeJson = "spanDislikeJson " + commentId;
                    addSpanDislike = document.getElementById(spanDislikeJson);
                    var dislikeValuePercent = parseInt(result.Data.DislikeRatio);
                    $('<span id="progbarDislikeInside ' + commentId + '">' + dislikeValuePercent + '%</span>').prependTo(addSpanDislike);                                        
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