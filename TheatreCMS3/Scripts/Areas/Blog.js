$("#likeBtn").click(function () {
    var Likes = $(likes).val();
    $.ajax({
        type: "POST",
        url: '@Url.Action("Comments", "AddLike")',
        data: JSON.,
        success: function (result) {

        }
    });
});

