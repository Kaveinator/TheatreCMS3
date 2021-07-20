let onLikeClickUrl = $("#OnLikeClick").val();
//$(function () {
//    $('#btnLike').click(function () {
function addLike(commentId) {
    {
        try {
            
            $.ajax({
                url: onLikeClickUrl,
                type: "POST",
                data: { id: commentId },
                success: function (result) {

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
$("htmlId").value = result;