function likeComment(commentId) {
    $.ajax({
        type: 'POST',
        url: '/Blog/Comments/LikeComment',
        data: { commentId: commentId },
        success: function (data) {
            $('#likes-' + commentId).text(data.likes);
            $('#dislikes-' + commentId).text(data.dislikes);
            $('#progress-bar-' + commentId).css("width", data.likeRatio + "%");
        }
    });
}

function dislikeComment(commentId) {
    $.ajax({
        type: 'POST',
        url: '/Blog/Comments/DislikeComment',
        data: { commentId: commentId },
        success: function (data) {
            $('#likes-' + commentId).text(data.likes);
            $('#dislikes-' + commentId).text(data.dislikes);
            $('#progress-bar-' + commentId).css("width", data.likeRatio + "%");
        }
    });
}