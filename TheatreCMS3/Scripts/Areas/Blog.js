//Ajax function to Post to BlogPostController with the value taken from the Button creating the modal
$("#BlogPost-index--deleteModal").on('show.bs.modal', function (event) {
    let myUrl = $("#myUrl").val();
    let btn = $(event.relatedTarget);
    let id = btn.val();
    let modal = $(this);
    modal.find("#deleteButton").on("click", function (e) {
        $.ajax({
            type: "POST",
            url: myUrl,
            data: { Id: id },
            success: function () {
                $(btn).closest("tr").hide();
                $("#BlogPost-index--deleteModal").modal("hide");
                $(".BlogPost-index--deleteNotif").fadeIn(500).delay(3000).fadeOut(2000);
            },
            error: function () {
            }
        });
    });
})

//On Close Event for Modal that removes the listener from the DeleteButton that was applied above
$("#BlogPost-index--deleteModal").on('hide.bs.modal', function () {
    let modal = $(this);
    modal.find("#deleteButton").off();
})
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
            var likesId = commentId + "likes";
            var progressBarId = commentId + "bar";
            var ratioId = "#" + commentId + "ratio";
            $.ajax({
                url: onLikeClickUrl,
                type: "POST",
                data: { id: commentId },
                success: function (result) {
                    document.getElementById(likesId).innerHTML = result.Data["likes"];
                    $(ratioId).load(location.href + " " + ratioId);
                    document.getElementById(progressBarId).style.width = result.Data["likeRatio"];
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
            var dislikeId = commentId + "dislikes";
            var progressBarId = commentId + "bar";
            var ratioId = "#" + commentId + "ratio";
            $.ajax({
                url: onDisikeClickUrl,
                type: "POST",
                data: { id: commentId },
                success: function (result) {
                    document.getElementById(dislikeId).innerHTML = result.Data["dislikes"];
                    $(ratioId).load(location.href + " " + ratioId);
                    document.getElementById(progressBarId).style.width = result.Data["likeRatio"];
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

// Deletes Blog Author and hide's Modal, initiating shrinking animation.
function DeleteAuthors(id) {
    console.log("Hello");
    let myUrl = $("#deleteUrl").val();
    $.ajax({
        type: "POST",
        url: myUrl,
        data: { Id: id },
        success: function () {
            $("#BlogAuthorDeleteModal").modal("hide");
            $("#blogAuthorContainer" + id).addClass("animate__zoomOut");
            $("#blogAuthorContainer" + id).hide(1500);
        },
        error: function () {
            console.log("Failure to delete Author")
        }
    });
}

