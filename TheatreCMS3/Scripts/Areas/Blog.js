// Function to update the progress bar
function updateProgressBars() {
    $('.comment-index--bg-custom').each(function () {
        var progressBar = $(this);
        var commentId = progressBar.data('comment-id');

        $.ajax({
            url: '/Blog/Comments/GetLikeRatio',
            data: { commentId: commentId },
            success: function (response) {
                var likeRatio = response.likeRatio;
                var dislikesRatio = 100 - likeRatio;

                progressBar.css('background-image', 'linear-gradient(to right, #D6972A ' + likeRatio + '%, #D6972A ' + likeRatio + '%, #28A745 ' + likeRatio + '%, #28A745 ' + likeRatio + '%)');
                progressBar.find('.likes-count').text(likeRatio.toFixed(2) + '%');
                progressBar.find('.dislikes-count').text(dislikesRatio.toFixed(2) + '%');
            },
            error: function () {
                console.log('Error occurred while updating progress bar.');
            }
        });
    });
}

// Calls the updateProgressBars function initially
updateProgressBars();

// Like button
function Like(id) {
    $.ajax({
        url: '/Comments/AddLike',
        type: 'POST',
        data: { id: id },
        success: function (response) {
            $('#like-count-' + id).text(response.likes);
            updateProgressBars(); // Passes the correct values
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}

// Dislike button
function Dislike(id) {
    $.ajax({
        url: '/Comments/AddDislike',
        type: 'POST',
        data: { id: id },
        success: function (response) {
            $('#dislike-count-' + id).text(response.dislikes);
            updateProgressBars(); // Passes the correct values
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}