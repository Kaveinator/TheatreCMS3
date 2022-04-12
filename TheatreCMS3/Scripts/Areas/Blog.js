
function myTest() {
    alert("Hello! I am an alert box!");
}

function addLike(commentId) {
    {
        try {
            $.ajax({
                url: '/Comments/GetAddLike',
                type: "POST",
                data: { id: commentId },
                success: function (result) {
                    console.log("it works");
                    $("div").find('span[class="blog-comments--like_count ' + commentId + '"]').text(result.Data.Likes);
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