
function Likes(id) {
    $.ajax({
        type: "POST",
        url: "/Comments/AddLikes",
        data: {id: id},
    })
        .done(function (result) {
            var numLikes = result.Data[0];
            var ratio = result.Data[1];
            $("#like-" + id).text(numLikes);
            $("#ratio-" + id).css("width", ratio.toPrecision(4) + "%");
            $("#ratio-" + id).text(ratio.toPrecision(4) + "% Likes");
        })
}

function Dislikes(id) {
    $.ajax({
        type: "POST",
        url: "/Comments/AddDislikes",
        data: {id: id},
    })
        .done(function (result) {
            var numDislikes = result.Data[0];
            var ratio = result.Data[1];
            $("#dislike-" + id).text(numDislikes);
            $("#ratio-" + id).css("width", ratio.toPrecision(4) + "%");
            $("#ratio-" + id).text(ratio.toPrecision(4) + "% Likes");
        })
}
