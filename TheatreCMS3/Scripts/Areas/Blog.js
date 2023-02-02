
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
//End Comment likes and dislikes

//Comments progress bar

//function LikeRatio(id) {
//    $.ajax({
//        type: "POST",
//        url: "/Comments/LikesRatio",
//        data: {id: id},
//    })
//}

function updateProgress(percentage) {
    document.getElementById('progressBar').style.width = percentage + '%';
    $('#progressText').html(percentage + '%');

//.done(function (msg) {
//    updateProgress(100 / host);