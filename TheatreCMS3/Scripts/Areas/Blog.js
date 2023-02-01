
//Comment likes and dislikes
function Likes(id) {
    $.ajax({
        type: "POST",
        url: "/Comments/AddLikes",
        data: {id: id},
    })
}

function Dislikes(id) {
    $.ajax({
        type: "POST",
        url: "/Comments/AddDislikes",
        data: {id: id},
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

//function updateProgress(percentage) {
//    document.getElementById('progressBar').style.width = percentage + '%';
//    $('#progressText').html(percentage + '%');

//.done(function (msg) {
//    updateProgress(100 / host);