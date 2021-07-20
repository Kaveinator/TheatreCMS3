function getBlogBio(id) {
    $(document).ready(function () {
        var url = '/Blog/BlogAuthors/BlogBio/' + id;
        $.get(url, null, function (data) {
            $("#displayText" + id).html(data);
        });
    })
}

function getBlogPost(id) {
    $(document).ready(function () {
        $("#displayText" + id).html("Implmented in future stories");
    })
}
let onLikeClickUrl = $("#OnLikeClick").val();
let onDisikeClickUrl = $("#OnDislikeClick").val();

function addLike(commentId) {
    {
        try {
            var htmlID = commentId + "likes";
            $.ajax({
                url: onLikeClickUrl,
                type: "POST",
                data: { id: commentId },
                success: function (likeResult) {
                    document.getElementById(htmlID).innerHTML = likeResult.Data;
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
            var htmlDislikeID = commentId + "dislikes";
            $.ajax({
                url: onDisikeClickUrl,
                type: "POST",
                data: { id: commentId },
                success: function (result) {
                    document.getElementById(htmlDislikeID).innerHTML = result.Data;
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
