$("#likeBtn").click(function () {
    var id = $(likes).val();
    $.ajax({
        type: "POST",
        url: '@Url.Action("Comments", "AddLike")',
        data: JSON.,
        success: function (result) {

        }
    });
});

