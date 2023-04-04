function Like(id) {
    $.ajax({
        type: "POST",
        url: "/Comments/AddLike",
        data: { id: id },
        success: function (result) {
            $("#Likes-" + id).empty(),
            $("#Likes-" + id).text(result)
        }
    });
};

function Dislike(id) {
    $.ajax({
        type: "POST",
        url: "/Comments/AddDislike",
        data: { id: id },
        success: function (result) {
            $("#Dislikes-" + id).empty(),
            $("#Dislikes-" + id).text(result)
        }
    })
}
