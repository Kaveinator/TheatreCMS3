function likeComment(commentId) {
    $.ajax({
        type: 'POST',
        url: '/Blog/Comments/LikeComment',
        data: { commentId: commentId },
        success: function (data) {
            $('#likes-' + commentId).text(data.likes);
        }
    });
}

function dislikeComment(commentId) {
    $.ajax({
        type: 'POST',
        url: '/Blog/Comments/DislikeComment',
        data: { commentId: commentId },
        success: function (data) {
            $('#dislikes-' + commentId).text(data.dislikes);
        }
    });
}