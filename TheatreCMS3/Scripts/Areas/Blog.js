let onLikeClickUrl = $("#OnLikeClick").val();
//$(function () {
//    $('#btnLike').click(function () {
function addLike(commentId) {
    {
        try {
            var htmlID = commentId + "likes";
            $.ajax({
                url: onLikeClickUrl,
                type: "POST",
                data: { id: commentId },
                success: function (result) {
                    document.getElementById(htmlID).innerHTML = result.Data;
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

var htmlID = commentId + "likes";
