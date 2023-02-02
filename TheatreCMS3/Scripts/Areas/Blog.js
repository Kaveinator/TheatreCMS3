
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
            /*document.getElementById("progress").style.width = ratio;*/
            $("#progress").text(ratio);
            /*alert(ratio);*/
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
            $("#dislike").text(numDislikes);
            $("#progress").text(ratio);
            /*alert(ratio);*/
        })
}
