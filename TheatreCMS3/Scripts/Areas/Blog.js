
(function ($) {
    function readURL(input) {
        var $prev = $('#BlogPhoto-Create--Input_Img');

        if (input.files && input.files[0]) {
            var reader = new FileReader();

            function getBlogPost(id) {
                $(document).ready(function () {
                    $("#displayText" + id).html("Implmented in future stories");
                })
            }
        }



        $('#inputFile').on('change', function () {
            readURL(this);
        });

    }
})

//Comment Section JS
$((function () {
    var url;
    var redirectUrl;
    var target;
    var commentContainerId;

    //Delete Success bar gets added to html at the top of #blog-comments-container, but hidden. 
    $('#blog-comments-container').prepend(`
        <div class="blog-comments-deleteSuccessBarContainer w-50 cmg-bg-dark">
            <div class="blog-comments-deleteSuccessBar progress ">
              <div class="progress-bar bg-success" role="progressbar" style="width: 100%" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100">
                    <p class="my-auto">The comment was deleted successfully<i class="fa fa-check" aria-hidden="true"></i></p></div>
            </div>
        </div>
            `);
    $('.blog-comments-deleteSuccessBarContainer').hide();

    //deleteModal, also renders hidden.
    $('body').append(`
        <div id="deleteModal" class="modal" tabindex="-1" role="dialog">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title cms-text-main">Delete Comment?</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <p class="delete-modal-body cms-text-secondary-dark">Modal body text goes here.</p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" id="confirm-delete">Confirm Delete</button>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
`);

    //delete comment function makes a url from data, updates the body message, 
    //this way the body message can contain information about the comment, like the author.
    //displays the delete confirmation modal.
    $(".delete-comment").on('click', (e) => {
        e.preventDefault();

        target = e.target;
        var Id = $(target).data('id');
        var controller = $(target).data('controller');
        var action = $(target).data('action');
        var bodyMessage = $(target).data('body-message');
        commentContainerId = "#" + Id + "comment";
        redirectUrl = $(target).data('redirect-url');
        url = "/Blog/" + controller + "/" + action + "/" + Id;
        $(".delete-modal-body").text(bodyMessage);
        $("#deleteModal").modal("show");
    });

    //on clicking confirm delete function, hides the confirm delete modal
    //performs the ajax call to controller, hides the deleted comment
    //shows the success bar, then fades out. 
    $("#confirm-delete").on('click', () => {
        $("#deleteModal").modal("hide");
        try {
            $.ajax({
                url: url,
                type: "POST",
                success: function (result) {
                    $(".blog-comments-deleteSuccessBarContainer").show().delay(3000).fadeOut(1500);
                    $(commentContainerId).hide();
                },
                error: function (error) {
                    alert(error);
                }
            });
        }
        catch (e) {
            alert(e.message);
        }
    });
}()));

function addLike(commentId) {
    let onLikeClickUrl = $("#OnLikeClick").val();
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
        

function addDislike(commentId) {
    {
        let onDisikeClickUrl = $("#OnDislikeClick").val();
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
    ;
// Deletes Blog Author and hide's Modal, initiating shrinking animation.
function DeleteAuthors(id) {
    console.log("Hello");
    let myUrl = $("#deleteUrl").val();
    $.ajax({
        type: "POST",
        url: myUrl,
        data: { Id: id },
        success: function () {
            $("#blogAuthorContainer" + id).addClass("animate__zoomOut");
            $("#blogAuthorContainer" + id).hide(1500);
        },
        error: function () {
            console.log("Failure to delete Author")
        }
    });
}