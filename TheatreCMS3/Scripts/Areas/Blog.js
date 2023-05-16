function likeComment(commentId) {
    $.ajax({
        type: 'POST',
        url: '/Blog/Comments/LikeComment',
        data: { commentId: commentId },
        success: function (result) {
            $('#likes-' + commentId).text(result.likes);
            $('#dislikes-' + commentId).text(result.dislikes);
            $('#percentage-likes-' + commentId).text(result.likeRatio.toFixed(0) + '% Likes');
            $('#percentage-dislikes-' + commentId).text((100 - result.likeRatio.toFixed(0)) + '% Dislikes');
            $('#like-progress-bar-' + commentId).css('width', result.likeRatio + '%').attr('aria-valuenow', result.likes).attr('aria-valuemax', result.likes + result.dislikes);
            $('#dislike-progress-bar-' + commentId).css('width', (100 - result.likeRatio) + '%').attr('aria-valuenow', result.dislikes).attr('aria-valuemax', result.likes + result.dislikes);
        },
        error: function (result) {
            alert('An error occurred while processing your request.');
        }
    });
}

function dislikeComment(commentId) {
    $.ajax({
        type: 'POST',
        url: '/Blog/Comments/DislikeComment',
        data: { commentId: commentId },
        success: function (result) {
            $('#likes-' + commentId).text(result.likes);
            $('#dislikes-' + commentId).text(result.dislikes);
            $('#percentage-likes-' + commentId).text(result.likeRatio.toFixed(0) + '% Likes');
            $('#percentage-dislikes-' + commentId).text((100 - result.likeRatio.toFixed(0)) + '% Dislikes');
            $('#like-progress-bar-' + commentId).css('width', result.likeRatio + '%').attr('aria-valuenow', result.likes).attr('aria-valuemax', result.likes + result.dislikes);
            $('#dislike-progress-bar-' + commentId).css('width', (100 - result.likeRatio) + '%').attr('aria-valuenow', result.dislikes).attr('aria-valuemax', result.likes + result.dislikes);
        },
        error: function (result) {
            alert('An error occurred while processing your request.');
        }
    });
}