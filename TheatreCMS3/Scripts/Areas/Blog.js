//Like button
function Like(id) {
    $.ajax({
        url: '/Comments/AddLike',
        type: 'POST',
        data: { id: id },
        success: function (response) {
            $('#like-count-' + id).text(response.likes);
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}

//Dislike button
function Dislike(id) {
    $.ajax({
        url: '/Comments/AddDislike',
        type: 'POST',
        data: { id: id },
        success: function (response) {
            $('#dislike-count-' + id).text(response.dislikes);
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
}