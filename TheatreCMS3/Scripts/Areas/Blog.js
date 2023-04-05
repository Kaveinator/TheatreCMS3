function Like(id) {
    $.ajax({
        type: "POST",
        url: "/Comments/AddLike",
        data: { id: id },
        success: function (result) {
            $("#Likes-" + id).empty();
            $("#Likes-" + id).text(result);
            GetRatio(id);
        }
    });
};

function Dislike(id) {
    $.ajax({
        type: "POST",
        url: "/Comments/AddDislike",
        data: { id: id },
        success: function (result) {
            $("#Dislikes-" + id).empty();
            $("#Dislikes-" + id).text(result);
            GetRatio(id);
        }
    })
}

function GetRatio(id) {
    $.ajax({
        type: "POST",
        url: "/Comments/Ratio",
        data: { id: id },
        success: function (Ratios) {
            $("#LikeBar-" + id).css("width", Ratios[0] + "%");
            $("#DislikeBar-" + id).css("width", Ratios[1] + "%");
        }
    })
}

function DeleteComment(id) {
    $.ajax({
        type: "POST",
        url: "/Comments/Delete",
        data: { id: id },
        success: function (id) {
            $("#Comment-" + id).html("");
        }
    })
}
