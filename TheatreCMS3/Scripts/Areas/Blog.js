
function Likes(id) {
    $.ajax({
        type: "POST",
        url: "/Comments/AddLikes",
        data: {id: id},
    })
        .done(function (result) {
            var numLikes = result.Data[0];
            var ratio = result.Data[1];
            $("#like").text(numLikes);
            alert(ratio);
        })
}

function Dislikes(id) {
    $.ajax({
        type: "POST",
        url: "/Comments/AddDislikes",
        data: {id: id},
    })
        .done(function (result) {
            $("#dislike").text('Dislikes ', result.Data[0]);
        })
}
