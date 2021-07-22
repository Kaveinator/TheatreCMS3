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


//Comment Section JS
$((function() {
    var url;
    var redirectUrl;
    var target;
    var commentContainerId;
    $('#blog-comments-container').prepend(`
        <div class="blog-comments-deleteSuccessBarContainer w-50 cmg-bg-dark">
            <div class="blog-comments-deleteSuccessBar progress ">
              <div class="progress-bar bg-success" role="progressbar" style="width: 100%" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100">
                    <p class="my-auto">The comment was deleted successfully<i class="fa fa-check" aria-hidden="true"></i></p></div>
            </div>
        </div>
            `);
    $('.blog-comments-deleteSuccessBarContainer').hide();
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
    {
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

            //$.get(url)
            //    .done((result) => {
            //        if (!redirectUrl) {
            //            return $(target).parent().parent().hide("slow");
            //        }
            //        window.location.href = redirectUrl;
            //    })
            //    .fail((error) => {
            //        if (redirectUrl)
            //            window.location.href = redirectUrl;
            //    }).always(() => {
            //        $("#deleteModal").modal("hide");
            //    });

//End Comment Section JS