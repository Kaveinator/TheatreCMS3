
//Comment likes and dislikes
function Likes(id) {
    $.ajax({
        type: "POST",
        url: "/Comments/AddLikes",
        data: {id: id},
    })
        .done(function (result) {
            $("#like").text(result.Data[0]);
        //    $('#progressBar').css('width', completedPercentage + '%');
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
