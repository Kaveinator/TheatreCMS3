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

        $('body').append(`
                        <div class="modal fade" id="deleteModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                <h4 class="modal-title" id="myModalLabel">Warning</h4>
                            </div>
                            <div class="modal-body delete-modal-body">
                            
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal" id="cancel-delete">Cancel</button>
                                <button type="button" class="btn btn-danger" id="confirm-delete">Delete</button>
                            </div>
                            </div>
                        </div>
                        </div>`);



    $(".delete-comment").on('click', (e) => {
        
            e.preventDefault();

            target = e.target;
            var Id = $(target).data('id');
            var controller = $(target).data('controller');
            var action = $(target).data('action');
            var bodyMessage = $(target).data('body-message');
            redirectUrl = $(target).data('redirect-url');

            url = "/" + controller + "/" + action + "?Id=" + Id;
            $(".delete-modal-body").text(bodyMessage);
            $("#deleteModal").modal("show");
        });

    $("#confirm-delete").on('click', () => {
        $("#deleteModal").modal("hide");
        try {
            
            $.ajax({
                url: url,
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

